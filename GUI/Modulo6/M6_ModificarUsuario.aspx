<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M6_ProcesarSolicitud.aspx.cs" Inherits="templateApp.GUI.Modulo6.procesar_solicitud" %>

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
			    <a href="M6_ListaUsuarios.aspx">Usuarios</a>
		    </li>

		    <li class="active">
			    Nuevo Usuario
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de Usuarios
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Creación de Nuevo Usuario
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <!-- Customized stylesheet -->
    <link href="css/styles.css" rel="stylesheet" />
    <div id="alert" runat="server">
    </div>

    <div class="box box-body">
        <legend class="scheduler-border">Datos Personales</legend>
            <div class="row form-group">
                <label for="nameBox" class="control-label col-xs-2 needed">Nombres:</label>
                <div class="col-xs-10">
                    <asp:TextBox id="nameBox" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label for="lastBox" class="control-label col-xs-2 needed">Apellidos:</label>
                <div class="col-xs-10">
                    <asp:TextBox id="lastBox" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label for="birthBox" class="control-label col-xs-2 needed">Fecha de Nacimiento:</label>
                <div class="col-xs-10">
                    <asp:TextBox id="birthBox" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label for="natDrop" class="control-label col-xs-2 needed">Nacionalidad:</label>
                <div class="col-xs-10">
                    <div class="dropdown" runat="server" id="divNatDrop">
                        <asp:DropDownList id="natDrop"  cssclass="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged="natDropChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>  
                </div>
            </div>
            <div class="row form-group">
                <label for="idBox" class="control-label col-xs-2 needed">Cédula o Pasaporte:</label>
                <div class="col-xs-10">
                    <asp:TextBox id="idBox" CssClass="form-control" runat="server" data-validation="number" required></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label for="sexGroup" class="control-label col-xs-2 needed">Sexo:</label>
                <div class="col-xs-10">
                    <asp:RadioButton id="femRadio" CssClass="radio-inline" Text="Femenino" Checked="False" GroupName="sexGroup" runat="server" />
                    <asp:RadioButton id="masRadio" CssClass="radio-inline" Text="Masculino" Checked="False" GroupName="sexGroup" runat="server" />
                </div>
            </div>
            <div class="row form-group">
                <label for="emailBox" class="control-label col-xs-2 needed">Correo Electrónico:</label>
                <div class="col-xs-10">
                    <asp:TextBox id="emailBox" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label for="phoneBox" class="control-label col-xs-2  needed">Teléfono:</label>
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
            <div class="row form-group">
                <label for="bloodDrop" class="control-label col-xs-2">Tipo de Sangre:</label>
                <div class="col-xs-10">
                    <div class="dropdown" runat="server" id="divBloodDrop">
                        <asp:DropDownList id="bloodDrop"  cssclass="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged="bloodDropChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>                  
                </div>
            </div>
            <div class="row form-group">
                <label for="textareaAlegias" class="control-label col-xs-2">Alergias:</label>
                <div class="col-xs-10">
                    <asp:TextBox id="alergyBox" textmode="MultiLine" rows="5" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label for="weightBox" class="control-label col-xs-2">Peso:</label>
                <div class="col-xs-10">
                    <asp:TextBox id="weightBox" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label for="heightBox" class="control-label col-xs-2">Estatura:</label>
                <div class="col-xs-10">
                    <asp:TextBox id="heightBox" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="row" style="text-align: center">
                <asp:Button id="agreeButton" cssclass="btn btn-success col-lg-offset-1" Text="Aceptar" OnClick="agreed" runat="server"/>
                <asp:Button id="cancelButton" cssclass="btn btn-success col-lg-offset-1" Text="Aceptar" OnClientClick="window.open('M6_ListaUsuarios.aspx', 'ListarUsuarios');" runat="server"/>
            </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tableSolisitudes").DataTable({
                "language": {
                    "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                }
            });
        });
    </script>
</asp:Content>
