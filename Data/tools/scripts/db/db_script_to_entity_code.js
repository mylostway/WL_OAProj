/**
	根据db表创建语句生成Entity属性和xml映射
	
	用法：
		1、将创建语句的字段复制到新文档，然后用'|'替换'\r\n'。
		2、将字符串复制到浏览器F12，var str = "val"
		3、调用entityGen.go(str); 和 entityGen.toXml(str);
**/

var entityGen = (function(){
	
	var _log = function(str){
		console.log(str);
	}
	
	// 类型映射
	var _keyWordMap = {		
		"int" : "int",
		"datetime" : "DateTime",
		"date" : "DateTime",
		"tinyint" : "byte",		
		"varchar" : "string",
		"char" : "string",
		"decimal" : "int",
	}
	
	// 转换属性名字
	var _convName = function(nameStr){
		var arr = _trim(nameStr).split("_");
		if(!arr || 1 == arr.length) {
			return nameStr;
		}
		var part = arr[0];
		var ret = (part[0].toUpperCase() + part.substr(1));
		for(var i = 1;i < arr.length;i++){
			part = arr[i];
			ret += (part[0].toUpperCase() + part.substr(1))
		}
		return ret;
	}
		
	
	var _toCammalCaseStr = function(str){
		return (str[0].toUpperCase() + str.substr(1));
	}
	
	// 转换数据类型
	var _convType = function(typeStr){
		for(var e in _keyWordMap){
			if(typeStr.indexOf(e) >= 0) return _keyWordMap[e];
		}
		// return typeStr;
		return "";
	}
	
	// 行头格式的分隔符
	var LINE_STAND_FORMAT_STR = "\t";
	
	// 行头子元素格式的分隔符
	var LINE_STAND_CHILD_FORMAT_STR = "\t\t";

	// 根据规则生成特性
	var _genAttribute = function(fieldArr){		
		var ret = "";
		if(!fieldArr) return ret;
		var strLine = fieldArr.join(" ");
		
		// required属性
		if(strLine.indexOf("not null") >= 0 && strLine.indexOf("default ") < 0){
			ret += (LINE_STAND_FORMAT_STR + "[Required]\r\n");
		}
		
		// 字符串限制长度
		var type = fieldArr[1].toLocaleLowerCase();
		if(type.indexOf("char") >= 0 || type.indexOf("byte") >= 0){
			var regMatch = /\(\s*\d+\s*\)/.exec(type);
			if(regMatch && regMatch.length){
				var strLen = regMatch[0];
				strLen = strLen.substr(1,strLen.length - 2);
				ret += (LINE_STAND_FORMAT_STR + "[MaxLength(" + _trim(strLen) + ")]\r\n");
			}
		}
		
		return ret;
	}
	
	// trim
	var _trim = function(str){
		return str.replace(/^\s+|\s+$/gm,'');
	}
	
	// 去除空格和mysql分隔符'`'的影响
	var _fixLineStr = function(strLine){
		return _trim(strLine).replace(/`/g,"");
	}
	
	// 去掉创表语句的注释行和空行
	var _removeUselessLine = function(lineArr){
		var retVal = [];
		if(!lineArr || !lineArr.length) return retVal;
		for(var i = 0;i < lineArr.length;i++){
			var line = _trim(lineArr[i]);
			if(!line || !line.length) continue;
			if(line.substr(0,2) == "--") continue;
			retVal.push(lineArr[i]);
		}
		return retVal;
	}
	
	var LINE_SPLITOR = "\n";
	
	var m_tabName = "";
	var m_className = "";
	
	// 根据db表创建语句生成Entity属性
	var _go = function(str){
		var resultStr = "";	
		var arr = _removeUselessLine(str.split(LINE_SPLITOR));		
		var i = 0;
		var firstLine = _fixLineStr(arr[0]).toLocaleLowerCase();
		var lArr = [];
		if(firstLine.indexOf("create table ") >= 0){
			lArr = firstLine.split(" ");
			var j = 0;
			var tabName = "";
			for(;j < lArr.length;j++){
				if(lArr[j].indexOf("t_") >= 0) {
					tabName = lArr[j];
					var idx = tabName.indexOf(".");
					if(idx >= 0) tabName = tabName.substr(idx + 1);
					break;
				}
			}
			m_tabName = tabName;
			m_className = _toCammalCaseStr(_convName(tabName.substr(2))) + "Entity";
			resultStr += "[Table(\"" + tabName + "\")]\r\npublic class " + m_className + " : BaseEntity<int>\r\n{\r\n";
			i = 1;
		}
		for(;i < arr.length;i++){
			var line = "";
			lArr = _fixLineStr(arr[i]).split(" ");
			if(lArr.length <= 1) continue;	
			var name = _convName(_trim(lArr[0]));
			// 已经从基类继承，忽略这两行
			if(name == "Fid" || name == "Fstate") continue;
			var type = _convType(_trim(lArr[1]));
			if(!type) continue;
			var comment = "";
			for(var j = 2;j < lArr.length;j++){
				if(lArr[j] == "comment") {
					comment = _trim(lArr.splice(j+1).join(" "));
					break;
				}
			}
			
			line += "\t\/\/\/ <summary>\r\n";			
			line += "\t\/\/\/ " + comment.substr(1,comment.length - 2) + "\r\n";
			line += "\t\/\/\/ </summary>\r\n";
			line += _genAttribute(lArr);
			line += "\tpublic virtual " + (type + " " + name + "{ get; set; }");
			resultStr += (line + "\r\n\r\n");
		}		
		if(firstLine.indexOf("create table ") >= 0) resultStr += "}";
		return resultStr;
	}
	
	// 根据db表创建语句生成xml配置
	var _toXml = function(str){
		var resultStr = "";	
		var arr = _removeUselessLine(str.split(LINE_SPLITOR));
		var i = 0;
		var firstLine = _fixLineStr(arr[0]).toLocaleLowerCase();
		var lArr = [];
		if(firstLine.indexOf("create table ") >= 0){			
			resultStr += "<class name=\"" + m_className + "\" table=\"" + m_tabName + "\">\r\n";
			i = 1;
		}
		for(;i < arr.length;i++){
			var line = "";
			lArr = _fixLineStr(arr[i]).split(" ");
			if(lArr.length <= 1) continue;
			// 结束创表语句
			//if(/\)\s*ENGINE\s*=\s*Innodb/.test(arr[i])){
			if(/\)\s*engine\s*=\s*innodb/.test(arr[i].toLocaleLowerCase())){
				resultStr += "</class>\r\n";
				break;
			}			
			var name = _trim(lArr[0]);
			var type = _convType(_trim(lArr[1]));
			if(!type) continue;
			var entityFieldName = _convName(name);
			// 特殊字段处理
			if(entityFieldName == "Fid")
			{
				line += (LINE_STAND_FORMAT_STR + "<id name=\"" + entityFieldName + "\" type=\"int\" column=\"" + name + "\" unsaved-value=\"0\">\r\n");
				line += (LINE_STAND_CHILD_FORMAT_STR + "<generator class=\"identity\"/>\r\n");
				line += (LINE_STAND_FORMAT_STR + "</id>\r\n");
			}
			else if(entityFieldName == "Fstate")
			{
				line += (LINE_STAND_FORMAT_STR + "<property name=\"" + entityFieldName + "\" column=\"" + name + "\" not-null=\"true\" />\r\n\r\n");
			}
			else
			{		
				line += (LINE_STAND_FORMAT_STR + "<property name=\"" + entityFieldName + "\" column=\"" + name + "\" />\r\n");
			}
			
			resultStr += (line);
		}
		return resultStr;
	}
	
	return {
		go : _go,
		toXml : _toXml,
		LINE_SPLITOR : LINE_SPLITOR
	}
	
}())
