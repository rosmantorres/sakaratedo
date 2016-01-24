using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoEliminarImplemento:Comando<bool>
    {
        public Entidad dojo;

        public Entidad Dojo {
            set { this.dojo = value; }

            get { return this.dojo; }
        }

        public override bool Ejecutar()
        {

            try
            {
                return FabricaDAOSqlServer.ObtenerDAOImplemento().eliminarInventarioDatos(((Implemento)this.LaEntidad).Id_Implemento, this.dojo);

            }
            catch (ExcepcionComandoEliminarImplemento ex)
            {
                ex = new ExcepcionComandoEliminarImplemento("Error en Comando eliminar implemento", new Exception());
                Logger.EscribirError("Error en Comando eliminar implemento", ex);
                throw ex;

            }

            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("Error en Comando eliminar implemento", ex);
                throw ex;
            }
        }
    }
}
