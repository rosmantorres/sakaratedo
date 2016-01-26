//Funcion que activa o desactiva el Boton de Procesar Pago si los campos cumplen o no con ciertas condiciones.
function example() {
    //
    if (document.getElementById("contenidoCentral_DropDownList1").value === "-1") {

        document.getElementById("contenidoCentral_Monto").readOnly = true;
        document.getElementById("contenidoCentral_DatoPago").readOnly = true;
        document.getElementById("contenidoCentral_Monto").value = "";
        document.getElementById("contenidoCentral_DatoPago").value = "";
        document.getElementById("contenidoCentral_BotonPagar").disabled = true;
    }
    else {
        document.getElementById("contenidoCentral_Monto").value = "";
        document.getElementById("contenidoCentral_DatoPago").value = "";
        document.getElementById("contenidoCentral_Monto").readOnly = false;
        document.getElementById("contenidoCentral_DatoPago").readOnly = false;
    }
}

function onchangeExample() {
   
    if (document.getElementById("contenidoCentral_DropDownList1").value === "1") {
        var tarjeta = document.getElementById("contenidoCentral_DatoPago").value;
        var monto = document.getElementById("contenidoCentral_Monto").value;

        

        if (tarjeta.match(/^[0-9]{20}$/g) && monto.match(/^(([0-9]+)|([0-9]+)(\,{1})([0-9]+))$/g) != null) {

            document.getElementById("contenidoCentral_BotonPagar").disabled = false;
        }
        else {
            document.getElementById("contenidoCentral_BotonPagar").disabled = true;
        }

    }
    else
        if (document.getElementById("contenidoCentral_DropDownList1").value === "2" || document.getElementById("contenidoCentral_DropDownList1").value === "3") {
            var tarjeta = document.getElementById("contenidoCentral_DatoPago").value;
            var monto = document.getElementById("contenidoCentral_Monto").value;

            if (tarjeta.match(/^([0-9]{8}|[0-9]{10})$/g) != null && monto.match(/^(([0-9]+)|([0-9]+)(\,{1})([0-9]+))$/g)) {

                document.getElementById("contenidoCentral_BotonPagar").disabled = false;
            }
            else {
                document.getElementById("contenidoCentral_BotonPagar").disabled = true;
            }

        }


}


