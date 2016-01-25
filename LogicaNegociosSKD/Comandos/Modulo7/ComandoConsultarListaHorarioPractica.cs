using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo7;
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
    /// Comando para detallar el horario de practica del atleta
    /// </summary>
    public class ComandoConsultarListaHorarioPractica : Comando<Tuple<List<Entidad>>>
    {
        /// <summary>
        /// Implementacion de método ejecutar para comando listar horario de practica del atleta
        /// </summary>
        /// <returns>Retorta tupla con listas del evento horario de clase</returns>
        public override Tuple<List<Entidad>> Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoEvento baseDeDatosEvento = fabrica.ObtenerDaoEventoM7();
            List<Entidad> eventos = new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)LaEntidad;
            Tuple<List<Entidad>> tupla;
            try
            {
                if (idPersona.Id > 0)
                {
                    eventos = baseDeDatosEvento.ListarHorarioPractica(idPersona);
                     tupla = Tuple.Create(eventos);
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
