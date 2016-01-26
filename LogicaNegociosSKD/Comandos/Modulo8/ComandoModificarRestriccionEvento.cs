using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoModificarRestriccionEvento : Comando<Boolean>
    {
        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ComandoModificarRestriccionEvento(Entidad nuevaEntidad) 
            :base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override Boolean Ejecutar()
        {
            Boolean resultado = false;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            IDaoRestriccionEvento daoRestriccionEvento = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionEvento();

            try
            {

                resultado = daoRestriccionEvento.ModificarRestriccionEvento(this.LaEntidad);

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return resultado;

        }

    }
}
