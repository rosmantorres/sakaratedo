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
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            FabricaEntidades fabricaEntidad = new FabricaEntidades();
            DaoDiseno daoDiseno = (DaoDiseno)fabrica.ObtenerDAODiseno();
            DaoDatos daoDatos = (DaoDatos)fabrica.ObtenerDAODatos();
            try
            {
                Persona persona = (Persona)fabricaEntidad.ObtenerPersona();
                Dojo dojo = (Dojo)fabricaEntidad.ObtenerDojo();
                Diseño diseñoPlanilla = (Diseño)fabricaEntidad.obtenerDiseño();
                //
                Evento evento = new Evento();
                Competencia competencia = (Competencia)fabricaEntidad.ObtenerCompetencia();
                Organizacion organizacion = (Organizacion)fabricaEntidad.ObtenerOrganizacion();
                SolicitudPlanilla solicitud = 
                    (SolicitudPlanilla)fabricaEntidad.ObtenerSolicitudPlanilla();
                List<string> matricula = new List<string>();
                diseñoPlanilla = (Diseño)daoDiseno.ConsultarXId(planilla);
                daoDiseno.LimpiarSQLConnection();
                persona = daoDatos.ConsultarPersona(idPersona);
                daoDatos.LimpiarSQLConnection();
                dojo = daoDatos.ConsultarDojo(persona.ID);
                daoDatos.LimpiarSQLConnection();
                matricula = daoDatos.ConsultarMatricula(dojo.Id_dojo, idPersona);
                daoDatos.LimpiarSQLConnection();
                evento = daoDatos.ConsultarEvento(idIns);
                daoDatos.LimpiarSQLConnection();
                competencia = (Competencia)daoDatos.ConsultarCompetencia(idIns);
                daoDatos.LimpiarSQLConnection();
                organizacion = (Organizacion)daoDatos.ConsultarOrganizacion(dojo.Organizacion_dojo);
                daoDatos.LimpiarSQLConnection();
                solicitud =(SolicitudPlanilla)daoDatos.ConsultarSolicitud(idSolici);
                daoDatos.LimpiarSQLConnection();
                Fabrica.FabricaComandos fComandos = new Fabrica.FabricaComandos();
                ComandoReemplazarElementos comand = 
                    (ComandoReemplazarElementos)fComandos.ObtenerComandoReemplazarElementos();
                comand.Info = diseñoPlanilla.Contenido;
                comand.Persona = persona;
                comand.Dojo = dojo;
                //comand.Evento = evento;
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
