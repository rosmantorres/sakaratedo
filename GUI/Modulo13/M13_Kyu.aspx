<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Inicio.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo12/M12_AgregarEliminarOrganizaciones.js") %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Lista de Kyu</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"></asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

<div class="container">

    <div class="table-responsive">
    
    <div align="center">
      <table class="table-hover table-bordered table-condensed">
        <tr>
          <td><a href="M13_Kyu_atletas.aspx"><img src="Kyu-imagenes/blanca-azul.jpg" width="92" height="72" class="img-responsive" /></a></td>
          <td><img src="Kyu-imagenes/celeste.jpg" width="92" height="72" class="img-responsive"/></td>
          <td><img src="Kyu-imagenes/celeste-amarillo.jpg" width="92" height="72"class="img-responsive" /></td>
          <td><img src="Kyu-imagenes/amarilla.jpg" width="92" height="72"class="img-responsive" /></td>
          <td><img src="Kyu-imagenes/naranja.jpg" width="92" height="72" class="img-responsive"/></td>
          </tr>
        <tr>
          <td><img src="Kyu-imagenes/naranja-verde.jpg" width="92" height="72"class="img-responsive" /></td>
          <td><img src="Kyu-imagenes/verde.jpg" width="92" height="72"class="img-responsive" /></td>
          <td><img src="Kyu-imagenes/purpura.jpg" width="92" height="72" class="img-responsive"/></td>
          <td><img src="Kyu-imagenes/azul.jpg" width="92" height="72" class="img-responsive"/></td>
          <td><img src="Kyu-imagenes/azul-roja.jpg" width="92" height="72" class="img-responsive"/></td>
          </tr>
        <tr>
          <td><img src="Kyu-imagenes/marron.jpg" width="92" height="72" class="img-responsive"/></td>
          <td><img src="Kyu-imagenes/marron-blanco.jpg" width="92" height="72"class="img-responsive" /></td>
          <td><img src="Kyu-imagenes/marron-negro.jpg" width="92" height="72"class="img-responsive" /></td>
          <td><img src="Kyu-imagenes/negro-blanco.jpg" width="92" height="72"class="img-responsive" /></td>
          <td><img src="Kyu-imagenes/negro.jpg" width="92" height="72" class="img-responsive" /></td>
          </tr>
      </table>
    </div>
    </div>

</div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="M13_Inicio.aspx">Reportes Dojo</a> 
		    </li>
            
		    <li class="active">
			    Kyu
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>