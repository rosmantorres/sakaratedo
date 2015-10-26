<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_SolicitudPlanilla.aspx.cs" Inherits="templateApp.GUI.Modulo14.SolicitudPlanilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Solicitar planillas</a>
		    </li>

		    <li class="active">
			    Solicitud de Planilla
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Solicitud Planilla</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
   <!-- general form elements -->
  <div class="box-header with-border">
   <h3 class="box-title">Solicitud de Planilla</h3>
  </div>
  <!-- /.box-header -->
  <!-- form start -->
  <form role="form" name="solicitud_planilla" id="solicitud_planilla" method="post" action="M14_SolicitudPlanilla.aspx?success=1">
   <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
       <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
         <div id="alertlocal" runat="server">
          <!-- Alertas-->
          </div>
                  <div class="col-sm-3 col-md-3 col-lg-3">
                      <label>Fecha retiro:</label>
                  </div>     
                  <div class="col-sm-8 col-md-8 col-lg-8">
                      
                      <input type="date" ID="id_fechai" Class="form-control"   runat="server"/>    
                  </div>
      </div>
     <div class="form-group col-sm-12 col-md-12 col-lg-12">
                  <div class="col-sm-3 col-md-3 col-lg-3">
                      <label>Fecha reincorporación:</label>
                  </div>     
                  <div class="col-sm-8 col-md-8 col-lg-8">
                       <input type="date" ID="Id_fechaf" Class="form-control" runat="server"/>   </div>           
                  </div>
     <div class="form-group col-sm-12 col-md-12 col-lg-12">
                  <div class="col-sm-3 col-md-3 col-lg-3">
                      <label>Motivo:</label>
                  </div>     
                  <div class="col-sm-8 col-md-8 col-lg-8">
                       <input type="text" ID="Date1" Class="form-control" runat="server"/>   </div>     
                  </div>
 
 </div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-agregarComp" class="btn btn-primary" type="submit" href="M14_ConsultarPlanillas.aspx?eliminacionSuccess=1" onclick="return checkform();">Aceptar</a>
        &nbsp;&nbsp
         <a class="btn btn-default" href="M14_SolicitarPlanilla.aspx">Cancelar</a>
      </div>
   </form>

<!-- /.box -->

 </asp:Content>