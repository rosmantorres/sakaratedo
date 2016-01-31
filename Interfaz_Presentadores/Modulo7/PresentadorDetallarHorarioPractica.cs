using DominioSKD;
using DominioSKD.Entidades.Modulo7;
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
    public class PresentadorDetallarHorarioPractica
    {
        private IContratoDetallarHorarioPractica vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarHorarioPractica(IContratoDetallarHorarioPractica laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Método para cargar los datos del Horario
        /// </summary>
        /// <param name="idEvento">id del evento</param>
        public void CargarDatosHorario(Entidad idEvento)
        {
            try
            {
                ComandoConsultarDetallarHorarioPractica comandoDetallarEvento = (ComandoConsultarDetallarHorarioPractica)FabricaComandos.ObtenerComandoConsultarDetallarHorarioPractica();
                comandoDetallarEvento.LaEntidad = idEvento;
                EventoM7 evento = (EventoM7)comandoDetallarEvento.Ejecutar();

                vista.descripcion_evento = evento.Descripcion;
                vista.direccionEvento_evento = evento.Ubicacion.Direccion;
                if (evento.Estado.Equals(true))
                {
                    vista.estado_evento = M7_RecursosPresentador.AliasEventoActivo;
                }
                else if (evento.Estado.Equals(false))
                {
                    vista.estado_evento = M7_RecursosPresentador.AliasEventoInactivo;
                }
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
