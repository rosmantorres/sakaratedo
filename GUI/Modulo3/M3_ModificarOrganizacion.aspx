<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M3_ModificarOrganizacion.aspx.cs" Inherits="templateApp.GUI.Modulo3.M3_ModificarOrganizacion" %>
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
			    Modificar Organización
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Organización
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Modificar Organización
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">



        <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Modificar Organización</h3>
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
                      <p><b>Estado:</b></p>
                      <input type="text" name="estadoOrg" id="estadoContacto" placeholder="Estado" class="form-control" value="Estado">
                    </div>
                      <br/>
                      <br/>
                  <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 1-->
                      <div class="col-sm-3 col-md-3 col-lg-3">
                         <label>Técnica:</label>  
                      </div>
                      <div class="col-sm-8 col-md-8 col-lg-8" >
                         <div class="btn-group">
                            <button id="tecnica" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                            Karate<span class="caret"></span>
                            </button>
                            <ol id="dp4" class="dropdown-menu" role="menu"  onclick="cargartecnica();">
                               <li value="1"><a href="#">Técnica 1</a></li>
                               <li value="2"><a href="#">Técnica 2</a></li>
                               <li value="1"><a href="#">Técnica 3</a></li>
                               <li value="2"><a href="#">Técnica 4</a></li>
                               <li value="1"><a href="#">Técnica 5</a></li>
                            </ol>
                         </div>
                         </div>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                                     <h3>Orden de Cintas</h3>
                                     <select multiple="multiple" name="org_primary" size="4" class="form-control select select-primary select-block mbl">
                                     <option>Color A</option>
                                     <option>Color B</option>
                                     <option>Color F</option>
                                     <option>Color C</option>
                                     <option>Color B</option>
                                     <option>Color Z</option>
                                     </select>
                                     <br />
                                        <div class="text-center padding-small">
                                        <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-down" onclick="agregarCinta()"></button>
                                        <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-up" onclick="eliminarCinta()"></button>
                                        </div>
                                    <h3>Cintas seleccionadas</h3>
                                    <select multiple="multiple" name="org_secondary" size="4" class="form-control select select-primary select-block mbl"></select>
                        <br />
                        </div>
                      </div>
                  </div>       
                      
                  <!-- /.box-body -->

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-agregarOrganizacion" style="align-content:flex-end" class="btn btn-primary" type="submit" onclick="alertModificarOrganizacion();">Modificar</button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M3_ListarOrganizacion.aspx">Cancelar</a>
                  </div>

                </form>
              </div>
    
    <!-- /.box -->
</asp:Content>
