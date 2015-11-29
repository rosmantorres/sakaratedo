<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_ListarDojos.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_ListarDojos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Dojo</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Dojo</a> 
		    </li>
		
		    <li class="active">
			    Listar Dojos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Dojos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Dojos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
        <div id="alert" runat="server">
    </div>

    
    
     <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Dojos</h3>
                    
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tabladojos" class="table table-bordered table-striped dataTable">
            <thead>
				<tr>
                    <th style="text-align:left">Foto</th>
                    <th style="text-align:left">Rif</th>
					<th style="text-align:left">Nombre</th>
                    <th style="text-align:left">Organización</th>
                    <th style="text-align:left">Ubicación</th>
                    <th style="text-align:left">Status</th>
					<th style="text-align:left">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<asp:Literal runat="server" ID="laTabla"></asp:Literal>               
			    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>




</asp:Content>
