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
    /// Clase para obtener la lista de cintas obtenidas y la descripción de una cinta
    /// </summary>
    public class LogicaCintas
    {
        #region Atributos
        private List<DominioSKD.Cinta> laListaDeCintas;
        #endregion

        #region Get y Set
        public List<DominioSKD.Cinta> LaListaDeCintas
        {
            get { return laListaDeCintas; }
            set { laListaDeCintas = value; }
        }
        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public LogicaCintas()
        {
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método que obtiene la lista de cintas de un atleta
        /// </summary>
        /// <returns>Lista de objetos tipo cinta</returns>
        public List<DominioSKD.Cinta> obtenerListaDeCintas(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                    BDCinta baseDeDatosCinta = new BDCinta();
                    return baseDeDatosCinta.ListarCintasObtenidas(idPersona);
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
        /// Método que obtiene el detalle de cada cinta por su ID
        /// </summary>
        /// <param name="idCinta">Número entero que representa el id de la cinta</param>
        /// <returns>Objeto de tipo Cinta</returns>
        public DominioSKD.Cinta detalleCintaID(int idCinta)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (idCinta.GetType() == Type.GetType("System.Int32") && idCinta > 0)
                {
                    BDCinta baseDeDatosCinta = new BDCinta();
                    return baseDeDatosCinta.DetallarCinta(idCinta);
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
        /// Método que obtiene la fecha de recibimiento de una cinta para una persona
        /// </summary>
        /// <param name="idPersona">Número entero que representa el ID de la persona</param>
        /// <param name="idEvento">Número entero que representa el ID de la cinta</param>
        /// <returns>DateTime con la fecha de inscripción</returns>
        public DateTime obtenerFechaCinta(int idPersona, int idCinta)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0 &&
                    idCinta.GetType() == Type.GetType("System.Int32") && idCinta > 0)
                {
                    BDCinta baseDeDatosCinta = new BDCinta();
                    return baseDeDatosCinta.fechaCinta(idPersona, idCinta);
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
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <param name="idCinta"></param>
        /// <returns></returns>
        public DominioSKD.Cinta obtenerUltimaCinta(int idPersona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   RecursosLogicaModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (idPersona.GetType() == Type.GetType("System.Int32") && idPersona > 0)
                {
                    BDCinta baseDeDatosCinta = new BDCinta();
                    return baseDeDatosCinta.UltimaCinta(idPersona);
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
