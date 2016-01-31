<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M4_AgregarHistorialMatricula.aspx.cs" Inherits="templateApp.GUI.Modulo4.M4_AgregarHistorialMatricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.0/css/bootstrap-toggle.min.css" rel="stylesheet">
    <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
    <script src="M4_js/M4_Alert.js"></script>
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>
    <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
    
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

    <%-- INICIO_BREADCRUMBS --%>
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
			    Agregar Historial Matricula
		    </li>
	    </ol>
    </div>
	<%-- FIN_BREADCRUMBS --%>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Dojos
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Historial Matricula
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
      
    <%-- INICIO DE ALERTA DE FALTA DE CONTENIDO --%>
        <div id="alert"  >
            <div id="contenido_alerta">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            </div>
        </div>
    <%-- FIN DE ALERTA DE FALTA DE CONTENIDO --%>

    <%-- INICIO DE ALERTA DE CONFIRMACION --%>
         <div id="alert_confirmacion"  >
            <div id="Div2"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button> </div>
         </div>    
    <%-- FIN DE ALERTA DE CONFIRMACION --%>

    <%-- ELEMENTOS GENERALES DEL FORMULARIO --%>
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Nuevo Historial</h3>
            </div>
        <%-- ENCABEZADO DEL FORMULARIO --%>
            <%-- COMIENZO DEL FORMULARIO --%>
                <form role="form" name="agregar_historial_matricula" id="agregar_historial_matricula" method="post" runat="server">
                         <div id="alert1" runat="server">
    </div>
                    
                    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                        
                        <%-- DATE PICKER FECHA --%>
                        <div class="form-group col-sm-4 col-md-3 col-lg-4">
                            <h3>Fecha de vigencia</h3>
                            <div class="input-group input-append date" id="datePickerfecha">
                                <asp:TextBox runat="server" type="text" name="dateHM" id="dateHM" class="form-control" ></asp:TextBox>
                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <%-- FIN DATE PICKER FECHA --%>

                        <br/>

                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                            <h3>Modalidad de Pago:</h3>
                           <asp:DropDownList ID="modalidadHM"  class="btn btn-default dropdown-toggle" runat="server">
                               <asp:ListItem Selected="True" Value="">Seleccionar Modalidad: </asp:ListItem>
                                <asp:ListItem Value="Anual">Anual</asp:ListItem>
                                <asp:ListItem Value="Semestral">Semestral</asp:ListItem>
                                <asp:ListItem Value="Trimestral">Trimestral</asp:ListItem>
                                <asp:ListItem Value="Mensual">Mensual</asp:ListItem>
                                <asp:ListItem Value="Quincenal">Quincenal</asp:ListItem>
                                <asp:ListItem Value="Semanal">Semanal</asp:ListItem>
                             </asp:DropDownList>        
                        </div>

                        <br/>
                    
                        <div class="form-group col-sm-10 col-md-10 col-lg-10">
                           <h3>Monto Matricula:</h3>
                            <asp:TextBox runat="server" type="text" name="cmatriHM" id="cmatriHM" placeholder="*Costo Matricula" class="form-control" ></asp:TextBox>
                        </div>

                    </div>

                    <div class="box-footer">
                        &nbsp;&nbsp;&nbsp;&nbsp
                        <asp:Button id="btn_agregarHistorialMatricula" class="btn btn-primary" type="submit" style="align-content:flex-end" runat="server" OnClick="Btn_agregarHistorialM_Click" Text="Agregar"></asp:Button>
                        &nbsp;&nbsp
                        <a class="btn btn-default" href="M4_ListarHistorialMatricula.aspx">Cancelar</a>
                    </div>
                </form>
              </div>
    <%-- FIN DEL FORMULARIO --%>
    
      <!-- Declaración de las alertas-->
     <script type="text/javascript">


         $(document).ready(function () {
             $('#datePickerfecha')
             .datepicker({
                 format: 'yyyy/mm/dd'
             })
             .on('changeDate', function (e) {
                 // Revalidate the date field
             });
         });



         $(document).ready(function () {
             $("#alert").hide();
             $("#alert").attr("class", "alert alert-error alert-dismissible");
             $("#alert").attr("role", "alert");

             $("#alert_confirmacion").hide();
             $("#alert_confirmacion").attr("class", "alert alert-success alert-dismissible");
             $("#alert_confirmacion").attr("role", "alert");
             var valor = "";
             var estado = false;


             // Alertas de cada uno de los campos vacios y los que pertenecen a numéricos

             $("#btn-agregarHistorialMatricula").click(function (evento) {
                 if ($("modalidadHM").val() == "") {
                     valor = valor + "El campo Modalidad es obligatorio </br>";
                     estado = true;
                 }

                 if ($("#cmatriHM").val() == "") {
                     valor = valor + "El campo Costo de Matricula es obligatorio </br>";
                     estado = true;
                 }
                 else {
                     if ((isNaN($("#cmatriHM").val()))) {
                         valor = valor + "El campo Costo de Matricula  es num&eacute;erico </br>";
                         estado = true;
                     }
                 }
                 //aparición de las alertas de pantalla

                 if (estado) {
                     $("#alert_confirmacion").hide();
                     $("#alert").html(valor);
                     $("#alert").fadeIn(2000);
                     valor = "";
                     estado = false;
                     evento.preventDefault();

                 }

             });

         });
         
    </script>
    
</asp:Content>

