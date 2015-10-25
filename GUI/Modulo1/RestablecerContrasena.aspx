<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestablecerContrasena.aspx.cs" Inherits="templateApp.GUI.Modulo1.RestablecerContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
      <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
      <meta charset="utf-8"/>
      <title>SKD - Restablecer Contrasena</title>
      <meta name="generator" content="Bootply" />
      <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
      <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
      <!--[if lt IE 9]>
      <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
      <![endif]-->
      <link href="css/styles.css" rel="stylesheet" />
   </head>
   <body>
      <div class="container">
         <div class="row" id="pwd-container">
            <div class="col-md-4"></div>
            <div class="col-md-4">
               <section class="login-form">
                  <form method="post" action="#" role="login">
                      <div id="logo-pass">
                      <img src="../../dist/img/logofinal.png" class="img-responsive" alt=""/>
                        </div>
                     <div>
                        <h1>Restablecer Contraseña</h1>
                     </div>
                      <div>
                        <p>La contraseña debe tener al menos ocho caracteres, una letra mayuscula, una letra minuscula y un numero</p>
                     </div>
                     <input type="password" class="input-lg form-control" name="password1" id="password1" placeholder="Contraseña nueva" autocomplete="off">
                     <input type="password" class="form-control input-lg" name="password2" id="password2" placeholder="Repetir Contraseña" required="" />                    
                     <div class="pwstrength_viewport_progress"></div>
                     <button type="submit" name="go" class="btn btn-lg btn-primary btn-block"><span class="glyphicon glyphicon-refresh" aria-hidden="true"></span> Restablecer</button>
                   </form>  
                </section>
            </div>
            <div class="col-md-4"></div>
         </div>
      </div>
      <!-- script references -->
      <script src="../../bootstrap/js/bootstrap.min.js"></script>
      <script src="js/RestablecerContraseña.js"></script>
   </body>
</html>