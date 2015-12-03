using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD;
using DatosSKD.Modulo14;
using DominioSKD;
using LogicaNegociosSKD.Modulo14;
using LogicaNegociosSKD;


namespace PruebasUnitariasSKD.Modulo14
{
    [TestFixture]
    public class PruebaBDDiseno
    {
        private BDDiseño BaseDeDatoDiseno;
        [SetUp]
        public void Init()
        {
            BaseDeDatoDiseno = new BDDiseño();
        }
        
        /// <summary>
        /// Prueba para el metodo gurdar diseno en la BD
        /// </summary>
        [Test]
        public void PruebaGuardarDiseñoBD()
        {
            Planilla planilla = new Planilla(2, "RETIRO COMPETENCIA", true, "RETIRO");
            Diseño diseno= new Diseño(1,"contenido de la planilla");
            Assert.IsTrue(BaseDeDatoDiseno.GuardarDiseñoBD(diseno, planilla));
        }
        /// <summary>
        /// Prueba para el metodo gurdar diseno en la BD
        /// </summary>
       /* [Test]
        public void PruebaConsultarDiseño()
        {
            Planilla planilla = new Planilla(2, "RETIRO COMPETENCIA", true, "RETIRO");
            Diseño diseno = new Diseño(1, "contenido de la planilla");
            Assert.IsTrue(BaseDeDatoDiseno.ConsultarDiseño(1));
        }*/
        /// <summary>
        /// Prueba para el metodo modificar diseno en la BD
        /// </summary>
        [Test]
        public void PruebaModificarDiseño()
        {
            Planilla planilla = new Planilla(2, "RETIRO COMPETENCIA", true, "RETIRO");
            Diseño diseno = new Diseño(1, "contenido de la modificado");
            Assert.IsTrue(BaseDeDatoDiseno.ModificarDiseño(diseno));
        }
    }
}
