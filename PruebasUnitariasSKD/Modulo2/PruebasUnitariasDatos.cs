using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Modulo1;
using DatosSKD.Modulo2;
using PruebasUnitariasSKD.Modulo1;
using DominioSKD;
using ExcepcionesSKD;


namespace PruebasUnitariasSKD.Modulo2
{
    [TestFixture]
    class PruebasUnitariasDatos
    {
        [SetUp]
        protected  void parametros()
        {
           
        }
        [Test]
        public void PruebaValidarconsultarRolesUsuario()
        {
            List<Rol> _respuesta;
            _respuesta = BDRoles.consultarRolesUsuario(RecursosPU_Mod1.Id);
            Assert.AreNotEqual(null, _respuesta);

        }

        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void PruebaValidarconsultarRolesUsuarioEXC()
        {
            List<Rol> _respuesta;
            _respuesta = BDRoles.consultarRolesUsuario(null);

        }

       
    }
}
