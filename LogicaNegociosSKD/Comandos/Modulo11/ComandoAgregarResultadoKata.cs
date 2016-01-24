using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoAgregarResultadoKata : Comando<bool>
    {
        private List<Entidad> listaEntidad;
        public List<Entidad> ListaEntidad
        {
            get { return listaEntidad; }
            set { listaEntidad = value; }
        }
        public ComandoAgregarResultadoKata(List<Entidad> listaEntidad)
        {
            this.listaEntidad = listaEntidad;
        }
        public override bool Ejecutar()
        {
            try
            {
                IDaoResultadoKata daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoKata();
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
