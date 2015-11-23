﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M15_ConsultarImplemento.aspx.cs" Inherits="templateApp.GUI.Modulo15.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>		
		    <li class="active">
			    Consultar Implemento
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Gesti&oacuten de Inventario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Consultar Implemento
</asp:Content>

	<%--Ciudades con sus Dojo--%>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div id="alert" runat="server">
    </div>
       <h3 id="nombre-dojo">Dojo</h3>
       <div class ="row">
        <div class="col-lg-3"> 
        <select id="ubicacion" class="form-control" >
        <option value="0">Todas las ciudades</option>
        <option value="1">Caracas</option>
        <option value="2">Maracay</option>
        <option value="3">Valencia</option>
        </select>
            </div>
            <div class="col-lg-3">
        <select id="dojo" class="form-control" >
        <option value="1">Dojo A</option>
        <option value="2">Dojo B</option>
        <option value="3">Dojo C</option>
        <option value="4">Dojo D</option>
        <option value="5">Dojo E</option>
        <option value="6">Dojo F</option>
        </select>
             </div>
            <div class="col-lg-4">
        
             </div>
            <div class="col-lg-2">
        <select id="Select2" class="form-control" >
        <option value="1">Activo</option>
        <option value="2">Inactivo</option>
        </select>
             </div>
        </div>

    	<%--Contenido de la tabla--%>

    <div class="box-body table-responsive">
       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th>ID</th>
					<th>Nombre</th>
					<th>Tipo</th>
                    <th>Marca</th>
					<th>Color</th>
                    <th>Talla</th>
                    <th>Dojo</th>
                    <th>Cantidad</th>
                    <th>Stock M&iacutenimo</th>
                    <th>Estatus</th>
					<th>Precio (Bs)</th>
                    <th >Monto Total Bs</th>
                    <th>Proveedor</th>
                   <th style="text-align:right;">Acciones</th>
				</tr>
			</thead>

           	<%--llenado de la tabla--%>

			<tbody>
                <tr>
                <td class="id">1</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Rojo</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td>     
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" " href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
           <tr>
                <td class="id">2</td>
               	<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Azul</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                <td class="id">3</td>
					<td>Cinta</td>
					<td>Vestimenta</td>	
                    <td>Everblast</td>
                    <td>Amarillo</td>
                    <td>S</td>
                    <td>Red Dragon</td>
                    <td>30</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>30000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                <td class="id">4</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Rojo</td>
                    <td>M</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                <td class="id">5</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Rojo</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                <td class="id">6</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Rojo</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">7</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Rojo</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">8</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Rojo</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">9</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Rojo</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">10</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>rojo</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">11</td>
					<td>Guante de pelea</td>
					<td>Accesorio</td>	
                    <td>Kombate</td>
                    <td>Rojo</td>
                    <td>L</td>
                    <td>Green Dragon</td>
                    <td>20</td>
                    <td>5</td>
                    <td><div class="panel panel-default caja">
                    <div class="panel-body alert-error">                    
                    </div>
                    </div></td> 
                    <td>1000</td>
                    <td>20000</td>
                    <td>Shurido</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M15_ModificarImplemento.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>



			</tbody>
    </table>
        	<%--fin del llenado de la tabla--%>


        	<%--botón de eliminación de un implemento--%>

        <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacuten del implemento</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el implemento:</p>
                    <p id="req"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" href="M15_ConsultarImplemento.aspx?eliminacionSuccess=1">Eliminar</a>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div>
        </div>
      </div>
        	<%--botón de información de un implemento--%>

    		<div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Informaci&oacuten detallada del Producto</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
                                <div class="col-lg-6">
                                <p id="nombre_articulo"> Nombre del Implemento:</p>
                                <p id="talla_articulo"> Talla :</p>
                                <p id="color_articulo"> Color :</p>
                                <p id="marca_articulo"> Marca :</p>
                                <p id="dojo_articulo"> Dojo :</p>
                                <p id="cantidad_articulo"> Cantidad :</p>
                                <p id="stock_minimo_articulo">Stock M&iacutenimo :</p>
                                <p id="precio_articulo"> Precio Bs :</p>
                                <p id="monto_total_articulo"> Monto Total Bs :</p> 
                                <p id="proveedor_articulo">Proveedor :</p>
                                    </div>
                                <div class="col-lg-4">

                                  <div id="imagen_articulo"></div>  

                                </div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
    </div>

      <!-- Declaración de las alertas-->
        <script type="text/javascript">
            $(document).ready(function () {
                $(".caja").height(10);
                $(".caja").width(10);
                $("#nombre-dojo").css("text-align", "center");

                var table = $('#example').DataTable({  //lenguaje del DataTable
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                      },
                        
                   "columnDefs":[{//esconde el ID de la tabla
                            "targets":[0],
                            "visible":false
                   }]
                    
                });

                var req;
                var tr;
                // imprimir mensaje de confirmación de eliminar
                $('#example tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        req = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        tr = $(this).parent(); // se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');


                    }
                    else {
                        req = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        tr = $(this).parent();//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }

                });



                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar Implemento:  ' + req);
                    modal.find('#req').text(req);

                });
                // imprime en el modal la información
                $('#modal-info').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('#nombre_articulo').text("Nombre Implemento: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#tipo_articulo').text("Tipo: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#marca_articulo').text("Marca: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#color_articulo').text("Color: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#talla_articulo').text("Talla: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#dojo_articulo').text("Dojo: " + tr.prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#cantidad_articulo').text("Cantidad :" + tr.prev().prev().prev().prev().prev().prev().text());
                    modal.find('#stock_minimo_articulo').html("Stock M&iacutenimo :" + tr.prev().prev().prev().prev().prev().text());
                    modal.find('#precio_articulo').text("Precio (Bs): " + tr.prev().prev().prev().text());
                    modal.find('#monto_total_articulo').text("Monto Total: " + tr.prev().prev().text());
                    modal.find('#proveedor_articulo').text("Proveedor: " + tr.prev().text());

                });

                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                });

                //comboBox de ciudad con sus Dojo
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

                $("#nombre-dojo").text($("#dojo option:selected").text());
                $("#dojo").change(function () {
                    $("#nombre-dojo").text($("#dojo option:selected").text());
                });
                $("#ubicacion").change(function () {
                    $("#nombre-dojo").text($("#dojo option:selected").text());
                });
                $("#id").hide();
            });

        </script>
    
</asp:Content>