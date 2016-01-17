<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_DetalleCinta.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_DetalleCinta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">
    <%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		
		    <li>
			    <a href="M7_ConsultarCintas.aspx">Consultar Cintas</a> 
		    </li>

		    <li class="active">
			    Detallar Cinta
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Consulta de Atletas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Detalle de Cinta
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    <!-- general form elements -->
   <div class="box box-primary">
      <div class="box-header with-border">
         <h3 class="box-title">Detalle De Cinta</h3>
      </div>
      <!-- /.box-header -->
      <!-- form start -->
      <form runat="server" role="form" name="detalle_cinta" id="detalle_cinta" method="post">
         <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
            <div class="panel-group col-sm-12 col-md-12 col-lg-12">
               <div class="panel panel-primary">
                  <div class="panel-heading">
                     <h4>Datos de Cinta</h4>
                  </div>
                  <div class="panel-body">
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <br />
                         <%--<asp:Label runat="server" name="colorCinta" id="colorCinta" Font-Size="Large"></asp:Label>--%>
                         <h4 id="colorCinta1" runat="server" name="colorCinta">&nbsp;Color: </h4>
                     </div>
                     <br/>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                         <%--<asp:Label runat="server" name="rangoCinta" id="rangoCinta" Font-Size="Large"></asp:Label>--%>
                         <h4 id="rangoCinta1" runat="server" name="rangoCinta">&nbsp;Rango: </h4>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="clasificacionCinta" id="clasificacionCinta" Font-Size="Large"></asp:Label>--%>
                         <h4 id="clasificacionCinta1" runat="server" name="clasificacionCinta">&nbsp;Clasificacion: </h4>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="significadoCinta" id="significadoCinta" Font-Size="Large"></asp:Label>--%>
                         <h4 id="significadoCinta1" runat="server" name="significadoCinta">&nbsp;Significado: </h4>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <%--<asp:Label runat="server" name="ordenCinta" id="ordenCinta" Font-Size="Large"></asp:Label>--%>
                         <h4 id="ordenCinta1" runat="server" name="ordenCinta">&nbsp;Orden: </h4>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-5 col-lg-4">
                        <%--<asp:Label runat="server" name="fechaObtencionCinta" id="fechaObtencionCinta" Font-Size="Large"></asp:Label>--%>
                          <h4 id="fechaObtencionCinta1" runat="server" name="fechaObtencionCinta">&nbsp;Fecha de Obtención: </h4>
                        <br />
                     </div>
                      
            <br />
            <div class="form-group col-sm-5 col-md-5 col-lg-5"> <!--BOTON VOLVER-->
            <a class="btn btn-default" href="M7_ListarCintas.aspx">Volver</a>
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
   <!-- /.box -->
</asp:Content>
