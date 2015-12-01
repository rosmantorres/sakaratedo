<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_VerCarrito.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_VerCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		
		    <li>
			    <a href="#">Ver Carrito</a> 
		    </li>
		</ol>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Carrito 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Productos que posees:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>

    <div class="alert alert-success alert-dismissable" style="display:none" id="prueba">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            El Articulo Deportivo se ha Eliminado Exitosamente del Carrito.
        </div>
    
    <div class="alert alert-success alert-dismissable" style="display:none" id="prueba1">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            El Pago se ha registrado Exitosamente.
        </div>
<!--TABLAS-->
     <!-- general form elements -->
    <form role="form" class="form-horizontal" method="POST">
              
              <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Inventario</h3>
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tablainventario" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:left">Foto</th>
					<th style="text-align:left">Producto</th>
					<th style="text-align:left">Precio Unitario</th>           
                    <th style="text-align:left">Cantidad</th>
                    <th style="text-align:left">Precio por Cantidad</th>
					<th style="text-align:left">Acciones</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="laTabla1"></asp:Literal>
		    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>

         <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Matricula</h3>
        </div><!-- /.box-header -->

        <div class="box-body table-responsive">
        <table id="tablamatricula" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:left">Producto</th>
					<th style="text-align:left">Precio Unitario</th>           
                    <th style="text-align:left">Cantidad</th>
                    <th style="text-align:left">Precio por Cantidad</th>
					<th style="text-align:left">Acciones</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="laTabla2"></asp:Literal>
		    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>

                <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Evento</h3>
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tablaevento" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:left">Producto</th>
					<th style="text-align:left">Precio Unitario</th>           
                    <th style="text-align:left">Cantidad</th>
                    <th style="text-align:left">Precio por Cantidad</th>
					<th style="text-align:left">Acciones</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="laTabla3"></asp:Literal>
		    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>

   <!-- M  O  D  A  L  E  S-->
       <!--MODAL PARA EL DETALLE IMPLEMENTO-->
    	<div id="modal-info1" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Producto</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row">
                                <h3>Imagen</h3>
									<h4><input type="text" id="beta" value=""/></h4>
                                <h3>Nombre</h3>
                                    <h4><input type="text" id="beta1" value="" /></h4>
								<h3>Tipo Implemento</h3>
                                    <h4><input type="text" id="beta2" value="" /></h4>
                                <h3>Marca</h3>
                                    <h4><input type="text" id="beta3" value="" /></h4>
                                <h3>Color</h3>
                                    <h4><input type="text" id="beta4" value="" /></h4>
                                <h3>Talla</h3>
                                    <h4><input type="text" id="beta5" value="" /></h4>
                                <h3>Status</h3>
                                    <h4><input type="text" id="beta6" value="" /></h4>
                                <h3>Precio</h3>
                                    <h4><input type="text" id="beta7" value="" /></h4>
                                <h3>Descripcion</h3>
                                    <h4><input type="text" id="beta8" value="" /></h4>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

        <!--MODAL PARA EL DETALLE EVENTO-->
    	<div id="modal-info2" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Evento</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info2">
							<div class="row">
                                <h3>Id</h3>
									<h4><input type="text" id="beta9" value=""/></h4>
                                <h3>Nombre</h3>
									<h4><input type="text" id="beta10" value=""/></h4>
                                <h3>Descripcion</h3>
									<h4><input type="text" id="beta11" value=""/></h4>
                                <h3>Costo</h3>
									<h4><input type="text" id="beta12" value=""/></h4>

							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
   



