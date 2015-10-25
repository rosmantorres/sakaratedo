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
  
    <select class="combobox" style="width:300px; height:35px">
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
 
  
 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-3">
			<div class="form-group">
				<div class="icon-addon addon-lg">
					
					<input type="text" placeholder="Tiempo mínimo" class="form-control" id="tiempo_minimo">
                    <input style="margin-top:5%" type="text" placeholder="Putaje mínimo" class="form-control" id="puntaje_minimo">
                    <input style="margin-top:5%" type="text" placeholder="Horas docentes mínimas" class="form-control" id="horas_docentes">
					
                    <a id="btn-aceptar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="interfazRestriccionesAvanceCinta.aspx">Cancelar</a>
                    
                    <a id="btn-aceptar" type="submit" class="btn btn-primary pull-right" style="margin-top:5%; margin-right:5%; height:35px" href="interfazRestriccionesAvanceCinta.aspx?actionSuccess=1"> Agregar</a>
				
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
