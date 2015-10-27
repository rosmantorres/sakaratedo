<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M5_CrearCintas.aspx.cs" Inherits="templateApp.GUI.Modulo5.M5_CrearCintas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Organizaciones</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Cintas</a> 
		    </li>
		
		    <li class="active">
			    Agregar cinta
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de Cintas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Agregar Cintas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

   <form class="form-horizontal" role="form">
       <div class="form-group">
           <label for="org" class="col-lg-2 control-label">Organizaciones</label>
       <div class="col-xs-5 dropdown">
  <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
    Seleccione...
    <span class="caret"></span>
  </button>
  <ul class="dropdown-menu" aria-labelledby="dropdownMenu2">
    <li><a href="#">Shito Ryu</a></li>
    <li><a href="#">Budokai</a></li>
    <li><a href="#">Hombu</a></li>
  </ul>
</div>
</div>
  <div class="form-group">
    <label for="color" class="col-lg-2 control-label">Color</label>
    <div class="col-xs-5">
      <input type="email" class="form-control" id="cinta" placeholder="Color de cinta">
    </div>
  </div>

  <div class="form-group">
    <label for="ran" class="col-lg-2 control-label">Rango</label>
    <div class="col-xs-5">
      <input type="email" class="form-control" id="ran" placeholder="Rango de Cinta">
    </div>
  </div>
   
    <div class="form-group">
    <label for="cat" class="col-lg-2 control-label">Categoria</label>
    <div class="col-xs-5">
      <input type="email" class="form-control" id="cate" placeholder="Dan o Kyu">
    </div>
  </div>

    <div class="form-group">
    <div class="col-lg-offset-2 col-lg-10">
      <button id="aceptar" type="submit" class="btn btn-danger">Agregar</button>
    </div>
  </div>  

 </form>

  <div id="alerta1" class="alert alert-success alert-dismissable col-xs-7" aria-hidden="true">
  <button type="button" class="close" data-dismiss="alert">&times;</button>
  <strong>¡Agregado Exitosamente!</strong> La Cinta se ha agregado de forma exitosa.
  </div>


    <script type="text/javascript">

        $(document).ready(function () {

            $('#aceptar').on('click', function () {               

                $('#alerta1').alert();

            });

        });

    </script>

</asp:Content>
