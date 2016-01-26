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
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_ListarHorariodePractica : System.Web.UI.Page
    {
        #region Atributos
        private List<Evento> laLista = new List<Evento>();
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaHorarioPractica logEvento = new LogicaHorarioPractica();
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
                    String detalleStringCompetencia = Request.QueryString["horarioDetalle"];
                    if (!IsPostBack)
                    {
                        try
                        {
                            laLista = logEvento.obtenerListaDePractica(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                            if (laLista != null) 
                            { 
                            foreach (Evento evento in laLista)
                            {
                                this.laTabla.Text += M7_Recursos.AbrirTR;
                                this.laTabla.Text += M7_Recursos.AbrirTD + evento.Nombre.ToString() + M7_Recursos.CerrarTD;
                                this.laTabla.Text += M7_Recursos.AbrirTD + evento.Horario.HoraInicio.ToString() + M7_Recursos.CerrarTD;
                                this.laTabla.Text += M7_Recursos.AbrirTD + evento.Horario.HoraFin.ToString() + M7_Recursos.CerrarTD;
                                this.laTabla.Text += M7_Recursos.AbrirTD + evento.Ubicacion.Ciudad.ToString() + M7_Recursos.CerrarTD;
                                this.laTabla.Text += M7_Recursos.AbrirTD;
                                this.laTabla.Text += M7_Recursos.BotonInfoHorariodePractica + evento.Id_evento + M7_Recursos.BotonCerrar;
                                this.laTabla.Text += M7_Recursos.CerrarTD;
                                this.laTabla.Text += M7_Recursos.CerrarTR;
                            }
                            }
                            else
                            {
                                throw new ListaNulaException(M7_Recursos.Codigo_Lista_Nula,
                                M7_Recursos.Mensaje_Numero_Parametro_invalido, new Exception());
                            }

                        }
                        catch (ListaNulaException)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                            M7_Recursos.MensajeListaNulaLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                    Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                }

            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }            
        }
        #endregion
    }
}