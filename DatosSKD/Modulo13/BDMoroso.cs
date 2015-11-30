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
    class BDMoroso
    {

        public static DataTable ListarMorosos()
        {
            BDConexion laConexion;
          
            List<Parametro> parametros;
          string hola = "hola";
              try
              {
                  laConexion = new BDConexion();
                 parametros = new List<Parametro>();


                 DataTable laListaDeMorosos = laConexion.EjecutarStoredProcedureTuplas(
                                 RecursosBDModulo13.listamorosidad, parametros);

               

                 return laListaDeMorosos;

              }
              catch (SqlException ex)
              {
                  throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                      RecursoGeneralBD.Mensaje, ex);
              }
             
              catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
              {
                  throw ex;
              }
              catch (Exception ex)
              {
                  throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
              }

             

          }






      }
          
        }
    


