<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Prueba.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo12/M12_AgregarEliminarOrganizaciones.js") %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Lista de Atletas</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"></asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">


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
               
                             
			</tbody>
           
				
			
			<tbody>
				<tr>
					<td><img src="Fotos-Atletas/2.jpg" class="img-responsive" /></td>
					<td>Jose</td>
					<td>Perez</td>
					<td>25</td>
                    <td>71</td>
                    <td>1,70</td>
                  
                </tr>
               
                             
			</tbody>

            
				
			
			<tbody>
				<tr>
					<td><img src="Fotos-Atletas/3.jpg" class="img-responsive" /></td>
					<td>Rodrigo</td>
					<td>Yanez</td>
					<td>19</td>
                    <td>69</td>
                    <td>1,74</td>
                  
                </tr>
               
                             
			</tbody>

            
				
			
			<tbody>
				<tr>
					<td><img src="Fotos-Atletas/4.jpg" class="img-responsive" /></td>
					<td>Gregorio</td>
					<td>Padron</td>
					<td>26</td>
                    <td>79</td>
                    <td>1,71</td>
                  
                </tr>
               
                             
			</tbody>

            
			
			<tbody>
				<tr>
					<td><img src="Fotos-Atletas/5.jpg" class="img-responsive" /></td>
					<td>Alejandro</td>
					<td>García</td>
					<td>19</td>
                    <td>80</td>
                    <td>1,72</td>
                  
                </tr>
               
                             
			</tbody>

            
			
			<tbody>
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


     <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacute;n de Requerimiento</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el requerimiento:</p>
                    <p id="req"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" href="Inicio.aspx?eliminacionSuccess=1">Eliminar</a>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div><!-- /.modal-delete-content -->
        </div><!-- /.modal-delete-dialog -->
      </div><!-- /.modal-delete -->

    		<div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Información detallada del Caso de Uso</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Precondiciones</h3>
									<ul>
										<li>Usuario registrado</li>
										<li>Usuario logeado</li>
										<li>Proyecto creado</li>
									</ul>
								<h3>Condición Final de Éxito</h3>
								<p>
									Caso de uso creado
								</p>
								<h3>Condición Final de Fallo</h3>
								<p>
									El caso de uso no pudo ser creado
								</p>
								<h3>Disparador</h3>
								<p>
									Seleccionar opción "Gestión de Casos de uso" → "Agregar caso de uso" del menú
								</p>
								<h3>Escenario Principal de Éxito</h3>
									<ol>
										<li>El usuario o admin selecciona la opción "Gestión de Casos de uso" → "Agregar caso de uso" del menú.</li>
										<li>El sistema despliega la pantalla de obtener los datos del caso de uso.</li>
										<li>El usuario o admin ingresa los números de los requerimientos asociados.</li>
										<li>El sistema verifica la existencia de esos requerimientos.</li>
										<li>El usuario o admin introduce los datos del caso de uso.</li>
										<li>El sistema registra el caso de uso. Volver paso 2. El CU termina.</li>
    								</ol>
								<h3>Extensiones</h3>
								<p>
									4-A. El o los requerimientos no existen.
								</p>
								<p style="text-indent: 5em;">
									A1. Desplegar mensaje de error.
								</p>
								<p style="text-indent: 5em;">
									A2. Volver al paso 2. 
								</p>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>



    </div>

        <script type="text/javascript">
            $(document).ready(function () {

                var table = $('#example').DataTable({
                    "language": {
                        "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                    }
                });
                var req;
                var tr;

                $('#example tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        req = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');

                    }
                    else {
                        req = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                });



                $('#modal-delete').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                    modal.find('#req').text(req)
                })
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                });


            });

        </script>

</asp:Content>