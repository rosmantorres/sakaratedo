//Funcion que activa el boton si el valor seleccionado es diferente de -1, sino, lo desactiva
function example() {
    if ($('#<%=DropDownList1.ClientID %>').val() == -1) {

        $('#<%=BotonPagar.ClientID %>').attr("disabled", true);
    }
    else
        $('#<%=BotonPagar.ClientID %>').attr("disabled", false);
}


