﻿using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo7;
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
using LogicaNegociosSKD.Comandos.Modulo15;
using LogicaNegociosSKD.Comandos.Modulo10;
using LogicaNegociosSKD.Comandos.Modulo11;
using LogicaNegociosSKD.Comandos.Modulo9;
using LogicaNegociosSKD.Comandos.Modulo4;

namespace LogicaNegociosSKD.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1
        public Comando<String> ObtenerConsultarCorreo()
        {
            return new Comandos.Modulo1.ComandoConsultarCorreo();
        }
        public Comando<Boolean> ObtenerEnviarCorreo()
        {
            return new Comandos.Modulo1.ComandoEnviarCorreo();
        }
        public Comando<String[]> ObtenerIniciarSesion()
        {
            return new Comandos.Modulo1.ComandoIniciarSesion();
        }
        public Comando<Boolean> ObtenerRestablecerContraseña()
        {
            return new Comandos.Modulo1.ComandoRestablecerContraseña();
        }
        #endregion

        #region Modulo 2
        public Comando<Boolean> ObtenerAgregarRol()
        {
            return new Comandos.Modulo2.ComandoAgregarRol();
        }
        public Comando<Entidad> ObtenerCuentaUsuario()
        {
            return new Comandos.Modulo2.ComandoCuentaUsuario();
        }
        public Comando<Boolean> ObtenerEliminarRol()
        {
            return new Comandos.Modulo2.ComandoEliminarRol();
        }
        public Comando<List<DominioSKD.Entidades.Modulo2.Rol>> ObtenerRolesDeSistema()
        {
            return new Comandos.Modulo2.ComandoRolesDeSistema();
        }
        public Comando<List<DominioSKD.Entidades.Modulo2.Rol>> ObtenerRolesUsuario()
        {
            return new Comandos.Modulo2.ComandoRolesUsuario();
        }
        #endregion

        #region Modulo 3
        public static Comando<bool> ObtenerEjecutarAgregarOrganizacion(Entidad nuevaEntidad)
        {
            return new EjecutarAgregarOrganizacion(nuevaEntidad);
        }
        public static Comando<bool> ObtenerEjecutarModificarOrganizacion(Entidad nuevaEntidad)
        {
            return new EjecutarModificarOrganizacion(nuevaEntidad);
        }
        public static Comando<Entidad> ObtenerEjecutarConsultarXIdOrganizacion(Entidad nuevaEntidad)
        {
            return new EjecutarConsultarXIdOrganizacion(nuevaEntidad);
        }
        public static Comando<List<Entidad>> ObtenerEjecutarConsultarTodosOrganizacion()
        {
            return new EjecutarConsultarTodosOrganizacion();
        }
        public static Comando<List<Entidad>> ObtenerEjecutarComboOrganizaciones()
        {
            return new EjecutarComboOrganizaciones();
        }
        public static Comando<bool> ObtenerEjecutarModificarStatusOrganizacion(Entidad nuevaEntidad)
        {
            return new EjecutarModificarStatusOrganizacion(nuevaEntidad);
        }
        #endregion

        #region Modulo 4
        /// <summary>
        /// Instancia comando para Agregar Dojo
        /// </summary>
        /// <returns>True o False</returns>
        public static Comando<bool> CrearComandoAgregarDojo()
        {
            return new ComandoAgregarDojo();
        }

        /// <summary>
        /// Instancia comando para Listar Dojo
        /// </summary>
        /// <returns>Lista de Dojos</returns>
        public static Comando<List<Entidad>> CrearComandoListarDojos()
        {
            return new ComandoListarDojos();
        }

        /// <summary>
        /// Instancia comando para Eliminar Dojo
        /// </summary>
        /// <returns>True o False</returns>
        public static Comando<bool> CrearComandoEliminarDojo()
        {
            return new ComandoEliminarDojo();
        }

        /// <summary>
        /// Instancia comando para Detallar Dojo
        /// </summary>
        /// <returns>Dojo</returns>
        public static Comando<Entidad> CrearComandoDetallarDojo()
        {
            return new ComandoDetallarDojo();
        }

        /// <summary>
        /// Instancia comando para Modificar Dojo
        /// </summary>
        /// <returns>True o False</returns>
        public static Comando<bool> CrearComandoModificarDojo()
        {
            return new ComandoModificarDojo();
        }
        /// <summary>
        /// Instancia comando para Agregar Historial Matricula
        /// </summary>
        /// <returns>True o False</returns>
        public static Comando<bool> CrearComandoAgregaHistorialM()
        {
            return new ComandoAgregarHistorialM();
        }

        /// <summary>
        /// Instancia comando para Listar Historial Matricula
        /// </summary>
        /// <returns>Lista de Historial Matricula</returns>
        public static Comando<List<Entidad>> CrearComandoListarHistorialM()
        {
            return new ComandoListarHistorialM();
        }

        /// <summary>
        /// Instancia comando para Eliminar Historial Matricula
        /// </summary>
        /// <returns>True o False</returns>
        public static Comando<bool> CrearComandoEliminarHistorialM()
        {
            return new ComandoEliminarHistorialM();
        }

        /// <summary>
        /// Instancia comando para Detallar Historial Matricula
        /// </summary>
        /// <returns>Historial Matricula</returns>
        public static Comando<Entidad> CrearComandoDetallarHistorialM()
        {
            return new ComandoDetallarHistorialM();
        }

        /// <summary>
        /// Instancia comando para Modificar Historial Matricula
        /// </summary>
        /// <returns>True o False</returns>
        public static Comando<bool> CrearComandoModificarHistorialM()
        {
            return new ComandoModificarHistorialM();
        }
        #endregion

        #region Modulo 5
        public static Comando<bool> ObtenerEjecutarAgregarCinta(Entidad nuevaEntidad)
        {
            return new EjecutarAgregarCinta(nuevaEntidad);
        }
        public static Comando<bool> ObtenerEjecutarModificarCinta(Entidad nuevaEntidad)
        {
            return new EjecutarModificarCinta(nuevaEntidad);
        }
        public static Comando<Entidad> ObtenerEjecutarConsultarXIdCinta(Entidad nuevaEntidad)
        {
            return new EjecutarConsultarXIdCinta(nuevaEntidad);
        }
        public static Comando<List<Entidad>> ObtenerEjecutarConsultarTodosCinta()
        {
            return new EjecutarConsultarTodosCinta();
        }
        public static Comando<List<Entidad>> ObtenerEjecutarConsultarCintaXOrganizacion(Entidad nuevaEntidad)
        {
            return new EjecutarConsultarCintasXOrganizacion(nuevaEntidad);
        }
        public static Comando<bool> ObtenerEjecutarModificarStatusCinta(Entidad nuevaEntidad)
        {
            return new EjecutarModificarStatusCinta(nuevaEntidad);
        }
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7

        public static Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>>> ObtenerComandoConsultarListaEventosInscritos()
        {
            return new ComandoConsultarListaEventosInscritos();
        }
        public static Comando<Tuple<List<Entidad>>> ObtenerComandoConsultarListaHorarioPractica()
        {
            return new ComandoConsultarListaHorarioPractica();
        }
        public static Comando<Entidad> ObtenerComandoConsultarDetallarHorarioPractica()
        {
            return new ComandoConsultarDetallarHorarioPractica();
        }
        public static Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<DateTime>>> ObtenerComandoConsultarListaEventosAsistidos()
        {
            return new ComandoConsultarListaEventosAsistidos();
        }

        public static Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>>> ObtenerComandoConsultarListaEventosPagos()
        {
            return new ComandoConsultarListaEventosPagos();
        }

        public static Comando<Tuple<List<Entidad>, List<Boolean>, List<float>>> ObtenerComandoConsultarListaMatriculasPagas()
        {
            return new ComandoConsultarListaMatriculasPagas();
        }

        public static Comando<Tuple<List<Entidad>, List<DateTime>>> ObtenerComandoConsultarListaCinta()
        {
            return new ComandoConsultarListaCinta();
        }
        public static Comando<Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad>> ObtenerComandoConsultarPerfil()
        {
            return new ComandoConsultarPerfil();
        }
        public static Comando<Tuple<Entidad, DateTime>> ObtenerComandoConsultarDetallarCinta()
        {
            return new ComandoConsultarDetallarCinta();
        }
        public static Comando<Entidad> ObtenerComandoConsultarDetallarEvento()
        {
            return new ComandoConsultarDetallarEvento();
        }

        public static Comando<Entidad> ObtenerComandoConsultarDetallarEventoPago()
        {
            return new ComandoConsultarDetallarEvento();
        }
        public static Comando<Entidad> ObtenerComandoConsultarDetallarMatricula()
        {
            return new ComandoConsultarDetallarMatricula();
        }
        public static Comando<Entidad> ObtenerComandoConsultarDetallarCompetencia()
        {
            return new ComandoConsultarDetallarCompetencia();
        }
        #endregion

        #region Modulo 8

        #region Comandos Restriccion Competencia
        public static Comando<Boolean> CrearComandoAgregarRestriccionCompetencia()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCompetencia();
        }
        public static Comando<Boolean> CrearComandoAgregarListaCompetenciaRestriccionCompetencia()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarListaCompetenciaRestriccionCompetencia();
        }
        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarCompetencias()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCompetencias();
        }
        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarTodasLasCompetenciasAsociadas()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarTodasLasCompetenciasAsociadas();
        }
        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarTodasLasCompetenciasNoAsociadas()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarTodasLasCompetenciasNoAsociadas();
        }
        public static Comando<Boolean> CrearComandoEliminarListaCompetenciaRestriccionCompetencia()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarListaCompetenciaRestriccionCompetencia();
        }

        public static Comando<Boolean> CrearComandoModificarRestriccionCompetencia()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionCompetencia();
        }

        public static Comando<List<Entidad>> CrearComandoConsultarTodosRestriccionCompetencia()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarTodosRestriccionCompetencia();
        }

        public Comando<Boolean> CrearComandoEliminarLogicoRestriccionCompetencia(Entidad laRestCompetencia)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarLogicoRestriccionCompetencia(laRestCompetencia);
        }

        #endregion

        #region Comandos Restriccion Avance de Cinta
        public static Comando<Boolean> CrearComandoAgregarRestriccionCinta(Entidad laRestCinta)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCinta(laRestCinta);
        }

        /*public static Comando<Boolean> CrearComandoAgregarRestriccionCintaSimple(Entidad laRestCinta)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCintaSimple(laRestCinta);
        }*/

        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarRestriccionCinta()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarRestriccionCinta();
        }

        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarCintaTodas()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCintaTodas();
        }

        public static Comando<Boolean> CrearComandoModificarRestriccionCinta(Entidad laRestCinta)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionCinta(laRestCinta);
        }

        public static Comando<Boolean> CrearComandoStatusRestriccionCinta(Entidad laRestCinta)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarStatusCinta(laRestCinta);
        }

        #endregion

        #region Restriccion Evento
        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarEventosSinRestriccion()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarEventosSinRestriccion();
        }

        public static Comando<Boolean> CrearComandoAgregarRestriccionEvento(Entidad laRestEvento)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionEvento(laRestEvento);
        }

        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarRestriccionEvento()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarRestriccionEvento();
        }
        
        public static Comando<Boolean> CrearComandoModificarRestriccionEvento(Entidad laRestEvento)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionEvento(laRestEvento);
        }

        public static Comando<Boolean> CrearComandoEliminarRestriccionEvento(Entidad laRestEvento)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarRestriccionEvento(laRestEvento);
        }

        public static Comando<DominioSKD.Entidad> CrearComandoConsultarUnaRestriccionEvento(Entidad elEvento)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarUnaRestriccionEvento(elEvento);
        }

        public static Comando<List<DominioSKD.Entidad>> CrearComandoEventosQuePuedeParticiparAtleta(Entidad laPersona)
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoEventosQuePuedeParticiparAtleta(laPersona);
        }
        #endregion
        
        #endregion

        #region Modulo 9
        public static Comando<bool> ObtenerComandoAgregarEvento(Entidad laEntidad)
        {
            return new ComandoAgregarEvento(laEntidad);
        }

        public static Comando<bool> ObtenerComandoAgregarEventoConTipo(Entidad laEntidad)
        {
            return new ComandoAgregarEventoConTipo(laEntidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoConsultarListaEventos(Entidad laEntidad)
        {
            return new ComandoConsultarListaEventos(laEntidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoConsultarTipoEventos()
        {
            return new ComandoConsultarListaTipoEventos();
        }

        public static Comando<Entidad> ObtenerComandoConsultarEvento(Entidad laEntidad)
        {
            return new ComandoConsultarEvento(laEntidad);
        }

        public static Comando<bool> ObtenerComandoModificarEvento(Entidad laEntidad)
        {
            return new ComandoModificarEvento(laEntidad);
        }

        public static Comando<bool> ObtenerComandoModificarEventoConTipo(Entidad laEntidad)
        {
            return new ComandoModificarEventoConTipo(laEntidad);
        }

        #region Comando para Eventos por restricciones
        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoConsultarTodosEventos
        /// </summary>
        /// <returns>El ComandoConsultarTodosEventos</returns>
        public static Comando<Entidad> CrearComandoConsultarTodosEventos()
        {
            return new ComandoConsultarTodosEventos();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el comando CrearComandDetallarEvento
        /// </summary>
        /// <returns>El CrearComandDetallarEvento</returns>
        public static Comando<Entidad> CrearComandoDetallarEvento(Entidad evento)
        {
            return new ComandoDetallarEvento(evento);
        }

        #endregion

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

        public static Comando<Entidad> ObtenerComandoConsultarEventoM10XId(string idEvento)
        {
            return new ComandoConsultarEventoM10XId(idEvento);
        }

        public static Comando<List<Entidad>> ObtenerComandoTodasLasFechasEventoM10()
        {
            return new ComandoConsultarTodasLasFechasDeUnEventoM10();
        }

        public static Comando<List<Entidad>> ObtenerComandoEventosPorRangosdeFechaM10(string fechaInicio)
        {
            return new ComandoEventosPorRangosdeFechaM10(fechaInicio);
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

        public static Comando<List<Entidad>> ObtenerComandoTodasLasFechasAscensosM10()
        {
            return new ComandoTodasLasFechasEventoAscensoM10();
        }

        public static Comando<List<Entidad>> ObtenerComandoAscensosPorFechaM10(string fecha)
        {
            return new ComandoAscensosPorFechaM10(fecha);
        }
        #endregion

        #region Modulo 12

        public static Comando<List<Entidad>> ObtenerComandoConsultarCompetencias()
        {
            return new ComandoConsultarTodosCompetencia();
        }

        public static Comando<Entidad> ObtenerComandoDetallarCompetencia(Entidad paramEntidad)
        {
            return new ComandoConsultarXIdCompetencia(paramEntidad);
        }

        public static Comando<bool> ObtenerComandoAgregarCompetencia(Entidad paramEntidad)
        {
            return new ComandoAgregarCompetencia(paramEntidad);
        }

        public static Comando<bool> ObtenerComandoModificarCompetencia(Entidad paramEntidad)
        {
            return new ComandoModificarCompetencia(paramEntidad);
        }

        public static Comando<List<Entidad>> ObtenerComandoConsultarOrgazaniciones()
        {
            return new ComandoConsultarOrganizaciones();
        }

        public static Comando<List<Entidad>> ObtenerComandoConsultarCintas()
        {
            return new ComandoConsultarCintas();
        }

        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        public static Comando<List<Entidad>> ObtenerComandoCompetenciasSolicitud()
        {
            return new ComandoCompetenciasSolicitud();
        }
        public static Comando<List<Boolean>> ObtenerComandoDatosRequeridosSolicitud()
        {
            return new ComandoDatosRequeridosSolicitud();
        }
        public static Comando<List<Entidad>> ObtenerComandoEventosSolicitud()
        {
            return new ComandoEventosSolicitud();
        }
        public static Comando<Entidad> ObtenerComandoModificarPlanillaID()
        {
            return new ComandoModificarPlanillaID();
        }
        public static Comando<Entidad> ObtenerComandoModificarPlanillaIDTipo()
        {
            return new ComandoModificarPlanillaIDTipo();
        }
        public static Comando<Entidad> ObtenerComandoModificarSolicitudID()
        {
            return new ComandoModificarSolicitudID();
        }
        public static Comando<Boolean> ObtenerComandoNuevoTipoPlanilla()
        {
            return new ComandoNuevoTipoPlanilla();
        }
        public static Comando<List<String>> ObtenerComandoObtenerDatosBD()
        {
            return new ComandoObtenerDatosBD();
        }
        public static Comando<List<String>> ObtenerComandoObtenerDatosPlanilla()
        {
            return new ComandoObtenerDatosPlanilla();
        }
        public static Comando<Entidad> ObtenerComandoObtenerPlanillaID()
        {
            return new ComandoObtenerPlanillaID();
        }
        public static Comando<Entidad> ObtenerComandoObtenerSolicitudID()
        {
            return new ComandoObtenerSolicitudID();
        }
        public static Comando<List<Entidad>> ObtenerComandoObtenerTipoPlanilla()
        {
            return new ComandoObtenerTipoPlanilla();
        }
        public static Comando<bool> ObtenerComandoRegistrarPlanilla()
        {
            return new ComandoRegistrarPlanilla();
        }
        public static Comando<bool> ObtenerComandoRegistrarPlanillaTipo()
        {
            return new ComandoRegistrarPlanillaTipo();
        }
        public static Comando<Boolean> ObtenerComandoRegistrarSolicitudIDPersona()
        {
            return new ComandoRegistrarSolicitudIDPersona();
        }
        public static Comando<Boolean> ObtenerComandoRegistrarSolicitudPlanilla()
        {
            return new ComandoRegistrarSolicitudPlanilla();
        }

        public static Comando<List<Entidad>> ObtenerComandoListarPlanillasSolicitadas()
        {
            return new ComandoListarPlanillasSolicitadas();
        }

        public static Comando<List<Entidad>> ObtenerComandoConsultarPlanillasASolicitar()
        {
            return new ComandoConsultarPlanillasASolicitar();
        }

        public static Comando<Boolean> ObtenerComandoEliminarSolicitud()
        {
            return new ComandoEliminarSolicitud();
        }

        public static Comando<Boolean> ObtenerComandoAgregarDiseno()
        {
            return new ComandoAgregarDiseno();
        }

        public static Comando<Entidad> ObtenerComandoConsultarDiseñoPuro()
        {
            return new ComandoConsultarDiseñoPuro();
        }

        public static Comando<Boolean> ObtenerComandoModificarDiseno()
        {
            return new ComandoModificarDiseno();
        }

        public static Comando<string> ObtenerComandoReemplazarElementos()
        {
            return new ComandoReemplazarElementos();
        }

        public static Comando<Entidad> ObtenerComandoComandoConsultarDiseño()
        {
            return new ComandoConsultarDiseño();
        }

        public static Comando<List<Entidad>> ObtenerComandConsultarPlanillas()
        {
            return new ComandoConsultarPlanillas();
        }

        public static Comando<Boolean> ObtenerComandoCambiarStatusPlanilla()
        {
            return new ComandoCambiarStatusPlanilla();
        }
        #endregion

        #region Modulo 15

        #region ComandoAgregarImplemento -- ObtenerComandoAgregar
        public static Comando<bool> ObtenerComandoAgregar()
        {
            return new ComandoAgregarImplemento();
        }
        #endregion

        #endregion

        #region Modulo 16
    
        #region ComandoConsultarTodosImplementos -- ObtenerComandoConsultar
        public static Comando<List<Entidad>> ObtenerComandoConsultar()
        {
            return new ComandoConsultarTodosImplementos();
        }
        #endregion

        #region ComandoConsultarTodosImplementos2 -- ObtenerComandoConsultar2
        public static Comando<List<Entidad>> ObtenerComandoConsultar2()
        {
            return new ComandoConsultarTodosImplementos2();
        }
        #endregion

        #region ComandoEliminarImplemento -- ObtenerComandoEliminarImplemento
        public static Comando<bool> ObtenerComandoEliminarImplemento()
        {
            return new ComandoEliminarImplemento();
        }
        #endregion

        #region ComandoModificarImplemento -- ObtenerComandoModificarImplemento
        public static Comando<bool> ObtenerComandoModificarImplemento()
        {
            return new ComandoModificarImplemento();
        }
        #endregion

        #region ComandoImplementoXId -- ObtenerComandoImplementoXId
        public static Comando<Entidad> ObtenerComandoImplementoXId()
        {
            return new ComandoImplementoXId();
        }
        #endregion

        #region ComandoUsuarioDojo -- ObtenerComandoUsuarioDojo
        public static Comando<int> ObtenerComandoUsuarioDojo()
        {
            return new ComandoUsuarioDojo();
        }
        #endregion

        #region ComandoDojoId -- ObtenerComandoDojo
        public static Comando<Entidad> ObtenerComandoDojo()
        {
            return new ComandoDojoId();
        }
        #endregion 

        #region ComandoConsultarTodosProductos

        /// <summary>
        /// Metodo de la fabrica que instancia el comando ComandoConsultarTodosProductos
        /// </summary>
        /// <returns>El ComandoConsultarTodosProductos</returns>
        public static Comando<Entidad> CrearComandoConsultarTodosProductos()
        {
            return new ComandoConsultarTodosProductos();
        }
        #endregion

        #region CrearComandoDetallarProducto

        /// <summary>
        /// Metodo de la fabrica que instancia el comando CrearComandoDetallarProducto
        /// </summary>
        /// <returns>El ComandoDetallarProducto</returns>
        public static Comando<Entidad> CrearComandoDetallarProducto(Entidad implemento)
        {
            return new ComandoDetallarProducto(implemento);
        }
        #endregion

        #endregion

        #region Modulo 16

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
        public static Comando<bool> CrearComandoeliminarItem()
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
        /// Metodo de la fabrica que instancia el comando CrearComandoDetallarEvento
        /// </summary>
        /// <returns>El CrearComandoDetallarEvento</returns>
        public static Comando<Entidad> CrearComandoDetallarMatricula(Entidad matricula)
        {
            return new ComandoDetallarMatricula(matricula);
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el comando CrearComandoDetallarFactura
        /// </summary>
        /// <returns>El CrearComandoDetallarFactura</returns>
        public static Comando<Entidad> CrearComandoDetallarFactura(Entidad compra)
        {
            return new ComandoDetallarFactura(compra);
        }
        #endregion

    }
}

