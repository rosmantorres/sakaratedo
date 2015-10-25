<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M10_AgregarAsistenciaEventos.aspx.cs" Inherits="templateApp.GUI.Modulo10.M10_AgregarAsistenciaEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Asistencias a Eventos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Asistencias a Eventos</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Agregar Asistencia</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_asistencia" id="agregar_asistencia" method="post" action="#">
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

    <!--COMBO 1-->
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

    <!--COMBO 2-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Categoria:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
        <div class="btn-group">
          <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Seleccionar Categoria <span class="caret"></span>
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
   <br/>

   <div class="form-group">
      <div id="div-org" class="col-sm-12 col-md-12 col-lg-12">
         <h3>Inscritos:</h3>
         <select multiple="multiple" name="org_primary" size="4" class="form-control select select-primary select-block mbl">
            <option value="Organización 1">Atleta #1</option>
            <option value="Organización 2">Atleta #2</option>
            <option value="Organización 3">Atleta #3</option>
            <option value="Organización 1">Atleta #4</option>
            <option value="Organización 2">Atleta #5</option>
            <option value="Organización 3">Atleta #6</option>
         </select>
         <br />
         <div class="text-center padding-small">
            <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-down" onclick="agregarOrg()"></button>
            <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-up" onclick="eliminarOrg()"></button>
         </div>
         <h3>Asistieron:</h3>
         <select multiple="multiple" name="org_secondary" size="4" class="form-control select select-primary select-block mbl"></select>
         <br />
         <br />
      </div>
   </div>


    <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>No Asistieron:</h3>
       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					
					<th >Nombre</th>
					<th>Nota</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					
					<td>Atleta 1</td>
					<td>Planilla 1</td>
				
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                     </td>
                </tr>
                <tr>
                    
					<td>Atleta 2</td>
					<td>Planilla 2</td>
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                     </td>
				</tr><tr>
                    
					<td>Atleta 3</td>
					<td>Planilla 3</td>
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                     </td>
                </tr>
                <tr>
                    
					<td>Atleta 4</td>
					<td>Planilla 4</td>
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                     </td>
                </tr>
                <tr>
                
					<td>Atleta 5</td>
					<td>Planilla 5</td>
					
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
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
						<h4 class="modal-title">Información detallada de Inasistencias</h4>
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

</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-agregarComp" class="btn btn-primary" type="submit" href="M12_ListarCompetencias.aspx?eliminacionSuccess=1" onclick="return checkform();">Agregar</a>
         &nbsp;&nbsp
         <a class="btn btn-default" Volver</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>

