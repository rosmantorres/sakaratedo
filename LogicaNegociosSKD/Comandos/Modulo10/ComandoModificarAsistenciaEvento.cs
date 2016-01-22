using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo10
{
    public class ComandoModificarAsistenciaEvento : Comando<bool>
    {
        private List<Entidad> lista;

        public List<Entidad> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        public ComandoModificarAsistenciaEvento(List<Entidad> lista)
        {
            this.lista = lista;
        }
        public override bool Ejecutar()
        {
            try
            {
                IDaoAsistencia daoAsistencia = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAOAsistencia();
                bool resultado = daoAsistencia.ModificarAsistenciaEvento(lista);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
