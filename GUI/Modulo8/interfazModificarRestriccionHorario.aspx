<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazModificarRestriccionHorario.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazModificarRestriccionHorario" %>
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
			<a href="../Modulo8/interfazRestriccionesHorario.aspx">Gestión Restricciones de Horarios</a>
		</li>

		<li class="active">
			Modificacion de Restricciones de Horario
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">

    Gestión de Restricciones de Horarios
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">

    Modificar Restricción de Horario

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

        
  <div id="alert" runat="server">
    </div>
  
  <select class="combobox" style="width:500px; height:35px">
  <option value="">Seleccione Horario</option>
  <option value="1">Horario 1 Restricción 1: Lunes-Miercoles-Viernes 14:00 a 16:00, Cintas: blanca a marrón Edades 10 a 18 Ambos Sexos</option>
  <option value="2">Horario 2 Restricción 2: Martes-Jueves-Sabado 10:00 a 12:00, Cintas: blanca a marrón Edades 10 a 18 Ambos Sexos</option>
  <option value="3">Horario 3 Restricción 3: Lunes-Miercoles-Viernes 16:00 a 18:00, Cintas: blanca a marrón Edades 10 a 18 Ambos Sexos</option>
  <option value="4">Horario 4 Restricción 4: Lunes-Miercoles-Viernes 08:00 a 10:00, Cintas: blanca a marrón Edades 10 a 18 Ambos Sexos</option>
  <option value="5">Horario 5 Restricción 5: Martes-Jueves-Sabado 14:00 a 16:00, Cintas: blanca a marrón Edades 10 a 18 Ambos Sexos</option>
  </select>
 
  
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					
					<input type="text" placeholder="Edad mínima" class="form-control" id="edad_menor">
					
					<select class="combobox" style="width:265px; height:35px; margin-top: 5%" id="cinta_menor">
						<option value="">Seleccione Cinta</option>
						<option value="1">blanca</option>
						<option value="2">amarilla</option>
						<option value="3">verde</option>
						<option value="4">azul</option>
						<option value="5">roja</option>
						<option value="6">marrón</option>
						<option value="7">Negra 1do Dan</option>
						<option value="8">Negra 2do Dan</option>
						<option value="9">Negra 3er Dan</option>
						<option value="10">Negra 4to Dan</option>
						<option value="11">Negra 5to Dan</option>
					</select>
				</div>
			
            </div>
		</div>
        
        <label class="radio-inline"><input type="radio" name="optradio">Masculino</label>
        <label class="radio-inline"><input type="radio" name="optradio">Femenino</label>
        <label class="radio-inline"><input type="radio" name="optradio">Ambos Sexos</label>
		
        <div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					<input type="text" placeholder="Edad máxima" class="form-control" id="rango_mayor">
					
					<select class="combobox" style="width:265px; height:35px; margin-top: 5%" id="cinta_menor">
						<option value="">Seleccione Cinta</option>
						<option value="1">blanca</option>
						<option value="2">amarilla</option>
						<option value="3">verde</option>
						<option value="4">azul</option>
						<option value="5">roja</option>
						<option value="6">marrón</option>
						<option value="7">Negra 1do Dan</option>
						<option value="8">Negra 2do Dan</option>
						<option value="9">Negra 3er Dan</option>
						<option value="10">Negra 4to Dan</option>
						<option value="11">Negra 5to Dan</option>
					</select>
				    
                    <a id="btn-aceptar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesHorario.aspx">Cancelar</a>
                    <a id="btn-aceptar" type="submit" class="btn btn-primary pull-right" style="margin-top:5%; margin-right:5%; height:35px" href="interfazRestriccionesHorario.aspx?actionSuccess=3"> Modificar</a>
				
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
