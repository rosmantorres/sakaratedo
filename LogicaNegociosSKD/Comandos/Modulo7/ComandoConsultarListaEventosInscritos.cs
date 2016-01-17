using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo7
{
    /// <summary>
    /// Comando para consultar los eventos y competencias inscritos del atleta
    /// </summary>
    public class ComandoConsultarListaEventosInscritos : Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>>>
    {
             /// <summary>
            /// Implementacion de método ejecutar para comando listar eventos y competencias inscritos de atleta
            /// </summary>
            /// <returns>Retorta tupla con listas de evento, competencia y listas de las fechas de dichos eventos</returns>
            public override Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> Ejecutar()
            {
                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                DaoEvento baseDeDatosEvento = fabrica.ObtenerDaoEventoM7();
                List<Entidad> eventos = new List<Entidad>();
                List<Entidad> competencias = new List<Entidad>();
                Persona idPersona = (Persona)LaEntidad;
                Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>> tupla;
                List<DateTime> listaFechaEventos = new List<DateTime>();
                List<DateTime> listaFechaCompetencias = new List<DateTime>();
                try
                {
                    if (idPersona.Id > 0)
                    {
                        eventos = baseDeDatosEvento.ListarEventosInscritos(idPersona);
                        competencias = baseDeDatosEvento.ListarCompetenciasInscritas(idPersona);

                        foreach (Evento evento in eventos)
                        {
                            listaFechaEventos.Add(baseDeDatosEvento.FechaInscripcionEvento(idPersona, evento));
                        }
                        foreach (Competencia competencia in competencias)
                        {
                            listaFechaCompetencias.Add(baseDeDatosEvento.FechaInscripcionCompetencia(idPersona, competencia));
                        }

                        tupla = Tuple.Create(eventos, competencias, listaFechaEventos, listaFechaCompetencias);
                    }
                    else
                    {
                        throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                    RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                    }
                }
                catch (ExceptionSKDConexionBD ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw ex;
                }
                catch (NumeroEnteroInvalidoException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                    RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }
                catch (FormatException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                    RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }
                catch (ExceptionSKD ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw ex;
                }
                return tupla;
            }
    }
}
