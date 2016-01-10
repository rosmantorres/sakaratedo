<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarHorariodePractica.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarHorariodePractica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Horario Práctica
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Lista de las prácticas del atleta
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    <link href="css/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
   
    <script src="js/jquery-ui.js"></script>


    <div id="alert" runat="server"></div>

    <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Horarios de Prácticas</h3>
                </div><!-- /.box-header -->


    <div class="box-body table-responsive">


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
						<h2 class="modal-title">Información detallada del Horario de Práctica</h2>
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
                var table = $('#tablapractica').DataTable({
                    "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                    }
                });
                var req;
                var tr;       
     
            

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
