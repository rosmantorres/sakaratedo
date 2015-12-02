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
    /// Clase para obtener la lista de eventos pagados de los atletas y la descripción de un evento
    /// </summary>
    public class LogicaEventosPagos
    {
        #region Atributos
        private List<DominioSKD.Evento> laListaDeEventos;
        #endregion

        #region Get y Set
        public List<DominioSKD.Evento> LaListaDeEventos
        {
            get { return laListaDeEventos; }
            set { laListaDeEventos = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor
        /// </summary>
        public LogicaEventosPagos()
        {
        }

        /// <summary>
        /// Método que obtiene la lista de eventos asistidos
        /// </summary>
        /// <returns>Lista de objetos tipo Evento</returns>
        public List<DominioSKD.Evento> obtenerListaDeEventos(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                BDEvento baseDeDatosEvento = new BDEvento();
                return baseDeDatosEvento.ListarEventosPagos(idPersona);
                 }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }
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
        /// Método que obtiene la lista de competencias asistidas
        /// </summary>
        /// <returns>Lista de objetos tipo Competencia</returns>
        public List<DominioSKD.Competencia> obtenerListaDeCompetencias(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                  if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                    BDEvento baseDeDatosEvento = new BDEvento();
                    return baseDeDatosEvento.ListarCompetenciasPagas(idPersona);
                }
                  else
                  {
                      throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                  RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                  }
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
        /// Método que obtiene el detalle de cada evento por su ID
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID del evento</param>
        /// <returns>Objeto de tipo Evento</returns>
        public DominioSKD.Evento detalleEventoID(int idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                 if (idEvento.GetType() == Type.GetType("System.Int32") && idEvento > 0)
                {
                    BDEvento baseDeDatosEvento = new BDEvento();
                    return baseDeDatosEvento.DetallarEvento(idEvento);
                   
                }
                 else
                 {
                     throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                 RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                 }
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
        /// Método que obtiene el detalle de cada competencia paga por su ID
        /// </summary>
        /// <param name="idCompetencia">Número entero que representa el ID de la competencia</param>
        /// <returns>Objeto de tipo Competencia</returns>
        public DominioSKD.Competencia detalleCompetenciaPagaID(int idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                 if (idCompetencia.GetType() == Type.GetType("System.Int32") && idCompetencia > 0)
                {
                    BDCompetencia baseDeDatosCompetencia = new BDCompetencia();
                    return baseDeDatosCompetencia.DetallarCompetencia(idCompetencia);
                }
                 else
                 {
                     throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                 RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                 }
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
        /// Método que obtiene la fecha de pago de cada competencia paga por su ID
        /// </summary>
        /// <param name="idCompetencia">Número entero que representa el ID de la competencia</param>
        /// <param name="idPersona">Número entero que representa el ID de la Persona</param>
        /// <returns>Objeto de tipo Competencia</returns>
        public DateTime obtenerFechaInscripcioncompetencia(int idPersona, int idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                 if ((idCompetencia.GetType() == Type.GetType("System.Int32") && idCompetencia > 0 ) && (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0 ))
                {
                     BDEvento baseDeDatosEvento = new BDEvento();
                     return baseDeDatosEvento.fechaInscripcionCompetencia(idPersona, idCompetencia);
                    
                }
                 else
                 {
                     throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                 RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                 }
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
        /// Método que obtiene el monto pagado por un atleta de un evento
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID del evento</param>
        /// <param name="idPersona">Número entero que representa el ID del atleta</param>
        /// <returns>un objeto de tipo Matricula</returns>

        public float obtenerMontoEvento(int idPersona, int idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                   if ((idEvento.GetType() == Type.GetType("System.Int32") && idEvento > 0 ) && (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0 ))
                {
                     BDEvento baseDeDatosDetalleCompra = new BDEvento();
                     return baseDeDatosDetalleCompra.montoPagoEvento(idPersona, idEvento);
                }
                   else
                   {
                       throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                   RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                   }
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
        /// Método que obtiene la fecha de pago de  en un evento
        /// </summary>
        /// <param name="idPersona">Número entero que representa el ID de la persona</param>
        /// <param name="idEvento">Número entero que representa el ID del evento</param>
        /// <returns>DateTime con la fecha de inscripción</returns>
        public DateTime obtenerFechaPagoEvento(int idPersona, int idEvento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if ((idEvento.GetType() == Type.GetType("System.Int32") && idEvento > 0) && (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0))
                {
                     BDEvento baseDeDatosEvento = new BDEvento();
                     return baseDeDatosEvento.fechaPagoEvento(idPersona, idEvento);
                 }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }
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
        /// Método que obtiene el detalle de cada competencia por su ID
        /// </summary>
        /// <param name="idCompetencia">Número entero que representa el ID de la competencia</param>
        /// <returns>Objeto de tipo Competencia</returns>
        public DominioSKD.Competencia detalleCompetenciaID(int idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (idCompetencia.GetType() == Type.GetType("System.Int32") && idCompetencia > 0)
                {
                  BDCompetencia baseDeDatosCompetencia = new BDCompetencia();
                  return baseDeDatosCompetencia.DetallarCompetencia(idCompetencia);
                 }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosLogicaModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosLogicaModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }
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

