using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DatosSKD.DAO.Modulo8;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoConsultarCintaTodas : Comando<List<DominioSKD.Entidad>>
    {

        private Entidad RestriccionCinta;

        public Entidad restriccionCinta
        {
            get { return RestriccionCinta; }
            set { RestriccionCinta = value; }
        }

        public override List<DominioSKD.Entidad> Ejecutar()
        {
            List<DominioSKD.Entidad> ListaCintas = new List<Entidad>();
            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();            

            try
            {
                IDaoRestriccionCinta daoRestriccionCinta = fabricaDAO.ObtenerDAORestriccionCinta();
                ListaCintas = daoRestriccionCinta.ConsultarCintaTodas();

            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }

            return ListaCintas;

        }
    }
}