<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M10_AgregarAsistenciaEventos.aspx.cs" Inherits="templateApp.GUI.Modulo10.M10_AgregarAsistenciaEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Asistencias a Eventos</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

    
	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Asistencia a Eventos</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Asistencia a Eventos</a> 
		    </li>
		
		    <li class="active">
			    Agregar Asitencia a Eventos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>

    </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Asistencias a Eventos</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Agregar Asistencia</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_asistencia" id="agregar_asistencia" method="post" runat="server">
<div class="box-body col-sm-12 col-md-12 col-lg-12">
   
   
    <!--Date picker FECHA-->
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
       <br />
       <h3>Fecha del Evento:</h3>
       <asp:Calendar ID="calendar" runat="server" OnDayRender="calendar_DayRender" OnSelectionChanged="calendar_SelectionChanged"></asp:Calendar>
   </div>

     

    <!--COMBO EVENTO-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Eventos Disponibles:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
    <div class="dropdown" runat="server" id="div1">
        <asp:DropDownList ID="comboEventos"  CssClass="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboEventos_SelectedIndexChanged">
            <asp:ListItem>Seleccionar Evento:</asp:ListItem>
        </asp:DropDownList>
    </div>
      </div>
    </div>

        <!--LISTAS ATLETAS INSCRITOS Y ASISTENTES-->
    <div class="form-group">
      <div id="div-org" class="col-sm-12 col-md-12 col-lg-12" style="height:200px">
           <table style="width:100%; height:100% ">
               <tr>
                   <th >
                       <h3 style="text-align:center">Inscritos</h3>
                   </th>
                    <th>
                       
                   </th>
                   <th>
                       <h3 style="text-align:center">Asistieron</h3>
                   </th>
               </tr>
        <tr>
            <td>
         <asp:ListBox Runat="server" ID="listaInscritos" SelectionMode="Multiple" CssClass="form-control select select-primary select-block mbl" Height="150px">
         </asp:ListBox>
       </td>
            <td>
         <div class="text-center padding-small">
            <asp:LinkButton ID="bIzquierdo" runat="server" CssClass="btn btn-primary" OnClick="bIzquierdo_Click">
            <span aria-hidden="true" class="glyphicon glyphicon-chevron-left"></span>
            </asp:LinkButton>
            <asp:LinkButton ID="bDerecho" runat="server" CssClass="btn btn-primary" OnClick="bDerecho_Click">
            <span aria-hidden="true" class="glyphicon glyphicon-chevron-right"></span>
            </asp:LinkButton>
         </div>
           </td>
            
           <td>
         <asp:ListBox Runat="server" ID="listaAsistentes" SelectionMode="Multiple" CssClass="form-control select select-primary select-block mbl" Height="150px">
         </asp:ListBox>
       </td>
        </tr>
    </table>
      </div>
   </div>
    <!--FIN LISTAS ATLETAS INSCRITOS Y ASISTENTES-->

    <!--TABLA ATLETAS AUSENTES POR PLANILLA-->
    <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Inasistencia Justificada:</h3>
        <table id="tablaplanilla" class="table table-bordered table-striped dataTable">
        <thead>
				<tr> 
                    <th style="text-align:center">Nombre</th>
					<th style="text-align:center">Nota</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="dataTable"></asp:Literal>
		    </tbody>
            </table>
            </div>
        </div>

                    <script type="text/javascript">
                        $(document).ready(function () {
                            $('#tablaplanilla').DataTable();

                            var table = $('#tablaplanilla').DataTable();
                            var comp;
                            var tr;

                            $('#tablaplanilla tbody').on('click', 'a', function () {
                                if ($(this).parent().hasClass('selected')) {
                                    comp = $(this).parent().prev().prev().prev().prev().text();
                                    tr = $(this).parents('tr');//se guarda la fila seleccionada
                                    $(this).parent().removeClass('selected');

                                }
                                else {
                                    comp = $(this).parent().prev().prev().prev().prev().text();
                                    tr = $(this).parents('tr');//se guarda la fila seleccionada
                                    table.$('tr.selected').removeClass('selected');
                                    $(this).parent().addClass('selected');
                                }
                            });
                        });
        </script>

</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <asp:LinkButton ID="bAgregar" runat="server" CssClass="btn btn-primary" OnClick="bAgregar_Click">Agregar</asp:LinkButton>
         &nbsp;&nbsp
         <asp:LinkButton ID="bCancelar" runat="server" CssClass="btn btn-default" OnClick="bCancelar_Click">Cancelar</asp:LinkButton>
      </div>
   </form>

</div>

<!-- /.box -->
</asp:Content>
