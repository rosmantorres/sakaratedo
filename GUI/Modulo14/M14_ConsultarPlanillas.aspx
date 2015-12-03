<%@ Page Language="C#"  MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_ConsultarPlanillas.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14ConsultarPlanillas" %>

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
   
  <div class="row">
   <div class="col-xs-12">
     <div class="box">
       <div class="box-header">
           <h3 class="box-title">Planillas Creadas</h3>
        </div><!-- /.box-header -->
         <div class="box-body table-responsive">

          <table id="planillascreadas" class="table table-bordered table-striped dataTable">
           <thead>
            <tr>
                <th>Nombre</th>
                <th>Tipo de Planilla</th>
                <th>Datos</th>
                <th style="text-align:center;">Acciones</th>
            </tr>
          </thead>
 
          <tfoot>
            <tr>
                <th>Nombre</th>
                <th>Tipo de Planilla</th>
                <th>Datos</th>
                <th style="text-align:center;">Acciones</th>
            </tr>
         </tfoot>
 
         <tbody>
              <tr>
                <td class="id">Record Académico</td>
                <td>Solicutud</td>
                <td>Dojo, Atleta</td>
                <td>
                        <a class="btn btn-primary glyphicon glyphicon-save" target="_blank" href="DiseñoDefault.rpt"></a>                        
                       <a class="btn btn-default glyphicon glyphicon-pencil" href="M14_ModificarPlanillaCreada.aspx"></a>
                        <a class="btn btn-default glyphicon glyphicon-upload" data-toggle="modal" data-target="#modal-cargar"></a>
                       <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox" checked data-toggle="toggle" data-on="ON" data-off="OFF" >
                        </a>               
                </td>
            </tr>

             <tr>
                <td class="id">Retiro Competencia</td>
                <td>Retiro</td>
                <td>Dojo, Atleta, Competencia</td>
                <td>
                        <a class="btn btn-primary glyphicon glyphicon-save" target="_blank" href="DiseñoDefault.rpt"></a>                        
                       <a class="btn btn-default glyphicon glyphicon-pencil" href="M14_ModificarPlanillaCreada.aspx"></a>
                        <a class="btn btn-default glyphicon glyphicon-upload" data-toggle="modal" data-target="#modal-cargar"></a>
                       <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox" checked data-toggle="toggle" data-on="ON" data-off="OFF" >
                        </a>              
                </td>
            </tr>
            
             <tr>
                <td class="id">Inasistencia</td>
                <td>Solicitud</td>
                <td>Dojo, Atleta, Asistencia</td>
                <td>
                       <a class="btn btn-primary glyphicon glyphicon-save" target="_blank" href="DiseñoDefault.rpt"></a>                        
                       <a class="btn btn-default glyphicon glyphicon-pencil" href="M14_ModificarPlanillaCreada.aspx"></a>
                        <a class="btn btn-default glyphicon glyphicon-upload" data-toggle="modal" data-target="#modal-cargar"></a>
                       <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox" checked data-toggle="toggle" data-on="ON" data-off="OFF" >
                        </a>              
                </td>
            </tr>
              <tr>
                <td class="id">Retiro Dojo</td>
                <td>Retiro</td>
                <td>Dojo, Atleta</td>
                <td>
                      <a class="btn btn-primary glyphicon glyphicon-save" target="_blank" href="DiseñoDefault.rpt"></a>                        
                       <a class="btn btn-default glyphicon glyphicon-pencil" href="M14_ModificarPlanillaCreada.aspx"></a>
                        <a class="btn btn-default glyphicon glyphicon-upload" data-toggle="modal" data-target="#modal-cargar"></a>
                       <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox" checked data-toggle="toggle" data-on="ON" data-off="OFF" >
                        </a>              
                </td>
            </tr>
            
              <tr>
                <td class="id">Solicitud de Arbitraje</td>
                <td>Retiro</td>
                <td>Dojo, Atleta, Competencia</td>
                <td>
                       <a class="btn btn-primary glyphicon glyphicon-save" target="_blank" href="DiseñoDefault.rpt"></a>                        
                       <a class="btn btn-default glyphicon glyphicon-pencil" href="M14_ModificarPlanillaCreada.aspx"></a>
                        <a class="btn btn-default glyphicon glyphicon-upload" data-toggle="modal" data-target="#modal-cargar"></a>
                       <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox" checked data-toggle="toggle" data-on="ON" data-off="OFF" >
                        </a>              
                </td>
            </tr>
            
              <tr>
                <td class="id">Retiro Arbitraje</td>
                <td>Retiro</td>
                <td>Dojo, Atleta, Competencia</td>
                <td>
                       <a class="btn btn-primary glyphicon glyphicon-save" target="_blank" href="DiseñoDefault.rpt"></a>                        
                       <a class="btn btn-default glyphicon glyphicon-pencil" href="M14_ModificarPlanillaCreada.aspx"></a>
                        <a class="btn btn-default glyphicon glyphicon-upload" data-toggle="modal" data-target="#modal-cargar"></a>
                       <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox" checked data-toggle="toggle" data-on="ON" data-off="OFF" >
                        </a>               
                </td>
            </tr>
           </tbody>
        </table>
       </div>
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
                <button type="button" class="btn btn-primary" data-dismiss="modal">Aceptar</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div>
        </div>
      </div>
            
     <div id="modal-cargar" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Cargar diseño de Planilla</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Buscar Archivo...</p>
                    <p><input type="file" name="nombre"></p>
                    <p id="P1"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <button type="button" class="btn btn-primary" data-dismiss="modal" data-toggle="modal" data-target="#modal-exito">Cargar</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div>
        </div>
      </div>
     
      <div id="modal-exito" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Exito!!!</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>¡¡Su diseño se cargó satisfactoriamente!!</p>
                    <p id="P2"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <button type="button" class="btn btn-primary" data-dismiss="modal">Aceptar</button>
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