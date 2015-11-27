<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M12_DetalleCompetencia.aspx.cs" Inherits="templateApp.GUI.Modulo12.M12_DetalleCompetencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
<script type="text/javascript">

    function initialize() {
        var latlng = new google.maps.LatLng(10.5000, -66.9167);
        var mapProp = {
            center: latlng,
            zoom: 5,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var contentString = '<div id="content">' +
                                '<div id="siteNotice">' +
                                    '</div>' +
      '<h1 id="firstHeading" class="firstHeading">Título</h1>' +
      '<div id="bodyContent">' +
      '<p>  Cuerpo </p>' +
      '<p>' +
      '</p>' +
      '</div>' +
      '</div>';

        var infowindow = new google.maps.InfoWindow({
            content: contentString,
            maxWidth: 150
        });

        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

        var point = new google.maps.LatLng(10.5000, -66.9167);
        var marker = new google.maps.Marker({
            position: point,
            map: map,
            title: 'Ubicación',

        })

        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });

    }

    google.maps.event.addDomListener(window, 'load', initialize);
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Gestión de Competencias</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Detalle Competencia</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    
    <!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Detalle De Competencia</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form runat="server" role="form" name="detalle_competencia" id="detalle_competencia" method="post">
<div class="box-body col-sm-12 col-md-12 col-lg-12 ">

   <div class="form-group col-sm-10 col-md-10 col-lg-10">
      <br />
      <h3>Nombre de Competencia</h3>
      <input runat="server" type="text" name="nombreComp" id="nombreComp" class="form-control" readonly ="readonly"/>
   </div>
   <br/>
   <div class="form-group">
      <div class="col-sm-10 col-md-10 col-lg-10">
         <h3>Tipo de Competencia</h3>
         <input runat="server" type="text" name="tipoComp" id="tipoComp" class="form-control" readonly ="readonly"/>
         <br />
      </div>
   </div>
   <div class="form-group">
      <div id="div-org" class="col-sm-12 col-md-12 col-lg-12">
         <h3>Organizador(es)</h3>
          <input runat="server" type="text" name="orgComp" id="orgComp" class="form-control" readonly ="readonly"/>
         <br />
      </div>
   </div>
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Ubicación de Competencia</h3>
        <div id="googleMap" style="width:500px;height:250px;"></div>
        <br />
    </div>
   < <br />



</div>

      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a class="btn btn-default" href="M12_ListarCompetencias.aspx">Cancelar</a>
      </div>
   </form>

</div>

<!-- /.box -->

</asp:Content>
