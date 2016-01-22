using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo10
{
    public class ComandoListaAsistentesCompetencia : Comando<List<Entidad>>
    {
        private string idCompetencia;

        public string IdCompetencia
        {
            get { return idCompetencia; }
            set { idCompetencia = value; }
        }

        public ComandoListaAsistentesCompetencia(string idCompetencia)
        {
            this.idCompetencia = idCompetencia;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoAsistencia daoAsistencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOAsistencia();
                List<Entidad> listaEntidad = daoAsistencia.ListaAsistentesCompetencia(idCompetencia);
                return listaEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
