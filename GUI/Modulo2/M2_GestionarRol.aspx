<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M2_GestionarRol.aspx.cs" Inherits="templateApp.GUI.Modulo2.M2_Prueba" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Gestionar Usuario</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Dojo</a> 
		    </li>
		
		    <li class="active">
			    Listar Dojos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de roles
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Agregar o Quitar roles a un usuario

    Nombre(s):
    Apellido(s):
    Correo:
    Identificador:
    Dojo:

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<div>
    <form id="formulario" runat="server">
        <div>
            <select name="origen[]" id="origen" multiple="multiple" size="8">
                <option value="1">Opción 1</option>
                <option value="2">Opción 2</option>
                <option value="3">Opción 3</option>
                <option value="4">Opción 4</option>
                <option value="5">Opción 5</option>
                <option value="6">Opción 6</option>
                <option value="7">Opción 7</option>
                <option value="8">Opción 8</option>
            </select>
        </div>
        <div>
            <input type="button" class="pasar izq" value=" »"><input type="button" class="quitar der" value="« ">
        </div>
        <div class="">
            <select name="destino[]" id="destino" multiple="multiple" size="8"></select>
        </div>
        <p class="clear"><input type="submit" class="submit" value="Guardar cambios"></p>
    </form>
</div>
</asp:Content>
