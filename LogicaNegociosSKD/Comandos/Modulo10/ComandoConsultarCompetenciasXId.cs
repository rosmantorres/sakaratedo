using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo10
{
    public class ComandoConsultarCompetenciasXId : Comando<Entidad>
    {
        private string idCompetencia;

        public string IdCompetencia
        {
            get { return idCompetencia; }
            set { idCompetencia = value; }
        }
        public ComandoConsultarCompetenciasXId(string idCompetencia)
        {
            this.idCompetencia = idCompetencia;
        }
        public override Entidad Ejecutar()
        {
            try
            {
                IDaoAsistencia daoAsistencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOAsistencia();
                Entidad entidad = daoAsistencia.ConsultarCompetenciasXId(idCompetencia);
                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
