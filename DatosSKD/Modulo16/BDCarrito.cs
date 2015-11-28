using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;
using System.Data.SqlClient;
using System.Data;
using DominioSKD;


namespace DatosSKD.Modulo16
{
    /// <summary>
    /// Clase que gestiona todo el proceso del carrito del usuario contra la Base de Datos
    /// </summary>
    public class BDCarrito
    {
        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase BDCarrito
        /// </summary>
        public BDCarrito()
        {
           
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que obtiene todos los items de implementos en el carrito del usuario de la Base de Datos
        /// </summary>
        /// <param name="idUsuario">Usuario del que se desea ver los items del iventario agregados en carrito</param>
        /// <returns>Lista con todos los items del inventario que se encuentran en el carrito</returns>
        
        public List<Implemento> getImplemento(int idUsuario)
        {
            List<Implemento> laLista = new List<Implemento>();
            try
            {
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                DataTable dt = conexion.EjecutarStoredProcedureTuplas
                    (RecursosBDModulo16.PROCEDIMIENTO_SELECCIONAR_ID_INVENTARIO, parametros);

                //Obtengo todos los ids que estan en carrito de los Inventario
                foreach (DataRow row in dt.Rows)
                {
                    //Me creo el Implemento
                    Implemento elInventario = new Implemento();

                    //Preparo para obtener los datos de ese Inventario
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int,
                        row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString(), false);
                    parametros.Add(parametro);

                    //Seteamos el id del implemento
                    elInventario.Id_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString());

                    //Obtengo la informacion de los inventarios
                    conexion = new BDConexion();
                    DataTable dt2 = conexion.EjecutarStoredProcedureTuplas
                        (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_INVENTARIO_ID, parametros);

                    //Por cada ID obtengo su informacion correspondiente
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        elInventario.Imagen_implemento = row2[RecursosBDModulo16.PARAMETRO_IMAGEN].ToString();
                        elInventario.Nombre_Implemento = row2[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                        elInventario.Tipo_Implemento = row2[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                        elInventario.Marca_Implemento = row2[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                        elInventario.Precio_Implemento = int.Parse(
                            row2[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());                        
                    }

                    //Agrego a la lista
                    laLista.Add(elInventario);
                }

                //Retorno la lista
                return laLista;
            }
            catch (SqlException e)
            {
                throw new ExceptionSKDConexionBD("", "", e);
            }
            catch (ParametroInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExceptionSKDConexionBD("blabla", "blabla", e);
            }
        }

        /// <summary>
        /// Metodo que obtiene todas las matriculas en el carrito del usuario en la Base de Datos
        /// </summary>
        /// <param name="idUsuario">Usuario del que se desea ver las matriculas agregadas en carrito</param>
        /// <returns>Lista con todas las matriculas que se encuentra en el carrito</returns>
        /*
        public List<Matricula> getMatricula(int idUsuario)
        {

        }*/

        /// <summary>
        /// Metodo que obtiene tos los eventos en el carrito el usuario en la Base de Datos
        /// </summary>
        /// <param name="idUsuario">Usuario del que se desea ver los eventos agregados en carrito</param>
        /// <returns>Lista con todos los eventos que se encuentran en el carrito</returns>
        
        public List<Evento> getEvento(int idUsuario)
        {
            List<Evento> laLista= new List<Evento>();
            try
            {
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                DataTable dt = conexion.EjecutarStoredProcedureTuplas
                    (RecursosBDModulo16.PROCEDIMIENTO_SELECCIONAR_ID_EVENTO, parametros);

                //Obtengo todos los ids que estan en carrito de los eventos
                foreach(DataRow row in dt.Rows)
                {
                    
                    //Preparo para obtener los datos de ese evento
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, 
                        row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString(), false);
                    parametros.Add(parametro);

                    //Obtengo la informacion de los eventos
                    conexion = new BDConexion();
                    DataTable dt2 = conexion.EjecutarStoredProcedureTuplas
                        (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_EVENTO_ID, parametros);

                    //Por cada ID obtengo su informacion correspondiente
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        //Me creo el evento
                        Evento elEvento = new Evento(int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString()),
                            row2[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString(),null,
                            int.Parse(row2[RecursosBDModulo16.PARAMETRO_PRECIO].ToString()),null,null,null);

                        //Agrego a la lista
                        laLista.Add(elEvento);
                     }
                        
                    
                }

                //Retorno la lista
                return laLista;
            }
            catch (SqlException e)
            {
                throw new ExceptionSKDConexionBD("", "", e);
            }
            catch (ParametroInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExceptionSKDConexionBD("blabla", "blabla", e);
            }
        }

