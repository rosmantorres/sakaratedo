<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarEventosInscritos.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarEventosInscritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Eventos Inscritos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de los eventos en los que está inscrito
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>

    <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Eventos Inscritos</h3>
                </div><!-- /.box-header -->

    <div class="box-body table-responsive">

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                    <th>ID</th>
					<th>Evento</th>
                    <th>Tipo</th>
					<th>Fecha</th>
                    <th>Locación</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">001</td>
					<td>Noveno encuentro de cintas negras 5to DAN</td>
					<td>Seminario</td>
					<td>26/01/2016</td>
                    <td>Estado Barinas</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">002</td>
					<td>Campeonato Nacional 2016</td>
					<td>Competencia</td>
					<td>15/06/2016</td>
                    <td>Estado Carabobo</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info2" href="#"></a>
                     </td>
				</tr><tr>
                    <td class="id">003</td>
					<td>IV Jornada de excelencia de Karate Do</td>
					<td>Conferencia</td>
					<td>03/12/2015</td>
                    <td>Estado Distrito Capital</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info3" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">004</td>
					<td>Entrenamiento Especial de Bujutsu</td>
					<td>Entrenamiento Especial</td>
					<td>15/12/2015</td>
                    <td>Estado Distrito Capital</td>
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
						<h4 class="modal-title">Información detallada de los eventos inscritos</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Nombre</h3>
								<p>
								    Noveno encuentro de cintas negras 5to DAN
								</p>
								<h3>Tipo</h3>
								<p>
									Seminario
								</p>
								<h3>Fecha de inicio</h3>
								<p>
									26/01/2016
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									27/01/2016
								</p>
                                <h3>Locación</h3>
								<p>
									<ul>
                                        <li>Estado: Guárico</li>
                                        <li>Ciudad: San Juan de los Morros </li>
									</ul>
								</p>
								<h3>Descripción</h3>
								<p>
                                    Encuentro de atletas con cinta negra de 5to DAN. 
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
						<h4 class="modal-title">Información detallada de los eventos inscritos</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
                                <h3>Nombre</h3>
								<p>
								 Campeonato Nacional 2016
								</p>
								<h3>Tipo</h3>
								<p>
									Competencia
								</p>
								<h3>Fecha de inicio</h3>
								<p>
									5/06/2016
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									25/06/2016
								</p>
                                <h3>Locación</h3>
								<p>
									<ul>
                                        <li>Estado: Carabobo</li>
                                        <li>Ciudad: Valencia </li>
									</ul>
								</p>
                                <h3>Descripción</h3>
								<p>
                                    Competencia para los atletas de cinta negra. 
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
						<h4 class="modal-title">Información detallada de los eventos inscritos</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								  <h3>Nombre</h3>
								<p>
								 IV Jornada de excelencia de Karate Do
								</p>
								<h3>Tipo</h3>
								<p>
									Conferencia
								</p>
								<h3>Fecha de inicio</h3>
								<p>
									03/12/2015
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									25/06/2016
								</p>
                                <h3>Locación</h3>
								<p>
									<ul>
                                        <li>Estado: Distrito Capital</li>
                                        <li>Ciudad: Caracas </li>
									</ul>
								</p>
                                <h3>Descripción</h3>
								<p>
                                    Conferencia para enriquecer el conocimiento y habilidades de los atletas
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
						<h4 class="modal-title">Información detallada de los eventos inscritos</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								  <h3>Nombre</h3>
								<p>
								Entrenamiento Especial de Bujutsu
								</p>
								<h3>Tipo</h3>
								<p>
									Entrenamiento Especial
								</p>
								<h3>Fecha de inicio</h3>
								<p>
									15/12/2015
								</p>
                                <h3>Horario</h3>
								<p>
								    14:00 - 16:00
								</p>
                                <h3>Profesor</h3>
								<p>
									José Wu
								</p>
                                <h3>Salón</h3>
								<p>
									S-08
								</p>
                                <h3>Descripción</h3>
								<p>
                                 Entrenamiento de los elementos del Bujutsu( Golpes, Proyecciones, Luxaciones, Estrangulamiento)
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
