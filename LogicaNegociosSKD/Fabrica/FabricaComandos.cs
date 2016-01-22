﻿using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegociosSKD.Comandos.Modulo16;
using LogicaNegociosSKD.Comandos.Modulo3;
using LogicaNegociosSKD.Comandos.Modulo5;
using LogicaNegociosSKD.Comandos.Modulo12;
using LogicaNegociosSKD.Comandos.Modulo10;
using LogicaNegociosSKD.Comandos.Modulo11;

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
        public static Comando<List<Entidad>> ObtenerComandoListarEventosAsistidos()
        {
            return new ComandoListarEventosAsistidos();
        }

        public static Comando<List<Entidad>> ObtenerComandoListarCompetenciasAsistidas()
        {
            return new ComandoListarCompetenciasAsistidas();
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAsistentesEvento(string idEvento)
        {
            return new ComandoListaAsistentesEvento(idEvento);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaNoAsistentesEvento(string idEvento)
        {
            return new ComandoListaNoAsistentesEvento(idEvento);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAsistentesCompetencia(string idCompetencia)
        {
            return new ComandoListaAsistentesCompetencia(idCompetencia);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaNoAsistentesCompetencia(string idCompetencia)
        {
            return new ComandoListaNoAsistentesCompetencia(idCompetencia);
        }

        public static Comando<bool> ObtenerComandoModificarAsistenciaEvento(List<Entidad> lista)
        {
            return new ComandoModificarAsistenciaEvento(lista);
        }

        public static Comando<Entidad> ObtenerComandoConsultarCompetenciasXId(string idCompetencia)
        {
            return new ComandoConsultarCompetenciasXId(idCompetencia);
        }

        public static Comando<bool> ObtenerComandoModificarAsistenciaCompetencia(List<Entidad> lista)
        {
            return new ComandoModificarAsistenciaCompetencia(lista);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAtletasInscritosEvento(string idEvento)
        {
            return new ComandoListaAtletasInscritosEvento(idEvento);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaInasistentesPlanillaEvento(string idEvento)
        {
            return new ComandoListaInasistentesPlanilla(idEvento);
        }

        public static Comando<bool> ObtenerComandoAgregarAsistenciaEvento(List<Entidad> listaEntidad)
        {
            return new ComandoAgregarAsistenciaEvento(listaEntidad);
        }

        public static Comando<bool> ObtenerComandoAgregarAsistenciaCompetencia(List<Entidad> listaEntidad)
        {
            return new ComandoAgregarAsistenciaCompetencia(listaEntidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoListarHorariosCompetencia()
        {
            return new ComandoListarHorariosCompetencia();
        }

        public static Comando<List<Entidad>> ObtenerComandoCompetenciasPorFecha(string fechaInicio)
        {
            return new ComandoCompetenciasPorFecha(fechaInicio);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAtletasInscritosCompetencia(string idCompetencia)
        {
            return new ComandoListaAtletasInscritosCompetencia(idCompetencia);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaInasistentesPlanillaCompetencia(string idCompetencia)
        {
            return new ComandoListaInasistentesPlanillaCompetencia(idCompetencia);
        }

        public static Comando<Entidad> ObtenerComandoConsultarCompetenciaXIdDetalle(string idCompetencia)
        {
            return new ComandoConsultarCompetenciaXIdDetalle(idCompetencia);
        }
        #endregion

        #region Modulo 11
        public static Comando<List<Entidad>> ObtenerComandoListarResultadosEventosPasados()
        {
            return new ComandoListarResultadosEventosPasados();
        }

        public static Comando<List<Entidad>> ObtenerComandoListaCategoriaEvento(string idEvento)
        {
            return new ComandoListaCategoriaEvento(idEvento);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAtletasEnCategoriaYAscenso(Entidad entidad)
        {
            return new ComandoListaAtletasEnCategoriaYAscenso(entidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaInscritosExamenAscenso(Entidad entidad)
        {
            return new ComandoListaInscritosExamenAscenso(entidad);
        }

        public static Comando<Entidad> ObtenerComandoConsultarEventoDetalle(string idEvento)
        {
            return new ComandoConsultarEventoDetalle(idEvento);
        }

        public static Comando<bool> ObtenerComandoAgregarResultadoAscenso(List<Entidad> listaEntidad)
        {
            return new ComandoAgregarResultadoAscenso(listaEntidad);
        }

        public static Comando<bool> ObtenerComandoModificarResultadoAscenso(List<Entidad> listaEntidad)
        {
            return new ComandoModificarResultadoAscenso(listaEntidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoListarResultadosCompetenciasPasado()
        {
            return new ComandoListarResultadosCompetenciaPasado();
        }

        public static Comando<List<string>> ObtenerComandoListaEspecialidadesCompetencia(string idCompetencia)
        {
            return new ComandoListaEspecialidadesCompetencia(idCompetencia);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaCategoriaCompetencia(Entidad entidad)
        {
            return new ComandoListaCategoriaCompetencia(entidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAtletasParticipanCompetenciaKata(Entidad entidad)
        {
            return new ComandoListaAtletasParticipanCompetenciaKata(entidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAtletasParticipanCompetenciaKataAmbos(Entidad entidad)
        {
            return new ComandoListaAtletasParticipanCompetenciaKataAmbos(entidad);
        }

        public static Comando<bool> ObtenerComandoAgregarResultadoKata(List<Entidad> listaEntidad)
        {
            return new ComandoAgregarResultadoKata(listaEntidad);
        }

        public static Comando<bool> ObtenerComandoModificarResultadoKata(List<Entidad> listaEntidad)
        {
            return new ComandoModificarResultadoKata(listaEntidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAtletasParticipanCompetenciaKumite(Entidad entidad)
        {
            return new ComandoListaAtletasParticipanCompetenciaKumite(entidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaAtletasParticipanCompetenciaKumiteAmbos(Entidad entidad)
        {
            return new ComandoListaAtletasParticipanCompetenciaKumiteAmbos(entidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoListaInscritosCompetencia(Entidad entidad)
        {
            return new ComandoListaInscritosCompetencia(entidad);
        }

        public static Comando<bool> ObtenerComandoAgregarResultadoKumite(List<Entidad> listaEntidad)
        {
            return new ComandoAgregarResultadoKumite(listaEntidad);
        }

        public static Comando<bool> ObtenerComandoModificarResultadoKumite(List<Entidad> listaEntidad)
        {
            return new ComandoModificarResultadoKumite(listaEntidad);
        }
        #endregion

        #region Modulo 12

        public Comando<List<Entidad>> ObtenerComandoConsultarCompetencias()
        {
            return new ComandoConsultarTodosCompetencia();
        }

        public Comando<Entidad> ObtenerComandoDetallarCompetencia(Entidad paramEntidad)
        {
            return new ComandoConsultarXIdCompetencia(paramEntidad);
        }

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

        public Comando<List<Entidad>> ObtenerComandConsultarPlanillas()
        {
            return new ComandoConsultarPlanillas();
        }
        #endregion

        #region Modulo 15
        #endregion

        #region Modulo 16

        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoConsultarTodosEventos
        /// </summary>
        /// <returns>El ComandoConsultarTodosEventos</returns>
        public static Comando <Entidad> CrearComandoConsultarTodosEventos()
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
        /// <param name="pago">el pago que la persona realiza</param>
        /// <returns>El ComandoRegistrarPago con sus datos llenos</returns>
        public static Comando<bool> CrearComandoRegistrarPago(Entidad persona, Entidad pago)
        {
            return new ComandoRegistrarPago(persona, pago);
        }

        /*/// <summary>
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
        }*/

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

        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoVerCarrito Vacio
        /// </summary>
        /// <returns>El ComandoModificarCarrito vacio</returns>
        public static Comando<Entidad> CrearComandoVerCarrito()
        {
            return new ComandoVerCarrito();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el ComandoVerCarrito con sus datos llenos
        /// </summary>
        /// <param name="persona">La persona a la que se le desea ver sus datos</param>
        /// <returns>El carrito con todos los items de la persona</returns>
        public static Comando<Entidad> CrearComandoVerCarrito(Entidad persona)
        {
            return new ComandoVerCarrito(persona);
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoCeliminarItem que no recibe parámetros
        /// </summary>
        /// <returns>El ComandoeliminarItem</returns>
        public static  Comando<bool> CrearComandoeliminarItem()
                {
                    return new ComandoeliminarItem();
                }

        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoCeliminarItem que recibe parámetros
        /// </summary>
        /// <param name="tipoObjeto">tipo de objeto que se refiere al eliminar en el carrito</param>
        /// <param name="objetoaBorrar">el objeto que se va a borrar en el carrito</param>
        /// <param name="usuario">usuario que esta asociado al carrito</param>
        /// <returns>El ComandoeliminarItem</returns>
        public static Comando<bool> CrearComandoeliminarItem(int tipoObjeto, Entidad objetoaBorrar, Entidad usuario)
        {
            return new ComandoeliminarItem(tipoObjeto, objetoaBorrar, usuario);
        }
        
        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoConsultarTodosProductos
        /// </summary>
        /// <returns>El ComandoConsultarTodosProductos</returns>
        public static Comando<Entidad> CrearComandoConsultarTodosProductos()
        {
            return new ComandoConsultarTodosProductos();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoConsultarTodasFacturas
        /// </summary>
        /// <returns>El ComandoConsultarTodasFacturas</returns>
        public static Comando<Entidad> CrearComandoConsultarTodasFacturas()
        {
            return new ComandoConsultarTodasFacturas();
        }            

        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoConsultarTodasMensualidades
        /// </summary>
        /// <returns>El ComandoConsultarTodasMensualidades</returns>
        public static Comando<Entidad> CrearComandoConsultarTodasMensualidades()
        {
            return new ComandoConsultarTodasMensualidades();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el comando CrearComandDetallarEvento
        /// </summary>
        /// <returns>El CrearComandDetallarEvento</returns>
        public static Comando<Entidad> CrearComandoDetallarEvento(Entidad evento)
        {
            return new ComandoDetallarEvento(evento);
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el comando CrearComandoDetallarEvento
        /// </summary>
        /// <returns>El CrearComandoDetallarEvento</returns>
        public static Comando<Entidad> CrearComandoDetallarMatricula(Entidad matricula)
        {
            return new ComandoDetallarMatricula(matricula);
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el comando CrearComandoDetallarProducto
        /// </summary>
        /// <returns>El CrearComandDetallarEvento</returns>
        public static Comando<Entidad> CrearComandoDetallarProducto(Entidad implemento)
        {
            return new ComandoDetallarProducto(implemento);
        }
        #endregion


    }
}
