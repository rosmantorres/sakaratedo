using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo7;

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
                try
                {
                    BDEvento baseDeDatosEvento = new BDEvento();
                    return baseDeDatosEvento.ListarHorarioPractica(idPersona);
                }
                catch (Exception e)
                {
                    throw e;
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
                try
                {
                    BDEvento baseDeDatosEvento = new BDEvento();
                    return baseDeDatosEvento.DetallarEvento(idEvento);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            #endregion

        }
    }

