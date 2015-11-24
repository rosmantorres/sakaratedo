<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_ListarDojos.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_ListarDojos" %>
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
			    <a href="#">Dojo</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Dojo</a> 
		    </li>
		
		    <li class="active">
			    Listar Dojos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Dojos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Listar Dojos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
        <div id="alert" runat="server">
    </div>

    
    
     <div class="row">
            <div class="col-xs-12">
              <div class="box">
        <div class="box-header">
                      <h3 class="box-title">Dojos</h3>
             &nbsp;&nbsp;&nbsp;&nbsp
                     <a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox" checked data-toggle="toggle" data-on="Activo" data-off="Inactivo">
                        </a>
                    
        </div><!-- /.box-header -->

    <div class="box-body table-responsive">
        <table id="tabladojos" class="table table-bordered table-striped dataTable">
            <thead>
				<tr>
                    <th style="text-align:center">Foto</th>
                    <th style="text-align:center">Rif</th>
					<th style="text-align:center">Nombre</th>
                    <th style="text-align:center">Estado</th>
                    <th style="text-align:center">Ciudad</th>
                    <th style="text-align:center">Status</th>
					<th style="text-align:center">Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
                     <td><img src="Imagenes\Aikido.png" alt="" style="width:50px; height:auto;"></td>
					<td class="id">J-17280493-1</td>
					<td>Aikido</td>
                    <td>Río de Janeiro</td>
                    <td>Río de Janeiro</td>
                    <td><a class="make-switch switch-mini" data-toggle="modal" data-target="#modal-switch" >
                            <input type="checkbox"  data-toggle="toggle" data-on="Activo" data-off="Inactivo" disabled>
                        </a></td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"></a>
                        <a class="btn btn-primary glyphicon glyphicon-map-marker" data-toggle="modal" data-target="#modal-maps" href="#"></a>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="M4_ModificaDojo.aspx"></a>
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
              <h4 class="modal-title" >Eliminaci&oacute;n de Dojo</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el Dojo:</p>
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
						<h2 class="modal-title">Información De Dojo</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Dojo</h3>
                                 <img src="Imagenes/Aikido.png" width="150" height="150" alt="">
								
                                        <h4><b>Rif</b></h4>
                                        <p>J-17280493-1</p>
										<h4><b>Nombre</b><h4>
                                         <p>Aikido</p>
										<h4><b>Teléfono</b></h4>
                                         <p>55-4567899</p>
                                        <h4><b>País</b></h4>
                                         <p>Brasil</p>
                                        <h4><b>Estado</b></h4>
                                         <p>Río de Janeiro</p>
                                        <h4><b>Ciudad</b></h4>
                                         <p>Río de Janeiro</p>
                                        <h4><b>Reglamento Interno:</b></h4>
                                         <p>1. Regla 1</p>
                                         <p>2. Regla 2</p>
                                         <p>3. Regla 3</p>
                                         <p>4. Regla 4</p>
								
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

    <div id="modal-maps" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Ubicación Del Dojo</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="maps">
							  <div id="googleMap" style="width:500px;height:250px;"></div><br/>
						</div>
					</div>
				</div>
			</div>
		</div>

    <script src="M4_js/M4_TablaDojos_Accion.js"></script>
      

</asp:Content>
