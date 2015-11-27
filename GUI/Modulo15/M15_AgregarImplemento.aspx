<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M15_AgregarImplemento.aspx.cs" Inherits="templateApp.GUI.Modulo15.M15_Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);"> 
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		    <li>
			    <a href="M15_ConsultarImplemento.aspx">Consultar Implemento</a> 
		    </li>		
		    <li class="active">
			    Agregar Implemento
		    </li>
	    </ol>
        <a href="M15_AgregarImplemento.aspx">M15_AgregarImplemento.aspx</a>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Gesti&oacuten de Inventario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
Agregar Implemento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <%--Alerta de falta de contenido--%>
 <div id="alert"  >
    <div id="contenido_alerta"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div>
 </div>
     <div id="alert2" runat="server">
    </div>
    <%--Fin de alerta de falta de contenido--%>

    <%--Alerta de confirmación--%>
 <div id="alert_confirmacion"  >
    <div id="Div2"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div>
 </div>    
    <%--fin de Alerta de confirmación--%>

              <!-- Elementos generales del formulario -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Agregar Implemento</h3>
                </div><!--Encabezado del formulario -->

                <!-- Comienzo del formulario -->
                <form role="form" id="agregar_implemento" method="post" action="M15_ConsultarImplemento.aspx">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Nombre De Implemento:</b></p>
                        <input  type="text" id="nombre_implemento" name="nombre_implemento" placeholder="*Nombre del Implemento" class="form-control" />            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <p><b>Tipo Implemento:</b></p>
                        <select id="tipo_implemento" name="tipo_implemento" class="form-control" >
                               <option value="Vestimenta" >Vestimenta</option>
                               <option value="Accesorios" >Accesorios</option>
                               <option value="Otros" >Otros</option>
                        </select>            
                      </div>
                      <br/>
                       <div class="form-group col-sm-10 col-md-10 col-lg-10">
                           <p><b>Cantidad:</b></p>
                           <input type="text" id="cantidad_implemento" name="cantidad_implemento" placeholder="*Cantidad" class="form-control"   />            
                       </div>
                      <br/>
                     <div class="form-group col-sm-10 col-md-10 col-lg-10">
                        <p><b>Precio (Bs):</b></p>
                        <input type="text" id="precio_implemento" name="precio_implemento" placeholder="*Precio" class="form-control"   />         
                    </div>
                      <br/>
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                          <p><b>Color:</b></p>
                         <input type="text" id="color_implemento" name="color_implemento"  placeholder="*Color" class="form-control"  />            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Marca:</b></p>
                       <input type="text" id="marca_implemento" name="marca_implemento" placeholder="*Marca" class="form-control" />            
                    </div>
                      <br/>
                <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Talla:</b></p>
                        <select id="talla_implemento" name="talla_implemento" class="form-control" >
                               <option value="1" >XS</option>
                               <option value="2" >S</option>
                               <option value="3" >M</option>
                               <option value="4" >L</option>
                               <option value="5" >XL</option>
                               <option value="6" >XXL</option>
                               <option value="7" >XXXL</option>
                        </select>            
                      </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                        <p><b>Stock M&iacutenimo</b></p>
                        <input type="text" id="stock_implemento" name="stock_implemento" placeholder="*Stock Minimo" class="form-control"/>         
                     </div>
                      <br/>
                      
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Imagen Implemento:</b></p>
                       <input type="file" id="imagen_implemento"  name="imagen_implemento" class="form-control" />            
                    </div>
                      <br/>

                       <input type="hidden" id="agregar" name="agregar" value="agregar" class="form-control"  />            
                                                  
                  </div><!--Fin del listado del formulario -->

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                <button id="btnagregar" type="submit" class="btn btn-primary"  >Agregar</button>
                                      &nbsp;&nbsp
                  
                           <a class="btn btn-default" href="M15_ConsultarImplemento.aspx" runat="server" >Cancelar</a>
                  </div>

                </form>
              </div><!-- Fin del formulario-->
 
      <!-- Declaración de las alertas-->
     <script type="text/javascript">  
      $(document).ready(function () {
          $("#alert").hide();
          $("#alert").attr("class", "alert alert-error alert-dismissible");
          $("#alert").attr("role", "alert");

          $("#alert_confirmacion").hide();
          $("#alert_confirmacion").attr("class", "alert alert-success alert-dismissible");
          $("#alert_confirmacion").attr("role", "alert");
          var valor = "";
          var estado = false;


          // Alertas de cada uno de los campos vacios y los que pertenecen a numéricos

          $("#btndfagregarComp").click(function (evento) {
              //  alert($("#nombre_implemento").val());
              if ($("#nombre_implemento").val() == "") {
                  valor = "El campo nombre implemento es obligatorio </br>";
                  estado = true;
              }
              if ($("#cantidad_inventario").val() == "") {
                  valor = valor + "El campo cantidad es obligatorio </br>";
                  estado = true;
              } else {
                  if ((isNaN($("#cantidad_inventario").val()))) {
                      valor = valor + "El campo cantidad es num&eacuterico</br>";
                      estado = true;
                  }

              }

              if ($("#precio_producto").val() == "") {
                  valor = valor + "El campo precio es obligatorio </br>";
                  estado = true;
              }
              else {
                  if ((isNaN($("#precio_producto").val()))) {
                      valor = valor + "El campo precio es num&eacuterico </br>";
                      estado = true;
                  }
              }


              if ($("#stock_implemento").val() == "") {
                  valor = valor + "El campo stock m&iacutenimo es obligatorio </br>";
                  estado = true;
              }
              else {
                  if ((isNaN($("#stock_implemento").val()))) {
                      valor = valor + "El campo stock m&iacutenimo es num&eacuterico </br>";
                      estado = true;
                  }
              }

              if ($("#color_implemento").val() == "") {
                  valor = valor + "El campo color es obligatorio </br>";
                  estado = true;
              }
              if ($("#imagen_implemento").val() == "") {
                  valor = valor + "La imagen es obligatoria </br>";
                  estado = true;
              } else {
                  if ($("#imagen_implemento").val().split(".")[1] != "jpg") {

                      valor = valor + "Se acepta solo imagenes con formato .jpg </br>";
                      estado = true;
                  }

              }
              if ($("#proveedor_implemento").val() == "") {
                  valor = valor + "El campo proveedor es obligatorio </br>";
                  estado = true;
              }
              if ($("#marca_implemento").val() == "") {
                  valor = valor + "El campo marca es obligatorio </br>";
                  estado = true;
              }
               
              //aparición de las alertas de pantalla

              if (estado) {
                  $("#alert_confirmacion").hide();
                  $("#alert").html(valor);
                  $("#alert").fadeIn(2000);
                  valor = "";
                  estado = false;
                  evento.preventDefault();

              }
           
          });

      });

  </script>
    
    </asp:Content>
