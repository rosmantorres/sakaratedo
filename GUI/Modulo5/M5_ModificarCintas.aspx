<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M5_ModificarCintas.aspx.cs" Inherits="templateApp.GUI.Modulo5.M5_ModificarCintas" %>
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
			    Modificar cintas
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de Cintas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Modificar Cintas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div class="box box-primary">
        <div class="box-header with-border">
                  <h3 class="box-title">Modificar Cinta</h3>
                </div><!-- /.box-header -->
   <form class="form-horizontal" role="form">
        <div class="form-group">
    <label for="color" class="col-lg-2 control-label">Organización</label>
    <div class="col-xs-5">
      <input type="email" class="form-control" id="org" placeholder="Shito Ryu">
    </div>
  </div>
  <div class="form-group">
    <label for="color" class="col-lg-2 control-label">Color</label>
    <div class="col-xs-5">
      <input type="email" class="form-control" id="cinta" placeholder="Blanco">
    </div>
  </div>

  <div class="form-group">
    <label for="ran" class="col-lg-2 control-label">Rango</label>
    <div class="col-xs-5">
      <input type="email" class="form-control" id="ran" placeholder="10mo">
    </div>
  </div>
   
    <div class="form-group">
    <label for="cat" class="col-lg-2 control-label">Categoria</label>
    <div class="col-xs-5">
      <input type="email" class="form-control" id="cate" placeholder="Kyu">
    </div>
  </div>

    
    <div class="box-footer text-center">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-modificarCintas" style="align-content:flex-end" class="btn btn-primary" type="submit" onclick="alertModificarCinta();">Modificar</button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M3_ListarCintas.aspx">Cancelar</a>
                  </div>
  

 </form>
       </div>
</asp:Content>