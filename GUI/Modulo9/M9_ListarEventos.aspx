<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M9_ListarEventos.aspx.cs" Inherits="templateApp.GUI.Modulo9.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Eventos y Competencias</a> 
		    </li>
		
		    <li class="active">
			    Gestión de Eventos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Eventos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Lista de Eventos
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
        <table id="tablaeventos" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:center">Nombre</th>
					<th style="text-align:center">Tipo</th>
					<th style="text-align:center">Lugar</th>
					<th style="text-align:center">Fecha Inicio</th>
                    <th style="text-align:center">Fecha Fin</th>
                    <th style="text-align:center">Hora Inicio</th>
                    <th style="text-align:center">Hora Fin</th>
					<th style="text-align:center">Estatus</th>
                    <th style="text-align:center">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">Evento 1</td>
					<td>Entrenamiento Especial</td>
					<td>Dojo A</td>
					<td>01/11/2015</td>
                    <td>03/11/2015</td>
                    <td>02:00 PM</td>
                    <td>07:00 PM</td>
                    <td>Activo</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M9_ModificarEventos.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>

                				<tr>
					<td class="id">Evento 2</td>
					<td>Seminario</td>
					<td>Dojo B</td>
					<td>02/11/2015</td>
                    <td>02/11/2015</td>
                    <td>07:00 AM</td>
                    <td>05:00 PM</td>
                    <td>Activo</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M9_ModificarEventos.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                				<tr>
					<td class="id">Evento 3</td>
					<td>Clase</td>
					<td>Dojo C</td>
					<td>20/10/2015</td>
                    <td>20/10/2015</td>
                    <td>09:00 AM</td>
                    <td>012:00 PM</td>
                    <td>Desactivo</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M9_ModificarEventos.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
					<td class="id">Evento 4</td>
					<td>Simulacro de Competencia</td>
					<td>Parque del Este</td>
					<td>25/10/2015</td>
                    <td>25/10/2015</td>
                    <td>07:00 AM</td>
                    <td>04:00 PM</td>
                    <td>Activo</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M9_ModificarEventos.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
               
			    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>

        <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacute;n de Evento</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el evento:</p>
                    <p id="comp"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" href="M9_ListarEventos.aspx?eliminacionSuccess=2">Eliminar</a>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div><!-- /.modal-delete-content -->
        </div><!-- /.modal-delete-dialog -->
      </div><!-- /.modal-delete -->

    		<div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Descripci&oacute;n del Evento</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Descripci&oacute;n:</h3>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#tablaeventos').DataTable();

                var table = $('#tablaeventos').DataTable();
                var comp;
                var tr;

                $('#tablaeventos tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        comp = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');

                    }
                    else {
                        comp = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                });



                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar Evento:  ' + comp)
                    modal.find('#comp').text(comp)
                })
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                });


            });

        </script>
    
</asp:Content>

