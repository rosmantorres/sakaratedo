using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo3;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo3
{
    public class EjecutarComboOrganizaciones : Comando<List<Entidad>>
    {

        public override List<Entidad> Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = fabrica.ObtenerDaoOrganizacion();
            List<Entidad> _miLista = miDaoOrganizacion.ComboOrganizaciones();
            if (_miLista != null)
            {
                return _miLista;
            }
            else
            {
                return null;

            }
        }
    }
}