<!--MODAL DE PAGO-->
    <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <button id="btn-agregarComp" style="align-content:flex-end" class="btn btn-primary" type="button" data-toggle="modal" data-target="#modal-info"">Pagar</button>
          &nbsp;&nbsp
         
    </div>

   <div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Registrar Pago</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">


  <!--INFORMACION DEL MODAL PARA EL PAGO-->
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
          <div id="alert_nombre" runat="server">
         </div>
         <div id="alert_apellido" runat="server">
          </div>
          <div id="alert_username" runat="server">
          </div>
          <div id="alert_correo" runat="server">
          </div>
          <div id="alert_pregunta" runat="server">
          </div>
          <div id="alert_respuesta" runat="server">
           </div>
           <div id="alert_password" runat="server">
           </div>

        <div id="alertlocal" runat="server">
        </div>


        <h4 class="modal-title">Total: 26.096 Bs</h4>

    
         <div class="form-group">
        <!-- El form iba aqui -->
        
              
        <br />
        
            <div class="col-sm-10 col-md-10 col-lg-10">
                 <div class="dropdown" runat="server" id="div1">
                     </div>
             <%--     <asp:DropDownList ID="DropDownList1"   class="btn btn-default dropdown-toggle"   onchange="example()"  runat="server" >
                     <asp:ListItem Enabled="true" Text="Seleccione" Value="-1"></asp:ListItem>
                     <asp:ListItem Text="Tarjeta" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Deposito" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Transferencia" Value="3"></asp:ListItem>
               </asp:DropDownList>
              --%>
                 <div class="btn-group">
            
                                <select id="DropDownList1" runat="server" class="combobox" style="width:100px; height:35px" onchange="example()" >
                                <option value="-1">Seleccione</option>
                                <option value="1">Tarjeta</option>
                                <option value="2">Deposito</option>
                                <option value="3">Transferencia</option>
                                
                                  </select>
                
                                         </div>
            </div>
        </div>
        <h4 class="modal-title">Tarjeta Credito/Debito</h4>
        <div class="form-group">
	        <div id="div_usuao" class="col-sm-10 col-md-10 col-lg-10">
		        <input id="Text1" Disabled="disabled" type="text" placeholder="Numero de la Tarjeta" class="form-control" name="Text1" runat="server"/>
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_uario" class="col-sm-10 col-md-10 col-lg-10">
		        <input id="Text2" Disabled="disabled" type="text" placeholder="Nombre del Tarjeta Habiente" class="form-control" name="Text2" runat="server"/>
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_usuario" class="col-sm-10 col-md-10 col-lg-10">
		        <input id="Text3" Disabled="disabled" type="text" placeholder="Fecha de Vencimiento" class="form-control" name="Text3" runat="server"/>
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_email" class="col-sm-5 col-md-5 col-lg-5">
		        <input id="Text4" Disabled="disabled" type="password" placeholder="Codigo de Seguridad" class="form-control" name="Text4" runat="server"/>
		    </div>
	    </div>
        
        <h4 class="modal-title">Deposito Bancario</h4>

        <div class="form-group">
			<div id="div_confirm_pswd" class="col-sm-10 col-md-10 col-lg-10">
				    <input id="Text5" Disabled="disabled" type="text" placeholder="Numero del Deposito" class="form-control" name="Text5" runat="server"/>
            </div>
		</div>
       
        <div class="form-group">
			<div id="div_pregunta" class="col-sm-10 col-md-10 col-lg-10">
				<input id="Text6" Disabled="disabled" type="text" placeholder="Banco Emisor" class="form-control" name="Text6"  runat="server"/>
			</div>
		</div>

        <div class="form-group">
			<div id="div_preg" class="col-sm-5 col-md-5 col-lg-5">
				<input id="Text7" Disabled="disabled" type="text" placeholder="Monto" class="form-control" name="Text7"  runat="server"/>
			</div>
		</div>

        <h4 class="modal-title">Transferencia</h4>

        <div class="form-group">
			<div id="div_respuesta" class="col-sm-10 col-md-10 col-lg-10">
				<input id="Text8" Disabled="disabled" type="text" placeholder="Codigo de Confirmacion" class="form-control" name="Text8"  runat="server"/>
			</div>
		</div>

        <div class="form-group">
			<div id="div_respuestas" class="col-sm-10 col-md-10 col-lg-10">
				<input id="Text9" Disabled="disabled" type="text" placeholder="Banco Emisor" class="form-control" name="Text9"  runat="server"/>
			</div>
		</div>
        <div class="form-group">
			<div id="div_respuess" class="col-sm-5 col-md-5 col-lg-5">
				<input id="Text10" Disabled="disabled" type="text" placeholder="Monto" class="form-control" name="Text10"  runat="server"/>
			</div>
		</div>

         <div class="form-group">
		    <div class="box-footer">
			<%--<button id="Boton1" style="align-content:flex-end" runat="server" Disabled="disabled" class="btn btn-primary" type="button" onclick="$('#modal-info').modal('hide'); $('#prueba1').show(); $('#example').DataTable().clear().draw(); " >Registrar Pago</button>--%>
                <button id="Boton1" style="align-content:flex-end" runat="server" Disabled="disabled" class="btn btn-primary" type ="submit" onserverclick ="registrarPago">Registrar Pago</button>
                <a class="btn btn-default" href="M16_VerCarrito.aspx">Cancelar</a>
			</div>
	    </div>


    </form>
        </div>


