<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_AgregarResultadoCompetencia.aspx.cs" Inherits="templateApp.GUI.Modulo11.M11_AgregarResultadoCompetencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencias</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Resultados de Competencias</asp:Content>

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
			    Agregar Resultados de Competencias
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Agregar Resultado</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_resultado" id="agregar_resultado" method="post" action="#">
<div class="box-body col-sm-12 col-md-12 col-lg-12">
   
    <!--Date picker FECHA-->
    <div class="form-group col-sm-10 col-md-10 col-lg-10">
        <br />
        <h3>Fecha del Evento:</h3>
        <div class="input-group input-append date" id="datePicker">
        <input type="text" class="form-control" name="date" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
    </div>

    <!--COMBO EVENTO-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Eventos Disponibles:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Seleccionar Evento <span class="caret"></span>
          </button>
          <ul class="dropdown-menu">
               <li><a href="#">Evento #1</a></li>
               <li><a href="#">Evento #2</a></li>
               <li><a href="#">Evento #3</a></li>
               <li><a href="#">Evento #4</a></li>
          </ul>
        </div>
      </div>
    </div>

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
         
          </ul>
        </div>
      </div>
    </div>

        <!--COMBO CATEGORIA-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Categoria:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true">
            Seleccionar Categoria<span class="caret"></span>
          </button>
          <ul class="dropdown-menu">
               <li><a href="#">Categoria #1</a></li>
               <li><a href="#">Categoria #2</a></li>
               <li><a href="#">Categoria #3</a></li>
               <li><a href="#">Categoria #4</a></li>
          </ul>
        </div>
      </div>
    </div>

    <!--DATATABLE ATLETAS-->
    <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas a Competir:</h3>
       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					
					<th >Id</th>
					<th>Atleta</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					
					<td>1</td>
					<td>Jorge Gomez</td>
				
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_AgregarAscenso.aspx"></a>
                     </td>
                </tr>
                <tr>
                    
					<td>2</td>
					<td>Eduardo Cruz</td>
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_AgregarKata.aspx"></a>
                     </td>
				</tr><tr>
                    
					<td>3</td>
					<td>Romulo Betancourt</td>
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_AgregarKumite.aspx"></a>
                     </td>
                </tr>
                <tr>
                    
					<td>4</td>
					<td>Guillermo Perez</td>
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_AgregarKumite.aspx"></a>
                     </td>
                </tr>
                <tr>
                
					<td>5</td>
					<td>Juan Bastidas</td>
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M11_AgregarKata.aspx"></a>
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
						<h4 class="modal-title">Información detallada del Atleta</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<p>
									Nombre, Apellido, Sexo, cinta... etc
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

    <!--LISTA POSICIONES-->
     <div class="form-group">
      <div id="div-org" class="col-sm-12 col-md-12 col-lg-12">
         <h3>Posiciones:</h3>
         <select multiple="multiple" name="org_primary" size="4" class="form-control select select-primary select-block mbl">
            <option value="Organización 1">Atleta #1</option>
            <option value="Organización 2">Atleta #2</option>
            <option value="Organización 3">Atleta #3</option>
            <option value="Organización 1">Atleta #4</option>
            <option value="Organización 2">Atleta #5</option>
            <option value="Organización 3">Atleta #6</option>
         </select>
      </div>
   </div>

</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-agregarComp" class="btn btn-primary" type="submit" href="M11_ListarResultadoCompetencia.aspx" onclick="return checkform();">Agregar</a>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M11_ListarResultadoCompetencia.aspx"> Cancelar</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>