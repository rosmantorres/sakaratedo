<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_AgregarResultadoCompetencia.aspx.cs" Inherits="templateApp.GUI.Modulo11.M11_AgregarResultadoCompetencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencias</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Resultados de Competencias</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Resultados de Competencia</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Resultados de Competencia</a> 
		    </li>
		
		    <li class="active">
			    Agregar Resultados de Competencias
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div id="alert" runat="server"></div>

<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Agregar Resultado</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form role="form" name="agregar_resultado" id="agregar_resultado" method="post" runat="server">
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

   <!--COMBO ESPECIALIDAD-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3 id="lEspecialidad" runat="server" visible="false">Especialidad:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
    <div class="dropdown" runat="server" id="div2">
        <asp:DropDownList ID="comboEspecialidad"  CssClass="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboEspecialidad_SelectedIndexChanged" Visible="false">
            <asp:ListItem>Seleccionar Especialidad:</asp:ListItem>
        </asp:DropDownList>
    </div>
      </div>
    </div>

    <!--COMBO CATEGORIA-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3>Categoria:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
    <div class="dropdown" runat="server" id="div3">
        <asp:DropDownList ID="comboCategoria"  CssClass="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboCategoria_SelectedIndexChanged">
            <asp:ListItem>Seleccionar Categoria:</asp:ListItem>
        </asp:DropDownList>
    </div>
      </div>
    </div>

        <!--TABLA ATLETAS Y RESULTADOS DE EXAMENES DE ASCENSO-->
        <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas que compitieron Examen de Ascenso:</h3>
        <table id="tablaCompetidores" class="table table-bordered table-striped dataTable todasLasTablas">
        <thead>
				<tr> 
					<th style="text-align:center">Nombre del Atleta</th>
                    <th style="text-align:center">Puntuacion</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="dataTable"></asp:Literal>
		    </tbody>
            </table>
            </div>
        </div>

                <!--TABLA ATLETAS Y RESULTADOS DE COMPETENCIAS TIPO KATA-->
        <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas que compitieron en Especialidad Kata:</h3>
        <table id="tablaCompetidores2" class="table table-bordered table-striped dataTable todasLasTablas">
        <thead>
				<tr> 
					<th style="text-align:center">Nombre del Atleta</th>
                    <th style="text-align:center">Jurado 1</th>
                    <th style="text-align:center">Jurado 2</th>
                    <th style="text-align:center">Jurado 3</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="dataTable2"></asp:Literal>
		    </tbody>
            </table>
            </div>
        </div>

                <!--TABLA ATLETAS Y RESULTADOS DE COMPETENCIAS TIPO KUMITE-->
        <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas que compitieron en Especialidad Kumite:</h3>
        <table id="tablaCompetidores3" class="table table-bordered table-striped dataTable todasLasTablas">
        <thead>
				<tr> 
					<th style="text-align:center">Nombre del Atleta 1</th>
                    <th style="text-align:center">Puntuacion</th>
                    <th style="text-align:center">Nombre del Atleta 2</th>
                    <th style="text-align:center">Puntuacion</th>
				</tr>
			</thead>
			<tbody>
                <asp:Literal runat="server" ID="dataTable3"></asp:Literal>
		    </tbody>
            </table>
                   &nbsp;&nbsp;&nbsp;
                  <asp:LinkButton ID="bSiguiente" runat="server" CssClass="btn btn-primary" OnClick="bSiguiente_Click" OnClientClick="resultadosKumite();" Visible="false">Siguiente</asp:LinkButton>
                  <asp:LinkButton ID="bSiguienteAmbos" runat="server" CssClass="btn btn-primary" OnClick="bSiguienteAmbos_Click" OnClientClick="resultadosAmbos();" Visible="false">Siguiente</asp:LinkButton>
            </div>
        </div>

    <!--LISTA POSICIONES-->
     <div class="form-group">
      <div id="div-org" class="col-sm-12 col-md-12 col-lg-12">
         <h3 id="lPosicion" runat="server" visible="false">Posiciones:</h3>
         <asp:ListBox Runat="server" ID="listaGanadores" CssClass="form-control select select-primary select-block mbl" Height="150px" Visible="false">
         </asp:ListBox>
      </div>
   </div>

       <script type="text/javascript">
           $(document).ready(function () {
               $('.todasLasTablas').DataTable();

               var table = $('.todasLasTablas').DataTable();
               var comp;
               var tr;

               $('.todasLasTablas tbody').on('click', 'a', function () {
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

           function resultadosEvento() {
               var arreglo = [];
               $('#tablaCompetidores tbody').each(function () {
                   var i = 0;
                   $(this).find('select#combo').each(function () {

                       var opcion = $(this).val();
                       var obj = {
                           nombre: "",
                           resultado: opcion
                       };
                       arreglo.push(obj);
                   });
                   $(this).find('.sorting_1').each(function () {
                       arreglo[i].nombre = $(this).text();
                       i++;
                   });
               });
               var myJson = JSON.stringify(arreglo);
               document.getElementById('<%= rvalue.ClientID %>').value = myJson;
            }

            function resultadosKata() {
                var arreglo = [];
                $('#tablaCompetidores2 tbody').each(function () {
                    var i = 0;
                    var j = 0;
                    var x = 0;
                    $(this).find('select#combo1').each(function () {
                        var opcion = $(this).val();
                        var obj = {
                            nombre: "",
                            resultado1: opcion,
                            resultado2: "",
                            resultado3: ""
                        };
                        arreglo.push(obj);
                    });
                    $(this).find('select#combo2').each(function () {
                        var opcion = $(this).val();
                        arreglo[j].resultado2 = opcion;
                        j++;
                    });
                    $(this).find('select#combo3').each(function () {
                        var opcion = $(this).val();
                        arreglo[x].resultado3 = opcion;
                        x++;
                    });
                    $(this).find('.sorting_1').each(function () {
                        arreglo[i].nombre = $(this).text();
                        i++;
                    });
                });
                var myJson = JSON.stringify(arreglo);
                document.getElementById('<%= rvalue.ClientID %>').value = myJson;
           }

           function resultadosKumite() {
               var arreglo = [];
               $('#tablaCompetidores3 tbody').each(function () {
                   var i = 0;
                   var j = 0;
                   var x = 0;
                   $(this).find('select#combo1').each(function () {
                       var opcion = $(this).val();
                       var obj = {
                           nombre: "",
                           resultado1: opcion,
                           resultado2: "",
                           resultado3: ""
                       };
                       arreglo.push(obj);
                   });
                   $(this).find('select#combo2').each(function () {
                       var opcion = $(this).val();
                       arreglo[j].resultado3 = opcion;
                       j++;
                   });
                   $(this).find('.nombre1').each(function () {
                       arreglo[i].nombre = $(this).text();
                       i++;
                   });
                   $(this).find('.nombre2').each(function () {
                       arreglo[x].resultado2 = $(this).text();
                       x++;
                   });
               });
               var myJson = JSON.stringify(arreglo);
               document.getElementById('<%= rvalue2.ClientID %>').value = myJson;
           }

           function resultadosAmbos() {
               resultadosKata();
               resultadosKumite();
           }
        </script>
            <asp:HiddenField ID="rvalue" runat="server" />
            <asp:HiddenField ID="rvalue2" runat="server" />
</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <asp:LinkButton ID="bAgregar" runat="server" CssClass="btn btn-primary" OnClick="bAgregar_Click" OnClientClick="resultadosEvento();">Agregar</asp:LinkButton>
        <asp:LinkButton ID="bAgregarKata" runat="server" CssClass="btn btn-primary" OnClick="bAgregarKata_Click" OnClientClick="resultadosKata();" Visible="false">Agregar</asp:LinkButton>
        <asp:LinkButton ID="bAgregarKumite" runat="server" CssClass="btn btn-primary" OnClick="bAgregarKumite_Click" OnClientClick="resultadosKumite();" Visible="false">Agregar</asp:LinkButton>
        <asp:LinkButton ID="bAgregarAmbos" runat="server" CssClass="btn btn-primary" OnClick="bAgregarAmbos_Click" OnClientClick="resultadosKumite();" Visible="false">Agregar</asp:LinkButton>
         &nbsp;&nbsp
         <asp:LinkButton ID="bCancelar" runat="server" CssClass="btn btn-default" OnClick="bCancelar_Click">Cancelar</asp:LinkButton>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>