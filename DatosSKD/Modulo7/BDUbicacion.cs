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
    public class BDUbicacion
    {
        public Ubicacion DetallarUbicacion(int idUbicacion)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Ubicacion ubicacion;

            try
            {
                if (idUbicacion.GetType() == Type.GetType("System.Int32") && idUbicacion > 0)
                {
                     laConexion = new BDConexion();
                     parametros = new List<Parametro>();
                     ubicacion = new Ubicacion();

                     elParametro = new Parametro(RecursosBDModulo7.ParamIdUbicacion, SqlDbType.Int, idUbicacion.ToString(), false);
                    parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultaUbicacionXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    ubicacion.Id_ubicacion = int.Parse(row[RecursosBDModulo7.AliasIdUbicacion].ToString());
                    ubicacion.Ciudad = row[RecursosBDModulo7.AliasCiudad].ToString();
                    ubicacion.Estado = row[RecursosBDModulo7.AliasEstado].ToString();
                    ubicacion.Direccion = row[RecursosBDModulo7.AliasDireccion].ToString();
                    
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
            return ubicacion;
        }
    }
}
