using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoListaAtletasEnCategoriaYAscenso : Comando<List<Entidad>>
    {
        public ComandoListaAtletasEnCategoriaYAscenso(Entidad entidad)
        {
            this.LaEntidad = entidad;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoResultadoAscenso daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
                List<Entidad> listaEntidad = daoResultado.ListaAtletasEnCategoriaYAscenso(this.LaEntidad);
                return listaEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
