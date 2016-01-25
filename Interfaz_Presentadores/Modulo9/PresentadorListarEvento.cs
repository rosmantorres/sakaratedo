using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo9;
using System.Web;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using DominioSKD;
using DominioSKD.Fabrica;
using LogicaNegociosSKD.Fabrica;



namespace Interfaz_Presentadores.Modulo9
{
   public class PresentadorListarEventos
    {

        private IContratoListarEventos vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorListarEventos(IContratoListarEventos laVista)
        {
            this.vista = laVista;
        }
        public void ObtenerVariablesURL()
        {

            String success = HttpContext.Current.Request.QueryString[M9_RecursoInterfazPresentador.strSuccess];
            String detalleString = HttpContext.Current.Request.QueryString[M9_RecursoInterfazPresentador.strEventoDetalle];


            if (detalleString != null)
            {

            }

            if (success != null)
            {
                if (success.Equals(M9_RecursoInterfazPresentador.idAlertAgregar))
                {
                    vista.alertaClase = M9_RecursoInterfazPresentador.alertaSuccess;
                    vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M9_RecursoInterfazPresentador.innerHtmlAlertAgregar;

                }

                if (success.Equals(M9_RecursoInterfazPresentador.idAlertModificar))
                {
                    vista.alertaClase = M9_RecursoInterfazPresentador.alertaSuccess;
                    vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M9_RecursoInterfazPresentador.innerHtmlAlertModificar;
                }

            }
        }
        public void ListarEventos(String idPersona)
        {
            try
            {
               // FabricaEntidades fabricaEntidades = new FabricaEntidades();
                DominioSKD.Entidades.Modulo9.Evento a = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
                a.Id = int.Parse(idPersona);
                LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaEventos comandoListarEventos = (LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaEventos)FabricaComandos.ObtenerComandoConsultarListaEventos(a);
                List<Entidad> listaEventos = comandoListarEventos.Ejecutar();

                foreach (Entidad row in listaEventos)
                {
                    DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)row;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTR;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD + evento.Nombre.ToString() + M9_RecursoInterfazPresentador.CerrarTD;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD + evento.TipoEvento.Nombre.ToString() + M9_RecursoInterfazPresentador.CerrarTD;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD + String.Format("{0:dd/MM/yyyy}", evento.Horario.FechaInicio) + M9_RecursoInterfazPresentador.CerrarTD;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD + String.Format("{0:dd/MM/yyyy}", evento.Horario.FechaFin) + M9_RecursoInterfazPresentador.CerrarTD;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD + evento.Horario.HoraInicioS + M9_RecursoInterfazPresentador.CerrarTD;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD + evento.Horario.HoraFinS + M9_RecursoInterfazPresentador.CerrarTD;
                    if (evento.Estado)
                    {
                        vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD + "Activo" + M9_RecursoInterfazPresentador.CerrarTD;
                    }
                    else
                    {
                        vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD + "Inactivo" + M9_RecursoInterfazPresentador.CerrarTD;
                    }

                    vista.ilaTabla += M9_RecursoInterfazPresentador.AbrirTD;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.BotonInfo + evento.Id + M9_RecursoInterfazPresentador.BotonCerrar;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.BotonModificar + evento.Id + M9_RecursoInterfazPresentador.BotonCerrar;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.CerrarTD;
                    vista.ilaTabla += M9_RecursoInterfazPresentador.CerrarTR;
                }

            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M9_RecursoInterfazPresentador.alertaHtml + ex.Mensaje
                    + M9_RecursoInterfazPresentador.alertaHtmlFinal;

            }
        }
    }
}
