using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo14;

namespace LogicaNegociosSKD.Modulo14
{
    public class LogicaPlanilla
    {
        private DatosSKD.Modulo14.BDPlanilla datos = new DatosSKD.Modulo14.BDPlanilla();

        public List<DominioSKD.Planilla> ConsultarPlanillas()
        {
            return datos.ConsultarPlanillasCreadas();
        }
        /// <summary>Para verificar si el registro fue correcto</summary>
        /// <param name="elUsuario">El usuario que se va a registrar</param>
        /// <returns>Regresa true si el registro se realizó correctamente y false si no</returns>
        /// 
        public List<Planilla> ObtenerTipoPlanilla()
        {
            List<Planilla> listaTipoPlanilla = new List<Planilla>();

            listaTipoPlanilla = BDPlanilla.ObtenerTipoPlanilla();

            return listaTipoPlanilla;
        }

        /// <summary>Para verificar si el registro fue correcto</summary>
        /// <param name="elUsuario">El usuario que se va a registrar</param>
        /// <returns>Regresa true si el registro se realizó correctamente y false si no</returns>
        public List<String> ObtenerDatosBD()
        {
            List<String> listaDatos = new List<String>();
            try
            {
                listaDatos = BDPlanilla.ObtenerDatosBD();

            }
            catch (Exception e)
            {
                throw e;
            }

            return listaDatos;
        }

        /// <summary>Para verificar</summary>
        /// <param name="elUsuario">El usuario que se va a registrar</param>
        /// <returns>Regresa true si el registro se realizó correctamente y false si no</returns>
        public void RegistrarPlanilla(Planilla laPlanilla)
        {
            Boolean resultPlanilla = BDPlanilla.RegistrarPlanillaBD(laPlanilla);

            foreach (String nombreDato in laPlanilla.Dato)
            {
                Boolean resultdatos = BDPlanilla.RegistrarDatosPlanillaBD(laPlanilla.Nombre, nombreDato);

            }
        }
        public void RegistrarPlanilla(Planilla laPlanilla, String nombreTipo)
        {
            int idTipoPlanilla = BDPlanilla.ObtenerIdTipoPlanilla(nombreTipo);
            laPlanilla.IDtipoPlanilla = idTipoPlanilla;
            RegistrarPlanilla(laPlanilla);
        }
        public void NuevoTipoPlanilla(String nombreTipo)
        {
            Boolean result = BDPlanilla.RegistrarTipoPlanilla(nombreTipo);

        }
    }
}
