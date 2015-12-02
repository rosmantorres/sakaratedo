﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M3_AgregarOrganizacion.aspx.cs" Inherits="templateApp.GUI.Modulo3.M3_AgregarOrganizacion" %>
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
			    <a href="#">Organizacion</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Organizaciones</a> 
		    </li>

		    <li>
			    <a href="../Modulo3/M3_ListarOrganizacion.aspx">Listar Organizaciones</a> 
		    </li>
		    
            <li class="active">
			    Agregar Organización
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Organización
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Organización
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">



        <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Nueva Organización</h3>
                </div><!-- /.box-header -->

                <!-- form start -->
                <form role="form" name="modificar_organizacion" id="modificar_organizacion" method="post" action="M3_ListarOrganizacion.aspx?success=1">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">                   
                      <br/>
                      <div class="box-body col-sm-10 col-md-10 col-lg-10 ">
                      <p><b>* Nombre de la Organización:</b></p>
                      <input type="text" name="nombreOrg" id="nombreOrg" placeholder="Nombre" class="form-control" value="Karate">
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>* Email:</b></p>
                      <input type="email" name="emailOrg" id="emailOrg" placeholder="Email" class="form-control" value="Aikido@Org.com">
                    </div>     
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>* Número Telefónico:</b></p>
                      <input type="text" name="numeroOrg" id="numeroOrg" placeholder="Número" class="form-control" value="55-4567899">
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Direccion:</b></p>
                      <input type="text" name="direccionOrg" id="direccionOrg" placeholder="Direccion" class="form-control" value="Direccion">
                    </div>


                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                       
                           <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 1-->
                      <div class="col-sm-3 col-md-3 col-lg-3">
                         <label>* Estado:</label>  
                      </div>
                      <div class="col-sm-8 col-md-8 col-lg-8" >
                         <div class="btn-group">
                            <button id="estado" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Seleccionar<span class="caret"></span>
                            </button>
                            <ol id="dp4" class="dropdown-menu" role="menu"  onclick="cargartecnica();">
                               <li value="1"><a href="#">Distrito Federal</a></li>
                               <li value="2"><a href="#">Falcon</a></li>
                               <li value="1"><a href="#">Carabobo</a></li>
                               <li value="1"><a href="#">Zulia</a></li>
                               <li value="1"><a href="#">Guarico</a></li>


                            </ol>  
                         </div>                  
                      </div>
                      <br/>     
                  


                        <br/>
                        <br/>
                       
                  </div>  
                      
                     </div>



                      <br/>
                      <br/>
                  <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 1-->
                      <div class="col-sm-3 col-md-3 col-lg-3">
                         <label>* Técnica:</label>  
                      </div>
                      <div class="col-sm-8 col-md-8 col-lg-8" >
                         <div class="btn-group">
                            <button id="tecnica" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Seleccionar<span class="caret"></span>
                            </button>
                            <ol id="dp4" class="dropdown-menu" role="menu"  onclick="cargartecnica();">
                              <li value="1"><a href="#">Cobra-do</a></li>
                               <li value="2"><a href="#">Sistema libre de Karate</a></li>
                               <li value="1"><a href="#">Shotokan</a></li>

                            </ol>  
                         </div>                  
                      </div>
                      <br/>     
                  


                        <br/>
                        <br/>
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                                <p><b>* Campos obligatorios</b></p>            
                        </div>
                  </div>       
                   </div>   
                  <!-- /.box-body -->

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                        
                    <asp:Button id="btnagregarOrganizacion" class="btn btn-primary" type="submit" runat="server" onclick="alertModificarOrganizacion();" Text="Agregar"></asp:Button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M3_ListarOrganizacion.aspx">Cancelar</a>
                  </div>
                   
                </form>
              </div>
    
    <!-- /.box -->
</asp:Content>

