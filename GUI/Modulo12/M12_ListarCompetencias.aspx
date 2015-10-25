<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M12_ListarCompetencias.aspx.cs" Inherits="templateApp.GUI.Modulo12.M12_ListarCompetencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="http://maps.googleapis.com/maps/api/js"></script>
<script type="text/javascript">

    function initialize() {
        var latlng = new google.maps.LatLng(10.5000, -66.9167);
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

        var point = new google.maps.LatLng(10.5000, -66.9167);
        var marker = new google.maps.Marker({
            position: point,
            map: map,
            title: 'Ubicación',

        })

        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });
        
        // CARGA DE API GOOGLE MAPS EN MODAL DE BOOTSTRAP 3
        $('#modal-info').on('shown.bs.modal', function () {
            google.maps.event.trigger(map, "resize");
            map.setCenter(new google.maps.LatLng(10.5000, -66.9167));
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
			    Gestión de Competencias
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Competencias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Competencias
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

    
    
     <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Competencias</h3>
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tablacompetencias" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:left">Nombre</th>
					<th style="text-align:left">Tipo</th>
					<th style="text-align:left">Organizaciones Participantes</th>
                    <th style="text-align:left">Ubicación</th>
					<th style="text-align:left">Categoria</th>
                    <th style="text-align:left">Status</th>
					<th style="text-align:left">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">Competencia 1</td>
					<td>Kata</td>
					<td>Organización 1</td>
                    <td>Caracas, Venezuela</td>
					<td>Categoria 1</td>
                    <td>Por Iniciar</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M12_ModificarCompetencias.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
					<td class="id">Competencia 2</td>
					<td>Kata</td>
					<td>Organización 1, Organización 2</td>
                    <td>Caracas, Venezuela</td>
					<td>Categoria 1</td>
                    <td>Por Iniciar</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M12_ModificarCompetencias.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
					<td class="id">Competencia 3</td>
					<td>Kumite</td>
					<td>Organización 1, Organización 3</td>
                    <td>Caracas, Venezuela</td>
					<td>Categoria 1</td>
                    <td>Por Iniciar</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M12_ModificarCompetencias.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
					<td class="id">Competencia 4</td>
					<td>Kumite</td>
					<td>Organización 4</td>
                    <td>Caracas, Venezuela</td>
					<td>Categoria 1</td>
                    <td>Por Iniciar</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M12_ModificarCompetencias.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
					<td class="id">Competencia 5</td>
					<td>Kata</td>
					<td>Organización 1</td>
                    <td>Caracas, Venezuela</td>
					<td>Categoria 1</td>
                    <td>Por Iniciar</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M12_ModificarCompetencias.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
					<td class="id">Competencia 6</td>
					<td>Kumite</td>
					<td>Organización 3</td>
                    <td>Caracas, Venezuela</td>
					<td>Categoria 1</td>
                    <td>Por Iniciar</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M12_ModificarCompetencias.aspx"></a>
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
              <h4 class="modal-title" >Eliminaci&oacute;n de Competencia</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar la competencia:</p>
                    <p id="comp"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" href="M12_ListarCompetencias.aspx?eliminacionSuccess=2">Eliminar</a>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div><!-- /.modal-delete-content -->
        </div><!-- /.modal-delete-dialog -->
      </div><!-- /.modal-delete -->

    		<div/ id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Información de Competencia</h4>
					</div>
					<div class="modal-body">
                        <div class="row">
                            <h4 style="text-align:match-parent">&nbsp;&nbsp;&nbsp; Nombre de Competencia:</h4>
                            <ul>
                                <li>Competencia 1</li>
                            </ul>
                            <h4>&nbsp;&nbsp;&nbsp; Tipo de Competencia:</h4>
                            <ul>
                                <li>Kata</li>
                            </ul>
                            <h4>&nbsp;&nbsp;&nbsp; Organizaciones Involucradas:</h4>
                            <ul>
                                <li>Organización 1, Organización 2</li>
                            </ul>
                        </div>
                        <h4>&nbsp;&nbsp;&nbsp; Ubicación de Competencia</h4>                     
                        <div id="googleMap" style="width:500px;height:250px;"></div>
					</div>
				</div>
			</div>
		</div>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#tablacompetencias').DataTable();

                var table = $('#tablacompetencias').DataTable();
                var comp;
                var tr;

                $('#tablacompetencias tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        comp = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');

                    }
                    else {
                        comp = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                });



                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar Competencia:  ' + comp)
                    modal.find('#comp').text(comp)
                })
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                });


            });

        </script>
    
</asp:Content>

