

<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_EstadisticaEntrenamiento.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_EstadisticaEntrenamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">


    
<div class="form-horizontal">
    <div class="control-group row-fluid form-inline">
        <label for="name" class="control-label"><p class="text-info" >   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Atleta&nbsp; &nbsp;</p>
        </label>
        <div class="controls">
            <input type="text" id="atleta" placeholder="Ingrese atleta" class="span3">
        </div>
    </div>
</div>



   
    <div class="form-horizontal">
    <div class="control-group row-fluid form-inline">
        &nbsp;<label for="name" class="control-label"><p class="text-info">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Contrincante&nbsp;<i class="icon-star"></i></p></label>
        <div class="controls">
            <input type="text" id="contrincante" placeholder="Ingrese rival" class="span3">
            <br />
            <br />
            <br />
        </div>
    </div>
</div>

     &nbsp;&nbsp;&nbsp;&nbsp&nbsp;
         &nbsp;&nbsp

         <a id="btn-exportarComp" class="btn btn-primary" type="submit" href="M13_EstadisticaEntrenaminto.aspx?eliminacionSuccess=1" onclick="return checkform();">Ver</a>

</asp:Content>

