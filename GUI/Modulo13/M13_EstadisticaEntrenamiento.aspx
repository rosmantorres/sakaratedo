<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_EstadisticaEntrenamiento.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_EstadisticaEntrenamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">



    <div class="container">
<div class="row">
<div class="well">		
<form>
    <fieldset>
        <div class="form-group">
            <label for="query">Search:</label>
            <input class="form-control" name="query" id="query" placeholder="Start typing something to search..." type="text">              
        </div>
        <button type="submit" class="btn btn-primary">Search</button>
    </fieldset>
</form>
</div>
</div>
</div>

</asp:Content>

