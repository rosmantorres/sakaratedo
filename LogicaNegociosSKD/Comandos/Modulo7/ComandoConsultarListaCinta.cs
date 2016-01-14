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
    public class ComandoConsultarListaCinta : Comando<Tuple<List<Entidad>, List<DateTime>>>
    {
        /// <summary>
        /// Implementación del metodo abstracto Ejecutar de la clase comando
        /// </summary>
        /// <returns>Retorta tupla con listas de cinta y lista de sus fechas de obtención</returns>
        public override Tuple<List<Entidad>, List<DateTime>> Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoCinta baseDeDatosCinta = fabrica.ObtenerDaoCintaM7();
            List<Entidad> cintas = new List<Entidad>();
            Persona idPersona = (Persona)LaEntidad;
            Tuple<List<Entidad>, List<DateTime>> tupla;
            List<DateTime> listaFechaCintas = new List<DateTime>();

            try
            {
                if (idPersona.ID > 0)
                {
                    cintas = baseDeDatosCinta.ListarCintasObtenidas(idPersona);

                    foreach (Cinta cinta in cintas)
                    {
                        listaFechaCintas.Add(baseDeDatosCinta.FechaCinta(idPersona, cinta));
                    }

                    tupla = Tuple.Create(cintas, listaFechaCintas);
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
