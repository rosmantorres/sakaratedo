using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo3;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo3;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo3;
using DatosSKD.DAO.Modulo3;

namespace PruebasUnitariasSKD.Modulo3
{
    [TestFixture]
    class PUDaoOrganizacion
    {
        private Comando<bool> miComando;
        private FabricaDAOSqlServer fabricaDAO;
        private Entidad miEntidad;
    }
}
