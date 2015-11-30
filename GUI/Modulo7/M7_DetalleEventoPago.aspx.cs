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
    public partial class M7_DetalleEventoPago : System.Web.UI.Page
    {
        Evento evento = new Evento();
        Competencia competencia = new Competencia();
        LogicaEventosAsistidos laLogica = new LogicaEventosAsistidos();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
            String detalleStringEvento = Request.QueryString["eventoDetalle"];
            String detalleStringCompetencia = Request.QueryString["compDetalle1"];

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                try
                {
                    if (detalleStringEvento != null)
                    {
                        evento = laLogica.detalleEventoID(int.Parse(detalleStringEvento));
                        this.nombre_evento.Text = evento.Nombre;
                        this.descripcion_evento.Text = evento.Descripcion.ToString();
                        this.costo_evento.Text = evento.Costo.ToString();
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
                        this.fechaInicio_evento.Text = evento.Horario.FechaInicio.ToString("MM/dd/yyyy");
                        this.fechaFin_evento.Text = evento.Horario.FechaFin.ToString("MM/dd/yyyy");
                        this.estadoUbicacion_evento.Text = evento.Ubicacion.Estado.ToString();
                        this.ciudad_evento.Text = evento.Ubicacion.Ciudad.ToString();
                        this.direccion_evento.Text = evento.Ubicacion.Direccion;

                    }

                    else
                    { 
                       
                         competencia = laLogica.detalleCompetenciaID(int.Parse(detalleStringCompetencia));
                         this.nombre_evento.Text = "hola";
                         this.descripcion_evento.Text = competencia.TipoCompetencia;
                         this.costo_evento.Text = competencia.Costo.ToString();
                         this.estado_evento.Text = competencia.Status;
                         this.fechaInicio_evento.Text = competencia.FechaInicio.ToString("MM/dd/yyyy");
                         this.fechaFin_evento.Text = competencia.FechaFin.ToString("MM/dd/yyyy");
                         this.estadoUbicacion_evento.Text = competencia.Ubicacion.Estado.ToString();
                         this.ciudad_evento.Text = competencia.Ubicacion.Ciudad.ToString();
                         this.direccion_evento.Text = competencia.Ubicacion.Direccion;
                    }

                }
                catch (Exception ex)
                {
                }
            }
       
        }
    }
}