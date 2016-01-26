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

    <div class="alert alert-success alert-dismissable" style="display:none" id="prueba">
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

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
            <tr>
                <th>Nombre</th>
                <th>Tipo</th>
                <th>Ubicacion</th>
                <th>Fecha Inicio</th>
                <th>Fecha Fin</th>
                <th>Accion</th>
                
            </tr>
        </thead>
 
        <tfoot>
            <tr>
                <th>Nombre</th>
                <th>Tipo</th>
                <th>Ubicacion</th>
                <th>Fecha Inicio</th>
                <th>Fecha Fin</th>
                <th>Accion</th>
            </tr>
        </tfoot>
 
        <tbody>
            <tr>
                <td>Primera Competencia Anual</td>
                <td>Competencia</td>
                <td>Caracas</td>
                <td>01 Enero 2016</td>
                <td>02 Enero 2016</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a></td>
            </tr>
            <tr>
                <td>Sakarate-Do Avanzado</td>
                <td>Entrenamiento Especial</td>
                <td>Caracas</td>
                <td>07 Noviembre 2015</td>
                <td>08 Noviembre 2015</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a></td>
            </tr>
            <tr>
                <td>2DO Seminario Showakai Sakarate-Do</td>
                <td>Seminario</td>
                <td>Caracas</td>
                <td>01 Diciembre 2015</td>
                <td>03 Diciembre 2015</td>
                <td><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a></td>
            </tr>
            
            <tr>
                <td>Adulto Intermedio</td>
                <td>Clase</td>
                <td>Caracas</td>
                <td>20 Noviembre 2015</td>
                <td>21 Noviembre 2015</td>
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

    </div>

     <!--VALIDACION PARA MODAL -->
         
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
        </script>

</asp:Content>
