<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/SKD.Master" AutoEventWireup="true" CodeBehind="M13_Asistencia_Evento.aspx.cs" Inherits="templateApp.GUI.Modulo13.M13_ListarMorosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">Asistencia a Eventos</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">Eventos</asp:Content>
   

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    
    <script type="text/javascript">
         <!--
        function llenar_tabla() {           
        
    }
    //-->
      </script>
    
  <div class="form-group">
                
             <input id="Cedula" type="text"  class="typeahead" placeholder="Buscar por cedula">
             <button type="submit" onclick=llenar_tabla() class="btn btn-primary"> Submit</button>       
  
  </div>  


    <div class="newsheader_eventhead">
		<table border="0" padding="5" cellspacing="5">
			<tbody><tr>
				<td align="left">
					<img src="Imagenes/ven.png" alt="" height="100px">			</td>
				<td align="left">
					<div class="newsheader_eventhead_text">
					PATRICIA<br>GINON<br>CARACAS		</div>
				</td>
				<td aligh="left">
			<img src="Fotos-Atletas/5813.jpg" alt="" height="100px">			</td>
			</tr>
		</tbody>
        </table>
	</div>

 <script src="https://twitter.github.io/typeahead.js/releases/0.10.4/typeahead.bundle.js"></script>
 <script>

     $(function () {
         var $SelectedCompany = $('#selectedCompany').hide(),
         companyList = [{ "Key": 1, "Value": "19162756" }, { "Key": 2, "Value": "19162757" }, { "Key": 4, "Value": "19162758" }, { "Key": 5, "Value": "19162759" }];

         var companies = new Bloodhound({
             datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Value'),
             queryTokenizer: Bloodhound.tokenizers.whitespace,
             local: companyList
             //,prefetch: '/path/to/prefetch'
             //,remote: {/* You can use this for ajax call*/ } 
         });

         companies.initialize();

         $('#Cedula').typeahead({ highlight: true, minLength: 2 }, {
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

    <br> <br />  


   


    <div class="box-body table-responsive">
    <table id="example" class="table table-bordered table-striped dataTable">
       <thead>
              <tr>
                   
                   <th>Competici&oacuten</th>
                   <th>Ranking</th>
                   <th>Año</th>
                   <th>Modalidad</th>
                  <th>Match Ganados</th>

              </tr>
        </thead>
     <tbody>
              <tr>	
                   
                   <td style="text-align:center">Torneo de las americas</td>
                   <td style="text-align:center">Primer Lugar</td>
                  <td style="text-align:center">2015</td>
                  <td style="text-align:center">Kumite</td>  
                   <td style="text-align:center">5</td>                 
               </tr>                            
     
     
               <tr>	
                 
                   <td style="text-align:center">Torneo Clasificatorio</td>
                   <td style="text-align:center">Segundo Lugar</td>
                  <td style="text-align:center">2015</td>
                  <td style="text-align:center">Kumite</td>
                   <td style="text-align:center">4</td>                 
               </tr>                            
           <tr>	
                   
                   <td style="text-align:center">Torneo de las artes marciales </td>
                   <td style="text-align:center">Tercer Lugar</td>
                  <td style="text-align:center">2015</td>
                  <td style="text-align:center">Kumite</td>  
                   <td style="text-align:center">3</td>                 
               </tr>                            
     
     
               <tr>	
                 
                   <td style="text-align:center">Torneo Excelsior</td>
                   <td style="text-align:center"> Participaci&oacuten</td>
                  <td style="text-align:center">2015</td>
                  <td style="text-align:center">Kumite</td>
                   <td style="text-align:center">0</td>                 
               </tr>

       
                                           
      

        </table>
    </div>

   
     <script type="text/javascript">
         $(document).ready(function () {

             var table = $('#example').DataTable({
                 "language": {
                     "url": "http://cdn.datatables.net/plug-ins/1.10.9/i18n/Spanish.json"
                 }
             });
             var req;
             var tr;

         })

         </script>
     

</asp:Content>
