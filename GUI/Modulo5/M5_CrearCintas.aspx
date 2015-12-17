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

    


    <div class="box box-primary">
        <div class="box-header with-border">
                  <h3 class="box-title">Nueva Cinta</h3>
                </div><!-- /.box-header -->
        
     
                                      <h3>Seleccione una Organización</h3> 
<form role="form" name="consulta_org" id="consulta_org" method="post" runat="server">
           
     <div class="col-sm-8 col-md-8 col-lg-84">
             <div class="dropdown" runat="server" id="divComboTipoListOrg"  >
                 <asp:DropDownList ID="ListOrg" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                 </asp:DropDownList> <%-- OnSelectedIndexChanged="comboTipoPlanilla_SelectedIndexChanged"--%>
              </div>
      </div>
  
    <br />
    <br />
       
                         <!-- Lista de Organizaciones -->
 
 <div class="container">   
  <div class="row" >
   <!--  <label for="color" class="col-lg-2 control-label">*Color</label>-->
    <div class="col-xs-5">
        <div id="id_otro" runat="server" class="form-group" > 
             <input style="margin-top:5%" type="text" class="form-control" id="cinta" placeholder="Color de cinta" runat="server">
             <input style="margin-top:5%" type="text" class="form-control" id="ran" placeholder="Rango de Cinta" runat="server" >
             <input style="margin-top:5%" type="text" class="form-control" id="cate" placeholder="Clasificación de la Cinta" runat="server">
             <input style="margin-top:5%" type="text" class="form-control" id="signi" placeholder="Significado de la cinta" runat="server">
             <input style="margin-top:5%" type="text" class="form-control" id="ord" placeholder="Orden de la cinta" runat="server">
        </div>
    </div>
  </div>

  <br />                             


  <div class="box-footer text-center">
       &nbsp;&nbsp;&nbsp;&nbsp
       <asp:Button id="btnCrearCintas" style="align-content:center" class="btn btn-primary" type="submit" OnClick="btnCrearCinta" runat="server" text= "Agregar"></asp:Button>
       &nbsp;&nbsp
       <a class="btn btn-default" href="M5_ListarCintas.aspx">Cancelar</a>
  </div>
</div>
 </form>
            
  </div>  

</asp:Content>
