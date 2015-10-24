<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Prueba.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo12/M12_AgregarEliminarOrganizaciones.js") %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Lista de Morosos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Morosos</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
   

    <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 1-->
      <div class="col-sm-3 col-md-3 col-lg-3">
         <label>Seleccione el mes a consultar:</label>  
      </div>
      <div class="col-sm-8 col-md-8 col-lg-8" >
         <div class="btn-group">
            <button id="id_edades" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
            Selecionar...<span class="caret"></span>
            </button>
            <ol id="dp1" class="dropdown-menu" role="menu"  onclick="cargarcargo();">
                <li value="1"><a href="#">Enero</a></li>
                <li value="2"><a href="#">Febrero</a></li>
                <li value="2"><a href="#">Marzo</a></li>
                <li value="2"><a href="#">Abril</a></li>
                <li value="2"><a href="#">Mayo</a></li>
                <li value="2"><a href="#">Junio</a></li>
                <li value="2"><a href="#">Juli0</a></li>
                <li value="2"><a href="#">Agosto</a></li>
                <li value="2"><a href="#">Septiembre</a></li>
                <li value="2"><a href="#">Octubre</a></li>
                <li value="2"><a href="#">Noviembre</a></li>
                <li value="2"><a href="#">Dicembre</a></li>
            </ol>
         </div>
      </div>
   </div>
    
   
    <table id="tablamorosos" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:center">Nombre</th>
					<th style="text-align:center">Apellido</th>
					<th style="text-align:center">Tecnica</th>
					<th style="text-align:center">Monto deuda</th>
				</tr>
			</thead>
			
      </table>

</asp:Content>






