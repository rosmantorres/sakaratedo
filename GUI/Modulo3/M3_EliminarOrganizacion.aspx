<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M3_EliminarOrganizacion.aspx.cs" Inherits="templateApp.GUI.Modulo3.M3_EliminarOrganizacion" %>
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
		
		    <li class="active">
			    Eliminar Organizacion
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    <h1 class="modal-title">Eliminar Organización</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

 
 Organizaciones Registradas :
<div class="btn-group-vertical" role="group" aria-label="...">
  <button type="button" class="btn btn-default">Seito Karate Do</button>
  <button type="button" class="btn btn-default">Kenshin Karate Do</button>
  <button type="button" class="btn btn-default">Seito Kobudo Karate Do</button>
  <button type="button" class="btn btn-default">Shotokan Karate Do</button>


</div>

       <span class = "help-block">
      Seleccione la organizacion a eliminar y luego pulse 'Eliminar'
   </span>

    


       <div class = "form-group">
      <div class = "col-sm-offset-2 col-sm-10">
       <button type="submit" class="btn btn-xs btn-danger">Eliminar</button>
      </div>
   </div>


</asp:Content>
