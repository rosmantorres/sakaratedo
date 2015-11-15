using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using System.Data.Sql;
using System.Data.SqlClient;

namespace LogicaNegociosSKD.Modulo15
{
   public  class Implemento
    {
        public void consultarImplemento()
        {

            BDConexion conexion = new BDConexion();
            String query = "SELECT * FROM IMPLEMENTO";

            conexion.Conectar();
            SqlDataReader lectura = conexion.EjecutarQuery(query);

            if (lectura.HasRows)
            {
                while (lectura.Read())
                {
                    Console.WriteLine("{0}\t{1}", lectura.GetInt32(0),
                        lectura.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            lectura.Close();


        }
    }
}
