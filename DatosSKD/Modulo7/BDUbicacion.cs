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
    public class BDUbicacion
    {
        public Ubicacion DetallarUbicacion(int idUbicacion)
        {
             BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Ubicacion ubicacion = new Ubicacion();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdUbicacion, SqlDbType.Int, idUbicacion.ToString(),
                                            false);
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

                return ubicacion;

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
