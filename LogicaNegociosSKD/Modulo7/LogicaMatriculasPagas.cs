using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo7;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;

namespace LogicaNegociosSKD.Modulo7
{
    /// <summary>
    /// Clase para obtener la lista de matriculas pagadas y la descripción de matricula
    /// </summary>
    public class LogicaMatriculasPagas
    {
        #region Atributos
        private List<DominioSKD.Matricula> laListaDeMatriculas;
        #endregion

        #region Get y Set
        public List<DominioSKD.Matricula> LaListaDeEventos
        {
            get { return laListaDeMatriculas; }
            set { laListaDeMatriculas = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor
        /// </summary>
        public LogicaMatriculasPagas()
        {
        }

        /// <summary>
        /// Método que obtiene la lista de matriculas que han sido pagadas
        /// </summary>
        /// <returns>Lista de objetos tipo Matricula</returns>
        public List<DominioSKD.Matricula> obtenerListaDeMatriculas(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                BDMatricula baseDeDatosMatricula = new BDMatricula();
                return baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }


        /// <summary>
        /// Método que obtiene el id de la matricula  pagado por un atleta
        /// </summary>
        /// <param name="idPersona">Número entero que representa el ID del atleta</param>
        /// <returns>un objeto de tipo Matricula</returns>

        public int obtenerIdMatricula(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                BDMatricula baseDeDatosDetalleCompra = new BDMatricula();
                return baseDeDatosDetalleCompra.MatriculaID(idPersona);
                    
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }

 
        /// <summary>
        /// Método que obtiene el estado de la matricula
        /// </summary>
        /// <param name="idPersona">Número entero que representa el ID del atleta</param>
        /// <returns>un objeto de tipo  Matricula</returns>

        public Boolean obtenerEstado(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                BDMatricula baseDeDatosDetalleCompra = new BDMatricula();
                return baseDeDatosDetalleCompra.EstadoMatricula(idPersona);

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }


        /// <summary>
        /// Método que obtiene el monto pagado de la matricula por un atlteta
        /// </summary>
        /// <param name="idMatricula">Número entero que representa el ID de la matricula</param>
        /// <param name="idPersona">Número entero que representa el ID del atleta</param>
        /// <returns>un objeto de tipo Matricula</returns>
      
        public float obtenerMontoMatricula(int idPersona, int idMatricula)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                BDMatricula baseDeDatosDetalleCompra = new BDMatricula();
                return baseDeDatosDetalleCompra.montoPagoMatricula(idPersona, idMatricula);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }


        /// <summary>
        /// Método que obtiene el detalle de cada matricula por su ID
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID de la matricula</param>
        /// <returns>un objeto de tipo Matricula</returns>
      
        public DominioSKD.Matricula detalleMatriculaID(int idMatricula)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                BDMatricula baseDeDatosMatricula = new BDMatricula();
                return baseDeDatosMatricula.DetallarMatricula(idMatricula);
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }

        #endregion

    }
}