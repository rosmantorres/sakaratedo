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
    public class BDAtletasCinta
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
                    Persona personas = new Persona();
                    personas.Apellido = row[RecursosBDModulo13.apellido].ToString();
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
}
