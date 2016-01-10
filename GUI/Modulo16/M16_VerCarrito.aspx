﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_VerCarrito.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_VerCarrito" %>
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
     <form id="form1" runat="server">
              
              <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Inventario</h3>
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
       <asp:Table ID="TablaImplemento" runat="server" CssClass="table table-bordered table-striped dataTable">
           <asp:TableHeaderRow>
               <asp:TableHeaderCell>
                   Producto
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Precio
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Cantidad
               </asp:TableHeaderCell>               
               <asp:TableHeaderCell>
                   Acciones
               </asp:TableHeaderCell>
           </asp:TableHeaderRow>           
         </asp:Table>
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
       <asp:Table ID="TablaMatricula" runat="server" CssClass="table table-bordered table-striped dataTable">
           <asp:TableHeaderRow>
               <asp:TableHeaderCell>
                   Producto
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Precio
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Cantidad
               </asp:TableHeaderCell>               
               <asp:TableHeaderCell>
                   Acciones
               </asp:TableHeaderCell>
           </asp:TableHeaderRow>           
         </asp:Table>
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
       <asp:Table ID="TablaEvento" runat="server" CssClass="table table-bordered table-striped dataTable">
           <asp:TableHeaderRow>
               <asp:TableHeaderCell>
                   Producto
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Precio
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Cantidad
               </asp:TableHeaderCell>               
               <asp:TableHeaderCell>
                   Acciones
               </asp:TableHeaderCell>
           </asp:TableHeaderRow>           
         </asp:Table>
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
									<img src="" id="beta" />
                                   
                                <h3>Nombre</h3>
                                    <label id="aux1" ></label>
                                    
								<h3>Tipo Implemento</h3>
                                    <label id="aux2" ></label>
                                    
                                <h3>Marca</h3>
                                    <label id="aux3" ></label>
                                   
                                <h3>Color</h3>
                                    <label id="aux4" ></label>
                                    
                                <h3>Talla</h3>
                                    <label id="aux5" ></label>
                                    
                                <h3>Status</h3>
                                    <label id="aux6" ></label>
                                    
                                <h3>Precio</h3>
                                    <label id="aux7" ></label>
                                    
                                <h3>Descripcion</h3>
                                    <label id="aux8" ></label>
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
                                    <label id="aux9" ></label>
                                <h3>Nombre</h3>
									 <label id="aux10" ></label>
                                <h3>Descripcion</h3>
									 <label id="aux11" ></label>
                                <h3>Costo</h3>
									 <label id="aux12" ></label>

							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

    <!--BOTON DE PAGAR-->
    <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <button id="btn-agregarComp" style="align-content:flex-end" class="btn btn-primary" type="button" data-toggle="modal" data-target="#modal-info"">Pagar</button>
          &nbsp;&nbsp        
    </div>

   <!--MODAL DE PAGO-->
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

        <%-- <h4 class="modal-title" id ="preciofinal"></h4> --%>
        <br />
        <div class="form-group">
            <!-- El form iba aqui -->             
             <div class="col-sm-10 col-md-10 col-lg-10">
                 <div class="dropdown" runat="server" id="div1">
                     </div>
            
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
        <br />
     <%--  <h4 class="modal-title">Tarjeta Credito/Debito</h4>
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
		</div>--%>
         <div class="form-group">
		    <div class="box-footer">			
                <asp:Button ID="BotonPagar" runat="server" Text="Procesar Pago" disabled="true" OnClick ="RegistrarPago" class="btn btn-primary" style="align-content:flex-end"/>
                <a class="btn btn-default" href="M16_VerCarrito.aspx">Cancelar</a>
			</div>
	    </div>
        </div>
					</div>
				</div>
			</div>
		</div>
       </div>

     </form>      

<!--VALIDACION PARA EL MODAL DE PAGO-->
    <script type="text/javascript">
        debugger;

        //Funcion que activa el boton si el valor seleccionado es diferente de -1, sino, lo desactiva
        function example() {
            if ($('#<%=DropDownList1.ClientID %>').val() == -1) {

                $('#<%=BotonPagar.ClientID %>').attr("disabled", true);
            }
            else
                $('#<%=BotonPagar.ClientID %>').attr("disabled", false);
        }

        $(document).ready(function () {

            // Carga el modal con la informacion del IMPLEMENTO de acuerdo al id
            $('#modal-info1').on('show.bs.modal', function (e) {
            });

            // Carga el modal con la informacion del EVENTO de acuerdo al id
            $('#modal-info2').on('show.bs.modal', function (e) {
            });           
        });
    </script>
</asp:Content>
