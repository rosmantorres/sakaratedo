using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoAgregarResultadoAscenso : Comando<bool>
    {
        private List<Entidad> listaEntidad;
        public List<Entidad> ListaEntidad
        {
            get { return listaEntidad; }
            set { listaEntidad = value; }
        }
        public ComandoAgregarResultadoAscenso(List<Entidad> listaEntidad)
        {
            this.listaEntidad = listaEntidad;
        }
        public override bool Ejecutar()
        {
            try
            {
                IDaoResultadoAscenso daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
                bool resultado = daoResultado.Agregar(listaEntidad);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
