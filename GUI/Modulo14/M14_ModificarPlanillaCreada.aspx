<%@ Page Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M14_ModificarPlanillaCreada.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14_ModificarPlanillaCreada" %>

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
			    Modificar Planilla
		    </li>
	    </ol>
    </div>
	<%--Fin_Breadcrumbs--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión de Planillas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Modificar Planilla</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div id="alert" runat="server">
    </div> 
    <div class="row">
   <div class="col-xs-12">
     <div class="box">
   <!-- general form elements -->
  <div class="box-header with-border">
   <h3 class="box-title">Nueva Planilla</h3>
  </div>
  <!-- /.box-header -->
  <!-- form start -->
  <form role="form" name="modificar_planilla" id="modificar_planilla" method="post" action="M14_ModificarPlanillaCreada.aspx?success=1"  runat="server">
   <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
      <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
         <div id="alertlocal" runat="server">
          <!-- Alertas-->
          </div>
          <input id="id_planilla" type="text" placeholder="" class="form-control" name="idPlanilla" runat="server" />
          <div class="col-sm-3 col-md-3 col-lg-3">
            <label>Seleccione el tipo de planilla:</label>  
          </div>
          <div class="col-sm-8 col-md-8 col-lg-84">
             <div class="dropdown" runat="server" id="divComboTipoPlanilla" >
                 <asp:DropDownList ID="comboTipoPlanilla" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboTipoPlanilla_SelectedIndexChanged">
                 </asp:DropDownList>
              </div>
           </div>
     </div>

    <div class="form-group  col-sm-10 col-md-10 col-lg-10">
       <div  id="id_otro" runat="server">
        <br/>
          <h3>Nombre del tipo de Planilla</h3>
           <input id="id_nombretipo" type="text" placeholder="Nombre Tipo Planilla" class="form-control" name="NombreTipoPlanilla" runat="server" />
        </div>
     </div>
     <div class="form-group  col-sm-10 col-md-10 col-lg-10"">
      <br/>
      <h3>Nombre de Planilla</h3>
      <input id="id_nombrePlanilla" type="text" placeholder="NombrePlanilla" class="form-control" name="NombrePlanilla" runat="server" />
     </div>
    
    <div class="form-group">
      <div id="div-dat" class="col-sm-12 col-md-12 col-lg-12">
         <h3>Datos Disponibles</h3>

          <asp:ListBox ID="ListBox1" runat="server" Width="860px" Height="130px">
             <asp:ListItem Text="DOJO" Value="DOJO" Selected="True" />
             <asp:ListItem Text="PERSONA" Value="PERSONA" />
             <asp:ListItem Text="EVENTO" Value="EVENTO" />
             <asp:ListItem Text="COMPETENCIA" Value="COMPETENCIA"  />   
             <asp:ListItem Text="ORGANIZACION" Value="ORGANIZACION"  />
            <asp:ListItem Text="MATRICULA" Value="MATRICULA"  />

          </asp:ListBox>
          <br/>
         <div class="text-center padding-small col-sm-10 col-md-10 col-lg-10">
            <asp:LinkButton class="btn btn-default"  type="submit" runat="server" Text="<span class='glyphicon glyphicon-chevron-down'></span>" AutoPostBack="true" OnClick="AgregarDato_Click"></asp:LinkButton>
            <asp:LinkButton  class="btn btn-default"  type="submit" runat="server"  Text="<span class='glyphicon glyphicon-chevron-up'></span>" AutoPostBack="true" OnClick="QuitarDato_Click" ></asp:LinkButton>
         </div>
          <br />
         <h3>Datos Seleccionados</h3>
          <asp:ListBox ID="ListBox2" runat="server" Width="860px" Height="130px"></asp:ListBox>
        <br />
         <br />
      </div>
   </div>

 </div>
      <!-- /.box-body -->
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div class="box-footer">
         &nbsp;&nbsp;&nbsp;&nbsp
         <asp:Button id="btneditar" class="btn btn-primary"  type="submit" runat="server" Text = "Editar" OnClick="btneditar_Click" ></asp:Button>
         &nbsp;&nbsp
         <a class="btn btn-default" href="M14_ConsultarPlanillas.aspx">Cancelar</a>
      </div>
   </form>
   </div>
  </div>
 </div>
<!-- /.box -->
</asp:Content>
