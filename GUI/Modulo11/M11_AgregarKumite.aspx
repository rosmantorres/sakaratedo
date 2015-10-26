<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_AgregarKumite.aspx.cs" Inherits="templateApp.GUI.Modulo11.M11_AgregarKumite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencias</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Resultados de Competencias</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Resultados de Competencia</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Resultados de Competencia</a> 
		    </li>
		
		    <li class="active">
			    Agregar Kumite
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Agregar Resultados Kumite</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_asistencia" id="agregar_asistencia" method="post" action="#">
<div class="box-body col-sm-12 col-md-12 col-lg-12">

    <!--COMBO ATLETA#1-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Atleta #1:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Seleccionar Puntuacion: <span class="caret"></span>
          </button>
          <ul class="dropdown-menu">
               <li><a href="#">1</a></li>
               <li><a href="#">2</a></li>
               <li><a href="#">3</a></li>
               <li><a href="#">4</a></li>
               <li><a href="#">5</a></li>
               <li><a href="#">6</a></li>
               <li><a href="#">7</a></li>
               <li><a href="#">8</a></li>
               <li><a href="#">9</a></li>
               <li><a href="#">10</a></li>
          </ul>
        </div>
      </div>
    </div>

    <!--COMBO JURADO#2-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Atleta #2:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Seleccionar Puntuacion: <span class="caret"></span>
          </button>
          <ul class="dropdown-menu">
               <li><a href="#">1</a></li>
               <li><a href="#">2</a></li>
               <li><a href="#">3</a></li>
               <li><a href="#">4</a></li>
               <li><a href="#">5</a></li>
               <li><a href="#">6</a></li>
               <li><a href="#">7</a></li>
               <li><a href="#">8</a></li>
               <li><a href="#">9</a></li>
               <li><a href="#">10</a></li>
          </ul>
        </div>
      </div>
    </div>
   <br/>

            

</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-agregarComp" class="btn btn-primary" type="submit" href="M11_AgregarResultadoCompetencia.aspx?eliminacionSuccess=1" onclick="return checkform();">Agregar</a>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M11_AgregarResultadoCompetencia.aspx"> Cancelar</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>