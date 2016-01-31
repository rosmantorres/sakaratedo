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
using DominioSKD.Entidades.Modulo7;

namespace LogicaNegociosSKD.Comandos.Modulo7
{
    public class ComandoConsultarListaMatriculasPagas : Comando<Tuple<List<Entidad>, List<Boolean>, List<float>>>
    {
        /// <summary>
        /// Implementación del metodo abstracto Ejecutar de la clase comando
        /// </summary>
        /// <returns>Retorna tupla con listas de matricula,  sus listas de estados y montos pagos</returns>
        public override Tuple<List<Entidad>, List<Boolean>, List<float>> Ejecutar()
        {
            DaoMatricula baseDeDatosMatricula = FabricaDAOSqlServer.ObtenerDaoMatriculaM7();        
            List<Entidad> matriculas = new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)LaEntidad;
            Tuple<List<Entidad> ,List<Boolean>, List<float>> tupla;
            List<Boolean> listaEstado = new List<Boolean>();
            List<float> listaMonto = new List<float>();           
            try
            {
                if (idPersona.Id > 0)
                {
                    matriculas = baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
                   
                    foreach (MatriculaM7 matricula in matriculas)
                    {
                        listaEstado.Add(baseDeDatosMatricula.EstadoMatricula(idPersona));
                    }

                    foreach (MatriculaM7 matricula in matriculas)
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
                throw ex;
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKD ex)
            {
                throw ex;
            }
            return tupla;
        }
    }
}
