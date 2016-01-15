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
    public class ComandoConsultarListaMatriculasPagas : Comando<Tuple<List<Entidad>, List<Boolean>, List<float>>>
    {
        /// <summary>
        /// Implementación del metodo abstracto Ejecutar de la clase comando
        /// </summary>
        /// <returns>Retorta tupla con listas de evento, competencia y listas de sus fechas de inscripción</returns>
        public override Tuple<List<Entidad>, List<Boolean>, List<float>> Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoMatricula baseDeDatosMatricula = fabrica.ObtenerDaoMatriculaM7();        
            List<Entidad> matriculas = new List<Entidad>();
            Persona idPersona = (Persona)LaEntidad;
            Tuple<List<Entidad> ,List<Boolean>, List<float>> tupla;
            List<Boolean> listaEstado = new List<Boolean>();
            List<float> listaMonto = new List<float>();           
            try
            {
                if (idPersona.ID > 0)
                {
                    matriculas = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
                   
                    foreach (Matricula matricula in matriculas)
                    {
                        listaEstado.Add(baseDeDatosMatricula.EstadoMatricula(idPersona));
                    }

                    foreach (Matricula matricula in matriculas)
                    {
                        listaMonto.Add(baseDeDatosMatricula.MontoPagoMatricula(idPersona,matricula));
                    }
                

                    tupla = Tuple.Create(matriculas, listaEstado, listaMonto);
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
