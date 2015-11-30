// The plugin function for adding a new filtering routine
    $.fn.dataTableExt.afnFiltering.push(
    function (oSettings, aData, iDataIndex) {
        var dateStart = $("#fechaInicio").val();
        var dateEnd = $("#fechaFin").val();
        // aData represents the table structure as an array of columns, so the script access the date value 
        // in the first column of the table via aData[0]
        var evalDate = aData[2];
                     
        if (dateStart == "" && dateEnd == "") {
            return true;
        }
        else if (dateStart == "" || dateEnd == "") {
            return true;
        }
        else if (dateStart == "" && evalDate < dateEnd) {
            return true;
        }
        else if (dateStart <= evalDate && "" == dateEnd) {
            return true;
        }
        else if (dateStart <= evalDate && evalDate <= dateEnd) {
            return true;
        }
        else {
            return false;
        }

    });