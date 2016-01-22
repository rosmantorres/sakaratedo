using DatosSKD.DAO.Modulo14;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
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

        public override Entidad Ejecutar()
        {
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DaoDiseno daoDiseno = (DaoDiseno)FabricaDAOSqlServer.ObtenerDAODiseno();
            DaoDatos daoDatos = (DaoDatos)FabricaDAOSqlServer.ObtenerDAODatos();
            DaoSolicitud daoSol = (DaoSolicitud)FabricaDAOSqlServer.ObtenerDAOSolicitud();
            try
            {
                Persona persona = (Persona)FabricaEntidades.ObtenerPersona();
                DominioSKD.Entidades.Modulo14.SolicitudP solP = (DominioSKD.Entidades.Modulo14.SolicitudP)FabricaEntidades.ObtenerSolicitudP();
                Dojo dojo = (Dojo)FabricaEntidades.ObtenerDojo();
                DominioSKD.Entidades.Modulo14.Diseño diseñoPlanilla =
                    (DominioSKD.Entidades.Modulo14.Diseño)FabricaEntidades.obtenerDiseño();
                //
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)fabricaEntidad.ObtenerEvento();
                DominioSKD.Entidades.Modulo12.Competencia competencia = 
                    (DominioSKD.Entidades.Modulo12.Competencia)fabricaEntidad.ObtenerCompetencia();
                Organizacion organizacion =
                    (Organizacion)fabricaEntidad.ObtenerOrganizacion();
                DominioSKD.Entidades.Modulo14.SolicitudPlanilla solicitud =
                    (DominioSKD.Entidades.Modulo14.SolicitudPlanilla)FabricaEntidades.ObtenerSolicitudPlanilla();
                List<string> matricula = new List<string>();
                //diseñoPlanilla = (DominioSKD.Entidades.Modulo14.Diseño)daoDiseno.ConsultarXId(planilla);
                daoDiseno.LimpiarSQLConnection();
                persona = daoDatos.ConsultarPersona(idPersona);
                daoDatos.LimpiarSQLConnection();
                dojo = daoDatos.ConsultarDojo(persona.ID);
                daoDatos.LimpiarSQLConnection();
                matricula = daoDatos.ConsultarMatricula(dojo.Id_dojo, idPersona);
                daoDatos.LimpiarSQLConnection();
                evento = (DominioSKD.Entidades.Modulo9.Evento)daoDatos.ConsultarEvento(idIns);
                daoDatos.LimpiarSQLConnection();
                competencia = (DominioSKD.Entidades.Modulo12.Competencia)daoDatos.ConsultarCompetencia(idIns);
                daoDatos.LimpiarSQLConnection();
                organizacion = (Organizacion)daoDatos.ConsultarOrganizacion(dojo.Organizacion_dojo);
                daoDatos.LimpiarSQLConnection();
                solicitud = (DominioSKD.Entidades.Modulo14.SolicitudPlanilla)daoDatos.ConsultarSolicitud(idSolici);
                daoDatos.LimpiarSQLConnection();
                diseñoPlanilla = (DominioSKD.Entidades.Modulo14.Diseño)daoDiseno.ConsultarDisenoID(solicitud);
                daoDiseno.LimpiarSQLConnection();
                Fabrica.FabricaComandos fComandos = new Fabrica.FabricaComandos();
                ComandoReemplazarElementos comand = 
                    (ComandoReemplazarElementos)fComandos.ObtenerComandoReemplazarElementos();
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
