﻿using DatosSKD.DAO.Modulo14;
using DatosSKD.InterfazDAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo14
{
    public class ComandoConsultarDiseño : Comando<Entidad>
    {
        private Entidad planilla;
        private int idPersona;
        private int idIns;
        private int idSolici;

        public Entidad Planilla
        {
            get { return planilla; }
            set { planilla = value; }
        }
        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        public int IdIns
        {
            get { return idIns; }
            set { idIns = value; }
        }
        public int IdSolici
        {
            get { return idSolici; }
            set { idSolici = value; }
        }
        /// <summary>
        /// Método que separa consultar el diseño de un 
        /// planilla y reemplaza los valores con los datos necesarios del Atleta
        /// </summary>
        /// <param name="planilla">la Planilla que contiene el diseño</param>
        /// <param name="idPersona">Id de la persona de los datos</param>
        /// <param name="idSolicitud">Id de la solicitud de la planilla que 
        /// contiene el diseño a consultar</param>
        /// <returns>Retorna la entidad, con los datos reemplazados</returns>
        public override Entidad Ejecutar()
        {
            
            IDaoDiseno daoDiseno = FabricaDAOSqlServer.ObtenerDAODiseno();
            IDaoDatos daoDatos = FabricaDAOSqlServer.ObtenerDAODatos();
            IDaoSolicitud daoSol = FabricaDAOSqlServer.ObtenerDAOSolicitud();
            try
            {
                Persona persona = (Persona)FabricaEntidades.ObtenerPersona();
                DominioSKD.Entidades.Modulo14.SolicitudP solP = (DominioSKD.Entidades.Modulo14.SolicitudP)FabricaEntidades.ObtenerSolicitudP();
                Dojo dojo = (Dojo)FabricaEntidades.ObtenerDojo();
                DominioSKD.Entidades.Modulo14.Diseño diseñoPlanilla =
                    (DominioSKD.Entidades.Modulo14.Diseño)FabricaEntidades.obtenerDiseño();
                //
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
                DominioSKD.Entidades.Modulo12.Competencia competencia = 
                    (DominioSKD.Entidades.Modulo12.Competencia)FabricaEntidades.ObtenerCompetencia();
                Organizacion organizacion =
                    (Organizacion)FabricaEntidades.ObtenerOrganizacion();
                DominioSKD.Entidades.Modulo14.SolicitudPlanilla solicitud =
                    (DominioSKD.Entidades.Modulo14.SolicitudPlanilla)FabricaEntidades.ObtenerSolicitudPlanilla();
                List<string> matricula = new List<string>();
                persona = daoDatos.ConsultarPersona(idPersona);
                dojo = daoDatos.ConsultarDojo(persona.ID);
                matricula = daoDatos.ConsultarMatricula(dojo.Id_dojo, idPersona);
                evento = (DominioSKD.Entidades.Modulo9.Evento)daoDatos.ConsultarEvento(idIns);
                competencia = (DominioSKD.Entidades.Modulo12.Competencia)daoDatos.ConsultarCompetencia(idIns);
                organizacion = (Organizacion)daoDatos.ConsultarOrganizacion(dojo.Organizacion_dojo);
                solicitud = (DominioSKD.Entidades.Modulo14.SolicitudPlanilla)daoDatos.ConsultarSolicitud(idSolici);
                diseñoPlanilla = (DominioSKD.Entidades.Modulo14.Diseño)daoDiseno.ConsultarDisenoID(solicitud);
                ComandoReemplazarElementos comand =
                    (ComandoReemplazarElementos)FabricaComandos.ObtenerComandoReemplazarElementos();
                comand.Info = diseñoPlanilla.Contenido;
                //comand.Info = solicitud.Diseno.Contenido;
                comand.Persona = persona;
                comand.Dojo = dojo;
                comand.Evento = evento;
                comand.Competencia = competencia;
                comand.Matricula = matricula;
                comand.Organizacion = organizacion;
                comand.Solicitud = solicitud;
                diseñoPlanilla.Contenido = comand.Ejecutar();
                return diseñoPlanilla;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }

        }
    }
}
