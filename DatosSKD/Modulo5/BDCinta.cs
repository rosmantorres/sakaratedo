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

namespace DatosSKD.Modulo5
{
    public class BDCinta
    {
        public static bool AgregarCinta(Cinta  laCinta)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDModulo5.ParamColorCinta, SqlDbType.VarChar, laCinta.Color_nombre, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamRangoCinta, SqlDbType.VarChar, laCinta.Rango, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamClasiCinta, SqlDbType.VarChar, laCinta.Clasificacion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamSignificadoCinta, SqlDbType.VarChar, laCinta.Significado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamOrdenCinta, SqlDbType.Int, laCinta.Orden.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo5.AgregarCinta
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }


            return true;
        }

        public static bool ModificarCinta(Cinta laCinta)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDModulo5.PararamIdCinta, SqlDbType.Int, laCinta.Id_cinta.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamColorCinta, SqlDbType.VarChar, laCinta.Color_nombre, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamRangoCinta, SqlDbType.VarChar, laCinta.Rango, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamClasiCinta, SqlDbType.VarChar, laCinta.Clasificacion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamSignificadoCinta, SqlDbType.VarChar, laCinta.Significado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamOrdenCinta, SqlDbType.Int, laCinta.Orden.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo5.ModificarCinta
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }


            return true;
        }

        public static bool EliminarCinta(int laCinta)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDModulo5.ParamEliminarCinta, SqlDbType.Int, laCinta.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo5.EliminarCinta
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }


            return true;
        }
        
        public static List<Cinta> ListarCintas()
        {

            BDConexion laConexion;
            List<Cinta> laListaCintas = new List<Cinta>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo5.ParamIdOrg, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Cinta laCinta = new Cinta();

                    laCinta.Id_cinta = int.Parse(row[RecursosBDModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosBDModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosBDModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosBDModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosBDModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosBDModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion.Nombre = row[RecursosBDModulo5.AliasNombreOrg].ToString();
                    laListaCintas.Add(laCinta);

                }

            }
            catch (SqlException ex)
            {
                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }


            return laListaCintas;
        }

        public static List<Cinta> ListarCintasXOrganizacion(int idOrganizacion)
        {

            BDConexion laConexion;
            List<Cinta> laListaCintas = new List<Cinta>();
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Organizacion laOrganizacion = new Organizacion();

                elParametro = new Parametro(RecursosBDModulo5.ParamIdOrg, SqlDbType.Int, idOrganizacion.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo5.ConsultarCintasXOrganizacionId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Cinta laCinta = new Cinta();

                    laCinta.Id_cinta = int.Parse(row[RecursosBDModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosBDModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosBDModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosBDModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosBDModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosBDModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion.Nombre = row[RecursosBDModulo5.AliasNombreOrg].ToString();
                    laListaCintas.Add(laCinta);

                }

            }
            catch (SqlException ex)
            {

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }

            return laListaCintas;
        }
        
        public static Cinta DetallarCinta(int idCinta)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Cinta laCinta = new Cinta();

                elParametro = new Parametro(RecursosBDModulo5.ParamIdCinta, SqlDbType.Int, idCinta.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo5.ConsultarCintasXId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    
                    laCinta.Id_cinta = int.Parse(row[RecursosBDModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosBDModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosBDModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosBDModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosBDModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosBDModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion.Nombre = row[RecursosBDModulo5.AliasNombreOrg].ToString();


                }
                return laCinta;



            }
            catch (SqlException ex)
            {

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (Exception e)
            {
                throw e;
            }


        }

    }
}
