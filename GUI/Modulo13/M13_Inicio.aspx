<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Inicio.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo12/M12_AgregarEliminarOrganizaciones.js") %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Bienvenidos al Modulo de Gestion de Reportes</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
  <p>Modulo Gestion de Reportes</p>
  <p>&nbsp;</p>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

             <img src="Imagenes/reportes.jpg" width="370" height="229" />

           
    </asp:Content>