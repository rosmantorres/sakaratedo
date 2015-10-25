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
        <div id="alert" runat="server">
    </div>
     

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
    <br>
<!--COMBO 1-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Tipo de Evento:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Seleccionar Evento <span class="caret"></span>
          </button>
          <ul class="dropdown-menu">
               <li><a href="#">Clases</a></li>
               <li><a href="#">Charlas</a></li>
               <li><a href="#">Seminarios</a></li>
               <li><a href="#">Otros</a></li>
          </ul>
        </div>
      </div>
    </div>

    <br/>
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
      <br />
      <h3>Descripci&oacute;n</h3>
      <input type="text" name="descripcionEvent" id="descripcionEvent" placeholder="Breve resumen del Evento" class="form-control">
   </div>
   <br/>
     <!--Date picker FECHA-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
    <!--Date picker FECHA Inicio-->
    <div class="form-group col-sm-4 col-md-4 col-lg-4">
        <br />
        <h3>Fecha de Inicio:</h3>
        <div class="input-group input-append date" id="datePickerIni">
        <input type="text" class="form-control" name="date" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
    </div>
    <!--Date picker FECHA-->
    <div class="form-group col-sm-4 col-md-3 col-lg-4">
        <br />
        <h3>Fecha de Culminaci&oacute;n:</h3>
        <div class="input-group input-append date" id="datePickerFin">
        <input type="text" class="form-control" name="date" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
    </div>
   </div>
    <br/>
     <!--Date picker Hora-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
    <!--Date picker Hroa Inicio-->
    <div class="form-group col-sm-4 col-md-4 col-lg-4">
        <br />
        <h3>Hora de Inicio:</h3>
        <div class="input-group input-append date" id="hourPickerIni">
        <input type="time" class="form-control" name="date" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-time"></span></span>
        </div>
    </div>
    <!--Date picker Hora Fin-->
    <div class="form-group col-sm-4 col-md-3 col-lg-4">
        <br />
        <h3>Hora de Culminaci&oacute;n:</h3>
        <div class="input-group input-append date" id="hourPickerFin">
        <input type="time" class="form-control" name="date" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-time"></span></span>
        </div>
    </div>


    </div>


    <br/>
 
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
