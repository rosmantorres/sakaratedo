using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo15;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoDojoId :Comando<Entidad>
    {
        public override Entidad Ejecutar()
        {

            IDaoImplemento daoImplemeto = FabricaDAOSqlServer.ObtenerDAOImplemento();
            try
            {
                return daoImplemeto.DetallarDojo(this.LaEntidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
