<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M15_AgregarImplemento.aspx.cs" Inherits="templateApp.GUI.Modulo15.M15_Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
Gestion de Inventario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
Agregar Implemento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
 <div id="alert" runat="server">
    </div>
    
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Agregar Implemento</h3>
                </div><!-- /.box-header -->

                <!-- form start -->
                <form role="form" id="agregar_implemento" method="post" action="M15_AgregarImplemento.aspx?success=1" >
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Nombre De Articulo:</b></p>
                        <input  type="text" id="nombre_articulo" name="nombre_articulo" placeholder="*nombre del articulo" class="form-control" runat="server"/>            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <p><b>Tipo Articulo:</b></p>
                        <select id="tipo_articulo" class="form-control" runat="server">
                               <option value="1" >Vestimenta</option>
                               <option value="2" >Accesorios</option>
                               <option value="3" >Otros</option>
                        </select>            
                      </div>
                      <br/>
                       <div class="form-group col-sm-10 col-md-10 col-lg-10">
                           <p><b>Cantidad:</b></p>
                           <input type="text" id="cantidad_inventario" placeholder="*cantidad" class="form-control" runat="server"/>            
                       </div>
                      <br/>
                     <div class="form-group col-sm-10 col-md-10 col-lg-10">
                        <p><b>Precio:</b></p>
                        <input type="text" id="precio_producto" placeholder="*Precio" class="form-control" runat="server"/>         
                    </div>
                      <br/>
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                          <p><b>Color:</b></p>
                         <input type="text" id="color_implemento"  placeholder="*Color" class="form-control"  runat="server"/>            
                    </div>
                      <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Marca:</b></p>
                       <input type="text" id="marca_implemento"  placeholder="*marca" class="form-control" runat="server"/>            
                    </div>
                      <br/>
                <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Talla:</b></p>
                       <input type="text" id="talla_implemento"  placeholder="*talla" class="form-control" runat="server"/>            
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Dojo:</b></p>
                             <select id="nombre_dojo" class="form-control" runat="server">
                                  <option value="1" >dojo numero1</option>
                                  <option value="2" >dojo numero2</option>
                                  <option value="3" >dojo numero3</option>
                                  <option value="4" >dojo numero4</option>
                                  <option value="5" >dojo numero5</option>
                                  <option value="6" >dojo numero6</option>
                              </select></br></br>
                                                       
                    </div>
                      <br/>
                      
                      
                         <%= Request.Form %>>
                  </div><!-- /.box-body -->

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-agregarComp" style="align-content:flex-end" class="btn btn-primary" type="submit" onclick="return checkform();">Agregar</button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M15_AgregarImplemento.aspx">Cancelar</a>
                  </div>

                </form>
              </div><!-- /.box -->
  
    
    </asp:Content>
