<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_DetalleDojo.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_DetalleDojo" %>
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

       }
       google.maps.event.addDomListener(window, 'load', initialize);
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Gestión de Dojos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Detalle Dojo
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
      <!-- general form elements -->
   <div class="box box-primary">
      <div class="box-header with-border">
         <h3 class="box-title">Detalle De Dojo</h3>
      </div>
      <!-- /.box-header -->
      <!-- form start -->
      <form runat="server" role="form" name="detalle_dojo" id="detalle_dojo" method="post">
         <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
            <div class="panel-group col-sm-12 col-md-12 col-lg-12">
               <div class="panel panel-primary">
                  <div class="panel-heading">
                     <h4>Datos de Dojo</h4>
                  </div>
                  <div class="panel-body">
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <br />
                        <h4>Logo :</h4>
                        <asp:Label runat="server" name="imgDojo" id="imgDojo" Font-Size="Large"></asp:Label>
                     </div>
                     <br/>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <br />
                        <h4>Rif :</h4>
                        <asp:Label runat="server" name="rifDojo" id="rifDojo" Font-Size="Large"></asp:Label>
                     </div>
                     <br/>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <br />
                        <h4>Nombre :</h4>
                        <asp:Label runat="server" name="nombreDojo" id="nombreDojo" Font-Size="Large"></asp:Label>
                     </div>
                     <br/>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Estilo :</h4>
                        <asp:Label runat="server" name="estiloDojo" id="estiloDojo" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Organización :</h4>
                        <asp:Label runat="server" name="orgDojo" id="orgDojo" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Teléfono :</h4>
                        <asp:Label runat="server" name="telefonoDojo" id="telefonoDojo" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                     <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Email :</h4>
                        <asp:Label runat="server" name="emailDojo" id="emailDojo" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="form-group col-sm-4 col-md-4 col-lg-4">
                        <h4>Status :</h4>
                        <asp:Label runat="server" name="statusDojo" id="statusDojo" Font-Size="Large"></asp:Label>
                        <br />
                     </div>
                      <div class="form-group col-sm-12 col-md-12 col-lg-12">
                         <h4>Ubicación del Dojo :</h4>
                         <div id="googleMap" style="width:735px;height:350px;"></div>
                         <br />
                      </div>
            <div class="form-group col-sm-5 col-md-5 col-lg-5"> <!--BOTON VOLVER-->
            <a class="btn btn-default" href="M4_ListarDojos.aspx">Volver</a>
            </div>
                  </div>
               </div>
            </div>
         </div>
         <!-- /.box-body -->
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <div class="box-footer">
         </div>
      </form>
   </div>
   <!-- /.box -->
</asp:Content>
