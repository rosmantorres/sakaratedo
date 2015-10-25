<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_ListarMorosos.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_ListarMorosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Lista de Morosos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Morosos</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
   &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-exportarComp" class="btn btn-primary" type="submit" href="M13_ListarMorosos.aspx?eliminacionSuccess=1" onclick="return checkform();">Exportar PDF</a>
         &nbsp;&nbsp
   
    <table id="tablamorosos" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th style="text-align:center">Nombre</th>
					<th style="text-align:center">Apellido</th>
                    <th style="text-align:center">Numero de meses que adeuda</th>
					<th style="text-align:center">Monto deuda</th>
				</tr>
			</thead>
			
      </table>

</asp:Content>
