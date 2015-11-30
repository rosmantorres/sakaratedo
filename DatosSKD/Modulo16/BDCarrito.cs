﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;
using ExcepcionesSKD;
using System.Data.Sql;
using System.Configuration;

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
        #region VerCarrito
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
                    Implemento elImplemento = new Implemento();

                    //Preparo para obtener los datos de ese Inventario
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int,
                        row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2].ToString(), false);
                    parametros.Add(parametro);

                    //Seteamos el id del implemento
                    elImplemento.Id_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2].ToString());

                    //Obtengo la informacion de los implementos
                    conexion = new BDConexion();
                    DataTable dt2 = conexion.EjecutarStoredProcedureTuplas
                        (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_INVENTARIO_ID, parametros);

                    //Por cada ID obtengo su informacion correspondiente
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        elImplemento.Imagen_implemento = row2[RecursosBDModulo16.PARAMETRO_IMAGEN].ToString();
                        elImplemento.Nombre_Implemento = row2[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                        elImplemento.Tipo_Implemento = row2[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                        elImplemento.Marca_Implemento = row2[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                        elImplemento.Precio_Implemento = int.Parse(
                            row2[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());

                        //Agrego a la lista
                        laLista.Add(elImplemento);
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
        #endregion
        #region EliminarItem
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
        #endregion
        #region RegistrarPago
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
                Parametro parametro = new Parametro();
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO, 
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
        #endregion
        #region AgregarItem
        /// <summary>
        /// Metodo que agrega los eventos al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idPersona">Indica el Indentificador del usuario que esta asociado al evento</param>
        /// <param name="idEvento">Indica el Identificador del Evento</param>
        /// <param name="cantidad">Indica la cantidad que se estan agregando del evento</param>
        /// <param name="precio">Indica el precio del evento para este momento</param>
        /// <returns> True o False si la operacion fue exitosa o fallida</returns>
        /// <summary>
        public static bool agregarEventoaCarrito(int idPersona, int idEvento, int cantidad, int precio)
        {
            //Respuestas del metodo y del stored procedure
            bool exito = false;
            int respuesta = 0;

            //Creo la lista de los parametros para el stored procedure y los anexo
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                    SqlDbType.Int, idPersona.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDEVENTO,
                    SqlDbType.Int, idEvento.ToString(), false);
            parametros.Add(parametro);
                        parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                    SqlDbType.Int, cantidad.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                    SqlDbType.Int, precio.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                SqlDbType.Int, respuesta.ToString(), true);
            parametros.Add(parametro);

            try
            {
                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure esperando un resultado de una variable
                BDConexion conexion = new BDConexion();
                List<Resultado> result = conexion.EjecutarStoredProcedure
                    (RecursosBDModulo16.PROCEDIMIENTO_AGREGAR_EVENTO_CARRITO, parametros);

                //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }

                //Retorno la respuesta
                return exito;
            }

            catch (ExceptionSKDConexionBD ex)
            {

                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionGeneral,
                    RecursosBDModulo16.Mensaje_ExcepcionGeneral, ex);

            }
           
        }

        /// <summary>
        /// Metodo que modifica la cantidad de eventos en el carrito de un Usuario en BD
        /// </summary>
        /// <param name="idUsuario">el ID del usuario a modificarle el carrito</param>
        /// <param name="idEvento">el ID del evento a modificar en el carrito</param>
        /// <param name="cantidad">La cantidad a la cual se actualizara en el carrito</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool modificarCarritoEvento(int idUsuario, int idEvento, int cantidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que agrega las matriculas al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idUsuario">Indica el identificador del Usuario</param>
        /// <param name="idMatricula">Indica el Identificador de la Matricula</param>
        /// <returns>True o False si la operacion fue exitosa o fallida</returns>
        public static bool agregarMatriculaaCarrito(int idPersona, int idMatricula)
        {
            try
            {
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.ParamIdPersona,
                    SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.ParamIdEvento,
                    SqlDbType.Int, idMatricula.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                conexion.EjecutarStoredProcedure(RecursosBDModulo16.StoreProcedureAgregarmatriculaaCarrito, parametros);
                return true;

            }
            catch (NullReferenceException ex)
            {

                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionNullReference,
                    RecursosBDModulo16.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionSKDConexionBD ex)
            {

                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionSql,
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
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionGeneral,
                   RecursosBDModulo16.Mensaje_ExcepcionGeneral, ex);

            }

        }
        
        /// <summary>
        /// Metodo que agrega los implementos al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idPersona">el ID del usuario a modificar el carrito</param>
        /// <param name="idInventario">Todos los datos pertinentes de ese tipo de pago</param>
        /// <param name="cantidad">La cantidad que se agregaran de ese implemento</param>
        /// <param name="precio">El precio del implemento</param>
        /// <returns>True o False si la operacion fue exitosa o fallida</returns>
        public static bool agregarInventarioaCarrito(int idPersona, int idInventario, int cantidad, int precio)
        {
            //Preparamos la respuesta del Stored procedure y el exito o fallo del proceso
            int respuesta = 0;
            bool exito = false;
                       
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                    SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2,
                    SqlDbType.Int, idInventario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                    SqlDbType.Int, cantidad.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                        SqlDbType.Int, precio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                parametros.Add(parametro);

           try
           {
                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure esperando un resultado de una variable
                BDConexion conexion = new BDConexion();
                List<Resultado> result = conexion.EjecutarStoredProcedure
                    (RecursosBDModulo16.StoreProcedureAgregarinventarioaCarrito, parametros);
                
               //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }
               
               //Retorno la respuesta
                return exito;
            }

            catch (ExceptionSKDConexionBD ex)
            {

                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionGeneral,
                   RecursosBDModulo16.Mensaje_ExcepcionGeneral, ex);

            }
            
        }
        
        /// <summary>
        /// Metodo que modifica la cantidad de implementos en el carrito de un Usuario en BD
        /// </summary>
        /// <param name="idUsuario">el ID del usuario a modificarle el carrito</param>
        /// <param name="idImplemento">el ID del Implemento a modificar en el carrito</param>
        /// <param name="cantidad">La cantidad a la cual se actualizara en el carrito</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool modificarCarritoImplemento(int idUsuario, int idImplemento, int cantidad)
        {
            //Preparamos la respuesta del Stored procedure y el exito o fallo del proceso
            int respuesta = 0;
            bool exito = false;

            //Creo la lista de los parametros para el stored procedure y los anexo
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                SqlDbType.Int, idUsuario.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2,
                SqlDbType.Int, idImplemento.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                SqlDbType.Int, cantidad.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                SqlDbType.Int, respuesta.ToString(), true);
            parametros.Add(parametro);

            try
            {
                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure esperando un resultado de una variable
                BDConexion conexion = new BDConexion();
                List<Resultado> result = conexion.EjecutarStoredProcedure
                    (RecursosBDModulo16.PROCEDIMIENTO_MODIFICAR_CANTIDAD_IMPLEMENTO, parametros);

                //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }

                //Retorno la respuesta
                return exito;
            }

            catch (ExceptionSKDConexionBD ex)
            {

                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionGeneral,
                   RecursosBDModulo16.Mensaje_ExcepcionGeneral, ex);

            }
        }
        #endregion
        #endregion
    }
}
