<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazCrearRestriccionEvento.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazCrearRestriccionEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server">

    <%--Breadcrumbs--%>
	<ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">

		<li>
			<a href="../Master/Inicio.aspx">Inicio</a>
		</li>
		
        <li>
			<a href="../Modulo8/interfazMenuRestriccionesCintasYEventos.aspx">Menú de Restricciones de Cintas y Eventos</a>
		</li>

		<li>
			<a href="../Modulo8/interfazRestriccionesEventos.aspx">Gestión Restricciones de Eventos</a>
		</li>
		
		<li class="active">
			Agregar Restricciones de Eventos
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">

    Gestión de Restricciones de Eventos

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">

    Agregar Restricciones de Eventos

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>
  
<form role="form" name="agregar_restriccion" id="agregar_restriccion" method="post"   runat="server">
    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
      <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
          <div class="col-sm-3 col-md-3 col-lg-3">
            <label>Seleccione la competencia que desee:</label>  
          </div>
          <div class="col-sm-8 col-md-8 col-lg-84">
             <div class="dropdown" runat="server" id="divcomboCompetencia" >
                 <asp:DropDownList ID="comboCompetencia" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                 </asp:DropDownList>
              </div>

               
          </div>
      </div>
    </div>

  
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">

					<div class="dropdown" runat="server" id="EdadMin" >
                         <asp:DropDownList style="width:265px; height:35px; margin-top: 5%" id="EdadMinima" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                        </asp:DropDownList>
                    </div>	
                    <div class="dropdown" runat="server" id="divcomboCinta" >
                         <asp:DropDownList style="width:265px; height:35px; margin-top: 5%" id="cinta_menor" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                        </asp:DropDownList>
                    </div>
					
                </div>
			</div>
		</div>
        
        <div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					
                    
                    <div class="dropdown" runat="server" id="modalidad" >
                         <asp:DropDownList style="width:265px; height:35px; margin-top: 5%" id="Mod" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                        </asp:DropDownList>
                    </div>
                    
                    <div class="dropdown" runat="server" id="EdadMax" >
                         <asp:DropDownList style="width:265px; height:35px; margin-top: 5%" id="EdadMaxima" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                        </asp:DropDownList>
                    </div>					

					<div class="dropdown" runat="server" id="divcomboCintaMayor" >
                         <asp:DropDownList style="width:265px; height:35px; margin-top: 5%" id="cinta_mayor" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                        </asp:DropDownList>
                    </div>

                    
				    
                   <a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesCompetencia.aspx">Cancelar</a>
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary" OnClick="btnaceptar_Click" type="submit" runat="server" Text = "Agregar"   ></asp:Button>
				
                </div>
			</div>
		</div>
        
        
        <div class="dropdown" runat="server" id="sex" >
             <asp:DropDownList style="width:265px; height:35px; margin-top: 5%" id="sexo" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
             </asp:DropDownList>
        </div>
        
        

	</div>
</div>
</form>
       
<script type="text/javascript">
  $(document).ready(function(){
	$('.combobox').combobox();
  });
</script>

</asp:Content>
