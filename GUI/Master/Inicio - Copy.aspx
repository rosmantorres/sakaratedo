<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="templateApp.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Seccion de Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" runat="server">
    
       
    <div class="box-body table-responsive">

       <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
					<th>ID</th>
					<th >Requerimiento</th>
					<th>Tipo</th>
					<th >Prioridad</th>
					<th style="text-align:right;">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>TOT_RF_1</td>
					<td>El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    
                </tr>
                <tr>
                    <td">TOT_RF_2</td>
					<td>El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</td>
					<td>Funcional</td>
					<td>Alta</td>
                   
				</tr>
                
			</tbody>
    </table>
        </div>      
    
        <script type="text/javascript">
            $(document).ready(function () {

                var table = $('#example').DataTable({
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                    }
                });               
               
            })
        </script>
    
</asp:Content>
