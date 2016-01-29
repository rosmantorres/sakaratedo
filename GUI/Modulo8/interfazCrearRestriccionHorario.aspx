 <%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazCrearRestriccionHorario.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazCrearRestriccionHorario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

    <%--Breadcrumbs--%>
	<ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">

		<li>
			<a href="../Master/Inicio.aspx">Inicio</a>
		</li>
		
        <li>
			<a href="../Modulo8/interfazMenuRestriccionesCintasYEventos.aspx">Menú de Restricciones de Cintas y Eventos</a>
		</li>

		<li>
			<a href="../Modulo8/interfazRestriccionesHorario.aspx">Gestión de Restricciones de Horarios</a>
		</li>
		
		<li class="active">
			Agregar Restricciones de Horarios
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">

    Gestión de Restricciones de Horarios

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    
    Agregar Restricciones de Horarios

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
  <div id="alert" runat="server">
    </div>

<form  role="form" name="agregar_restriccion" id="agregar_restriccion" method="post"   runat="server">  
  <div class="col-sm-8 col-md-8 col-lg-84">
      Selecione un Evento:
      <div class="dropdown" runat="server" id="divcomboEventos" >
           <asp:DropDownList ID="comboEvento" name="dropdowlist" OnClick="btnaceptar_Click" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                 </asp:DropDownList>
      </div>  
   </div>
 
  
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					<p style="margin-top:50px;">Eddad Mínima</p>
					<div class="dropdown" runat="server" id="divEdadMin" contenteditable="false" draggable="false" >
                        <asp:DropDownList style="width:265px; height:35px; margin-top: -10px;" ID="comboEdadMinima" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="false" >
                        </asp:DropDownList>
                    </div>	
					
					<div class="col-sm-8 col-md-8 col-lg-84">
                      <p style="margin-top:30px; margin-left:-15px;">Sexo:</p>
                          <div class="dropdown" runat="server" id="div1"  style="margin-top:-10px; margin-left:-15px;">
                            <asp:DropDownList ID="comboSexo" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                            </asp:DropDownList>
                         </div>  
                    </div>
				</div>
			
            </div>
		</div>
		
        <div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
                    <p style="margin-top:50px;">Eddad Máxima:</p>
					<div class="dropdown" runat="server" id="divEdadMax" contenteditable="false" >
                        <asp:DropDownList ID="comboEdadMaxima" style="width:265px; height:35px; margin-top: -10px;" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="false" >
                        </asp:DropDownList>
                    </div>	
					
					<div class="col-sm-8 col-md-8 col-lg-84">
                        <p style="margin-top:30px; margin-left:-15px;">Cinta:</p>
             <div class="dropdown" runat="server" id="combocintama" style="margin-top:-10px; margin-left:-15px;">
                 <asp:DropDownList ID="comboCintaMayor" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                 </asp:DropDownList>
              </div>  
          </div>
				    <a id="btn-cancelar" type="submit" style="margin-top:35px; margin-right:183px; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesHorario.aspx">Cancelar</a>
                  <asp:Button id="btnaceptar" style="margin-top:120px; margin-left:-277px;" class="btn btn-primary" OnClick="btnaceptar_Click" type="submit" runat="server" Text = "Agregar" href="interfazRestriccionesHorario.aspx?actionSuccess=1"  ></asp:Button>
                </div>
			</div>
		</div>
	</div>
</div>
</form>
       
<script type="text/javascript">
    $(document).ready(function () {
        $('.combobox').combobox();
    });
</script>
</asp:Content>
