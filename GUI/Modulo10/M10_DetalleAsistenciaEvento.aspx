<%@ Page Language="C#"  MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M10_DetalleAsistenciaEvento.aspx.cs" Inherits="templateApp.GUI.Modulo10.M10_DetalleAsistenciaEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Asistencias a Eventos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Detalle de Asistencias a Eventos</asp:Content>

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
			    Detalle de Asitencia a Eventos
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>

    </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<!-- general form elements -->
<div class="box box-primary">
<div class="box-header with-border">
   <h3 class="box-title">Modificar Asistencia</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
<form runat="server" role="form" name="detalle_asistencia" id="detalle_asistencia" method="get">
<div class="box-body col-sm-12 col-md-12 col-lg-12">
   
     <!--Date picker FECHA-->
   <div class="form-group col-sm-10 col-md-10 col-lg-10">
       <br />
       <h3>Fecha del Evento:</h3>
       <asp:TextBox ID="fechaEvento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
       <h3>Nombre del Evento:</h3>
       <asp:TextBox ID="nombreEvento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
   </div>
 
    <!--LISTAS ATLETAS INSCRITOS Y ASISTENTES-->
    <div class="form-group">
      <div id="div-org" class="col-sm-10 col-md-10 col-lg-10" style="height:200px">
       <table style="width:100%; height:100% ">
               <tr>
                   <th >
                       <h3 style="text-align:center">No Asistieron</h3>
                   </th>

                   <th>
                       <h3 style="text-align:center">Asistieron</h3>
                   </th>
               </tr>
        <tr>
            <td>
         <asp:ListBox Runat="server" ID="listaNoAsistieron" SelectionMode="Multiple" CssClass="form-control select select-primary select-block mbl" Height="150px" Width="85%" Enabled="false">
         </asp:ListBox>
       </td>

             <td>
         <asp:ListBox Runat="server" ID="listaAsistentes" SelectionMode="Multiple" CssClass="form-control select select-primary select-block mbl" Height="150px" Enabled="false">
         </asp:ListBox>
            </td>
        </tr>
    </table>
      </div>
   </div>
    <!--FIN LISTAS ATLETAS INSCRITOS Y ASISTENTES-->

</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
        
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>

