<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazRestriccionesEventos.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazRestriccionesEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">

    <%--Breadcrumbs--%>
	<ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">

		<li>
			<a href="../Master/Inicio.aspx">Inicio</a>
		</li>
		
		<li>
			<a href="#">Algún Módulo</a>
		</li>
		
		<li class="active">
			Gestión Restricciones de Eventos
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">
    
    Gestión de Restricciones de Eventos

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">

    Restricciones de Eventos

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
	</div>

	<div class="row">
			<div class="col-xs-12">
			  <div class="box">
				<div class="box-header">
				  <h3 class="box-title">Lista de Restricciones de Eventos</h3>
				</div><!-- /.box-header -->

	 
	<div class="box-body table-responsive">

	   <table id="RestriccionesEventos" class="table table-bordered table-striped dataTable">
		<thead>
				<tr>
					<th>ID</th>
					<th>Evento</th>
					<th >Edad Mínima</th>
					<th>Edad Máxima</th>
					<th >Rango Mínimo</th>
					<th >Rango Máximo</th>
					<th >Sexo</th>
					<th >Categoría</th>
                    <th>Especialidad</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">REV_1</td>
					<td>Entrenamiento Especial 1/1/2016  12:00 a 14:00</td>
					<td>10</td>
					<td>18</td>
					<td>Blanco</td>
					<td>Marrón</td>
					<td>Ambos</td>
                    <td>N/A</td>
                    <td>N/a</td>
					<td>
						<a class="btn btn-default glyphicon glyphicon-pencil" href="interfazModificarRestriccionEvento.aspx"></a>
						<a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#modal-delete" href="#"></a>
					 </td>
				</tr>

				<tr>
					<td class="id">REV_2</td>
					<td>Competencia 1/2/2016  12:00 a 14:00</td>
					<td>10</td>
					<td>18</td>
					<td>Blanco</td>
					<td>Marrón</td>
					<td>Femenino</td>
                    <td>Peso Ligero</td>
                    <td>Kumite</td>
					<td>
						<a class="btn btn-default glyphicon glyphicon-pencil" href="interfazModificarRestriccionEvento.aspx"></a>
						<a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#modal-delete" href="#"></a>
					 </td>
				</tr>
				
				
			</tbody>
	</table>

					  

		<div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
		<div class="modal-dialog">
		  <div class="modal-content">
			<div class="modal-header">
			  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			  <h4 class="modal-title" >Eliminaci&oacute;n de Reestricción</h4>
			</div>
			<div class="modal-body">
			  <div class="container-fluid">
				<div class="row">
					<p>¿ Seguro que desea eliminar esta restricción ?</p>
					<%--<p id="req"></p>--%>
				</div>
			  </div>
			</div>
			<div class="modal-footer">  
				<a id="btn-eliminar" type="submit" class="btn btn-primary" href="interfazRestriccionesEventos.aspx?actionSuccess=2">Eliminar</a>
				<button type="submit" class="btn btn-default" data-dismiss="modal">Cancelar</button>
		   </div>
		  </div><!-- /.modal-delete-content -->
		</div><!-- /.modal-delete-dialog -->
	  </div><!-- /.modal-delete -->

		<script type="text/javascript">
			$(document).ready(function () {

			    var table = $('#RestriccionesEventos').DataTable({
					"language": {
						"url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
					}
				});
				var req;
				var tr;

				$('#RestriccionesEventos tbody').on('click', 'a', function () {
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
					modal.find('.modal-title').text('Eliminar Restricción  ')
					modal.find('#req').text(req)
				})
				$('#btn-eliminar').on('click', function () {
					table.row(tr).remove().draw();//se elimina la fila de la tabla
					$('#modal-delete').modal('hide');//se esconde el modal
				});


			});

		</script>
	

</asp:Content>
