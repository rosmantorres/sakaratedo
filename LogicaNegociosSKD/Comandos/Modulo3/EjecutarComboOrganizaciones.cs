using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo3;
using DominioSKD;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo3
{
    public class EjecutarComboOrganizaciones : Comando<List<Entidad>>
    {
        /// <summary>
        /// Método Ejecutar el consultar la lista de organizaciones (solo id y nombre)
        /// </summary>
        /// <returns>Lista de Organizaciones</returns>
        public override List<Entidad> Ejecutar()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try { 

            IDaoOrganizacion miDaoOrganizacion = FabricaDAOSqlServer.ObtenerDaoOrganizacion();
            List<Entidad> _miLista = miDaoOrganizacion.ComboOrganizaciones();
            if (_miLista != null)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return _miLista;
            }
            else
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosComandosModulo3.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw new ExcepcionesSKD.Modulo5.ListaVaciaExcepcion(RecursosComandosModulo3.Codigo_Error_Lista_Vacia,
                                  RecursosComandosModulo3.Mensaje_Error_Lista_Vacia, new Exception());


            }
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.Modulo3.FormatoIncorrectoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
        }
    }
}
