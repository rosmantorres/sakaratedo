<%@ Page Language="C#"  MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_RegistrarPlanilla.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14_RegistrarPlanilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo14/M14_AgregarEliminarDatos.js") %>"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Gestión de planillas</a>
		    </li>

		
		    <li class="active">
			    Registrar Planilla
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Registrar Planilla</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
   <!-- general form elements -->
  <div class="box-header with-border">
   <h3 class="box-title">Nueva Planilla</h3>
  </div>
  <!-- /.box-header -->
  <!-- form start -->
  <form role="form" name="agregar_planilla" id="agregar_planilla" method="post" action="M14_RegistrarPlanilla.aspx?success=1">
   <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
      <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
         <div id="alertlocal" runat="server">
          <!-- Alertas-->
          </div>
          <div class="col-sm-3 col-md-3 col-lg-3">
            <label>Seleccione el tipo de planilla:</label>  
          </div>
          <div class="col-sm-8 col-md-8 col-lg-8">
             <div class="btn-group">
            <button id="id_tipos" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
            Selecionar...<span class="caret"></span>
            </button>
            <ol id="dp1" class="dropdown-menu" role="menu"  onclick="cargartipo();">
               <li value="1"><a href="#">Retiro</a></li>
               <li value="2"><a href="#">Asistencia</a></li>
            </ol>
         </div>
     </div>

  <!--  <div class="form-group  col-sm-10 col-md-10 col-lg-10">
       <div  id="id_otro" runat="server">
        <br/>
          <h3>Nombre del tipo de Planilla</h3>
           <input id="id_nombretipo" type="text" placeholder="Nombre Tipo Planilla" class="form-control" name="NombreTipoPlanilla" runat="server" />
        </div>
     </div>-->
     <div class="form-group  col-sm-12 col-md-12 col-lg-12"">
      <br/>
      <h3>Nombre de Planilla</h3>
      <input id="Text1" type="text" placeholder="NombrePlanilla" class="form-control" name="NombrePlanilla" runat="server" />
     </div>
    
    <div class="form-group">
      <div id="div-dat" class="col-sm-12 col-md-12 col-lg-12">
         <h3>Datos Disponibles</h3>
          <select multiple="multiple" name="dat_primary" size="4" class="form-control select select-primary select-block mbl">
            <option value="Dojo">Dojo</option>
            <option value="Atleta">Atleta</option>
            <option value="Competencia">Competencia</option>
            <option value="Asistencia">Asistencia</option>
            <option value="Instructor">Instructor</option>
            <option value="Representante">Representante</option>
          </select>
          <br/>
         <div class="text-center padding-small">
            <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-down" onclick="agregarDat()"></button>
            <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-up" onclick="eliminarDat()"></button>
         </div>
         <h3>Organizaciones Seleccionadas</h3>
         <select multiple="multiple" name="dat_secondary" size="4" class="form-control select select-primary select-block mbl"></select>
         <br />
         <br />
      </div>
   </div>

 </div>  </div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
        <a id="btn-agregarComp" class="btn btn-primary" type="submit" href="M14_ConsultarPlanillas.aspx?eliminacionSuccess=1" onclick="return checkform();">Agregar</a>
          &nbsp;&nbsp
         <a class="btn btn-default" href="M14_ConsultarPlanillas.aspx">Cancelar</a>
      </div>
   </form>

<!-- /.box -->
</asp:Content>