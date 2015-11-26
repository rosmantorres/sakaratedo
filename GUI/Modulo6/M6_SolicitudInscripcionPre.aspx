<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M6_SolicitudInscripcionPre.aspx.cs" Inherits="templateApp.GUI.Modulo6.M6_SolicitudInscripcionPre" %>

<!DOCTYPE html>
<!-- Pagina para la generacion de una nueva solicitud de inscripcion por parte de un prospecto -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>SAKARATEDO | Solicitud de inscripción</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="../../bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
     <!-- DATA TABLES -->
     <link href="../../plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />

    <!-- AdminLTE Skins. Choose a skin from the css/skins
    folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../../dist/css/skins/_all-skins.min.css">

     <!-- jQuery 2.1.4 -->
     <script src="../../plugins/jQuery/jQuery-2.1.4.min.js"></script>
      
    <!-- Bootstrap 3.3.5 -->
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <!-- SlimScroll -->
    <script src="../../plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../../plugins/fastclick/fastclick.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../../dist/js/app.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../../dist/js/demo.js"></script> 

    <!-- DATA TABES SCRIPT -->
    <script src="../../plugins/datatables/jquery.dataTables.js" type="text/javascript"></script>
    <script src="../../plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>

    <script src="../../plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="../../plugins/datepicker/locales/bootstrap-datepicker.es.js"></script>
    <link href="../../plugins/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery-form-validator/2.2.8/jquery.form-validator.min.js"></script>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->  
