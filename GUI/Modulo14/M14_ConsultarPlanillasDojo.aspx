<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_ConsultarPlanillasDojo.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14_ConsultarPlanillasDojo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
</asp:Content>
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
			    Consultar Planillas Dojo
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Consultar Planillas</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

    <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Planillas Solicitadas</h3>
        </div>

    <div class="box-body table-responsive">
        <table id="tablaplanillas" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:center">Dojo</th>
					<th style="text-align:center">Matrícula</th>
					<th style="text-align:center">Atleta</th>
					<th style="text-align:center">Planilla</th>
					<th style="text-align:center">Tipo</th>
                    <th style="text-align:center">Fecha de creación</th>
                    <th style="text-align:center">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
                    <td>Jaduko-Jan</td>
                    <th>5678SKD</th>
                    <td>José Morgado</td>
                    <td>Inscripción</td>
                    <td>_________</td>
                    <td>10/03/2010</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" target="_blank" href="M14_VisorInscripcion.aspx"></a>
                     </td>
                </tr>
                <tr>
                    <td>Jaduko-Jan</td>
                    <td>5678SKD</td>
                    <th>José Morgado</th>
                    <td>Carnet</td>
                    <td>________</td>
                    <td>11/03/2010</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" target="_blank" href="M14_VisorCarnet.aspx"></a>
                     </td>
				</tr><tr>
                    <td>Jaduko-Jan</td>
                    <td>67238SKD</td>
                    <th>Richard Pérez</th>
                    <td>Permiso</td>
                    <td>Competencia</td>
                    <td>12/07/2010</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" href="M14_VisorCarnet.aspx"></a>
                     </td>
                </tr>
                <tr>
                    <td>Jaduko-Jan</td>
                    <td>67238SKD</td>
                    <th>Richard Pérez</th>
                    <td>Permiso</td>
                    <td>Temporal</td>
                    <td>20/09/2010</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign"href="M14_VisorCarnet.aspx"></a>
                     </td>
                </tr>
                <tr>
                    <td>Jaduko-Jan</td>
                    <td>34534SKD</td>
                    <td>Ana López</td>
                    <td>Ascenso</td>
                    <td>Cinta azul</td>
                    <td>30/11/2010</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" href="M14_VisorCarnet.aspx"></a>
                    </td>
                </tr>
			    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#tablaplanillas').DataTable();

                var table = $('#tablaplanillas').DataTable();
                var comp;
                var tr;

                $('#tablaplanillas tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        comp = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');
                        $(this).parent().removeClass('selected');

                    }
                    else {
                        comp = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                });

            });

        </script>

        <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
</asp:Content>
