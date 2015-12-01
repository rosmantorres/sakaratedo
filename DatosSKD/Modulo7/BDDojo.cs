using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            BDUbicacion baseDeDatosUbicacion = new BDUbicacion();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Dojo dojo = new Dojo();

                elParametro = new Parametro(RecursosBDModulo7.AliasPersonaDojoId, SqlDbType.Int, idDojo.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultaDojoXId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    dojo.Id_dojo = int.Parse(row[RecursosBDModulo7.AliasDojoId].ToString());
                    dojo.Nombre_dojo = row[RecursosBDModulo7.AliasDojoNombre].ToString();
                    dojo.Telefono_dojo = int.Parse(row[RecursosBDModulo7.AliasDojoTelefono].ToString());
                    dojo.Email_dojo = row[RecursosBDModulo7.AliasDojoEmail].ToString();
                    dojo.Ubicacion = baseDeDatosUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasDojoUbicacion].ToString()));
                }

                return dojo;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }
        }
    }

}
