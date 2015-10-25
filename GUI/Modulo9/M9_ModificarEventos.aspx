<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M9_ModificarEventos.aspx.cs" Inherits="templateApp.GUI.Modulo9.M9_ModificarEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
<script>
function habilitar() {
    document.getElementById('nombreEvent').disabled = false;
    document.getElementById('lugarEvent').disabled = false;
    document.getElementById('descripcionEvent').disabled = false;
    document.getElementById('dateInicio').disabled = false;
    document.getElementById('hourInicio').disabled = false;
    document.getElementById('dateFin').disabled = false;
    document.getElementById('hourFin').disabled = false;
    document.getElementById('input_status_activo').disabled = false;
    document.getElementById('input_status_inactivo').disabled = false;
    document.getElementById('tipoEvento').disabled = false;
} 
</script>
            <div id="alert" runat="server">
    </div>

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

    <!--COMBO 1-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Evento a Modificar:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" onclick="habilitar()">
            Seleccionar Evento <span class="caret"></span>
          </button>
          <ul class="dropdown-menu">
               <li><a href="#">Evento 1</a></li>
               <li><a href="#">Evento 2</a></li>
               <li><a href="#">Evento 3</a></li>
               <li><a href="#">Evento 4</a></li>
          </ul>
        </div>
      </div>
    </div>



   <div class="form-group col-sm-10 col-md-10 col-lg-10">
      <br />
      <h3>Nombre del Evento</h3>
      <input type="text" disabled name="nombreEvent" id="nombreEvent" placeholder="Nombre" class="form-control">
   </div>
   <br/>
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
      <br />
      <h3>Lugar del Evento</h3>
      <input type="text"disabled name="lugarEvent" id="lugarEvent" placeholder="Lugar" class="form-control">
   </div>
    <br>
<!--COMBO 1-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Tipo de Evento:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" id="tipoEvento" type="button"disabled data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
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
      <input type="text"disabled name="descripcionEvent" id="descripcionEvent" placeholder="Breve resumen del Evento" class="form-control">
   </div>
   <br/>
     <!--Date picker FECHA-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
    <!--Date picker FECHA Inicio-->
    <div class="form-group col-sm-4 col-md-4 col-lg-4">
        <br />
        <h3>Fecha de Inicio:</h3>
        <div class="input-group input-append date" id="datePickerIni">
        <input type="text"disabled class="form-control" name="dateInicio" id="dateInicio" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
    </div>
    <!--Date picker FECHA-->
    <div class="form-group col-sm-4 col-md-3 col-lg-4">
        <br />
        <h3>Fecha de Culminaci&oacute;n:</h3>
        <div class="input-group input-append date" id="datePickerFin">
        <input type="text"disabled class="form-control" name="dateFin" id="dateFin" />
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
        <input type="time"disabled class="form-control" name="hourInicio" id="hourInicio" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-time"></span></span>
        </div>
    </div>
    <!--Date picker Hora Fin-->
    <div class="form-group col-sm-4 col-md-3 col-lg-4">
        <br />
        <h3>Hora de Culminaci&oacute;n:</h3>
        <div class="input-group input-append date" id="hourPickerFin">
        <input type="time" disabled class="form-control" name="hourFin" id="hourFin" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-time"></span></span>
        </div>
    </div>


    </div>


    <br/>
 
        <div class="form-group col-sm-12 col-md-12 col-lg-12">
            <div class="col-sm-10 col-md-10 col-lg-10">
                <p><b>Status:</b></p>
                <label class="radio-inline">
                <input type="radio" disabled name="radioActivo" checked="checked" id="input_status_activo"/>Activo</label>
                <label class="radio-inline">
                <input type="radio"disabled name="radioInactivo" id="input_status_inactivo"/>Inactivo</label>

            </div>
        </div>
</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-modificarrEvent" class="btn btn-primary" type="submit" href="M9_ListarEventos.aspx?eliminacionSuccess=1" onclick="return checkform();">Modificar</a>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M9_ListarEventos.aspx">Volver</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>
