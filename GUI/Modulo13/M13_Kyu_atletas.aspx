<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Inicio.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_Inicio" %>
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
                    <th>Foto</th>
					<th>Nombre</th>
					<th >Apellido</th>
					<th>Edad</th>
					<th >Peso Kg</th>
                    <th >Altura</th>					
				</tr>
			</thead>
			<tbody>
				<tr>
					<td><img src="Fotos-Atletas/1.jpg" width="60" height="80" class="img-responsive" /></td>
					<td>AYKUT</td>
					<td>KAYA</td>
					<td>23</td>
                    <td>75</td>
                    <td>1,80</td>                  
                </tr>                            
			
            
			
				<tr>
					<td><img src="Fotos-Atletas/2.jpg" class="img-responsive" /></td>
					<td>Jose</td>
					<td>Perez</td>
					<td>25</td>
                    <td>71</td>
                    <td>1,70</td>
                  
                </tr>                            
				
			
			
				<tr>
					<td><img src="Fotos-Atletas/3.jpg" class="img-responsive" /></td>
					<td>Rodrigo</td>
					<td>Yanez</td>
					<td>19</td>
                    <td>69</td>
                    <td>1,74</td>
                  
                </tr>                            
			
            
				<tr>
					<td><img src="Fotos-Atletas/4.jpg" class="img-responsive" /></td>
					<td>Gregorio</td>
					<td>Padron</td>
					<td>26</td>
                    <td>79</td>
                    <td>1,71</td>                  
                </tr>               
			
            		
			
				<tr>
                	<td><img src="Fotos-Atletas/5.jpg" class="img-responsive" /></td>
					<td>Alejandro</td>
					<td>García</td>
					<td>19</td>
                    <td>80</td>
                    <td>1,72</td>
                  
                </tr>
                        
			
			
			
				<tr>
					<td width="60" height="80"><img src="Fotos-Atletas/6.jpg" class="img-responsive" /></td>
				  <td>Pablo</td>
					<td>Merchan</td>
					<td>20</td>
                    <td>68</td>
                    <td>1,90</td>                  
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