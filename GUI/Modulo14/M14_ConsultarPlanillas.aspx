<%@ Page EnableEventValidation="true" Language="C#"  MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_ConsultarPlanillas.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14ConsultarPlanillas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <title>Consultar Planillas</title>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li class="active">
			    Consultar Planillas
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Consultar Planillas</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" runat="server">
   <div id="alert" runat="server">
    </div>
  <div class="row">
   <div class="col-xs-12">
     <div class="box">
       <div class="box-header">
           <h3 class="box-title">Planillas Creadas</h3>
        </div><!-- /.box-header -->
      <form role="form" name="consultar_planilla" id="consular_planillas" runat="server">
         
          <div class="box-body table-responsive">
             
          <table id="planillascreadas" class="table table-bordered table-striped dataTable" accesskey="">
           <thead>
            <tr>
                <th id="key">ID</th>
                <th>Nombre</th>
                <th>Tipo de Planilla</th>
                <th>Datos</th>
                <th style="text-align:center;">Acciones</th>
            </tr>
          </thead>
              <asp:Literal runat="server" ID="tabla"></asp:Literal>
         <tbody>
             
           </tbody>
        </table>
       </div>
      </form>
    </div>
	</div>
  </div>
      
       <div id="modal-switch" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Activaci&oacute;n/Desactivaci&oacute;n de Planilla Solicitada</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>¿Está seguro que desea cambiar el status de la planilla?</p>
                    <p id="comp"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <button type="button" class="btn btn-primary" data-dismiss="modal" onserverclick="CambioDeStatus_Click">Aceptar</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div>
        </div>
      </div>
            
     
     
      <script type="text/javascript">
            $(document).ready(function () {
                $('#planillascreadas').DataTable();

                var table = $('#planillascreadas').DataTable();
                var planilla;
                var tr;

                $('#planillascreadas tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        req = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');

                    }
                    else {
                        req = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                });

            });
            $('#dimension-switch').bootstrapSwitch('setSizeClass', 'switch-small');
        </script>

    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
    
</asp:Content>