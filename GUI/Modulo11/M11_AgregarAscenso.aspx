<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_AgregarAscenso.aspx.cs" Inherits="templateApp.GUI.Modulo11.M11_AgregarAscenso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencias</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Resultados de Competencias</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Agregar Resultados Examen Ascenso</h3>
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
               <li><a href="#">Aprobado</a></li>
               <li><a href="#">No Aprobado</a></li>
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
         <a id="btn-agregarComp" class="btn btn-primary" type="submit" href="M10_ListarAsistenciaEventos.aspx" onclick="return checkform();">Agregar</a>
         &nbsp;&nbsp
         <a class="btn btn-default"> Cancelar</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>