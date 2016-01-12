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
<form runat="server" role="form" name="agregar_asistencia" id="agregar_asistencia" method="post">
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

        <!--TABLA ATLETAS Y RESULTADOS EN LA COMPETENCIA-->
        <div class="form-group">
      <div class="col-sm-12 col-md-12 col-lg-12">
        <h3>Atletas que compitieron:</h3>
        <table id="tablaCompetidores" class="table table-bordered table-striped dataTable">
        <thead>
				<tr> 
					<th style="text-align:center">Nombre del Atleta</th>
                    <th style="text-align:center">Puntaje</th>
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
                $('#tablaCompetidores').DataTable();

                var table = $('#tablaCompetidores').DataTable();
                var comp;
                var tr;

                $('#tablaCompetidores tbody').on('click', 'a', function () {
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

            
            function hola() {
                var arreglo = [];
                $('tbody').each(function () {
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
                console.log(myJson);
                document.getElementById('<%= rvalue.ClientID %>').value = myJson;
                //return myJson;
            }

 
            //$('#combo:eq(2)').css("color", "red");
          
               
            

                
        </script>
        <asp:HiddenField ID="rvalue" runat="server" />

</div>

      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
          <!--<input type="submit" value="Submit" onclick="hola();">-->
          <asp:LinkButton ID="bModificar" runat="server" CssClass="btn btn-primary" OnClick="bModificar_Click" OnClientClick="hola();">Modificar</asp:LinkButton>
          &nbsp;&nbsp
         <asp:LinkButton ID="bCancelar" runat="server" CssClass="btn btn-default" OnClick="bCancelar_Click">Cancelar</asp:LinkButton>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>