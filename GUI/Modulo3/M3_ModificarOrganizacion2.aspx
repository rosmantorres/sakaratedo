<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M3_ModificarOrganizacion2.aspx.cs" Inherits="templateApp.GUI.Modulo3.M3_ModificarOrganizacion2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Organizaciones</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Organizaciones</a> 
		    </li>

            <li>
			    <a href="../Modulo3/M3_ModificarOrganizacion.aspx">Seleccionar Organizacion</a> 
		    </li>
		
		    <li class="active">
			    Modificar Organizacion
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de Organización
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Modificar Organización
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

          

    <form class = "form-horizontal" role = "form">
   
 
   
   <div class = "form-group">
      <label for = "direccion" class = "col-sm-2 control-label">Direccion</label>
		
      <div class = "col-sm-10">
         <input type = "text" class = "form-control" id = "direccion" placeholder = "Urb. Santa Paula - El Cafetal, Caracas Venezuela">
      </div>
   </div>

    <div class = "form-group">
      <label for = "tecnica" class = "col-sm-2 control-label">Técnica</label>
		
      <div class = "col-sm-10">
         <input type = "text" class = "form-control" id = "tecnica" placeholder = "Seito Karate Do">
      </div>
   </div>

<div class = "form-group">
      <label for = "telefono1" class = "col-sm-2 control-label">Telefono</label>
		
      <div class = "col-sm-10">
         <input type = "text" class = "form-control" id = "telefono1" placeholder = "I(0212) 985-6512">
      </div>
   </div>
   
<div class = "form-group">
      <label for = "email" class = "col-sm-2 control-label">Email</label>
		
      <div class = "col-sm-10">
         <input type = "text" class = "form-control" id = "email" placeholder = "Seitokaratedo@gmail.com">
      </div>
   </div>

<div class = "form-group">
      <label for = "contacto" class = "col-sm-2 control-label">Persona de Contacto</label>
		
      <div class = "col-sm-10">
         <input type = "text" class = "form-control" id = "contacto" placeholder = "Alberto Rojas">
      </div>
   </div>


<div class = "form-group">
      <label for = "telefono2" class = "col-sm-2 control-label">Telefono del Contacto</label>
		
      <div class = "col-sm-10">
         <input type = "text" class = "form-control" id = "telefono2" placeholder = "(0414) 246-6742">
      </div>
   </div>



   
   <div class = "form-group">
      <div class = "col-sm-offset-2 col-sm-10">
         <button type = "submit" class = "btn btn-danger">Salvar modificaciones</button>
      </div>
   </div>
	
</form>
</asp:Content>
