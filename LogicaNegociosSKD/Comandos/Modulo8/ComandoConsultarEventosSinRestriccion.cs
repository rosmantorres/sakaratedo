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
    public class ComandoConsultarEventosSinRestriccion : Comando<List<DominioSKD.Entidad>>
    {
        private Entidad RestriccionEvento;

        public Entidad LaRestriccionCompetencia
        {
            get { return RestriccionEvento; }
            set { RestriccionEvento = value; }
        }
        public override List<DominioSKD.Entidad> Ejecutar()
        {
            List<DominioSKD.Entidad> resultado;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();                    

            try
            {
                IDaoRestriccionEvento daoRestriccionEvento = fabricaDAO.ObtenerDAORestriccionEvento();
                resultado = daoRestriccionEvento.ConsultarEventosSinRestriccion();

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return resultado;
        }
    }
}
