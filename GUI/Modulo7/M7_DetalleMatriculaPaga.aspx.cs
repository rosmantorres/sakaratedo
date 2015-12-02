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
    public partial class M7_DetalleMatriculaPaga : System.Web.UI.Page
    {
        Matricula matricula = new Matricula();
        LogicaMatriculasPagas Logica = new LogicaMatriculasPagas();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
            String detalleStringMatricula = Request.QueryString["matriculaDetalle"];
           

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                try
                {
                    
                    if (detalleStringMatricula != null)
                    {
                        matricula = Logica.detalleMatriculaID(int.Parse(detalleStringMatricula));
                        this.identificador.Text = matricula.Identificador.ToString();
                        this.fecha_creacion.Text = matricula.FechaCreacion.ToString("MM/dd/yyyy");
                        this.fecha_pago.Text = matricula.UltimaFechaPago.ToString("MM/dd/yyyy");

                    } 


                }
                catch (Exception ex)
                {
                }
            }

        }
    }
}
   

