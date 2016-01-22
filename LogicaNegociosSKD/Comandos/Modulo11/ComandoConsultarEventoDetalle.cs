using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoConsultarEventoDetalle : Comando<Entidad>
    {
        private string idEvento;

        public string IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        public ComandoConsultarEventoDetalle(string idEvento)
        {
            this.idEvento = idEvento;
        }
        public override Entidad Ejecutar()
        {
            try
            {
                IDaoResultadoAscenso daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
                Entidad entidad = daoResultado.ConsultarEventoDetalle(idEvento);
                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