<!--VALIDACION PARA EL MODAL DE PAGO-->
    <script src="js/Validacion.js"></script>
    <script>

        function example() {
            if ($('#<%=DropDownList1.ClientID %>').val() == -1) {

                $('#<%=Text1.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text2.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text3.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text4.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text5.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text6.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text7.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text8.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text9.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text10.ClientID %>').attr("disabled", "disabled");
                $('#<%=Text1.ClientID %>').val('');
                $('#<%=Text2.ClientID %>').val('');
                $('#<%=Text3.ClientID %>').val('');
                $('#<%=Text4.ClientID %>').val('');
                $('#<%=Text5.ClientID %>').val('');
                $('#<%=Text6.ClientID %>').val('');
                $('#<%=Text7.ClientID %>').val('');
                $('#<%=Text8.ClientID %>').val('');
                $('#<%=Text9.ClientID %>').val('');
                $('#<%=Text10.ClientID %>').val('');
            }
            else
                if ($('#<%=DropDownList1.ClientID %>').val() == 1) {
                    $('#<%=Text1.ClientID %>').attr("disabled", false);
                    $('#<%=Text2.ClientID %>').attr("disabled", false);
                    $('#<%=Text3.ClientID %>').attr("disabled", false);
                    $('#<%=Text4.ClientID %>').attr("disabled", false);

                    //Deshabilitamos los campos y limpiamos
                    $('#<%=Text5.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text6.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text7.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text8.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text9.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text10.ClientID %>').attr("disabled", "disabled");
                    $('#<%=Text5.ClientID %>').val('');
                    $('#<%=Text6.ClientID %>').val('');
                    $('#<%=Text7.ClientID %>').val('');
                    $('#<%=Text8.ClientID %>').val('');
                    $('#<%=Text9.ClientID %>').val('');
                    $('#<%=Text10.ClientID %>').val('');

                    $('#<%=Boton1.ClientID %>').attr("disabled", false);
                }

                else
                    if ($('#<%=DropDownList1.ClientID %>').val() == 2) {

                        //Deshabilitamos los campos y limpiamos
                        $('#<%=Text1.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text2.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text3.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text4.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text1.ClientID %>').val('');
                        $('#<%=Text2.ClientID %>').val('');
                        $('#<%=Text3.ClientID %>').val('');
                        $('#<%=Text4.ClientID %>').val('');

                        $('#<%=Text5.ClientID %>').attr("disabled", false);
                        $('#<%=Text6.ClientID %>').attr("disabled", false);
                        $('#<%=Text7.ClientID %>').attr("disabled", false);

                        //Deshabilitamos los campos y limpiamos
                        $('#<%=Text8.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text9.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text10.ClientID %>').attr("disabled", "disabled");
                        $('#<%=Text8.ClientID %>').val('');
                        $('#<%=Text9.ClientID %>').val('');
                        $('#<%=Text10.ClientID %>').val('');

                        $('#<%=Boton1.ClientID %>').attr("disabled", false);
                    }
                    else
                        if ($('#<%=DropDownList1.ClientID %>').val() == 3) {

                            //Deshabilitamos los campos y limpiamos
                            $('#<%=Text1.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text2.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text3.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text4.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text5.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text6.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text7.ClientID %>').attr("disabled", "disabled");
                            $('#<%=Text1.ClientID %>').val('');
                            $('#<%=Text2.ClientID %>').val('');
                            $('#<%=Text3.ClientID %>').val('');
                            $('#<%=Text4.ClientID %>').val('');
                            $('#<%=Text5.ClientID %>').val('');
                            $('#<%=Text6.ClientID %>').val('');
                            $('#<%=Text7.ClientID %>').val('');

                            $('#<%=Text8.ClientID %>').attr("disabled", false);
                            $('#<%=Text9.ClientID %>').attr("disabled", false);
                            $('#<%=Text10.ClientID %>').attr("disabled", false);
                            $('#<%=Boton1.ClientID %>').attr("disabled", false);
                        }
        }

    </script>
						</div>
					</div>
				</div>
			</div>
		</div>


    <script type="text/javascript">
        $(document).ready(function () {

            var table1 = $('#tablainventario').DataTable({
                "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                "language": {
                    "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                }
            });
            var req;
            var tr;

                    $('#tablainventario tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        req = $(this).parent().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');
                    }
                    else {
                        req = $(this).parent().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                });


                    var table2 = $('#tablamatricula').DataTable({
                    "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                    }
                });

                                $('tablamatricula tbody').on('click', 'a', function () {
                        if ($(this).parent().hasClass('selected')) {
                            req = $(this).parent().prev().prev().prev().text();
                            tr = $(this).parents('tr');//se guarda la fila seleccionada
                            $(this).parent().removeClass('selected');
                        }
                        else {
                            req = $(this).parent().prev().prev().prev().text();
                            tr = $(this).parents('tr');//se guarda la fila seleccionada
                            table.$('tr.selected').removeClass('selected');
                            $(this).parent().addClass('selected');
                        }
                    });


                                var table3 = $('#tablaevento').DataTable({
                                    "dom": '<"pull-left"f>rt<"pull-right"lp>i',
                                    "language": {
                                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                                    }
                                });

                                $('tablaevento tbody').on('click', 'a', function () {
                                    if ($(this).parent().hasClass('selected')) {
                                        req = $(this).parent().prev().prev().prev().text();
                                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                                        $(this).parent().removeClass('selected');
                                    }
                                    else {
                                        req = $(this).parent().prev().prev().prev().text();
                                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                                        table.$('tr.selected').removeClass('selected');
                                        $(this).parent().addClass('selected');
                                    }
                                });



                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                    modal.find('#req').text(req)
                })
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                    $('#prueba').show();//Muestra el mensaje de borrado exitosamente
                });


            // Carga el modal con la informacion del IMPLEMENTO de acuerdo al id
                $('#modal-info1').on('show.bs.modal', function (e) {

                    alert(e.relatedTarget.id);

                    $.ajax({
                        cache: false,
                        type: 'POST',
                        url: 'http://localhost:23072/GUI/Modulo16/M16_VerCarrito.aspx/pruebaImplemento',
                        data: "{'id':" + "'" + e.relatedTarget.id + "'" + "}",
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",

                        success: function (data) {
                            console.log(data);

                            var aa = JSON.parse(data.d);

                            console.log(aa);

                            $("#beta").val(aa.Imagen_implemento);
                            $("#beta1").val(aa.Nombre_Implemento);
                            $("#beta2").val(aa.Tipo_Implemento);
                            $("#beta3").val(aa.Marca_Implemento);
                            $("#beta4").val(aa.Color_Implemento);
                            $("#beta5").val(aa.Talla_Implemento);
                            $("#beta6").val(aa.Estatus_Implemento);
                            $("#beta7").val(aa.Precio_Implemento);
                            $("#beta8").val(aa.Descripcion_Implemento);

                        }
                    });
                })


            // Carga el modal con la informacion del EVENTO de acuerdo al id
                $('#modal-info2').on('show.bs.modal', function (e) {
                    alert(e.relatedTarget.id);
                    $.ajax({
                        cache: false,
                        type: 'POST',
                        url: 'http://localhost:23072/GUI/Modulo16/M16_VerCarrito.aspx/pruebaEvento',
                        data: "{'id':" + "'" + e.relatedTarget.id + "'" + "}",
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",

                        success: function (data) {
                            console.log(data);

                            var aa = JSON.parse(data.d);
                            console.log(aa);

                            $("#beta9").val(aa.Id_evento);
                            $("#beta10").val(aa.Nombre);
                            $("#beta11").val(aa.Descripcion);
                            $("#beta12").val(aa.Costo);

                        }
                    });
                })


           });

        </script>

</asp:Content>
