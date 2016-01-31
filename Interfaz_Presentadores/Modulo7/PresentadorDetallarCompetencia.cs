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
using DominioSKD.Entidades.Modulo7;

namespace Interfaz_Presentadores.Modulo7
{
    /// <summary>
    /// Presentador para detallar competencia
    /// </summary>
    public class PresentadorDetallarCompetencia
    {
        private IContratoDetallarCompetencia vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarCompetencia(IContratoDetallarCompetencia laVista)
        {
            vista = laVista;
        }


        /// <summary>
        /// Método para cargar los datos de la competencia
        /// </summary>
        /// <param name="idCompetencia">id de la competencia</param>
        public void CargarDatos(Entidad idCompetencia)
        {
            try
            {
                ComandoConsultarDetallarCompetencia comandoDetallarCompetencia = (ComandoConsultarDetallarCompetencia)FabricaComandos.ObtenerComandoConsultarDetallarCompetencia();
                comandoDetallarCompetencia.LaEntidad = idCompetencia;
                CompetenciaM7 cinta = (CompetenciaM7)comandoDetallarCompetencia.Ejecutar();

                vista.ciudad_evento = cinta.Ubicacion.Ciudad;
                vista.costo_evento = cinta.Costo.ToString();
                vista.direccion_evento = cinta.Ubicacion.Direccion;
                vista.estadoUbicacion_evento = cinta.Ubicacion.Estado;
                vista.fechaFin_evento = cinta.FechaFin.ToString(M7_RecursosPresentador.FormatoFecha);
                vista.fechaInicio_evento = cinta.FechaInicio.ToString(M7_RecursosPresentador.FormatoFecha);
                vista.nombre_evento = cinta.Nombre;
                vista.tipo_evento = M7_RecursosPresentador.AliasTipoEventoCompetencia;
                
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
