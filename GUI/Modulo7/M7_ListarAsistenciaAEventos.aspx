<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarAsistenciaAEventos.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarAsistenciaAEventos" %>
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
			    Consultar Eventos Asistidos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Asistencias a Eventos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de los eventos a los que has asistido
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

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
                  <h3 class="box-title">Eventos</h3>
                </div><!-- /.box-header -->
    
    <div class="box-body table-responsive">

        <div class="center-block" id="baseFechaControl">
            <div class="dateControlBlock">
                 Desde fecha: <input type="text" name="fechaInicio" id="fechaInicio" class="datepicker" size="8"/> Hasta fecha:   
                 <input type="text" name="fechaFin" id="fechaFin" class="datepicker" size="8"/>
            </div>
        </div>

       <table id="tablaasistencia" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th>Nombre</th>
                    <th>Tipo</th>
					<th>Fecha de Inscripcion</th>
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
						<h2 class="modal-title">Información detallada del Articulo</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row">
                                <p>
									<input type="text" id="beta" value="" />
								</p>
								<h3>Nombre</h3>
								<p>
									<input type="text" id="beta4" value="" />
								</p>

								<h3>Cantidad disponible</h3>
                                <br />
                                <form role="form" class="form-horizontal" method="POST">
                                     <div class="col-sm-8 col-md-8 col-lg-8" >
                                     </div>
                                    <br />
                               
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

    
                      
    
    <!--VALIDACION PARA MODAL -->
    <script src="js/Validacion.js"></script>

        <script type="text/javascript">
            $.datepicker.setDefaults($.datepicker.regional["es"]);
            $(document).ready(function () {
                var table = $('#tablaasistencia').DataTable({
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
                    //dateFormat: 'dd/m/yy',
                    onClose: function (selectedDate) {
                        $("#fechaFin").datepicker("option", "minDate", selectedDate);
                    }
                });
                $("#fechaFin").datepicker({
                    minDate: "-50Y",
                    maxDate: "Y",
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    showOn: 'button',
                    buttonImage: 'css/images/calendar.gif',
                    buttonText: 'Mostrar Fecha',
                    //dateFormat: 'dd/m/yy',
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
             
                $('#tablaasistencia tbody').on('click', 'a', function () {
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
                        url: 'http://localhost:23072/GUI/Modulo7/M7_ListarAsistenciaAEventos.aspx/prueba',
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
