using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo7;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_DetalleCinta : System.Web.UI.Page
    {
        Cinta cinta = new Cinta();
        LogicaCintas laLogica = new LogicaCintas();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "12";
            String detalleString = Request.QueryString["cintaDetalle"];

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                try
                {
                    cinta = laLogica.detalleCintaID(int.Parse(detalleString));
                    this.colorCinta.Text = cinta.Color_nombre;
                    this.rangoCinta.Text = cinta.Rango;
                    this.clasificacionCinta.Text = cinta.Clasificacion;
                    this.significadoCinta.Text = cinta.Significado;
                    this.ordenCinta.Text = cinta.Orden.ToString();
                    this.fechaObtencionCinta.Text = laLogica.obtenerFechaCinta(1, int.Parse(detalleString)).ToString("MM/dd/yyyy");
                    
                }
                catch(Exception ex)
                {
                }
            }
        }
    }
}