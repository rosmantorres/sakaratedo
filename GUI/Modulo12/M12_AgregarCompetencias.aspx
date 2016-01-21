<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M12_AgregarCompetencias.aspx.cs" Inherits="templateApp.GUI.Modulo12.M12_AgregarCompetencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="http://maps.googleapis.com/maps/api/js"></script>
   <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
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
   <%--Breadcrumbs--%>
   <div>
      <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
         <li>
            <a href="../Master/Inicio.aspx">Home</a>
         </li>
         <li>
            <a href="../GUI/Modulo9/M9_ListarEventos.aspx">Eventos y Competencias</a> 
         </li>
         <li>
            <a href="../GUI/Modulo12/M12_ListarCompetencias.aspx">Gestión de Competencias</a> 
         </li>
         <li class="active">
            Agregar Competencia
         </li>
      </ol>
   </div>
   <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Competencias</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Competencia</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div id="alert" runat="server"></div>
   <!-- general form elements -->
   <div class="box box-primary">
      <div class="box-header with-border">
         <h3 class="box-title">Nueva Competencia</h3>
      </div>
      <!-- /.box-header -->
      <!-- form start -->
      <form runat="server" role="form" name="agregar_competencia" id="agregar_competencia" method="post">
         <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
            <div class="panel-group col-sm-12 col-md-12 col-lg-12">
               <div class="panel panel-primary">
                  <div class="panel-heading">
                     <h4>Datos de Competencia</h4>
                  </div>
                  <div class="panel-body">
                     <div class="col-sm-4 col-md-4 col-lg-4">
                        <br />
                        <h3>Nombre :</h3>
                        <asp:TextBox runat="server" type="text" name="nombreComp" id="nombreComp" placeholder="Nombre" class="form-control"></asp:TextBox>
                     </div>
                     <br/>
                     <div class="col-sm-4 col-md-4 col-lg-4">
                        <h3>Tipo :</h3>
                        <label class="radio-inline">
                           <asp:RadioButton runat="server" type="radio" Checked="true" Text="Kata" name="radioTipo" id="input_tipo_kata" GroupName="tipoComp" />
                        </label>
                        <label class="radio-inline">
                           <asp:RadioButton runat="server" type="radio" Text="Kumite" name="radioTipo" id="input_tipo_kumite" GroupName="tipoComp"/>
                        </label>
                        <label class="radio-inline">
                           <asp:RadioButton runat="server" type="radio" Text="Ambos" name="radioTipo" id="input_tipo_ambos" GroupName="tipoComp"/>
                        </label>
                        <br />
                     </div>
                     <div class="col-sm-4 col-md-4 col-lg-4">
                        <h3>Organizador(es) :</h3>
                        <asp:CheckBox runat="server" id="organizaciones" Width="300px" CssClass="checkbox" ClientIDMode="Static"></asp:CheckBox>
                     </div>
                     <!--Date picker FECHA-->
                     <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <!--Date picker FECHA Inicio-->
                        <div class="form-group col-sm-6 col-md-6 col-lg-6">
                           <br />
                           <h3>Fecha de Inicio:</h3>
                           <div class="input-group input-append date" id="datePickerIni">
                              <input type="text" class="form-control" name="date" id="input_fecha_ini"/>
                              <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                              <asp:HiddenField runat="server" id="fechaIni" ClientIDMode="Static"></asp:HiddenField>
                           </div>
                        </div>
                        <!--Date picker FECHA-->
                        <div class="form-group col-sm-6 col-md-6 col-lg-6">
                           <br />
                           <h3>Fecha de Culminaci&oacute;n:</h3>
                           <div class="input-group input-append date" id="datePickerFin">
                              <input type="text" class="form-control" name="date" id="input_fecha_fin"/>
                              <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                              <asp:HiddenField runat="server" id="fechaFin" ClientIDMode="Static"/>
                           </div>
                        </div>
                     </div>
                     <br/>
                     <div class="form-group">
                        <div id="div-org" class="col-sm-12 col-md-12 col-lg-12">
                           <div id="elComboOrgs">
                              <h3>Organizaciones Disponibles</h3>
                              <div class="dropdown" runat="server" id="divComboOrg">
                                       <asp:DropDownList ID="comboOrgs" BackColor="White" class="btn btn-default dropdown-toggle col-sm-6 col-md-6 col-lg-6" runat="server" OnSelectedIndexChanged="comboOrgs_SelectedIndexChanged">
                                       </asp:DropDownList>
                              </div>
                              <br />
                              <br />
                           </div>
                        </div>
                     </div>
                     <div class="form-group col-sm-12 col-md-12 col-lg-12" onload="initialize();">
                        <h3>Ubicación :</h3>
                        <asp:HiddenField runat="server" id="txtLAT" ClientIDMode="Static"></asp:HiddenField><!--LATITUD DE UBICACION-->
                        <asp:HiddenField runat="server" id="txtLONG" ClientIDMode="Static"/><!--LONGITUD DE UBICACION-->
                        <div id="googleMap" style="width:735px;height:350px;"></div>
                        <br />
                     </div>
                     <div class="panel-group col-sm-10 col-md-10 col-lg-10">
                        <div class="panel panel-primary">
                           <div class="panel-heading">
                              <h4>Agregar Categoria</h4>
                           </div>
                           <div class="panel-body">
                              <div class="form-group col-sm-12 col-md-12 col-lg-12">
                                 <!--SECCION EDAD-->
                                 <div class="col-sm-4 col-md-4 col-lg-4">
                                    <label>Seleccione el rango de edad:</label>  
                                 </div>
                                 <div class="col-sm-8 col-md-8 col-lg-8" >
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                       <label>Desde:</label>&nbsp;&nbsp;<asp:TextBox runat="server" id="edad_desde" type="number" Text="10" min="10" max="60" ClientIDMode="Static"/>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                       <label>Hasta:</label>&nbsp;&nbsp;<asp:TextBox runat="server" id="edad_hasta" type="number" Text="10" min="10" max="60" ClientIDMode="Static"/>
                                    </div>
                                 </div>
                              </div>
                              <div class="form-group col-sm-12 col-md-12 col-lg-12">
                                 <!--AREA DE SELECCION DE CINTA-->
                                 <div class="col-sm-4 col-md-4 col-lg-4">
                                    <label>Seleccione la cinta:</label>  
                                 </div>
                                 <div class="col-sm-4 col-md-4 col-lg-4" >
                                    <div class="dropdown" runat="server" id="divComboCintaDesde">
                                       <asp:DropDownList ID="comboCintaDesde" BackColor="White"  class="btn btn-default dropdown-toggle" runat="server" ClientIDMode="Static">
                                       </asp:DropDownList>
                                    </div>
                                 </div>
                                 <div class="col-sm-4 col-md-4 col-lg-4" >
                                    <div class="dropdown" runat="server" id="divComboCintaHasta">
                                       <asp:DropDownList ID="comboCintaHasta" BackColor="White"  class="btn btn-default dropdown-toggle" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="comboCintaHasta_SelectedIndexChanged">
                                       </asp:DropDownList>
                                    </div>
                                 </div>
                              </div>
                              <div class="form-group col-sm-12 col-md-12 col-lg-12">
                                 <!--AREA DE SELECCION DE SEXO-->
                                 <div class="col-sm-4 col-md-4 col-lg-4">
                                    <p><b>Seleccione el sexo:</b></p>
                                    <label class="radio-inline">
                                       <asp:RadioButton runat="server" type="radio" Checked="true" Text="M" name="radioSexoM" id="input_sexo_M" GroupName="sexoCategoria"/>
                                    </label>
                                    <label class="radio-inline">
                                       <asp:RadioButton runat="server" type="radio" Text="F" name="radioSexoF" id="input_sexo_F" GroupName="sexoCategoria"/>
                                    </label>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                     <br />
                     <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <div class="col-sm-4 col-md-4 col-lg-4">
                           <h3>Status:</h3>
                           <label class="radio-inline">
                              <asp:RadioButton runat="server" Text="Por Iniciar" type="radio" name="radioStatus" checked="true" id="input_status_porIniciar" GroupName="statusComp"/>
                           </label>
                           <label class="radio-inline">
                              <asp:RadioButton runat="server" Text="En Curso" type="radio" name="radioStatus" id="input_status_enCurso" GroupName="statusComp"/>
                           </label>
                           <label class="radio-inline">
                           <input type="radio" name="radioStatus" disabled="disabled" id="input_status_Finalizado"/>Finalizado</label>
                        </div>
                         <div class="col-sm-1 col-md-1 col-lg-1"></div>
                         <div class="col-sm-4 col-md-4 col-lg-4">
                        <h3>Costo :</h3>
                        <asp:TextBox runat="server" TextMode="Number" name="costoComp" id="costoComp" placeholder="Costo" class="form-control" MaxLength="4" ClientIDMode="Static"></asp:TextBox>
                     </div>
                     </div>
                     <br />
                     <div class="form-group col-sm-5 col-md-5 col-lg-5">
                        <br/>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button id="btn_agregarComp" class="btn btn-primary" type="submit" runat="server" OnClick="btn_agregarComp_Click" Text="Agregar"></asp:Button>
                        &nbsp;&nbsp;
                        <a class="btn btn-default" href="M12_ListarCompetencias.aspx">Cancelar</a>
                        <br/>
                     </div>
                  </div>
               </div>
            </div>
         </div>
         <!-- /.box-body -->
         <div class="box-footer">
         </div>
      </form>
   </div>
   <!-- /.box -->
   <script type="text/javascript">
       $(document).ready(function () {
           $('#tablacompetencias').DataTable();

           $(function () {
               $('#organizaciones').bootstrapToggle({
                   on: 'Todas',
                   off: 'Elegir Una'
               });
           })

           var table = $('#tablacompetencias').DataTable();

       });
   </script>
   <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
   <script>
        $(function () {
            if ($('#organizaciones').is(":checked")) {
                $('#elComboOrgs').hide();
            }
            else {
                $('#elComboOrgs').show();
            }
            $('#organizaciones').change(function () {
                if ($(this).prop('checked')) {
                    $('#elComboOrgs').hide();
                }
                else {
                    $('#elComboOrgs').show();
                }
            });
        });
   </script>    
   <script>
       $(function () {
           $('#edad_desde').change(function () {
               var valor = $('#edad_desde').val();
               $('#edad_hasta').removeAttr('disabled');
               $('#edad_hasta').attr('min', valor);
           });
       });
   </script>
