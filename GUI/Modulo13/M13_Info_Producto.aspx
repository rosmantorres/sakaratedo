﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Info_Producto.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_Info_Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Inventario de Productos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Inventario de Productos</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
    &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-exportarComp" class="btn btn-primary" type="submit" href="Pdf/Morosos.pdf?eliminacionSuccess=1" onclick="return checkform();">Exportar a PDF</a>
         &nbsp;&nbsp
 <form id="form1" runat="server">
     <asp:DropDownList ID="DropDownList1" runat="server">

         <asp:ListItem Text="Seleccionar Continente" Value="-1"></asp:ListItem>
         <asp:ListItem Text="Asia" Value="1"></asp:ListItem>
         <asp:ListItem Text="Africa" Value="2"></asp:ListItem>
         <asp:ListItem Text="Europa" Value="3"></asp:ListItem>
         <asp:ListItem Text="North America" Value="4"></asp:ListItem>
         <asp:ListItem Text="South America" Value="5"></asp:ListItem>
    

     </asp:DropDownList>  
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
      
        </form>  


     <div class="box-body table-responsive">
         
			<asp:Table ID="example" runat="server" CssClass="table table-bordered table-striped dataTable">
                <asp:TableHeaderRow><asp:TableHeaderCell>Foto</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Tipo</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Color</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Estatus</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Stock Min</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Total</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Dojo</asp:TableHeaderCell>
                
                </asp:TableHeaderRow>
			</asp:Table>
               
        </div>

     <script type="text/javascript">
         $(document).ready(function () {

             var table = $('#example').DataTable({
                 "language": {
                     "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                 }
             });
             var req;
             var tr;

             $('#example tbody').on('click', 'a', function () {
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



             $('#modal-delete').on('show.bs.modal', function (event) {
                 var modal = $(this)
                 modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                 modal.find('#req').text(req)
             })
             $('#btn-eliminar').on('click', function () {
                 table.row(tr).remove().draw();//se elimina la fila de la tabla
                 $('#modal-delete').modal('hide');//se esconde el modal
             });


         });

         </script>


</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="M13_Inicio.aspx">Reportes Dojo</a> 
		    </li>
		
		    <li class="active">
			    Inventario de Productos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>