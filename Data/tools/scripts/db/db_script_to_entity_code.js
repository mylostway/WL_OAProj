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
	
	// 类型映射
	var _keyWordDefaultValueMap = {		
		"int" : "0",
		"DateTime" : "DateTime.Now",
		"byte" : "0",		
		"double" : "0",
		"string" : "\"\"",
	}
	
	// 转换属性名字
	// 规则为：用下划线分组单词，然后每个组的单词首字母大写。
	var _convName = function(nameStr){
		return nameStr;
		// 2018-10-03 FIX：不用下面规则了，为了兼容以后可能迁移Chloe.net
		var arr = _trim(nameStr).split("_");
		if(!arr || 1 == arr.length) {
			return nameStr;
		}
		var part = arr[0];
		var ret = _toCammalCaseStr(part);
		for(var i = 1;i < arr.length;i++){
			part = arr[i];
			ret += _toCammalCaseStr(part);
		}
		return ret;
	}
	
	
	// 转换属性名字
	// 规则为：用下划线分组单词，然后每个组的单词首字母大写。
	var _convTabName = function(nameStr){
		var arr = _trim(nameStr).split("_");
		if(!arr || 1 == arr.length) {
			return nameStr;
		}
		var part = arr[0];
		var ret = _toCammalCaseStr(part);
		for(var i = 1;i < arr.length;i++){
			part = arr[i];
			ret += _toCammalCaseStr(part);
		}
		return ret;
	}
	
	
	// 获取类型字段对应的默认值
	var _getDefaultFieldVal = function(type){
		var ret = _keyWordDefaultValueMap[type];
		if(!ret) ret = "default(" + type + ")";
		return ret;
	}
		
	
	// 转换字符串为CammalCase形式 - 首字母大写
	var _toCammalCaseStr = function(str){
		return (str[0].toUpperCase() + str.substr(1));
	}
	
	// 转换字符串为LittleCase形式 - 首字母小写
	var _toLittleCaseStr = function(str){
		return (str[0].toLowerCase() + str.substr(1));
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
	
	// 记录所有该类的字段名称，用于制作copy构造函数	
	var m_classFieldsDic = {};
	
	var _genConstructor = function(){
		if(!m_className) return "";
		var ret = "\t\tpublic " + m_className + "(){ }\n\n";
				
		ret += "\t\tpublic " + m_className + "(" + m_className + " rhs)" + LINE_SPLITOR + "\t\t{" + LINE_SPLITOR + "\t\t\tif(null == rhs) return;" + LINE_SPLITOR;
		for(var e in m_classFieldsDic){
			ret += "\t\t\tthis." + e + " = rhs." + e + ";" + LINE_SPLITOR;
		}
		ret += "\t\t}\n";
		return ret;
	}
	
	
	var _genEqualFunctionCode = function(){
		if(!m_className) return "";
		// 重载 == 操作符
		var ret = "\n\n\t\tpublic static bool operator ==(" + m_className + " lhs, " + m_className + " rhs)" + LINE_SPLITOR + "\t\t{" + LINE_SPLITOR ;
		ret += "\t\t\tif (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;" + LINE_SPLITOR;
		ret += "\t\t\tif (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;" + LINE_SPLITOR;
		ret += "\t\t\tif (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;" + LINE_SPLITOR;
		ret += "\t\t\t return (" + LINE_SPLITOR;
		for(var e in m_classFieldsDic){
			ret += "\t\t\t\tlhs." + e + " == rhs." + e + " &&" + LINE_SPLITOR;
		}
		// 去掉最后的 &&
		ret = ret.substr(0,ret.length - 3);
		ret += "\n\t\t\t);\n\t\t}";
		
		// 重载配套的 != 操作符
		ret += (LINE_SPLITOR + LINE_SPLITOR);
		ret += "\t\tpublic static bool operator !=(" + m_className + " lhs, " + m_className + " rhs)" + LINE_SPLITOR + "\t\t{" + LINE_SPLITOR + "\t\t\t return !(lhs == rhs);" + LINE_SPLITOR + "\t\t}" + LINE_SPLITOR;
				
		return ret;
	}
	
	
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
			m_className = _toCammalCaseStr(_convTabName(tabName.substr(2))) + "Entity";
			resultStr += "[Table(\"" + tabName + "\")]\r\npublic class " + m_className + " : BaseEntity<int>\r\n{\r\n";
			i = 1;
		}
		m_classFieldsDic = {};
		for(;i < arr.length;i++){
			var line = "";
			lArr = _fixLineStr(arr[i]).split(" ");
			if(lArr.length <= 1) continue;
			var type = _convType(_trim(lArr[1]));
			if(!type) continue;
			var name = _convName(_trim(lArr[0]));
			m_classFieldsDic[name] = 1;
			// 已经从基类继承，忽略这两行
			if(name == "Fid" || name == "Fstate") continue;			
			var comment = "";
			for(var j = 2;j < lArr.length;j++){
				if(lArr[j].toLowerCase() == "comment") {
					comment = _trim(lArr.splice(j+1).join(" "));
					break;
				}
			}
			
			var fieldName = _toLittleCaseStr(name);
			//line += LINE_STAND_FORMAT_STR + "protected " + (type + " " + fieldName + " = " + _getDefaultFieldVal(type) + ";") + LINE_SPLITOR;
			line += LINE_STAND_FORMAT_STR + "\/\/\/ <summary>" + LINE_SPLITOR;			
			line += LINE_STAND_FORMAT_STR + "\/\/\/ " + comment.substr(1,comment.length - 2) + LINE_SPLITOR;
			line += LINE_STAND_FORMAT_STR + "\/\/\/ </summary>" + LINE_SPLITOR;
			line += _genAttribute(lArr);
			line += "\tpublic virtual " + (type + " " + name + "{ get; set; }");
            //line += "\tpublic virtual " + (type + " " + name + "{ get { return " + fieldName + "; } set { " + fieldName + " = value; } }");
            // 因为db设置的原因（varchar列大部分都设置成not null default），而字符串在C#里默认为null，导致insert的时候会报错
            //if (type == "string") line += " = \"\";";
			resultStr += (line + "\r\n\r\n");
		}
		resultStr += _genConstructor();
		resultStr += _genEqualFunctionCode();
		if(firstLine.indexOf("create table ") >= 0) resultStr += "}";
		return resultStr;
	}
	
	var _toViewMode = function(str){
		var resultStr = "";	
		var arr = _removeUselessLine(str.split(LINE_SPLITOR));
		var i = 0;
		var firstLine = _fixLineStr(arr[0]).toLocaleLowerCase();
		var lArr = [];
		var viewModeName = "";
		if(m_className) {
			viewModeName = m_className + "ViewMode";
			resultStr += "public class " + viewModeName + " : " + m_className + ", INotifyPropertyChanged, IIsCheckableView\n{\n";
			resultStr += "\tpublic " + viewModeName + "() { }\n\n\tpublic " + viewModeName + "(" + m_className + " rhs) : base(rhs) { }\n\n";
			i = 1;
		}
		for(;i < arr.length;i++){
			var line = "";
			lArr = _fixLineStr(arr[i]).split(" ");
			if(lArr.length <= 1) continue;	
			var name = _convName(_trim(lArr[0]));
			// 已经从基类继承，忽略这两行
			if(name == "Fstate") continue;
			if(name == "Fid"){
				//line += 
				continue;
			}
			var type = _convType(_trim(lArr[1]));
			if(!type) continue;
			var comment = "";
			for(var j = 2;j < lArr.length;j++){
				if(lArr[j].toLowerCase() == "comment") {
					comment = _trim(lArr.splice(j+1).join(" "));
					console.log(comment);
					break;
				}
			}
			
			var fieldName = _toLittleCaseStr(name);
			line += LINE_STAND_FORMAT_STR + "\/\/\/ <summary>" + LINE_SPLITOR;
			line += LINE_STAND_FORMAT_STR + "\/\/\/ viewMode子属性 - " + comment.substr(1,comment.length - 2) + LINE_SPLITOR;
			line += LINE_STAND_FORMAT_STR + "\/\/\/ </summary>" + LINE_SPLITOR;
			//line += _genAttribute(lArr);
			//line += "\tpublic virtual " + (type + " " + name + "{ get; set; }");
			line += "\tpublic " + (type + " V" + name + "\n\t{\n\t\tget { return " + fieldName + "; }\n\t\tset\n\t\t{\n\t\t\tif (" + fieldName + " == value) return;\n\t\t\t" + fieldName + " = value;\n\t\t\tOnPropertyChanged();\n\t\t }\n\t }");
			resultStr += (line + "\n\n");
		}		
		resultStr += "\tbool isSelected;\n";
		resultStr += "\tpublic string IsSelected\n\t{\n\t\tget { return DataConvetor.ConvertBoolToStrSeen(isSelected); }\n\t\tset\n\t\t{\n\t\tvar val = DataConvetor.ConvertStrBoolToVal(value);\n\t\tif (isSelected == val) return;\n\t\tisSelected = val;\n\t\tOnPropertyChanged();\n\t\t}\n\t}\n\n";
		resultStr += "\tpublic event PropertyChangedEventHandler PropertyChanged;\n\tprotected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)\n\t{\n\t\tPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));\n\t}\n\n"
		
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

    var _toJson = function (str,isWithMock) {
        var resultStr = "";	
		var arr = _removeUselessLine(str.split(LINE_SPLITOR));
		var i = 0;
		var firstLine = _fixLineStr(arr[0]).toLocaleLowerCase();
		var lArr = [];
		var viewModeName = "";
		if(m_className) {
            resultStr += m_className + " : {\n";
			i = 1;
		}
		for(;i < arr.length;i++){
			var line = "";
			lArr = _fixLineStr(arr[i]).split(" ");
			if(lArr.length <= 1) continue;	
			var name = _convName(_trim(lArr[0]));
			// 已经从基类继承，忽略这两行
			if(name == "Fstate") continue;
			if(name == "Fid"){
				//line += 
				continue;
            }
            var type = _trim(lArr[1]).toLowerCase();
            if (!type) continue;
            if (!_convType(type)) continue;
			var comment = "";
			for(var j = 2;j < lArr.length;j++){
				if(lArr[j].toLowerCase() == "comment") {
					comment = _trim(lArr.splice(j+1).join(" "));
					break;
				}
			}
			
            var fieldName = name;
			
            line += "\t " + fieldName + " : ";
            if (!isWithMock) line += "'',";
            else {
                switch (type) {
                    case "int": {
                        line += "Mock.Random.integer(1,9999),";
                        break;
                    }
                    case "tinyint": {
                        line += "Mock.Random.integer(1,9),";
                        break;
                    }          
                    case "datetime": {
                        line += "Mock.Random.date(),";
                        break;
                    }
                    default: {
                        var cmpFieldName = fieldName.toLowerCase();
                        if (cmpFieldName.indexOf("memo") >= 0) {
                            line += "Mock.Random.csentence(),";
                        }
                        else if (cmpFieldName.indexOf("mark") >= 0) {
                            line += "Mock.Random.word().toUpperCase(),";
                        }
                        else if (cmpFieldName.indexOf("phone") >= 0
                            || cmpFieldName.indexOf("mobile") >= 0
                            || cmpFieldName.indexOf("fax") >= 0
                            || cmpFieldName.indexOf("deposit") >= 0
                            || cmpFieldName.indexOf("account") >= 0
                            || cmpFieldName.indexOf("qq") >= 0) {
                            line += "Mock.Random.id().substr(0,10),";
                        }
                        else if (cmpFieldName.indexOf("status") >= 0
                            || cmpFieldName.indexOf("state") >= 0) {
                            line += "Mock.Random.integer(0, 2).toString(),";
                        }
                        else if (cmpFieldName.indexOf("wx") >= 0) {
                            line += "Mock.Random.word() + \"@wx.tenpay.com\",";
                        }
                        else {
                            line += "Mock.Random.cname(),";
                        }
                        
                        break;
                    }
                }
            }
			resultStr += (line + "\n");
        }		

		if(firstLine.indexOf("create table ") >= 0) resultStr += "}";
		return resultStr;
    }
	
	return {
		go : _go,
		toXml : _toXml,
        toViewMode: _toViewMode,
        toJson: _toJson,

		LINE_SPLITOR : LINE_SPLITOR
	}
	
}())
