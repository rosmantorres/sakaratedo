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
    public class ComandoConsultarRestriccionEvento : Comando<List<DominioSKD.Entidad>>
    {

        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public override List<DominioSKD.Entidad> Ejecutar()
        {
            List<DominioSKD.Entidad> resultado = new List<Entidad>(); ;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();


            try
            {
                IDaoRestriccionEvento daoRestriccionEvento = fabricaDAO.ObtenerDAORestriccionEvento();
                resultado = daoRestriccionEvento.ConsultarEventosConRestriccion();

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return resultado;

        }

    }
}