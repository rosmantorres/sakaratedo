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
    public class EjecutarConsultarXIdOrganizacion : Comando<Entidad>
    {
        public EjecutarConsultarXIdOrganizacion(Entidad nuevaEntidad)
            : base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override Entidad Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            IDaoOrganizacion miDaoOrganizacion = fabrica.ObtenerDaoOrganizacion();
            Entidad _miEntidad = miDaoOrganizacion.ConsultarXId(this.LaEntidad);

            if (_miEntidad != null)
            {
                return _miEntidad;
            }
            else
            {
                return null;

            }
            
        }
    }
}
