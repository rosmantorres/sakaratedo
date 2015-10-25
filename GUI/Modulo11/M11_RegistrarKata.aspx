<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_RegistrarKata.aspx.cs" Inherits="templateApp.GUI.Modulo11.M11_RegistrarKata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencias</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Resultados de Competencias</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Agregar Resultados Kata</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_asistencia" id="agregar_asistencia" method="post" action="#">
<div class="box-body col-sm-12 col-md-12 col-lg-12">

    <!--COMBO CATEGORIA-->
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
               <li><a href="#">Especialidad #1</a></li>
               <li><a href="#">Especialidad #2</a></li>
               <li><a href="#">Especialidad #3</a></li>
               <li><a href="#">Especialidad #4</a></li>
          </ul>
        </div>
      </div>
    </div>
   <br/>

            <script type="text/javascript">

                //script que hace el manejo del datepicker
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
         <a id="btn-agregarComp" class="btn btn-primary" type="submit" href="M10_ListarAsistenciaEventos.aspx" onclick="return checkform();">Agregar</a>
         &nbsp;&nbsp
         <a class="btn btn-default"> Volver</a>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>