<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_AgregarDojo.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_AgregarDojo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="M4_js/M4_Alert.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
    <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
    
    
    
    
    
    
    
    <script type="text/javascript">
        function initialize() {
            var latitude;
            var longitude;
            var latilong;
            var mapProp = {
                center: new google.maps.LatLng(10.5000, -66.9167),
                zoom: 5,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
            var marker;// variable marker que contiene la longitud y latitud del punto del mapa
            // funcion que setea un marker si se clickea la primera vez sino borra el anterior y reescribe con el nuevo
            function placeMarker(location) {
                if (marker) { // si existe el marcador reemplaza solamente los valores y borra el otro
                    marker.setPosition(location);
                    var latilong = marker.getPosition();//obtener elemento posicion
                    var latitude = latilong.lat();// obtener latitud de la posicion
                    var longitude = latilong.lng();// obtener longitud de la posicion
                    document.getElementById("txtLAT").value = latitude;// ubicar input latitud html y setear valor
                    document.getElementById("txtLONG").value = longitude;// ubicar input longitud html y setear valor
                } else { // crear nuevo marcador
                    marker = new google.maps.Marker({
                        position: location,
                        map: map
                    });
                    var latilong = marker.getPosition(); //Obtener elemento posicion
                    var latitude = latilong.lat();// obtener latitud de la posicion
                    var longitude = latilong.lng();// obtener longitud de la posicion
                    document.getElementById("txtLAT").value = latitude; // ubicar input latitud html y setear valor
                    document.getElementById("txtLONG").value = longitude; // ubicar input longitud html y setear valor
                }
            }
            // llamada la funcion placke marker cuando ocurre un evento de click
            google.maps.event.addListener(map, 'click', function (event) {
                placeMarker(event.latLng);
            });
        }
        google.maps.event.addDomListener(window, 'load', initialize);
   </script>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    




</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

    <%-- INICIO_BREADCRUMBS --%>
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
	<%-- FIN_BREADCRUMBS --%>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Dojos
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Dojo
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
      
    <%-- INICIO DE ALERTA DE FALTA DE CONTENIDO --%>
        <div id="alert"  >
            <div id="contenido_alerta">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            </div>
        </div>
    <%-- FIN DE ALERTA DE FALTA DE CONTENIDO --%>

    <%-- INICIO DE ALERTA DE CONFIRMACION --%>
         <div id="alert_confirmacion"  >
            <div id="Div2"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div>
         </div>    
    <%-- FIN DE ALERTA DE CONFIRMACION --%>

    <%-- ELEMENTOS GENERALES DEL FORMULARIO --%>
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Nuevo Dojo</h3>
            </div>
    <%-- ENCABEZADO DEL FORMULARIO --%>
            <%-- COMIENZO DEL FORMULARIO --%>
                <form role="form" name="agregar_dojo" id="agregar_dojo" method="post" runat="server">
                    
                    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                        <div class="box-body col-sm-10 col-md-10 col-lg-10 ">
                            <img src="Imagenes\Aikido.png" class="img-thumbnail" alt="Logo Dojo" width="200" height="100" style="margin: 5px 900px 5px 5px;float: left; " > 
                            <asp:TextBox id="logoDojo" name="logoDojo" type="file" class="file"  runat="server"></asp:TextBox>
                        </div>
                    
                        <br/>

                        <div class="box-body col-sm-10 col-md-10 col-lg-10 ">
                            <h3>Rif Del Dojo:</h3>
                            <asp:TextBox runat="server" type="text" name="rifDojo" id="rifDojo" placeholder="*RIF" class="form-control" ></asp:TextBox>
                        </div>

                        <br/>

                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                          <h3>Nombre Del Dojo:</h3>
                          <asp:TextBox runat="server" type="text" name="nombreDojo" id="nombreDojo" placeholder="*Nombre" class="form-control" ></asp:TextBox>
                        </div>
                        
                        <br/>

                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Número Telefónico:</h3>
                            <asp:TextBox runat="server" type="text" name="numeroDojo" id="numeroDojo" placeholder="*Número-Telefono" class="form-control" ></asp:TextBox>
                        </div>

                        <br/>

                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Email:</h3>
                            <asp:TextBox runat="server" type="email" name="emailDojo" id="emailDojo" placeholder="*Email" class="form-control" ></asp:TextBox>
                        </div>
                        
                        <br/>

                         <!-- COMBO ESTADOS -->
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Estado:</h3>
                            <select name="estado" id="estado" class="form-control" runat="server">
                                <option value="Distrito Capital" >Distrito Capital</option>
                            </select>            
                        </div>
                        
                        <br/>

                         <!-- COMBO CIUDAD -->
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Ciudad:</h3>
                            <select name="ciudad" id="ciudad" class="form-control" runat="server">
                                <option value="Caracas" >Caracas</option>
                            </select>            
                        </div>

                        <br/>

                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Dirección Dojo:</h3>
                            <asp:TextBox runat="server" type="text" name="direccionDojo" id="direccionDojo" placeholder="Direccion" class="form-control" ></asp:TextBox>
                        </div>

                        <br/>

                        <div class="form-group col-sm-12 col-md-12 col-lg-12" onload="initialize();">
                            <h3>Ubicación :</h3>
                                <input type="text" id="txtLAT" name="txtLAT" runat="server" visible="false" disabled="disabled"><!--LATITUD DE UBICACION-->
                                <input type="text" id="txtLONG" name="txtLONG" runat="server" visible="false" disabled="disabled"><!--LONGITUD DE UBICACION-->
                                <div id="googleMap" style="width:735px;height:350px;"></div>
                            <br/>
                        </div>

                        <br/>

                <%-- <div class="form-group">
                    <div class="col-sm-10 col-md-10 col-lg-10">
                        <h3>Elegir Administrador:</h3>
                        <label class="radio-inline">
                        <input type="radio" name="radioTipo"  id="input_nuevo"  onclick="return fillCodigoTextField();"/>Nuevo</label>
                        <label class="radio-inline">
                        <input type="radio" name="radioTipo" checked="checked" id="input_existente" onclick="return fillCodigoTextField();" />Existente</label>
                    </div>
                </div>
                   <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <h3>Estilo:</h3>
                      <input type="text" name="estiloDojo" id="estiloDojo" class="form-control" readonly="readonly" value="Estilo 1">
                    </div>
                      <br/>
                      <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <h3>Reglamento Interno:<h3>
                      <textarea class="form-control" id="reglaDojo" name="reglaDojo">1. Regla 1
2. Regla 2
3. Regla 3
4. Regla 4</textarea>
                    </div>--%>
                        <br/>

                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Status:</h3>
                            <label class="radio-inline">
                                <asp:RadioButton runat="server" Text="Activo" type="radio" GroupName="statusDojo" name="statusDojo"  id="statusDojoA"  />
                            </label>
                            <label class="radio-inline">
                                <asp:RadioButton runat="server" Text="Inactivo" type="radio" GroupName="statusDojo" name="statusDojo"  id="statusDojoI"  />
                            </label>
                            <!--<a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                                <asp:Literal runat="server" ID="status"></asp:Literal> 
                            </a>-->
                        </div>
                  
                        <%-- DATE PICKER FECHA --%>
                        <div class="form-group col-sm-4 col-md-3 col-lg-4">
                        <!--<h3>Matricula:<h3> <br />-->
                            <h3>Fecha de vigencia</h3>
                            <div class="input-group input-append date" id="datePickerfecha">
                                <asp:TextBox runat="server" type="text" name="dateDojo" id="dateDojo" class="form-control" ></asp:TextBox>
                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>


                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Modalidad de Pago:</h3>
                            <select id="modalidad" name="modalidad" class="form-control" runat="server" onchange="">
                                <option value="Anual" onclick="return fillCodigoTextField();">Anual</option>
                                <option value="Semestral" onclick="return fillCodigoTextField();">Semestral</option>
                                <option value="Trimestral" onclick="return fillCodigoTextField();">Trimestral</option>
                                <option value="Mensual" onclick="return fillCodigoTextField();">Mensual</option>
                                <option value="Quincenal" onclick="return fillCodigoTextField();">Quincenal</option>
                                <option value="Semanal" onclick="return fillCodigoTextField();">Semanal</option>
                            </select>            
                         </div>

                         <br/>
                    
                         <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Monto Matricula:</h3>
                             <asp:TextBox runat="server" type="text" name="cmatriDojo" id="cmatriDojo" placeholder="*Costo Matricula" class="form-control" ></asp:TextBox>
                         </div>

                    </div>  
   

                    <div class="box-footer">
                        &nbsp;&nbsp;&nbsp;&nbsp
                        <asp:Button id="btn_agregarDojo" class="btn btn-primary" type="submit" style="align-content:flex-end" runat="server" OnClick="btn_agregarDojo_Click" Text="Agregar"></asp:Button>
                        &nbsp;&nbsp
                        <a class="btn btn-default" href="M4_ListarDojos.aspx">Cancelar</a>
                    </div>
                </form>
              </div>
    <%-- FIN DEL FORMULARIO --%>
    
      <!-- Declaración de las alertas-->
     <script type="text/javascript">


         $(document).ready(function () {
             $('#datePickerfecha')
             .datepicker({
                 format: 'yyyy/mm/dd'
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
