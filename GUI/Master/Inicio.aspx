<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="templateApp.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Seccion de Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" runat="server">
    
    <div class="table-responsive">
	    <table id="table-requerimientos" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>ID</th>
					<th style="width: 530px">Requerimiento</th>
					<th>Tipo</th>
					<th style="width: 50px">Prioridad</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">SKD_RF_1</td>
					<td>El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">SKD_RF_2</td>
					<td>El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
				</tr><tr>
                    <td class="id">SKD_RF_3</td>
					<td>El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">SKD_RF_4</td>
					<td>El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                <td class="id">SKD_RF_5</td>
					<td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">SKD_RF_6</td>
					<td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                    <td class="id">SKD_RNF_1</td>
					<td>El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					<td>No Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td class="id">SKD_RNF_2</td>
					<td>El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					<td>No Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                <td class="id">SKD_RNF_3</td>
					<td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					<td>No Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td class="id">SKD_RNF_4</td>
					<td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					<td>No Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
			</tbody>
		</table>
    </div>
</asp:Content>
