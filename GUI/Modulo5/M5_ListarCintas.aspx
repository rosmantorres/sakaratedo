﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M5_ListarCintas.aspx.cs" Inherits="templateApp.GUI.Modulo5.M5_ListarCintas"  %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="M4_js/M4_JSGoogleMaps.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
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
   <form role="form" class="table table-bordered table-striped dataTable" name="consulta_org" id="consulta_org" method="post" runat="server"> 
<div id="alert" runat="server"></div>

<div class="row">
    <div class="col-xs-12">
        <div class="box">

            <div class="box-header">
                 <h3 class="box-title">Lista de Cintas</h3>
            </div><!-- /.box-header -->
            
            <asp:DropDownList ID="listaOrg" AutoPostBack="true" runat="server" OnSelectedIndexChanged="organizacionSeleccionada">
                <asp:ListItem Value="-1">Seleccione una Organizaci&oacute;n</asp:ListItem>
            </asp:DropDownList>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <input id="cintaIdStatus" type="hidden" runat="server" />
    <input id="estatusActual" type="hidden" runat="server" />
    <input id="nombreOrg" type="hidden" runat="server" />
<!--<div class="form-group col-sm-10 col-md-10 col-lg-10">  -->
<div class="box-body table-responsive"> 
<table id="ListaCintas" class="table table-bordered table-striped dataTable">
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
    

</div>
</div>
</div>

  
 <div id="modal-switch" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Activaci&oacute;n/Desactivaci&oacute;n de Cinta Seleccionada</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>¿Está seguro que desea cambiar el status de la cinta?</p>
                    <p id="comp"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <asp:Button runat="server" class="btn btn-primary" OnClick="cambiarStatus" Text="Aceptar" />
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div>
        </div>
      </div>
</form>
 
    <script type="text/javascript">
        $(document).ready(function () {
            $(".statusToggle").click(function () {
                //$(this).find("input").val()
                if ($(this).find("input").is(":checked")) {
                    $("[id$='estatusActual']").val("1");
                }
                else {
                    $("[id$='estatusActual']").val("0");
                }
                $("[id$='cintaIdStatus']").val($(this).find("input").val());
                $("[id$='nombreOrg']").val($(this).closest("td").prev("td").html());

            })

              $('#ListaCintas').DataTable();

        /*      var table = $('#ListaCintas').DataTable({
                "language": {
                    "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                }
              });*/
            var req;
            var tr;
          /*
            $('#ListaCintas tbody').on('click', 'a', function () {
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
           
           */ // la verdad no se q coño hace esa funcion de ahi arriba

        }); 
          $('#dimension-switch').bootstrapSwitch('setSizeClass', 'switch-small');
        </script> 
 <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
    
 
</asp:Content>  