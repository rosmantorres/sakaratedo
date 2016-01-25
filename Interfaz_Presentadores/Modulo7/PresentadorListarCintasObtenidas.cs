using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD;
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
    /// Presentador para listar cintas obtenidas
    /// </summary>
    public class PresentadorListarCintasObtenidas
    {
        private IContratoListarCintasObtenidas vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarCintasObtenidas(IContratoListarCintasObtenidas laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Método para consultar las cintas obtenidas
        /// </summary>
        public void ConsultarCintasObtenidas(Entidad idPersona)
        {
            FabricaComandos fabricaComandos = new FabricaComandos();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            try
            {
                Comando<Tuple<List<Entidad>, List<DateTime>>> comandoListaCintasObtenidas = fabricaComandos.ObtenerComandoConsultarListaCinta();
                comandoListaCintasObtenidas.LaEntidad = idPersona;
                Tuple<List<Entidad>, List<DateTime>> tupla = comandoListaCintasObtenidas.Ejecutar();

                List<Entidad> listaCinta = tupla.Item1;
                List<DateTime> listaFecha = tupla.Item2;

                using (var e1 = listaCinta.GetEnumerator())
                using (var e2 = listaFecha.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        CintaM7 cinta = (CintaM7)e1.Current;
                        DateTime fechaInscripcion = e2.Current;

                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Color_nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Rango.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Clasificacion.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoCintas + cinta.Id + M7_RecursosPresentador.BotonCerrar;
                        vista.laTabla += M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.CerrarTR;
                    }
                }
            }
            catch (NumeroEnteroInvalidoException)
            {
            }
            catch (FormatException)
            {
            }
            catch (Exception)
            {

            }
        }
    }
}
