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
    public class ComandoUsuarioDojo : Comando<int>
    {

        private string usuario;
        public override int Ejecutar()
        {

            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            IDaoImplemento daoImplemeto = fabrica.ObtenerDAOImplemento();
            try
            {
               return daoImplemeto.usuarioImplementoDatos(this.usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
