<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M3_ListarOrganizacion.aspx.cs" Inherits="templateApp.GUI.Modulo3.M3_ListarOrganizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Organización</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Organización</a> 
		    </li>
		
		    <li class="active">
			    Listar Organizaciones
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Organización
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Organizaciones
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
        <div id="alert" runat="server">
    </div>

    
    
     <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Organizaciones</h3>
                    
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tabladojos" class="table table-bordered table-striped dataTable">
            <thead>
				<tr>
                      <th style="text-align:center">Nombre</th>
                    <th style="text-align:center">Email</th>
					<th style="text-align:center">Teléfono</th>
                    <th style="text-align:center">Estilo</th>
                    <th style="text-align:center">Direccion</th>
                    <th style="text-align:center">Estado</th>
                    <th style="text-align:center">Acciones</th>
                    
				</tr>
			</thead>
			<tbody>
				<tr>
                     
					<td class="id">Sakara IB</td>
                    <td>Aikido@Dojo.com</td>
                    <td>412-5464858</td>
					<td>Karate</td>
					<td>Direccion</td>
					<td>Estado</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M3_ModificarOrganizacion.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
               <tr>
                     
					<td class="id">Sakara IB</td>
                    <td>Aikido@Dojo.com</td>
                    <td>412-5464858</td>
					<td>Karate</td>
					<td>Direccion</td>
					<td>Estado</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M3_ModificarOrganizacion.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                     
					<td class="id">Sakara IB</td>
                    <td>Aikido@Dojo.com</td>
                    <td>412-5464858</td>
					<td>Karate</td>
					<td>Direccion</td>
					<td>Estado</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M3_ModificarOrganizacion.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                     
					<td class="id">Sakara IB</td>
                    <td>Aikido@Dojo.com</td>
                    <td>412-5464858</td>
					<td>Karate</td>
					<td>Direccion</td>
					<td>Estado</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M3_ModificarOrganizacion.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                     
					<td class="id">Sakara IB</td>
                    <td>Aikido@Dojo.com</td>
                    <td>412-5464858</td>
					<td>Karate</td>
					<td>Direccion</td>
					<td>Estado</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M3_ModificarOrganizacion.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                     
					<td class="id">Sakara IB</td>
                    <td>Aikido@Dojo.com</td>
                    <td>412-5464858</td>
					<td>Karate</td>
					<td>Direccion</td>
					<td>Estado</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M3_ModificarOrganizacion.aspx"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
			    </tbody>
            </table>
           </div>
       </div>
    </div>
</div>




        <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacute;n de Organización</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar la Organización:</p>
                    <p id="dojo"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" href="#">Eliminar</a>
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
						<h2 class="modal-title">Información De Organización</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Organización</h3>
                                 <img src="Imagenes/Aikido.png" width="150" height="150" alt="">
								
                                        <h4><b>Nombre</b></h4>
                                        <p>Karate</p>
										<h4><b>Técnica</b></h4>
                                         <p>Aikido</p>
										<h4><b>Teléfono</b></h4>
                                         <p>55-4567899</p>
                                        <h4><b>Email</b></h4>
                                         <p>admin@gmail.com</p>
                                        <h4><b>Contacto</b></h4>
                                         <p>Pedro Perez 0412 3117784</p>
                          
                              
								    <h3><b>Orden de Cintas</b></h3>
                                     <select multiple="multiple" name="org_primary" size="4" class="form-control select select-primary select-block mbl">
                                     <option>Color A</option>
                                     <option>Color B</option>
                                     <option>Color F</option>
                                     <option>Color C</option>
                                     <option>Color B</option>
                                     <option>Color Z</option>
                                     </select>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>


      

</asp:Content>
