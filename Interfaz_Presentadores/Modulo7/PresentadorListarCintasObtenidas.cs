using DominioSKD;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_Presentadores.Modulo7
{
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

        public void ConsultarCintasObtenidas()
        {
            FabricaComandos fabricaComandos = new FabricaComandos();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            try
            {
                Comando<Tuple<List<Entidad>, List<DateTime>>> comandoListaCintasObtenidas = fabricaComandos.ObtenerComandoConsultarListaCinta();
                Persona idPersona = new Persona();//cambiar por fabrica

                //idPersona.ID = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                idPersona.ID = 6; //falta modificar esto
                comandoListaCintasObtenidas.LaEntidad = idPersona;
                Tuple<List<Entidad>, List<DateTime>> tupla = comandoListaCintasObtenidas.Ejecutar();

                List<Entidad> listaCinta = tupla.Item1;
                List<DateTime> listaFecha = tupla.Item2;

                /*var numbersAndWords = listaCinta.Zip(listaFecha, (n, w) => new { cinta = n, fecha = w });

                foreach (var nw in numbersAndWords)
                {
                    Cinta cinta = (Cinta)nw.cinta;
                    DateTime fechaInscripcion = nw.fecha;
       
                    vista.laTabla += M7_RecursosPresentador.AbrirTR;
                    vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Color_nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                    vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Rango.ToString() + M7_RecursosPresentador.CerrarTD;
                    vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                    vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Clasificacion.ToString() + M7_RecursosPresentador.CerrarTD;
                    vista.laTabla += M7_RecursosPresentador.AbrirTD;
                    vista.laTabla += M7_RecursosPresentador.BotonInfoCintas + cinta.Id_cinta + M7_RecursosPresentador.BotonCerrar;
                    vista.laTabla += M7_RecursosPresentador.CerrarTD;
                    vista.laTabla += M7_RecursosPresentador.CerrarTR;
                }*/

                using (var e1 = listaCinta.GetEnumerator())
                using (var e2 = listaFecha.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        Cinta cinta = (Cinta)e1.Current;
                        DateTime fechaInscripcion = e2.Current;

                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Color_nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Rango.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + cinta.Clasificacion.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoCintas + cinta.Id_cinta + M7_RecursosPresentador.BotonCerrar;
                        vista.laTabla += M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.CerrarTR;

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
