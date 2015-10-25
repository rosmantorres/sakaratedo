<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M3_Modificar_org.aspx.cs" Inherits="templateApp.GUI.Modulo3.M3_Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

        <h1>Modificar Datos de la Organizacion</h1>
 Organizaciones Registradas :
<div class="btn-group-vertical" role="group" aria-label="...">
  <button type="button" class="btn btn-default">Seito Karate Do</button>
  <button type="button" class="btn btn-default">Kenshin Karate Do</button>
  <button type="button" class="btn btn-default">Seito Kobudo Karate Do</button>
  <button type="button" class="btn btn-default">Shotokan Karate Do</button>


</div>

    

           <span class = "help-block">
      Seleccione la organizacion a modificar  y luego pulse 'Modificar Datos'
   </span>





    <div id="browse_app">
  <a class="btn btn-xs btn-info" href="M3_Modificar2_org.aspx">Modificar Datos</a>

</div>



</asp:Content>
