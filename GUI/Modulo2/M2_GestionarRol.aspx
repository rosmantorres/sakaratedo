<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M2_GestionarRol.aspx.cs" Inherits="templateApp.GUI.Modulo2.M2_Prueba" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Gestionar Usuario</a> 
		    </li>
		    <li class="active">
			    Gestionar roles
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de roles
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Agregar o Quitar roles a un usuario
    
    <br />
    Nombre(s):
    <br />
    Apellido(s):
    <br />
    Correo:
    <br />
    Identificador:
    <br />
    Dojo:
    <br />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="box box-body">
    <div>
        <form class="form-horizontal">
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
                    <th>Rol</th>
                    <th>Descripcion</th>
                    <th>Fecha de asignación</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Administrador de Dojo</td>
                    <td>se encarga de gestionar y organizar todas las actividades referentes al dojo,<br />
                        tanto como hacer labores de mantenimiento de personal.
                    </td>
                    <td>22/11/2015</td>
                    <td>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                 <tr>
                    <td>Atleta</td>
                    <td>Son competidores asociados a los dojos en los cuales entrenan mes a mes<br />
                        para su formacion marcial.
                    </td>
                    <td>21/11/2015</td>
                    <td>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
            </tbody>
        </table>
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
