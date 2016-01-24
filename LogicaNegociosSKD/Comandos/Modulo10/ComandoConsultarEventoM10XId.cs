using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo10
{
    public class ComandoConsultarEventoM10XId : Comando<Entidad>
    {
        private string idEvento;
        public string IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }
        public ComandoConsultarEventoM10XId(string idEvento)
        {
            this.idEvento = idEvento;
        }
        public override Entidad Ejecutar()
        {
            try
            {
                IDaoAsistencia daoAsistencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOAsistencia();
                Entidad entidad = daoAsistencia.ConsultarEventoXID(idEvento);
                return entidad;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
