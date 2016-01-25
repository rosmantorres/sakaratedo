<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazModificarRestriccionAvanceCinta.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazModificarRestriccionAvanceCinta" %>
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
			Modificar Restricciones de Avance de Cinta
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">

    Gestión de Restricciones de Avance de Cinta

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">

    Modificar Restricciones de Avance de Cinta

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>
<form role="form" name="agregar_restriccion" id="agregar_restriccion" method="post"   runat="server"> 
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div class="form-group">
                <div id="alertlocal" runat="server">
                    <!-- Alertas-->
                </div>
				<div class="icon-addon addon-lg">
					
					<input type="number" placeholder="Tiempo Mínimo" class="form-control" id="tiempo_minimo" runat="server">
                    <input style="margin-top:5%" type="number" placeholder="Puntaje Mínimo" class="form-control" id="puntaje_minimo" runat="server">
                    <input style="margin-top:5%" type="number" placeholder="Horas doncentes mínimas" class="form-control" id="horas_docentes" runat="server">
					
                    <a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesAvanceCinta.aspx">Cancelar</a>
                    
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Modificar"   ></asp:Button>
				
				</div>	
			
            </div>
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
