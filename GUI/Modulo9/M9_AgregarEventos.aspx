<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M9_AgregarEventos.aspx.cs" Inherits="templateApp.GUI.Modulo9.M9_AgregarEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
<script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
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
			    <a href="../Modulo9/M9_ListarEventos.aspx">Gesti&oacute;n de Eventos</a> 
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
   <h1 class="box-title">Nuevo Evento</h1>
</div>
<!-- /.box-header -->
<!-- form start -->
<form runat="server" role="form" name="agregarEvento" id="agregarEvento" method="post">
    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
        <div class="panel-group ">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3>Datos del Evento</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Nombre del Evento</h3>
                                <asp:TextBox runat="server" type="text" name="nombreEvento" id="nombreEvento" placeholder="Nombre" class="form-control"></asp:TextBox>
                            </div>
                    </div>
                </div>
<!--COMBO 1-->
                    <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="col-sm-4 col-md-4 col-lg-4" >
                                <h3>Tipo de Evento</h3>
                                <div class="btn-group"> 
                                    <div class="dropdown" runat="server" id="divComboTipoEvento">
                                       <asp:DropDownList ID="comboTipoEvento"  class="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged="comboTipoEvento_SelectedIndexChanged" AutoPostBack="true">
                                       </asp:DropDownList>
                                    </div>
                                        <asp:TextBox runat="server" type="text" name="otroEvento" id="otroEvento" placeholder="Tipo de Evento" class="form-control"></asp:TextBox>
                                    
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Costo del Evento</h3>
                                <asp:TextBox runat="server" type="number" name="costoEvento" id="costoEvento" placeholder="Costo" class="form-control"></asp:TextBox>
                            </div>
                    </div>
                </div>




 <!--Date picker FECHA-->
                   <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12" >
            <!---Date picker FECHA Inicio-->
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Fecha de Inicio</h3>
                                <div class="input-group input-append date" id="datePickerIni">
                                    <input runat="server" type="text" class="form-control" name="date" id="fechaInicio"/>
                                    <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>
                            <div class="col-sm-1 col-md-1 col-lg-1"></div>
                            <!--Date picker FECHA-->
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Fecha de Culminaci&oacute;n</h3>
                                <div class="input-group input-append date" id="datePickerFin">
                                    <input runat="server" type="text" class="form-control" name="date" id="fechaFin"/>
                                    <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>
                       </div>
                    </div>
     <!--Date picker Hora-->
                    <div class="row">
                       <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <!--Date picker Hora Inicio-->
                           <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Hora de Inicio</h3>
                                <div class="input-group input-append date" id="hourPickerIni">
                                    <asp:TextBox TextMode="Time" Class="form-control" ID="horaInicio" runat="server">

                                    </asp:TextBox>
                                     <span class="input-group-addon add-on"><span class="glyphicon glyphicon-time"></span></span>
                                   
                                </div>
                           </div>
                            <!--Date picker Hora Fin-->
                           <div class="col-sm-1 col-md-1 col-lg-1"></div>
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Hora de Culminaci&oacute;n</h3>
                                <div class="input-group input-append date" id="hourPickerFin">
                                    <asp:TextBox TextMode="Time" class="form-control" ID="horaFin" runat="server">
                                   </asp:TextBox><span class="input-group-addon add-on"><span class="glyphicon glyphicon-time"></span></span>
                                </div>
                            </div>
                        </div>
                    </div>
               
<!--DESCRIPCION-->
                    <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="col-sm-9 col-md-9 col-lg-9" >
                                <h3>Descripci&oacute;n</h3>
                                <asp:TextBox runat="server" type="text" TextMode="multiline" style = "resize:vertical" name="DescripcionEvento" id="descripcionEvento" placeholder="Breve descrici&oacute;n del evento" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
 <!--ESTADO-->
                    <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <p><b>Status:</b></p>
                                <label class="radio-inline">
                                    <asp:RadioButton runat="server" Text="Activo"  checked="true" type="radio" name="radioStatus" id="inputEstadoActivo" GroupName="statusEvento"/>
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton runat="server" Text="Inactivo" type="radio" name="radioStatus" id="inputEstadoInactivo" GroupName="statusEvento"/>
                                </label>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <asp:Button id="btn_agregarEvento" class="btn btn-primary" type="submit" runat="server" OnClick="btn_agregarEventoClick" Text="Agregar"></asp:Button>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M9_ListarEventos.aspx">Cancelar</a>
      </div>
   </form>
</div>

<script type="text/javascript">
$(document).ready(function () {
    $('#datePickerIni')
    .datepicker({
        format: 'mm/dd/yyyy'
    })
    .on('changeDate', function (e) {
                // Revalidate the date field
            });
    });

$(document).ready(function () {
    $('#datePickerFin')
    .datepicker({
        format: 'mm/dd/yyyy'
    })
    .on('changeDate', function (e) {
        // Revalidate the date field
    });
});

    </script>

<!-- /.box -->
</asp:Content>
