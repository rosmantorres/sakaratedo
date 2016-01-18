using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoEliminarImplemento:Comando<bool>
    {
        private Entidad implemento;
        private Entidad dojo;

        public override bool Ejecutar()
        {

            try
            {
                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                return fabrica.ObtenerDAOImplemento().eliminarInventarioDatos(((Implemento)this.implemento).Id_Implemento,this.dojo);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
