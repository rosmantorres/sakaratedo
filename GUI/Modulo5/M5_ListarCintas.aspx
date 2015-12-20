<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M5_ListarCintas.aspx.cs" Inherits="templateApp.GUI.Modulo5.M5_ListarCintas" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server"> 
<%--Breadcrumbs--%> 
    <div> 
    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);"> 
    <li> 
    <a href="../Master/Inicio.aspx">Home</a> 
    </li> 
 
    <li> 
    <a href="#">Organizaciones</a>  
    </li> 
 
            <li> 
    <a href="#">Gestión de Cintas</a>  
    </li> 
 
    <li class="active"> 
    Listar cintas 
    </li> 
    </ol> 
    </div> 
<%--Fin_Breadcrumbs--%> 
</asp:Content> 
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server"> 
    Gestión de Cintas 
</asp:Content> 
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server"> 
    Listado de Cintas por Organización 
</asp:Content> 

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server"> 

<div id="alert" runat="server"></div>

<div class="row">
    <div class="col-xs-12">
        <div class="box">

            <div class="box-header">
                 <h3 class="box-title">Lista de Cintas</h3>
            </div><!-- /.box-header -->

<form role="form" class="table table-bordered table-striped dataTable" name="consulta_org" id="consulta_org" method="post" runat="server">
    
<div class="form-group col-sm-10 col-md-10 col-lg-10">  
<table id="ListaCintas" class="table-bordered table-striped dataTable">
<thead>        
<tr> 
    <th>ID</th> 
    <th >Color</th> 
    <th>Rango</th> 
    <th >Clasificacion</th> 
    <th >Significado</th> 
    <th >Orden</th> 
    <th >Organizaci&oacuten</th> 
    <th style="text-align:right;">Acciones</th> 
</tr> 
</thead> 

<tbody> 
<asp:Literal runat="server" ID="tabla"></asp:Literal>


</tbody>
</table>
</div>

</form>
 
        <div id="modal-delete" class="modal" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true"> 
        <div class="modal-dialog"> 
          <div class="modal-content"> 
            <div class="modal-header"> 
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> 
              <h4 class="modal-title" >Eliminaci&oacute;n de Cinta</h4> 
            </div> 
            <div class="modal-body"> 
              <div class="container-fluid"> 
                <div class="row"> 
                    <p>Seguro que desea eliminar la Cinta:</p> 
                    <p id="req"></p> 
                </div> 
              </div> 
            </div> 
            <div class="modal-footer">   
                <a id="btn-eliminar" type="button" class="btn btn-primary" href="M5_Listar.aspx?eliminacionSuccess=1">Eliminar</a> 
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
<h4 class="modal-title">Información detallada de la Organización</h4> 
</div> 
<div class="modal-body"> 
<div class="container-fluid" id="info"> 
<div class="row"> 
<h3>Nombre</h3> 
<p> 
Shito Ryu 
    </p> 
<h3>Direccion</h3> 
<p>  
El Paraiso 
</p> 
<h3>Persona Contacto</h3> 
<p> 
Kyoshi Jose Gregorio Natera 
</p> 
<h3>Email Contacto</h3> 
<p> 
kyoshinatera@gmail.com 
</p> 
 
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
                modal.find('.modal-title').text('Eliminar Cinta:  ' + req)
                modal.find('#req').text(req)
            })
            $('#btn-eliminar').on('click', function () {
                table.row(tr).remove().draw();//se elimina la fila de la tabla 
                $('#modal-delete').modal('hide');//se esconde el modal 
            });


        });

        </script> 
 
 
</asp:Content>  