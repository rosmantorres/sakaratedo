<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_ModificarDojo.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_AgregarDojo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Administración de Dojos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Modificar Dojo
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Editando Dojo</h3>
                </div><!-- /.box-header -->

                <!-- form start -->
                <form role="form" name="agregar_dojo" id="agregar_dojo" method="post" action="M4_ListarDojos.aspx?success=1">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">

 <div>
  <label class="box-title">Imagen Actual:</label>
<img src="Dojoico.png" class="img-thumbnail" alt="Logo Dojo" width="200" height="100" style="margin: 5px 900px 5px 5px;float: left; " > 
 
 <input id="input-1a" type="file" class="file"  >
 </div>



                      <p><b>Rif Del Dojo:</b></p>
                      <input type="text" name="rifDojo" id="rifDojo" placeholder="RIF" class="form-control">
                    </div>
                      <br/>
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Nombre Del Dojo:</b></p>
                      <input type="text" name="nombreDojo" id="nombreDojo" placeholder="Nombre" class="form-control">
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Número Telefónico:</b></p>
                      <input type="text" name="numeroDojo" id="numeroDojo" placeholder="Número" class="form-control">
                    </div>
                      <br/>
                  <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 1-->
                      <div class="col-sm-3 col-md-3 col-lg-3">
                         <label>País:</label>  
                      </div>
                      <div class="col-sm-8 col-md-8 col-lg-8" >
                         <div class="btn-group">
                            <button id="pais" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Selecionar...<span class="caret"></span>
                            </button>
                            <ol id="dp4" class="dropdown-menu" role="menu"  onclick="cargarestado();">
                               <li value="1"><a href="#">País 1</a></li>
                               <li value="2"><a href="#">País 2</a></li>
                               <li value="1"><a href="#">País 3</a></li>
                               <li value="2"><a href="#">País 4</a></li>
                               <li value="1"><a href="#">País 5</a></li>
                               <li value="2"><a href="#">País 6</a></li>
                            </ol>
                         </div>
                      </div>
                  </div>
                <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 2-->
                      <div class="col-sm-3 col-md-3 col-lg-3">
                         <label>Estado:</label>  
                      </div>
                      <div class="col-sm-8 col-md-8 col-lg-8" >
                         <div class="btn-group">
                            <button id="estado" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Selecionar...<span class="caret"></span>
                            </button>
                            <ol id="dp5" class="dropdown-menu" role="menu"  onclick="cargarciudad();">
                               <li value="1"><a href="#">Estado 1</a></li>
                               <li value="2"><a href="#">Estado 2</a></li>
                               <li value="1"><a href="#">Estado 3</a></li>
                               <li value="2"><a href="#">Estado 4</a></li>
                            </ol>
                         </div>
                      </div>
                  </div>
                 <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 3-->
                      <div class="col-sm-3 col-md-3 col-lg-3">
                         <label>Ciudad:</label>  
                      </div>
                      <div class="col-sm-8 col-md-8 col-lg-8" >
                         <div class="btn-group">
                            <button id="ciudad" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Selecionar...<span class="caret"></span>
                            </button>
                            <ol id="dp6" class="dropdown-menu" role="menu">
                               <li value="1"><a href="#">Ciudad 1</a></li>
                               <li value="2"><a href="#">Ciudad 2</a></li>
                               <li value="1"><a href="#">Ciudad 3</a></li>
                               <li value="2"><a href="#">Ciudad 4</a></li>
                            </ol>
                         </div>
                      </div>
                  </div>
                <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Dirección:</b></p>
                      <input type="text" name="direccionDojo" id="direccionDojo" placeholder="Av/Calle/Sector/Urb/Piso/NºHabitación" class="form-control">
                    </div>
                      <br/>
                <div class="form-group">
                    <div class="col-sm-10 col-md-10 col-lg-10">
                        <p><b>Modificar Administrador:</b></p>
                        <label class="radio-inline">
                        <input type="radio" name="radioTipo" checked="checked" id="input_nuevo"  onclick="return fillCodigoTextField();"/>Nuevo</label>
                        <label class="radio-inline">
                        <input type="radio" name="radioTipo" id="input_existente" onclick="return fillCodigoTextField();" />Existente</label>
                    </div>
                </div>
                   <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Estilo:</b></p>
                      <input type="text" name="estiloDojo" id="estiloDojo" class="form-control" readonly="readonly" value="Estilo 1">
                    </div>
                      <br/>
                  </div><!-- /.box-body -->

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-agregarDojo" style="align-content:flex-end" class="btn btn-primary" type="submit" onclick="return checkform();">Modificar</button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M4_ListarDojos.aspx">Volver</a>
                  </div>

                </form>
              </div><!-- /.box -->
</asp:Content>
