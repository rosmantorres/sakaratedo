<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_ListarResultadoCompetencia.aspx.cs" Inherits="templateApp.GUI.Modulo11.ListarResultadoCompetencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencia
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Resultados de Competencia
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="breads" runat="server">

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
			    Listar Resultados de Competencias
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
    </asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

     <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Listar Resultados</h3>
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tablaResultado" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                    <th style="text-align:center">Referencia</th>
					<th style="text-align:center">Nombre del Evento</th>
                    <th style="text-align:center">Fecha</th>
					<th style="text-align:center">Tipo</th>
					<th style="text-align:center">Acciones</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="dataTable"></asp:Literal>				
			</tbody>
       </table>
           </div>
       </div>
    </div>
</div>

             <script type="text/javascript">
                 $(document).ready(function () {
                     $('#tablaResultado').DataTable();

                     var table = $('#tablaResultado').DataTable();
                     var comp;
                     var tr;

                     $('#tablaResultado tbody').on('click', 'a', function () {
                         if ($(this).parent().hasClass('selected')) {
                             comp = $(this).parent().prev().prev().prev().prev().text();
                             tr = $(this).parents('tr');//se guarda la fila seleccionada
                             $(this).parent().removeClass('selected');

                         }
                         else {
                             comp = $(this).parent().prev().prev().prev().prev().text();
                             tr = $(this).parents('tr');//se guarda la fila seleccionada
                             table.$('tr.selected').removeClass('selected');
                             $(this).parent().addClass('selected');
                         }
                     });

                 });

        </script>
    
</asp:Content>