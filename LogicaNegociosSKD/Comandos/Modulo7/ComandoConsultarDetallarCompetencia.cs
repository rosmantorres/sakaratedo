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
    /// Comando para detallar competencia de atleta
    /// </summary>
    public class ComandoConsultarDetallarCompetencia : Comando<Entidad>
    {
        /// <summary>
        /// Implementacion de método ejecutar para comando detallar competencia de atleta
        /// </summary>
        /// <returns>Retorna entidad de competencia</returns>
        public override Entidad Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoCompetencia baseDeDatosCompetencia= fabrica.ObtenerDaoCompetenciaM7();
            CompetenciaM7 idCompetencia = (CompetenciaM7)LaEntidad;
            CompetenciaM7 competencia;
            try
            {
                if (idCompetencia.Id > 0)
                {
                    competencia = (CompetenciaM7)baseDeDatosCompetencia.ConsultarXId(idCompetencia);
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
            return competencia;
        }
    }
}
