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
        public static List<RestriccionCinta> ConsultarRestriccionCintaTodas()
        {
            
            BDConexion laConexion;
            List<RestriccionCinta> ListaRestriccionCinta = new List<RestriccionCinta>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursoBDRestriccionCinta.ConsultarRestriccionesCinta, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    RestriccionCinta laRestriccion = new RestriccionCinta();

                    laRestriccion.IdRestriccionCinta = int.Parse(row[RecursoBDRestriccionCinta.AliasIdRestriccionCinta].ToString());
                    laRestriccion.Descripcion = row[RecursoBDRestriccionCinta.AliasDescripcionRestCinta].ToString();
                    laRestriccion.PuntosMinimos = int.Parse(row[RecursoBDRestriccionCinta.AliasPuntosMinCintas].ToString());
                    laRestriccion.TiempoDocente = int.Parse(row[RecursoBDRestriccionCinta.AliasTiempoDocente].ToString());

                    ListaRestriccionCinta.Add(laRestriccion);

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

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursoBDRestriccionCinta.Codigo_Error_Formato,
                      RecursoBDRestriccionCinta.Mensaje_Error_Formato, ex);
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

            
            return ListaRestriccionCinta;

        }

        public static bool AgregarRestriccionCinta(RestriccionCinta laRestriccion, int NuevaCinta)
        {

            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursoBDRestriccionCinta.ParamDescripcionRestricionCinta, SqlDbType.VarChar,
                    laRestriccion.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursoBDRestriccionCinta.ParamCintaNueva, SqlDbType.Int,
                        NuevaCinta.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursoBDRestriccionCinta.ParamTiempoMinimo, SqlDbType.Int,
                        laRestriccion.TiempoMinimo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursoBDRestriccionCinta.ParamPuntosMinimos, SqlDbType.Int,
                        laRestriccion.PuntosMinimos.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursoBDRestriccionCinta.ParamHorasDocentes, SqlDbType.Int,
                        laRestriccion.TiempoDocente.ToString(), false);
                parametros.Add(elParametro);


                BDConexion laConexion = new BDConexion();
                laConexion.EjecutarStoredProcedure(RecursoBDRestriccionCinta.AgregarRestriccionCinta, parametros);
            }

            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
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

            return true;
        }

        public static bool ModificarRestriccionCinta(RestriccionCinta laRestriccion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursoBDRestriccionCinta.ParamDescripcionRestricionCinta, SqlDbType.VarChar,
                    laRestriccion.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursoBDRestriccionCinta.ParamIdRestriccion, SqlDbType.Int,
                        laRestriccion.IdRestriccionCinta.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursoBDRestriccionCinta.ParamTiempoMinimo, SqlDbType.Int,
                        laRestriccion.TiempoMinimo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursoBDRestriccionCinta.ParamPuntosMinimos, SqlDbType.Int,
                        laRestriccion.PuntosMinimos.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursoBDRestriccionCinta.ParamHorasDocentes, SqlDbType.Int,
                        laRestriccion.TiempoDocente.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursoBDRestriccionCinta.ModificarRestriccionCinta, parametros);

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

                Parametro elParametro = new Parametro(RecursoBDRestriccionCinta.ParamIdRestriccion, SqlDbType.Int,
                        laRestriccion.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursoBDRestriccionCinta.EliminarRestriccionCinta, parametros);

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

                Parametro elParametro = new Parametro(RecursoBDRestriccionCinta.ParamCinta, SqlDbType.Int,
                        laCinta.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursoBDRestriccionCinta.ConsultarRestriccionCinta, parametros);

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