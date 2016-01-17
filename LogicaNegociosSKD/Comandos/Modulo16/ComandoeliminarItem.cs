using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.Fabrica;
using LogicaNegociosSKD.Comandos;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;
using DatosSKD.DAO.Modulo16;
using DominioSKD;



namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando que ejecuta la accion de eliminar un item del carrito en específico
    /// </summary>
    public class ComandoeliminarItem : Comando<bool>
    {

        #region Atributos
        /// <summary>
        /// Atributos del Comando
        /// </summary>
        private int tipoObjeto;
        private Entidad objetoaBorrar;
        private Entidad usuario;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad del atributo TipoObjeto
        /// </summary>
        public int TipoObjeto
        {
            get
            {
                return this.tipoObjeto;
            }

            set
            {
                this.tipoObjeto = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo objetoborrar
        /// </summary>
        public Entidad ObjetoaBorrar
        {
            get
            {
                return this.objetoaBorrar;
            }

            set
            {
                this.objetoaBorrar = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo usuario
        /// </summary>
        public Entidad Usuario
        {
            get
            {
                return this.usuario;
            }
            set
            {
                this.usuario = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del comando
        /// </summary>
        public ComandoeliminarItem()
        {

        }

        /// <summary>
        /// Constructor del comando con todos los datos requeridos para eliminar
        /// </summary>
        /// <param name="tipoObjeto">tipo de objeto que se eliminará</param>
        /// <param name="ObjetoaBorrar">El item que se elimina al carrito de la persona</param>
        /// <param name="Usuario">Indica a que Usuario esta asociado el item</param>
        public ComandoeliminarItem(int tipoObjeto, Entidad objetoaBorrar, Entidad usuario)
        {
            this.tipoObjeto = tipoObjeto;
            this.objetoaBorrar = objetoaBorrar;
            this.usuario = usuario;

        }
        #endregion
         
        #region Metodo Ejecutar
        /// <summary>
        /// Comando que ejecuta la logica para eliminar un item del carrito
        /// </summary>
        /// <param name="parametro">tipo de objeto, objeto a borrar, persona</param>
        /// <returns>retorna true si se elimino el item a seleccionar de forma satisfactoriamente,
        /// de lo contrario devueleve false</returns>
        public override bool Ejecutar()
        {

            try
            {
                //Se escribe en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Respuesta a obtener en el DAO
                bool Respuesta = false;

                //Instancio el DAO de Carrito
                IdaoCarrito daoCarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();

                //Se procede a ejecutar eliminarItem y se retorna el Resultado


                Respuesta = daoCarrito.eliminarItem(tipoObjeto, objetoaBorrar, usuario);

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //retorno la respuesta de donde sea llamado
                return Respuesta;

            }



            #region Catches
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
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


            #endregion



        }


        #endregion
    }
}
