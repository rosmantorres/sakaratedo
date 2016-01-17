using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo7
{
    /// <summary>
    /// Presentador para detallar evento
    /// </summary>
    public class PresentadorDetallarEvento
    {
        private FabricaComandos fabricaComandos;
        private IContratoDetallarEvento vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarEvento(IContratoDetallarEvento laVista)
        {
            vista = laVista;
        }


        /// <summary>
        /// Método para cargar los datos del evento
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        public void cargarDatos(Evento idEvento)
        {
            try
            {
                fabricaComandos = new FabricaComandos();
                ComandoConsultarDetallarEvento comandoDetallarEvento = (ComandoConsultarDetallarEvento)fabricaComandos.ObtenerComandoConsultarDetallarEvento();
                comandoDetallarEvento.LaEntidad = idEvento;
                Evento evento = (Evento)comandoDetallarEvento.Ejecutar();

                vista.ciudad_evento = evento.Ubicacion.Ciudad;
                vista.costo_evento = evento.Costo.ToString();
                vista.descripcion_evento = evento.Descripcion;
                vista.direccionEvento_evento = evento.Ubicacion.Direccion;
                vista.estadoUbicacion_evento = evento.Ubicacion.Estado;
                if (evento.Estado.Equals(true))
                {
                    vista.estado_evento = M7_RecursosPresentador.AliasEventoActivo;
                }
                else if (evento.Estado.Equals(false))
                {
                    vista.estado_evento = M7_RecursosPresentador.AliasEventoInactivo;
                }
                vista.fechaFin_evento = evento.Horario.FechaFin.ToString("MM/dd/yyyy");
                vista.fechaInicio_evento = evento.Horario.FechaInicio.ToString("MM/dd/yyyy");
                vista.horaFin_evento = evento.Horario.HoraFin.ToString();
                vista.horaInicio_evento = evento.Horario.HoraInicio.ToString();
                vista.nombre_evento = evento.Nombre;
                             
            }
            catch (NumeroEnteroInvalidoException)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
    M7_RecursosPresentador.Mensaje_Numero_Parametro_invalido, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FormatException)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
    M7_RecursosPresentador.Mensaje_Numero_Parametro_invalido, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception)
            {
            }
        }
    }
}
