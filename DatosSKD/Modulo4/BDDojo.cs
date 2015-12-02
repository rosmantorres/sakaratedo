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

namespace DatosSKD.Modulo4
{
    public class BDDojo
    {
        
        public static List<Dojo> ListarDojos()
        {
            BDConexion laConexion;
            List<Dojo> laListaDeDojos = new List<Dojo>();
            List<Parametro> parametros;

              try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo4.ConsultarDojos, parametros);
                foreach (DataRow row in dt.Rows)
                {

                    Dojo elDojo = new Dojo();

                    elDojo.Id_dojo= int.Parse(row[RecursosBDModulo4.AliasIdDojo].ToString());
                    elDojo.Rif_dojo = row[RecursosBDModulo4.AliasRifDojo].ToString();
                    elDojo.Nombre_dojo = row[RecursosBDModulo4.AliasNombreDojo].ToString();
                    elDojo.Telefono_dojo = int.Parse(row[RecursosBDModulo4.AliasTelefonoDojo].ToString());
                    elDojo.Email_dojo = row[RecursosBDModulo4.AliasEmailDojo].ToString();
                    elDojo.Logo_dojo = row[RecursosBDModulo4.AliasLogoDojo].ToString();
                    elDojo.Status_dojo = row[RecursosBDModulo4.AliasStatusDojo].ToString();
                    elDojo.OrgNombre_dojo = row[RecursosBDModulo4.AliasNombreOrganizacion].ToString();
                    elDojo.Registro_dojo = DateTime.Parse(row[RecursosBDModulo4.AliasFechaDojo].ToString());
                    elDojo.Organizacion_dojo = int.Parse(row[RecursosBDModulo4.AliasIdOrganizacion].ToString());
                    elDojo.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo4.AliasIdUbicacion].ToString()),
                                                            row[RecursosBDModulo4.AliasNombreCiudad].ToString(),
                                                            row[RecursosBDModulo4.AliasNombreEstado].ToString());

                    laListaDeDojos.Add(elDojo);

                }

            }
              catch (SqlException ex)
              {
                  throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                      RecursoGeneralBD.Mensaje, ex);
              }
              catch (FormatException ex)
              {
                  throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                       RecursosBDModulo4.Mensaje_Error_Formato, ex);
              }
              catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
              {
                  throw ex;
              }
              catch (Exception ex)
              {
                  throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
              }

              return laListaDeDojos;
        }

        public static Dojo DetallarDojo(int idDojo)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Dojo elDojo = new Dojo();
            elDojo.Id_dojo = idDojo;
           
            try
            {
                
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();


                    elParametro = new Parametro(RecursosBDModulo4.ParamIdDojo, SqlDbType.Int, idDojo.ToString(),
                                                false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDModulo4.ConsultarDojoXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {


                        elDojo.Id_dojo = int.Parse(row[RecursosBDModulo4.AliasIdDojo].ToString());
                        elDojo.Rif_dojo = row[RecursosBDModulo4.AliasRifDojo].ToString();
                        elDojo.Nombre_dojo = row[RecursosBDModulo4.AliasNombreDojo].ToString();
                        elDojo.Telefono_dojo = int.Parse(row[RecursosBDModulo4.AliasTelefonoDojo].ToString());
                        elDojo.Email_dojo = row[RecursosBDModulo4.AliasEmailDojo].ToString();
                        elDojo.Logo_dojo = row[RecursosBDModulo4.AliasLogoDojo].ToString();
                        elDojo.Status_dojo = row[RecursosBDModulo4.AliasStatusDojo].ToString();
                        elDojo.Estilo_dojo = row[RecursosBDModulo4.AliasEstiloDojo].ToString();
                        elDojo.Registro_dojo = DateTime.Parse(row[RecursosBDModulo4.AliasFechaDojo].ToString());
                        elDojo.Organizacion_dojo = int.Parse(row[RecursosBDModulo4.AliasIdOrganizacion].ToString());
                        elDojo.OrgNombre_dojo = row[RecursosBDModulo4.AliasNombreOrganizacion].ToString();
                        elDojo.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo4.AliasIdUbicacion].ToString()),
                                                                row[RecursosBDModulo4.AliasNombreCiudad].ToString(),
                                                                row[RecursosBDModulo4.AliasNombreEstado].ToString());
                        //elDojo.Matricula_dojo = (BuscarMatriculaVigente(elDojo));

                    }
                    return elDojo;
              
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                     RecursosBDModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


        }

        

        public static void eliminarDojo(int idDojo)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {

                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                elParametro = new Parametro(RecursosBDModulo4.ParamIdDojo, SqlDbType.Int, idDojo.ToString(),
                                               false);
                parametros.Add(elParametro);

                laConexion.EjecutarStoredProcedure(RecursosBDModulo4.EliminarDojo, parametros);


            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                     RecursosBDModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
        }


        private static bool BuscarRifDojo(Dojo elDojo)
        {
            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosBDModulo4.ParamRifDojo, SqlDbType.VarChar, elDojo.Rif_dojo.ToString(),
                                               false);
                parametros.Add(elParametro);
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo4.BuscarRifDojo, parametros);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        if (String.Equals(elDojo.Rif_dojo, row[RecursosBDModulo4.ParametroRifDojo].ToString()))
                        {
                            retorno = true;
                            break;
                        }
                        else retorno = false;
                    }
                }
                else return false;
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                     RecursosBDModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }


            return retorno;

        }


        public static bool AgregarDojo(Dojo elDojo, Historial_Matricula elHistorial, Ubicacion laUbicacion)
        {


            try
            {
                if (!BuscarRifDojo(elDojo))
                { 
                    bool status;
                    if (elDojo.Status_dojo.Equals("true"))
                        status = true;
                    else
                        status= false;
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosBDModulo4.ParametroRifDojo, SqlDbType.VarChar, elDojo.Rif_dojo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroNombreDojo, SqlDbType.VarChar, elDojo.Nombre_dojo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroTelefonoDojo, SqlDbType.Int,
                       elDojo.Telefono_dojo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroEmailDojo, SqlDbType.VarChar,
                        elDojo.Email_dojo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroLogoDojo, SqlDbType.VarChar,
                        elDojo.Logo_dojo, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroFechaRegistro, SqlDbType.DateTime,
                      elDojo.Registro_dojo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroStatusDojo, SqlDbType.Bit,
                        status.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroNombreEstado, SqlDbType.VarChar,
                        laUbicacion.Estado, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroNombreCiudad, SqlDbType.VarChar,
                        laUbicacion.Ciudad, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroLatitud, SqlDbType.VarChar,
                        laUbicacion.Latitud, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroLongitud, SqlDbType.VarChar,
                        laUbicacion.Longitud, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroDireccion, SqlDbType.VarChar,
                        laUbicacion.Direccion, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroModalidad, SqlDbType.VarChar,
                        elHistorial.Modalidad_historial_matricula, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosBDModulo4.ParametroMontoMatricula, SqlDbType.Float,
                        elHistorial.Monto_historial_matricula.ToString(), false);
                    parametros.Add(elParametro);


                    BDConexion laConexion = new BDConexion();
                    laConexion.EjecutarStoredProcedure(RecursosBDModulo4.AgregarDojo, parametros);


                }

                else

                    throw new ExcepcionesSKD.Modulo4.DojoExistenteException(RecursosBDModulo4.Codigo_Dojo_Existente,
                                RecursosBDModulo4.Mensaje_Dojo_Existente, new Exception());

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosBDModulo4.Codigo_Error_Formato,
                     RecursosBDModulo4.Mensaje_Error_Formato, ex);
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
