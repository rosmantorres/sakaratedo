using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace DatosSKD.Modulo13
{
    public class BDimplementos
    {
        
        
        #region Listar Inventario

        public static  SqlDataReader D_Inventario()
        {
            // BDConexion laConexion;
            String query = "  select imp.imp_imagen, imp_nombre,imp.imp_tipo, imp.imp_marca, imp.imp_color,  imp.imp_estatus, imp_precio, imp_stockmin, inv_cantidad_total, d.doj_nombre  from implemento as imp, inventario as inv, dojo as d where imp.imp_id=inv.IMPLEMENTO_imp_id and d.doj_id=inv.DOJO_doj_id;";
            //laConexion = new BDConexion();
            BDConexion objeto_con= new BDConexion();
            SqlDataReader resultado = objeto_con.EjecutarQuery(query);               
            
            




            return resultado;

        }
        #endregion




        #region Listar Inventario
        public static SqlDataReader D_Info_producto(String dojo)
        {        
          
            BDConexion conn;
            List<Parametro> parametros;
            Parametro param = new Parametro();
            List<Persona> persona = new List<Persona>();

            try
            {

                conn = new BDConexion();
                parametros = new List<Parametro>();

                param = new Parametro("@dojo", SqlDbType.VarChar, dojo, false);
                parametros.Add(param);

                DataTable dt = conn.EjecutarStoredProcedureTuplas("M13_Consultar_top5", parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Implemento implemento = new Implemento();
                    implemento.Apellido = row[RecursosBDModulo13.apellido].ToString();
                    personas.Nombre = row[RecursosBDModulo13.nombre].ToString();
                    personas.Estatura = double.Parse(row[RecursosBDModulo13.estatura].ToString());
                    personas.Peso = double.Parse(row[RecursosBDModulo13.peso].ToString());
                    personas.FechaNacimiento = DateTime.Parse(row[RecursosBDModulo13.Edad].ToString());

                    persona.Add(personas);


                }

                return persona;

            }


            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo, RecursoGeneralBD.Mensaje, ex);
            }

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
        #endregion
}

