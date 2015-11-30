<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarOrganizacionYDojo.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarOrganizacionYDojo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		    <li class="active">
			   Consultar Organización y Dojo
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Organización y Dojo</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Organización y dojo al que pertenece actualmente</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

 <div class="row">
            <div class="col-xs-12">
              <div class="box">
                </div><!-- /.box-header -->

    <div class="box-body table-responsive">
						<div class="container-fluid" id="info">
 <!-- general form elements -->
   <div class="box box-primary">
      <div class="box-header with-border">
         <h3 class="box-title">Detalle De Competencia</h3>
      </div>
      <!-- /.box-header -->
      <!-- form start -->
     <form runat="server" role="form" name="detalle_competencia" id="detalle_competencia" method="post">
		 <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
            <div class="panel-group col-sm-12 col-md-12 col-lg-12">
               <div class="panel panel-primary">
                  <div class="panel-heading">
                     <h4>Datos del Atleta</h4>
                  </div>
                  <div class="panel-body">
                      <br/>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                         <br />
                        <h4>Nombre :</h4>
                        <asp:Label runat="server" name="nombreAtleta" id="nombreAtleta" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Apellido :</h4>
                        <asp:Label runat="server" name="apellidoAtleta" id="apellidoAtleta" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                       <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Fecha de Nacimiento :</h4>
                        <asp:Label runat="server" name="fechaNac" id="fechaNac" Font-Size="Large"></asp:Label>
                         </div>
                        <br />
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Direccion :</h4>
                        <asp:Label runat="server" name="direccion" id="direccion" Font-Size="Large"></asp:Label>
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Dojo al que pertenece:</h4>
                        <asp:Label runat="server" name="dojo" id="dojo" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Teléfono Dojo :</h4>
                        <asp:Label runat="server" name="dojoTlf" id="dojoTlf" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                    <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Email Dojo :</h4>
                        <asp:Label runat="server" name="dojoEmail" id="dojoEmail" Font-Size="Large"></asp:Label>
                        <br />
                    <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Ubicacion Dojo :</h4>
                        <asp:Label runat="server" name="dojoUbicacion" id="dojoUbicacion" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Organizacion :</h4>
                        <asp:Label runat="server" name="organizacion" id="organizacion" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4> Teléfono Organizacion :</h4>
                        <asp:Label runat="server" name="organizacionTlf" id="organizacionTlf" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4> Email Organizacion :</h4>
                        <asp:Label runat="server" name="organizacionEmail" id="organizacionEmail" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4> Ubicacion Organizacion :</h4>
                        <asp:Label runat="server" name="organizacionUbica" id="organizacionUbica" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                    </div>
                  </div>
                 </div>
               </div>        
          <!-- /.box-body -->
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <div class="box-footer">
         </div>
         </form>
       </div>
      </div>
     </div>
	</div>
    </asp:Content>
