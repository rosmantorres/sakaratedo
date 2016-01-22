using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoListaAtletasParticipanCompetenciaKumite : Comando<List<Entidad>>
    {
        public ComandoListaAtletasParticipanCompetenciaKumite(Entidad entidad)
        {
            this.LaEntidad = entidad;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoResultadoKumite daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoKumite();
                List<Entidad> listaEntidad = daoResultado.ListaAtletasParticipanCompetenciaKumite(this.LaEntidad);
                return listaEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
