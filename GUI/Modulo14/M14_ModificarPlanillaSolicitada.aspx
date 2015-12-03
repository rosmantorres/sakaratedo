<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_ModificarPlanillaSolicitada.aspx.cs" Inherits="templateApp.GUI.Modulo14.ModificarPlanillaSolicitada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Planillas</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Planillas</a> 
		    </li>
              <li>
			    <a href="#">Consultar Planilla</a> 
		    </li>

		    <li class="active">
			    Modificar Planilla
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Modificar Planilla</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
   <!-- general form elements -->
  <div class="box-header with-border">
   <h3 class="box-title">Modificar Planilla</h3>
  </div>
  <!-- /.box-header -->
  <!-- form start -->
  <form role="form" name="modificar_planilla" id="modificar_planilla" method="post" action="M14_ModificarPlanillaSolicitada.aspx?success=1"  runat="server">
   
      <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
      <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
         <div id="alertlocal" runat="server">
          <!-- Alertas-->
          </div>
           <input id="id_solicitud" type="text" placeholder="" class="form-control" name="idSolicitud" runat="server" />  
         </div>
    
         <!--Date picker FECHA Retiro-->
       
       <div class="form-group col-sm-6 col-md-6 col-lg-6" id="fechaRetiro" runat="server">
       
         <h3>Fecha de Retiro:</h3>
         <div class="input-group input-append date" id="id_fechai" >
         <input type="text"  class="form-control" name="date" id="idFechaI" runat="server" />
         <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
      </div>
     
    </div>
       <div class="form-group col-sm-6 col-md-6 col-lg-6" id="fechaReincorporacion" runat="server">
        <h3>Fecha de Reincorporacion:</h3>
         <div class="input-group input-append date" id="id_fechaf">
         <input type="text" class="form-control" name="date" id="idFechaF" runat="server" />
         <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
       </div>
      </div>
       
       <div class="col-sm-12 col-md-12 col-lg-12">
        
       <br/>
        <div class="col-sm-3 col-md-3 col-lg-3" id="labelCompetencia" runat="server">
            <label>Seleccione la competencia:</label>  
          </div>
         <div class="col-sm-3 col-md-3 col-lg-3" id="labelEvento" runat="server">
            <label>Seleccione el evento:</label>  
          </div>
        <div class="col-sm-8 col-md-8 col-lg-84">
             <div class="dropdown" runat="server" id="divComboEvento" >
                 <asp:DropDownList ID="comboEvento" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true">
                 </asp:DropDownList>
              </div>
           </div>
           <div class="col-sm-8 col-md-8 col-lg-84">
             <div class="dropdown" runat="server" id="divComboCompetencia" >
                 <asp:DropDownList ID="comboCompetencia" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true">
                 </asp:DropDownList>
              </div>
           </div>
       </div>
         <div class="form-group col-sm-12 col-md-12 col-lg-12">
                  <div class="col-sm-8 col-md-8 col-lg-8">
                      <h3>Motivo:</h3>
                      <br />  
                       <textarea id="id_motivo" cols="120" rows="10"  class="form-control" runat="server"></textarea>
                  </div>
          </div>
 

 </div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <asp:Button id="boteditar" class="btn btn-primary"  type="submit" runat="server" Text = "Editar" OnClick="boteditar_Click" ></asp:Button>
        &nbsp;&nbsp
         <a class="btn btn-default" href="M14_SolicitarPlanilla.aspx">Cancelar</a>
      </div>
      <script type="text/javascript">
          $(document).ready(function () {
              $('#id_fechai')
              .datepicker({
                  format: 'mm/dd/yyyy'
              })
              .on('changeDate', function (e) {
                  // Revalidate the date field
              });
          });

          $(document).ready(function () {
              $('#id_fechaf')
              .datepicker({
                  format: 'mm/dd/yyyy'
              })
              .on('changeDate', function (e) {
                  // Revalidate the date field
              });
          });
   </script>
  
  </form>

<!-- /.box -->

 </asp:Content>