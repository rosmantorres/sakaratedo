<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_ConsultarProducto.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_ConsultarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--     <asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
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
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Consulta de Articulos Deportivos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Articulos en Existencia:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div class="alert alert-success alert-dismissable" style="display:none" id="prueba">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            El Articulo Deportivo se ha Agregado Exitosamente al Carrito.
        </div>

     <div class="box-body table-responsive">

         <!--MODAL PARA EL DETALLE-->
     <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Articulos Actuales</h3>
                </div><!-- /.box-header -->

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
            <tr>
                <th>Foto</th>
                <th>Articulo Deportivo</th>
                <th>Precio (Bs)</th>
                <th>Accion</th>
                
            </tr>
        </thead>
 
        <tfoot>
            <tr>
                <th>Foto</th>
                <th>Articulo Deportivo</th>
                <th>Precio (BS)</th>
                <th>Accion</th>
            </tr>
        </tfoot>
 
        <tbody>
            <tr>
                <td><img src="Imagenes\GuanteRojo.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Guantes Rojos</td>
                <td>Bs 5000</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a></td>
            </tr>
            <tr>
                <td><img src="Imagenes\CintaBlanca.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Cinta Blanca</td>
                <td>Bs 400</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a></td>
            </tr>
            <tr>
                <td><img src="Imagenes\Suspensorio.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Suspensorio</td>
                <td>Bs 350</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a></td>
            </tr>
            
            <tr>
                <td><img src="Imagenes\ProtectorBucal.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Proteccion Bucal</td>
                <td>Bs 3200</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a></td>
            </tr>

             <tr>
                <td><img src="Imagenes\Karategi.jpg" alt="" style="width:60px; height:auto;"></td>
                <td>Karategi</td>
                <td>Bs 14000</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a></td>
            </tr>

        </tbody>
    </table>

                  <!--MODAL PARA EL DETALLE -->
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
                                <img src="Imagenes/GuanteRojo.jpg" alt="">
								<h3>Nombre</h3>
								<p>
									Guantes Rojos
								</p>
								<h3>Cantidad disponible</h3>
                                <br />
                                <form runat="server" class="form-horizontal" method="POST">
                                     <div class="dropdown" runat="server" id="div1">
                                     <asp:DropDownList ID="DropDownList1"   class="btn btn-default dropdown-toggle"  onchange="funcionCantidadObjetos(this.id);"  runat="server" >
                                         <asp:ListItem Enabled="true" Text="Cantidad" Value="-1"></asp:ListItem>
                                         <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                         <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                         <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                         <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                     </asp:DropDownList>
                                     </div> 
                               
            
								    <h3>Detalles</h3>
								    <p>
									    Guantes de color rojos diseñados para proteger las manos al momento de impactar
                                        golpes contra el contrincante o cuando se está practicando, con un diseño
                                        particular de color rojo a gusto del atleta.
								    </p>
								    <div class="form-group">
		                                <div class="box-footer">
				                            <button id="Boton1" style="align-content:flex-end" runat="server" Disabled="disabled" class="btn btn-primary" type="button" onclick="$('#modal-info1').modal('hide'); $('#prueba').show();" >Agregar al Carrito</button>
                                             
			                            </div>
	                                </div>
                                </form>


							</div>
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

                 var table = $('#example').DataTable({
                     "language": {
                         "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                     }
                 });
                 var req;
                 var tr;

                 $('#example tbody').on('click', 'a', function () {
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
             });


             function funcionCantidadObjetos(param) {

                 

                 if ($('#<%=DropDownList1.ClientID %>').val() != -1) {

                     $('#<%=Boton1.ClientID %>').attr("disabled", false);
                 }
                 else     
                 $('#<%=Boton1.ClientID %>').attr("disabled", "disabled");
             }

        </script>

</asp:Content>
