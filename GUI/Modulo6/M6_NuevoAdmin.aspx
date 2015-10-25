<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M6_ProcesarSolicitud.aspx.cs" Inherits="templateApp.GUI.Modulo6.procesar_solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Creacion de Administrador
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div id="alert" runat="server">
    </div>

    <div class="box box-body">
        <legend class="scheduler-border">Usuario del Sistema</legend>
        <div class="row form-group">
            <label for="imputUserName" class="control-label col-xs-2">Nombre de usuario:</label>
            <div class="col-xs-10">
                <input type="text" class="form-control" id="imputUserName"  placeholder="ej: eltercera" required/>
            </div>
        </div>
        <div class="row form-group">
            <label for="imputPassword" class="control-label col-xs-2">Contraseña:</label>
            <div class="col-xs-10">
                <input type="password" class="form-control" id="imputPassword"  placeholder="" required/>
            </div>
        </div>
        <div class="row form-group">
            <label for="imputPasswordRe" class="control-label col-xs-2">Repetir contraseña:</label>
            <div class="col-xs-10">
                <input type="password" class="form-control" id="imputPasswordRe"  placeholder="" required/>
            </div>
        </div>                
        <legend class="scheduler-border">Datos Personales</legend>
        <div class="row form-group">
            <label for="imputNombres" class="control-label col-xs-2">Nombres:</label>
            <div class="col-xs-10">
                <input class="form-control" id="imputNombres"  placeholder="ej: Rómulo Jose" required/>
            </div>
        </div>
        <div class="row form-group">
            <label for="imputApellidos" class="control-label col-xs-2">Apellidos:</label>
            <div class="col-xs-10">
                <input class="form-control" id="imputApellidos" placeholder="ej: Rodriguez Rojas" required/>
            </div>
        </div>
        <div class="row form-group">
            <label for="dateNacimiento" class="control-label col-xs-2">Fecha de Nacimiento:</label>
            <div class="col-xs-10">
                <input type="text" id="dateNacimiento" readonly class="form-control" placeholder="dd/mm/aaaa" required/>
            </div>
        </div>
        <div class="row form-group">
            <label for="selectNacionalidad" class="control-label col-xs-2">Nacionalidad:</label>
            <div class="col-xs-10">
                <button id="selectNacionalidad" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                Seleccione una Nacionalidad <span class="caret"></span>
                </button>
                <ol id="selectNacionalidadOpts" class="dropdown-menu" role="menu"  onclick="">
                    <li value="1"><a href="#">Venezolano</a></li>
                    <li value="2"><a href="#">Extranjero</a></li>
                </ol>
            </div>
        </div>
        <div class="row form-group">
            <label for="inputCI" class="control-label col-xs-2">Cédula o Pasaporte:</label>
            <div class="col-xs-10">
                <input data-validation="number" type="text" class="form-control" id="inputCI" placeholder="ej: 19513536" required/>
            </div>
        </div>
        <div class="row form-group">
            <label for="selectSex" class="control-label col-xs-2">Sexo:</label>
            <div class="col-xs-10">
                <label class="radio-inline"><input type="radio" name="selectSex" checked>Femenino</label>
                <label class="radio-inline"><input type="radio" name="selectSex">Masculino</label>
            </div>
        </div>
        <div class="row form-group">
            <label for="inputMail" class="control-label col-xs-2">Correo Electrónico:</label>
            <div class="col-xs-10">
                <input type="email" class="form-control" id="inputMail" placeholder="ej: pedro@gmail.com" data-validation="email"/>
            </div>
        </div>
        <div class="row form-group">
            <label for="inputTelf" class="control-label col-xs-2">Teléfono:</label>
            <div class="col-xs-10">
                <input type="text" id="inputTelf" class="form-control"  placeholder="Ej: (0212)451-54-54" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"/>
            </div>
        </div>
        <div class="row form-group">
            <label for="inputMovil" class="control-label col-xs-2">Teléfono Móvil:</label>
            <div class="col-xs-10">
                <input type="text" id="inputMovil" class="form-control" placeholder="Ej: (0212)451-54-54" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"/>
            </div>
        </div>
        <div class="row form-group">
            <label for="textareaDir" class="control-label col-xs-2">Direccion de habitación:</label>
            <div class="col-xs-10">
                <textarea id="textareaDir" class="form-control col-xs-2" rows="5"></textarea>
            </div>
        </div>
        <div class="row" style="text-align: center">
            <input type="button" value="Aceptar" class="btn btn-success col-lg-offset-1" />
            <input type="button" value="Cancelar" class="btn btn-primary col-lg-offset-1" />
        </div>
    </div>
</asp:Content>