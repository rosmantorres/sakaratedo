using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoListarResultadosEventosPasados : Comando<List<Entidad>>
    {
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoResultadoAscenso daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
                List<Entidad> listaEntidad = daoResultado.ListarResultadosEventosPasados();
                return listaEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
