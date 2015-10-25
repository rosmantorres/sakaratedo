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
			<a href="#">Algún Módulo</a>
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
  
    <select class="combobox" style="width:300px; height:35px">
        <option value="">Seleccione Restricción de Avance de Cinta</option>
        <option value="1">blanca Tiempo Mínimo : 3 meses Puntaje Mínimo: 30 pts Horas Docentes mínimas: 0</option>
		<option value="2">amarilla Tiempo Mínimo : 5 meses Puntaje Mínimo: 60 pts Horas Docentes mínimas: 0</option>
		<option value="3">verde Tiempo Mínimo : 7 meses Puntaje Mínimo: 120 pts Horas Docentes mínimas: 0</option>
		<option value="4">azul Tiempo Mínimo : 9 meses Puntaje Mínimo: 240 pts Horas Docentes mínimas: 8</option>
		<option value="5">roja Tiempo Mínimo: 11 meses Puntaje Mínimo: 480 pts Horas Docentes mínimas: 16</option>
		<option value="6">marrón Tiempo Mínimo: 13 meses Puntaje Mínimo: 960 pts Horas Docentes mínimas: 32</option>
		<option value="7">Negra 1do Dan Tiempo Mínimo: 18 meses Puntaje Mínimo: 1920 pts Horas Docentes mínimas: 80</option>
		<option value="8">Negra 2do Dan Tiempo Mínimo: 24 meses Puntaje Mínimo: 4000 pts Horas Docentes mínimas: 160</option>
		<option value="9">Negra 3er Dan Tiempo Mínimo: 30 meses Puntaje Mínimo: 8000 pts Horas Docentes mínimas: 320</option>
		<option value="10">Negra 4to Dan Tiempo Mínimo: 36 meses Puntaje Mínimo: 16000 pts Horas Docentes mínimas: 640</option>
		<option value="11">Negra 5to Dan Tiempo Mínimo: 42 meses Puntaje Mínimo: 32000 pts Horas Docentes mínimas: 1028</option>
   </select>
 
  
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					
					<input type="text" placeholder="Tiempo Mínimo" class="form-control" id="tiempo_minimo">
                    <input style="margin-top:5%" type="text" placeholder="Putaje Mínimo" class="form-control" id="puntaje_minimo">
                    <input style="margin-top:5%" type="text" placeholder="Horas doncentes mínimas" class="form-control" id="horas_docentes">
					
                    <a id="btn-aceptar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesAvanceCinta.aspx">Cancelar</a>
                    
                    <a id="btn-aceptar" type="submit" class="btn btn-primary pull-right" style="margin-top:5%; margin-right:5%; height:35px" href="interfazRestriccionesAvanceCinta.aspx?actionSuccess=3"> Modificar</a>
				
				</div>	
			
            </div>
		</div>
        
    
        <div class="col-md-3">
	        <div class="form-group">
		    	<div class="icon-addon addon-lg">

                    <label class="radio-inline"><input type="radio" name="optradio">Semanas</label>
                    <label class="radio-inline"><input type="radio" name="optradio">Meses</label>
                    <label class="radio-inline"><input type="radio" name="optradio">Años</label>
					
                </div>
			</div>
		</div>
	</div>
</div>

       
<script type="text/javascript">
  $(document).ready(function(){
	$('.combobox').combobox();
  });
</script>

</asp:Content>
