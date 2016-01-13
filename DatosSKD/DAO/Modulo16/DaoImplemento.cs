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

        #region Metodos para ConsultarXId (Listar Productos por id )
        /// <summary>
        /// Metodo que retorma una lista de productos existentes
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de implementos</returns>
       
        public Entidad ConsultarXId(Entidad implemento)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Implemento> laLista = new List<Implemento>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Implemento elImplemento;
            ListaImplemento lista = new ListaImplemento();
            Dojo elDojo = new Dojo();

            PersonaM1 p = (PersonaM1)implemento;

            try
            {
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, p._Id.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_INVENTARIO_TOTAL_DOJOS, parametros);

                    //Limpio la conexion
                    LimpiarSQLConnection();

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
                    lista.ListaImplementos = laLista;

                    //Limpio la conexion
                    LimpiarSQLConnection();

                    return lista;
            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
           
        }
#endregion

            #region Metodo para DetallarImplemento (Detallar Implemento)
            /// <summary>
        /// Metodo que retorma una entidad de tipo implemento
        /// </summary>
        /// <param name=Entidad>Se pasa el id del implemento a buscar</param>
        /// <returns>Todas los atributos de la clase implemento para el detallar</returns>
        
        public Entidad DetallarImplemento(Entidad implemento)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Implemento> laLista = new List<Implemento>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Implemento elImplemento = new Implemento();
            Implemento lista = new Implemento();

            Implemento imp = (Implemento)implemento;


            try
            {
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, imp.Id_Implemento.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.DETALLAR_IMPLEMENTO, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                foreach (DataRow row in resultado.Rows)
                {
                    elImplemento = (Implemento)laFabrica.ObtenerImplemento();
                    elImplemento.Imagen_implemento = row[RecursosBDModulo16.PARAMETRO_IMAGEN].ToString();
                    elImplemento.Nombre_Implemento = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elImplemento.Tipo_Implemento = row[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                    elImplemento.Marca_Implemento = row[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                    elImplemento.Color_Implemento = row[RecursosBDModulo16.PARAMETRO_COLOR].ToString();
                    elImplemento.Talla_Implemento = row[RecursosBDModulo16.PARAMETRO_TALLA].ToString();
                    elImplemento.Estatus_Implemento = row[RecursosBDModulo16.PARAMETRO_ESTATUS].ToString();
                    elImplemento.Precio_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    elImplemento.Descripcion_Implemento = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();
              
                }

                //Limpio la conexion
                LimpiarSQLConnection();

                return elImplemento;

            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        #endregion 

        #region Metodo para ListarImplemento

        /// <summary>
        /// Metodo para el listar de productos sin parametro
        /// </summary>
        /// <returns>Retorna una lista de implementos</returns>
        public List<Entidad> ListarImplemento()
        {
            return new List<Entidad>();
        }

        #endregion

        #region Metodo para ConsultarTodos sin parametros
        /// <summary>
        /// Metodo que devueve un tipoimplemento dado su id
        /// </summary>
        /// <param name="NONE">El metodo no posee paso de parametros</param>
        /// <returns>Retorna una lista de implementos</returns>
      //  public Entidad DetallarImplemento(Entidad implemento)
         public List<Entidad> ConsultarTodos()
       {
           return new List<Entidad>();
        }

        #endregion

    }
}
