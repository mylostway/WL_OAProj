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
		"tinyint" : "byte",	
		//"varchar\(.+\)" : "string",		
		"varchar" : "string",
		"char" : "string",
	}
	
	// 转换属性名字
	var _convName = function(nameStr){
		var arr = nameStr.split("_");
		if(!arr || 1 == arr.length) return nameStr;
		var part = arr[0];
		var ret = (part[0].toUpperCase() + part.substr(1));
		for(var i = 1;i < arr.length;i++){
			part = arr[i];
			ret += (part[0].toUpperCase() + part.substr(1))
		}
		return ret;
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
	
	var LINE_SPLITOR = "\n";
	
	var m_tabName = "";
	var m_className = "";
	
	// 根据db表创建语句生成Entity属性
	var _go = function(str){
		var resultStr = "";	
		var arr = str.split(LINE_SPLITOR);
		var i = 0;
		var firstLine = arr[0];
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
			m_className = _convName(tabName.substr(2)) + "Entity";
			resultStr += "[Table(\"" + tabName + "\")]\r\npublic class " + m_className + " : BaseEntity<int>\r\n{\r\n";
			i = 1;
		}
		for(;i < arr.length;i++){
			var line = "";
			lArr = arr[i].split(" ");
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
		var arr = str.split(LINE_SPLITOR);
		var i = 0;
		var firstLine = arr[0];
		var lArr = [];
		if(firstLine.indexOf("create table ") >= 0){			
			resultStr += "<class name=\"" + m_className + "\" table=\"" + m_tabName + "\">\r\n";
			i = 1;
		}
		for(;i < arr.length;i++){
			var line = "";
			lArr = arr[i].split(" ");
			if(lArr.length <= 1) continue;
			// 结束创表语句
			if(/\)\s*ENGINE\s*=\s*Innodb/.test(arr[i])){
				resultStr += "</class>\r\n";
				break;
			}			
			var name = _trim(lArr[0]);	
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