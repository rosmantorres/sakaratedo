<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M9_DetalleEvento.aspx.cs" Inherits="templateApp.GUI.Modulo9.M9_DetalleEvento" %>
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
   <h1 class="box-title">Detalle Evento</h1>
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
                                <asp:label runat="server"  name="nombreEvento" id="nombreEvento" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-sm-4 col-md-4 col-lg-4" >
                                <h3>Tipo de Evento</h3>
                                       <asp:label runat="server"  name="tipoEvento" id="tipoEvento" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Costo del Evento</h3>
                       
                                <asp:label runat="server" name="costoEvento" id="costoEvento" Font-Size="Large"></asp:Label>

                            </div>
                    </div>
                </div>


 <!--Date picker FECHA-->
                   <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12" >
            <!---FECHA Inicio-->
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Fecha de Inicio</h3>
                                <asp:label runat="server" name="fechaInicio" id="fechaInicio" Font-Size="Large"></asp:Label>
                                </div>
                 <!-- FECHA-->
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Fecha de Culminaci&oacute;n</h3>
                                <asp:label runat="server" name="fechaFin" id="fechaFin" Font-Size="Large"></asp:Label>
                            </div>
                       </div>
                    </div>
     <!--Date picker Hora-->
                    <div class="row">
                       <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <!--Hora Inicio-->
                           <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Hora de Inicio</h3>
                               <asp:label runat="server" name="horaInicio" id="horaInicio" Font-Size="Large"></asp:Label>
                           </div>
                            <!--Date picker Hora Fin-->
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <h3>Hora de Culminaci&oacute;n</h3>
                               <asp:label runat="server" name="horaFin" id="horaFin" Font-Size="Large"></asp:Label>
                            </div>
                        </div>
                    </div>
               
<!--DESCRIPCION-->
                    <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="col-sm-9 col-md-9 col-lg-9" >
                                <h3>Descripci&oacute;n</h3>
                                <asp:label runat="server" name="descripcionEvento" id="descripcionEvento" Font-Size="Large"></asp:Label>
                            </div>
                        </div>
                    </div>
 <!--ESTADO-->
                    <div class="row">
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="col-sm-10 col-md-10 col-lg-10">
                                <h3>Status</h3>
                                <asp:label runat="server" name="statusEvento" id="statusEvento" Font-Size="Large"></asp:Label>
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

      </div>
   </form>
</div>

</asp:Content>
