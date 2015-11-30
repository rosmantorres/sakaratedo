using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;
using ExcepcionesSKD;
using System.Globalization;

namespace DatosSKD.Modulo8
{
    public class BDRestriccionCinta
    {
        public static bool AgregarRestriccionCinta(RestriccionCinta laRestriccion, int NuevaCinta)
        {
            
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDModulo8.ParamDescripcionRestricionCinta, SqlDbType.VarChar,
                    laRestriccion.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo8.ParamCintaNueva, SqlDbType.Int,
                        NuevaCinta.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo8.ParamTiempoMinimo, SqlDbType.Int,
                        laRestriccion.TiempoMinimo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo8.ParamPuntosMinimos, SqlDbType.Int,
                        laRestriccion.PuntosMinimos.ToString(),false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo8.ParamHorasDocentes, SqlDbType.Int,
                        laRestriccion.TiempoDocente.ToString(), false);
                parametros.Add(elParametro);

                
                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo8.AgregarRestriccionCinta, parametros);
            }

            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }    

            return true;
        }

        public static bool ModificarRestriccionCinta(RestriccionCinta laRestriccion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo8.ParamDescripcionRestricionCinta, SqlDbType.VarChar,
                    laRestriccion.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo8.ParamIdRestriccion, SqlDbType.Int,
                        laRestriccion.IdRestriccionCinta.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo8.ParamTiempoMinimo, SqlDbType.Int,
                        laRestriccion.TiempoMinimo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo8.ParamPuntosMinimos, SqlDbType.Int,
                        laRestriccion.PuntosMinimos.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo8.ParamHorasDocentes, SqlDbType.Int,
                        laRestriccion.TiempoDocente.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo8.ModificarRestriccionCinta, parametros);

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }   

            return true;
        }

        public static bool EliminarRestriccionCinta(int laRestriccion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo8.ParamIdRestriccion, SqlDbType.Int,
                        laRestriccion.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo8.EliminarRestriccionCinta, parametros);

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        public static bool ConsultarRestriccionCinta(int laCinta)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo8.ParamCinta, SqlDbType.Int,
                        laCinta.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo8.ConsultarRestriccionCinta, parametros);

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }
    }

}