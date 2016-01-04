<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M15_ModificarImplemento.aspx.cs" Inherits="templateApp.GUI.Modulo15.WebForm2" %>
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
			    Modificar Implemento
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Gesti&oacuten de Inventario

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Modificar Implemento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
     <%--Alerta de falta de contenido--%>
 <div id="alert"  >
    <div id="contenido_alerta"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div>
 </div>
     <%--Fin de alerta de falta de contenido--%>

    <%--Alerta de confirmación--%>
 <div id="alert_confirmacion"  >
    <div id="Div2"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div>
 </div>    

    <div id="alert2" runat="server">
    </div>
       <%--fin de Alerta de confirmación--%>

    



    <script runat=server>
        public void refrescar() { 
         
            
        
        
        }     
 
    
    
     </script>

    
    
    
    
                 <!-- Elementos generales del formulario -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Modificar Implemento</h3>
                </div><!-- /.box-header -->

              <!-- Comienzo del formulario -->
                <form role="form" id="modificar_implemento"  runat="server" method="post" action="M15_ConsultarImplemento.aspx">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <input type="hidden" id="id_implemento" name="id_implemento" value="id_implemento" class="form-control" runat="server" />            

                      <p><b>Nombre De Implemento:</b></p>
                        <input  type="text" id="nombre_implemento" name ="nombre_implemento" placeholder="*Nombre del Implemento" class="form-control" value="Guante de pelea" runat="server"/>            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <p><b>Tipo Implemento:</b></p>
                        <select id="tipo_implemento"  name="tipo_implemento" class="form-control" runat="server">
                               <option value="Vestimenta" >Vestimenta</option>
                               <option selected value="Accesorios" >Accesorios</option>
                               <option value="Otros" >Otros</option>
                        </select>            
                      </div>
                      <br/>
                       <div class="form-group col-sm-10 col-md-10 col-lg-10">
                           <p><b>Cantidad:</b></p>
                           <input type="number" id="cantidad_implemento" name="cantidad_implemento" placeholder="*Cantidad" class="form-control" value="20" runat="server"/>            
                       </div>
                      <br/>
                     <div class="form-group col-sm-10 col-md-10 col-lg-10">
                        <p><b>Precio (Bs):</b></p>
                        <input type="number" id="precio_implemento" name="precio_implemento" placeholder="*Precio" class="form-control" value="1000" runat="server"/>         
                    </div>
                      <br/>
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                          <p><b>Color:</b></p>
                         <select id="color_implemento" name="color_implemento" class="form-control" runat="server">
                            <option value="AZUL" >AZUL</option>
                               <option value="VERDE" >VERDE</option>
                               <option value="AMARILLO" >AMARILLO</option>
                               <option value="ROJO" >ROJO</option>
                               <option value="NEGRO" >NEGRO</option>
                               <option value="ROSADO" >ROSADO</option>
                        </select>

                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Marca:</b></p>
                      <select id="marca_implemento" name="marca_implemento" class="form-control" runat="server">
                               <option value="ADIDAS" >ADIDAS</option>
                               <option value="ARENA" >ARENA</option>
                               <option value="PUMA" >PUMA</option>
                               <option value="NIKE" >NIKE</option>
                               <option value="KOMBA" >KOMBA</option>
                               <option value="RS21" >RS21</option>
                        </select>

                        </div>
                      <br/>
                <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Talla:</b></p>
                       <select id="talla_implemento" name="talla_implemento" class="form-control" runat="server">
                              <option value="XS" >XS</option>
                               <option value="S" >S</option>
                               <option value="M" >M</option>
                               <option value="L" >L</option>
                               <option value="XL" >XL</option>
                               <option value="XXL" >XXL</option>
                               <option value="XXXL" >XXXL</option>
                        </select>            
                      </div>
                      <br/>
                
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Stock m&iacutenimo:</b></p>
                       <input type="number" id="stock_implemento" name="stock_implemento" placeholder="*Stock m&iacutenimo" class="form-control" value="5" runat="server"/>            
                    </div>
                      <br/>
                        
                      
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Descripcion:</b></p>
                       <input type="text" id="descripcion_implemento" name="descripcion_implemento" placeholder="*Descripcion" class="form-control" value="5" runat="server"/>            
                    </div>
                      <br/>

                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Imagen Implemento:</b></p>
                       <input type="file" id="imagen_implemento" name="imagen_implemento" class="form-control" runat="server"/>            
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Estatus:</b></p>
                             <select id="estatus_implemento" name="estatus_implemento" class="form-control" runat="server">
                                  <option value="Activo" >Activo</option>
                                  <option value="Inactivo" >Inactivo</option>                                  
                              </select>
                                                       
                      </div>
                      <br/>
                      
                         
                  </div><!--Fin del listado del formulario -->
           <input type="hidden" id="modificar" name="modificar" value="modificar" class="form-control"  />            

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-agregarComp" class="btn btn-primary" type="submit" onclick="return checkform();">Modificar</button>
                    &nbsp;&nbsp
                       <a class="btn btn-default" href="M15_ConsultarImplemento.aspx">Cancelar</a>
                  </div>

                </form>
                 
              </div><!-- Fin del formulario-->
    
