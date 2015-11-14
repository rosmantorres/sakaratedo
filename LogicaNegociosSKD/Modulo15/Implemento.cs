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

            SqlDataReader lectura = conexion.EjecutarQuery(query);
            while (lectura.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", lectura[0], lectura[1]));
            }


        }
    }
}
