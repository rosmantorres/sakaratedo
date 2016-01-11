<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M16_ConsultarMensualidad.aspx.cs" Inherits="templateApp.GUI.Modulo16.M16_ConsultarMensualidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">
    <script type="text/javascript">

    </script>

<!--BREADCRUMB-->
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Inicio</a>
		    </li>
		    <li>
			    <a href="../Modulo16/M16_VerCarrito.aspx">Ver Carrito</a> 
		    </li>

            <li>
			    <a href="#">Consultar Mensualidades Morosas</a> 
		    </li>
		</ol>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server"> Consulta de Mensualidades
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server"> Mensualidades Morosas en Existencia:
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server">
    </div>

    <div class="alert alert-success alert-dismissable" style="display:none" id="agregarEventoaCarrito">
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true"  >&times;</button>
            La Mensualidad se ha Agregado Exitosamente.
        </div>

     <form runat="server" >

    <div class="box-body table-responsive">

<!--TABLA DEL LISTAR DE MENSUALIDADES MOROSAS-->
     <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Eventos Actuales</h3>
                </div><!-- /.box-header -->
              </div>
        
       <asp:Table ID="tablitaMensualidades" runat="server" CssClass="table table-bordered table-striped dataTable">
           <asp:TableHeaderRow>
               <asp:TableHeaderCell>
                   Id Matricula
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Identificador
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Precio (BsF.)
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Mensualidad a Pagar
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Mes a Pagar
               </asp:TableHeaderCell>
               <asp:TableHeaderCell>
                   Anio a Pagar
               </asp:TableHeaderCell>             
               <asp:TableHeaderCell>
                   Acciones
               </asp:TableHeaderCell>
           </asp:TableHeaderRow>           
      </asp:Table>
    
        </div>
        

     <!--MODAL PARA EL DETALLE -->
<div id="modal-info1" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true" >
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h2 class="modal-title">Información detallada de la Mensualidad</h2>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info1">
							<div class="row" id="prueba" >
                                <asp:Literal runat="server" ID="detalleMensualidadLiteral" ></asp:Literal>

							</div>
						</div>
					</div>
				</div>
			</div>
		</div>    
    
     
    </form>

</asp:Content>
