using DominioSKD;
using DominioSKD.Entidades.Modulo6;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
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
using DominioSKD.Entidades.Modulo7;
namespace Interfaz_Presentadores.Modulo7
{
    /// <summary>
    /// Presentador para detallar matricula
    /// </summary>
    public class PresentadorDetallarMatricula
    {
        private FabricaComandos fabricaComandos;
        private IContratoDetallarMatricula vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarMatricula(IContratoDetallarMatricula laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Método para cargar los datos de la matricula
        /// </summary>
        /// <param name="idCinta">id de la matricula</param>
        public void CargarDatos(Entidad idMatricula, Entidad idPersona)
        {           
            try
            {
               fabricaComandos = new FabricaComandos();
                ComandoConsultarDetallarMatricula comandoDetallarMatricula =(ComandoConsultarDetallarMatricula)fabricaComandos.ObtenerComandoConsultarDetallarMatricula();
                comandoDetallarMatricula.LaEntidad = idMatricula;
                comandoDetallarMatricula.IdPersona = (PersonaM7)idPersona;
                MatriculaM7 matricula = (MatriculaM7)comandoDetallarMatricula.Ejecutar();
                String estadoFinal;
                vista.identificadorMatricula = matricula.Identificador;

                if (matricula.Status.Equals(true))
                {
                    vista.estadoMatricula = M7_RecursosPresentador.AliasMatriculaActiva;
                }
                else
                {
                    vista.estadoMatricula = M7_RecursosPresentador.AliasMatriculaInactiva;
                }

                /*if (matricula.Status.Equals(true))

                {
                    estadoFinal = "Activa";
                }
                else
                {
                    estadoFinal = "No Activa";
                }*/
                
                vista.fechaCreacionMatricula = matricula.FechaCreacion.ToString("MM/dd/yyyy");
                vista.fechaPagoMatricula = matricula.UltimaFechaPago.ToString("MM/dd/yyyy");
                estadoFinal = matricula.Status.ToString();

             
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
