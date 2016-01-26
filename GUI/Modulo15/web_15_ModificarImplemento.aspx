<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="web_15_ModificarImplemento.aspx.cs" Inherits="templateApp.GUI.Modulo15.web_15_ModificarImplemento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

         <%--Alerta de falta de contenido--%>
 <div id="alert" runat="server" >
 </div>
     <%--Fin de alerta de falta de contenido--%>

    <%--Alerta de confirmación--%>
 <div id="alert_confirmacion"  >
</div>    

    <div id="alert2" runat="server">
    </div>
       <%--fin de Alerta de confirmación--%>

                 <!-- Elementos generales del formulario -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Modificar Implemento</h3>
                </div><!-- /.box-header -->

              <!-- Comienzo del formulario -->
                <form role="form" id="modificar_implemento"  runat="server">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <input type="hidden" id="id_implemento" name="id_implemento"  class="form-control" runat="server" />            

                      <p><b>Nombre De Implemento:</b></p>
                        <input  type="text" id="nombre_implemento" name ="nombre_implemento" placeholder="*Nombre del Implemento" class="form-control" value="Guante de pelea" runat="server"/>            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <p><b>Tipo Implemento:</b></p>
                        <select id="tipo_implemento"  name="tipo_implemento" class="form-control" runat="server">
                               <option value="Vestimenta" >Vestimenta</option>
                               <option selected value="Accesorios" >Accesorios</option>
                               <option value="otros" >Otros</option>
                        </select>           
                      </div>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                          <input id="tipo_implemento_div" name="tipo_implemento_div"  placeholder="*tipo" class="form-control"  runat="server"/>             
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
                                                            <option value="otros" >Otros</option>

                        </select>
                      
                    </div>
                              <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <input id="color_impolemento_div"  placeholder="*color" class="form-control"  runat="server"/>             
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
                                <option value="otros" >Otros</option>

                        </select>
                              
                      </div>
                       <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <input id="marca_implemento_div"  placeholder="*marca" class="form-control"  runat="server"/>       

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
                               <option value="otros" >Otros</option>

                        </select>            

                      </div>
                            <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <input id="talla_implemento_div"  placeholder="*talla" class="form-control"  runat="server"/>             
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
                    <img id="imagen_img" src="" alt="Smiley face" height="80" width="80" runat="server">

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

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <asp:Button class="btn btn-default" ID="Modificar" runat="server" Text="Modificar" />
                    &nbsp;&nbsp
                       <a class="btn btn-default" href="web_15_ConsultarImplemento.aspx">Cancelar</a>
                  </div>

                </form>
                 
              </div><!-- Fin del formulario-->
          <!-- Declaración de las alertas-->
    <script src="../../plugins/jquery_validate/dist/jquery.validate.js"></script>
<script src="../../plugins/jquery_validate/dist/jquery.validate.min.js"></script>
<script src="../../plugins/jquery_validate/dist/additional-methods.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             // alert("prueba");


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
                         number: true
                     },
                     ctl00$contenidoCentral$precio_implemento: {
                         required: true,
                         minlength: 1,
                         maxlength: 8,
                         number: true
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
                         number: true
                     },
                     ctl00$contenidoCentral$descripcion_implemento: {
                         required: true,
                         minlength: 5,
                         maxlength: 120,
                     },
                     ctl00$contenidoCentral$tipo_implemento_div: {
                         required: true,
                         minlength: 3,
                         maxlength: 120,
                     },
                     ctl00$contenidoCentral$marca_implemento_div: {
                         required: true,
                         minlength: 3,
                         maxlength: 120,
                     },
                     ctl00$contenidoCentral$color_implemento_div: {
                         required: true,
                         minlength: 3,
                         maxlength: 120,
                     },
                     ctl00$contenidoCentral$talla_implemento_div: {
                         required: true,
                         minlength: 1,
                         maxlength: 3,
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
                         minlength: "Minimo tiene que ser 1 caracteres",
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
                     ctl00$contenidoCentral$tipo_implemento_div: {
                         required: "Este campo es obligatorio",
                         minlength: "Minimo tiene que ser 3 caracteres",
                         maxlength: "Maximo tiene que ser 120 caracteres"

                     },
                     ctl00$contenidoCentral$marca_implemento_div: {
                         required: "Este campo es obligatorio",
                         minlength: "Minimo tiene que ser 3 caracteres",
                         maxlength: "Maximo tiene que ser 120 caracteres"

                     },
                     ctl00$contenidoCentral$color_implemento_div: {
                         required: "Este campo es obligatorio",
                         minlength: "Minimo tiene que ser 3 caracteres",
                         maxlength: "Maximo tiene que ser 120 caracteres"

                     },
                     ctl00$contenidoCentral$talla_implemento_div: {
                         required: "Este campo es obligatorio",
                         minlength: "Minimo tiene que ser 1 caracteres",
                         maxlength: "Maximo tiene que ser 3 caracteres"

                     }



                 },
                 submitHandler: function (form) {
                     // some other code
                     // maybe disabling submit button
                     // then:
                     form.submit();
                 }

             });



             // talla implemento
             $("#contenidoCentral_talla_implemento").change(function () {
                 // alert("hola");
                 if ($("#contenidoCentral_talla_implemento").val() == "otros") {
                     $("#contenidoCentral_talla_implemento_div").show();
                 } else {
                     $("#contenidoCentral_talla_implemento_div").hide();
                     $("#contenidoCentral_talla_implemento_div").val("prueba");
                     $("#contenidoCentral_talla_implemento_div-error").text("");

                 }

             });


             // tipo implemento
             $("#contenidoCentral_tipo_implemento").change(function () {
                 // alert("hola");
                 if ($("#contenidoCentral_tipo_implemento").val() == "otros") {
                     $("#contenidoCentral_tipo_implemento_div").val("");
                     $("#contenidoCentral_tipo_implemento_div").show();

                 } else {
                     $("#contenidoCentral_tipo_implemento_div").hide();
                     $("#contenidoCentral_tipo_implemento_div").val("prueba");
                     $("#contenidoCentral_tipo_implemento_div-error").text("");
                 }

             });


             // color implemento
             $("#contenidoCentral_color_implemento").change(function () {
                 // alert("hola");
                 if ($("#contenidoCentral_color_implemento").val() == "otros") {
                     $("#contenidoCentral_color_implemento_div").show();
                 } else {
                     $("#contenidoCentral_color_implemento_div").hide();
                     $("#contenidoCentral_color_implemento_div").val("prueba");
                     $("#contenidoCentral_color_implemento_div-error").text("");

                 }

             });


             // talla marca
             $("#contenidoCentral_marca_implemento").change(function () {
                 // alert("hola");
                 if ($("#contenidoCentral_marca_implemento").val() == "otros") {
                     $("#contenidoCentral_marca_implemento_div").show();
                 } else {
                     $("#contenidoCentral_marca_implemento_div").hide();
                     $("#contenidoCentral_marca_implemento_div").val("prueba");
                     $("#contenidoCentral_marca_implemento_div-error").text("");

                 }

             });


         });
    </script>

</asp:Content>
