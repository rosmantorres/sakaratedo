using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo14;
namespace LogicaNegociosSKD.Modulo14
{
    public class LogicaSolicitud
    {
        private BDSolicitud datos = new BDSolicitud();
        private BDDiseño diseño = new BDDiseño();
        /// <summary>
        /// Metodo que lista todas las planillas que ha solicitado una persona
        /// </summary>
        /// <param name="idPersona"Id de la Persona </param>
        /// <returns>Retorna una lista de solicitudes</returns>
        public List<DominioSKD.SolicitudPlanilla> ListarPlanillasSolicitadas(int idPersona)
        {
            return datos.ConsultarSolicitudes(idPersona);
        }

        /// <summary>
        /// Método que elimina una solicitud dada
        /// </summary>
        /// <param name="idSolicitud">Id de la solicitud que se desea eliminar</param>
        /// <returns>Retorna true si la operación se realizo con éxito.
        /// De lo contrario devuelve false</returns>
        public Boolean EliminarSolicitud(int idSolicitud)
        {
            return datos.EliminarSolicitudBD(idSolicitud);
        }

        /// <summary>
        /// Método que devuelve todas las planillas que un atleta puede solicitar
        /// </summary>
        /// <returns>retorna una lista de planillas</returns>
        public List<DominioSKD.Planilla> ConsultarPlanillasASolicitar()
        {
            return datos.ConsultarPlanillasASolicitarBD();
        }
    
        /// <summary>Para determinar que datos son requeridos en la solicitud</summary>
        /// <param name="idPlanilla"> id de la planilla solicitada</param>
        /// <returns>Regresa una lista de bool para determinar que datos son requeridos</returns>

        public List<Boolean> DatosRequeridosSolicitud(int idPlanilla)
        {
            Diseño resultDiseño = diseño.ConsultarDiseño(idPlanilla);

            List<bool> datosRequeridos = new List<bool>();

            datosRequeridos.Add(resultDiseño.Contenido.Contains("$sol_pla_fecha_retiro"));
            datosRequeridos.Add(resultDiseño.Contenido.Contains("$sol_pla_fecha_reincorporacion"));

            return datosRequeridos;
        }

        /// <summary>Para registrar una solicitud</summary>
        /// <param name="laSolicitud"> la solicitud</param>
        /// <returns>Regresa true si el registro se realizó correctamente y false si no</returns>
        public void RegistrarSolicitudPlanilla(SolicitudP laSolicitud)
        {
            Boolean result = datos.RegistrarSolicitudPlanillaBD(laSolicitud);
        }

        /// <summary>Para registrar una solicitud por el id de la persona</summary>
        /// <param name="laSolicitud"> la solicitud</param>
        /// <returns>Regresa true si el registro se realizó correctamente y false si no</returns>
        public void RegistrarSolicitudIDPersona(SolicitudP laSolicitud)
        {
            Boolean result = datos.RegistrarSolicitudIDPersonaBD(laSolicitud);
        }
        /// <summary>Para determinar que datos son requeridos en la solicitud</summary>
        /// <param name="idPlanilla"> id de la planilla solicitada</param>
        /// <returns>Regresa una lista de bool para determinar que datos son requeridos</returns>

        public List<SolicitudP> EventosSolicitud(int idPersona)
        {
            List<SolicitudP> eventos = new List<SolicitudP>();
            try
            {
                eventos = datos.ObtenerEventosSolicitud(idPersona);
            }
            catch (Exception e)
            {

            }
            return eventos;
        }

        /// <summary>Para determinar que datos son requeridos en la solicitud</summary>
        /// <param name="idPersona"> id persona</param>
        /// <returns>Regresa una lista de bool para determinar que datos son requeridos</returns>

        public List<SolicitudP> CompetenciasSolicitud(int idPersona)
        {
            List<SolicitudP> eventos = new List<SolicitudP>();
            try
            {
                eventos = datos.ObtenerCompetenciaSolicitud(idPersona);
            }
            catch (Exception e)
            {

            }
            return eventos;
        }
        /// <summary>Obtener una solicitud por ID</summary>
        /// <param name="idPlanilla"></param>
        /// <returns>Regresa la solicitud con su fechar, fecharei y motivo</returns>
        /// 
        public SolicitudPlanilla ObtenerSolicitudID(int idSolicitud)
        {
            SolicitudPlanilla solicitud = new SolicitudPlanilla();

            BDSolicitud BaseDeDatoPlanilla = new BDSolicitud();
            solicitud = BaseDeDatoPlanilla.ObtenerSolicitudID(idSolicitud);
            return solicitud;
        }
        /// <summary>Modificar una solicitud por id</summary>
        /// <param name="laSolicitud">la solicitud</param>
        /// <returns>Regresa true si se modifico y false si no</returns>
        /// 
        public SolicitudP ModificarSolicitudID(SolicitudP laSolicitud)
        {
            BDSolicitud BaseDeDatoSolicitud = new BDSolicitud();
            SolicitudP solicitud = new SolicitudP();
            BaseDeDatoSolicitud.ModificarSolicitudBD(laSolicitud);

            return solicitud;
        }
    }
}
