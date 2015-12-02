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
    public partial class DetalleEventoInscrito : System.Web.UI.Page
    {
        Evento evento = new Evento();
        Competencia competencia = new Competencia();
        LogicaEventosInscritos laLogica = new LogicaEventosInscritos();
        /// <summary>
        /// Metodo que se ejecuta cuando se carga la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String rolUsuario = Session[GUI.Master.RecursosInterfazMaster.sessionRol].ToString();
                Boolean permitido = false;
                List<String> rolesPermitidos = new List<string>
                    (new string[] { "Sistema", "Atleta", "Representante", "Atleta(Menor)" });
                foreach (String rol in rolesPermitidos)
                {
                    if (rol == rolUsuario)
                        permitido = true;
                }
                if (permitido)
                {
            ((SKD)Page.Master).IdModulo = "7";
            String detalleStringEvento = Request.QueryString["EventInscDetalle"];
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
                }
                catch (Exception ex)
                {
                }
            }
       
                }
                else
                {
                    Response.Redirect(GUI.Master.RecursosInterfazMaster.direccionMaster_Inicio);
                }

            }
            catch (NullReferenceException ex)
            {


            }

        }
    }
}