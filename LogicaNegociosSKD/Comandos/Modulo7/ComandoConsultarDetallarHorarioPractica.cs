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
    /// Comando para detallar horario de practica
    /// </summary>
    public class ComandoConsultarDetallarHorarioPractica : Comando<Entidad>
    {
        /// <summary>
        /// Implementacion de método ejecutar para comando detallar horario practica
        /// </summary>
        /// <returns>Retorna entidad de evento</returns>
        public override Entidad Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoEvento baseDeDatosEvento = fabrica.ObtenerDaoEventoM7();
            EventoM7 idEvento = (EventoM7)LaEntidad;
            EventoM7 evento;
            try
            {
                if (idEvento.Id > 0)
                {
                    evento = (EventoM7)baseDeDatosEvento.ConsultarXId(idEvento);
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
            return evento;
        }
    }
}
