<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M15_ConsultarImplemento.aspx.cs" Inherits="templateApp.GUI.Modulo15.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Gestion de Inventario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Consultar Implemento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
    <div id="alert" runat="server">
    </div>
    
    <center><h3 id="nombre-dojo">Dojo</h3></center>
    <select id="ubicacion">
        <option value="0">Todas las ciudades</option>
        <option value="1">Caracas</option>
        <option value="2">Maracay</option>
        <option value="3">Valencia</option>
    </select>
        <select id="dojo">
        <option value="1">Dojo A</option>
        <option value="2">Dojo B</option>
        <option value="3">Dojo C</option>
        <option value="4">Dojo D</option>
        <option value="5">Dojo E</option>
        <option value="6">Dojo F</option>

    </select>
    <div class="box-body table-responsive">

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th>ID</th>
					<th >Nombre</th>
					<th>Tipo</th>
                    <th >Marca</th>
					<th >Color</th>
                    <th >Talla</th>
                    <th >Dojo</th>
                    <th >Cantidad</th>
					<th >Precio Bs</th>
                    <th >Monto Total Bs</th>
                   <th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				

                <tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" " href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
           <tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>azul</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                <td class="id">1</td>
					<td>cinta</td>
					<td>vestimenta</td>	
                    <td>pirata</td>
                    <td>amarillo</td>
                    <td>s</td>
                    <td>boina verde</td>
                    <td>30</td>
                    <td>1000</td>
                    <td>30000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>M</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>El dragon verde</td>
                    <td>20</td>
                    <td>1000</td>
                    <td>20000</td>
                    
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>



			</tbody>
    </table>

        <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacute;n del Articulo</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el Articulo:</p>
                    <p id="req"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" href="M15_consultar_implemento.aspx?eliminacionSuccess=1">Eliminar</a>
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
						<h4 class="modal-title">Información detallada del Producto</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
                                <p id="nombre_articulo"> Nombre del Articulo :</p>
                                <p id="talla_articulo"> Talla :</p>
                                <p id="color_articulo"> Color :</p>
                                <p id="marca_articulo"> Marca :</p>
                                <p id="dojo_articulo"> Dojo :</p>
                                <p id="cantidad_articulo"> Cantidad :</p>
                                <p id="precio_articulo"> Precio Bs:</p>
                                <p id="monto_total_articulo"> Monto Total Bs:</p> 
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>



    </div>

        <script type="text/javascript">
            $(document).ready(function () {
             

               var table = $('#example').DataTable({
                   "language": {
                       "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                   }
               });

                var req;
                var tr;

                $('#example tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        req = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        tr = $(this).parent(); // se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');


                    }
                    else {
                        req = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        tr = $(this).parent();//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                  
                });



                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar Articulo:  ' + req);
                    modal.find('#req').text(req);

                });

                $('#modal-info').on('show.bs.modal', function (event) {
                    var modal = $(this)
                   
                    modal.find('#nombre_articulo').text("Nombre articulo: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#tipo_articulo').text("Tipo: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#marca_articulo').text("Marca: " + tr.prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#color_articulo').text("Color: " + tr.prev().prev().prev().prev().prev().prev().text());
                    modal.find('#talla_articulo').text("Talla: " + tr.prev().prev().prev().prev().prev().text());
                    modal.find('#dojo_articulo').text("Dojo: " + tr.prev().prev().prev().prev().text());
                    modal.find('#cantidad_articulo').text("Cantidad :" + tr.prev().prev().prev().text());
                    modal.find('#precio_articulo').text("Precio Bs: " + tr.prev().prev().text());
                    modal.find('#monto_total_articulo').text("Monto Total: " + tr.prev().text());


                });

                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                });

                $("#ubicacion").change(function () {


                    if ($("#ubicacion").val() == "0") {
                        $("#dojo").html("<option value='1'>Dojo A</option> <option value='2'>Dojo B</option><option value='3'>Dojo C</option> <option value='4'>Dojo D</option><option value='5'>Dojo E</option> <option value='6'>Dojo F</option>");
                    }
                    else if ($("#ubicacion").val() == "1") {
                        $("#dojo").html("<option value='1'>Dojo A</option> <option value='2'>Dojo B</option>");
                    } else if ($("#ubicacion").val() == "2") {
                        $("#dojo").html("<option value='3'>Dojo C</option> <option value='4'>Dojo D</option>");
                    } else {
                        $("#dojo").html("<option value='5'>Dojo E</option> <option value='6'>Dojo F</option>");
                    }
                });
                $("#dojo").change(function () {
                    $("#nombre-dojo").text($("#dojo option:selected").text());
                });
            });

        </script>
    
</asp:Content>
