using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DominioSKD;
using DatosSKD.InterfazDAO.Modulo15;
using ExcepcionesSKD.Modulo15.ExcepcionComando;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo15
{
    public class ComandoConsultarTodosImplementos : Comando<List<Entidad>>
    {

        public override List<Entidad> Ejecutar()
        {
            List<Entidad> lista=new List<Entidad>();
            try
            {
                lista = FabricaDAOSqlServer.ObtenerDAOImplemento().listarInventarioDatos(this.LaEntidad);

            }
            catch (ExcepcionComandoConsultarTodosImplementos ex)
            {
                ex = new ExcepcionComandoConsultarTodosImplementos("Error en Comando consultar todos implementos", new Exception());
                Logger.EscribirError("Error en Comando consultar todos implementos", ex);
                throw ex;

            }

            catch (ExceptionSKD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                Logger.EscribirError("Error en Comando consultar todos implementos", ex);
                throw ex;
            }
            return lista;
        }
    }
}
