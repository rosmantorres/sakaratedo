using DatosSKD.InterfazDAO.Modulo11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    class ComandoListaEspecialidadesCompetencia : Comando<List<string>>
    {
        private string idCompetencia;
        public string IdCompetencia
        {
            get { return idCompetencia; }
            set { idCompetencia = value; }
        }
        public ComandoListaEspecialidadesCompetencia(string idCompetencia)
        {
            this.idCompetencia = idCompetencia;
        }

        public override List<string> Ejecutar()
        {
            try
            {
                IDaoResultadoKata daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoKata();
                List<string> listaString = daoResultado.ListaEspecialidadesCompetencia(idCompetencia);
                return listaString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
