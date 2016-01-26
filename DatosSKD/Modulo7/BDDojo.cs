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
    /// <summary>
    /// Clase que organiza la
    /// </summary>
    public class BDDojo
    {
        /// <summary>
        /// Detalle del dojo del atleta
        /// </summary>
        /// <param name="idDojo"></param>
        /// <returns></returns>
        public Dojo DetallarDojo(int idDojo)
        {

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
             
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            BDUbicacion baseDeDatosUbicacion = new BDUbicacion();
            Dojo dojo;

            try
            {
                
                if (idDojo.GetType() == Type.GetType("System.Int32") && idDojo > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    dojo = new Dojo();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdDojo, SqlDbType.Int, idDojo.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultaDojoXId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    dojo.Id_dojo = int.Parse(row[RecursosBDModulo7.AliasDojoId].ToString());
                    dojo.Nombre_dojo = row[RecursosBDModulo7.AliasDojoNombre].ToString();
                    dojo.Telefono_dojo = int.Parse(row[RecursosBDModulo7.AliasDojoTelefono].ToString());
                    dojo.Email_dojo = row[RecursosBDModulo7.AliasDojoEmail].ToString();
                    dojo.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasDojoUbicacion].ToString()));
                    dojo.Organizacion_dojo = int.Parse(row[RecursosBDModulo7.AliasDojoOrganizacionId].ToString());
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
            return dojo;
        }
       }
}