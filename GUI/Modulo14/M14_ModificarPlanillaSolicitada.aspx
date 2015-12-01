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
    <div class="form-group col-sm-12 col-md-12 col-lg-12" name="calendar">
    <!--Date picker FECHA Retiro-->
      <div class="form-group col-sm-4 col-md-4 col-lg-4">
       <div id="alertlocal" runat="server">
         <h3>Fecha de Retiro:</h3>
         <div class="input-group input-append date" id="id_fechai">
         <input type="text"  class="form-control" name="date" />
         <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
      </div>
     </div>
    </div>
       <div class="form-group col-sm-4 col-md-3 col-lg-4">
        <h3>Fecha de inicio:</h3>
         <div class="input-group input-append date" id="id_fechaf">
         <input type="text" class="form-control" name="date" />
         <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
       </div>
      </div>
   </div>
       <%--<div class="form-group  col-sm-12 col-md-12 col-lg-12" >
         <div id="alertlocal" runat="server">
          <!-- Alertas-->
          </div>
                  <div class="col-sm-3 col-md-3 col-lg-3">
                      <label>Fecha retiro:</label>
                  </div>     
                  <div class="col-sm-8 col-md-8 col-lg-8">
                      
                      <input type="date" ID="id_fechai" Class="form-control"   runat="server"/>    
                  </div>
      </div>
            <div class="form-group col-sm-12 col-md-12 col-lg-12">
                   <div class="col-sm-3 col-md-3 col-lg-3">
                      <label>Fecha reincorporación:</label>
                   </div>     
                   <div class="col-sm-8 col-md-8 col-lg-8">
                       <input type="date" ID="Id_fechaf" Class="form-control" runat="server"/>  
                   </div>           
             </div>--%>
   
                 <div class="form-group col-sm-4  col-md-3 col-lg-4">
                   <h3>MOTIVO:</h3>
                   <div class="col-sm-4 col-md-4 col-lg-4">
                     <asp:TextBox id="TextBox1" placeholder="Escribe el Motivo" TextMode="multiline" Columns="106" Rows="10" runat="server" />     
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