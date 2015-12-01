<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_ConsultarProducto.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_ConsultarProducto" %>
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
			    <a href="#">Consultar Producto</a> 
		    </li>
		</ol>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Consulta de Articulos Deportivos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Articulos en Existencia:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

    
    <div class="alert alert-success alert-dismissable" style="display:none" id="agregarImplementoAcarrito">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            la matricula se ha Agregado Exitosamente al Carrito.
        </div>

     <div class="box-body table-responsive">

         <!--MODAL PARA EL DETALLE-->
     <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Articulos Actuales</h3>
                </div><!-- /.box-header -->
              </div>
       <table id="tablaproducto" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:left">Id</th>
                    <th style="text-align:left">Imagen</th>
                    <th style="text-align:left">Nombre</th>
					<th style="text-align:left">Marca</th>
                    <th style="text-align:left">Tipo</th>
					<th style="text-align:left">Precio</th>
					<th style="text-align:left">Acciones</th>
				</tr>
		</thead>
                        <div class="box-footer">
				                                                                      
			                            </div>
			<tbody>
                <asp:Literal runat="server" ID="laTabla"></asp:Literal>
		    </tbody>
            </table>
        </div>

                  <!--MODAL PARA EL DETALLEDEL PRODUCTO -->
<div id="modal-info1" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Articulo</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row">
                                <h3>Imagen</h3>
									<h4><input type="text" id="beta" value=""/></h4>
                                <h3>Nombre</h3>
                                    <h4><input type="text" id="beta1" value="" /></h4>
								<h3>Tipo Implemento</h3>
                                    <h4><input type="text" id="beta2" value="" /></h4>
                                <h3>Marca</h3>
                                    <h4><input type="text" id="beta3" value="" /></h4>
                                <h3>Color</h3>
                                    <h4><input type="text" id="beta4" value="" /></h4>
                                <h3>Talla</h3>
                                    <h4><input type="text" id="beta5" value="" /></h4>
                                <h3>Status</h3>
                                    <h4><input type="text" id="beta6" value="" /></h4>
                                <h3>Precio</h3>
                                    <h4><input type="text" id="beta7" value="" /></h4>
                                <h3>Descripcion</h3>
                                    <h4><input type="text" id="beta8" value="" /></h4>
							</div>
						</div>
					</div>
				</div>
			</div>
 </div>

     <!--VALIDACION PARA MODAL -->
    <script src="js/Validacion.js"></script>

         <script type="text/javascript">
             $(document).ready(function () {

                 var table = $('#tablaproducto').DataTable({
                     "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                     "language": {
                         "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                     }
                 });
                 var req;
                 var tr;

                 $('#tablaproducto tbody').on('click', 'a', function () {
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

                 // Carga el modal con la informacion del producto de acuerdo al id
                 $('#modal-info1').on('show.bs.modal', function (e) {

                     alert(e.relatedTarget.id);

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

                             console.log(aa);

                             $("#beta").val(aa.Imagen_implemento);
                             $("#beta1").val(aa.Nombre_Implemento);
                             $("#beta2").val(aa.Tipo_Implemento);
                             $("#beta3").val(aa.Marca_Implemento);
                             $("#beta4").val(aa.Color_Implemento);
                             $("#beta5").val(aa.Talla_Implemento);
                             $("#beta6").val(aa.Estatus_Implemento);
                             $("#beta7").val(aa.Precio_Implemento);
                             $("#beta8").val(aa.Descripcion_Implemento);

                         }
                     });
                 })
             });

        </script>

</asp:Content>
