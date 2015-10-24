<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarHorariodePractica.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarHorariodePractica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Horario de Práctica
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de los horarios de práctica
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>

    <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Horario</h3>
                </div><!-- /.box-header -->


    <div class="box-body table-responsive">

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                    <th>ID</th>
					<th>Práctica</th>
                    <th>Profesor</th>
					<th>Hora Inicio</th>
                    <th>Día</th>
                    <th>Salón</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">001</td>
					<td>Tsuki (Golpe)</td>
					<td>José Reyes</td>
					<td>14:00</td>
                    <td>Lunes </td>
                    <td>S-03 </td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">002</td>
					<td>Dachi (Posición) </td>
					<td>Alejandro Fermín</td>
					<td>16:00</td>
                   <td>Lunes </td>
                    <td>S-05 </td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info2" href="#"></a>
                     </td>
				</tr><tr>
                    <td class="id">003</td>
					<td>Uke (Bloqueo) </td>
					<td>Ana K. López</td>
					<td>14:00</td>
                    <td>Miércoles </td>
                    <td>S-02 </td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info3" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">004</td>
					<td>Kata (Forma) </td>
					<td>Luisa E. López</td>
					<td>16:00</td>
                    <td>Jueves </td>
                    <td>S-04 </td>
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
						<h4 class="modal-title">Información detallada del horario de práctica </h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
                  				<h3>Práctica</h3>
								<p>
									Tsuki (Golpe)
								</p>
								<h3>Profesor</h3>
								<p>
									José Reyes
								</p>
								<h3>Hora de inicio</h3>
								<p>
									14:00
								</p>
								<h3>Hora de finalización</h3>
								<p>
									15:30
								</p>
                                <h3>Día</h3>
								<p>
									Lunes
								</p>
								<h3>Salón</h3>
								<p>
                                    S-03
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
						<h4 class="modal-title">Información detallada del horario de práctica</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
                                  <td class="id">002</td>
								<h3>Práctica</h3>
								<p>
									Dachi (Posición)
								</p>
								<h3>Profesor</h3>
								<p>
									Alejandro Fermín
								</p>
								<h3>Hora de inicio</h3>
								<p>
									16:00
								</p>
								<h3>Hora de finalización</h3>
								<p>
									17:30
								</p>
                                <h3>Día</h3>
								<p>
									Lunes
								</p>
								<h3>Salón</h3>
								<p>
                                   S-05
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
						<h4 class="modal-title">Información detallada del horario de práctica </h4>
					</div>
						        <h3>Práctica</h3>
								<p>
									Uke (Bloqueo)
								</p>
								<h3>Profesor</h3>
								<p>
									Ana K. López
								</p>
								<h3>Hora de inicio</h3>
								<p>
									14:00
								</p>
								<h3>Hora de finalización</h3>
								<p>
									15:30
								</p>
                                <h3>Día</h3>
								<p>
									Miércoles
								</p>
								<h3>Salón</h3>
								<p>
                                    S-02
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
						<h4 class="modal-title">Información detallada del horario de práctica</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
									<h3>Práctica</h3>
								<p>
									Kata (Forma)
								</p>
								<h3>Profesor</h3>
								<p>
									Luisa E. López
								</p>
								<h3>Hora de inicio</h3>
								<p>
									16:00
								</p>
								<h3>Hora de finalización</h3>
								<p>
									17:30
								</p>
                                <h3>Día</h3>
								<p>
									Jueves
								</p>
								<h3>Salón</h3>
								<p>
                                   S-04
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

