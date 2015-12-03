<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_SolicitarPlanilla.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14_SolicitarPlanilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">

		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="M14_ConsultarPlanillas.aspx">Gestión de planillas</a>
		    </li>
		
		    <li class="active">
			    Solicitar Planillas
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Solicitar Planilla</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <!-- general form elements -->
    <div class="box box-primary">
      <div class="box-header with-border">
        <h3 class="box-title">Solicitar Planilla</h3>
      </div>
      <!-- /.box-header -->
     <!-- form start -->
    <form role="form" name="solicitar_planilla" id="solicitar_planilla" method="post" action="M14_SolicitarPlanilla.aspx?success=1">

     <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
         <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
            <div id="alertlocal" runat="server">
              <!-- Alertas-->
            </div>
            <div class="col-sm-3 col-md-3 col-lg-3">
                <label>Seleccione el tipo de planilla:</label>  
            </div>
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

         <div class="box-body table-responsive">
           <table id="solicitarplanilla" class="table table-bordered table-striped dataTable">
            <thead>
             <tr>
                <th>Nombre</th>
                <th>Tipo de Planilla</th>
                <th>Acciones</th>

             </tr>
           </thead>
           <tfoot>
            <tr>
                <th>Nombre</th>
                <th>Tipo de Planilla</th>
                <th>Acciones</th>
            </tr>
           </tfoot>
           <tbody>
              <tr>
                <td>Record Académico</td>
                <td>Solicitud</td>
                <td>
                        <a class="btn btn-primary" href="M14_SolicitudPlanilla.aspx">Solicitar</a>                                  
                </td>
            </tr>
            <tr>
                <td>Retiro de Competencias</td>
                <td>Retiro</td>
                <td>
                        <a class="btn btn-primary" href="M14_SolicitudPlanilla.aspx">Solicitar</a>                        

                </td>
            </tr>
            <tr>
                <td>Solicitud de Arbitaje</td>
                <td>Solicitud</td>
                <td>
                        <a class="btn btn-primary" href="M14_SolicitudPlanilla.aspx">Solicitar</a>                        
            </tr>
            <tr>
                <td>Permiso de Inasistencia</td>
                <td>Solicitud</td>
                <td>
                        <a class="btn btn-primary" href="M14_SolicitudPlanilla.aspx">Solicitar</a>                        

            </tr>
            <tr>
                <td>Retiro de Arbitraje</td>
                <td>Retiro</td>
                <td>
                        <a class="btn btn-primary" href="M14_SolicitudPlanilla.aspx">Solicitar</a>                        

                </td>
            </tr>
            
          </tbody>
         </table>
       </div>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#solicitarplanilla').DataTable();
            });


        </script>


        
    </div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
      </div>
   </form>
 </div>
<!-- /.box -->
</asp:Content>