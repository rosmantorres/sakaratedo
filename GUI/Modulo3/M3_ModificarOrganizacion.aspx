<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M3_ModificarOrganizacion.aspx.cs" Inherits="templateApp.GUI.Modulo3.M3_ModificarOrganizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="M4_js/M4_Alert.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Organizacion</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Organizaciones</a> 
		    </li>

		    <li>
			    <a href="../Modulo3/M3_ListarOrganizacion.aspx">Listar Organizaciones</a> 
		    </li>
		    
            <li class="active">
			    Modificar Organización
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Organización
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Modificar Organización
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server"></div>

        <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Modificar Organización</h3>
                </div><!-- /.box-header -->

                <!-- form start -->
       
                                      
<form role="form" name="consulta_org" id="consulta_org" method="post" runat="server">
           
 
 <div class="container">   
  <div class="row" >
   <!--  <label for="color" class="col-lg-2 control-label">*Color</label>-->
    <div class="col-xs-5">
        <div id="id_otro" runat="server" class="form-group" > 
             <input style="margin-top:5%" type="text" class="form-control" id="nombre" placeholder="Nombre de la Organización" runat="server">
             <input style="margin-top:5%" type="text" class="form-control" id="email" placeholder="Email" runat="server" >
             <input style="margin-top:5%" type="text" class="form-control" id="telefono" placeholder="Número Telefónico" runat="server">
             <input style="margin-top:5%" type="text" class="form-control" id="direccion" placeholder="Direccion" runat="server">
        </div>
    </div>

      <div class="col-sm-8 col-md-8 col-lg-84">
      <div class="dropdown" runat="server" id="divComboEstado"  >
                 <asp:DropDownList ID="ListEstados" style="margin-top:1%" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                 <asp:listitem value ="-1">Seleccionar Estado</asp:listitem>
                 <asp:listitem value ="Distrito Federal">Distrito Federal</asp:listitem>
                 <asp:listitem value ="Falcon">Falcon</asp:listitem>
                 </asp:DropDownList> 
       </div>
    </div>

    <div class="col-sm-8 col-md-8 col-lg-84">
       <div class="dropdown" runat="server" id="div1"  >
                 <asp:DropDownList ID="ListTecnica" style="margin-top:3%" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                 <asp:listitem value ="-1">Seleccionar Tecnica</asp:listitem>
                 <asp:listitem value ="Cobra-do">Cobra-do</asp:listitem>
                 <asp:listitem value ="Sistema libre de Karate">Sistema libre de Karate</asp:listitem>
                 <asp:listitem value ="Shotokan">Shotokan</asp:listitem>
                 </asp:DropDownList> 
        </div>
     </div>
  
  </div>

  <br />                             

    
  <div class="box-footer text-center">
       &nbsp;&nbsp;&nbsp;&nbsp
       <asp:Button id="btnmofificarOrganizacion" style="align-content:center" class="btn btn-primary" type="submit" OnClick="btnModificarOrganizaciones" runat="server" text= "Modificar"></asp:Button>
       &nbsp;&nbsp
       <a class="btn btn-default" href="M3_ConsultarOrganizacion.aspx">Cancelar</a>
  </div>
</div> <!-- /.container-->
 </form>
            
  </div>  

    
    <!-- /.box -->
</asp:Content>
