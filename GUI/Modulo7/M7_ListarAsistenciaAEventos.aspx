<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarAsistenciaAEventos.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarAsistenciaAEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Asistencias a Eventos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de los eventos a los que has asistido
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>

    <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Eventos</h3>
                </div><!-- /.box-header -->


    <div class="box-body table-responsive">

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                    <th>ID</th>
					<th>Evento</th>
                    <th>Tipo</th>
					<th>Fecha de Inicio</th>
                    <th>Locación</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">001</td>
					<td>Octavo encuentro de cintas amarillas 2do kyu</td>
					<td>Seminario</td>
					<td>24/10/2015</td>
                    <td>Estado Guarico</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">002</td>
					<td>Clase de kata</td>
					<td>Entrenamiento Especial</td>
					<td>01/11/2015</td>
                    <td>Estado Distrito Capital</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info2" href="#"></a>
                     </td>
				</tr><tr>
                    <td class="id">003</td>
					<td>Competencia entre cintas blancas</td>
					<td>Competencia</td>
					<td>13/10/2015</td>
                    <td>Estado Distrito Capital</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info3" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">004</td>
					<td>Cuarto encuentro de cintas blancas 1er kyu</td>
					<td>Seminario</td>
					<td>10/05/2015</td>
                    <td>Estado Guarico</td>
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
						<h4 class="modal-title">Información detallada del evento</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Nombre</h3>
								<p>
									Octavo encuentro de cintas amarillas 2do kyu
								</p>
								<h3>Tipo</h3>
								<p>
									Seminario
								</p>
								<h3>Fecha de inicio</h3>
								<p>
									24/10/2015
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									26/10/2015
								</p>
                                <h3>Locación</h3>
								<ul>
									<li>Estado: Guarico</li>
									<li>Ciudad: San Juan de los Morros</li>
								</ul>
								<h3>Descripción</h3>
								<p>
                                    Encuentro entre los cinturones amarillos de rango 2do Kyu
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
						<h4 class="modal-title">Información detallada del evento</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Nombre</h3>
								<p>
									Clase de Kata
								</p>
								<h3>Tipo</h3>
								<p>
									Entrenamiento especial
								</p>
								<h3>Fecha de inicio</h3>
								<p>
									01/11/2015
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									01/11/2015
								</p>
                                <h3>Locación</h3>
								<ul>
									<li>Estado: Distrito Capital</li>
									<li>Ciudad: Caracas</li>
									<li>Dojo: SAKARATEDO</li>
								</ul>
                                <h3>Profesor</h3>
								<p>
									Juan Biltorgo
								</p>
                                <h3>Hora</h3>
								<p>
									8:00 pm
								</p>
                                <h3>Salón</h3>
								<p>
									A556
								</p>
								<h3>Descripción</h3>
								<p>
                                    Clase teorica-práctica de kata
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
						<h4 class="modal-title">Información detallada del evento</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Nombre</h3>
								<p>
									Competencia entre cintas blancas
								</p>
								<h3>Tipo</h3>
								<p>
									Competencia
								</p>
								<h3>Fecha de inicio</h3>
								<p>
									13/04/2015
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									16/04/2015
								</p>
                                <h3>Tipo de competencia</h3>
								<p>
									Kata
								</p>
                                <h3>Categoria</h3>
                                <ul>
									<li>Edad: 12-18 años</li>
									<li>Cinta: Blanca</li>
									<li>Peso: 40-65 Kgs</li>
								</ul>
                                <h3>Estado</h3>
								<p>
									Finalizada
								</p>
                                <h3>Locación</h3>
								<ul>
									<li>Estado: Distrito Capital</li>
									<li>Ciudad: Caracas</li>
									<li>Dojo: SAKARATEDO</li>
								</ul>
								<h3>Descripción</h3>
								<p>
                                    Competencia solo entre cintas blancas en el dojo SAKARATEDO
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
						<h4 class="modal-title">Información detallada del evento</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Nombre</h3>
								<p>
									Cuarto encuentro de cintas blancas 1er kyu
								</p>
								<h3>Tipo</h3>
								<p>
									Seminario
								</p>
								<h3>Fecha de inicio</h3>
								<p>
									10/05/2015
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									10/05/2015
								</p>
                                <h3>Locación</h3>
								<ul>
									<li>Estado: Guarico</li>
									<li>Ciudad: San Juan de los Morros</li>
								</ul>
								<h3>Descripción</h3>
								<p>
                                    Encuentro entre los cinturones blancos 1er kyu
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
