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

namespace DatosSKD.Modulo13
{
    class BDListarMoroso
    {

        public static List<Persona> ListarMorosos()
        {
            BDConexion laConexion;
            List<Persona> laListaDeMorosos = new List<Persona>();
            //List<Parametro> parametros;

              try
              {
                  laConexion = new BDConexion();
                 // parametros = new List<Parametro>();


                  DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                 RecursosBDModulo13.ConsultarCompetencias, parametros);

                  foreach (DataRow row in dt.Rows)
                  {
                      Competencia laCompetencia = new Competencia();

                      laCompetencia.Id_competencia = int.Parse(row[RecursosBDModulo12.AliasIdCompetencia].ToString());
                      laCompetencia.Nombre = row[RecursosBDModulo12.AliasNombreCompetencia].ToString();
                      laCompetencia.TipoCompetencia = row[RecursosBDModulo12.AliasTipoCompetencia].ToString();

                      if (laCompetencia.TipoCompetencia == "1")
                          laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKata;
                      else
                          laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKumite;

                      laCompetencia.Status = row[RecursosBDModulo12.AliasStatusCompetencia].ToString();
                      laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDModulo12.AliasTodasOrganizaciones].ToString());

                      if (laCompetencia.OrganizacionTodas == false)
                          laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo12.AliasIdOrganizacion].ToString())
                                                                          , row[RecursosBDModulo12.AliasNombreOrganizacion].ToString());
                      else
                      {
                          laCompetencia.Organizacion = new Organizacion(RecursosBDModulo12.TodasLasOrganizaciones);
                      }
                      laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo12.AliasIdUbicacion].ToString()),
                                                              row[RecursosBDModulo12.AliasNombreCiudad].ToString(),
                                                              row[RecursosBDModulo12.AliasNombreEstado].ToString());

                      laListaDeMorosos.Add(laCompetencia);

                  }

              }
              catch (SqlException ex)
              {
                  throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                      RecursoGeneralBD.Mensaje, ex);
              }
              catch (FormatException ex)
              {
                  throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                       RecursosBDModulo12.Mensaje_Error_Formato, ex);
              }
              catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
              {
                  throw ex;
              }
              catch (Exception ex)
              {
                  throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
              }

              return laListaDeMorosos;

          }






      }
          
        }
    


