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
                    laCompetencia.TipoCompetencia = int.Parse(row[RecursosBDModulo12.AliasTipoCompetencia].ToString());
                    laCompetencia.Status = row[RecursosBDModulo12.AliasStatusCompetencia].ToString();
                    laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDModulo12.AliasTodasOrganizaciones].ToString());

                    if(laCompetencia.OrganizacionTodas == false)
                        laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo12.AliasIdOrganizacion].ToString())
                                                                        ,row[RecursosBDModulo12.AliasNombreOrganizacion].ToString());

                    laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo12.AliasIdUbicacion].ToString()),
                                                            row[RecursosBDModulo12.AliasNombreCiudad].ToString(),
                                                            row[RecursosBDModulo12.AliasNombreEstado].ToString());
                    
                    laListaDeCompetencias.Add(laCompetencia);
                
                }
            
            }
            catch (Exception e)
            {
            
            }

            return laListaDeCompetencias;

        }
    }
}
