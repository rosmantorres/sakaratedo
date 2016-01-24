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
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;
using DominioSKD.Entidades.Modulo1;

namespace DatosSKD.DAO.Modulo16
{
    public class DaoCompra : DAOGeneral, IdaoCompra
    {
        #region Constructor
        /// <summary>
        /// Constructor vacio del DAO
        /// </summary>
        public DaoCompra()
        {

        }
        #endregion

        #region Metodos para ConsultarXId
        /// <summary>
        /// Metodo que retorma una lista de facturas existentes
        /// </summary>
        /// <param name=Entidad>Se pasa el id del usuario logueado</param>
        /// <returns>Todas las facturas asociadas al id de la persona logueada</returns>
        public Entidad ConsultarXId(Entidad entidad)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Compra> laLista = new List<Compra>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Compra laCompra;
            ListaCompra lista = new ListaCompra();

            // Casteamos
            PersonaM1 p = (PersonaM1)entidad;

            //Nos aseguramos que realmente sea una persona valida
            if (entidad is PersonaM1)
            {
                try
                {
                    //Escribo en el logger la entrada a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Creo la lista de los parametros para el stored procedure y los anexo
                    parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, p._Id.ToString(), false);
                    parametros.Add(parametro);

                    //Ejecuto el Stored Procedure 
                    resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_COMPRAS, parametros);

                    //Limpio la conexion
                    LimpiarSQLConnection();

                    //Obtengo todos los ids que estan en la compra
                    foreach (DataRow row in resultado.Rows)
                    {
                        laCompra = (Compra)FabricaEntidades.ObtenerFactura();
                        laCompra.Com_id = int.Parse(row[RecursosBDModulo16.PARAMETRO_ID_COMPRA].ToString());
                        laCompra.Com_estado = row[RecursosBDModulo16.PARAMETRO_ESTADO_COMPRA].ToString();
                        laLista.Add(laCompra);

                    }
                    //Agrego a la lista
                    lista.ListaCompras = laLista;

                    //Limpio la conexion
                    LimpiarSQLConnection();

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Retorno la lista
                    return lista;

                }

