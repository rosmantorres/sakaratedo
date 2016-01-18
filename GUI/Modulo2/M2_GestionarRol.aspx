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
			    <a href="<%=Page.ResolveUrl("~/GUI/Modulo6/M6_ListaUsuarios.aspx") %>">Gestionar Usuario</a> 
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


        <img id="imageTag" runat="server" src="" class="img-circle" alt="User Image" height="150" width="150">   
        <br />
        <br />
        Nombre completo:<strong id="NombreApellido" runat="server"></strong>
        <br /> 
         <br />
        Usuario:<strong id="NombreUsuario" runat="server"></strong>

                  <span class="hidden-xs" id="userName" runat="server"></span>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<form method="post" action="#"  id="userRol" runat="server">
<div class="box box-body">
    <div>

    </div>

    <br />
    <div>
        
        <input type="hidden" name="country" value="Norway" id="RolSelect" runat="server">
        <table id="tableSolisitudes" class="table table-bordered table-striped dataTable">
            <thead>
                <tr>
                    <th>Rol</th>
                    <th>Descripcion</th>
                    <th>Fecha de asignación</th>
                    <th>Acciones</th>

                </tr>
            </thead>
            <tbody id="TBodyRoles" runat="server">
               
            </tbody>
             <script>

                 $('a').click(function () {

                     valor = $(this).data('id');
                     console.log(valor);
                     valor = this.getAttribute("data-id");
                     console.log(valor);
                     document.getElementById("<%=RolSelect.ClientID%>").value = valor;

                    });

                </script>
        </table>
    </div>

    <div id="modal-create" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" aria-label="Close">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h3>¿Esta seguro que desea <strong>agregar</strong> este rol?</h3>
                </div>
                  <div class="modal-footer" style="text-align: center">
                    <input id="Button1" type="button" runat="server" OnServerClick="AgregarRol" value="Agregar" class="btn btn-success col-lg-offset-1" />
                    <input type="button" data-dismiss="modal" value="Cancelar" class="btn btn-default col-lg-offset-1" />
                  </div>
            </div>
        </div>
    </div>

     <div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" aria-label="Close">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4>Usted no posee los permisos suficientes para modificar este rol</h4>
                </div>
                  <div class="modal-footer" style="text-align: center">
                    <input type="button" data-dismiss="modal" value="Ok" class="btn btn-default btn-lg" />
                  </div>
            </div>
        </div>
    </div>
    
    <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" aria-label="Close">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h3>¿Esta seguro que desea <strong>eliminar</strong> este rol?</h3>
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
