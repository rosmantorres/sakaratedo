<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M6_NuevoAdmin.aspx.cs" Inherits="templateApp.GUI.Modulo6.M6_NuevoAdmin" %>

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
			    <a href="../Modulo4/M4_ListarDojos.aspx">Dojo</a> 
		    </li>

            <li>
			    <a href="../Modulo4/M4_ListarDojos.aspx">Gestion de Dojos</a> 
		    </li>

            <li>
			    <a href="../Modulo4/M4_AgregarDojo.aspx">Agregar Dojo</a> 
		    </li>
		
		    <li class="active">
			    Creacion de Administrador
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Creacion de Administrador
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Creacion del primer administrador
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div id="alert" runat="server">
    </div>

    <div class="box box-body">
        <legend class="scheduler-border">Usuario del Sistema</legend>
        <div class="row form-group">
            <label for="userBoxBox" class="control-label col-xs-2">Nombre de usuario:</label>
            <div class="col-xs-10">
                <asp:TextBox id="userBox" cssclass="form-control" runat="server" required></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <label for="passwordBox" class="control-label col-xs-2">Contraseña:</label>
            <div class="col-xs-10">
                <asp:TextBox id="passwordBox" CssClass="form-control" TextMode="password" runat="server" required/>
            </div>
        </div>
        <div class="row form-group">
            <label for="password2Box" class="control-label col-xs-2">Repetir contraseña:</label>
            <div class="col-xs-10">
                <asp:TextBox id="password2Box" CssClass="form-control" TextMode="password" runat="server" required/>
            </div>
        </div>                
        <legend class="scheduler-border">Datos Personales</legend>
        <div class="row form-group">
            <label for="nameBox" class="control-label col-xs-2">Nombres:</label>
            <div class="col-xs-10">
                <asp:TextBox id="nameBox" cssclass="form-control" runat="server" required></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <label for="lastBox" class="control-label col-xs-2">Apellidos:</label>
            <div class="col-xs-10">
                <asp:TextBox id="lastBox" cssclass="form-control" runat="server" required></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <label for="birthBox" class="control-label col-xs-2">Fecha de Nacimiento:</label>
            <div class="col-xs-10">
                <asp:TextBox id="birthBox" cssclass="form-control" runat="server" required></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <label for="natDrop" class="control-label col-xs-2">Nacionalidad:</label>
            <div class="col-xs-10">
                <div class="dropdown" runat="server" id="divNatDrop">
                    <asp:DropDownList id="natDrop"  cssclass="btn btn-default dropdown-toggle" runat="server" SelectedIndexChanged="natDropChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row form-group">
            <label for="idBox" class="control-label col-xs-2">Cédula o Pasaporte:</label>
            <div class="col-xs-10">
                <asp:TextBox id="idBox" CssClass="form-control" runat="server" required></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <label for="sexBox" class="control-label col-xs-2">Sexo:</label>
            <div class="col-xs-10">
                <asp:RadioButton id="femRadio" CssClass="radio-inline" Text="Femenino" Checked="False" GroupName="sexGroup" runat="server" />
                    <asp:RadioButton id="masRadio" CssClass="radio-inline" Text="Masculino" Checked="False" GroupName="sexGroup" runat="server" />
            </div>
        </div>
        <div class="row form-group">
            <label for="sexBox" class="control-label col-xs-2">Correo Electrónico:</label>
            <div class="col-xs-10">
                <asp:TextBox id="emailBox" cssclass="form-control" runat="server" required></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <label for="phoneBox" class="control-label col-xs-2">Teléfono:</label>
            <div class="col-xs-10">
                <asp:TextBox id="phoneBox" cssclass="form-control" runat="server" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})" required></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <label for="mobileBox" class="control-label col-xs-2">Teléfono Móvil:</label>
            <div class="col-xs-10">
                <asp:TextBox id="mobileBox" cssclass="form-control" runat="server" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})" required></asp:TextBox>
            </div>
        </div>
        <div class="row form-group">
            <label for="addressBox" class="control-label col-xs-2">Direccion de habitación:</label>
            <div class="col-xs-10">
                <asp:TextBox id="addressBox" textmode="MultiLine" rows="5" cssclass="form-control" runat="server" required></asp:TextBox>
            </div>
        </div>
        <div class="row" style="text-align: center">
            <asp:Button id="agreeButton" cssclass="btn btn-success col-lg-offset-1" Text="Aceptar" runat="server" OnClick="agreeButton_Click"/>
            <asp:Button id="cancelButton" cssclass="btn btn-success col-lg-offset-1" Text="Cancelar" OnClientClick="window.open('M6_ListaUsuarios.aspx', 'ListarUsuarios');" runat="server"/>
        </div>
    </div>

    <script type="text/javascript">
        document.getElementById("aceptar").onclick = function () {
            location.href = "../Modulo4/M4_ListarDojos.aspx";
        };
        document.getElementById("cancelar").onclick = function () {
            location.href = "../Modulo4/M4_ListarDojos.aspx";
        };
    </script>
</asp:Content>
