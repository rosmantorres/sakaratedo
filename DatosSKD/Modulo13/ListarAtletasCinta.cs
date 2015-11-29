using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosSKD.Modulo13
{
    public class ListarAtletasCinta
    {
        public static List<Persona> ListarPersonasCintas() 
        {
            int idCinta = 1;
            BDConexion conn;
            List<Parametro> parametros;
            Parametro param = new Parametro();
            List<Persona> persona = new List<Persona>();

            try
            {

                conn = new BDConexion();
                parametros = new List<Parametro>();

                param = new Parametro(RecursosBDModulo13.Cinta, SqlDbType.Int, idCinta.ToString(), false);
                parametros.Add(param);

                DataTable dt = conn.EjecutarStoredProcedureTuplas(RecursosBDModulo13.ConsultarAtleta, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Persona personas = new Persona;
                    
                    

                }
            
            
            
            
            }



        }
        
    }
}
