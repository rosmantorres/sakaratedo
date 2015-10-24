<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M6_CrearUsuarioPre.aspx.cs" Inherits="templateApp.GUI.Modulo6.M6_CrearUsuarioPre" %>

<!DOCTYPE html>

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
         Creación de Usuario
        <br />
            <small> 
            Crear un usuario para ingresar en el sistema.
            </small>
	</h1>
    </section>
    <div class="box box-body">
    <form class="form-horizontal">
        <fieldset class="scheduler-border">
            <legend class="scheduler-border">Usuario del Sistema</legend>
            <div class="form-group">
                <label for="imputUserName" class="control-label col-xs-2">Nombre de usuario:</label>
                <div class="col-xs-10">
                    <input type="text" class="form-control" id="imputUserName"  placeholder="ej: eltercera" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="imputPassword" class="control-label col-xs-2">Contraseña:</label>
                <div class="col-xs-10">
                    <input type="password" class="form-control" id="imputPassword"  placeholder="" required/>
                </div>
            </div>
            <div class="form-group">
                <label for="imputPasswordRe" class="control-label col-xs-2">Repetir contraseña:</label>
                <div class="col-xs-10">
                    <input type="password" class="form-control" id="imputPasswordRe"  placeholder="" required/>
                </div>
            </div>
            <div class="box-footer">
                <button type="submit" class="btn btn-primary"> Guardar </button>
                <button type="button" class="btn btn-default"> Volver </button>
            </div>
        </fieldset>
    </form>
    </div>
</body>
</html>

