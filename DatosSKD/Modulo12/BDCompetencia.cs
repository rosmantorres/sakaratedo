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

namespace DatosSKD.Modulo12
{
    public class BDCompetencia
    {

        public static List<Competencia> ListarCompetencias()
        {
            BDConexion laConexion;
            List<Competencia> laListaDeCompetencias = new List<Competencia>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo12.ConsultarCompetencias, parametros);

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
                    
                    laListaDeCompetencias.Add(laCompetencia);
                
                }
            
            }
            catch (Exception e)
            {
                throw e;
            }

            return laListaDeCompetencias;

        }

        public static Competencia DetallarCompetencia(int idCompetencia)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Competencia laCompetencia = new Competencia();

                elParametro = new Parametro(RecursosBDModulo12.AliasIdCompetencia,SqlDbType.Int,idCompetencia.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo12.ConsultarCompetenciasXId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    

                    laCompetencia.Id_competencia = int.Parse(row[RecursosBDModulo12.AliasIdCompetencia].ToString());
                    laCompetencia.Nombre = row[RecursosBDModulo12.AliasNombreCompetencia].ToString();
                    laCompetencia.TipoCompetencia = row[RecursosBDModulo12.AliasTipoCompetencia].ToString();

                    if (laCompetencia.TipoCompetencia == "1")
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKata;
                    else
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKumite;

                    laCompetencia.Status = row[RecursosBDModulo12.AliasStatusCompetencia].ToString();
                    laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDModulo12.AliasTodasOrganizaciones].ToString());
                    laCompetencia.FechaInicio = Convert.ToDateTime(row[RecursosBDModulo12.AliasEdadInicio].ToString());
                    laCompetencia.FechaFin = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin].ToString());
                    laCompetencia.Costo = float.Parse(row[RecursosBDModulo12.AliasCostoCompetencia].ToString());
                    
                    if (laCompetencia.OrganizacionTodas == false)
                        laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo12.AliasIdOrganizacion].ToString())
                                                                        , row[RecursosBDModulo12.AliasNombreOrganizacion].ToString());
                    else
                    {
                        laCompetencia.Organizacion = new Organizacion(RecursosBDModulo12.TodasLasOrganizaciones);
                    }
                    laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo12.AliasIdUbicacion].ToString()),
                                                            row[RecursosBDModulo12.AliasLatitudDireccion].ToString(),
                                                            row[RecursosBDModulo12.AliasLongitudDireccion].ToString(),
                                                            row[RecursosBDModulo12.AliasNombreCiudad].ToString(),
                                                            row[RecursosBDModulo12.AliasNombreEstado].ToString(),
                                                            row[RecursosBDModulo12.AliasNombreDireccion].ToString());

                    laCompetencia.Categoria = new Categoria(int.Parse(row[RecursosBDModulo12.AliasIdCategoria].ToString()),
                                                             int.Parse(row[RecursosBDModulo12.AliasEdadInicio].ToString()),
                                                             int.Parse(row[RecursosBDModulo12.AliasFechaFin].ToString()),
                                                             row[RecursosBDModulo12.AliasCintaInicio].ToString(),
                                                             row[RecursosBDModulo12.AliasCintaFin].ToString(),
                                                             row[RecursosBDModulo12.AliasSexo].ToString());
                    

                }
                return laCompetencia;



            }
            catch (Exception e)
            {
                throw e;
            }

           
        }

    }
}
