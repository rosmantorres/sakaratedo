using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo10
{
    public class ComandoConsultarCompetenciaXIdDetalle : Comando<Entidad>
    {
        private string idCompetencia;

        public string IdCompetencia
        {
            get { return idCompetencia; }
            set { idCompetencia = value; }
        }
        public ComandoConsultarCompetenciaXIdDetalle(string idCompetencia)
        {
            this.idCompetencia = idCompetencia;
        }
        public override Entidad Ejecutar()
        {
            try
            {
                IDaoAsistencia daoAsistencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOAsistencia();
                Entidad entidad = daoAsistencia.ConsultarCompetenciaXIdDetalle(idCompetencia);
                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
