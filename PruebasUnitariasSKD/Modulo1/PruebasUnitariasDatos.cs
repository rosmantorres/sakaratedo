using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Modulo1;
using PruebasUnitariasSKD.Modulo1;
using DominioSKD;
using ExcepcionesSKD;


namespace PruebasUnitariasSKD.Modulo1.Datos
{
    [TestFixture]
    class PruebasUnitariasLogin
    {
        [SetUp]
        protected  void parametros()
        {
           
        }
         // Prueba unitaria del metodo IniciarSesion() de forma erronea
        [Test]
        [ExpectedException(typeof(ExceptionSKDConexionBD))]
        public  void PruebaInicioSesionFallida()
        {
            Cuenta laCuenta = new Cuenta();
            laCuenta = DatosSKD.Modulo1.BDLogin.ObtenerUsuario(RecursosPU_Mod1.pruebaErrorCorreo);

        }

       
    }
}