<script>
    $(function () {
        $('#comboCintaDesde').change(function () {
            $('#comboCintaHasta').html('');
            var cintaDesde = $('#comboCintaDesde').val();
            var $options = $("#comboCintaDesde > option").clone();
            $.each($options, function (i, item) {
                if (item.value >= cintaDesde)
                    $('#comboCintaHasta').append($('<option>', {
                        value: item.value,
                        text: item.text
                    }));
            });
        });
    });
   </script>
   <script>
       $(function () {
           $('#comboCintaHasta').change(function () {
               return $('#comboCintaHasta').val();
           })
       });
   </script>
   <script type="text/javascript">
       function updateInput(ish) {
           document.getElementById("edad_hasta").value = ish;
       }
   </script>

 <script>
     $(document).ready(function () {
         $("#input_fecha_fin").datepicker({
             dateFormat: 'mm/dd/yy'
         });
         $("#input_fecha_ini").datepicker({
             todayBtn: 1,
             dateFormat: 'mm/dd/yy',
             autoclose: true
         }).on('changeDate', function (selected) {
             var minDate = new Date(selected.date.valueOf());
             document.getElementById("fechaIni").value = minDate;
             $('#input_fecha_fin').datepicker('setStartDate', minDate);
         });

         $("#input_fecha_fin").datepicker()
             .on('changeDate', function (selected) {
                 var minDate = new Date(selected.date.valueOf());
                 document.getElementById("fechaFin").value = minDate;
                 $('#input_fecha_ini').datepicker('setEndDate', minDate);
             });
     });
    </script>
</asp:Content>