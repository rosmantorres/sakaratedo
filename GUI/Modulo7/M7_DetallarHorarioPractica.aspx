<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_DetallarHorarioPractica.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_DetallarHorarioPractica" %>
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
			    <a href="M7_ListarHorariodePractica.aspx">Consulta Horario Practica</a> 
		    </li>

		    <li class="active">
			   Consultar Horario de Práctica
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Consulta Atleta
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Detalle Horario Práctica
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
     <!-- general form elements -->
   <div class="box box-primary">
      <div class="box-header with-border">
         <h3 class="box-title">Detalle De Horario Práctica</h3>
      </div>
      <!-- /.box-header -->
      <!-- form start -->
      <form runat="server" role="form" name="detalleHorario" id="detalleHorario" method="post">
         <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
            <div class="panel-group col-sm-12 col-md-12 col-lg-12">
               <div class="panel panel-primary">
                  <div class="panel-heading">
                     <h4>Datos del Horario</h4>
                  </div>
                  <div class="panel-body">
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <br />
                        <h4>Nombre Clase:</h4>
                        <asp:Label runat="server" name="nombre_evento" id="nombre_evento" Font-Size="Large"></asp:Label>
                     </div>
                     <br/>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Descripcion :</h4>
                        <asp:Label runat="server" name="descripcion_evento" id="descripcion_evento" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Estado :</h4>
                        <asp:Label runat="server" name="estado_evento" id="estado_evento" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Hora de Inicio :</h4>
                        <asp:Label runat="server" name="horaInicio_evento" id="horaInicio_evento" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Hora que Finaliza :</h4>
                        <asp:Label runat="server" name="horaFin_evento" id="horaFin_evento" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Dirección :</h4>
                        <asp:Label runat="server" name="direccion_evento" id="direccion_evento" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="panel-group col-sm-10 col-md-10 col-lg-10">
            </div>
            <br />
            <div class="form-group col-sm-5 col-md-5 col-lg-5"> <!--BOTON VOLVER-->
            <a class="btn btn-default" href="M7_ListarHorarioDePractica.aspx">Volver</a>
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
