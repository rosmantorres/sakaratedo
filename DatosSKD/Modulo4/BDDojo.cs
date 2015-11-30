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

                    elDojo.Dojo_Id= int.Parse(row[RecursosBDModulo4.AliasIdDojo].ToString());
                    elDojo.Rif_dojo = row[RecursosBDModulo4.AliasRifDojo].ToString();
                    elDojo.Nombre_dojo = row[RecursosBDModulo4.AliasNombreDojo].ToString();
                    elDojo.Telefono_dojo = int.Parse(row[RecursosBDModulo4.AliasTelefonoDojo].ToString());
                    elDojo.Email_dojo = row[RecursosBDModulo4.AliasEmailDojo].ToString();
                    elDojo.Logo_dojo = row[RecursosBDModulo4.AliasLogoDojo].ToString();
                    elDojo.Estilo_dojo = row[RecursosBDModulo4.AliasEstiloDojo].ToString();
                    elDojo.Status_dojo = row[RecursosBDModulo4.AliasStatusDojo].ToString();
                    elDojo.Registro_dojo = DateTime.Parse(row[RecursosBDModulo4.AliasFechaDojo].ToString());
                    elDojo.Organizacion_dojo = row[RecursosBDModulo4.AliasNombreOrganizacion].ToString();
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
            elDojo.Dojo_Id = idDojo;
           
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


                        elDojo.Dojo_Id = int.Parse(row[RecursosBDModulo4.AliasIdDojo].ToString());
                        elDojo.Rif_dojo = row[RecursosBDModulo4.AliasRifDojo].ToString();
                        elDojo.Nombre_dojo = row[RecursosBDModulo4.AliasNombreDojo].ToString();
                        elDojo.Telefono_dojo = int.Parse(row[RecursosBDModulo4.AliasTelefonoDojo].ToString());
                        elDojo.Email_dojo = row[RecursosBDModulo4.AliasEmailDojo].ToString();
                        elDojo.Logo_dojo = row[RecursosBDModulo4.AliasLogoDojo].ToString();
                        elDojo.Estilo_dojo = row[RecursosBDModulo4.AliasEstiloDojo].ToString();
                        elDojo.Status_dojo = row[RecursosBDModulo4.AliasStatusDojo].ToString();
                        elDojo.Registro_dojo = DateTime.Parse(row[RecursosBDModulo4.AliasFechaDojo].ToString());
                        elDojo.Organizacion_dojo = row[RecursosBDModulo4.AliasNombreOrganizacion].ToString();
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
        public static bool BuscarIDDojo(Dojo elDojo)
        {
            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo4.ParamIdDojo, SqlDbType.Int
                                                      , elDojo.Id_dojo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo4.ParamSalidaNumDojo, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDModulo4.BuscarIdDojo
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDModulo4.ParamSalidaNumDojo)
                        if (int.Parse(elResultado.valor) == 1)
                            retorno = true;
                        else
                            throw new ExcepcionesSKD.Modulo4.DojoInexistenteException(RecursosBDModulo4.Codigo_Dojo_Inexistente,
                                RecursosBDModulo4.Mensaje_Dojo_Inexistente, new Exception());
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

            return retorno;


        }
    }
}
