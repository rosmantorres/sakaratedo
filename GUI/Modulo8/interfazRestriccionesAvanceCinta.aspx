﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazRestriccionesAvanceCinta.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazRestriccionesAvanceCinta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">

    <%--Breadcrumbs--%>
	<ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">

		<li>
			<a href="../Master/Inicio.aspx">Inicio</a>
		</li>
		
		<li>
			<a href="../Modulo8/interfazMenuRestriccionesCintasYEventos.aspx">Menú de Restricciones de Cintas y Eventos</a>
		</li>
		
		<li class="active">
			Gestión Restricciones de Avance de Cinta
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">

    Gestión de Restricciones de Avance de Cinta
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">

    Restricciones de Avance de Cinta

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
	</div>

	<div class="row">
			<div class="col-xs-12">
			  <div class="box">
				<div class="box-header">
				  <h3 class="box-title">Lista de Restricciones de Avance de Cinta</h3>
				</div><!-- /.box-header -->

	 
	<div class="box-body table-responsive">

	   <table id="RestriccionesCintas" class="table table-bordered table-striped dataTable">
		<thead>
				<tr>
					<th>ID</th>
					<th>Cinta</th>
					<th >Tiempo Mínimo</th>
					<th>Puntaje Mínimo</th>
					<th >Mínimo Horas Docentes</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">RPC_1</td>
					<td>Blanca</td>
					<td>3 meses</td>
					<td>30pts</td>
					<td>0 horas</td>
					<td>
						<a class="btn btn-default glyphicon glyphicon-pencil" href="interfazModificarRestriccionAvanceCinta.aspx"></a>
						<a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#modal-delete" href="#"></a>
					 </td>
				</tr>

				<tr>
					<td class="id">RPC_2</td>
					<td>Amarilla</td>
					<td>5 meses</td>
					<td>60pts</td>
					<td>2 horas</td>
					<td>
						<a class="btn btn-default glyphicon glyphicon-pencil" href="interfazModificarRestriccionAvanceCinta.aspx"></a>
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
				<a id="btn-eliminar" type="submit" class="btn btn-primary" href="interfazRestriccionesAvanceCinta.aspx?actionSuccess=2">Eliminar</a>
				<button type="submit" class="btn btn-default" data-dismiss="modal">Cancelar</button>
		   </div>
		  </div><!-- /.modal-delete-content -->
		</div><!-- /.modal-delete-dialog -->
	  </div><!-- /.modal-delete -->

		<script type="text/javascript">
			$(document).ready(function () {

			    var table = $('#RestriccionesCintas').DataTable({
					"language": {
						"url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
					}
				});
				var req;
				var tr;

				$('#RestriccionesCintas tbody').on('click', 'a', function () {
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
