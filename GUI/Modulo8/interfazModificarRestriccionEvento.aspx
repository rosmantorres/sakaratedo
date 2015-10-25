<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="interfazModificarRestriccionEvento.aspx.cs" Inherits="templateApp.GUI.Modulo8.interfazModificarRestriccionEvento" %>
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
			<a href="../Modulo8/interfazRestriccionesEventos.aspx">Restricciones de Eventos</a>
		</li>
		
		<li class="active">
			Modificar de Restricciones de Eventos
		</li>
	
	</ol>
	<%--Fin_Breadcrumbs--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">

    Gestion de Restricciones de Eventos

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">

    Modificar Restricciones de Eventos

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>
  
  <select class="combobox" style="width:500px; height:35px">
  <option value="">Seleccione Horario</option>
  <option value="1">Entrenamiento Especial 1/1/2016  12:00 a 14:00 Rango Edades: 10 a 18 Rango Cintas: Blanca a Marron Sexo: Ambos Categoria: N/A Especialidad N/A</option>
  <option value="2">Competencia 1/2/2016  12:00 a 14:00 Rango Edades: 10 a 18 Rango Cintas: Blanca a Marron Sexo: Femenino Categoria: N/Peso Pluma Especialidad: Kumite</option>
  <option value="3">Entrenamiento Especial 1/1/2016  12:00 a 14:00  12:00 a 14:00 Rango Edades: 10 a 18 Rango Cintas: Blanca a Marron Sexo: Ambos Categoria: N/A Especialidad N/A</option>
  <option value="4">Competencia 1/2/2016  12:00 a 14:00 Rango Edades: 10 a 18 Rango Cintas: Blanca a Marron Sexo: Femenino Categoria: N/Peso Pluma Especialidad: Kumite</option>
  <option value="5">Entrenamiento Especial 1/1/2016  12:00 a 14:00  12:00 a 14:00 Rango Edades: 10 a 18 Rango Cintas: Blanca a Marron Sexo: Ambos Categoria: N/A Especialidad N/A</option>
  </select>
 
  
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					
					<input type="text" placeholder="Edad Minima" class="form-control" id="edad_menor">
					
					<select class="combobox" style="width:265px; height:35px; margin-top: 5%" id="cinta_menor">
						
                        <option value="">Seleccione Cinta Menor</option>
					    <option value="1">blanca</option>
					    <option value="2">amarilla</option>
					    <option value="3">verde</option>
					    <option value="4">azul</option>
					    <option value="5">roja</option>
					    <option value="6">marron</option>
					    <option value="7">Negra 1do Dan</option>
					    <option value="8">Negra 2do Dan</option>
					    <option value="9">Negra 3er Dan</option>
					    <option value="10">Negra 4to Dan</option>
					    <option value="11">Negra 5to Dan</option>
					
                    </select>
			
                    <select class="combobox" style="width:265px; height:35px; margin-top: 5%" id="Modalidad">
						
                        <option value="">Seleccione Categoria</option>
						<option value="1">Ligero</option>
						<option value="2">Medio</option>
                        <option value="3">Semipesado</option>
                        <option value="4">Pesado</option>
						
                    </select>

                </div>
			</div>
		</div>
        
        <div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					
                    <input type="text" placeholder="Edad Maxima" class="form-control" id="rango_mayor">
					
					<select class="combobox" style="width:265px; height:35px; margin-top: 5%" id="cinta_menor">
						
                        <option value="">Seleccione Cinta Mayor</option>
					    <option value="1">blanca</option>
					    <option value="2">amarilla</option>
					    <option value="3">verde</option>
					    <option value="4">azul</option>
					    <option value="5">roja</option>
					    <option value="6">marron</option>
					    <option value="7">Negra 1do Dan</option>
					    <option value="8">Negra 2do Dan</option>
					    <option value="9">Negra 3er Dan</option>
					    <option value="10">Negra 4to Dan</option>
					    <option value="11">Negra 5to Dan</option>

					</select>

                    <select class="combobox" style="width:265px; height:35px; margin-top: 5%" id="Modalidad">
						
                        <option value="">Seleccione Modalidad</option>
					    <option value="1">Kata</option>
					    <option value="2">Kumite</option>

                    </select>
				    
                    <a id="btn-aceptar" type="button" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesEventos.aspx">Cancelar</a>
                    
                    <a id="btn-aceptar" type="button" class="btn btn-primary glyphicon glyphicon-check pull-right" style="margin-top:5%; margin-right:5%; height:35px" href="interfazRestriccionesEventos.aspx?actionSuccess=3"> Modificar</a>
				
                </div>
			</div>
		</div>
        
        
        <div class="col-md-4">
           
            <p>Sexo</p>
            <label class="radio-inline"><input type="radio" name="optradio">Masculino</label>
            <label class="radio-inline"><input type="radio" name="optradio">Femenino</label>
            <label class="radio-inline"><input type="radio" name="optradio">Ambos Sexos</label>

        </div>
        

	</div>
</div>

       
<script type="text/javascript">
  $(document).ready(function(){
	$('.combobox').combobox();
  });
</script>

</asp:Content>
