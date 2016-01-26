<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_AgregarDojo.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_AgregarDojo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="M4_js/M4_Alert.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Dojo</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Dojo</a> 
		    </li>
		
		    <li class="active">
			    Agregar Dojo
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Dojos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Dojo
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Nuevo Dojo</h3>
                </div><!-- /.box-header -->

                <!-- form start -->
                <form role="form" name="agregar_dojo" id="agregar_dojo" method="post" action="../Modulo6/M6_NuevoAdmin.aspx">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                      
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                    <img src="Imagenes\Aikido.png" class="img-thumbnail" alt="Logo Dojo" width="200" height="100" style="margin: 5px 900px 5px 5px;float: left; " > 
                        <input id="input-1a" type="file" class="file"  >
                    </div>
                      <br/>
                   <div class="form-group col-sm-10 col-md-10 col-lg-10">
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
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Email:</b></p>
                      <input type="email" name="emailDojo" id="emailDojo" placeholder="Email" class="form-control">
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
                      <div id="googleMap" style="width:500px;height:250px;"></div><br/>
                    </div>
                      <br/>
             
                   <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Estilo:</b></p>
                      <input type="text" name="estiloDojo" id="estiloDojo" class="form-control" readonly="readonly" value="Estilo 1">
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Reglamento Interno:</b></p>
                      <textarea class="form-control" id="reglaDojo" name="reglaDojo" placeholder="1. Regla1"></textarea>
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Status:</b></p>
                     <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox"  data-toggle="toggle" data-on="Activo" data-off="Inactivo">
                        </a>
                    </div>
                  </div><!-- /.box-body -->

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-agregarDojo" style="align-content:flex-end" class="btn btn-primary" type="submit" 
                        onclick="alertAgregarDojo();">Agregar</button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M4_ListarDojos.aspx">Cancelar</a>
                  </div>
                                   
                </form>
              </div>
 
    
    
    <!-- /.box -->
</asp:Content>
