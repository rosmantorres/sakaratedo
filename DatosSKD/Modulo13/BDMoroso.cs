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
    public class BDMoroso
    {

        #region atributos

        private BDConexion con = new BDConexion();


        #endregion

        #region metodos
        public List<DominioSKD.Morosidad> ConsultarMorosos()
        {
            SqlConnection conect = con.Conectar();
            List<DominioSKD.Morosidad> lista = new List<DominioSKD.Morosidad>();
            DominioSKD.Morosidad morosidad;

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo13.ConsultarListaMorosidad, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        morosidad = new DominioSKD.Morosidad();
                        morosidad.Nombre =leer[RecursosBDModulo13.nombre].ToString();
                        morosidad.Apellido = leer[RecursosBDModulo13.apellido].ToString();
                        morosidad.Cedula = leer[RecursosBDModulo13.dni].ToString();
                        morosidad.DojoNombre = leer[RecursosBDModulo13.DojoNombre].ToString();
                        morosidad.MeseMoroso = leer[RecursosBDModulo13.meseMoroso].ToString();
                        morosidad.Monto = leer[RecursosBDModulo13.MontoTotal].ToString();


                        lista.Add(morosidad);
                        morosidad = null;

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
