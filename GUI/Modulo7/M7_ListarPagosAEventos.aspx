<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarPagosAEventos.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarPagosAEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Historial de Pagos a Eventos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de los pagos efectuados 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>

    <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Pagos de eventos</h3>
                </div><!-- /.box-header -->


    <div class="box-body table-responsive">

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                    <th>Factura</th>
					<th>Evento</th>
                    <th>Fecha</th>
                    <th>Pago</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">001</td>
				    <td>Entrenamiento</td>
					<td>23/10/2015</td>
					<td>8.000 Bsf</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">002</td>
					<td>Competencia</td>
					<td>27/10/2015</td>
					<td>3.280 Bsf</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info2" href="#"></a>
                     </td>
				</tr><tr>
                    <td class="id">003</td>
					<td>Seminario de patadas</td>
                    <td>02/11/2015</td>
                    <td>2.000 Bsf</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info3" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">004</td>
					<td>Entrenamiento especial</td>
					<td>11/11/2015</td>
					<td>4.285 Bsf</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info4" href="#"></a>
                     </td>
                </tr>
                

			</tbody>
    </table>
        </div>
       </div>
                </div>
        </div>

    		<div id="modal-info1" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Información detallada del pago</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Número de factura</h3>
								<p>
									001
								</p>	
								<h3>Evento</h3>
								<p>
									Entrenamiento
								</p>
                                <h3>Organización</h3>
								<p>
									Keishin Kai Shito Ryu
								</p>
								<h3>Fecha de pago</h3>
								<p>
									23/10/2015
								</p>
								<h3>Monto del pago</h3>
								<p>
									8.000 Bsf
								</p>
								<h3>Descripcíón</h3>
								<p>
									Cancelado el monto del entrenamiento
								</p>	
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

    <div id="modal-info2" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Información detallada del pago</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Número de factura</h3>
								<p>
									002
								</p>	
								<h3>Evento</h3>
								<p>
									Competencia
								</p>
                                <h3>Organización</h3>
								<p>
									Keishin Kai Shito Ryu
								</p>
								<h3>Fecha de pago</h3>
								<p>
									27/10/2015
								</p>
								<h3>Monto del pago</h3>
								<p>
									3.280 Bsf
								</p>
								<h3>Descripcíón</h3>
								<p>
									Cancelado el monto de la competencia
								</p>	
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

    <div id="modal-info3" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Información detallada del pago</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Número de factura</h3>
								<p>
									003
								</p>	
								<h3>Evento</h3>
								<p>
									Seminario de patadas
								</p>
                                <h3>Organización</h3>
								<p>
									Keishin Kai Shito Ryu
								</p>
								<h3>Fecha de pago</h3>
								<p>
									02/11/2015
								</p>
								<h3>Monto del pago</h3>
								<p>
									2.000 Bsf
								</p>
								<h3>Descripcíón</h3>
								<p>
									Cancelado el monto del seminario
								</p>	
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

    <div id="modal-info4" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Información detallada del pago</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Número de factura</h3>
								<p>
									004
								</p>	
								<h3>Evento</h3>
								<p>
									Entrenamiento Especial
								</p>
                                <h3>Organización</h3>
								<p>
									Keishin Kai Shito Ryu
								</p>
								<h3>Fecha de pago</h3>
								<p>
									11/11/2015
								</p>
								<h3>Monto del pago</h3>
								<p>
									4.285 Bsf
								</p>
								<h3>Descripcíón</h3>
								<p>
									Cancelado el monto del entrenamiento especial
								</p>	
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

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



                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                    modal.find('#req').text(req)
                })
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                });


            });

        </script>

</asp:Content>
