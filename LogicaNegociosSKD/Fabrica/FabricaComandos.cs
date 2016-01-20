using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegociosSKD.Comandos.Modulo3;
using LogicaNegociosSKD.Comandos.Modulo5;
using LogicaNegociosSKD.Comandos.Modulo15;

namespace LogicaNegociosSKD.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
		public EjecutarAgregarOrganizacion ObtenerEjecutarAgregarOrganizacion(Entidad nuevaEntidad)
        {
            return new EjecutarAgregarOrganizacion(nuevaEntidad);
        }
        public EjecutarModificarOrganizacion ObtenerEjecutarModificarOrganizacion(Entidad nuevaEntidad)
        {
            return new EjecutarModificarOrganizacion(nuevaEntidad);
        }
        public EjecutarConsultarXIdOrganizacion ObtenerEjecutarConsultarXIdOrganizacion(Entidad nuevaEntidad)
        {
            return new EjecutarConsultarXIdOrganizacion(nuevaEntidad);
        }
        public EjecutarConsultarTodosOrganizacion ObtenerEjecutarConsultarTodosOrganizacion()
        {
            return new EjecutarConsultarTodosOrganizacion();
        }
        public EjecutarComboOrganizaciones ObtenerEjecutarComboOrganizaciones()
        {
            return new EjecutarComboOrganizaciones();
        }
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
		 public EjecutarAgregarCinta ObtenerEjecutarAgregarCinta(Entidad nuevaEntidad)
        {
            return new EjecutarAgregarCinta(nuevaEntidad);
        }
        public EjecutarModificarCinta ObtenerEjecutarModificarCinta(Entidad nuevaEntidad)
        {
            return new EjecutarModificarCinta(nuevaEntidad);
        }
        public EjecutarConsultarXIdCinta ObtenerEjecutarConsultarXIdCinta(Entidad nuevaEntidad)
        {
            return new EjecutarConsultarXIdCinta(nuevaEntidad);
        }
        public EjecutarConsultarTodosCinta ObtenerEjecutarConsultarTodosCinta()
        {
            return new EjecutarConsultarTodosCinta();
        }
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
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
        public Comando<List<Entidad>> ObtenerComandoCompetenciasSolicitud()
        {
            return new ComandoCompetenciasSolicitud();
        }
        public Comando<List<Boolean>> ObtenerComandoDatosRequeridosSolicitud()
        {
            return new ComandoDatosRequeridosSolicitud();
        }
        public Comando<List<Entidad>> ObtenerComandoEventosSolicitud()
        {
            return new ComandoEventosSolicitud();
        }
        public Comando<Entidad> ObtenerComandoModificarPlanillaID()
        {
            return new ComandoModificarPlanillaID();
        }
        public Comando<Entidad> ObtenerComandoModificarPlanillaIDTipo()
        {
            return new ComandoModificarPlanillaIDTipo();
        }
        public Comando<Entidad> ObtenerComandoModificarSolicitudID()
        {
            return new ComandoModificarSolicitudID();
        }
        public Comando<Boolean> ObtenerComandoNuevoTipoPlanilla()
        {
            return new ComandoNuevoTipoPlanilla();
        }
        public Comando<List<String>> ObtenerComandoObtenerDatosBD()
        {
            return new ComandoObtenerDatosBD();
        }
        public Comando<List<String>> ObtenerComandoObtenerDatosPlanilla()
        {
            return new ComandoObtenerDatosPlanilla();
        }
        public Comando<Entidad> ObtenerComandoObtenerPlanillaID()
        {
            return new ComandoObtenerPlanillaID();
        }
        public Comando<Entidad> ObtenerComandoObtenerSolicitudID()
        {
            return new ComandoObtenerSolicitudID();
        }
        public Comando<List<Entidad>> ObtenerComandoObtenerTipoPlanilla()
        {
            return new ComandoObtenerTipoPlanilla();
        }
        public Comando<bool> ObtenerComandoRegistrarPlanilla()
        {
            return new ComandoRegistrarPlanilla();
        }
        public Comando<bool> ObtenerComandoRegistrarPlanillaTipo()
        {
            return new ComandoRegistrarPlanillaTipo();
        }
        public Comando<Boolean> ObtenerComandoRegistrarSolicitudIDPersona()
        {
            return new ComandoRegistrarSolicitudIDPersona();
        }
        public Comando<Boolean> ObtenerComandoRegistrarSolicitudPlanilla()
        {
            return new ComandoRegistrarSolicitudPlanilla();
        }

        public Comando<List<Entidad>> ObtenerComandoListarPlanillasSolicitadas()
        {
            return new ComandoListarPlanillasSolicitadas();
        }

        public Comando<List<Entidad>> ObtenerComandoConsultarPlanillasASolicitar()
        {
            return new ComandoConsultarPlanillasASolicitar();
        }

        public Comando<Boolean> ObtenerComandoEliminarSolicitud()
        {
            return new ComandoEliminarSolicitud();
        }

        public Comando<Boolean> ObtenerComandoAgregarDiseno()
        {
            return new ComandoAgregarDiseno();
        }

        public Comando<Entidad> ObtenerComandoConsultarDiseñoPuro()
        {
            return new ComandoConsultarDiseñoPuro();
        }

        public Comando<Boolean> ObtenerComandoModificarDiseno()
        {
            return new ComandoModificarDiseno();
        }

        public Comando<string> ObtenerComandoReemplazarElementos()
        {
            return new ComandoReemplazarElementos();
        }

        public Comando<Entidad> ObtenerComandoComandoConsultarDiseño()
        {
            return new ComandoConsultarDiseño();
        }
        #endregion

        #region Modulo 15
        public Comando <bool> ObtenerComandoAgregar()
        {
            return new ComandoAgregarImplemento();
        }

        public Comando<List<Entidad>> ObtenerComandoConsultar()
        {
            return new ComandoConsultarTodosImplementos();
        }

        public Comando<List<Entidad>> ObtenerComandoConsultar2()
        {
            return new ComandoConsultarTodosImplementos2();
        }

        public Comando<bool> ObtenerComandoEliminarImplemento()
        {
            return new ComandoEliminarImplemento();
        }

        public Comando<bool> ObtenerComandoModificarImplemento()
        {
            return new ComandoModificarImplemento();
        }

        public Comando<Entidad> ObtenerComandoImplementoXId()
        {
            return new ComandoImplementoXId();
        }

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
