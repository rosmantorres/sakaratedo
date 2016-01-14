using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ConsultarCintaTodas : Comando<List<DominioSKD.Entidad>>
    {

        private Entidad RestriccionCinta;

        public Entidad restriccionCinta
        {
            get { return RestriccionCinta; }
            set { RestriccionCinta = value; }
        }

        public override List<DominioSKD.Entidad> Ejecutar()
        {
            List<DominioSKD.Entidad> resultado;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            IDaoRestriccionCinta daoRestriccionCinta = fabricaDAO.ObtenerDAORestriccionCinta();

            try
            {

                resultado = daoRestriccionCinta.ConsultarCintaTodas();

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return resultado;

        }
    }
}