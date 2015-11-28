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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        public Boolean CambiarStatusPlanilla(int idPlanilla)
        {
            return datos.CambiarStatus(idPlanilla);
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

        /// <summary>Obtener una planilla por ID</summary>
        /// <param name="idPlanilla"></param>
        /// <returns>Regresa la planilla con su nombre, status y tipo planilla</returns>
        /// 
        public Planilla ObtenerPlanillaID(int idPlanilla)
        {
            Planilla planilla = new Planilla();

            planilla = BDPlanilla.ObtenerPlanillaID(idPlanilla);
            planilla.Dato = BDPlanilla.ObtenerDatosPlanillaID(idPlanilla);

            return planilla;
        }

        /// <summary>Modificar una planilla</summary>
        /// <param name="idPlanilla">la planilla</param>
        /// <returns>Regresa true si se modifico y false si no</returns>
        /// 
        public Planilla ModificarPlanillaID(Planilla laPlanilla)
        {
            Planilla planilla = new Planilla();

            BDPlanilla.ModificarPlanillaBD(laPlanilla);
            BDPlanilla.EliminarDatosPlanillaBD(laPlanilla.ID);
            foreach (String item in laPlanilla.Dato)
            {
                BDPlanilla.RegistrarDatosPlanillaIdBD(laPlanilla.ID, item);                
            }

            return planilla;
        }

        /// <summary>Modificar una planilla</summary>
        /// <param name="idPlanilla">la planilla</param>
        /// <returns>Regresa true si se modifico y false si no</returns>
        /// 
        public Planilla ModificarPlanillaID(Planilla laPlanilla, String tipoPlanilla)
        {
            int idTipoPlanilla = BDPlanilla.ObtenerIdTipoPlanilla(tipoPlanilla);
            laPlanilla.IDtipoPlanilla = idTipoPlanilla;
            ModificarPlanillaID(laPlanilla);
            return laPlanilla;
        }  

    }
}
