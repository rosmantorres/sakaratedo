<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_ModificarResultadoCompetencia.aspx.cs" Inherits="templateApp.GUI.Modulo11.M11_ModificarResultadoCompetencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencia
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Modificar Resultados de Competencia
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
			    Modificar Resultados de Competencia
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
   <h3 class="box-title">Modificar Resultado</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_asistencia" id="agregar_asistencia" method="post" action="#">
<div class="box-body col-sm-12 col-md-12 col-lg-12">
   
    
   <!--COMBO ESPECIALIDAD-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Especialidad:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Seleccionar Especialidad <span class="caret"></span>
          </button>
          <ul class="dropdown-menu">
               <li><a href="#">Kata</a></li>
               <li><a href="#">Kumite</a></li>
               <li><a href="#">Ascenso</a></li>
          </ul>
        </div>
      </div>
    </div>

    <!--COMBO CATEGORIA-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Categoria:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Seleccionar Categoria <span class="caret"></span>
          </button>
          <ul class="dropdown-menu">
               <li><a href="#">Categoria 1</a></li>
               <li><a href="#">Categoria 2</a></li>
              <li><a href="#">Categoria 3</a></li>
          </ul>
        </div>
      </div>
    </div>


    <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas que compitieron:</h3>
       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                    <th style="text-align:center">Cédula</th>
					<th style="text-align:center">Nombre del Atleta</th>
                    <th style="text-align:center">Puntaje</th>
					<th style="text-align:center">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
                    <td class="id">1</td>
					<td>Nestor Betancourt</td>
                    <td> 12</td>
                  
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_ModificarAscenso.aspx"></a>
                     </td>
                </tr>
                <tr>
                     <td class="id">2</td>
                    <td>Eduardo Cruz</td>
                     <td>20</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_ModificarKata.aspx"></a>
                     </td>
				</tr><tr>
                    <td class="id">3</td>
                    <td>Israel Rojer</td>
                     <td>36</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_ModificarKumite.aspx"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">4</td>
                    <td>Jose Madrigal</td>
                     <td>5</td>		
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_ModificarKumite.aspx"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">5</td>
                    <td>Paul Lopez</td>
                    <td> 26</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_ModificarKata.aspx"></a>
                    </td>
                </tr>
			    </tbody>
    </table>
            </div>
        </div>

        		<div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Información del Puntaje</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<p>
									El Puntaje fue...
								</p>
							</div>
						</div>
					</div>
				</div>
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

                });


                $(document).ready(function () {
                    $('#datePicker')
                        .datepicker({
                            format: 'mm/dd/yyyy'
                        })
                        .on('changeDate', function (e) {
                            // Revalidate the date field
                            $('#eventForm').formValidation('revalidateField', 'date');
                        });

                    $('#eventForm').formValidation({
                        framework: 'bootstrap',
                        icon: {
                            valid: 'glyphicon glyphicon-ok',
                            invalid: 'glyphicon glyphicon-remove',
                            validating: 'glyphicon glyphicon-refresh'
                        },
                        fields: {
                            name: {
                                validators: {
                                    notEmpty: {
                                        message: 'The name is required'
                                    }
                                }
                            },
                            date: {
                                validators: {
                                    notEmpty: {
                                        message: 'The date is required'
                                    },
                                    date: {
                                        format: 'MM/DD/YYYY',
                                        message: 'The date is not a valid'
                                    }
                                }
                            }
                        }
                    });
                });



        </script>

</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-modificarResul" class="btn btn-primary" type="submit" href="M11_ListarResultadoCompetencia.aspx?eliminacionSuccess=2" onclick="">Aceptar</a>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M11_ListarResultadoCompetencia.aspx"> Cancelar</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>