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
            Organizacion laOrganizacion = new Organizacion(laCinta.Organizacion.Id_organizacion, laCinta.Organizacion.Nombre);

            try
            {
                if (BuscarIDOrganizacion(laOrganizacion)) 
                {
                  if (!BuscarNombreCinta(laCinta)) {
                      if (!BuscarOrdenCinta(laCinta)) { 
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
                elParametro = new Parametro(RecursosBDModulo5.ParamIdOrgCinta, SqlDbType.Int, laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo5.AgregarCinta
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

                    }
                    else
                    {
                        throw new ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException(RecursosBDModulo5.Codigo_Orden_Cinta_Repetida,
                                RecursosBDModulo5.Mensaje_Orden_Cinta_Repetida, new Exception());
                    }
                  }
                  else
                  {
                      throw new ExcepcionesSKD.Modulo5.CintaRepetidaException(RecursosBDModulo5.Codigo_Cinta_Repetida,
                              RecursosBDModulo5.Mensaje_Cinta_Repetida, new Exception());
                  }
            }// Fin if    
            else
            {
                 throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosBDModulo5.Codigo_Organizacion_Inexistente,
                                RecursosBDModulo5.Mensaje_Organizacion_Inexistente, new Exception());
            }
            } // Fin Try
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                 throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosBDModulo5.Codigo_Error_Formato,
                     RecursosBDModulo5.Mensaje_Error_Formato, ex);
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

        public static bool ModificarCinta(Cinta laCinta)
        {
            Organizacion laOrganizacion = new Organizacion(laCinta.Organizacion.Id_organizacion, laCinta.Organizacion.Nombre);

            try
            {
              if (BuscarIDOrganizacion(laOrganizacion))
               {  
                   if (!BuscarNombreCinta(laCinta)) {
                     if (!BuscarOrdenCinta(laCinta)) { 
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
                elParametro = new Parametro(RecursosBDModulo5.ParamIdOrgCinta, SqlDbType.Int, laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo5.ModificarCinta
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

                    }
                     else
                     {
                         throw new ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException(RecursosBDModulo5.Codigo_Orden_Cinta_Repetida,
                                 RecursosBDModulo5.Mensaje_Orden_Cinta_Repetida, new Exception());
                     }
                   }
                   else
                   {
                       throw new ExcepcionesSKD.Modulo5.CintaRepetidaException(RecursosBDModulo5.Codigo_Cinta_Repetida,
                               RecursosBDModulo5.Mensaje_Cinta_Repetida, new Exception());
                   }
             } // Fin if
             else
                {
                    throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosBDModulo5.Codigo_Organizacion_Inexistente,
                                   RecursosBDModulo5.Mensaje_Organizacion_Inexistente, new Exception());
                }
            } // Fin Try
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosBDModulo5.Codigo_Error_Formato,
                    RecursosBDModulo5.Mensaje_Error_Formato, ex);
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
                               RecursosBDModulo5.ConsultarTodasLasCintas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Cinta laCinta = new Cinta();

                    laCinta.Id_cinta = int.Parse(row[RecursosBDModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosBDModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosBDModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosBDModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosBDModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosBDModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo5.AliasIdOrganizacion].ToString())
                                                                        , row[RecursosBDModulo5.AliasNombreOrg].ToString());
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

                elParametro = new Parametro(RecursosBDModulo5.ParamIdOrg, SqlDbType.Int, idOrganizacion.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo5.ConsultarTodasLasCintas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Cinta laCinta = new Cinta();

                    laCinta.Id_cinta = int.Parse(row[RecursosBDModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosBDModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosBDModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosBDModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosBDModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosBDModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo5.AliasIdOrganizacion].ToString())
                                                                         , row[RecursosBDModulo5.AliasNombreOrg].ToString());
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
                    laCinta.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo5.AliasIdOrganizacion].ToString())
                                                                         , row[RecursosBDModulo5.AliasNombreOrg].ToString());


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

        public static bool BuscarIDOrganizacion(Organizacion laOrganizacion)
        {
            
            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laOrganizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo5.ParamSalidaNumOrganizacion, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDModulo5.BuscarIDOrganiacion
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDModulo5.ParamSalidaNumOrganizacion)
                        if (int.Parse(elResultado.valor) == 1)
                            retorno = true;
                        else
                        {
                            Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo5.Mensaje_Organizacion_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                            throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosBDModulo5.Codigo_Organizacion_Inexistente,
                                RecursosBDModulo5.Mensaje_Organizacion_Inexistente, new Exception());
                        }
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo5.Codigo_Error_Formato,
                     RecursosBDModulo5.Mensaje_Error_Formato, ex);
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

            return retorno;


        }

        public static bool BuscarOrdenCinta(Cinta laCinta)
        {

            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo5.ParamOrdenCinta, SqlDbType.Int
                                                      , laCinta.Orden.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo5.ParamSalidaNumCinta, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDModulo5.BuscarOrdenCinta
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDModulo5.ParamSalidaNumCinta)
                        if (int.Parse(elResultado.valor) == 1) // Significa q el orden si esta repetido
                            retorno = true;
                        else
                        {
                            retorno = false;
                        }
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo5.Codigo_Error_Formato,
                     RecursosBDModulo5.Mensaje_Error_Formato, ex);
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

            return retorno;


        }

        public static bool BuscarNombreCinta(Cinta laCinta)
        {

            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo5.ParamColorCinta, SqlDbType.VarChar
                                                      , laCinta.Color_nombre, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo5.ParamSalidaNumCinta, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDModulo5.BuscarNombreCinta
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDModulo5.ParamSalidaNumCinta)
                        if (int.Parse(elResultado.valor) == 1) // Significa q el nombre en esa organizacion esta repetido si esta repetido
                            retorno = true;
                        else
                        {
                            retorno = false;
                        }
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo5.Codigo_Error_Formato,
                     RecursosBDModulo5.Mensaje_Error_Formato, ex);
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

            return retorno;


        }

    }
}
