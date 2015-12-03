using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo14;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo14;

namespace PruebasUnitariasSKD.Modulo14
{
   [TestFixture]
    public class PruebaLogicaDiseno
    {
        private LogicaDiseño logica;
       
       [SetUp]
       public void Init()
       {
           LogicaDiseño logica = new LogicaDiseño();
       }
       /// <summary>
       /// Prueba para el metodo agregar Planilla Creadas
       /// </summary>
       [Test]
       public void PruebaAgregarDiseno()
       {
           LogicaDiseño logica = new LogicaDiseño();
           Planilla planilla = new Planilla(5, "RETIRO COMPETENCIA", true, "RETIRO");
           Diseño diseno = new Diseño(3, "contenido de la planilla");
           Assert.IsTrue(logica.ModificarDiseño(diseno));
       }
       /// <summary>
       /// Prueba para el metodo modificar diseno planilla
       /// </summary>
       [Test]
       public void PruebaModificarDiseño()
       {
           LogicaDiseño logica = new LogicaDiseño();
           Planilla planilla = new Planilla(3, "RETIRO COMPETENCIA", true, "RETIRO");
           Diseño diseno = new Diseño(6, "contenido de la planilla");
           Assert.IsTrue(logica.AgregarDiseño(diseno, planilla));
       }

      [TearDown]
      public void Limpiar()
       {

           logica = null;
       }

    }
}
