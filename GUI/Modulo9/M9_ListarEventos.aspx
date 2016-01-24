<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M9_ListarEventos.aspx.cs" Inherits="templateApp.GUI.Modulo9.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
<script type="text/javascript">

    function initialize() {
        var latlng = new google.maps.LatLng(51.508742, -0.120850);
        var mapProp = {
            center: latlng,
            zoom: 5,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var contentString = '<div id="content">' +
                                '<div id="siteNotice">' +
                                    '</div>' +
      '<h1 id="firstHeading" class="firstHeading">Título</h1>' +
      '<div id="bodyContent">' +
      '<p>  Cuerpo </p>' +
      '<p>' +
      '</p>' +
      '</div>' +
      '</div>';

        var infowindow = new google.maps.InfoWindow({
            content: contentString,
            maxWidth: 150
        });

        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

        var point = new google.maps.LatLng(51.508742, -0.120850);
        var marker = new google.maps.Marker({
            position: point,
            map: map,
            title: 'Ubicación',

        })

        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });

    }




    google.maps.event.addDomListener(window, 'load', initialize);
</script>
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
			    Gesti&oacute;n de Eventos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gesti&oacute;n de Eventos
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
					<th style="text-align:center">Fecha Inicio</th>
                    <th style="text-align:center">Fecha Fin</th>
                    <th style="text-align:center">Hora Inicio</th>
                    <th style="text-align:center">Hora Fin</th>
					<th style="text-align:center">Status</th>
                    <th style="text-align:center">Acciones</th>
				</tr>
			</thead>
			    <tbody>
                    <asp:Literal runat="server" ID="tabla"></asp:Literal>    
			    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>
<%-- 
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
                                <h4>Mapa</h4>
                                <div id="googleMap" style="width:250px;height:250px;"></div>


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

        </script>--%>
    
</asp:Content>

