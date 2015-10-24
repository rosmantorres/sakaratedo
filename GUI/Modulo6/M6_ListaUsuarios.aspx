<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M6_ListaUsuarios.aspx.cs" Inherits="templateApp.GUI.Modulo6.M6_ListaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Usuarios en el sistema
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Lista de los usuarios a los que se pyuede administrar
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div id="alert" runat="server">
    </div>

    <div class="box box-body">


    <div>

        <form class="form-horizontal">
            

            <div class="form-group">
                <label for="selectDojo" class="control-label col-xs-2">Dojo:</label>
                <div class="col-xs-4">
                    <select id="selectDojo" class="form-control">
                        <option>Seleccione un Dojo</option>
                    </select>
                </div>
            </div>
        </form>
    </div>


    <div>
        <table id="tableSolisitudes" class="table table-bordered table-striped dataTable">
            <thead>
                <tr>
                    <th>Nombres, Apellidos</th>
                    <th>CI o Pasporte</th>
                    <th>Nombre de usuario</th>
                    <th>Roles</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Rómulo Jose, Rodríguez Rojas</td>
                    <td>19.513.356</td>
                    <td>Eltercera</td>
                    <td>Atleta</td>
                    <td>
                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info" href="#"><a/>
                         <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>



    <div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        
    </div>

    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tableSolisitudes").DataTable({
                "language": {
                    "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                }
            });
        });
    </script>
</asp:Content>
