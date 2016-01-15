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
    public class PresentadorListarEventosAsistidos
    {
        private IContratoListarEventosAsistidos vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarEventosAsistidos(IContratoListarEventosAsistidos laVista)
        {
            vista = laVista;
        }

        public void ConsultarCintasObtenidas()
        {
            FabricaComandos fabricaComandos = new FabricaComandos();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            try
            {
                Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>>> comandoListaEventosAsistidos = 
                    fabricaComandos.ObtenerComandoConsultarListaEventosAsistidos();

                Persona idPersona = new Persona();//cambiar por fabrica
                //idPersona.ID = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                idPersona.ID = 6; //falta modificar esto
                comandoListaEventosAsistidos.LaEntidad = idPersona;
                Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla = comandoListaEventosAsistidos.Ejecutar();

                List<Entidad> listaEvento = tupla.Item1;
                List<Entidad> listaCompetencia = tupla.Item2;
                List<DateTime> listaFechaEvento = tupla.Item3;
                List<DateTime> listaFechaCompetencia = tupla.Item4;

                using (var e1 = listaEvento.GetEnumerator())
                using (var e2 = listaFechaEvento.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        Evento evento = (Evento)e1.Current;
                        DateTime fechaInscripcion = e2.Current;

                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.TipoEvento.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Ubicacion.Estado.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoAsistenciaAEventos + evento.Id_evento + M7_RecursosPresentador.BotonCerrar;
                        vista.laTabla += M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.CerrarTR;
                    }
                }

                using (var e1 = listaCompetencia.GetEnumerator())
                using (var e2 = listaFechaCompetencia.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        Competencia competencia = (Competencia)e1.Current;
                        DateTime fechaInscripcion = e2.Current;

                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.TipoCompetencia.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.Ubicacion.Estado.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoAsistenciaACompetencias + competencia.Id_competencia + M7_RecursosPresentador.BotonCerrar;
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
