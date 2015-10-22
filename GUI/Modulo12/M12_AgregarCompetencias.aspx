<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M12_AgregarCompetencias.aspx.cs" Inherits="templateApp.GUI.Modulo12.M12_AgregarCompetencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Gestión De Competencias</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Agregar Competencia</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Nueva Competencia</h3>
                </div><!-- /.box-header -->

                <!-- form start -->
                <form role="form" id="agregar_competencia" method="post" action="M12_ListarCompetencias.aspx?success=1">
                  <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
                    <div class="form-group col-sm-10 col-md-10 col-lg-10">
                      <p><b>Nombre De Competencia:</b></p>
                      <input type="text" name="nombreComp" id="nombreComp" placeholder="Nombre" class="form-control">
                    </div>
                      <br/>
                <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Tipo de Competencia:</b></p>
                    <label class="radio-inline">
                    <input type="radio" name="radioTipo" checked="checked" id="input_tipo_kata" onclick="return fillCodigoTextField();" />Kata</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioTipo" id="input_tipo_kumite"  onclick="return fillCodigoTextField();"/>Kumite</label>
                </div>
            </div>
                   
                  </div><!-- /.box-body -->

                  <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp
                    <button id="btn-agregarComp" style="align-content:flex-end" class="btn btn-primary" type="submit" onclick="return checkform();">Agregar</button>
                    &nbsp;&nbsp
                    <a class="btn btn-default" href="M12_ListarCompetencias.aspx">Cancelar</a>
                  </div>

                </form>
              </div><!-- /.box -->

</asp:Content>
