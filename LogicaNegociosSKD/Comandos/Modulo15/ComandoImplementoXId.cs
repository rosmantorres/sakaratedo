using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{    
    public class ComandoImplementoXId:Comando<Entidad>
    {
        private Entidad dojo;
        private Entidad implemento;

        public override Entidad Ejecutar()
        {

            try
            {
                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                return fabrica.ObtenerDAOImplemento().ConsultarXId(this.implemento);

              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
