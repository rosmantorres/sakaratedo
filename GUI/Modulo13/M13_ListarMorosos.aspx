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
			
        <tbody>
				<tr>
					<td class="id" style="text-align:center">Rose</td>
					<td style="text-align:center">Gomez</td>
					<td style="text-align:center">2</td>
					<td style="text-align:center">5000.00</td>
                                                          
                </tr>

            <tr>
					<td class="id" style="text-align:center">Leopoldo</td>
					<td style="text-align:center">Mirabal</td>
					<td style="text-align:center">3</td>
					<td style="text-align:center">8000.00</td>
                                                          
                </tr>
            <tr>
					<td class="id" style="text-align:center">Eduardo</td>
					<td style="text-align:center">Pacheco</td>
					<td style="text-align:center">4</td>
					<td style="text-align:center">15000.00</td>
                                                          
                </tr>
         </tbody>
      </table>

   
  

</asp:Content>
