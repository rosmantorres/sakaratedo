using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo8;
using DominioSKD;

namespace templateApp.GUI.Modulo8
{
    public partial class interfazCrearRestriccionAvanceCinta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ((SKD)Page.Master).IdModulo = "8";
            if (!IsPostBack)
            {
               
                //llenarComboRestriccionCinta();
                llenarComboCinta();
            }

        }

      /*  protected void llenarComboRestriccionCinta()
        {

            LogicaNegociosSKD.Modulo8.LogicaRestriccionCinta lRC = new LogicaNegociosSKD.Modulo8.LogicaRestriccionCinta();
            List<RestriccionCinta> listRestriccionCinta = new List<RestriccionCinta>();
            listRestriccionCinta = lRC.obtenerListaDeRestriccionCinta();
            Dictionary<string, string> options = new Dictionary<string, string>();

            options.Add("-1", "Selecciona una opcion");
            try
            {
                foreach (RestriccionCinta item in listRestriccionCinta)
                {
                    options.Add(item.IdRestriccionCinta.ToString(), item.Descripcion);
                }
                options.Add("-2", "OTRO");
            }
            catch (Exception e)
            {

            }

            comboRestCinta.DataSource = options;
            comboRestCinta.DataTextField = "value";
            comboRestCinta.DataValueField = "key";
            comboRestCinta.DataBind();
        }*/

        protected void llenarComboCinta()
        {

            LogicaNegociosSKD.Modulo8.LogicaRestriccionCinta lRC = new LogicaNegociosSKD.Modulo8.LogicaRestriccionCinta();
            List<Cinta> listCinta = new List<Cinta>();
            listCinta = lRC.obtenerListaDeCinta();
            Dictionary<string, string> options = new Dictionary<string, string>();

            options.Add("-1", "Selecciona una opcion");
            try
            {
                foreach (Cinta item in listCinta)
                {
                    options.Add(item.Id_cinta.ToString(), item.Color_nombre);
                }
                options.Add("-2", "OTRO");
            }
            catch (Exception e)
            {

            }

            comboCinta.DataSource = options;
            comboCinta.DataTextField = "value";
            comboCinta.DataValueField = "key";
            comboCinta.DataBind();
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            string opcionDato=descripcion.Value.ToString();
            string opciondato2 = tiempo_minimo.Value;
            string opciondato3 = tiempo_maximo.Value;
            string opciondato4 = puntaje_minimo.Value;
            string opciondato5 = horas_docentes.Value;

           
            RestriccionCinta Restriccion = new RestriccionCinta(opcionDato, Int32.Parse(opciondato2), Int32.Parse(opciondato3), Int32.Parse(opciondato4), Int32.Parse(opciondato5));

            LogicaRestriccionCinta LRC = new LogicaRestriccionCinta();

            if (this.comboCinta.SelectedValue != "-1" && this.comboCinta.SelectedValue != "-2")
            {
                LRC.AgregarRestriccionCinta(Restriccion, Int32.Parse(this.comboCinta.SelectedValue));
            }

        }

    }
}