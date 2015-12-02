<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarHorariodePractica.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarHorariodePractica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		
		    <li>
			    <a href="M7_ListarOrganizacionYDojo.aspx">Consulta Atletas</a> 
		    </li>

		    <li class="active">
			   Consultar Horario de Práctica
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Horario de Práctica
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de los horarios de práctica
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <link href="css/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="css/daterange.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <script src="js/daterange.js"></script>
    <script src="js/jquery.ui.datepicker-es.js"></script>
       
     <div id="alert" runat="server"> </div>
   
    <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Horario</h3>
                </div><!-- /.box-header -->


    <div class="box-body table-responsive">

        <div class="center-block" id="baseFechaControl">
            <div class="dateControlBlock">
                 Desde fecha: <input type="text" name="fechaInicio" id="fechaInicio" class="datepicker" size="8"/> Hasta fecha:   
                 <input type="text" name="fechaFin" id="fechaFin" class="datepicker" size="8"/>
            </div>
        </div>



       <table id="tablapractica" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th>Práctica</th>
                    <th>Hora Inicio</th>
                    <th>Hora Fin</th>
                    <th>Ubicación</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				    <asp:Literal runat="server" ID="laTabla"></asp:Literal>   
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
						<div class="container-fluid" id="info1">
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
						<div class="container-fluid" id="info2">
							<div class="row">
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
						<h4 class="modal-title">Información detallada del horario de práctica</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info3">
							<div class="row">
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
						<div class="container-fluid" id="info4">
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

                var table = $('#tablapractica').DataTable({
                    "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                    }
                });
                var req;
                var tr;

                $('#tablapractica tbody').on('click', 'a', function () {
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

                $('#modal-info1').on('show.bs.modal', function (e) {

                    $.ajax({
                        cache: false,
                        type: 'POST',
                        url: 'http://localhost:23072/GUI/Modulo7/M7_ListarHorarioPractica.aspx/prueba',
                        data: "{'id':" + "'" + e.relatedTarget.id + "'" + "}",
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",

                        success: function (data) {
                            console.log(data);

                            var aa = JSON.parse(data.d);

                            $("#beta").val(aa.nombre);
                            $("#beta4").val(aa.id);

                        }
                    });
                })
            });

        </script>

</asp:Content>

