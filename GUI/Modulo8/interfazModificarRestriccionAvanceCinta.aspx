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
			<a href="#">Algun Modulo</a>
		</li>

        <li>
			<a href="../Modulo8/interfazRestriccionesAvanceCinta.aspx">Restricciones de Avance de Cinta</a>
		</li>
		
		<li class="active">
			Modificar Restricciones de Avance de Cinta
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">

    Gestion de Restricciones de Avance de Cinta

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">

    Modificar Restricciones de Avance de Cinta

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>
  
    <select class="combobox" style="width:300px; height:35px">
        <option value="">Seleccione Restriccion de Avance de Cinta</option>
        <option value="1">blanca Tiempo Minimo: 3 meses Puntaje Minimo: 30 pts Horas Docentes Minimas: 0</option>
		<option value="2">amarilla Tiempo Minimo: 5 meses Puntaje Minimo: 60 pts Horas Docentes Minimas: 0</option>
		<option value="3">verde Tiempo Minimo: 7 meses Puntaje Minimo: 120 pts Horas Docentes Minimas: 0</option>
		<option value="4">azul Tiempo Minimo: 9 meses Puntaje Minimo: 240 pts Horas Docentes Minimas: 8</option>
		<option value="5">roja Tiempo Minimo: 11 meses Puntaje Minimo: 480 pts Horas Docentes Minimas: 16</option>
		<option value="6">marron Tiempo Minimo: 13 meses Puntaje Minimo: 960 pts Horas Docentes Minimas: 32</option>
		<option value="7">Negra 1do Dan Tiempo Minimo: 18 meses Puntaje Minimo: 1920 pts Horas Docentes Minimas: 80</option>
		<option value="8">Negra 2do Dan Tiempo Minimo: 24 meses Puntaje Minimo: 4000 pts Horas Docentes Minimas: 160</option>
		<option value="9">Negra 3er Dan Tiempo Minimo: 30 meses Puntaje Minimo: 8000 pts Horas Docentes Minimas: 320</option>
		<option value="10">Negra 4to Dan Tiempo Minimo: 36 meses Puntaje Minimo: 16000 pts Horas Docentes Minimas: 640</option>
		<option value="11">Negra 5to Dan Tiempo Minimo: 42 meses Puntaje Minimo: 32000 pts Horas Docentes Minimas: 1028</option>
   </select>
 
  
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					
					<input type="text" placeholder="tiempo minimo" class="form-control" id="tiempo_minimo">
                    <input style="margin-top:5%" type="text" placeholder="Putaje minimo" class="form-control" id="puntaje_minimo">
                    <input style="margin-top:5%" type="text" placeholder="Horas doncentes minimas" class="form-control" id="horas_docentes">
					
                    <a id="btn-aceptar" type="button" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesAvanceCinta.aspx">Cancelar</a>
                    
                    <a id="btn-aceptar" type="button" class="btn btn-primary glyphicon glyphicon-check pull-right" style="margin-top:5%; margin-right:5%; height:35px" href="interfazRestriccionesAvanceCinta.aspx?actionSuccess=3"> Modificar</a>
				
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
