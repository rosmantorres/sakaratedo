using DominioSKD;
using Interfaz_Contratos.Modulo11;
using LogicaNegociosSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interfaz_Presentadores.Modulo11
{
    public class PresentadorListaResultado
    {
        IContratoListarResultadoCompetencia vista;

        public PresentadorListaResultado(IContratoListarResultadoCompetencia vista)
        {
            this.vista = vista;
        }

        public void ObtenerUrls_ObtenerAlerts()
        {
            string success = HttpContext.Current.Request.QueryString[M11_RecursosPresentador.Success];

            if (success != null)
            {
                if (success.Equals(M11_RecursosPresentador.AlertAscensoExitoAgregar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlAscensoExitoAgregado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertAscensoModificado))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlAscensoExitoModificado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertAscensoErrorAgregar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlAscensoErrorAgregar;
                }
                if (success.Equals(M11_RecursosPresentador.AlertAscensoErrorModificar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlAscensoErrorModificar;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKataModificado))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKataExitoModificado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKataErrorModificar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKataErrorModificado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKumiteModificar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKumiteExitoModificado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKumiteErrorModificar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKumiteErrorModificado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKataKumiteModificar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKataKumiteExitoModificado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKataKumiteErrorModificar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKataKumietErrorModificado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKataExitoAgregar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKataExitoAgregado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKataErrorAgregar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKataErrorAgregado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKumiteExitoAgregar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKumiteAgregado;

                }
                if (success.Equals(M11_RecursosPresentador.AlertKumiteErrorAgregar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKumiteErrorAgregado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKataKumiteExitoAgregar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKataKumiteExitoAgregado;
                }
                if (success.Equals(M11_RecursosPresentador.AlertKataKumiteErrorAgregar))
                {
                    vista.alertaClase = M11_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M11_RecursosPresentador.Alerta;
                    vista.alerta = M11_RecursosPresentador.InnerHtmlKataKumiteErrorAgregado;
                }
            }
        }

        public void CargaTablaEventosCompetencias()
        {
            try
            {
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListarResultadosEventosPasados();
                List<Entidad> eventos = comando.Ejecutar();
                foreach (Entidad evento in eventos)
                {
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTR;
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Evento)evento).Id.ToString() + M11_RecursosPresentador.CerrarTD;
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Evento)evento).Nombre.ToString() + M11_RecursosPresentador.CerrarTD;
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD + String.Format(M11_RecursosPresentador.FormatoFechas, ((DominioSKD.Entidades.Modulo10.Evento)evento).Horario.FechaInicio) + M11_RecursosPresentador.CerrarTD;
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Evento)evento).TipoEvento.Nombre.ToString() + M11_RecursosPresentador.CerrarTD;

                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD;
                    vista.Tabla.Text += M11_RecursosPresentador.BotonInfoEvento + ((DominioSKD.Entidades.Modulo10.Evento)evento).Id + M11_RecursosPresentador.BotonCerrar;
                    vista.Tabla.Text += M11_RecursosPresentador.BotonModificarEvento + ((DominioSKD.Entidades.Modulo10.Evento)evento).Id + M11_RecursosPresentador.BotonCerrar;
                    vista.Tabla.Text += M11_RecursosPresentador.CerrarTD;
                    vista.Tabla.Text += M11_RecursosPresentador.CerrarTR;
                }

                Comando<List<Entidad>> comando2 = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListarResultadosCompetenciasPasado();
                List<Entidad> competencias = comando2.Ejecutar();
                foreach (Entidad competencia in competencias)
                {
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTR;
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id.ToString() + M11_RecursosPresentador.CerrarTD;
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Nombre.ToString() + M11_RecursosPresentador.CerrarTD;
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD + String.Format(M11_RecursosPresentador.FormatoFechas, ((DominioSKD.Entidades.Modulo12.Competencia)competencia).FechaInicio) + M11_RecursosPresentador.CerrarTD;
                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD + M11_RecursosPresentador.Competencia + M11_RecursosPresentador.CerrarTD;

                    vista.Tabla.Text += M11_RecursosPresentador.AbrirTD;
                    vista.Tabla.Text += M11_RecursosPresentador.BotonInfoCompetencia + ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id + M11_RecursosPresentador.BotonCerrar;
                    vista.Tabla.Text += M11_RecursosPresentador.BotonModificarCompetencia + ((DominioSKD.Entidades.Modulo12.Competencia)competencia).Id + M11_RecursosPresentador.BotonCerrar;
                    vista.Tabla.Text += M11_RecursosPresentador.CerrarTD;
                    vista.Tabla.Text += M11_RecursosPresentador.CerrarTR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
