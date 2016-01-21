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
    public class ComandoEliminarImplemento:Comando<bool>
    {
        public Entidad dojo;
        public override bool Ejecutar()
        {

            try
            {
                 ((Dojo)this.dojo).Dojo_Id=((Implemento)LaEntidad).Stock_Minimo_Implemento;
                return FabricaDAOSqlServer.ObtenerDAOImplemento().eliminarInventarioDatos(((Implemento)this.LaEntidad).Id_Implemento, this.dojo);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
