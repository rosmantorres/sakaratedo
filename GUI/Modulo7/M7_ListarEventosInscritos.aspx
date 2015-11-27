<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarEventosInscritos.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarEventosInscritos" %>
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
			    Consultar Eventos Inscritos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Eventos Inscritos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de los eventos en los que está inscrito
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <link href="css/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="css/daterange.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <script src="js/daterange.js"></script>
    <script src="js/jquery.ui.datepicker-es.js"></script>

    <link href="css/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="css/daterange.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <script src="js/daterange.js"></script>
    <script src="js/jquery.ui.datepicker-es.js"></script>

    <div id="alert" runat="server"></div>

    <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Eventos Inscritos</h3>
                </div><!-- /.box-header -->

    <div class="box-body table-responsive">

        <div class="center-block" id="baseFechaControl">
            <div class="dateControlBlock">
                 Desde fecha: <input type="text" name="fechaInicio" id="fechaInicio" class="datepicker" size="8"/> Hasta fecha:   
                 <input type="text" name="fechaFin" id="fechaFin" class="datepicker" size="8"/>
            </div>
        </div>


       <table id="tablainscritos" class="table table-bordered table-striped dataTable">
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
						<h4 class="modal-title">Información detallada de los eventos inscritos</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row">
								<h3>Nombre</h3>
								<p>
								    Noveno encuentro de cintas negras 5to KYU
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
								<div>
									<ul>
                                        <li>Estado: Guárico</li>
                                        <li>Ciudad: San Juan de los Morros </li>
									</ul>
								</div>
								<h3>Descripción</h3>
								<p>
                                    Encuentro de atletas con cinta negra de 5to KYU. 
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
						<div class="container-fluid" id="info2">
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
									06/05/2016
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									06/25/2016
								</p>
                                <h3>Locación</h3>
								<div>
									<ul>
                                        <li>Estado: Carabobo</li>
                                        <li>Ciudad: Valencia </li>
									</ul>
								</div>
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
						<div class="container-fluid" id="info3">
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
									12/03/2015
								</p>
								<h3>Fecha de finalización</h3>
								<p>
									01/15/2016
								</p>
                                <h3>Locación</h3>
								<div>
									<ul>
                                        <li>Estado: Distrito Capital</li>
                                        <li>Ciudad: Caracas </li>
									</ul>
								</div>
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
						<div class="container-fluid" id="info4">
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
									12/15/2015
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
            $.datepicker.setDefaults($.datepicker.regional["es"]);
            $(document).ready(function () {

                var table = $('#tablainscritos').DataTable({
                    "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                    }
                });
                var req;
                var tr;
                $dateControls = $("#baseFechaControl").children("div").clone();
                $("#feedbackTable_filter").prepend($dateControls);

                // Implementacion de jQuery UI Datepicker widget sobre los controles de fechas
                $("#fechaInicio").datepicker({
                    minDate: "-50Y",
                    maxDate: "Y",
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    showOn: 'button',
                    buttonImage: 'css/images/calendar.gif',
                    buttonText: 'Mostrar Fecha',
                    onClose: function (selectedDate) {
                        $("#fechaFin").datepicker("option", "minDate", selectedDate);
                    }
                });
                $("#fechaFin").datepicker({
                    minDate: "-50Y",
                    maxDate: "+50Y",
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    showOn: 'button',
                    buttonImage: 'css/images/calendar.gif',
                    buttonText: 'Mostrar Fecha',
                    onClose: function (selectedDate) {
                        $("#fechaInicio").datepicker("option", "maxDate", selectedDate);
                    }
                });

                // Crea el evento listeners que va a filtrar la tabla siempre que el usuario escriba el usuario escriba
                // en el datepicker 
                $("#fechaInicio").keyup(function () { table.draw(); });
                $("#fechaInicio").change(function () { table.draw(); });
                $("#fechaFin").keyup(function () { table.draw(); });
                $("#fechaFin").change(function () { table.draw(); });

                $('#tablainscritos tbody').on('click', 'a', function () {
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
