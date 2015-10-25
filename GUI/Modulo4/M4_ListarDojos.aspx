<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_ListarDojos.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_ListarDojos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Administración de Dojos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Dojos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

        <div id="alert" runat="server">
    </div>

    
    
     <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Dojos</h3>
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tabladojos" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                      <th style="text-align:center">Foto</th>
                    <th style="text-align:center">Rif</th>
					<th style="text-align:center">Nombre</th>
					<th style="text-align:center">Teléfono</th>
                    <th style="text-align:center">Email</th>
					<th style="text-align:center">Pais</th>
                    <th style="text-align:center">Estado</th>
                    <th style="text-align:center">Ciudad</th>
					<th style="text-align:center">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
                     <td><img src="Imagenes\Aikido.png" alt="" style="width:50px; height:auto;"></td>
					<td class="id">J-17280493-1</td>
					<td>Aikido</td>
					<td>55-4567899</td>
                    <td>Aikido@Dojo.com</td>
					<td>Brasil</td>
                    <td>Río de Janeiro</td>
                    <td>Río de Janeiro</td>

                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M4_ModificaDojo.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                     <td><img src="Imagenes\hokuto.jpg" alt="" style="width:60px; height:auto;"></td>
					<td class="id">J-17280434-1</td>
					<td>hokuto</td>
					<td>0212-4567811</td>
                    <td>hokuto@Dojo.com</td>
					<td>Venezuela</td>
                    <td>Distrito Capital</td>
                    <td>Caracas</td>

                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M4_ModificaDojo.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                     <td><img src="Imagenes\Dai-Fu.jpg" alt="" style="width:60px; height:auto;"></td>
					<td class="id">J-17280422-1</td>
					<td>Dai-Fu</td>
					<td>0212-4533899</td>
                      <td>Dai-Fu@Dojo.com</td>
					<td>Colombia</td>
                    <td>Distrito Capital</td>
                    <td>Bogotá</td>

                    <td>
                     
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M4_ModificaDojo.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                     <td><img src="Imagenes\Kaizen.jpg" alt="" style="width:60px; height:auto;"></td>
					<td class="id">J-17280433-1</td>
					<td>Kaizen</td>
					<td>0212-4567800</td>
                    <td>Kaizen@Dojo.com</td>
					<td>Chile</td>
                    <td>Estado 4</td>
                    <td>Santiago de Chile</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M4_ModificaDojo.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                     <td><img src="Imagenes\rendoki.jpg" alt="" style="width:60px; height:auto;"></td>
					<td class="id">J-17280456-1</td>
					<td>rendoki</td>
					<td>0212-4567867</td>
                    <td>rendoki@Dojo.com</td>
					<td>España</td>
                    <td>Madrid</td>
                    <td>Madrid </td>

                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M4_ModificaDojo.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                     <td><img src="Imagenes\bushido.jpg" alt="" style="width:60px; height:auto;"></td>
					<td class="id">J-17280234-1</td>
					<td>bushido</td>
					<td>0212-2345678</td>
                    <td>bushido@Dojo.com</td>
					<td>Estados Unidos</td>
                    <td>NY</td>
                    <td>Edison</td> 

                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M4_ModificaDojo.aspx"></a>
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
              <h4 class="modal-title" >Eliminaci&oacute;n de Dojo</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el Dojo:</p>
                    <p id="dojo"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" href="M4_ListarDojos.aspx?eliminacionSuccess=2">Eliminar</a>
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
						<h2 class="modal-title">Información De Dojo</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Dojo</h3>
                                 <img src="Imagenes/Aikido.png" width="150" height="150" alt="">
								
                                        <h4>Rif</h4>
                                        <p>J-17280493-1</p>
										<h4>Nombre</h4>
                                         <p>Aikido</p>
										<h4>Teléfono</h4>
                                         <p>55-4567899</p>
                                        <h4>País</h4>
                                         <p>Brasil</p>
                                        <h4>Estado</h4>
                                         <p>Río de Janeiro</p>
                                        <h4>Ciudad</h4>
                                         <p>Río de Janeiro</p>
								
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>




        <script type="text/javascript">
            $(document).ready(function () {
                $('#tabladojos').DataTable();

                var table = $('#tabladojos').DataTable();
                var dojo;
                var tr;

                $('#tabladojos tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        dojo = $(this).parent().prev().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');

                    }
                    else {
                        dojo = $(this).parent().prev().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                });



                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar Dojo:  ' + dojo)
                    modal.find('#dojo').text(dojo)
                })
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                });


            });

        </script> 

</asp:Content>
