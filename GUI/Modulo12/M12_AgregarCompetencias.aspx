<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M12_AgregarCompetencias.aspx.cs" Inherits="templateApp.GUI.Modulo12.M12_AgregarCompetencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo12/M12_AgregarEliminarOrganizaciones.js") %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Competencias</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Competencia</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Nueva Competencia</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_competencia" id="agregar_competencia" method="post" action="M12_ListarCompetencias.aspx?success=1">
<div class="box-body col-sm-12 col-md-12 col-lg-12 ">
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
      <br />
      <h3>Nombre de Competencia</h3>
      <input type="text" name="nombreComp" id="nombreComp" placeholder="Nombre" class="form-control">
   </div>
   <br/>
   <div class="form-group">
      <div class="col-sm-10 col-md-10 col-lg-10">
         <h3>Tipo de Competencia</h3>
         <label class="radio-inline">
         <input type="radio" name="radioTipo" checked="checked" id="input_tipo_kata" onclick="return fillCodigoTextField();" />Kata</label>
         <label class="radio-inline">
         <input type="radio" name="radioTipo" id="input_tipo_kumite"  onclick="return fillCodigoTextField();"/>Kumite</label>
      </div>
   </div>
   <div class="form-group">
      <div id="div-org" class="col-sm-12 col-md-12 col-lg-12">
         <h3>Organizaciones Disponibles</h3>
         <select multiple="multiple" name="org_primary" size="4" class="form-control select select-primary select-block mbl">
            <option value="Organización 1">Organización 1</option>
            <option value="Organización 2">Organización 2</option>
            <option value="Organización 3">Organización 3</option>
            <option value="Organización 1">Organización 4</option>
            <option value="Organización 2">Organización 5</option>
            <option value="Organización 3">Organización 6</option>
         </select>
         <br />
         <div class="text-center padding-small">
            <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-down" onclick="agregarOrg()"></button>
            <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-up" onclick="eliminarOrg()"></button>
         </div>
         <h3>Organizaciones Seleccionadas</h3>
         <select multiple="multiple" name="org_secondary" size="4" class="form-control select select-primary select-block mbl"></select>
         <br />
         <br />
      </div>
   </div>
   <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 1-->
      <div class="col-sm-3 col-md-3 col-lg-3">
         <label>Seleccione el rango de edad:</label>  
      </div>
      <div class="col-sm-8 col-md-8 col-lg-8" >
         <div class="btn-group">
            <button id="id_edades" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
            Selecionar...<span class="caret"></span>
            </button>
            <ol id="dp1" class="dropdown-menu" role="menu"  onclick="cargarcargo();">
               <li value="1"><a href="#">12-20</a></li>
               <li value="2"><a href="#">21-26</a></li>
            </ol>
         </div>
      </div>
   </div>
   <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 2-->
      <div class="col-sm-3 col-md-3 col-lg-3">
         <label>Seleccione la cinta:</label>  
      </div>
      <div class="col-sm-8 col-md-8 col-lg-8" >
         <div class="btn-group">
            <button id="id_cinta" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" >
            Selecionar...<span class="caret"></span>
            </button>
            <ol id="dp3" class="dropdown-menu" role="menu">                                                                                                 
            </ol>
         </div>
      </div>
   </div>
   <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 3-->
      <div class="col-sm-3 col-md-3 col-lg-3">
         <label>Seleccione el sexo:</label>  
      </div>
      <div class="col-sm-8 col-md-8 col-lg-8" >
         <div class="btn-group">
            <button id="id_sexo" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
            Selecionar...<span class="caret"></span>
            </button>
            <ol id="dp2" class="dropdown-menu" role="menu">
            </ol>
         </div>
      </div>
   </div>
</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <button id="btn-agregarComp" class="btn btn-primary" type="submit" onclick="return checkform();">Agregar</button>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M12_ListarCompetencias.aspx">Volver</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>
