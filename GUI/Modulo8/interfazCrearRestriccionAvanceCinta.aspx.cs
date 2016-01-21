using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo8
{
    public partial class interfazCrearRestriccionAvanceCinta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            string opcionDato = descripcion.Value.ToString();
            string opciondato2 = tiempo_minimo.Value;
            string opciondato3 = tiempo_maximo.Value;
            string opciondato4 = puntaje_minimo.Value;
            string opciondato5 = horas_docentes.Value;


            /*RestriccionCinta Restriccion = new RestriccionCinta(opcionDato, Int32.Parse(opciondato2), Int32.Parse(opciondato3), Int32.Parse(opciondato4), Int32.Parse(opciondato5));

            LogicaRestriccionCinta LRC = new LogicaRestriccionCinta();

            if (this.comboCinta.SelectedValue != "-1" && this.comboCinta.SelectedValue != "-2")
            {
                LRC.AgregarRestriccionCinta(Restriccion, Int32.Parse(this.comboCinta.SelectedValue));
            }*/

        }
    }
}