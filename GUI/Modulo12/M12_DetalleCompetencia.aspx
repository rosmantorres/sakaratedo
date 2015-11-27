<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M12_DetalleCompetencia.aspx.cs" Inherits="templateApp.GUI.Modulo12.M12_DetalleCompetencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
<script type="text/javascript">

    function initialize() {
        var latitude = "<%=laLatitud%>";
        var longitude = "<%=laLongitud%>"
        var latlng = new google.maps.LatLng(latitude,longitude);
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

        var point = new google.maps.LatLng(latitude,longitude);
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

   <div class="form-group col-sm-6 col-md-6 col-lg-6">
      <br />
      <h4>Nombre de Competencia :</h4>
      <asp:Label runat="server" name="nombreComp" id="nombreComp" Font-Size="Large"></asp:Label>
   </div>
   <br/>
   <div class="form-group col-sm-6 col-md-6 col-lg-6">
         <h4>Tipo de Competencia :</h4>
         <asp:Label runat="server" name="tipoComp" id="tipoComp" Font-Size="Large"></asp:Label>
         <br />
   </div>
   <div class="form-group col-sm-6 col-md-6 col-lg-6">
         <h4>Organizador(es) :</h4>
          <asp:Label runat="server" name="orgComp" id="orgComp" Font-Size="Large"></asp:Label>
         <br />
    </div>
    <div class="form-group col-sm-6 col-md-6 col-lg-6">
         <h4>Status De Competencia :</h4>
          <asp:Label runat="server" name="statusComp" id="statusComp" Font-Size="Large"></asp:Label>
         <br />
    </div>
    <div class="form-group col-sm-6 col-md-6 col-lg-6">
         <h4>Duración De Competencia :</h4>
          <asp:Label runat="server" name="inicioComp" id="inicioComp" Font-Size="Large"></asp:Label>  -  <asp:Label runat="server" name="finComp" id="finComp" Font-Size="Large"></asp:Label>
         <br />
    </div>
    <div class="form-group col-sm-6 col-md-6 col-lg-6">
         <h4>Costo De Competencia :</h4>
          <asp:Label runat="server" name="costoComp" id="costoComp" Font-Size="Large"></asp:Label>
         <br />
    </div>
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h4>Ubicación de Competencia :</h4>
        <div id="googleMap" style="width:500px;height:250px;"></div>
        <br />
    </div>
   
    <div class="panel-group col-sm-8 col-md-8 col-lg-8">
        <div class="panel panel-primary">
        <div class="panel-heading"><h4>Categoria de Competencia</h4></div>
           <div class="panel-body">
        <h4>Rango De Cintas</h4>
         <asp:Label runat="server" name="categIniComp" id="categIniComp" Font-Size="Large"></asp:Label>  -  
         <asp:Label runat="server" name="categFinComp" id="categFinComp" Font-Size="Large"></asp:Label>
        <br />
        <h4>Rango De Edades</h4>
         <asp:Label runat="server" name="categEdadIniComp" id="categEdadIniComp" Font-Size="Large"></asp:Label>  -  
         <asp:Label runat="server" name="categEdadFinComp" id="categEdadFinComp" Font-Size="Large"></asp:Label>
        <br />
        <h4>Sexo</h4>
        <asp:Label runat="server" name="categSexoComp" id="categSexoComp" Font-Size="Large"></asp:Label>
            </div>
        </div>
      </div>
    <br />
</div>

      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <a class="btn btn-default" href="M12_ListarCompetencias.aspx">Volver</a>
      </div>
   </form>

</div>

<!-- /.box -->

</asp:Content>