<script src="../../plugins/jquery_validate/dist/jquery.validate.js"></script>
<script src="../../plugins/jquery_validate/dist/jquery.validate.min.js"></script>
<script src="../../plugins/jquery_validate/dist/additional-methods.js"></script>

    <!-- Declaración de las alertas-->
  <script type="text/javascript">

      $(document).ready(function () {

          // just for the demos, avoids form submit
          jQuery.validator.setDefaults({
              debug: true,
              success: "valid"
          });
          $("#modificar_implemento").validate({
              rules: {
                  ctl00$contenidoCentral$nombre_implemento: {
                      required: true,
                      minlength: 2,
                      maxlength: 90

                  },
                  ctl00$contenidoCentral$tipo_implemento: {
                      required: true,
                      minlength: 1,
                      maxlength: 90

                  },
                  ctl00$contenidoCentral$cantidad_implemento: {
                      required: true,
                      minlength: 1,
                      maxlength: 8,
                      number: true,
                      range: [0, 99999999]
                  },
                  ctl00$contenidoCentral$precio_implemento: {
                      required: true,
                      minlength: 1,
                      maxlength: 8,
                      number: true,
                      range: [0, 99999999]
                  },
                  ctl00$contenidoCentral$color_implemento: {
                      required: true,
                      minlength: 1,
                      maxlength: 90
                  },
                  ctl00$contenidoCentral$marca_implemento: {
                      required: true,
                      minlength: 1,
                      maxlength: 90
                  },
                  ctl00$contenidoCentral$talla_implemento: {
                      required: true,
                      minlength: 1,
                      maxlength: 5
                  },
                  ctl00$contenidoCentral$stock_implemento: {
                      required: true,
                      minlength: 1,
                      maxlength: 8,
                      number: true,
                      range: [0, 99999999]
                  },
                  ctl00$contenidoCentral$descripcion_implemento: {
                      required: true,
                      minlength: 5,
                      maxlength: 120,
                  },
                  ctl00$contenidoCentral$imagen_implemento: {
                      required: true
                  },
                  ctl00$contenidoCentral$estatus_implemento: {
                      required: true
                  }
              },
              messages: {
                  ctl00$contenidoCentral$nombre_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 2 caracteres",
                      maxlength: "Maximo tiene que ser 90 caracteres"
                  },
                  ctl00$contenidoCentral$tipo_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 2 caracteres",
                      maxlength: "Maximo tiene que ser 90 caracteres"
                  },
                  ctl00$contenidoCentral$cantidad_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 1 digito",
                      maxlength: "Maximo tiene que ser 8 digitos",
                      number: "solo se aceptan numeros",
                      range: "solo se aceptan numeros mayores a 0 y menores que 99999999"

                  },
                  ctl00$contenidoCentral$precio_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 1 digito",
                      maxlength: "Maximo tiene que ser 8 digitos",
                      number: "solo se aceptan numeros",
                      range: "solo se aceptan numeros mayores a 0 y menores que 99999999"


                  },
                  ctl00$contenidoCentral$color_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 2 caracteres",
                      maxlength: "Maximo tiene que ser 90 caracteres"
                  },
                  ctl00$contenidoCentral$marca_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 2 caracteres",
                      maxlength: "Maximo tiene que ser 90 caracteres"
                  },
                  ctl00$contenidoCentral$talla_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 1 caracter",
                      maxlength: "Maximo tiene que ser 5 caracteres"
                  },
                  ctl00$contenidoCentral$stock_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 1 digito",
                      maxlength: "Maximo tiene que ser 8 digitos",
                      number: "solo se aceptan numeros",
                      range: "solo se aceptan numeros mayores a 0 y menores que 99999999"


                  },
                  ctl00$contenidoCentral$descripcion_implemento: {
                      required: "Este campo es obligatorio",
                      minlength: "Minimo tiene que ser 5 caracteres",
                      maxlength: "Maximo tiene que ser 120 caracteres"

                  },
                  ctl00$contenidoCentral$imagen_implemento: {
                      required: "La imagen es obligatoria"


                  },
                  ctl00$contenidoCentral$estatus_implemento: {
                      required: "El estatus es obligatorio"


                  }
                  

              },
              submitHandler: function (form) {
                  // some other code
                  // maybe disabling submit button
                  // then:
                  form.submit();
              }

          });



 

          $("#alert").hide();
          $("#alert").attr("class", "alert alert-error alert-dismissible");
          $("#alert").attr("role", "alert");

          $("#alert_confirmacion").hide();

          $("#alert_confirmacion").attr("class", "alert alert-success alert-dismissible");
          $("#alert_confirmacion").attr("role", "alert");
          var valor = "";
          var estado = false;

          // Alertas de cada uno de los campos vacios y los que pertenecen a numéricos

          $("#btn-agregarComp").click(function (evento) {
              //  alert($("#nombre_articulo").val());
              if ($("#nombre_articulo").val() == "") {
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

              if ($("#stock_implemento").val() == "") {
                  valor = valor + "El campo stock m&iacutenimo es obligatorio </br>";
                  estado = true;
              } else {
                  if ((isNaN($("#stock_implemento").val()))) {
                      valor = valor + "El campo stock m&iacutenimo es num&eacuterico</br>";
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