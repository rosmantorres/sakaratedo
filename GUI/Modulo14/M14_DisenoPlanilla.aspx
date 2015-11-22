<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_DisenoPlanilla.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14_DisenoPlanilla" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="breads" runat="server">

	<%--Breadcrumbs--%>
    <div>
	    <ol class="breadcrumb" style="background-color:rgba(0,0,0,0);">
		    <li>
			    <a href="../Master/Inicio.aspx">Home</a>
		    </li>
		
		    <li>
			    <a href="#">Planillas</a> 
		    </li>

            <li>
			    <a href="#">Gestión de Planillas</a> 
		    </li>
		
		    <li class="active">
			    Diseñar Planillas
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Diseñar Planilla</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
 
    <div class="row">
   <div class="col-xs-12">
     <div class="box">
      <!-- general form elements -->
  <div class="box-header with-border">
   <h3 class="box-title">Planilla</h3>
  </div>
  <!-- /.box-header -->
  <!-- form start -->
  <form role="form" name="diseno_planilla" id="diseno_planilla" method="post" action="M14_DisenoPlanilla.aspx?success=1"  runat="server">
   <div class="box-body col-sm-12 col-md-12 col-lg-12 ">

       <div class="col-xs-12 col-lg-12 col-md-12">
         <div class="col-sm-9 col-lg-9 col-md-9">
            <CKEditor:CKEditorControl ID="CKEditor1"  Height="620px" runat="server">
            </CKEditor:CKEditorControl>
          </div>
          <div class="col-sm-2 col-lg-2 col-md-2">
              <Label>Leyenda</Label>
              <br />
              <br />
              <div class="dropdown" runat="server" id="divComboDatos" >
                 <asp:DropDownList ID="comboDatos" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true">
                 </asp:DropDownList>
              </div>
              <br />
              
              <asp:Label id="labelLeyenda" Text="" runat="server" />
          </div>
        </div>





       </div>
        
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
       &nbsp;&nbsp;&nbsp;&nbsp
         <asp:Button id="btnguardar" class="btn btn-primary"  type="submit" runat="server" Text = "Guardar"  ></asp:Button>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M14_ConsultarPlanillas.aspx">Cancelar</a>
      </div>
    
      <script src="ckeditor/ckeditor.js"></script>
  </form>
         </div>
   </div>

 </div>
<!-- /.box -->
</asp:Content>
