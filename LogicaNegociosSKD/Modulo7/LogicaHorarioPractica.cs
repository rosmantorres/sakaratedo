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
        /// Clase para obtener la lista de horario de clase y el detalle de los mismos
        /// </summary>
        public class LogicaHorarioPractica
        {
            #region Atributos

            private List<DominioSKD.Evento> laListaDeHorarioPractica;

                      #endregion

            /// <summary>
            /// Constructor
            /// </summary>
            #region Gets & Sets
            public List<DominioSKD.Evento> LaListaDeHorarioPractica
            {
                get { return laListaDeHorarioPractica; }
                set { laListaDeHorarioPractica = value; }
            }
            #endregion

            #region Metodos
            /// <summary>
            /// COnstructor
            /// </summary>
            public LogicaHorarioPractica()
            {
            }

            /// <summary>
            /// Metodo que obtiene la lista de horarios de practica
            /// </summary>
            /// <returns>
            /// Lista de objetos tipo Evento
            /// </returns>
            public List<DominioSKD.Evento> obtenerListaDePractica(int idPersona)
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
                    return baseDeDatosEvento.ListarHorarioPractica(idPersona);
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
            /// Metodo que devuelve el detalle del evento inscrito
            /// </summary>
            /// <param name="idEvento"></param>
            /// <returns>
            /// Objeto de tipo evento
            /// </returns>
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

            #endregion

        }
    }

