using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;

namespace DatosSKD.Modulo14
{
    public class BDSolicitud
    {
        private BDConexion con = new BDConexion();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public List<DominioSKD.SolicitudPlanilla> ConsultarSolicitudes(int idPersona)
        {
            SqlConnection conect = con.Conectar();
            List<DominioSKD.SolicitudPlanilla> lista = new List<DominioSKD.SolicitudPlanilla>();
            SolicitudPlanilla solicitud;
            
               try
               {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarSolicitudPlanilla, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroPersonaPerId, idPersona));

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        while (leer.Read())
                        {
                            solicitud = new SolicitudPlanilla();
                            DominioSKD.Planilla planilla = new Planilla();
                            solicitud.Planilla = planilla;
                            solicitud.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdSolicitud]);
                            solicitud.FechaCreacion = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaCreacion]);
                            solicitud.FechaRetiro = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaRetiro]);
                            solicitud.FechaReincorporacion = Convert.ToDateTime(leer[RecursosBDModulo14.AtributoFechaReincorporacion]);
                            solicitud.Motivo = leer[RecursosBDModulo14.AtributoMotivo].ToString();
                            solicitud.Planilla.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdPlanillaDatos]);
                            solicitud.Planilla.Nombre = leer[RecursosBDModulo14.AtributoNombrePlanilla].ToString();
                            solicitud.Planilla.TipoPlanilla = leer[RecursosBDModulo14.AtributoTipo].ToString();
                            if(leer[RecursosBDModulo14.AtributoEventoNombre].ToString()!="")
                                solicitud.Evento = leer[RecursosBDModulo14.AtributoEventoNombre].ToString();
                            else
                                solicitud.Evento = leer[RecursosBDModulo14.AtributoCompetenciaNombre].ToString();
                            lista.Add(solicitud);
                            planilla = null;
                            solicitud = null;
                            
                        }

                        return lista;
                    }
                else
                   {
                       return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Desconectar(conect);
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diseño"></param>
        /// <param name="planilla"></param>
        /// <returns></returns>
        public Boolean EliminarSolicitudBD(int idSolicitud)
        {
            SqlConnection conect = con.Conectar();
            try
            {
                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureEliminarSolicitud, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroIdSolicitud,
                        SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo14.ParametroIdSolicitud].Value = idSolicitud;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public List<DominioSKD.Planilla> ConsultarPlanillasASolicitarBD()
        {
            SqlConnection conect = con.Conectar();
            List<DominioSKD.Planilla> lista = new List<DominioSKD.Planilla>();
             DominioSKD.Planilla planilla;

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarPlanillasASolicitar, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        planilla = new Planilla();
                        Diseño diseño = new Diseño();
                        planilla.Diseño = diseño;
                        planilla.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdPlanilla]);
                        planilla.Nombre = leer[RecursosBDModulo14.AtributoNombrePlanilla].ToString();
                        planilla.Diseño.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdDiseño]);
                        planilla.TipoPlanilla = leer[RecursosBDModulo14.AtributoTipo].ToString();
                        lista.Add(planilla);
                        diseño = null;
                        planilla = null;

                    }

                    return lista;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Desconectar(conect);
            }
        }
    }
}
