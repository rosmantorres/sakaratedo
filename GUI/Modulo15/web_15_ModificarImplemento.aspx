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
 <div id="alert"  >
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
    
</asp:Content>
