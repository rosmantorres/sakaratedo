<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M9_AgregarEventos.aspx.cs" Inherits="templateApp.GUI.Modulo9.M9_AgregarEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
		<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Eventos y Competencias</a> 
		    </li>
            		    <li>
			    <a href="#">Gesti&oacute;n de Eventos</a> 
		    </li>
		
		    <li class="active">
			    <a href="#">Agregar Evento</a> 
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gesti&oacute;n de Eventos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Evento</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     

<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Nuevo Evento</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_evento" id="agregar_evento" method="post" action="M9_ListarEventos.aspx?success=1">
<div class="box-body col-sm-12 col-md-12 col-lg-12 ">


   <div class="form-group col-sm-10 col-md-10 col-lg-10">
      <br />
      <h3>Nombre del Evento</h3>
      <input type="text" name="nombreEvent" id="nombreEvent" placeholder="Nombre" class="form-control">
   </div>
   <br/>
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
      <br />
      <h3>Lugar del Evento</h3>
      <input type="text" name="lugarEvent" id="lugarEvent" placeholder="Lugar" class="form-control">
   </div>
   <br/>
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
      <br />
      <h3>Descripci&oacute;n</h3>
      <input type="text" name="descripcionEvent" id="descripcionEvent" placeholder="Breve resumen del Evento" class="form-control">
   </div>
   <br/>
    <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 1-->
      <div class="col-sm-3 col-md-3 col-lg-3">
         <label>Tipo de Evento:</label>  
      </div>
      <div class="col-sm-8 col-md-8 col-lg-8" >
         <div class="btn-group">
            <button id="id_tipo" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
            Seleccionar...<span class="caret"></span>
            </button>

            <ol id="dp1" class="dropdown-menu" role="menu"  onclick="cargarcargo();">
               <li value="1"><a href="#">Seminario</a></li>
               <li value="2"><a href="#">Clases Especiales</a></li>
            </ol>
         </div>
      </div>
   </div>
        <div class="form-group col-sm-12 col-md-12 col-lg-12">
            <div class="col-sm-10 col-md-10 col-lg-10">
                <p><b>Status:</b></p>
                <label class="radio-inline">
                <input type="radio" name="radioStatus" checked="checked" id="input_status_activo"/>Activo</label>
                <label class="radio-inline">
                <input type="radio" name="radioStatus" id="input_status_inactivo"/>Inactivo</label>

            </div>
        </div>
</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-agregarEvent" class="btn btn-primary" type="submit" href="M9_ListarEventos.aspx?eliminacionSuccess=1" onclick="return checkform();">Agregar</a>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M9_ListarEventos.aspx">Volver</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>
