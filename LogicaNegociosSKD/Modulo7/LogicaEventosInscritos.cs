using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo7;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using DominioSKD.Entidades.Modulo9;


namespace LogicaNegociosSKD.Modulo7
{
    /// <summary>
    /// Clase para obtener la lista de eventos inscritos y el detalle de los mismos
    /// </summary>
    public class LogicaEventosInscritos
    {
        #region Atributos

        private List<Evento> laListaDeEventoInscrito;

       #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        #region Gets & Sets
         public List<Evento> LaListaDeEventoInscrito
        {
            get { return laListaDeEventoInscrito; }
            set { laListaDeEventoInscrito = value; }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
         public LogicaEventosInscritos()
         {
         }

         #region Métodos
      /// <summary>
      /// Metodo que devuelve la lista de competencias inscritas
      /// </summary>
      /// <param name="idPersona"></param>
      /// <returns>Lista de competencias</returns>
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
                    return baseDeDatosEvento.ListarCompetenciasInscritas(idPersona);
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
         /// Metodo que devuelve la lista de eventos inscritos
         /// </summary>
         /// <param name="idPersona"></param>
         /// <returns>Lista de eventos</returns>
         public List<Evento> obtenerListaDeEventos(int idPersona)
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
                    return baseDeDatosEvento.ListarEventosInscritos(idPersona);
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
        /// Método que devuelve el detalle del evento inscrito
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns>
        /// Objeto de tipo evento
        /// </returns>
         public Evento detalleEventoID(int idEvento)
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
        /// Metodo que devuelve detalle de competencia
        /// </summary>
        /// <param name="idCompetencia"></param>
        /// <returns></returns>
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
