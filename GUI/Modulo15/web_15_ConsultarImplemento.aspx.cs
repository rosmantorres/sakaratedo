using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using Interfaz_Contratos.Modulo15;
using Interfaz_Presentadores.Modulo15;

namespace templateApp.GUI.Modulo15
{
    public partial class web_15_ConsultarImplemento : System.Web.UI.Page,IContratoConsultarImplemento
    {
        private List<Entidad> laLista = new List<Entidad>();
        private PresentadorConsultarImplemento presentador;
       
        public web_15_ConsultarImplemento()
        {
            presentador = new PresentadorConsultarImplemento(this);
        }


        string IContratoConsultarImplemento.tabla
        {
            get
            {
                return tabla.Text;
            }
            set
            {
                tabla.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "15";



             List<Entidad> listaImplementos = presentador.cargarListaImplementos();
             
            foreach (Entidad valorActual in listaImplementos)
            {
                this.tabla.Text+="<tr>";
                this.tabla.Text+="<td>" + ((Implemento)valorActual).Id_Implemento + "</td>";
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Nombre_Implemento + "</td>";
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Tipo_Implemento + "</td>";
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Marca_Implemento + "</td>";
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Color_Implemento + "</td>";
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Talla_Implemento + "</td>";
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Cantida_implemento + "</td>";
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Stock_Minimo_Implemento + "</td>";
                if (((Implemento)valorActual).Stock_Minimo_Implemento > ((Implemento)valorActual).Cantida_implemento)
                {
                    this.tabla.Text+="<td><div class='panel panel-default caja'><div class='panel-body alert-error'></div></td>";
                }
                else
                {
                    if (((Implemento)valorActual).Stock_Minimo_Implemento == ((Implemento)valorActual).Cantida_implemento)
                    {
                        this.tabla.Text+="<td><div class='panel panel-default caja'><div class='panel-body alert-warning'></div></td>";

                    }
                    else
                    {
                        if (((Implemento)valorActual).Stock_Minimo_Implemento < ((Implemento)valorActual).Cantida_implemento)
                        {
                            this.tabla.Text+="<td><div class='panel panel-default caja'><div class='panel-body alert-success'></div></td>";
                        }
                    }

                }
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Precio_Implemento + "</td>";
                this.tabla.Text += "<td>" + ((Implemento)valorActual).Precio_Implemento * ((Implemento)valorActual).Cantida_implemento + "</td>";
                this.tabla.Text+="<td>";
                this.tabla.Text+="<a class='btn btn-primary glyphicon glyphicon-info-sign' data-toggle='modal' data-target='#modal-info' href='#'></a>";
                this.tabla.Text += "<a class='btn btn-default glyphicon glyphicon-pencil'  href='web_15_ModificarImplemento.aspx?idImplemento=" + ((Implemento)valorActual).Id_Implemento + "'></a>";
                this.tabla.Text += "<a id='nombre_2' class='eliminar_clase btn btn-danger glyphicon glyphicon-remove-sign' data-id=" + ((Implemento)valorActual).Id_Implemento + " data-toggle='modal' data-target='#modal-delete'></a>";
                this.tabla.Text+="</td>";
                this.tabla.Text+="</tr>";


            }

      //      btnEliminar.Click += new EventHandler(this.eliminarImplemento);     

        }

        public void eliminarImplemento(object sender, EventArgs e){ 
        
        
        }
    }
}