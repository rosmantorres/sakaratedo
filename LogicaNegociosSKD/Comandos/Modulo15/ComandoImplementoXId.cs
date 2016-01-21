using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;

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
                return FabricaDAOSqlServer.ObtenerDAOImplemento().implementoInventarioDatos(((Implemento)this.LaEntidad).Id_Implemento);

              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
