<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_ProgramaKyu.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_ProgramaKyu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Programa T&eacutecnico por Kyu</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Programa T&eacutecnico Inicial</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">


    &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-exportarComp" class="btn btn-primary" type="submit" href="Pdf/programa_tecnico.pdf?eliminacionSuccess=1" onclick="return checkform();">Exportar a PDF</a>
         &nbsp;&nbsp


    <div class="box-body table-responsive">
            <div class="box-body table-responsive">
    <table id="example" class="table table-bordered table-striped dataTable">
       <thead>
              <tr>
                   <th style="text-align:center">Nombre</th>
                  <th style="text-align:center">Tipo de T&eacutenica</th>
                   <th style="text-align:center">T&eacutenica</th>
                   <th style="text-align:center">Descripci&oacuten</th>
                 

              </tr>
        </thead>
     <tbody>
              <tr>	
                   <td style="text-align:center">Keri (Geri) Waza</td>
                   <td style="text-align:center">T&eacutenicas de Patadas</td>
                   <td style="text-align:center">MAE KOSHI GERI CHUDAN</td>
                  <td style="text-align:center">PATADA FRONTAL BOLA DELANTERA DEL PIE</td>
                                     
               </tr>    
         <tr>	
                   <td style="text-align:center">Uke Waza</td>
                   <td style="text-align:center">T&eacutenicas de Defensas</td>
                   <td style="text-align:center">YODAN AGE UKE</td>
                  <td style="text-align:center">ESQUIVACION DE LA PARTE SUPERIOR</td>
                                     
               </tr>    
        <tr>	
                   <td style="text-align:center">Uchi Waza</td>
                   <td style="text-align:center">T&eacutenicas de Ataques</td>
                   <td style="text-align:center">SEIKEN OI ZUKI</td>
                  <td style="text-align:center">GOLPE CON APOYO DE LA PIERNA</td>
                                     
               </tr>                              
                        
      </tbody>

        </table>
    </div>
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
            <li>
			    <a href="M13_KyuPrograma.aspx">Kyu</a> 
		    </li>      
            
		    <li class="active">
			    Programa Técnico Kyu
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>