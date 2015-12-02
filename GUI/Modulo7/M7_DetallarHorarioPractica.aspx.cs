using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using LogicaNegociosSKD.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_DetallarHorarioPractica : System.Web.UI.Page
    {
        Evento evento = new Evento();
        Competencia competencia = new Competencia();
        LogicaHorarioPractica laLogica = new LogicaHorarioPractica();

        /// <summary>
        /// Metodo que se ejecuta cuando carga la pagina
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
                    String detalleStringEvento = Request.QueryString["horarioDetalle"];

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                try
                {
                    evento = laLogica.detalleEventoID(int.Parse(detalleStringEvento));
                    if (evento != null)
                    {                      
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
                    else
                    {
                         throw new ObjetoNuloException(M7_Recursos.Codigo_Numero_Parametro_Invalido,
                         M7_Recursos.MensajeObjetoNuloLogger, new Exception());
                    }
                }
                        catch (ObjetoNuloException)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M7_Recursos.MensajeObjetoNuloLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                        catch (NumeroEnteroInvalidoException)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M7_Recursos.Mensaje_Numero_Parametro_invalido, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                        catch (Exception ex)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
       
        }
    }
}