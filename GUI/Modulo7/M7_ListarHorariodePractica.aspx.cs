using DominioSKD;
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
        private Horario horario;
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
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        #endregion
    }
}