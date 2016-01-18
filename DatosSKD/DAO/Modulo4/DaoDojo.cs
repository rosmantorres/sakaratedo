using DatosSKD.DAO;
using DatosSKD.InterfazDAO;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo4
{
    class DaoDojo : DAOGeneral
    {
        #region IDAO
        public bool Agregar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo4 = (DominioSKD.Entidades.Modulo4.Dojo)parametro;

                if (!BuscarNombreCompetenciaAgregar(laCompetencia))
                {
                }
                else
                {
                    Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.Mensaje_Dojo_Existente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo4.DojoInexistenteException(RecursosDAOModulo4.Codigo_Dojo_Existente,
                                RecursosDAOModulo4.Mensaje_Dojo_Existente, new Exception());
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.DojoInexistenteException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }
        #endregion
    }
}
