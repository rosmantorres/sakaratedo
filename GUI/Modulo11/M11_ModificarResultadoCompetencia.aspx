<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M11_ModificarResultadoCompetencia.aspx.cs" Inherits="templateApp.GUI.Modulo11.M11_ModificarResultadoCompetencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Resultados de Competencia
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Modificar Resultados de Competencia
</asp:Content>
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
			    Modificar Resultados de Competencia
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

        <div id="alert" runat="server">
    </div>
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Modificar Resultado</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form runat="server" role="form" name="modificar_resultado" id="modificar_resultado" method="post">
<div class="box-body col-sm-12 col-md-12 col-lg-12">
   
    <!--Texboxes FECHA y NOMBRE-->
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
       <br />
       <h3>Fecha del Evento:</h3>
       <asp:TextBox ID="fechaEvento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
       <h3>Nombre del Evento:</h3>
       <asp:TextBox ID="nombreEvento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
   </div>
    
   <!--COMBO ESPECIALIDAD-->
    <div class="form-group col-sm-12 col-md-12 col-lg-12">
        <h3 id="lEspecialidad" runat="server" visible="false">Especialidad:</h3>
      <div class="col-sm-8 col-md-8 col-lg-8" >
    <div class="dropdown" runat="server" id="div1">
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
    <div class="dropdown" runat="server" id="div2">
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
                    <th style="text-align:center">Referencia</th>
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
          <asp:LinkButton ID="bModificar" runat="server" CssClass="btn btn-primary" OnClick="bModificar_Click" OnClientClick="resultadosEvento();">Modificar</asp:LinkButton>
          <asp:LinkButton ID="bModificarKata" runat="server" CssClass="btn btn-primary" OnClick="bModificarKata_Click" OnClientClick="resultadosKata();" Visible="false">Modificar</asp:LinkButton>
          <asp:LinkButton ID="bModificarKumite" runat="server" CssClass="btn btn-primary" OnClick="bModificarKumite_Click" OnClientClick="resultadosKumite();" Visible="false">Modificar</asp:LinkButton>
          <asp:LinkButton ID="bModificarAmbas" runat="server" CssClass="btn btn-primary" OnClick="bModificarAmbas_Click" OnClientClick="resultadosAmbos();" Visible="false">Modificar</asp:LinkButton>
          &nbsp;&nbsp
         <asp:LinkButton ID="bCancelar" runat="server" CssClass="btn btn-default" OnClick="bCancelar_Click">Cancelar</asp:LinkButton>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>