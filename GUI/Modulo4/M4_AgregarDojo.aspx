<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_AgregarDojo.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_AgregarDojo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
        <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="M4_js/M4_Alert.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
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
			    Agregar Dojo
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Dojos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Dojo
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
      <%--Alerta de falta de contenido--%>
 <div id="alert"  >
    <div id="contenido_alerta"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div>
 </div>
    <%--Fin de alerta de falta de contenido--%>

        <%--Alerta de confirmación--%>
 <div id="alert_confirmacion"  >
    <div id="Div2"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div>
 </div>    
    <%--fin de Alerta de confirmación--%>

       <!-- Elementos generales del formulario -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Nuevo Dojo</h3>
                </div><!--Encabezado del formulario -->

                    <!-- Comienzo del formulario -->
                <form role="form" name="agregar_dojo" id="agregar_dojo" method="post" action="../Modulo6/M6_NuevoAdmin.aspx">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                       <div class="box-body col-sm-10 col-md-10 col-lg-10 ">
                    <img src="Imagenes\Aikido.png" class="img-thumbnail" alt="Logo Dojo" width="200" height="100" style="margin: 5px 900px 5px 5px;float: left; " > 
                        <input id="input-1a" type="file" class="file"  >
                           </div>
                      <br/>
                    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                      <p><b>Rif Del Dojo:</b></p>
                      <input type="text" name="rifDojo" id="rifDojo" placeholder="*RIF" class="form-control" value="">
                    </div>
                      <br/>
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Nombre Del Dojo:</b></p>
                      <input type="text" name="nombreDojo" id="nombreDojo" placeholder="*Nombre" class="form-control" value="">
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Número Telefónico:</b></p>
                      <input type="text" name="numeroDojo" id="numeroDojo" placeholder="*Número-Telefono" class="form-control" value="">
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Email:</b></p>
                      <input type="email" name="emailDojo" id="emailDojo" placeholder="*Email" class="form-control" value="">
                    </div>
                      <br/>

                <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 1-->
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <p><b>Estado:</b></p>
                         <select id="Select1" class="form-control" runat="server">
                               <option value="1" >Estado 1</option>
                               <option value="2" >Estado 2</option>
                               <option value="3" >Estado 3</option>
                               <option value="4" >Estado 4</option>
                        </select>            
                      </div>
                </div>
                      <br/>


                 <div class="form-group col-sm-12 col-md-12 col-lg-12"><!--COMBO 2-->
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <p><b>Ciudad:</b></p>
                        <select id="Select2" class="form-control" runat="server">
                               <option value="1" >ciudad1</option>
                               <option value="2" >ciudad2</option>
                               <option value="3" >ciudad3</option>
                            <option value="4" >ciudad4</option>
                        </select>            
                      </div>
                </div>
                      <br/>
                          <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>DIreccion Dojo:</b></p>
                      <input type="text" name="nombreDojo" id="direDojo" placeholder="Direccion" class="form-control" value="">
                    </div>
                      <br/>

                 <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Dirección:</b></p>
                      <div id="googleMap" style="width:500px;height:250px;"></div><br/>
                    </div>
                      <br/>
                      
                <div class="form-group">
                    <div class="col-sm-10 col-md-10 col-lg-10">
                        <p><b>Elegir Administrador:</b></p>
                        <label class="radio-inline">
                        <input type="radio" name="radioTipo"  id="input_nuevo"  onclick="return fillCodigoTextField();"/>Nuevo</label>
                        <label class="radio-inline">
                        <input type="radio" name="radioTipo" checked="checked" id="input_existente" onclick="return fillCodigoTextField();" />Existente</label>
                    </div>
                </div>
                   <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Estilo:</b></p>
                      <input type="text" name="estiloDojo" id="estiloDojo" class="form-control" readonly="readonly" value="Estilo 1">
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Reglamento Interno:</b></p>
                      <textarea class="form-control" id="reglaDojo" name="reglaDojo">1. Regla 1
