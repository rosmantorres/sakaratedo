using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;
using ExcepcionesSKD.ExceptionSKD;
using ExcepcionesSKD;


namespace DatosSKD.Modulo16
{
    public class BDEvento
    {

        #region Metodos
        /// <summary>
        /// Metodo que retorma una lista de eventos existentes
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de eventos</returns>
        public static List<Evento> ListarEvento()
        {
            BDConexion laConexion;
            List<Evento> laListaDeEvento = new List<Evento>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.CONSULTAR_EVENTOS, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Evento elEvento = new Evento();

                    elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                    elEvento.Nombre = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elEvento.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    laListaDeEvento.Add(elEvento);

                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return laListaDeEvento;

        }

        

        public static Evento DetallarEvento(int idEvento)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Evento elEvento = new Evento();

                elParametro = new Parametro(RecursosBDModulo16.AliasIdEvento, SqlDbType.Int, idEvento.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.StoreProcedureConsultarEventosXId, parametros);

                foreach (DataRow row in dt.Rows)
                {


                    elEvento.Nombre = row[RecursosBDModulo16.AliasNombreEvento].ToString();
                    elEvento.id_organizacion = int.Parse(row[RecursosBDModulo16.AliasidOrganizacion].ToString());
                    elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.AliasIdEvento].ToString());
         
                   
          
                }
               
                      return elEvento;


            }
             catch (NullReferenceException ex)
             {

                 throw new BDEventoException(RecursosBDModulo16.Codigo_ExcepcionNullReference,
                     RecursosBDModulo16.Mensaje_ExcepcionNullReference, ex);

             }
             catch(ExceptionSKDConexionBD ex)
             {
                
                 throw new BDEventoException(RecursoGeneralBD.Codigo,
                     RecursoGeneralBD.Mensaje,ex);

             }
             catch (SqlException ex)
             {
                 throw new BDEventoException(RecursosBDModulo16.Codigo_ExcepcionSql,
                     RecursosBDModulo16.Mensaje_ExcepcionSql, ex);

             }
             catch (ParametroIncorrectoException ex)
             {
                 throw new ParametroIncorrectoException(RecursosBDModulo16.Codigo_ExcepcionParametro,
                     RecursosBDModulo16.Mensaje__ExcepcionParametro, ex);
             }
             catch (AtributoIncorrectoException ex)
             {
                 throw new AtributoIncorrectoException(RecursosBDModulo16.Codigo_ExcepcionAtributo,
                     RecursosBDModulo16.Mensaje_ExcepcionAtributo, ex);
             }
             catch (Exception ex)
             {
                 throw new BDEventoException(RecursosBDModulo16.Codigo_ExcepcionGeneral,
                    RecursosBDModulo16.Mensaje_ExcepcionGeneral, ex);

             }

        }
         }
     }















        #endregion
    }
}

