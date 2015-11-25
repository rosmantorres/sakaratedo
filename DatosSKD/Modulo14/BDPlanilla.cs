using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatosSKD.Modulo14
{
    public class BDPlanilla
    {
        #region atributos

        private BDConexion con = new BDConexion();

        #endregion

        #region metodos
        public List<DominioSKD.Planilla> ConsultarPlanillasCreadas()
        {
            SqlConnection conect = con.Conectar();
            List<DominioSKD.Planilla> lista = new List<DominioSKD.Planilla>();
            DominioSKD.Planilla planilla;

                try
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarPlanillasCreadas, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        while (leer.Read())
                        {
                            planilla = new DominioSKD.Planilla();
                            planilla.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdPlanilla]);
                            planilla.Nombre = leer[RecursosBDModulo14.AtributoNombrePlanilla].ToString();
                            planilla.Status = Convert.ToBoolean(leer[RecursosBDModulo14.AtributoStatusPlanilla]);
                            planilla.TipoPlanilla= leer[RecursosBDModulo14.AtributoNombreTipoPlanilla].ToString();
                            lista.Add(planilla);
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
        #endregion
    }
}
