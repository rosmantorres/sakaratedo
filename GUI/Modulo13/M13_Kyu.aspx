<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Prueba.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo12/M12_AgregarEliminarOrganizaciones.js") %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Lista de Morosos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Morosos</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

<div class="container">

    <div class="table-responsive">
    
    <div align="center">
      <table class="table-hover table-bordered table-condensed">
        <tr>
          <td><img src="Kyu-imagenes/blanca-azul.jpg" width="92" height="72" class="img-responsive" /></td>
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