2. Regla 2
3. Regla 3
4. Regla 4</textarea>
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Status:</b></p>
                     <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox"  data-toggle="toggle" data-on="Activo" data-off="Inactivo">
                        </a>
                    </div>
                  
                    
                   

                    <!--Date picker FECHA-->
    <div class="form-group col-sm-4 col-md-3 col-lg-4">
          <p><b>      Matricula:</b></p>
        <br />
        <p>Fecha de vigencia</p>
        <div class="input-group input-append date" id="datePickerfecha">
        <input type="text" class="form-control" name="date" />
        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
    </div>



                    
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         <p><b>Tipo Mensualidad:</b></p>
                        <select id="tipo_mensualidad" class="form-control" runat="server">
                               <option value="1" >Anual</option>
                               <option value="2" >Semestral</option>
                               <option value="3" >Trimestral</option>
                            <option value="4" >Mensual</option>
                        </select>            
                      </div>
                      <br/>

  
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Monto Matricula:</b></p>
                      <input type="text" name="cmatriDojo" id="cmatriDojo" placeholder="*Costo Matricula" class="form-control" value="">
                    </div>
            </div>  <!--Fin del listado del formulario -->
   

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-agregarDojo" style="align-content:flex-end" class="btn btn-primary" type="submit">Agregar</button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M4_ListarDojos.aspx">Cancelar</a>
                  </div>
                </form>
              </div><!-- Fin del formulario-->
    
    
      <!-- Declaración de las alertas-->
     <script type="text/javascript">

         $(document).ready(function () {
             $('#datePickerfecha')
             .datepicker({
                 format: 'mm/dd/yyyy'
             })
             .on('changeDate', function (e) {
                 // Revalidate the date field
             });
         });

         $(document).ready(function () {
             $("#alert").hide();
             $("#alert").attr("class", "alert alert-error alert-dismissible");
             $("#alert").attr("role", "alert");

             $("#alert_confirmacion").hide();
             $("#alert_confirmacion").attr("class", "alert alert-success alert-dismissible");
             $("#alert_confirmacion").attr("role", "alert");
             var valor = "";
             var estado = false;


             // Alertas de cada uno de los campos vacios y los que pertenecen a numéricos

             $("#btn-agregarDojo").click(function (evento) {
                 //  alert($("#nombre_articulo").val());
                 if ($("#rifDojo").val() == "") {
                     valor = "El campo Nombre  es obligatorio </br>";
                     estado = true;
                 }
                 if ($("#emailDojo").val() == "") {
                     valor = valor + "El campo Rif es obligatorio </br>";
                     estado = true;
                 }





                 if ($("#input-1a").val() == "") {
                     valor = valor + "La imagen es obligatoria </br>";
                     estado = true;
                 } else {
                     if ($("#input-1a").val().split(".")[1] != "jpg") {

                         valor = valor + "Se acepta solo imagenes con formato .jpg </br>";
                         estado = true;
                     }

                 }


                 if ($("#numeroDojo").val() == "") {
                     valor = valor + "El campo Telefono es obligatorio </br>";
                     estado = true;
                 }
                 else {
                     if ((isNaN($("#numeroDojo").val()))) {
                         valor = valor + "El campo Telefono  es num&eacuterico </br>";
                         estado = true;
                     }
                 }

                 if ($("#cmatriDojo").val() == "") {
                     valor = valor + "El campo Costo de Matricula es obligatorio </br>";
                     estado = true;
                 }
                 else {
                     if ((isNaN($("#cmatriDojo").val()))) {
                         valor = valor + "El campo Costo de Matricula  es num&eacuterico </br>";
                         estado = true;
                     }
                 }
                 //aparición de las alertas de pantalla

                 if (estado) {
                     $("#alert_confirmacion").hide();
                     $("#alert").html(valor);
                     $("#alert").fadeIn(2000);
                     valor = "";
                     estado = false;
                     evento.preventDefault();

                 }



             });

         });

  </script>
    
    </asp:Content>
