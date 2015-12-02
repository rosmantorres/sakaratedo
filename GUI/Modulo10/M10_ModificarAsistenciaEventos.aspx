<%@ Page Language="C#"  MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M10_ModificarAsistenciaEventos.aspx.cs" Inherits="templateApp.GUI.Modulo10.M10_ModificarAsistenciaEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../../plugins/datepicker/datepicker3.css" rel="stylesheet"/>
     <script src="../../../plugins/datepicker/bootstrap-datepicker.js"></script>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Asistencias a Eventos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Modificar Asistencias a Eventos</asp:Content>

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
			    Modificar Asitencia a Eventos
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
<form runat="server" role="form" name="modificar_asistencia" id="modificar_asistencia" method="post">
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
                       
                   </th>
                   <th>
                       <h3 style="text-align:center">Asistieron</h3>
                   </th>
               </tr>
        <tr>
            <td>
         <asp:ListBox Runat="server" ID="listaNoAsistieron" SelectionMode="Multiple" CssClass="form-control select select-primary select-block mbl" Height="150px">
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

</div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
          <asp:LinkButton ID="bModificar" runat="server" CssClass="btn btn-primary" OnClick="bModificar_Click">Modificar</asp:LinkButton>
          &nbsp;&nbsp
         <asp:LinkButton ID="bCancelar" runat="server" CssClass="btn btn-default" OnClick="bCancelar_Click">Cancelar</asp:LinkButton>
      </div>
   </form>
</div>
<!-- /.box -->
</asp:Content>

