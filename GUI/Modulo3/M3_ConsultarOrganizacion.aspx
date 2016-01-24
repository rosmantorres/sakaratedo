<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M3_ConsultarOrganizacion.aspx.cs" Inherits="templateApp.GUI.Modulo3.M3_ConsultarOrganizacion" %>
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
			    <a href="#">Organización</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Organización</a> 
		    </li>
		
		    <li class="active">
			    Listar Organizaciones
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Organización
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Organizaciones
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
        <div id="alert" runat="server">
    </div>

    
    
<div class="row">
    <div class="col-xs-12">
        <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Lista de Organizaciones</h3>
                    
        </div><!-- /.box-header -->
<form role="form" class="table table-bordered table-striped dataTable" name="consulta_org" id="consulta_org" method="post" runat="server"> 
 <div class="box-body table-responsive"> 
        <table id="tablaOrg" class="table table-bordered table-striped dataTable">
            <thead>
				<tr>
                    <th>ID</th> 
                    <th>Nombre</th>
                    <th>Email</th>
					<th>Teléfono</th>
                    <th>Estilo</th>
                    <th>Direccion</th>
                    <th>Estado</th>
                    <th style="text-align:right;">Acciones</th>                    
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="tabla"></asp:Literal>           
			</tbody>
            </table>
           </div>
</form>
       </div>
    </div>
</div>



 <div id="modal-switch" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Activaci&oacute;n/Desactivaci&oacute;n de Organizaci&oacute;n Seleccionada</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>¿Está seguro que desea cambiar el status de la organización?</p>
                    <p id="comp"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <button type="button" class="btn btn-primary" data-dismiss="modal" onserverclick="CambioDeStatus_Click">Aceptar</button>  <!-- onserverclick="CambioDeStatus_Click" --> 
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div>
        </div>
      </div>
    
    
    <script type="text/javascript">
          $(document).ready(function () {

              var table = $('#tablaOrg').DataTable({
              /*  "language": {
                    "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                }*/
            });
            var req;
            var tr;
          
            $('#tablaOrg tbody').on('click', 'a', function () {
                if ($(this).parent().hasClass('selected')) {
                    req = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr');//se guarda la fila seleccionada 
                    $(this).parent().removeClass('selected');

                }
                else {
                    req = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr');//se guarda la fila seleccionada 
                    table.$('tr.selected').removeClass('selected');
                    $(this).parent().addClass('selected');
                }
            });
           


        }); 
          $('#dimension-switch').bootstrapSwitch('setSizeClass', 'switch-small');
        </script>
      <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
 

</asp:Content>
