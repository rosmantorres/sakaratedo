using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD.Comandos.Modulo7;
using LogicaNegociosSKD.Fabrica;
using System;
using DominioSKD.Entidades.Modulo7;

namespace Interfaz_Presentadores.Modulo7
{
    /// <summary>
    /// Presentador para detallar evento
    /// </summary>
    public class PresentadorDetallarEvento
    {
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
        public void CargarDatos(Entidad idEvento)
        {
            try
            {
                ComandoConsultarDetallarEvento comandoDetallarEvento = (ComandoConsultarDetallarEvento)FabricaComandos.ObtenerComandoConsultarDetallarEvento();
                comandoDetallarEvento.LaEntidad = idEvento;
                EventoM7 evento = (EventoM7)comandoDetallarEvento.Ejecutar();

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
                vista.fechaFin_evento = evento.Horario.FechaFin.ToString(M7_RecursosPresentador.FormatoFecha);
                vista.fechaInicio_evento = evento.Horario.FechaInicio.ToString(M7_RecursosPresentador.FormatoFecha);
                vista.horaFin_evento = evento.Horario.HoraFin.ToString();
                vista.horaInicio_evento = evento.Horario.HoraInicio.ToString();
                vista.nombre_evento = evento.Nombre;
                             
            }
            catch (NumeroEnteroInvalidoException)
            {
            }
            catch (FormatException)
            {
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
