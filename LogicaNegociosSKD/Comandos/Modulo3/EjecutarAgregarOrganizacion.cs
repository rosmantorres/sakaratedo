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
    public class EjecutarAgregarOrganizacion : Comando<bool>
    {

        public EjecutarAgregarOrganizacion(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }


        public override bool Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = fabrica.ObtenerDaoOrganizacion();
            miDaoOrganizacion.Agregar(this.LaEntidad); 
            return false;
        }
 

    }
}
