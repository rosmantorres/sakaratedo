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
    /// <summary>
    /// Comando para listar cintas de atleta
    /// </summary>
    public class ComandoConsultarListaCinta : Comando<Tuple<List<Entidad>, List<DateTime>>>
    {
        /// <summary>
        /// Implementacion de método ejecutar para comando listar cintas de atleta
        /// </summary>
        /// <returns>Retorna tupla con listas de cinta y lista de sus fechas de obtención</returns>
        public override Tuple<List<Entidad>, List<DateTime>> Ejecutar()
        {
            DaoCinta baseDeDatosCinta = FabricaDAOSqlServer.ObtenerDaoCintaM7();
            List<Entidad> cintas = new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)LaEntidad;
            Tuple<List<Entidad>, List<DateTime>> tupla;
            List<DateTime> listaFechaCintas = new List<DateTime>();

            try
            {
                if (idPersona.Id > 0)
                {
                    cintas = baseDeDatosCinta.ListarCintasObtenidas(idPersona);

                    foreach (CintaM7 cinta in cintas)
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
