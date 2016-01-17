<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_DetalleResultadoCompetencia.aspx.cs" Inherits="templateApp.GUI.Modulo11.M11_DetalleResultadoCompetencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencia
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Detalle Resultados de Competencia
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

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
			    Detalle Resultados de Competencia
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

        <div id="alert" runat="server">
    </div>
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Detalle Resultados de Competencia</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form runat="server" role="form" name="detalle_competencia" id="detalle_competencia" method="get">
<div class="box-body col-sm-12 col-md-12 col-lg-12">
   
    <!--Texboxes FECHA y NOMBRE-->
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
       <br />
       <h3>Fecha del Evento:</h3>
       <asp:TextBox ID="fechaEvento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
       <h3>Nombre del Evento:</h3>
       <asp:TextBox ID="nombreEvento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
       <h3 id="lEspecialidad" runat="server" visible="false">Especialidad del Evento:</h3>
       <asp:TextBox ID="especialidadEvento" runat="server" CssClass="form-control" Enabled="false" Visible="false"></asp:TextBox>
       <h3>Categoria del Evento:</h3>
       <asp:TextBox ID="categoriaEvento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
   </div>

        <!--TABLA ATLETAS Y RESULTADOS DE EXAMENES DE ASCENSO-->
        <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas que compitieron Examen de Ascenso:</h3>
        <table id="tablaCompetidores" class="table table-bordered table-striped dataTable todasLasTablas">
        <thead>
				<tr> 
					<th style="text-align:center">Nombre del Atleta</th>
                    <th style="text-align:center">Puntuacion</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="dataTable"></asp:Literal>
		    </tbody>
            </table>
            </div>
        </div>

                <!--TABLA ATLETAS Y RESULTADOS DE COMPETENCIAS TIPO KATA-->
        <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas que compitieron en Especialidad Kata:</h3>
        <table id="tablaCompetidores2" class="table table-bordered table-striped dataTable todasLasTablas">
        <thead>
				<tr> 
					<th style="text-align:center">Nombre del Atleta</th>
                    <th style="text-align:center">Jurado 1</th>
                    <th style="text-align:center">Jurado 2</th>
                    <th style="text-align:center">Jurado 3</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="dataTable2"></asp:Literal>
		    </tbody>
            </table>
            </div>
        </div>

                <!--TABLA ATLETAS Y RESULTADOS DE COMPETENCIAS TIPO KUMITE-->
        <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas que compitieron en Especialidad Kumite:</h3>
        <table id="tablaCompetidores3" class="table table-bordered table-striped dataTable todasLasTablas">
        <thead>
				<tr> 
                    <th style="text-align:center">Referencia</th>
					<th style="text-align:center">Nombre del Atleta 1</th>
                    <th style="text-align:center">Puntuacion</th>
                    <th style="text-align:center">Nombre del Atleta 2</th>
                    <th style="text-align:center">Puntuacion</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="dataTable3"></asp:Literal>
		    </tbody>
            </table>
            </div>
        </div>

        <script type="text/javascript">
            $(document).ready(function () {
                $('.todasLasTablas').DataTable();

                var table = $('.todasLasTablas').DataTable();
                var comp;
                var tr;

                $('.todasLasTablas tbody').on('click', 'a', function () {
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

</div>

      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
          
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>