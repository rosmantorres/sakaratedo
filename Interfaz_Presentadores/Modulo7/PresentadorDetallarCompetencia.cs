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
    /// Presentador para detallar competencia
    /// </summary>
    public class PresentadorDetallarCompetencia
    {
        private FabricaComandos fabricaComandos;
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
        /// <param name="idCliente">id del cliente</param>
        public void cargarDatos(Competencia idCompetencia)
        {
            try
            {
                fabricaComandos = new FabricaComandos();
                ComandoConsultarDetallarCompetencia comandoDetallarCompetencia = (ComandoConsultarDetallarCompetencia)fabricaComandos.ObtenerComandoConsultarDetallarCompetencia();
                comandoDetallarCompetencia.LaEntidad = idCompetencia;
                Competencia cinta = (Competencia)comandoDetallarCompetencia.Ejecutar();

                vista.ciudad_evento = cinta.Ubicacion.Ciudad;
                vista.costo_evento = cinta.Costo.ToString();
                vista.direccion_evento = cinta.Ubicacion.Direccion;
                vista.estadoUbicacion_evento = cinta.Ubicacion.Estado;
                vista.fechaFin_evento = cinta.FechaFin.ToString("MM/dd/yyyy");
                vista.fechaInicio_evento = cinta.FechaInicio.ToString("MM/dd/yyyy");
                vista.nombre_evento = cinta.Nombre;
                vista.tipo_evento = M7_RecursosPresentador.AliasTipoEventoCompetencia;
                
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
