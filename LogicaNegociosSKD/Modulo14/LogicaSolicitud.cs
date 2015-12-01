﻿using System;
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
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public List<DominioSKD.SolicitudPlanilla> ListarPlanillasSolicitadas(int idPersona)
        {
            return datos.ConsultarSolicitudes(idPersona);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
        public Boolean EliminarSolicitud(int idSolicitud)
        {
            return datos.EliminarSolicitudBD(idSolicitud);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>Para determinar que datos son requeridos en la solicitud</summary>
        /// <param name="idPlanilla"> id de la planilla solicitada</param>
        /// <returns>Regresa una lista de bool para determinar que datos son requeridos</returns>

        public List<String> EventosSolicitud(int idPersona)
        {
            List<String> eventos = new List<String>();
            try
            {
                eventos = datos.ObtenerEventosSolicitud(idPersona);
            }catch(Exception e){

            }
            return eventos;
        }

        /// <summary>Para determinar que datos son requeridos en la solicitud</summary>
        /// <param name="idPersona"> id persona</param>
        /// <returns>Regresa una lista de bool para determinar que datos son requeridos</returns>

        public List<String> CompetenciasSolicitud(int idPersona)
        {
            List<String> eventos = new List<String>();
            try
            {
                eventos = datos.ObtenerCompetenciaSolicitud(idPersona);
            }
            catch (Exception e)
            {

            }
            return eventos;
        }
    }
}
