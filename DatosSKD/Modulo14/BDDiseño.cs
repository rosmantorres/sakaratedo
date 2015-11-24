﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatosSKD.Modulo14
{
    public class BDDiseño
    {
        private BDConexion con = new BDConexion();

        public Boolean GuardarDiseñoBD(DominioSKD.Diseño diseño, DominioSKD.Planilla planilla)
        {
            SqlConnection conect = con.Conectar();
            try
            {
                if (diseño != null && planilla != null)
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureGuardarDiseño, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroContenido,
                        SqlDbType.VarChar));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroPlanilla,
                        SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo14.ParametroContenido].Value = diseño.Contenido;
                    sqlcom.Parameters[RecursosBDModulo14.ParametroPlanilla].Value = planilla.ID;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
                }
                else
                {
                    return false;
                }
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

        public DominioSKD.Diseño ConsultarDiseño(DominioSKD.Planilla planilla)
        {
            SqlConnection conect = con.Conectar();
            DominioSKD.Diseño diseño = new DominioSKD.Diseño();

            if (planilla != null)
            {
                try
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo14.ProcedureConsultarDiseño, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo14.ParametroDiseñoPlanilla, planilla.ID));

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        while (leer.Read())
                        {
                            diseño.ID = Convert.ToInt32(leer[RecursosBDModulo14.AtributoIdDiseño]);
                            diseño.Contenido = leer[RecursosBDModulo14.AtributocontenidoDiseño].ToString();
                            diseño.Base64Decode();
                            return diseño;
                        }

                        return null;
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
            else
            {
                return null;
            }
        }
    }
}
