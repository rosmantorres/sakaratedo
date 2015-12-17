using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo5;

namespace PruebasUnitariasSKD.Modulo5
{
    [TestFixture]
    public class PruebaBDCinta
    {
        List<Cinta> laLista;
        Cinta laCinta;
        [SetUp]
        public void init(){
            laLista = new List<Cinta>();
            laCinta = new Cinta();
        }

        [TearDown]

        public void clean()
        {
            laLista = null;
        }

        [Test]
        public void pruebaVacioListaCintas()
        {
            laLista = BDCinta.ListarCintas();
            Assert.IsNotNull(laLista);
        }

        [Test]
        public void pruebaCantidadCintas()
        {
            laLista = BDCinta.ListarCintas();
            Assert.AreEqual(8, laLista.ToArray().Length);
        }

        [Test]
        public void pruebaVacioDetalleCinta()
        {
            laCinta = BDCinta.DetallarCinta(2);
            Assert.IsNotNull(laCinta);
        }

        [Test]
        public void pruebaVacioListaCintasXOrganizacion()
        {
            laLista = BDCinta.ListarCintasXOrganizacion(1);
            Assert.IsNotNull(laLista);
        }

        [Test]
        public void pruebaVacioCintaAgregar()
        {
            laCinta = new Cinta("Negro", "4to Kyu", "Nivel superior",4, "Maestro superior",null,true);            
            BDCinta.AgregarCinta(laCinta);
            Assert.IsNotNull(laCinta);
        }

        [Test]
        public void pruebaCintaModificar()
        {
            laCinta = new Cinta("Blanco", "4to Kyu", "Nivel superior", 4, "Maestro superior", null, true); 
            BDCinta.ModificarCinta(laCinta);
            Assert.AreEqual("Blanco", laCinta.Color_nombre);
            
        }



    }
}
