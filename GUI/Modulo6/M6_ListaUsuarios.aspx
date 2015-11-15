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
    <!-- Customized stylesheet -->
<link href="css/styles.css" rel="stylesheet" />
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
                <tr>
                    <td>Rómulo Jose, Rodríguez Rojas</td>
                    <td>19.513.356</td>
                    <td>Eltercera</td>
                    <td>Atleta</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                         <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                    <td>Rómulo Jose, Rodríguez Rojas</td>
                    <td>19.513.356</td>
                    <td>Eltercera</td>
                    <td>Atleta</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                         <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-success glyphicon glyphicon-refresh" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
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



                    