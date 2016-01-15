using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7

        public Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>>> ObtenerComandoConsultarListaEventosAsistidos()
        {
            return new ComandoConsultarListaEventosAsistidos();
        }

        public Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>>> ObtenerComandoConsultarListaEventosPagos()
        {
            return new ComandoConsultarListaEventosPagos();
        }

        public Comando<Tuple<List<Entidad>, List<Boolean>, List<float>>> ObtenerComandoConsultarListaMatriculasPagas()
        {
            return new ComandoConsultarListaMatriculasPagas();
        }

        public Comando<Tuple<List<Entidad>, List<DateTime>>> ObtenerComandoConsultarListaCinta()
        {
            return new ComandoConsultarListaCinta();
        }
        public Comando<Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad>> ObtenerComandoConsultarPerfil()
        {
            return new ComandoConsultarPerfil();
        }
        public Comando<Entidad> ObtenerComandoConsultarDetallarCinta()
        {
            return new ComandoConsultarDetallarCinta();
        }
        public Comando<Entidad> ObtenerComandoConsultarDetallarEvento()
        {
            return new ComandoConsultarDetallarEvento();
        }
        public Comando<Entidad> ObtenerComandoConsultarDetallarMatricula()
        {
            return new ComandoConsultarDetallarMatricula();
        }
        public Comando<Entidad> ObtenerComandoConsultarDetallarCompetencia()
        {
            return new ComandoConsultarDetallarCompetencia();
        }
        #endregion

        #region Modulo 8
        #endregion

        #region Modulo 9
        #endregion

        #region Modulo 10
        #endregion

        #region Modulo 11
        #endregion

        #region Modulo 12
        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        #endregion

        #region Modulo 15
        #endregion

        #region Modulo 16
        /*
                /// <summary>
                /// Metodo de la fabrica que instancia el comando ComandoConsultarTodosEventos
                /// </summary>
                /// <returns>El ComandoConsultarTodosEventos</returns>
                public static Comando<List<Entidad>> CrearComandoConsultarTodosEventos()
                {
                    return new ComandoConsultarTodosEventos();
                }

                /// <summary>
                /// Metodo de la fabrica que instancia el comando ComandoAgregarItem Vacio
                /// </summary>
                /// <returns>El ComandoAgregarItem vacio</returns>
                public static Comando<bool> CrearComandoAgregarItem()
                {
                    return new ComandoAgregarItem();
                }

                /// <summary>
                /// Metodo de la fabrica que instancia el ComandoAgregarItem con sus datos llenos
                /// </summary>
                /// <param name="persona">La persona a la que se le agregara al carrito</param>
                /// <param name="objeto">el item que se agregara al carrito de la persona</param>
                /// <param name="tipoObjeto">Indica a que tipo de item nos estamos refiriendo para Agregar</param>
                /// <param name="cantidad">la cantidad que se esta agregando del objeto</param>
                /// <returns>El ComandoAgregarItem con sus datos llenos</returns>
                public static Comando<bool> CrearComandoAgregarItem(Entidad persona, Entidad objeto, int tipoObjeto
                    , int cantidad)
                {
                    return new ComandoAgregarItem(persona, objeto, tipoObjeto, cantidad);
                }

                /// <summary>
                /// Metodo de la fabrica que instancia el comando ComandoRegistrarPago Vacio
                /// </summary>
                /// <returns>El ComandoRegistrarPago vacio</returns>
                public static Comando<bool> CrearComandoRegistrarPago()
                {
                    return new ComandoRegistrarPago();
                }

                /// <summary>
                /// Metodo de la fabrica que instancia el ComandoRegistraPago con sus datos llenos
                /// </summary>
                /// <param name="persona">La persona a la cual se le adjudicara la transaccion</param>
                /// <param name="tipoPago">el tipo de pago que la persona realizo</param>
                /// <returns>El ComandoRegistrarPago con sus datos llenos</returns>
                public static Comando<bool> CrearComandoRegistrarPago(Entidad persona, String tipoPago)
                {
                    return new ComandoRegistrarPago(persona, tipoPago);
                }

                /// <summary>
                /// Metodo de la fabrica que instancia el comando ComandoModificarCarrito Vacio
                /// </summary>
                /// <returns>El ComandoModificarCarrito vacio</returns>
                public static Comando<bool> CrearComandoModificarCarrito()
                {
                    return new ComandoModificarCarrito();
                }

                /// <summary>
                /// Metodo de la fabrica que instancia el ComandoModficiarCarrito con sus datos llenos
                /// </summary>
                /// <param name="persona">La persona a la que se le modificara el carrito</param>
                /// <param name="objeto">el item que se modificara al carrito de la persona</param>
                /// <param name="tipoObjeto">Indica a que tipo de item nos estamos refiriendo para Modificar</param>
                /// <param name="cantidad">la cantidad nueva que se quiere del objeto</param>
                /// <returns>El ComandoModificarCarrito con sus datos llenos</returns>
                public static Comando<bool> CrearComandoModificarCarrito(Entidad persona, Entidad objeto, int tipoObjeto
                    , int cantidad)
                {
                    return new ComandoModificarCarrito(persona, objeto, tipoObjeto, cantidad);
                }

                public static Comando<bool> CrearComandoeliminarItem()
                {
                    return new ComandoeliminarItem();
                }
        */
        #endregion


    }
}
