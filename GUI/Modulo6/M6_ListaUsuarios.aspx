<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M6_ListaUsuarios.aspx.cs" Inherits="templateApp.GUI.Modulo6.M6_ListaUsuarios" %>

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
			    Gestion de Usuarios
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Usuarios en el sistema
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Lista de los usuarios que se pueden administrar
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div id="alert" runat="server">
    </div>

    <div class="box box-body">


    <div>

        <form class="form-horizontal">
            

            <div class="row">
                <label for="selectDojo" class="control-label col-xs-2">Dojo:</label>
                <div class="col-xs-4">
                    <select id="selectDojo" class="form-control">
                        <option>Seleccione un Dojo</option>
                    </select>
                </div>
            </div>
            <div class="row">
                <a class="btn btn-success glyphicon glyphicon-plus-sign col-md-offset-11" data-toggle="modal" data-target="#modal-create" href="#""></a>
            </div>
        </form>
    </div>

    <br />
    <div>
        <table id="tableSolisitudes" class="table table-bordered table-striped dataTable">
            <thead>
                <tr>
                    <th>Nombres, Apellidos</th>
                    <th>CI o Pasporte</th>
                    <th>Nombre de usuario</th>
                    <th>Roles</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
               
                      
                <%foreach(DominioSKD.Entidades.Modulo1.Cuenta cuenta in lasCuentas) %>
                <%{ %>
                 <tr style="background: rgb(224, 235, 235);">
                    <td><%=cuenta.PersonaUsuario._Nombre+' '+cuenta.PersonaUsuario._Apellido %></td>
                    <td><%=cuenta.PersonaUsuario._DocumentoID %> </td>
                     <td><%=cuenta.Nombre_usuario %></td>
                    <td><%foreach (DominioSKD.Entidades.Modulo2.Rol rol in cuenta.Roles)%>
                        <%{ %>
                               <%=rol.Nombre +" ;"%>

                        <%}%>
                    </td>
                     <td>
                         <a class="btn btn-default glyphicon glyphicon-user" href="<%=Page.ResolveUrl("~/GUI/Modulo2/M2_GestionarRol.aspx?user="+cripto.EncriptarCadenaDeCaracteres( cuenta.PersonaUsuario._Id.ToString(),DES)) %>"></a>
                    </td>
                    
                </tr>
                <%} %>

           
       
            </tbody>
        </table>
    </div>



    <div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" aria-label="Close">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h2>Consulta de Usuario</h2>
                </div>
                <div class="modal-body">
                    <legend class="scheduler-border">Datos Personales</legend>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Nombres:</strong></div>
                        <div class="col-md-8">Rómulo José</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Apellidos:</strong></div>
                        <div class="col-md-8">Rodríguez Rojas</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Usuario:</strong></div>
                        <div class="col-md-8">eltercera</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Nacionalidad:</strong></div>
                        <div class="col-md-8">Venezolana</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Fecha de Nacimiento:</strong></div>
                        <div class="col-md-8">05/10/1990</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Edad:</strong></div>
                        <div class="col-md-8">24</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>CI o Pasaporte:</strong></div>
                        <div class="col-md-8">19.513.536</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Sexo:</strong></div>
                        <div class="col-md-8">Masculino</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Correo electronico:</strong></div>
                        <div class="col-md-8">rodriguezrjrr@gmail.com</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Teléfono:</strong></div>
                        <div class="col-md-8">(0414)914-64-38</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Teléfono Movil:</strong></div>
                        <div class="col-md-8"></div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Dirección de Habitación:</strong></div>
                        <div class="col-md-8"> La Vega, Los Mangos, Sector unido, Carretera negra, Casa N° 12 La Vega, Los Mangos, Sector unido, Carretera negra, Casa N° 12sdf skdf skdf dsjk fjsd fjlhs jfhds fj eif lja dfjlsd fjl</div>
                    </div>
                    <legend class="scheduler-border">Datos de Salud</legend>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Tipo de Sangre:</strong></div>
                        <div class="col-md-8">O+</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Alergias:</strong></div>
                        <div class="col-md-8">Ninguna</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Peso:</strong></div>
                        <div class="col-md-8">80 Kg</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Estatura:</strong></div>
                        <div class="col-md-8">1.70 m</div>
                    </div>
                    <legend class="scheduler-border">Datos del Representantes</legend>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Nombres:</strong></div>
                        <div class="col-md-8">Rómulo José</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Apellidos:</strong></div>
                        <div class="col-md-8">Rodríguez Rojas</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Nacionalidad:</strong></div>
                        <div class="col-md-8">Venezolana</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Fecha de Nacimiento:</strong></div>
                        <div class="col-md-8">05/10/1990</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Edad:</strong></div>
                        <div class="col-md-8">24</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>CI o Pasaporte:</strong></div>
                        <div class="col-md-8">19.513.536</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Sexo:</strong></div>
                        <div class="col-md-8">Masculino</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Correo electronico:</strong></div>
                        <div class="col-md-8">rodriguezrjrr@gmail.com</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Teléfono:</strong></div>
                        <div class="col-md-8">(0414)914-64-38</div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Teléfono Movil:</strong></div>
                        <div class="col-md-8"></div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Patentesco:</strong></div>
                        <div class="col-md-8">Padre</div>
                    </div>
                </div>
            </div>
         </div>
    </div>

    <div id="modal-update" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" aria-label="Close">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h2>Modificación de Usuario</h2>
                </div>
                <div class="modal-body">
                    <legend class="scheduler-border">Datos Personales</legend>
                        <div class="row form-group">
                            <label for="imputNombres" class="control-label col-xs-2">Nombres:</label>
                            <div class="col-xs-10">
                                <input class="form-control" id="imputNombres"  value="Rómulo José" required/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="imputApellidos" class="control-label col-xs-2">Apellidos:</label>
                            <div class="col-xs-10">
                                <input class="form-control" id="imputApellidos" value="Rodriguez Rojas" required/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="dateNacimiento" class="control-label col-xs-2">Fecha de Nacimiento:</label>
                            <div class="col-xs-10">
                                <input type="text" id="dateNacimiento" class="form-control" value="05/10/1990" required/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="selectNacionalidad" class="control-label col-xs-2">Nacionalidad:</label>
                            <div class="col-xs-10">
                                <button id="selectNacionalidad" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                Nacionalidad: <span class="caret"></span>
                                </button>
                                <ol id="selectNacionalidadOpts" class="dropdown-menu" role="menu"  onclick="">
                                    <li value="1"><a href="#" selected>Venezolano</a></li>
                                    <li value="2"><a href="#">Extranjero</a></li>
                                </ol>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="inputCI" class="control-label col-xs-2">Cédula o Pasaporte:</label>
                            <div class="col-xs-10">
                                <input data-validation="number" type="text" class="form-control" id="inputCI" value="19513536" required/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="selectSex" class="control-label col-xs-2">Sexo:</label>
                            <div class="col-xs-10">
                                <label class="radio-inline"><input type="radio" name="selectSex" disabled>Femenino</label>
                                <label class="radio-inline"><input type="radio" name="selectSex" checked disabled>Masculino</label>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="inputMail" class="control-label col-xs-2">Correo Electrónico:</label>
                            <div class="col-xs-10">
                                <input type="email" class="form-control" id="inputMail" value="rodriguezrjrr@gmail.com" data-validation="email"/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="inputTelf" class="control-label col-xs-2">Teléfono:</label>
                            <div class="col-xs-10">
                                <input type="text" id="inputTelf" class="form-control"  value="(0212)451-54-54" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="inputMovil" class="control-label col-xs-2">Teléfono Móvil:</label>
                            <div class="col-xs-10">
                                <input type="text" id="inputMovil" class="form-control" placeholder="(0414)240-21-48" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="textareaDir" class="control-label col-xs-2">Direccion de habitación:</label>
                            <div class="col-xs-10">
                                <textarea id="textareaDir" class="form-control col-xs-2" rows="5">La Vega, Los Mangos, Sector unido, Carretera negra, Casa N° 12 La Vega, Los Mangos, Sector unido, Carretera negra, Casa N° 12</textarea>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="selectSangre" class="control-label col-xs-2">Tipo de Sangre:</label>
                            <div class="col-xs-10">
                                <button id="selectSangre" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    Seleccione un tipo de sangre <span class="caret"></span>
                                    </button>
                                    <ol id="selectSangreOpts" class="dropdown-menu" role="menu"  onclick="">
                                        <li value="1"><a href="#">O-</a></li>
                                        <li value="2" selected><a href="#">O+</a></li>
                                        <li value="2"><a href="#">A-</a></li>
                                        <li value="2"><a href="#">A+</a></li>
                                        <li value="2"><a href="#">B-</a></li>
                                        <li value="2"><a href="#">B+</a></li>
                                        <li value="2"><a href="#">AB-</a></li>
                                        <li value="2"><a href="#">AB+</a></li>
                                    </ol>
                                </div>
                            </div>
                        <div class="row form-group">
                            <label for="textareaAlegias" class="control-label col-xs-2">Alergias:</label>
                            <div class="col-xs-10">
                                <textarea id="textareaAlegias" class="form-control col-xs-2" rows="5" >Citricos. Mariscos</textarea>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="inputPeso" class="control-label col-xs-2">Peso:</label>
                            <div class="col-xs-10">
                                <input type="text" id="inputPeso" class="form-control" value="80"/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="inputEstatura" class="control-label col-xs-2">Estatura:</label>
                            <div class="col-xs-10">
                                <input type="text" id="inputEstatura" class="form-control" value="1.70"/>
                            </div>
                        </div>
                        <div class="row" style="text-align: center">
                            <input type="button" value="Aceptar" class="btn btn-success col-lg-offset-1" />
                            <input type="button" value="Cancelar" class="btn btn-primary col-lg-offset-1" />
                        </div>
                </div>
            </div>  
         </div>
    </div>

    <div id="modal-create" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" aria-label="Close">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h2>Creación de Usuario</h2>
                </div>
                <div class="modal-body">
                    <legend class="scheduler-border">Rol</legend>
                    <div class="row form-group">
                        <label for="selectRole" class="control-label col-xs-2">Rol:</label>
                        <div class="col-xs-10">
                        <button id="selectRole" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Seleccione un rol <span class="caret"></span>
                            </button>
                            <ol id="selectRoleOpts" class="dropdown-menu" role="menu"  onclick="">
                                <li value="1"><a href="#">Entrenador</a></li>
                                <li value="2"><a href="#">Administrador</a></li>
                                <li value="2"><a href="#">Atleta</a></li>
                            </ol>
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
                </fieldset>
                </div>
            </div>  
         </div>
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



                    