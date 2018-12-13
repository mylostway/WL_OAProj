var enumCodeGender = (function(){
	
	var _log = function(msg){
		console.log(msg);
	}
	
	var _gen = function(id){
		var targetSel = $("#" + id);		
		if(!targetSel || !targetSel.html()){
			_log("can not find " + id + " element!!");
			return;
		}
		var optionArr = targetSel.find("option");
		if(!optionArr || !optionArr.length){
			_log(id + " select`s option is empty!");
			return;
		}
		var code = "public enum " + id + "Enums : int\n{\n";
		for(var i = 0;i < optionArr.length;i++){
			var line = "\t[EnumNames(\"" + optionArr[i].innerText + "\")]\n\tEnum" + i;
			if(i == 0) line += " = 0,";
			else line += ",";
			line += "\n";
			code += line;
		}
		code += "}";
		_log(code);
	}
	
	return {
		gen : _gen
	}
	
}());