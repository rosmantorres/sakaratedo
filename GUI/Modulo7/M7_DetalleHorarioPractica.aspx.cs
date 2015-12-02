using DominioSKD;
using LogicaNegociosSKD.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_DetalleHorarioPractica : System.Web.UI.Page
    {
        Evento evento = new Evento();
        LogicaHorarioPractica laLogica = new LogicaHorarioPractica();

        /// <summary>
        /// Metodo que se ejecuta cuando carga la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
            String detalleStringEvento = Request.QueryString["horarioDetalle"];

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                try
                {
                    if (detalleStringEvento != null)
                    {
                        evento = laLogica.detalleEventoID(int.Parse(detalleStringEvento));
                        this.nombre_evento.Text = evento.Nombre;
                        this.descripcion_evento.Text = evento.Descripcion.ToString();
                        
                        if (evento.Estado.Equals(true))
                        {
                            this.estado_evento.Text = M7_Recursos.AliasEventoActivo;
                        }
                        else if (evento.Estado.Equals(false))
                        {
                            this.estado_evento.Text = M7_Recursos.AliasEventoInactivo;
                        }
                        this.horaInicio_evento.Text = evento.Horario.HoraInicio.ToString();
                        this.horaFin_evento.Text = evento.Horario.HoraFin.ToString();
                        this.direccion_evento.Text = evento.Ubicacion.Direccion;

                    }
                }
                catch (Exception ex)
                {
                }
            }
       
        }
    }
}