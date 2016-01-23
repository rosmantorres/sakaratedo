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

        

        public override int Ejecutar()
        {

            IDaoImplemento daoImplemeto = FabricaDAOSqlServer.ObtenerDAOImplemento();
            try
            {
               return daoImplemeto.usuarioImplementoDatos(((Usuario)this.LaEntidad)._Nombre);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