        /*
        /// <summary>
        /// Metodo que obtiene todas las matriculas en el carrito del usuario de la Base de Datos
        /// </summary>
        /// <param name="idUsuario">Usuario del que se desea ver las matriculas agregadas en el carrito</param>
        /// <returns>Lista con todas las matriculas que se encuentran en el carrito</returns>
        
        public List<Matricula> getMatricula(int idUsuario)
        {
            List<Matricula> laLista= new List<Matricula>();
            try
            {
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                DataTable dt = conexion.EjecutarStoredProcedureTuplas
                    (RecursosBDModulo16.PROCEDIMIENTO_SELECCIONAR_ID_MATRICULA, parametros);

                //Obtengo todos los ids que estan en carrito de los eventos
                foreach(DataRow row in dt.Rows)
                {
                    
                    //Preparo para obtener los datos de ese evento
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, 
                        row[RecursosBDModulo16.PARAMETRO_IDMATRICULA].ToString(), false);
                    parametros.Add(parametro);

                    //Obtengo la informacion de los eventos
                    conexion = new BDConexion();
                    DataTable dt2 = conexion.EjecutarStoredProcedureTuplas
                        (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_MATRICULA_ID, parametros);

                    Matricula laMatricula = new Matricula();

                    //Por cada ID obtengo su informacion correspondiente
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        //Me creo la matricula
                        //TERMINAR ESTA PARTE!!!!!!!!!!!!!!!!!!!!!!
                        laMatricula = 

                        //Agrego a la lista
                        laLista.Add(laMatricula);
                     }
                        
                    
                }

                //Retorno la lista
                return laLista;
            }
            catch (SqlException e)
            {
                throw new ExceptionSKDConexionBD("", "", e);
            }
            catch (ParametroInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExceptionSKDConexionBD("blabla", "blabla", e);
            }
        }*/
        
        /// <summary>
        /// Metodo que elimina un objeto que haya en el carrito del usuario en la Base de Datos
        /// </summary>
        /// <param name="tipoObjeto">Especifica si se borrara una matricula, un inventario o evento</param>
        /// <param name="objetoBorrar">El objeto en especifico a borrar</param>
        /// <param name="idUsuario">El usuario al que se alterara su carrito</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>
        public bool eliminarItem(int tipoObjeto, int objetoBorrar, int idUsuario)
        {
            //Procedo a intentar eliminar el Item en BD
            try
            {
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO, SqlDbType.Int, 
                    idUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, 
                    objetoBorrar.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_TIPO_ITEM, SqlDbType.Int, 
                    tipoObjeto.ToString(), false);
                parametros.Add(parametro);
                
                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                conexion.EjecutarStoredProcedure(RecursosBDModulo16.PROCEDIMIENTO_ELIMINAR_ITEM,parametros);

                return true;
            }
            catch (SqlException e)
            {
                throw new ExceptionSKDConexionBD("","",e);
            }
            catch (ParametroInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExceptionSKDConexionBD("blabla","blabla",e);
            }

        }

        /// <summary>
        /// Metodo que registra el pago de los productos existentes en el carrito de la base de datos
        /// La lista de datos actualmente no se usa, se deja asi para posibles futuros usos
        /// </summary>
        /// <param name="tipoPago">Indica cual de las formas se eligio para los pagos</param>
        /// <param name="datos">Todos los datos pertenecientes de ese tipo de pago</param>
        /// <param name="idUsuario">El usuario al que se alterara su carrito</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>
        public bool registrarPago(String tipoPago, List<int> datos, int idUsuario)
        {
            //Procedo a intentar registrar el pago en Base de Datos
            try
            {
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO, 
                    SqlDbType.VarChar, tipoPago, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_TIPO_ITEM, 
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                conexion.EjecutarStoredProcedure(RecursosBDModulo16.PROCEDIMIENTO_REGISTRAR_PAGO, parametros);

                return true;
            }
            catch (SqlException e)
            {
                throw new ExceptionSKDConexionBD("", "", e);
            }
            catch (ParametroInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExceptionSKDConexionBD("blabla", "blabla", e);
            }
        }














        /// <summary>
        /// Metodo que agrega los eventos al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idUsuario">Indica el Indentificador del usuario que esta asociado al evento</param>
        /// <param name="idEvento">Indica el Identificador del Evento</param>
        /// <returns> True o False si la operacion fue exitosa o fallida</returns>
        public bool agregarEventoaCarrito(int idUsuario, int idEvento)
        {
            return true;
        }

        /// <summary>
        /// Metodo que agrega los matriculas al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idUsuario">Indica el identificador del Usuario</param>
        /// <param name="idMatricula">Indica el Identificador de la Matricula</param>
        /// <returns>True o False si la operacion fue exitosa o fallida</returns>
        public bool agregarMatriculaaCarrito(int idUsuario, int idMatricula)
        {
            return true;
        }

        /// <summary>
        /// Metodo que agrega los inventarios al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idUsuario">Indica cual de las formas se eligio para pagar</param>
        /// <param name="idInventario">Todos los datos pertinentes de ese tipo de pago</param>
        /// <returns>True o False si la operacion fue exitosa o fallida</returns>
        public bool agregarInventarioaCarrito(int idUsuario, int idInventario)
        {
            return true;
        }


        


        #endregion
    }
}
