<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_EstadisticaEntrenamiento.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_EstadisticaEntrenamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <link rel="stylesheet" type="text/css" href="Estilo/tournaments.css">

    <script src="https://twitter.github.io/typeahead.js/releases/0.10.4/typeahead.bundle.js"></script>

    <script>


        $(function () {
            var $SelectedCompany = $('#selectedCompany').hide(),
                companyList = [{ "Key": 1, "Value": "Alejandro Gonzalez" }, { "Key": 2, "Value": "Eduardo Schwank" }, { "Key": 4, "Value": "Eduardo Pacheco" }, { "Key": 5, "Value": "Chuck Norris" }];

            var companies = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Value'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                local: companyList
            
            });

            companies.initialize();

            $('#selecAtleta').typeahead({ highlight: true, minLength: 2 }, {
                name: 'companies', displayKey: 'Value', source: companies.ttAdapter()
            })
            .on("typeahead:selected", function (obj, company) {
                $SelectedCompany.html("Selected Company: " + JSON.stringify(company)).show();
            });

            $('#selecRival').typeahead({ highlight: true, minLength: 2 }, {
                name: 'companies', displayKey: 'Value', source: companies.ttAdapter()
            })
            .on("typeahead:selected", function (obj, company) {
                $SelectedCompany.html("Selected Company: " + JSON.stringify(company)).show();
            });

        });
    </script>

    <form class="form-inline">
        <div class="form-group">
            <label for="name">Atleta</label>
            <input type="text" class="form-control" id="selecAtleta" placeholder="Ingrese Atleta">
        </div>
        <div class="form-group">
            <label for="name">Rival</label>
            <input type="text" class="form-control" id="selecRival" placeholder="Ingrese Rival">
        </div>
        <button type="submit" class="btn btn-default">Ver</button>
    </form>

    
 
   
    

    <table id="resultados" class="">

        <tbody>

            <tr>
                <td class="playername" data-name="Alejandro Gonzalez">
                    <div class="flagh">
                        <img src="Fotos-Atletas/Venezuela.png">
                    </div>
                    Alejandro Gonzalez</td>
                <td id="spec"><span></span> </td>
                <td class="opponentname" data-name="Eduardo Schwank">Eduardo Schwank<div class="flagh">
                    <img src="Fotos-Atletas/Venezuela.png">
                </div>
                </td>
            </tr>
            <tr>
                <td class="plimage" data-name="Alejandro Gonzalez">
                    <img src="Fotos-Atletas/AlejandroGonzalez.jpg"></td>
                <td class="rezultat">4 : 11</td>
                <td class="plimage" data-name="EduardoSchwank">
                    <img src="Fotos-Atletas/EduardoSchwank.jpg"></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="playerdata">24</td>
                <td class="playerdatam">Edad</td>
                <td class="playerdata">25</td>
            </tr>
            <tr>
                <td class="playerdata">Venezuela</td>
                <td class="playerdatam">Pais</td>
                <td class="playerdata">Venezuela</td>
            </tr>
            <tr>
                <td class="playerdata">6'1" (185 cm)</td>
                <td class="playerdatam">Altura</td>
                <td class="playerdata">6'1" (185 cm)</td>
            </tr>
            <tr>
                <td class="playerdata">187 lbs (85 kg)</td>
                <td class="playerdatam">Peso</td>
                <td class="playerdata">188 lbs (85 kg)</td>
            </tr>

             <tr>
                <td class="playerdata">9eno Kyu</td>
                <td class="playerdatam">Kyu</td>
                <td class="playerdata">9eno Kyu</td>
            </tr>
           
        </tbody>
    </table>
     <div id="progress">
        <div id="playerprogres" style="width: 25.3%">26.7%</div>
        <div id="oppprogres" style="width: 69.7%;">73.3%</div>
    </div>






</asp:Content>

