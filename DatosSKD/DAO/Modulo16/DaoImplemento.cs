using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DatosSKD.DAO;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo15;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;

namespace DatosSKD.DAO.Modulo16
{
    public class DaoImplemento : DAOGeneral, IdaoImplemento
    {
    
        #region Metodos
        /// <summary>
        /// Metodo que retorma una lista de eventos existentes
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de eventos</returns>
        public List<Entidad> ConsultarTodos()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Implemento elImplemento;
            Dojo elDojo;

            try
            {
                    resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_IMPLEMENTOS_POR_DOJOS,
                        parametros);

                    foreach (DataRow row in resultado.Rows)
                    {
                        elImplemento = (Implemento)laFabrica.ObtenerImplemento();
                        elDojo = (Dojo)laFabrica.ObtenerDojos();
                        elImplemento.Id_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString());
                        elImplemento.Nombre_Implemento = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                        elImplemento.Tipo_Implemento = row[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                        elImplemento.Marca_Implemento = row[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                        elImplemento.Precio_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                        elImplemento.Cantida_implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_CANTIDAD_IMPLEMENTO].ToString());
                        elDojo.Nombre_dojo = row[RecursosBDModulo16.PARAMETRO_DOJO_NOMBRE].ToString();
                        elImplemento.Dojo_Implemento = elDojo;
                        laLista.Add(elImplemento);
                       
                    }

                return laLista;

            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
            

        }


        public List<Entidad> ListarImplemento()
        {
            return new List<Entidad>();
        }

        /// <summary>
        /// Metodo que devueve un tipoimplemento dado su id
        /// </summary>
        /// <param name="Id_evento">Indica el objeto a detallar</param>
        /// <returns>Retorna un implemento en especifico con todos sus detalles</returns>
        public Entidad DetallarImplemento(int Id_implemento)
        {
            return new Persona();
        }

        #endregion

    }
}
