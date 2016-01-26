<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarOrganizacionYDojo.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarOrganizacionYDojo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">
    <%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>

		    <li class="active">
			    Consultar Organizacion y Dojo
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Consulta de Atleta
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Consulta Perfil
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    <!-- general form elements -->
   <div class="box box-primary">
      <div class="box-header with-border">
         <h3 class="box-title">Datos del Atleta</h3>
      </div>
      <!-- /.box-header -->
      <!-- form start -->
      <form runat="server" role="form" name="detalle_Persona" id="detalle_Persona" method="post">
         <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
            <div class="panel-group col-sm-12 col-md-12 col-lg-12">
               <div class="panel panel-primary">
                  <div class="panel-heading">
                     <h4>Información</h4>
                  </div>
                  <div class="panel-body">
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <br />
                        <%--<asp:Label runat="server" name="nombrePersona" id="nombrePersona" Text="" Font-Size="Large"></asp:Label>--%>
                         <h4 id="nombrePersona1" runat="server" name="nombrePersona">&nbsp;Nombre: </h4>
                     </div>
                     <br/>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="ApellidoPersona" id="apellidoPersona" Font-Size="Large"></asp:Label>--%>
                         <h4 id="apellidoPersona1" runat="server" name="apellidoPersona">&nbsp;Apellido: </h4>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="fechaNacimiento" id="fechaNacimiento" Font-Size="Large"></asp:Label>--%>
                         <h4 id="fechaNacimiento1" runat="server" name="fechaNacimiento">&nbsp;Fecha de Nacimiento: </h4>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="direccion" id="direccion" Font-Size="Large"></asp:Label>--%>
                         <h4 id="direccion1" runat="server" name="direccion">&nbsp;Dirección: </h4>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="nombreDojo" id="nombreDojo" Font-Size="Large"></asp:Label>--%>
                         <h4 id="nombreDojo1" runat="server" name="nombreDojo">&nbsp;Dojo al que pertenece: </h4>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="telefonoDojo" id="telefonoDojo" Font-Size="Large"></asp:Label>--%>
                          <h4 id="telefonoDojo1" runat="server" name="telefonoDojo">&nbsp;Teléfono del Dojo: </h4>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="emailDojo" id="emailDojo" Font-Size="Large"></asp:Label>--%>
                          <h4 id="emailDojo1" runat="server" name="emailDojo">&nbsp;Email del Dojo: </h4>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="ubicacionDojo" id="ubicacionDojo" Font-Size="Large"></asp:Label>--%>
                          <h4 id="ubicacionDojo1" runat="server" name="ubicacionDojo">&nbsp;Ubicación del Dojo: </h4>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="nombreOrganizacion" id="nombreOrganizacion" Font-Size="Large"></asp:Label>--%>
                          <h4 id="nombreOrganizacion1" runat="server" name="nombreOrganizacion">&nbsp;Organización: </h4>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="emailOrganizacion" id="emailOrganizacion" Font-Size="Large"></asp:Label>--%>
                          <h4 id="emailOrganizacion1" runat="server" name="emailOrganizacion">&nbsp;Email Organización: </h4>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="ubicacionOrganizacion" id="ubicacionOrganizacion" Font-Size="Large"></asp:Label>--%>
                          <h4 id="ubicacionOrganizacion1" runat="server" name="ubicacionOrganizacion">&nbsp;Ubicación Organización: </h4>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="cintaActual" id="cintaActual" Font-Size="Large"></asp:Label>--%>
                          <h4 id="cintaActual1" runat="server" name="cintaActual">&nbsp;Cinta Actual: </h4>
                        <br />
                     </div>
                      <div class="panel-group col-sm-10 col-md-10 col-lg-10">
            </div>
            <br />
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
   <!-- /.box -->
</asp:Content>
