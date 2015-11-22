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

            <li>
			    <a href="M6_ListaUsuarios.aspx">Gestión de Usuarios</a>
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
                <asp:Literal runat="server" ID="usersTable"></asp:Literal>
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
                        <asp:Label ID="nameLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Apellidos:</strong></div>
                        <asp:Label ID="lastLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Usuario:</strong></div>
                        <asp:Label ID="userLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Nacionalidad:</strong></div>
                        <asp:Label ID="natLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Fecha de Nacimiento:</strong></div>
                        <asp:Label ID="birthLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Edad:</strong></div>
                        <asp:Label ID="ageLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>CI o Pasaporte:</strong></div>
                        <asp:Label ID="idLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Sexo:</strong></div>
                        <asp:Label ID="sexLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Correo electronico:</strong></div>
                        <asp:Label ID="emailLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Teléfono:</strong></div>
                        <asp:Label ID="phoneLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Teléfono Movil:</strong></div>
                        <asp:Label ID="mobileLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Dirección de Habitación:</strong></div>
                        <asp:Label ID="addressLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <legend class="scheduler-border">Datos de Salud</legend>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Tipo de Sangre:</strong></div>
                        <asp:Label ID="bloodLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Alergias:</strong></div>
                        <asp:Label ID="alergyLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Peso:</strong></div>
                        <asp:Label ID="weightLabel" runat="server" class="col-md-8"></asp:Label><label> Kg.</label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Estatura:</strong></div>
                        <asp:Label ID="heightLabel" runat="server" class="col-md-8"></asp:Label><label> m.</label>
                    </div>
                    <legend class="scheduler-border">Datos del Representantes</legend>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Nombres:</strong></div>
                        <asp:Label ID="repNameLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Apellidos:</strong></div>
                        <asp:Label ID="lastRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Nacionalidad:</strong></div>
                        <asp:Label ID="natRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Fecha de Nacimiento:</strong></div>
                        <asp:Label ID="birthRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Edad:</strong></div>
                        <asp:Label ID="ageRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>CI o Pasaporte:</strong></div>
                        <asp:Label ID="idRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Sexo:</strong></div>
                        <asp:Label ID="sexRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Correo electronico:</strong></div>
                        <asp:Label ID="emailRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Teléfono:</strong></div>
                        <asp:Label ID="phoneRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Teléfono Movil:</strong></div>
                        <asp:Label ID="mobileRepLabel" runat="server" class="col-md-8"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="text-align: right"><strong>Patentesco:</strong></div>
                        <asp:Label ID="repLabel" runat="server" class="col-md-8"></asp:Label>
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



                    