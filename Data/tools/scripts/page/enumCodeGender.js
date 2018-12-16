var enumCodeGender = (function(){
	
	var _log = function(msg){
		console.log(msg);
	}

    var _genCodeOnOptionsArr = function (optionArr,enumPrefix) {
        if (!optionArr || !optionArr.length) {
            _log(enumPrefix + " select`s option is empty!");
            return;
        }
        var code = "public enum " + enumPrefix + "Enums : int\n{\n";
        for (var i = 0; i < optionArr.length; i++) {
            var line = "\t[EnumNames(\"" + optionArr[i].innerText + "\")]\n\t" + optionArr[i].innerText;
            if (i == 0) line += " = 0,";
            else line += ",";
            line += "\n";
            code += line;
        }
        code += "}";
        _log(code);
    }

	var _genOnId = function(id){
		var targetSel = $("#" + id);		
		if(!targetSel || !targetSel.html()){
			_log("can not find " + id + " element!!");
			return;
		}
        _genCodeOnOptionsArr(targetSel.find("option"),id);
	}

    var _genAll = function(){
        var allSelArr = $("select");
        if (!allSelArr || !allSelArr.length) return;
        for (var i = 0; i < allSelArr.length; i++) {
            var optionArr = $(allSelArr[i]).find("option");
            var prefix = allSelArr[i].name;            
            if (!prefix) prefix = allSelArr[i].id;
            if (!prefix) prefix = "Sel" + i;
            _genCodeOnOptionsArr(optionArr, prefix);
        }
    }

	return {
        genOnId: _genOnId,
        genAll: _genAll
	}
	
}());