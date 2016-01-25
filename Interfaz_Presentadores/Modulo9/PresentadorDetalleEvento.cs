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
    public class PresentadorDetalleEvento
    {
        private IContratoDetalleEvento vista;
        public PresentadorDetalleEvento(IContratoDetalleEvento laVista)
        {
            this.vista = laVista;
        }
        /// <summary>
        /// Metodo para consultar las variables del url
        /// </summary>
        public void ObtenerVariableURL()
        {
            String detalleString = HttpContext.Current.Request.QueryString[M9_RecursoInterfazPresentador.strEventoDetalle];
            if (detalleString != null)
                DetallarEvento(int.Parse(detalleString));
        }
        public void DetallarEvento(int iD)
        {
            try
            {
                //FabricaEntidades fabricaEntidades = new FabricaEntidades();
                DominioSKD.Entidades.Modulo9.Evento entidad = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
                entidad.Id = iD;
                Comando<Entidad> comandoDetallarEvento = FabricaComandos.ObtenerComandoConsultarEvento(entidad);
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)comandoDetallarEvento.Ejecutar();
                vista.iNombreEvento = evento.Nombre;
                vista.iTipoEvento = evento.TipoEvento.Nombre;
                vista.iCostoEvento = evento.Costo.ToString();
                vista.iDescripcionEvento = evento.Descripcion;
                vista.iFechaInicio = evento.Horario.FechaInicio.ToShortDateString();
                vista.iFechaFin = evento.Horario.FechaFin.ToShortDateString();
                vista.iHoraInicio = evento.Horario.HoraInicioS;
                vista.iHoraFin = evento.Horario.HoraFinS;
                if (evento.Estado)
                {
                    vista.iStatusEvento = "Activo";
                }
                else
                {
                    vista.iStatusEvento = "Inactivo";
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
