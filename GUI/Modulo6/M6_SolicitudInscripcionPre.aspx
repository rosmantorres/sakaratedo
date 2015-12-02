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
        <asp:Label id="labelinfo" Visible="false" runat="server"></asp:Label>
    <form class="form-horizontal" runat="server">
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Seleccion de Dojo</legend>
            <div class="form-group">
                <label for="OrgDrop" class="control-label col-xs-2">Organizacion:</label>
                <div class="col-xs-10">
                    <div class="dropdown" runat="server" id="divBloodDrop">
                        <asp:DropDownList id="OrgDrop" ClientIDMode="Static" cssclass="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged="OrgDropChange" AutoPostBack="true">
                        </asp:DropDownList>
                    </div> 
                </div>
            </div>

            <div class="form-group">
                <label for="selectDojo" class="control-label col-xs-2">Dojo:</label>
                <div class="col-xs-10">
                    <asp:DropDownList id="DojoDrop" ClientIDMode="Static"  cssclass="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
        </fieldset>

        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Datos Personales</legend>
            <div class="form-group">
                <label for="imputNombres" class="control-label col-xs-2">Nombres:</label>
                <div class="col-xs-10">
                    <asp:TextBox ClientIDMode="Static" id="imputNombres" placeholder="ej: Romulo Jose" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="imputApellidos" class="control-label col-xs-2">Apellidos:</label>
                <div class="col-xs-10">
                    <asp:TextBox ClientIDMode="Static" id="imputApellidos" placeholder="ej: Rodriguez Rojas" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="dateNacimiento" class="control-label col-xs-2">Fecha de Nacimiento:</label>
                <div class="col-xs-10">
                    <asp:TextBox ClientIDMode="Static" id="dateNacimiento"  readonly placeholder="ej: dd/mm/aaaa" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="selectNacionalidad" class="control-label col-xs-2">Nacionalidad:</label>
                <div class="col-xs-10">
                    <asp:DropDownList ClientIDMode="Static" id="selectNacionalidad"  cssclass="btn btn-default dropdown-toggle" runat="server">
                        <asp:ListItem Text="Venezolano" Value="Venezolano" />
                        <asp:ListItem value ="Extranjero">Extranjero</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label for="inputCI" class="control-label col-xs-2">Cédula o Pasaporte:</label>
                <div class="col-xs-10">
                    <asp:TextBox ClientIDMode="Static" data-validation="number" id="inputCI" placeholder="ej: 19513536" cssclass="form-control" runat="server" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="selectSex" class="control-label col-xs-2">Sexo:</label>
                <div class="col-xs-10">
                    <label class="radio-inline"><input type="radio" name="selectSex" value="F" checked />Femenino</label>
                    <label class="radio-inline"><input type="radio" name="selectSex" value="M" />Masculino</label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMail" class="control-label col-xs-2">Correo Electrónico:</label>
                <div class="col-xs-10">
                    <input type="email" class="form-control" name="inputMail" id="inputMail" placeholder="ej: pedro@gmail.com" data-validation="email"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputTelf" class="control-label col-xs-2">Teléfono:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputTelf" name="inputTelf" class="form-control"  placeholder="Ej: 02124515454" data-validation="length" data-validation-length="11-11"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMovil" class="control-label col-xs-2">Teléfono Móvil:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputMovil" name="inputMovil" class="form-control" placeholder="Ej: 02124515454" data-validation="length" data-validation-length="11-11"/>
                </div>
            </div>
            <div class="form-group">
                <label for="textareaDir" class="control-label col-xs-2">Direccion de habitación:</label>
                <div class="col-xs-10">
                    <textarea id="textareaDir" name="textareaDir"class="form-control col-xs-2" rows="5"></textarea>
                </div>
            </div>
            <div class="form-group">
                <label for="selectSangre" class="control-label col-xs-2">Tipo de Sangre:</label>
                <div class="col-xs-10">
                    <select id="selectSangre" name="selectSangre" class="btn btn-default dropdown-toggle">
                        <option value ="ON">O-</option>
                        <option value ="OP">O+</option>
                        <option value ="AN">A-</option>
                        <option value ="AP">A+</option>
                        <option value ="BN">B-</option>
                        <option value ="BP">B+</option>
                        <option value ="ABN">AB-</option>
                        <option value ="ABP">AB+</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="textareaAlegias" class="control-label col-xs-2">Alergias:</label>
                <div class="col-xs-10">
                    <textarea id="textareaAlegias" name="textareaAlegias" class="form-control col-xs-2" rows="5"></textarea>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPeso" class="control-label col-xs-2">Peso:</label>
                <div class="col-xs-10">
                    <input data-validation="number" data-validation-allowing="float" type="text" name="inputPeso" id="inputPeso" class="form-control" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputEstatura" class="control-label col-xs-2">Estatura:</label>
                <div class="col-xs-10">
                    <input data-validation="number" data-validation-allowing="float" type="text" id="inputEstatura" name="inputEstatura" class="form-control" required/>
                </div>
            </div>
        </fieldset>
        <fieldset class="scheduler-border" id="sfR">
            <legend class="scheduler-border">Datos del Representante</legend>
            <div class="form-group">
                <label for="imputNombresR" class="control-label col-xs-2">Nombres:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputNombresR" name="imputNombresR" placeholder="ej: Romulo Jose" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="imputApellidosR" class="control-label col-xs-2">Apellidos:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputApellidosR" name="imputApellidosR" placeholder="ej: Rodriguez Rojas" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="dateNacimientoR" class="control-label col-xs-2">Fecha de Nacimiento:</label>
                <div class="col-xs-10">
                    <input type="text" id="dateNacimientoR" name="dateNacimientoR" readonly class="form-control" placeholder="dd/mm/aaaa" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectNacionalidadR" class="control-label col-xs-2">Nacionalidad:</label>
                <div class="col-xs-10">
                    <select id="selectNacionalidadR" name="selectNacionalidadR" class="btn btn-default dropdown-toggle">
                        <option>Venezolana</option>
                        <option>Extrangero</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="inputCRI" class="control-label col-xs-2" >Cédula o Pasaporte:</label>
                <div class="col-xs-10">
                    <input data-validation="number" type="text" class="form-control" id="inputCIR" name="inputCIR" placeholder="ej: 19513536" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectSexR" class="control-label col-xs-2">Sexo:</label>
                <div class="col-xs-10">
                    <label class="radio-inline"><input type="radio" name="selectSexR" value="F" checked/>Femenino</label>
                    <label class="radio-inline"><input type="radio" name="selectSexR" value="M" />Masculino</label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMailR" class="control-label col-xs-2">Correo Electrónico:</label>
                <div class="col-xs-10">
                    <input data-validation="email" type="email" class="form-control" id="inputMailR" name="inputMailR" placeholder="ej: pedro@gmail.com" data-validation="required"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputTelfR" class="control-label col-xs-2">Teléfono:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputTelfR" name="inputTelfR" class="form-control" placeholder="Ej: 02124515454" data-validation="length" data-validation-length="11-11"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMovilR" class="control-label col-xs-2">Teléfono Móvil:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputMovilR" name="inputMovilR" class="form-control" placeholder="Ej: 02124515454" data-validation="length" data-validation-length="11-11"/>
                </div>
            </div>
        </fieldset>
        <fieldset class="scheduler-border" id="sfCE">
            <legend class="scheduler-border">Contacto de Emergencia</legend>
            <div class="form-group">
                <label for="imputNombresCE" class="control-label col-xs-2">Nombres:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputNombresCE" name="imputNombresCE"  placeholder="ej: Romulo Jose" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="imputApellidosCE" class="control-label col-xs-2">Apellidos:</label>
                <div class="col-xs-10">
                    <input class="form-control" id="imputApellidosCE" name="imputApellidosCE" placeholder="ej: Romulo Jose" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="selectSexCE" class="control-label col-xs-2">Sexo:</label>
                <div class="col-xs-10">
                    <label class="radio-inline"><input type="radio" name="selectSexCE" value="F" checked/>Femenino</label>
                    <label class="radio-inline"><input type="radio" name="selectSexCE" value="M" />Masculino</label>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMailCE" class="control-label col-xs-2">Correo Electrónico:</label>
                <div class="col-xs-10">
                    <input data-validation="email" type="email" class="form-control" id="inputMailCE" name="inputMailCE" placeholder="ej: pedro@gmail.com" data-validation="required"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputTelfCE" class="control-label col-xs-2">Teléfono:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputTelfCE" name="inputTelfCE" class="form-control" placeholder="Ej: 02124515454" data-validation="length" data-validation-length="11-11"/>
                </div>
            </div>
            <div class="form-group">
                <label for="inputMovilCE" class="control-label col-xs-2">Teléfono Móvil:</label>
                <div class="col-xs-10">
                    <input type="text" id="inputMovilCE" name="inputMovilCE" class="form-control" placeholder="Ej: 02124515454" data-validation="length" data-validation-length="11-11"/>
                </div>
            </div>
        </fieldset>
        <div class="box-footer">
            <asp:Button class="btn btn-primary" id="BtnSubmit" text="Enviar" OnClick="ProsesarSolicitud" runat="server" />
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
            $("#dateNacimientoR").datepicker({
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
                    $("#sfCE").attr("disabled", "disabled");
                } else {
                    $("#sfCE").show();
                    $("#sfR").hide();
                    $("#sfR").attr("disabled", "disabled");
                }
            });
        });

    </script> 
</body>
</html>
