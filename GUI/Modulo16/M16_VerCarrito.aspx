<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_VerCarrito.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_VerCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Carrito 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Productos que posees:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

     <div id="alert" runat="server">
    </div>
    
<!--MODAL PARA EL DETALLE-->
     <!-- general form elements -->
    <form runat="server" class="form-horizontal" method="POST">
              
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Subtotal 23.300 Bs.</h3>
                </div><!-- /.box-header -->
        <table id="example" class="table table-bordered table-striped dataTable">
        <thead>
            <tr>
                <th>Foto</th>
                <th>Producto</th>
                <th>Cantidad</th>
                <th>Precio (Bs.)</th>
                <th>Acciones</th>
            </tr>
        </thead>
 
        <tfoot>
            <tr>
                <th>Foto</th>
                <th>Producto</th>
                <th>Cantidad</th>
                <th>Precio (Bs.)</th>
                <th>Acciones</th>
            </tr>
        </tfoot>
<!--INFORMACION DEL MODAL PARA EL DETALLE-->
        <tbody>
           
            <tr>
                <td><img src="Imagenes/CintaBlanca.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Cinta Blanca</td>
                <td>
                     
                                 <div class="dropdown" runat="server" id="div3">
                                 <asp:DropDownList ID="DropDownList3"   class="btn btn-default dropdown-toggle"  runat="server" >
                                     
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 
                                
                </td>
                <td>400</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/Karategi.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Karategi</td>
                <td>
                     
                                 <div class="dropdown" runat="server" id="div4">
                                 <asp:DropDownList ID="DropDownList4"   class="btn btn-default dropdown-toggle"  runat="server" >
                                     
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 
                                

                </td>
                <td>14000</td>
                 <td>
                     <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                     <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/Suspensorio.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Suspensorio</td>
                <td>
                    
                                 <div class="dropdown" runat="server" id="div5">
                                 <asp:DropDownList ID="DropDownList5"   class="btn btn-default dropdown-toggle"  runat="server" >
                                    
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 
                        

                </td>
                <td>350</td>
                <td> 
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
             <tr>
                <td><img src="Imagenes/ProtectorBucal.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Proteccion bucal</td>
                <td>
                     <div class="dropdown" runat="server" id="div6">
                                 <asp:DropDownList ID="DropDownList6"   class="btn btn-default dropdown-toggle"  runat="server" >
                                     
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 

                </td>
                <td>3200</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"></a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            <tr>
                <td><img src="Imagenes/GuanteRojo.jpg" alt="" style="width:50px; height:auto;"></td>
                <td>Guantes rojos</td>
                <td>
                     <div class="dropdown" runat="server" id="div7">
                                 <asp:DropDownList ID="DropDownList7"   class="btn btn-default dropdown-toggle"  runat="server" >
                                    
                                     <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                 </asp:DropDownList>
                                 </div> 

                </td>
                <td>5000</td>
                <td>
                    <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info1" href="#"> </a>
                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                </td>
            </tr>
            
        </tbody>
    </table>

         <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminar Producto</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el Producto:</p>
                    <p id="req"></p>
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

    		<div id="modal-info1" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada del Producto</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row">
                                <img src="Imagenes/GuanteRojo.jpg" alt="">
								<h3>Nombre</h3>
								<p>
									Guantes Rojos
								</p>
								<h3>Cantidad disponible</h3>
								<p>
									7
								</p>
								<h3>Detalles</h3>
								<p>
									Guantes de color rojos diseñados para proteger las manos al momento de impactar
                                    golpes contra el contrincante o cuando se está practicando, con un diseño
                                    particular de color rojo a gusto del atleta.
								</p>
								
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
    </div>



<!--MODAL DE PAGO-->
    <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <button id="btn-agregarComp" style="align-content:flex-end" class="btn btn-primary" type="submit" data-toggle="modal" data-target="#modal-info"">Pagar</button>
          &nbsp;&nbsp
         
    </div>

   <div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Registrar Pago</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">


</asp:Content>