                #region catches
                catch (LoggerException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw e;
                }
                catch (ArgumentNullException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new ParseoVacioException(RecursosBDModulo16.CODIGO_EXCEPCION_ARGUMENTO_NULO,
                        RecursosBDModulo16.MENSAJE_EXCEPCION_ARGUMENTO_NULO, e);
                }
                catch (FormatException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new ParseoFormatoInvalidoException(RecursosBDModulo16.CODIGO_EXCEPCION_FORMATO_INVALIDO,
                        RecursosBDModulo16.MENSAJE_EXCEPCION_FORMATO_INVALIDO, e);
                }
                catch (OverflowException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new ParseoEnSobrecargaException(RecursosBDModulo16.CODIGO_EXCEPCION_SOBRECARGA,
                        RecursosBDModulo16.MENSAJE_EXCEPCION_SOBRECARGA, e);
                }
                catch (ParametroInvalidoException e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw e;
                }
                catch (ExceptionSKDConexionBD e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw e;
                }
                catch (ExceptionSKD e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw e;
                }
                catch (Exception e)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                    throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                        RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
                }
                #endregion
            }
            else throw new PersonaNoValidaException(RecursosBDModulo16.MENSAJE_EXCEPCION_PERSONA_INVALIDA);  
        }
        #endregion

        #region Metodo DetallarFactura
        /// <summary>
        /// Metodo que devueve un tipoimplemento dado su id
        /// </summary>
        /// <param name="entidad">Indica el objeto a detallar</param>
        /// <returns>Retorna una factura en especifico con todos sus detalles</returns>
        public Entidad DetallarFactura(Entidad compra)
        {
            List<Compra> laLista = new List<Compra>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();

            // Instanciando los productos
            DetalleFacturaProducto elProducto = new DetalleFacturaProducto();

            //Instancio los eventos
            DetalleFacturaEvento elEvento = new DetalleFacturaEvento();

            // Instancio las matriculas
            DetalleFacturaMatricula laMatricula = new DetalleFacturaMatricula();

            // Instanciando el pago
            Pago elPago = new Pago();

            // Instancio la compra
            Compra laCompra = new Compra();
            Compra lista = new Compra();
            
            // Casteamos
            Compra comp = (Compra)compra;

            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista de los parametros para el stored procedure y los anexo
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, comp.Com_id.ToString(), false);
                parametros.Add(parametro);

                 /////////////////////////////////////// Buscando el detalle de PRODUCTOS //////////////////////////////////////////

                //Ejecuto el Stored Procedure 
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_PRODUCTO_FACTURA, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                comp.Listainventario = new List<DetalleFacturaProducto>();

                //Obtengo todos los elementos del evento
                foreach (DataRow row in resultado.Rows)
                {
                    elProducto = (DetalleFacturaProducto)FabricaEntidades.ObtenerFacturaImplemento();

                    elProducto.Producto.Nombre_Implemento = row[RecursosBDModulo16.PARAM_NOMBRE].ToString();
                    elProducto.Producto.Precio_Implemento = int.Parse(row[RecursosBDModulo16.PARAM_PRECIO].ToString());
                    elProducto.Cantidad_producto = int.Parse(row[RecursosBDModulo16.PARAM_CANTIDAD].ToString());
                    elProducto.Subtotal = int.Parse(row[RecursosBDModulo16.PARAM_MONTO_PP].ToString());

                    comp.Listainventario.Add(elProducto);
                }

                //Limpio la conexion
                LimpiarSQLConnection();

                /////////////////////////////////////// Buscando el detalle de EVENTOS //////////////////////////////////////////
                //Ejecuto el Stored Procedure 
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_EVENTO_FACTURA, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                comp.Listaevento = new List<DetalleFacturaEvento>();

                //Obtengo todos los elementos del evento
                foreach (DataRow row in resultado.Rows)
                {
                    elEvento = (DetalleFacturaEvento)FabricaEntidades.ObtenerFacturaEvento();

                    elEvento.Evento.Nombre = row[RecursosBDModulo16.PARAM_NOMBRE_EVENTO].ToString();
                    elEvento.Evento.Costo = int.Parse(row[RecursosBDModulo16.PARAM_PRECIO].ToString());
                    elEvento.Cantidad_evento = int.Parse(row[RecursosBDModulo16.PARAM_CANT_EVENTO].ToString());
                    elEvento.Subtotal = int.Parse(row[RecursosBDModulo16.PARAM_MONTO_PE].ToString());

                    comp.Listaevento.Add(elEvento);
                }

                //Limpio la conexion
                LimpiarSQLConnection();


                /////////////////////////////////////// Buscando el detalle de MATRICULA //////////////////////////////////////////
                //Ejecuto el Stored Procedure 
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_MATRICULA_FACTURA, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                comp.Listamatricula = new List<DetalleFacturaMatricula>();

                //Obtengo todos los elementos del evento
                foreach (DataRow row in resultado.Rows)
                {
                    laMatricula = (DetalleFacturaMatricula)FabricaEntidades.ObtenerFacturaMatricula();

                    laMatricula.Matricula.Identificador = row[RecursosBDModulo16.PARAM_NOMBRE_MAT].ToString();
                    laMatricula.Matricula.Costo = int.Parse(row[RecursosBDModulo16.PARAM_PRECIO].ToString());
                    laMatricula.Cantidad_matricula = int.Parse(row[RecursosBDModulo16.PARAM_CANT_MAT].ToString());
                    laMatricula.Subtotal = int.Parse(row[RecursosBDModulo16.PARAM_MONTO_PM].ToString());

                    comp.Listamatricula.Add(laMatricula);
                }

                //Limpio la conexion
                LimpiarSQLConnection();


                /////////////////////////////////////// Buscando los DATOS DE LA FACTURA //////////////////////////////////////////
                //Ejecuto el Stored Procedure 
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_FACTURA_DATO, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                comp.Listapago = new List<Pago>();

                //Obtengo todos los elementos de la factura
                foreach (DataRow row in resultado.Rows)
                {
                    elPago = (Pago)FabricaEntidades.ObtenerFacturaPago();
                    laCompra = (Compra)FabricaEntidades.ObtenerFactura();

                    laCompra.Id = int.Parse(row[RecursosBDModulo16.PARAM_ID_FACT].ToString());
                    laCompra.Com_fecha_compra = DateTime.Parse(row[RecursosBDModulo16.PARAM_FECHA_COMPRA].ToString());
                    elPago.TipoPago = row[RecursosBDModulo16.PARAM_TIPO_PAGO_FACT].ToString();
                    comp.Monto = int.Parse(row[RecursosBDModulo16.PARAM_MONTO_PAGO_FACT].ToString());

                    comp.Listapago.Add(elPago);
                }

                //Limpio la conexion
                LimpiarSQLConnection();

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno el evento
                return comp;

            }

            #region catches
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ArgumentNullException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoVacioException(RecursosBDModulo16.CODIGO_EXCEPCION_ARGUMENTO_NULO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_ARGUMENTO_NULO, e);
            }
            catch (FormatException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoFormatoInvalidoException(RecursosBDModulo16.CODIGO_EXCEPCION_FORMATO_INVALIDO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_FORMATO_INVALIDO, e);
            }
            catch (OverflowException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoEnSobrecargaException(RecursosBDModulo16.CODIGO_EXCEPCION_SOBRECARGA,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_SOBRECARGA, e);
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }
            #endregion          
        }

        #endregion

        #region Metodo que Lista las facturas
        /// <summary>
        /// Metodo que devueve una lista de facturas
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>Retorna una lista de facturas sin filtro</returns>
        public List<Entidad> ListarFactura()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodo ConsultarTodos
        /// <summary>
        /// Metodo que devueve una lista de facturas
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>Retorna una lista de facturas</returns>
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodo de Agregar
        /// <summary>
        /// Metodo que que no implementamos
        /// </summary>
        public Entidad Agregar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodo de Modificar
        /// <summary>
        /// Metodo que que no implementamos
        /// </summary>
        public Entidad Modificar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
