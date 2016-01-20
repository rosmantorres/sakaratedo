<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazCrearRestriccionAvanceCinta.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazCrearRestriccionAvanceCinta" %>
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
			<a href="../Modulo8/interfazRestriccionesAvanceCinta.aspx">Gestión Restricciones de Avance de Cinta</a>
		</li>
		
		<li class="active">
			Agregar Restricciones de Avance de Cinta
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">

    Gestión de Restricciones de Avance de Cinta

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">

    Agregar Restricciones de Avance de Cinta

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>
<form  role="form" name="agregar_restriccion" id="agregar_restriccion" method="post"   runat="server">
     <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
      <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
          <div class="col-sm-3 col-md-3 col-lg-3">
            <label>Seleccione la cinta que desee:</label>  
          </div>
          <div class="col-sm-8 col-md-8 col-lg-84">
             <div class="dropdown" runat="server" id="divcomboCinta" >
                 <asp:DropDownList ID="comboCinta" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                 </asp:DropDownList>
              </div>  
          </div>
      </div>
    </div>
 
  
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div id="id_otro" runat="server" class="form-group">
				<div class="icon-addon addon-lg">
					
					<input runat="server" type="text" placeholder="Descripcion" class="form-control" id="descripcion" name ="descripcion">
					<input style="margin-top:5%" runat="server" type="text" placeholder="Tiempo mínimo" class="form-control" id="tiempo_minimo" name ="tiempo_minimo">                    
					<input style="margin-top:5%" runat="server" type="text" placeholder="Tiempo maximo" class="form-control" id="tiempo_maximo" name ="tiempo_maximo">
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Puntaje mínimo" class="form-control" id="puntaje_minimo" name="punto_minimo">
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Horas docentes mínimas" class="form-control" id="horas_docentes" name="hora_docente">
					
                    <a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesAvanceCinta.aspx">Cancelar</a>
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary" OnClick="btnaceptar_Click" type="submit" runat="server" Text = "Agregar"   ></asp:Button>
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
