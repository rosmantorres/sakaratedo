using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;

namespace DatosSKD.Modulo7
{
        public class BDOrganizacion
    {
            /// <summary>
            /// Detalle de la organizacion a la cual pertenece un dojo
            /// </summary>
            /// <param name="idOrg"></param>
            /// <returns></returns>
            public Organizacion DetallarOrganizacion(int idOrg)
            {

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                BDConexion laConexion;
                List<Parametro> parametros;
                Parametro elParametro = new Parametro();
                Organizacion org;
               
                try
                {
                    if (idOrg.GetType() == Type.GetType("System.Int32") && idOrg > 0)
                {
                        laConexion = new BDConexion();
                        parametros = new List<Parametro>();
                        org = new Organizacion();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdOrganizacion, SqlDbType.Int, idOrg.ToString(), false);
                    parametros.Add(elParametro);           

                        DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDModulo7.ConsultaOrganizacionXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                         org.Id = int.Parse(row[RecursosBDModulo7.AliasOrganizacionId].ToString());
                         org.Nombre = row[RecursosBDModulo7.AliasOrganizacionNombre].ToString();
                         org.Direccion = row[RecursosBDModulo7.AliasOrganizacionDireccion].ToString();
                         org.Telefono = int.Parse(row[RecursosBDModulo7.AliasOrganizacionTelefono].ToString());
                         org.Email = row[RecursosBDModulo7.AliasOrganizacionEmail].ToString();
                    }

                  }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }
                
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionSKD("No se pudo completar la operacion", ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return org;
        }
   }
}
