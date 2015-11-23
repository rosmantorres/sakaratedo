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
			    Nueva Solicitud
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Solicitudes de inscripción
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Nueva Solicitud de Insripción
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <!-- Customized stylesheet -->
    <link href="css/styles.css" rel="stylesheet" />
    <div id="alert" runat="server">
    </div>

    <div class="box box-body">
        <div>
            <form class="form-horizontal">
                <!--
                <fieldset class="scheduler-border">
                    <legend class="scheduler-border">Seleccion de Dojo</legend>
                    <div class="form-group">
                        <label for="selectOrganizacion" class="control-label col-xs-2">Organizacion:</label>
                        <div class="col-xs-10">
                            <button id="selectOrganizacion" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Seleccione una Organizacion <span class="caret"></span>
                            </button>
                            <ol id="selectOrganizacionOpts" class="dropdown-menu" role="menu"  onclick="">
                                <li value="1"><a href="#">Organizacion 1</a></li>
                                <li value="2"><a href="#">Organizacion 1</a></li>
                                <li value="2"><a href="#">Organizacion 1</a></li>
                            </ol>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="selectDojo" class="control-label col-xs-2">Dojo:</label>
                        <div class="col-xs-10">
                        <button id="selectDojo" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Seleccione un Dojo <span class="caret"></span>
                            </button>
                            <ol id="selectDojoOpts" class="dropdown-menu" role="menu"  onclick="">
                                <li value="1"><a href="#">Dojo 2</a></li>
                                <li value="2"><a href="#">Dojo 2</a></li>
                                <li value="2"><a href="#">Dojo 3</a></li>
                            </ol>
                        </div>
                    </div>
                </fieldset>-->

                <fieldset class="scheduler-border">
                    <legend class="scheduler-border">Datos Personales</legend>
                    <div class="form-group">
                        <label for="imputNombres" class="control-label col-xs-2">Nombres:</label>
                        <div class="col-xs-10">
                            <input class="form-control" id="imputNombres"  placeholder="ej: Romulo Jose" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="imputApellidos" class="control-label col-xs-2">Apellidos:</label>
                        <div class="col-xs-10">
                            <input class="form-control" id="imputApellidos" placeholder="ej: Romulo Jose" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="dateNacimiento" class="control-label col-xs-2">Fecha de Nacimiento:</label>
                        <div class="col-xs-10">
                            <input type="text" id="dateNacimiento" readonly class="form-control" placeholder="dd/mm/aaaa" required/>
                        </div>
                    </div>
                    <div class="form-group">
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
                    <div class="form-group">
                        <label for="inputCI" class="control-label col-xs-2">Cédula o Pasaporte:</label>
                        <div class="col-xs-10">
                            <input data-validation="number" type="text" class="form-control" id="inputCI" placeholder="ej: 19513536" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selectSex" class="control-label col-xs-2">Sexo:</label>
                        <div class="col-xs-10">
                            <label class="radio-inline"><input type="radio" name="selectSex" checked>Femenino</label>
                            <label class="radio-inline"><input type="radio" name="selectSex">Masculino</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputMail" class="control-label col-xs-2">Correo Electrónico:</label>
                        <div class="col-xs-10">
                            <input type="email" class="form-control" id="inputMail" placeholder="ej: pedro@gmail.com" data-validation="email"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputTelf" class="control-label col-xs-2">Teléfono:</label>
                        <div class="col-xs-10">
                            <input type="text" id="inputTelf" class="form-control"  placeholder="Ej: (0212)451-54-54" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputMovil" class="control-label col-xs-2">Teléfono Móvil:</label>
                        <div class="col-xs-10">
                            <input type="text" id="inputMovil" class="form-control" placeholder="Ej: (0212)451-54-54" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="textareaDir" class="control-label col-xs-2">Direccion de habitación:</label>
                        <div class="col-xs-10">
                            <textarea id="textareaDir" class="form-control col-xs-2" rows="5"></textarea>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selectSangre" class="control-label col-xs-2">Tipo de Sangre:</label>
                        <div class="col-xs-10">
                        <button id="selectSangre" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Seleccione un tipo de sangre <span class="caret"></span>
                            </button>
                            <ol id="selectSangreOpts" class="dropdown-menu" role="menu"  onclick="">
                                <li value="1"><a href="#">O-</a></li>
                                <li value="2"><a href="#">O+</a></li>
                                <li value="3"><a href="#">A-</a></li>
                                <li value="4"><a href="#">A+</a></li>
                                <li value="5"><a href="#">B-</a></li>
                                <li value="6"><a href="#">B+</a></li>
                                <li value="7"><a href="#">AB-</a></li>
                                <li value="8"><a href="#">AB+</a></li>
                            </ol>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="textareaAlegias" class="control-label col-xs-2">Alergias:</label>
                        <div class="col-xs-10">
                            <textarea id="textareaAlegias" class="form-control col-xs-2" rows="5"></textarea>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPeso" class="control-label col-xs-2">Peso:</label>
                        <div class="col-xs-10">
                            <input type="text" id="inputPeso" class="form-control"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEstatura" class="control-label col-xs-2">Estatura:</label>
                        <div class="col-xs-10">
                            <input type="text" id="inputEstatura" class="form-control"/>
                        </div>
                    </div>
                </fieldset>
                <fieldset class="scheduler-border" id="sfR">
                    <legend class="scheduler-border">Datos del Representante</legend>
                    <div class="form-group">
                        <label for="imputNombresR" class="control-label col-xs-2">Nombres:</label>
                        <div class="col-xs-10">
                            <input class="form-control" id="imputNombresR"  placeholder="ej: Romulo Jose" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="imputApellidosR" class="control-label col-xs-2">Apellidos:</label>
                        <div class="col-xs-10">
                            <input class="form-control" id="imputApellidosR" placeholder="ej: Rodriguez Rojas" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="dateNacimientoR" class="control-label col-xs-2">Fecha de Nacimiento:</label>
                        <div class="col-xs-10">
                            <input type="text" id="dateNacimientoR" readonly class="form-control" placeholder="dd/mm/aaaa" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selectNacionalidadR" class="control-label col-xs-2">Nacionalidad:</label>
                        <div class="col-xs-10">
                            <select id="selectNacionalidadR" class="form-control">
                                <option>Venezolana</option>
                                <option>Extrangero</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputCRI" class="control-label col-xs-2" >Cédula o Pasaporte:</label>
                        <div class="col-xs-10">
                            <input data-validation="number" type="text" class="form-control" id="inputCIR" placeholder="ej: 19513536" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selectSexR" class="control-label col-xs-2">Sexo:</label>
                        <div class="col-xs-10">
                            <label class="radio-inline"><input type="radio" name="selectSexR" checked>Femenino</label>
                            <label class="radio-inline"><input type="radio" name="selectSexR">Masculino</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputMailR" class="control-label col-xs-2">Correo Electrónico:</label>
                        <div class="col-xs-10">
                            <input data-validation="email" type="email" class="form-control" id="inputMailR" placeholder="ej: pedro@gmail.com" data-validation="required"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputTelfR" class="control-label col-xs-2">Teléfono:</label>
                        <div class="col-xs-10">
                            <input type="text" id="inputTelfR" class="form-control" placeholder="Ej: (0212)451-54-54"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputMovilR" class="control-label col-xs-2">Teléfono Móvil:</label>
                        <div class="col-xs-10">
                            <input type="text" id="inputMovilR" class="form-control" placeholder="Ej: (0212)451-54-54"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selectParentescoR" class="control-label col-xs-2">Parentesco:</label>
                        <div class="col-xs-10">
                            <select id="selectParentescoR" class="form-control">
                                <option>Padre / Madre</option>
                                <option>Abuelo / Abuela</option>
                            </select>
                        </div>
                    </div>
                </fieldset>
                <fieldset class="scheduler-border" id="sfCE">
                    <legend class="scheduler-border">Contacto de Emergencia</legend>
                    <div class="form-group">
                        <label for="imputNombresCE" class="control-label col-xs-2">Nombres:</label>
                        <div class="col-xs-10">
                            <input class="form-control" id="imputNombresCE"  placeholder="ej: Romulo Jose" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="imputApellidosCE" class="control-label col-xs-2">Apellidos:</label>
                        <div class="col-xs-10">
                            <input class="form-control" id="imputApellidosCE" placeholder="ej: Romulo Jose" required/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selectSexCE" class="control-label col-xs-2">Sexo:</label>
                        <div class="col-xs-10">
                            <label class="radio-inline"><input type="radio" name="selectSexCE" checked>Femenino</label>
                            <label class="radio-inline"><input type="radio" name="selectSexCE">Masculino</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputMailCE" class="control-label col-xs-2">Correo Electrónico:</label>
                        <div class="col-xs-10">
                            <input data-validation="email" type="email" class="form-control" id="inputMailCE" placeholder="ej: pedro@gmail.com" data-validation="required"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputTelfCE" class="control-label col-xs-2">Teléfono:</label>
                        <div class="col-xs-10">
                            <input type="text" id="inputTelfCE" class="form-control" placeholder="Ej: (0212)451-54-54"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputMovilCE" class="control-label col-xs-2">Teléfono Móvil:</label>
                        <div class="col-xs-10">
                            <input type="text" id="inputMovilCE" class="form-control" placeholder="Ej: (0212)451-54-54"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="selectParentescoCE" class="control-label col-xs-2">Parentesco:</label>
                        <div class="col-xs-10">
                            <select id="selectParentescoCE" class="form-control">
                                <option>Padre / Madre</option>
                                <option>Abuelo / Abuela</option>
                                <option>Otro</option>
                            </select>
                        </div>
                    </div>
                </fieldset>
                <div class="box-footer">
                    <button type="submit" class="btn btn-primary"> Agregar </button>
                    <button type="button" class="btn btn-default"> Cancelar </button>
                </div>
            </form>
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
