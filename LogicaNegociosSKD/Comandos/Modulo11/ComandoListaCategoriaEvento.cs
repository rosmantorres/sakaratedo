using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoListaCategoriaEvento : Comando<List<Entidad>>
    {
        private string idEvento;
        public string IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        public ComandoListaCategoriaEvento(string idEvento)
        {
            this.idEvento = idEvento;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoResultadoAscenso daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
                List<Entidad> listaEntidad = daoResultado.ListaCategoriaEvento(idEvento);
                return listaEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
