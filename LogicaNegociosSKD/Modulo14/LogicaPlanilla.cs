using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo14;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Modulo14
{
    public class LogicaPlanilla
    {
        private DatosSKD.Modulo14.BDPlanilla datos = new DatosSKD.Modulo14.BDPlanilla();

        /// <summary>
        /// Método que devuelve todas las planillas creadas
        /// </summary>
        /// <returns>Retorna una lista con todas las planillas registradas</returns>
        public List<DominioSKD.Planilla> ConsultarPlanillas()
        {
            try
            {
                List<DominioSKD.Planilla> listaplanilla = new List<DominioSKD.Planilla>();
                listaplanilla = datos.ConsultarPlanillasCreadas();
                foreach (DominioSKD.Planilla planilla in listaplanilla)
                {
                    planilla.Dato = BDPlanilla.ObtenerDatosPlanillaID1(planilla.ID);
                }
                return listaplanilla;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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
        /// <summary>Para obtener el tipo de planilla</summary>
        /// <returns>Regresa una lista de planillas</returns>
        /// 
        public List<Planilla> ObtenerTipoPlanilla()
        {
            try
            {
                List<Planilla> listaTipoPlanilla = new List<Planilla>();
                BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
                listaTipoPlanilla = BaseDeDatoPlanilla.ObtenerTipoPlanilla();

                return listaTipoPlanilla;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>
        /// Método que cambia el status de una planilla
        /// </summary>
        /// <param name="idPlanilla">Id de la planilla a modificar</param>
        /// <returns>Retorna True se se realizo la modificación con éxito.
        /// De lo contrario devuelve False</returns>
        public Boolean CambiarStatusPlanilla(int idPlanilla)
        {
            try
            {

                return datos.CambiarStatus(idPlanilla);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>Para obtener los datos de la bd</summary>
        /// <returns>Regresa una lista con los datos</returns>
        public List<String> ObtenerDatosBD()
        {
            List<String> listaDatos = new List<String>();
            try
            {
                BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
                listaDatos = BaseDeDatoPlanilla.ObtenerDatosBD();
                return listaDatos;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>Para registrar una planilla</summary>
        /// <param name="laPlanilla"> la planilla</param>
        /// <returns>Regresa true si el registro se realizó correctamente y false si no</returns>
        public void RegistrarPlanilla(Planilla laPlanilla)
        {
            try
            {
                BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
                Boolean resultPlanilla = BaseDeDatoPlanilla.RegistrarPlanillaBD(laPlanilla);

                foreach (String nombreDato in laPlanilla.Dato)
                {

                    Boolean resultdatos = BaseDeDatoPlanilla.RegistrarDatosPlanillaBD(laPlanilla.Nombre, nombreDato);

                }
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>
        /// Método que registra una planilla
        /// </summary>
        /// <param name="laPlanilla">La clase planilla</param>
        /// <param name="nombreTipo">El tipo de planilla al cual pertenece</param>
        public void RegistrarPlanilla(Planilla laPlanilla, String nombreTipo)
        {
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            try
            {
                int idTipoPlanilla = BaseDeDatoPlanilla.ObtenerIdTipoPlanilla(nombreTipo);
                laPlanilla.IDtipoPlanilla = idTipoPlanilla;
                RegistrarPlanilla(laPlanilla);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>
        /// Método que registra un nuevo tipo de planilla
        /// </summary>
        /// <param name="nombreTipo">Recibe el nombre del nuevo tipo de planilla</param>
        public void NuevoTipoPlanilla(String nombreTipo)
        {
            try
            {
                BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
                Boolean result = BaseDeDatoPlanilla.RegistrarTipoPlanilla(nombreTipo);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>Obtener una planilla por ID</summary>
        /// <param name="idPlanilla"></param>
        /// <returns>Regresa la planilla con su nombre, status y tipo planilla</returns>
        /// 
        public Planilla ObtenerPlanillaID(int idPlanilla)
        {
            Planilla planilla = new Planilla();
            try
            {

                BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
                planilla = BaseDeDatoPlanilla.ObtenerPlanillaID(idPlanilla);
                planilla.Dato = BaseDeDatoPlanilla.ObtenerDatosPlanillaID(idPlanilla);
                return planilla;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>
        /// Método que devuelve una lista de sting con los datos que posee 
        /// una planilla
        /// </summary>
        /// <param name="idPlanilla">iD de la planilla de la cual se desean 
        /// saber sus datos</param>
        /// <returns>Regresa la lista con dichos datos</returns>
        public List<string> ObtenerDatosPlanilla(int idPlanilla)
        {
            try
            {
                BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
                List<String> datos = BaseDeDatoPlanilla.ObtenerDatosPlanillaID(idPlanilla);
                return datos;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>Modificar una planilla por id</summary>
        /// <param name="laPlanilla">la planilla</param>
        /// <returns>Regresa true si se modifico y false si no</returns>
        /// 
        public Planilla ModificarPlanillaID(Planilla laPlanilla)
        {
            BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
            try
            {
                Planilla planilla = new Planilla();
                BaseDeDatoPlanilla.ModificarPlanillaBD(laPlanilla);
                BaseDeDatoPlanilla.EliminarDatosPlanillaBD(laPlanilla.ID);
                foreach (String item in laPlanilla.Dato)
                {
                    BaseDeDatoPlanilla.RegistrarDatosPlanillaIdBD(laPlanilla.ID, item);
                }

                return planilla;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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

        /// <summary>Modificar una planilla</summary>
        /// <param name="">la planilla y el tipo de planilla</param>
        /// <returns>Regresa la planilla modificando su tipo de planilla</returns>
        /// 
        public Planilla ModificarPlanillaID(Planilla laPlanilla, String tipoPlanilla)
        {
            try
            {
                BDPlanilla BaseDeDatoPlanilla = new BDPlanilla();
                int idTipoPlanilla = BaseDeDatoPlanilla.ObtenerIdTipoPlanilla(tipoPlanilla);
                laPlanilla.IDtipoPlanilla = idTipoPlanilla;
                ModificarPlanillaID(laPlanilla);
                return laPlanilla;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
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
