<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Kyu_atletas.aspx.cs" Inherits="templateApp.GUI.Modulo13.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo12/M12_AgregarEliminarOrganizaciones.js") %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Lista de Atletas</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"></asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
   
     &nbsp;&nbsp;&nbsp;&nbsp
         <a id="btn-exportarComp" class="btn btn-primary" type="submit" href="Pdf/Atletas.pdf?eliminacionSuccess=1" onclick="return checkform();">Exportar a PDF</a>
         &nbsp;&nbsp

     <div class="box-body table-responsive">

      <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
				<tr>
                   
					<th>Nombre</th>
					<th >Apellido</th>
					<th>Edad</th>
					<th >Peso Kg</th>
                    <th >Altura</th>					
				</tr>
			</thead>
			

		<tbody>

            <%
                
                List<DominioSKD.Persona> lista = new List<DominioSKD.Persona>();
                LogicaNegociosSKD.Modulo13.LogicaAtletaCinta lcinta = new LogicaNegociosSKD.Modulo13.LogicaAtletaCinta();
                String id = Request.QueryString["id"];
                lista = lcinta.obtenerListaPersona(id);
                foreach (DominioSKD.Persona valorActual in lista)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>" + valorActual.Nombre + "</td>");
                    Response.Write("<td>" + valorActual.Apellido + "</td>");
                    Response.Write("<td>" + valorActual.Edad + "</td>");
                    Response.Write("<td>" + valorActual.Peso + "</td>");
                    Response.Write("<td>" + valorActual.Estatura + "</td>");
                    Response.Write("</tr>");
                }
                
                   %> 
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

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="M13_Inicio.aspx">Reportes Dojo</a> 
		    </li>
            
             <li>
			    <a href="M13_Kyu.aspx">Kyu</a> 
		    </li>


		    <li class="active">
			    Kyu Atletas
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>