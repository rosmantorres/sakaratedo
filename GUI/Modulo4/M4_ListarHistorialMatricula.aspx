<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_ListarHistorialMatricula.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_ListarHistorialMatricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">
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
			    Listar Historial Matricula
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Gestión de Dojos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Listar Historial Matricula
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    <form runat="server" role="form" name="eliminar_matricula" id="eliminar_matricula" method="post" action="M4_ListarHistorialMatricula.aspx?success=2">

        <div id="alert" runat="server">
    </div>

    
    
     <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Historial Matricula</h3>
                    
        </div><!-- /.box-header -->
                 
    <div class="box-body table-responsive">
         <table id="tablaMatricula" class="table table-bordered table-striped dataTable" >
            <thead>
				
                    
                    <asp:Literal runat="server" ID="sta"></asp:Literal>                      
				
			</thead>
			<tbody>
				<asp:Literal runat="server" ID="laTabla"></asp:Literal>           
			    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>
     <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacute;n de Matricula</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar la Matricula:</p>
                    <p id="mat"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
         <a id="btneliminarmatricula" type="button" class="btn btn-primary"  href="M4_ListarHistorialMatricula.aspx?matriculaEliminar=0" >Eliminar</a>
               <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div><!-- /.modal-delete-content -->
        </div><!-- /.modal-delete-dialog -->
      </div><!-- /.modal-delete -->

    </form>
<script type="text/javascript">
    $(document).ready(function () {
        $('#tablaMatricula').DataTable();

        var table = $('#tablaMatricula').DataTable();
        var mat;
        var tr;
        var idEliminar;

        // imprimir mensaje de confirmación de eliminar
        $('a.eliminar_clase').click(function (e) {
            idEliminar = $(this).attr("data-id");
            //   alert(idEliminar);
            $('#btneliminarmatricula').attr("href", "M4_ListarHistorialMatricula.aspx?matriculaElimiar=" + idEliminar);

        });
        $('#tablaMatricula tbody').on('click', 'a.eliminar_clase', function (e) {
            idEliminar = $(this).attr("data-id");
            //   alert(idEliminar);
            $('#btneliminarmatricula').attr("href", "M4_ListarHistorialMatricula.aspx?matriculaEliminar=" + idEliminar);

        });

        $('#tablaMatricula tbody').on('click', 'a', function () {
            if ($(this).parent().hasClass('selected')) {
                mat = $(this).parent().prev().prev().prev().text();
                tr = $(this).parents('tr');//se guarda la fila seleccionada
                $(this).parent().removeClass('selected');

            }
            else {
                mat = $(this).parent().prev().prev().prev().text();
                tr = $(this).parents('tr');//se guarda la fila seleccionada
                table.$('tr.selected').removeClass('selected');
                $(this).parent().addClass('selected');
            }
        });



        $('#modal-delete').on('show.bs.modal', function (event) {
            var modal = $(this)
            modal.find('.modal-title').text('Eliminar Matricula:  ' + mat)
            modal.find('#mat').text(mat)
        })
        $('#btn-eliminar').on('click', function () {
            table.row(tr).remove().draw();//se elimina la fila de la tabla
            $('#modal-delete').modal('hide');//se esconde el modal
        });


    });

        </script>
</asp:Content>

