using DominioSKD;
using Interfaz_Contratos.Modulo10;
using LogicaNegociosSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interfaz_Presentadores.Modulo10
{
    public class PresentadorListarAsistencia 
    {
        IContratoListarAsistencia vista;

        public PresentadorListarAsistencia(IContratoListarAsistencia vista)
        {
            this.vista = vista;
        }

        public void ObtenerUrls_ObtenerAlerts()
        {
            string success = HttpContext.Current.Request.QueryString[M10_RecursosPresentador.Success];

            if (success != null)
            {
                if (success.Equals(M10_RecursosPresentador.AlertAgregarAsistenciaEvento))
                {
                    vista.alertaClase = M10_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M10_RecursosPresentador.Alerta;
                    vista.alerta = M10_RecursosPresentador.InnerHtmlAgregarAsistenciaEvento;
                }
                if (success.Equals(M10_RecursosPresentador.AlertModificarAsistenciaExito))
                {
                    vista.alertaClase = M10_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M10_RecursosPresentador.Alerta;
                    vista.alerta = M10_RecursosPresentador.InnerHtmlModificarAsistencia;
                }
                if (success.Equals(M10_RecursosPresentador.AlertErrorAgregarEvento))
                {
                    vista.alertaClase = M10_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M10_RecursosPresentador.Alerta;
                    vista.alerta = M10_RecursosPresentador.InnerHtmlErrorAgregarEvento;
                }
                if (success.Equals(M10_RecursosPresentador.AlertAgregarAsistenciaCompetencia))
                {
                    vista.alertaClase = M10_RecursosPresentador.AlertaSuccess;
                    vista.alertaRol = M10_RecursosPresentador.Alerta;
                    vista.alerta = M10_RecursosPresentador.InnerHtmlAgregarAsistenciaCompetencia;
                }
                if (success.Equals(M10_RecursosPresentador.AlertErrorAgregarCompetencia))
                {
                    vista.alertaClase = M10_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M10_RecursosPresentador.Alerta;
                    vista.alerta = M10_RecursosPresentador.InnerHtmlErrorAgregarCompetencia;
                }
                if (success.Equals(M10_RecursosPresentador.AlertErrorModificarAsistencia))
                {
                    vista.alertaClase = M10_RecursosPresentador.AlertaDanger;
                    vista.alertaRol = M10_RecursosPresentador.Alerta;
                    vista.alerta = M10_RecursosPresentador.InnerHtmlErrorModificarAsistencia;
                }
            }
        }

        public void CargaTablaEventosCompetencias()
        {
            try
            {
                Comando<List<Entidad>> comando = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListarEventosAsistidos();
                List<Entidad> listaEntidad = comando.Ejecutar();
                foreach (Entidad entidad in listaEntidad)
                {
                    vista.tabla += M10_RecursosPresentador.AbrirTR;
                    vista.tabla += M10_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Evento)entidad).Id.ToString() + M10_RecursosPresentador.CerrarTD;
                    vista.tabla += M10_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo10.Evento)entidad).Nombre.ToString() + M10_RecursosPresentador.CerrarTD;
                    vista.tabla += M10_RecursosPresentador.AbrirTD + String.Format(M10_RecursosPresentador.FormatoFechas, ((DominioSKD.Entidades.Modulo10.Evento)entidad).Horario.FechaInicio) + M10_RecursosPresentador.CerrarTD;
                    vista.tabla += M10_RecursosPresentador.AbrirTD + M10_RecursosPresentador.Evento + " " + ((DominioSKD.Entidades.Modulo10.Evento)entidad).TipoEvento.Nombre.ToString() + M10_RecursosPresentador.CerrarTD;

                    vista.tabla += M10_RecursosPresentador.AbrirTD;
                    vista.tabla += M10_RecursosPresentador.BotonInfoEvento + ((DominioSKD.Entidades.Modulo10.Evento)entidad).Id + M10_RecursosPresentador.BotonCerrar;
                    vista.tabla += M10_RecursosPresentador.BotonModificarEvento + ((DominioSKD.Entidades.Modulo10.Evento)entidad).Id + M10_RecursosPresentador.BotonCerrar;
                    vista.tabla += M10_RecursosPresentador.CerrarTD;
                    vista.tabla += M10_RecursosPresentador.CerrarTR;
                }

                Comando<List<Entidad>> comando2 = LogicaNegociosSKD.Fabrica.FabricaComandos.ObtenerComandoListarCompetenciasAsistidas();
                List<Entidad> listaEntidad2 = comando2.Ejecutar();
                foreach (Entidad entidad in listaEntidad2)
                {
                    vista.tabla += M10_RecursosPresentador.AbrirTR;
                    vista.tabla += M10_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id.ToString() + M10_RecursosPresentador.CerrarTD;
                    vista.tabla += M10_RecursosPresentador.AbrirTD + ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Nombre.ToString() + M10_RecursosPresentador.CerrarTD;
                    vista.tabla += M10_RecursosPresentador.AbrirTD + String.Format(M10_RecursosPresentador.FormatoFechas, ((DominioSKD.Entidades.Modulo12.Competencia)entidad).FechaInicio) + M10_RecursosPresentador.CerrarTD;
                    vista.tabla += M10_RecursosPresentador.AbrirTD + M10_RecursosPresentador.Competencia + M10_RecursosPresentador.CerrarTD;

                    vista.tabla += M10_RecursosPresentador.AbrirTD;
                    vista.tabla += M10_RecursosPresentador.BotonInfoCompetencia + ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id + M10_RecursosPresentador.BotonCerrar;
                    vista.tabla += M10_RecursosPresentador.BotonModificarCompetencia + ((DominioSKD.Entidades.Modulo12.Competencia)entidad).Id + M10_RecursosPresentador.BotonCerrar;
                    vista.tabla += M10_RecursosPresentador.CerrarTD;
                    vista.tabla += M10_RecursosPresentador.CerrarTR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
