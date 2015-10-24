<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M7_ListarOrganizacionYDojo.aspx.cs" Inherits="templateApp.GUI.Modulo7.M7_ListarOrganizacionYDojo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Organización y Dojo
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Organización y dojo al que pertenece actualmente
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">


<div id="alert" runat="server">
    </div>

 <div class="row">
            <div class="col-xs-12">
              <div class="box">
                </div><!-- /.box-header -->

    <div class="box-body table-responsive">
						<div class="container-fluid" id="info">
							<h3>Atleta</h3>
								<p>
								   <ul>
                                        <li>Nombre: Enmanuel</li>
                                        <li>Apellido: García </li>
                                        <li>Fecha Nacimiento: 27/02/1995 </li>
									</ul>
								</p>
								<h3>Dojo</h3>
								<p>
									Dojo Hombuji
								</p>
								<h3>Organización a la que pertenece el Dojo</h3>
								<p>
									Organización El Parque Karate Do
								</p>
								<h3>Fecha de inicio en el Dojo</h3>
								<p>
									10/01/2010
								</p>
                                <h3>Cinta actual</h3>
								<p>
									   Cinta Verde
								</p>
						</div>
        		</div>
			</div>
		</div>

    </asp:Content>