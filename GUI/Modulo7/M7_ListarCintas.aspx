<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarCintas.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarCintas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Cintas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de cintas obtenidas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

    <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Cintas</h3>
                </div><!-- /.box-header -->


    <div class="box-body table-responsive">

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                    <th>Nivel</th>
                    <th>Tipo</th>
					<th>Color</th>
                    <th>Fecha de obtención</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
                    <td>1er</td>
					<td>Kyu</td>
					<td>Blanco</td>
                    <td>05/04/2015</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                     </td>
                </tr>
                <tr>
					<td>2do</td>
					<td>Kyu</td>
					<td>Amarillo</td>
                    <td>24/10/2015</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info2" href="#"></a>
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
						<h4 class="modal-title">Información detallada de la cinta</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Color</h3>
								<p>
									Blanco
								</p>
								<h3>Nivel</h3>
								<p>
									1er
								</p>
								<h3>Tipo</h3>
								<p>
									Kyu
								</p>
								<h3>Fecha de obtención</h3>
								<p>
									05/04/2015
								</p>
                                <h3>Sensei</h3>
								<p>
									Federico Rojas
								</p>
								<h3>Locación del examen</h3>
                                <ul>
									<li>Estado: Distrito Capital</li>
									<li>Ciudad: Caracas</li>
									<li>Dojo: SAKARATEDO</li>
								</ul>
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
						<h4 class="modal-title">Información detallada de la cinta</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Color</h3>
								<p>
									Amarillo
								</p>
								<h3>Nivel</h3>
								<p>
									2do
								</p>
								<h3>Tipo</h3>
								<p>
									Kyu
								</p>
								<h3>Fecha de obtención</h3>
								<p>
									24/10/2015
								</p>
                                <h3>Sensei</h3>
								<p>
									Juan Gutierrez
								</p>
								<h3>Locación del examen</h3>
                                <ul>
									<li>Estado: Distrito Capital</li>
									<li>Ciudad: Caracas</li>
									<li>Dojo: SAKARATEDO</li>
								</ul>
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
