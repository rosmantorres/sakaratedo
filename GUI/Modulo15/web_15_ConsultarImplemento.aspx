﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="web_15_ConsultarImplemento.aspx.cs" Inherits="templateApp.GUI.Modulo15.web_15_ConsultarImplemento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    
    <div id="alert" runat="server">
    </div>
    <div id="alert2" runat="server">
    </div>

       <center><h3 id="nombre_dojo" runat="server">Dojo</h3></center>
       <div class ="row">
        <div class="col-lg-3"> 


        <select id="estatus_implemento" class="form-control" >
        <option value="1">Activo</option>
        <option value="2">Inactivo</option>
        </select>
    
            </div>
            <div class="col-lg-3">
             </div>
            <div class="col-lg-4">
        
             </div>
            <div class="col-lg-2">
             </div>
        </div>

    	<%--Contenido de la tabla--%>

    <div class="box-body table-responsive">

                          
           <table id="example" class="table table-bordered table-striped dataTable" >
                <thead>
    			
                    <tr>
				
                    <th >ID</th>
					<th class="tomar" >Nombre</th>
					<th class="tomar" >Tipo</th>
                    <th class="tomar">Marca</th>
					<th class="tomar">Color</th>
                    <th class="tomar">Talla</th>
                    <th class="tomar">Cantidad</th>
                    <th>Stock M&iacutenimo</th>
                    <th>Estatus</th>                 
					<th class="tomar">Precio (Bs)</th>
                    <th >Monto Total Bs</th>
                   <th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
                <tfoot>
                        <tr>
                    <th>ID</th>
					<th >Nombre</th>
					<th >Tipo</th>
                    <th >Marca</th>
					<th >Color</th>
                    <th >Talla</th>
                    <th >Cantidad</th>
                    <th>Stock M&iacutenimo</th>
                    <td>Estatus</td>                 
					<th >Precio (Bs)</th>
                    <th>Monto Total Bs</th>
                   <td style="text-align:right;">Acciones</td>
                            
                        </tr>
                    </tfoot>
                    <tbody id="cuerpo"> 
            <asp:Literal runat="server" ID="tabla"></asp:Literal>
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
                <a id="btneliminar" type="button" class="btn btn-primary"  href="web_15_eliminarImplemento.aspx?eliminacionSuccess=1" >Eliminar</a>
                <button type="button" class="btn btn-default" data-dismiss="modal" >Cancelar</button>
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
                                <p id="tipo_articulo"> Tipo de Implemento:</p>
                                <p id="talla_articulo"> Talla :</p>
                                <p id="color_articulo"> Color :</p>
                                <p id="marca_articulo"> Marca :</p>
                                <p id="cantidad_articulo"> Cantidad :</p>
                                <p id="stock_minimo_articulo">Stock M&iacutenimo :</p>
                                <p id="precio_articulo"> Precio Bs :</p>
                                <p id="monto_total_articulo"> Monto Total Bs :</p> 
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
<script type="text/javascript" src="../../plugins/datatables/extensions/TableTools/js/dataTables.tableTools.js" ></script>
 <link rel="stylesheet" type="text/css" href="../../plugins/datatables/extensions/TableTools/css/dataTables.tableTools.css" />


        <link rel="stylesheet" type="text/css" href="../../plugins/dataTables.tableTools.css" media="screen" />

        <script type="text/javascript">
            $(document).ready(function () {
                $(".caja").height(10);
                $(".caja").width(10);
                $("#nombre-dojo").css("text-align", "center");

                var table = $('#example').DataTable({  //lenguaje del DataTable
                    "iDisplayLength": 6,
                    "bLengthChange": false,

                    dom: 'T<"clear">lfrtip',

                    "smart":true,
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                    },

                    "columnDefs": [{//esconde el ID de la tabla
                        "targets": [0],
                        "visible": false
                    }],
                    tableTools: {
                        "sSwfPath": "../../plugins/copy_csv_xls_pdf.swf",
                        "aButtons": [
                            "copy",
                            "csv",
                            "xls",
                            {
                                "sExtends": "pdf",
                                "sPdfOrientation": "landscape",
                                "sPdfMessage": "Lista de Implementos"

                            },
                            "print"
                        ]
                    }

                });

           

             

                table.columns().every(function (){
                    var that = this;

                    $( 'input', this.footer()).on( 'keyup change', function () {
                     //   alert(that.search());
                        if (that.search() !== this.value) {

                            that.search(this.value).draw();
                        } 
                } );
                });




                var req;
                var tr;
                var idEliminar;
                // imprimir mensaje de confirmación de eliminar

                $('a.eliminar_clase').click(function (e) {
                    idEliminar = $(this).attr("data-id");
                    //   alert(idEliminar);
                    $('#btneliminar').attr("href", "web_15_ConsultarImplemento.aspx?consultar=eliminar&idImplemento=" + idEliminar);


                });

                $('#example tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        req = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        idEliminar = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        tr = $(this).parent(); // se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');


                    }
                    else {
                        req = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text();
                        idEliminar = $(this).parent().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text();
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
                    modal.find('#nombre_articulo').text("Nombre Implemento: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#tipo_articulo').text("Tipo: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#talla_articulo').text("Talla: " + tr.prev().prev().prev().prev().prev().prev().text());
                    modal.find('#color_articulo').text("Color: " + tr.prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#marca_articulo').text("Marca: " + tr.prev().prev().prev().prev().prev().prev().prev().prev().text());
                    modal.find('#cantidad_articulo').text("Cantidad :" + tr.prev().prev().prev().prev().prev().text());
                    modal.find('#stock_minimo_articulo').html("Stock M&iacutenimo :" + tr.prev().prev().prev().prev().text());
                    modal.find('#precio_articulo').text("Precio (Bs): " + tr.prev().prev().text());
                    modal.find('#monto_total_articulo').text("Monto Total: " + tr.prev().text());

                });

                $('#btneliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                });


                var posicion = location.href;
                if (posicion.split("=")[1] == "Activo") {
                    $("#estatus_implemento").val(1);

                }
                else {
                    if (posicion.split("=")[1] == "Inactivo") {

                        $("#estatus_implemento").val(2);
                    }
                }

                $("#estatus_implemento").change(function () {

                    var respuesta = $("#estatus_implemento").val();

                    if (respuesta == 1) {
                        location.href = "web_15_ConsultarImplemento.aspx?consultar=Activo";


                    } else {
                        if (respuesta == 2) {

                            location.href = "web_15_ConsultarImplemento.aspx?consultar=Inactivo";

                        }

                    }


                });

                $("#id").hide();
            });

        </script>
</asp:Content>
