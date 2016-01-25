using DatosSKD.InterfazDAO.Modulo11;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo11
{
    public class ComandoAscensosPorFechaM10 : Comando<List<Entidad>>
    {
        private string fecha;
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public ComandoAscensosPorFechaM10(string fecha)
        {
            this.fecha = fecha;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoResultadoAscenso daoResultado = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOResultadoAscenso();
                List<Entidad> lista = daoResultado.AscensosPorFechaM10(fecha);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
