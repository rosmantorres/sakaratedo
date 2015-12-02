<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_ListarMorosos.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_ListarMorosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Lista de Morosos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Morosos</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
   &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-exportarComp" class="btn btn-primary" type="submit" href="Pdf/Morosos.pdf?eliminacionSuccess=1" onclick="return checkform();">Exportar a PDF</a>
         &nbsp;&nbsp

    <div class="box-body table-responsive">
    <table id="example" class="table table-bordered table-striped dataTable">
       <thead>
              <tr>
                   <th>Nombre</th>
                   <th>Apellido</th>
                   <th>Cedula</th>
                   <th>Dojo</th>
                   <th>Meses de Mora</th>
                   <th>Monto de deuda</th>

              </tr>
        </thead>
     <tbody>
            <%
                List<DominioSKD.Morosidad> listaMorosoV = new List<DominioSKD.Morosidad>();
                LogicaNegociosSKD.Modulo13.LogicaMorosos lmoroso = new LogicaNegociosSKD.Modulo13.LogicaMorosos();
                listaMorosoV= lmoroso.ConsultarLosMorosos();
                foreach (DominioSKD.Morosidad valorActual in listaMorosoV)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>" + valorActual.Nombre + "</td>");
                    Response.Write("<td>" + valorActual.Apellido + "</td>");
                    Response.Write("<td>" + valorActual.Cedula + "</td>");
                    Response.Write("<td>" + valorActual.DojoNombre + "</td>");
                    Response.Write("<td>" + valorActual.MeseMoroso + "</td>");
                    Response.Write("<td>" + valorActual.Monto + "</td>");
                }
                
                   %> 
      </tbody>

        </table>
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
			    Lista Morosos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>