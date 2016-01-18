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
			    <a href="M14_ConsultarPlanillas.aspx">Gestion de Planillas</a> 
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
 
    <div id="alerta" runat="server">
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
  <form role="form" name="diseno_planilla" id="diseno_planilla"  runat="server">

   
   <div class="box-body col-sm-12 col-md-12 col-lg-12 ">

       <div class="col-xs-12 col-lg-12 col-md-12">
         <div class="col-sm-9 col-lg-9 col-md-9">
             <asp:Label ID="tipoPlanilla1" runat="server"></asp:Label>
             <asp:Label ID="Planilla1" runat="server"></asp:Label>
        </div>
         <div class="col-sm-9 col-lg-9 col-md-9">
            <CKEditor:CKEditorControl ID="CKEditor"  Height="620px" runat="server">
            </CKEditor:CKEditorControl>
          </div>
              <div class="col-sm-2 col-lg-2 col-md-2">
              <Label>Leyenda</Label>
              <br />
              <br />
                  
              <asp:ScriptManager ID="ScriptManager" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional"
                     runat="server">
                 <ContentTemplate>
                 <asp:DropDownList ID="comboDatos1" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboDatos_SelectedIndexChanged">
                 </asp:DropDownList>
                 <br />             
                 <asp:Label id="campos1" Text="" runat="server" />
                 <asp:Label id="camposStatic1" Text="" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>                   
          </div>         
        </div>





       </div>
        
      <!-- /.box-body -->
      <div class="box-footer">
         <asp:Button id="btnguardar" class="btn btn-primary"  type="submit" runat="server" Text = "Guardar" OnClick="btnguardar_Click"  ></asp:Button>
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
