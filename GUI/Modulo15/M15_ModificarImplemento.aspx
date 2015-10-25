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
Gestion de Inventario

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Modificar Implemento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
 <div id="alert"  >
    <div id="contenido_alerta"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button> </div>
 </div>

 <div id="alert_confirmacion"  >
    <div id="Div2"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button> </div>
 </div>    


              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Modificar Implemento</h3>
                </div><!-- /.box-header -->

                <!-- form start -->
                <form role="form" id="modificar_implemento" method="post" action="M15_ConsultarImplemento.aspx?modificar=exito">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Nombre De Implemento:</b></p>
                        <input  type="text" id="nombre_articulo" placeholder="*Nombre del Implemento" class="form-control" value="Guante de pelea"/>            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <p><b>Tipo Implemento:</b></p>
                        <select id="tipo_articulo" class="form-control">
                               <option value="1" >Vestimenta</option>
                               <option selected value="2" >Accesorios</option>
                               <option value="3" >Otros</option>
                        </select>            
                      </div>
                      <br/>
                       <div class="form-group col-sm-10 col-md-10 col-lg-10">
                           <p><b>Cantidad:</b></p>
                           <input type="text" id="cantidad_inventario" placeholder="*Cantidad" class="form-control" value="20"/>            
                       </div>
                      <br/>
                     <div class="form-group col-sm-10 col-md-10 col-lg-10">
                        <p><b>Precio (Bs):</b></p>
                        <input type="text" id="precio_producto" placeholder="*Precio" class="form-control" value="1000"/>         
                    </div>
                      <br/>
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                          <p><b>Color:</b></p>
                         <input type="text" id="color_implemento"  placeholder="*Color" class="form-control" value="Rojo"/>            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Marca:</b></p>
                       <input type="text" id="marca_implemento"  placeholder="*Marca" class="form-control" value="Kombate"/>            
                    </div>
                      <br/>
                <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Talla:</b></p>
                       <select id="Select1" class="form-control">
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
                      <p><b>Dojo:</b></p>
                             <select id="nombre_dojo" class="form-control">
                                  <option selected value="1" >el dragon verde </option>
                                  <option value="2" >dojo número2</option>
                                  <option value="3" >dojo número3</option>
                                  <option value="4" >dojo número4</option>
                                  <option value="5" >dojo número5</option>
                                  <option value="6" >dojo número6</option>
                              </select>
                                                       
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Proveedor:</b></p>
                       <input type="text" id="proveedor_implemento"  placeholder="*Proveedor" class="form-control" value="Shirido"/>            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Imagen Implemento:</b></p>
                       <input type="file" id="imagen_implemento"  class="form-control"/>            
                    </div>
                      <br/>
                      
                      
                         
                  </div><!-- /.box-body -->

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-agregarComp" style="align-content:flex-end" class="btn btn-primary" type="submit" onclick="return checkform();">Modificar</button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M15_ConsultarImplemento.aspx">Cancelar</a>
                  </div>

                </form>
              </div><!-- /.box -->
    
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
                      valor = valor + "El campo cantidad es numérico</br>";
                      estado = true;
                  }

              }

              if ($("#precio_producto").val() == "") {
                  valor = valor + "El campo precio es obligatorio </br>";
                  estado = true;
              }
              else {
                  if ((isNaN($("#precio_producto").val()))) {
                      valor = valor + "El campo precio es numérico";
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
              }
              if ($("#proveedor_implemento").val() == "") {
                  valor = valor + "El campo proveedor es obligatorio </br>";
                  estado = true;
              }
              if ($("#marca_implemento").val() == "") {
                  valor = valor + "El campo marca es obligatorio </br>";
                  estado = true;
              }

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