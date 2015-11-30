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
        public class BDOrganizacion
    {
            /// <summary>
            /// Detalle de la organizacion a la cual pertenece un dojo
            /// </summary>
            /// <param name="idOrg"></param>
            /// <returns></returns>
            public Organizacion DetallarOrganizacion(int idOrg)
            {
                BDConexion laConexion;
                List<Parametro> parametros;
                Parametro elParametro = new Parametro();
               
                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    Organizacion org = new Organizacion();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idOrg.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDModulo7.ConsultaOrganizacionXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                         org.Id_organizacion = int.Parse(row[RecursosBDModulo7.AliasOrganizacionId].ToString());
                         org.Nombre = row[RecursosBDModulo7.AliasOrganizacionNombre].ToString();
                         org.Direccion = row[RecursosBDModulo7.AliasOrganizacionDireccion].ToString();
                         org.Telefono = int.Parse(row[RecursosBDModulo7.AliasOrganizacionTelefono].ToString());
                         org.Email = row[RecursosBDModulo7.AliasOrganizacionEmail].ToString();
                    }

                    return org;

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