</head>
<body>

    <div class="wrapper">

      <header class="main-header">
        <!-- Logo -->
        <a href="Inicio.aspx" class="logo" style="background-color:#080B0C">
          <!-- mini logo for sidebar mini 50x50 pixels -->
          <span class="logo-mini"><b>SKD</b></span>
          <!-- logo for regular state and mobile devices -->
          <span class="logo-lg" style="font-size:15px;font-family:Helvetica;color: #ffffff"><img src="/dist/img/logofinal.png" style="max-width:80px;margin-top:3px;margin-left:0px" class="pull-left" />SA-KARATEDO</span>
        </a>
        <nav class="navbar navbar-static-top" role="navigation" style="background-color:#080B0C">
        </nav>
       </header>
    </div>


    <section class="content-header">
        <h1 class="page-header">
        Solicitud de inscripción
        <br />
            <small> 
            Formulario para la solicitud de inscripcion en un dojo.
            </small>
	</h1>
    </section>
    <div class="box box-body">
    <form class="form-horizontal">
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Seleccion de Dojo</legend>
            <div class="form-group">
                <label for="selectOrganizacion" class="control-label col-xs-2">Organizacion:</label>
                <div class="col-xs-10">
                    <button id="selectOrganizacion" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    Seleccione una Organizacion <span class="caret"></span>
                    </button>
                    <ol id="selectOrganizacionOpts" class="dropdown-menu" role="menu"  onclick="">
                        <li value="1"><a href="#">Organizacion 1</a></li>
                        <li value="2"><a href="#">Organizacion 1</a></li>
                        <li value="2"><a href="#">Organizacion 1</a></li>
                    </ol>
                </div>
            </div>

            <div class="form-group">
                <label for="selectDojo" class="control-label col-xs-2">Dojo:</label>
                <div class="col-xs-10">
                <button id="selectDojo" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    Seleccione un Dojo <span class="caret"></span>
                    </button>
                    <ol id="selectDojoOpts" class="dropdown-menu" role="menu"  onclick="">
                        <li value="1"><a href="#">Dojo 2</a></li>
                        <li value="2"><a href="#">Dojo 2</a></li>
                        <li value="2"><a href="#">Dojo 3</a></li>
                    </ol>
                </div>
            </div>
        </fieldset>

        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Datos Personales</legend>
            <div class="form-group">
                <label for="imputNombres" class="control-label col-xs-2">Nombres:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputNombres"  placeholder="ej: Romulo Jose" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="imputApellidos" class="control-label col-xs-2">Apellidos:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputApellidos" placeholder="ej: Romulo Jose" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="dateNacimiento" class="control-label col-xs-2">Fecha de Nacimiento:</label>
                <div class="col-xs-10">
                    <input type="text" id="dateNacimiento" readonly class="form-control" placeholder="dd/mm/aaaa" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectNacionalidad" class="control-label col-xs-2">Nacionalidad:</label>
                <div class="col-xs-10">
                    <button id="selectNacionalidad" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    Seleccione una Nacionalidad <span class="caret"></span>
                    </button>
                    <ol id="selectNacionalidadOpts" class="dropdown-menu" role="menu"  onclick="">
                        <li value="1"><a href="#">Venezolano</a></li>
                        <li value="2"><a href="#">Extranjero</a></li>
                    </ol>
                </div>
            </div>
            <div class="form-group">
                <label for="inputCI" class="control-label col-xs-2">Cédula o Pasaporte:</label>
                <div class="col-xs-10">
                    <input data-validation="number" type="text" class="form-control" id="inputCI" placeholder="ej: 19513536" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectSex" class="control-label col-xs-2">Sexo:</label>
                <div class="col-xs-10">
                    <label class="radio-inline"><input type="radio" name="selectSex" checked>Femenino</label>
                    <label class="radio-inline"><input type="radio" name="selectSex">Masculino</label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMail" class="control-label col-xs-2">Correo Electrónico:</label>
                <div class="col-xs-10">
                    <input type="email" class="form-control" id="inputMail" placeholder="ej: pedro@gmail.com" data-validation="email"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputTelf" class="control-label col-xs-2">Teléfono:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputTelf" class="form-control"  placeholder="Ej: (0212)451-54-54" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMovil" class="control-label col-xs-2">Teléfono Móvil:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputMovil" class="form-control" placeholder="Ej: (0212)451-54-54" data-validation="custom" data-validation-regexp="((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})"/>
                </div>
            </div>
            <div class="form-group">
                <label for="textareaDir" class="control-label col-xs-2">Direccion de habitación:</label>
                <div class="col-xs-10">
                    <textarea id="textareaDir" class="form-control col-xs-2" rows="5"></textarea>
                </div>
            </div>
            <div class="form-group">
                <label for="selectSangre" class="control-label col-xs-2">Tipo de Sangre:</label>
                <div class="col-xs-10">
                <button id="selectSangre" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    Seleccione un tipo de sangre <span class="caret"></span>
                    </button>
                    <ol id="selectSangreOpts" class="dropdown-menu" role="menu"  onclick="">
                        <li value="1"><a href="#">O-</a></li>
                        <li value="2"><a href="#">O+</a></li>
                        <li value="3"><a href="#">A-</a></li>
                        <li value="4"><a href="#">A+</a></li>
                        <li value="5"><a href="#">B-</a></li>
                        <li value="6"><a href="#">B+</a></li>
                        <li value="7"><a href="#">AB-</a></li>
                        <li value="8"><a href="#">AB+</a></li>
                    </ol>
                </div>
            </div>
            <div class="form-group">
                <label for="textareaAlegias" class="control-label col-xs-2">Alergias:</label>
                <div class="col-xs-10">
                    <textarea id="textareaAlegias" class="form-control col-xs-2" rows="5"></textarea>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPeso" class="control-label col-xs-2">Peso:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputPeso" class="form-control"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEstatura" class="control-label col-xs-2">Estatura:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputEstatura" class="form-control"/>
                </div>
            </div>
        </fieldset>
        <fieldset class="scheduler-border" id="sfR">
            <legend class="scheduler-border">Datos del Representante</legend>
            <div class="form-group">
                <label for="imputNombresR" class="control-label col-xs-2">Nombres:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputNombresR"  placeholder="ej: Romulo Jose" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="imputApellidosR" class="control-label col-xs-2">Apellidos:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputApellidosR" placeholder="ej: Rodriguez Rojas" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="dateNacimientoR" class="control-label col-xs-2">Fecha de Nacimiento:</label>
                <div class="col-xs-10">
                    <input type="text" id="dateNacimientoR" readonly class="form-control" placeholder="dd/mm/aaaa" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectNacionalidadR" class="control-label col-xs-2">Nacionalidad:</label>
                <div class="col-xs-10">
                    <select id="selectNacionalidadR" class="form-control">
                        <option>Venezolana</option>
                        <option>Extrangero</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="inputCRI" class="control-label col-xs-2" >Cédula o Pasaporte:</label>
                <div class="col-xs-10">
                    <input data-validation="number" type="text" class="form-control" id="inputCIR" placeholder="ej: 19513536" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectSexR" class="control-label col-xs-2">Sexo:</label>
                <div class="col-xs-10">
                    <label class="radio-inline"><input type="radio" name="selectSexR" checked>Femenino</label>
                    <label class="radio-inline"><input type="radio" name="selectSexR">Masculino</label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMailR" class="control-label col-xs-2">Correo Electrónico:</label>
                <div class="col-xs-10">
                    <input data-validation="email" type="email" class="form-control" id="inputMailR" placeholder="ej: pedro@gmail.com" data-validation="required"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputTelfR" class="control-label col-xs-2">Teléfono:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputTelfR" class="form-control" placeholder="Ej: (0212)451-54-54"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMovilR" class="control-label col-xs-2">Teléfono Móvil:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputMovilR" class="form-control" placeholder="Ej: (0212)451-54-54"/>
                </div>
            </div>
        </fieldset>
        <fieldset class="scheduler-border" id="sfCE">
            <legend class="scheduler-border">Contacto de Emergencia</legend>
            <div class="form-group">
                <label for="imputNombresCE" class="control-label col-xs-2">Nombres:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputNombresCE"  placeholder="ej: Romulo Jose" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="imputApellidosCE" class="control-label col-xs-2">Apellidos:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputApellidosCE" placeholder="ej: Romulo Jose" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectSexCE" class="control-label col-xs-2">Sexo:</label>
                <div class="col-xs-10">
                    <label class="radio-inline"><input type="radio" name="selectSexCE" checked>Femenino</label>
                    <label class="radio-inline"><input type="radio" name="selectSexCE">Masculino</label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMailCE" class="control-label col-xs-2">Correo Electrónico:</label>
                <div class="col-xs-10">
                    <input data-validation="email" type="email" class="form-control" id="inputMailCE" placeholder="ej: pedro@gmail.com" data-validation="required"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputTelfCE" class="control-label col-xs-2">Teléfono:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputTelfCE" class="form-control" placeholder="Ej: (0212)451-54-54"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMovilCE" class="control-label col-xs-2">Teléfono Móvil:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputMovilCE" class="form-control" placeholder="Ej: (0212)451-54-54"/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectParentescoCE" class="control-label col-xs-2">Parentesco:</label>
                <div class="col-xs-10">
                    <select id="selectParentescoCE" class="form-control">
                        <option>Padre / Madre</option>
                        <option>Abuelo / Abuela</option>
                        <option>Otro</option>
                    </select>
                </div>
            </div>
        </fieldset>
        <div class="box-footer">
            <button type="submit" class="btn btn-primary"> Enviar </button>
            <button type="button" class="btn btn-default"> Cancelar </button>
        </div>
    </form>
    </div>
    <!-- </div> -->
    <script type="text/javascript">
        $(document).ready(function () {
            $("#dateNacimiento").datepicker({
                format: 'dd/mm/yyyy',
                language: 'es'
            });
            $.validate({
                lang: 'es'
            });
            $("#sfCE").hide();
            $("#sfR").hide();
            $("#dateNacimiento").change(function () {
                var d1 = $("#dateNacimiento").val().split("/");
                var dat1 = new Date(d1[2], d1[1] - 1, d1[0]);
                var dat2 = new Date()
                if (((dat2 - dat1) / (1000 * 60 * 60 * 24 * 360)) < 18) {
                    $("#sfR").show();
                    $("#sfCE").hide();
                } else {
                    $("#sfCE").show();
                    $("#sfR").hide();
                }
            });
        });

    </script> 
</body>
</html>
