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
		"varchar" : "string"
	}
	
	// 转换属性名字
	var _convName = function(nameStr){
		var arr = nameStr.split("_");
		if(!arr || 1 == arr.length) return nameStr;
		var ret = arr[0];
		for(var i = 1;i < arr.length;i++){
			var part = arr[i];
			ret += (part[0].toUpperCase() + part.substr(1))
		}
		return ret;
	}
	
	// 转换数据类型
	var _convType = function(typeStr){
		for(var e in _keyWordMap){
			if(typeStr.indexOf(e) >= 0) return _keyWordMap[e];
		}
		return typeStr;
	}
	
	
	// trim
	var _trim = function(str){
		return str.replace(/^\s+|\s+$/gm,'');
	}
	
	// 根据db表创建语句生成Entity属性
	var _go = function(str){
		var resultStr = "";	
		var arr = str.split("|");
		for(var i = 0;i < arr.length;i++){
			var line = "";
			var lArr = arr[i].split(" ");
			if(lArr.length <= 1) continue;	
			var name = _convName(_trim(lArr[0]));
			var type = _convType(_trim(lArr[1]));
			var comment = "";
			for(var j = 2;j < lArr.length;j++){
				if(lArr[j] == "comment") {
					comment = _trim(lArr.splice(j+1).join(" "));
					break;
				}
			}
			
			line += "\/\/\/ <summary>\r\n";			
			line += "\/\/\/ " + comment.substr(1,comment.length - 2) + "\r\n";
			line += "\/\/\/ </summary>\r\n";
			line += "public " + (type + " " + name + "{ get; set; }");
			resultStr += (line + "\r\n\r\n");
		}		
		return resultStr;
	}
	
	// 根据db表创建语句生成xml配置
	var _toXml = function(str){
		var resultStr = "";	
		var arr = str.split("|");
		for(var i = 0;i < arr.length;i++){
			var line = "";
			var lArr = arr[i].split(" ");
			if(lArr.length <= 1) continue;
			//console.log(lArr[0] + "," + _trim(lArr[0]));
			var name = _trim(lArr[0]);			
			var entityFieldName = _convName(name);
			
			line += "<property name=\"" + entityFieldName + "\" column=\"" + name + "\" />"
			resultStr += (line + "\r\n");
		}
		return resultStr;
	}
	
	return {
		go : _go,
		toXml : _toXml
	}
	
}())