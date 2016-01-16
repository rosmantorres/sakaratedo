﻿using DatosSKD.DAO.Modulo7;
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
    public class ComandoConsultarListaEventosPagos : Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>>>
    {
        /// <summary>
        /// Implementación del metodo abstracto Ejecutar de la clase comando
        /// </summary>
        /// <returns>Retorta tupla con listas de evento, competencia y listas de sus fechas de inscripción</returns>
        public override Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoEvento baseDeDatosEvento = fabrica.ObtenerDaoEventoM7();          
            List<Entidad> eventos = new List<Entidad>();
            List<Entidad> competencias = new List<Entidad>();
            Persona idPersona = (Persona)LaEntidad;
            Tuple<List<Entidad> ,List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla;
            List<DateTime> listaFechaPagoEventos = new List<DateTime>();
            List<DateTime> listaFechaPagoCompetencias = new List<DateTime>();
            List<float> listaMontoPagoEvento = new List<float>();   
            try
            {
                if (idPersona.ID > 0)
                {              
                    eventos = baseDeDatosEvento.ListarEventosPagos(idPersona);
                    competencias= baseDeDatosEvento.ListarCompetenciasPaga(idPersona);

                    foreach (Evento evento in eventos)
                    {                       
                        listaFechaPagoEventos.Add(baseDeDatosEvento.FechaPagoEvento(idPersona, evento));
                        listaMontoPagoEvento.Add(baseDeDatosEvento.MontoPagoEvento(idPersona, evento));
                    }
                    foreach (Competencia competencia in competencias)
                    {
                        listaFechaPagoCompetencias.Add(baseDeDatosEvento.FechaInscripcionCompetencia(idPersona, competencia));
                    }

                    tupla = Tuple.Create(eventos, competencias, listaFechaPagoEventos, listaMontoPagoEvento, listaFechaPagoCompetencias);
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