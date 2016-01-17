using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD;
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
    /// Presentador para detallar cinta
    /// </summary>
    public class PresentadorDetallarCinta
    {
        private FabricaComandos fabricaComandos;
        private IContratoDetallarCinta vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarCinta(IContratoDetallarCinta laVista)
        {
            vista = laVista;
        }


        /// <summary>
        /// Método para cargar los datos de la cinta
        /// </summary>
        /// <param name="idCinta">id de la cinta</param>
        /// <param name="idPersona">id de la persona</param>
        public void cargarDatos(Cinta idCinta, Persona idPersona)
        {           
            try
            {
                fabricaComandos = new FabricaComandos();
                ComandoConsultarDetallarCinta comandoDetallarCinta =(ComandoConsultarDetallarCinta)fabricaComandos.ObtenerComandoConsultarDetallarCinta();
                comandoDetallarCinta.LaEntidad = idCinta;
                comandoDetallarCinta.IdPersona = idPersona;
                Tuple<Entidad, DateTime> tupla = comandoDetallarCinta.Ejecutar();
                Cinta cinta = (Cinta)tupla.Item1;
                DateTime fechaObtencionCinta = tupla.Item2;
                
                vista.clasificacionCinta = cinta.Clasificacion;
                vista.colorCinta = cinta.Color_nombre;
                vista.fechaObtencionCinta = fechaObtencionCinta.ToString("MM/dd/yyyy");
                vista.ordenCinta = cinta.Orden.ToString();
                vista.rangoCinta = cinta.Rango;
                vista.significadoCinta = cinta.Significado;
                
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
