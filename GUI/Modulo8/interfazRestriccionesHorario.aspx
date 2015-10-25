<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazRestriccionesHorario.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazRestriccionesHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">

<%--Titulo--%>
 Gestion de Restricciones de Horarios
<%--Fin_Titulo--%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    
    Restricciones de Horarios
	
	<%--Breadcrumbs--%>
	<ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">

		<li>
			<a href="../Master/Inicio.aspx">Home</a>
		</li>
		
		<li>
			<a href="#">Gestion de Horarios</a>
		</li>
		
		<li class="active">
			Gestion de Horarios
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
	
	<div id="alert" runat="server">
	</div>

	<div class="row">
			<div class="col-xs-12">
			  <div class="box">
				<div class="box-header">
				  <h3 class="box-title">Lista de Restricciones</h3>
				</div><!-- /.box-header -->

	
  
  
				  
	<div class="box-body table-responsive">

	   <table id="Restricciones" class="table table-bordered table-striped dataTable">
		<thead>
				<tr>
					<th><input type="checkbox" id="checkall" /></th>
					<th>ID</th>
					<th>Horario</th>
					<th >Edad Minima</th>
					<th>Edad Maxima</th>
					<th >Rango Minimo</th>
					<th >Rango Maximo</th>
					<th >Sexo</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td><input type="checkbox" class="checkthis" /></td>
					<td class="id">RH_1</td>
					<td>Lunes-Miercoles-Viernes 12:00 a 14:00</td>
					<td>10</td>
					<td>18</td>
					<td>Blanco</td>
					<td>Marron</td>
					<td>Ambos</td>
					<td>
						<a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
						<a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#modal-delete" href="#"></a>
					 </td>
				</tr>

				<tr>
					<td><input type="checkbox" class="checkthis" /></td>
					<td class="id">RH_1</td>
					<td>Lunes-Miercoles-Viernes 12:00 a 14:00</td>
					<td>10</td>
					<td>18</td>
					<td>Blanco</td>
					<td>Marron</td>
					<td>Ambos</td>
					<td>
						<a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
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
			  <h4 class="modal-title" >Eliminaci&oacute;n de Reestriccion</h4>
			</div>
			<div class="modal-body">
			  <div class="container-fluid">
				<div class="row">
					<p>Seguro que desea eliminar esta restriccion</p>
					<%--<p id="req"></p>--%>
				</div>
			  </div>
			</div>
			<div class="modal-footer">  
				<a id="btn-eliminar" type="button" class="btn btn-primary" href="interfazRestriccionesHorario.aspx?actionSuccess=2">Eliminar</a>
				<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
		   </div>
		  </div><!-- /.modal-delete-content -->
		</div><!-- /.modal-delete-dialog -->
	  </div><!-- /.modal-delete -->

		<script type="text/javascript">
			$(document).ready(function () {

				var table = $('#Restricciones').DataTable({
					"language": {
						"url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
					}
				});
				var req;
				var tr;

				$('#Restricciones tbody').on('click', 'a', function () {
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
					modal.find('.modal-title').text('Eliminar Restriccion  ')
					modal.find('#req').text(req)
				})
				$('#btn-eliminar').on('click', function () {
					table.row(tr).remove().draw();//se elimina la fila de la tabla
					$('#modal-delete').modal('hide');//se esconde el modal
				});


			});

		</script>
	
</asp:Content>
