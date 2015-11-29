<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_ConsultarEvento.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_ConsultarEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		
		    <li>
			    <a href="../Modulo16/M16_VerCarrito.aspx">Ver Carrito</a> 
		    </li>

            <li>
			    <a href="#">Consultar Evento</a> 
		    </li>
		</ol>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Consulta de Eventos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Eventos en Existencia:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

    <div class="alert alert-success alert-dismissable" style="display:none" id="agregarEventoaCarrito">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            El Evento se ha Agregado Exitosamente al Carrito.
        </div>

    <div class="box-body table-responsive">

         <!--MODAL PARA EL DETALLE-->
     <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Eventos Actuales</h3>
                </div><!-- /.box-header -->
              </div>
       <table id="tablaevento" class="table table-bordered table-striped dataTable">
        <thead>
            <tr>
                    <th style="text-align:right">Id</th>
                    <th style="text-align:right">Nombre</th>
					<th style="text-align:right">Costo</th>
                    <th style="text-align:right">Descripcion</th>
					<th style="text-align:right">Acciones</th> 
            </tr>
        </thead>
 
        <tbody>
            <asp:Literal runat="server" ID="laTabla"></asp:Literal>
        </tbody>
    </table>    
   </div>
                  <!--MODAL PARA EL DETALLE -->
<div id="modal-info1" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Evento</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row">
								<h3>Nombre</h3>
									2DO Seminario Showakai Sakarate-Do
                                <br />
                                <h3>Tipo</h3>
                                    Seminario
                                <br />
                                <h3>Lugar/ Fin</h3>
                                    Caracas
                                <br />
								<h3>Fecha Inicio</h3>
                                    01 Diciembre 2015
                                <br />
                                <h3>Fecha Fin</h3>
                                    03 Diciembre 2015
                                <br />
                                
                                <form role="form" class="form-horizontal" method="POST">
								    <h3>Descricion</h3>
								    <p>
									    El 2do Seminario Showakai se presenta en la ciudad de Caracas para el deleite de todos los interesados, se ofrece material de apoyo mas las clases de practica.
								    </p>
								    <div class="form-group">
		                                <div class="box-footer">
				                            <button id="Boton1" style="align-content:flex-end" runat="server"  class="btn btn-primary" type="button"  onclick="$('#modal-info1').modal('hide'); $('#prueba').show();"  >Agregar al Carrito</button>
                                          
			                            </div>
	                                </div>
                                </form>


							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

     <!--VALIDACION PARA MODAL -->
         
         <script type="text/javascript">
             $(document).ready(function () {

                 var table = $('#tablaevento').DataTable({
                     "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                     "language": {
                         "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                     }
                 });
                 var req;
                 var tr;

                 $('#tablaevento tbody').on('click', 'a', function () {
                     if ($(this).parent().hasClass('selected')) {
                         req = $(this).parent().prev().prev().prev().text();
                         tr = $(this).parents('tr');//se guarda la fila seleccionada
                         $(this).parent().removeClass('selected');

                     }
                     else {
                         req = $(this).parent().prev().prev().prev().text();
                         tr = $(this).parents('tr');//se guarda la fila seleccionada
                         table.$('tr.selected').removeClass('selected');
                         $(this).parent().addClass('selected');
                     }

                 });

                 $('#modal-delete').on('show.bs.modal', function (event) {
                     var modal = $(this)
                     modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                     modal.find('#req').text(req)
                 })
                 $('#btn-eliminar').on('click', function () {
                     table.row(tr).remove().draw();//se elimina la fila de la tabla
                     $('#modal-delete').modal('hide');//se esconde el modal
                     $('#prueba').show();//Muestra el mensaje de agregado exitosamente

                 });

                 // Carga el modal con la informacion del evento de acuerdo al id
                 $('#modal-info1').on('show.bs.modal', function (e) {

                     $.ajax({
                         cache: false,
                         type: 'POST',
                         url: 'http://localhost:23072/GUI/Modulo16/M16_ConsultarProducto.aspx/prueba',
                         data: "{'id':" + "'" + e.relatedTarget.id + "'" + "}",
                         dataType: 'json',
                         contentType: "application/json; charset=utf-8",

                         success: function (data) {
                             console.log(data);

                             var aa = JSON.parse(data.d);

                             $("#beta").val(aa.id);
                             $("#beta1").val(aa.Nombre);
                             $("#beta7").val(aa.Precio);
                             $("#beta8").val(aa.descripcion);

                         }
                     });
                 })
             });
        </script>

</asp:Content>