﻿using DominioSKD;
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
    /// Presentador para listar eventos asistidos
    /// </summary>
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

        /// <summary>
        /// Método para consultar los eventos asistidos del atleta
        /// </summary>
        public void ConsultarEventosAsistidos(Entidad idPersona)
        {
            try
            {
                Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>>> comandoListaEventosAsistidos = 
                    FabricaComandos.ObtenerComandoConsultarListaEventosAsistidos();

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
                        EventoM7 evento = (EventoM7)e1.Current;
                        DateTime fechaInscripcion = e2.Current;

                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.TipoEvento.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Ubicacion.Estado.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoAsistenciaAEventos + evento.Id + M7_RecursosPresentador.BotonCerrar;
                        vista.laTabla += M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.CerrarTR;
                    }
                }

                using (var e1 = listaCompetencia.GetEnumerator())
                using (var e2 = listaFechaCompetencia.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        CompetenciaM7 competencia = (CompetenciaM7)e1.Current;
                        DateTime fechaInscripcion = e2.Current;

                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.TipoCompetencia.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.Ubicacion.Estado.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoAsistenciaACompetencias + competencia.Id + M7_RecursosPresentador.BotonCerrar;
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
