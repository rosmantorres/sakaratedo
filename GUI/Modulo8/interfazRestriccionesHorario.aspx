<%@ Page EnableEventValidation="true" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazRestriccionesHorario.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazRestriccionesHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <title>Consultar Restricciones Horarios-Eventos</title>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

    <%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		    <li>
			    <a href="../Modulo8/interfazMenuRestriccionesCintasYEventos.aspx">Menú de Restricciones de Cintas y Eventos</a>
		    </li>
		    <li class="active">
			    Gestión Restricciones de Horarios
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Restricciones de Horarios</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Restricciones de Horarios</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
   <div id="alert" runat="server">
   </div>
  <div class="row">
   <div class="col-xs-12">
	 <div class="box">
	   <div class="box-header">
		   <h3 class="box-title">Lista de Restricciones de Horarios</h3>
		</div><!-- /.box-header -->
      <form role="form" name="consultar_planilla" id="consular_planillas" runat="server">

	      <div class="box-body table-responsive">

	      <table id="RestriccionesCintas" class="table table-bordered table-striped dataTable" accesskey="">
		   <thead>
			<tr>
			    <th>Id Restriccion</th>
			    <th>Id Evento</th>
			    <th>Nombre Evento</th>
			    <th>Edad Minima</th>
			    <th>Edad Maxima</th>
                <th>Cinta</th>
                <th>Sexo</th>
                <th>Status</th>
			    <th style="text-align:right;">Acciones</th>
			</tr>
		   </thead>
          <asp:Literal runat="server" ID="tabla"></asp:Literal>
		<tbody>
							
				
	</tbody>
	  </table>
       </div>
     </form>

					  

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
				<a id="btn-eliminar" type="submit" class="btn btn-primary" href="interfazRestriccionesHorario.aspx?actionSuccess=2">Eliminar</a>
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
