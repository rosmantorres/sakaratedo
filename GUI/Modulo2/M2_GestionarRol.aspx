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
<form method="post" action="#"  id="userRol" runat="server">
<div class="box box-body">
    <div>

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
                <%int cont = 0; %>
               <%foreach(DominioSKD.Rol rol in rolesDePersona) %>
                <%{ %>
                 <tr>
                    <td><%=rol.Nombre %></td>
                    <td><%=rol.Descripcion %>
                    </td>
                    <td><%=rol.Fecha_creacion.ToString()%></td>
                    <td >
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" value="1" data-toggle="modal" data-target="#modal-delete" href="#"><a id="IdRol<%=cont++.ToString() %>" style="visibility: hidden"><%=rol.Id_rol %></a></a>
                    </td>
                </tr>
                <%} %>
                 <%foreach(DominioSKD.Rol rol in rolesFiltrados) %>
                <%{ %>
                 <tr>
                    <td><%=rol.Nombre %></td>
                    <td><%=rol.Descripcion %></td>
                    <td>-</td>
                    <td>
                        <a class="btn btn-success glyphicon glyphicon-plus-sign" value="2" data-toggle="modal" data-target="#modal-create" href="#" ><a id="IdRol<%=cont++.ToString()%>" style="visibility: hidden"><%=rol.Id_rol %></a></a>
                    </td>
                </tr>
                <%} %>

            </tbody>
        </table>
    </div>

    <div id="modal-create" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" aria-label="Close">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h3>Agregar nuevo rol a usuario</h3>
                </div>
                <div class="modal-body" aria-label="Close">
                            <div class="row form-group">
                                <label for="selectRole" class="control-label col-xs-2">Rol:</label>
                                <div class="col-xs-10" runat="server" id="DropDawnDiv" >
                                    <asp:DropDownList ID="RolList" class="btn btn-default dropdown-toggle"  runat="server">

                                    </asp:DropDownList>
                                     <td>
                                      <a class="btn btn-info glyphicon glyphicon-question-sign" data-toggle="modal" id="InfoButton" runat="server"  data-target="#info" href="#"></a>
                                     </td>

                                </div>
                            </div>
                     <div class="row form-group">

                    </div>
                </div>
                  <div class="modal-footer" style="text-align: center">
                    <input type="button" runat="server" onserverclick="AgregarRol" value="Agregar" class="btn btn-success col-lg-offset-1" />
                    <input type="button" data-dismiss="modal" value="Cancelar" class="btn btn-default col-lg-offset-1" />
                  </div>
            </div>
        </div>
    </div>
    
    <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" aria-label="Close">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h3>¿Esta seguro que desea eliminar este rol?</h3>
                </div>
                  <div class="modal-footer" style="text-align: center">
                    <input type="button" runat="server" OnServerClick="EliminarRol" value="Eliminar" class="btn btn-danger col-lg-offset-1" />
                    <input type="button" data-dismiss="modal" value="Cancelar" class="btn btn-default col-lg-offset-1" />
                  </div>
            </div>
        </div>
    </div>
 </div>
</form>
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
