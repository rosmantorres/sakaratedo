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
        /// <summary>Para obtener el tipo de planilla</summary>
        /// <returns>Regresa una lista de planillas</returns>
        /// 
        public List<Planilla> ObtenerTipoPlanilla()
        {
            List<Planilla> listaTipoPlanilla = new List<Planilla>();
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            listaTipoPlanilla = BaseDeDatoPlanilla.ObtenerTipoPlanilla();

            return listaTipoPlanilla;
        }

        public Boolean CambiarStatusPlanilla(int idPlanilla)
        {
            return datos.CambiarStatus(idPlanilla);
        }

        /// <summary>Para obtener los datos de la bd</summary>
        /// <returns>Regresa una lista con los datos</returns>
        public List<String> ObtenerDatosBD()
        {
            List<String> listaDatos = new List<String>();
            try
            {
                BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
                listaDatos = BaseDeDatoPlanilla.ObtenerDatosBD();
            }
            catch (Exception e)
            {
                throw e;
            }

            return listaDatos;
        }

        /// <summary>Para registrar una planilla</summary>
        /// <param name="laPlanilla"> la planilla</param>
        /// <returns>Regresa true si el registro se realizó correctamente y false si no</returns>
        public void RegistrarPlanilla(Planilla laPlanilla)
        {
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            Boolean resultPlanilla = BaseDeDatoPlanilla.RegistrarPlanillaBD(laPlanilla);

            foreach (String nombreDato in laPlanilla.Dato)
            {
                
                Boolean resultdatos = BaseDeDatoPlanilla.RegistrarDatosPlanillaBD(laPlanilla.Nombre, nombreDato);
                
            }
        }

        public void RegistrarPlanilla(Planilla laPlanilla, String nombreTipo)
        {
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            int idTipoPlanilla = BaseDeDatoPlanilla.ObtenerIdTipoPlanilla(nombreTipo);
            laPlanilla.IDtipoPlanilla = idTipoPlanilla;
            RegistrarPlanilla(laPlanilla);
        }

        public void NuevoTipoPlanilla(String nombreTipo)
        {
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            Boolean result = BaseDeDatoPlanilla.RegistrarTipoPlanilla(nombreTipo);

        }

        /// <summary>Obtener una planilla por ID</summary>
        /// <param name="idPlanilla"></param>
        /// <returns>Regresa la planilla con su nombre, status y tipo planilla</returns>
        /// 
        public Planilla ObtenerPlanillaID(int idPlanilla)
        {
            Planilla planilla = new Planilla();

            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            planilla = BaseDeDatoPlanilla.ObtenerPlanillaID(idPlanilla);
            planilla.Dato = BaseDeDatoPlanilla.ObtenerDatosPlanillaID(idPlanilla);

            return planilla;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="idPlanilla"></param>
        /// <returns></returns>
        public List<string> ObtenerDatosPlanilla(int idPlanilla)
        {
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            List<String> datos = BaseDeDatoPlanilla.ObtenerDatosPlanillaID(idPlanilla);
            return datos;
        }

        /// <summary>Modificar una planilla por id</summary>
        /// <param name="laPlanilla">la planilla</param>
        /// <returns>Regresa true si se modifico y false si no</returns>
        /// 
        public Planilla ModificarPlanillaID(Planilla laPlanilla)
        {
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            Planilla planilla = new Planilla();
            BaseDeDatoPlanilla.ModificarPlanillaBD(laPlanilla);
            BaseDeDatoPlanilla.EliminarDatosPlanillaBD(laPlanilla.ID);
            foreach (String item in laPlanilla.Dato)
            {
                BaseDeDatoPlanilla.RegistrarDatosPlanillaIdBD(laPlanilla.ID, item);                
            }

            return planilla;
        }

        /// <summary>Modificar una planilla</summary>
        /// <param name="">la planilla y el tipo de planilla</param>
        /// <returns>Regresa la planilla modificando su tipo de planilla</returns>
        /// 
        public Planilla ModificarPlanillaID(Planilla laPlanilla, String tipoPlanilla)
        {
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            int idTipoPlanilla = BaseDeDatoPlanilla.ObtenerIdTipoPlanilla(tipoPlanilla);
            laPlanilla.IDtipoPlanilla = idTipoPlanilla;
            ModificarPlanillaID(laPlanilla);
            return laPlanilla;
        }  

    }
}
