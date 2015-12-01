<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_MostrarPlanilla.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14_MostrarPlanilla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breads" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="subtitulo" runat="server">Mostrar Planilla</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div id="alert" runat="server">
    </div>
    <div class="row">
   <div class="col-xs-12">
     <div class="box">
      <!-- general form elements -->
  <div class="box-header with-border">
   <h3 class="box-title">Planilla</h3>
  </div>
  <!-- /.box-header -->
  <!-- form start -->
         <form role="form" name="mostrar_planilla" id="mostrar_planilla" method="post" action="M14_MostrarPlanilla.aspx"  runat="server">
             <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                 <asp:Label ID="NombrePanilla" runat="server"></asp:Label>
             </div>
                 <div class="col-xs-12 col-lg-12 col-md-12">
                 <div class="col-xs-12 col-lg-12 col-md-12">
                     <div class="col-sm-9 col-lg-9 col-md-9">
                        <asp:Label ID="informacion" runat="server"></asp:Label>
                     </div>
                 </div>
                 <div class="box-footer">
                   <asp:Button id="btnguardar" class="btn btn-primary"  type="submit" runat="server" Text = "Imprimir" OnClick="imprimir_Click"></asp:Button>
                    <a class="btn btn-default" href="M14_ConsultarPlanillas.aspx">Cancelar</a>
                 </div>
             </div>
         </form>
        </div>
   </div>

 </div>
</asp:Content>
