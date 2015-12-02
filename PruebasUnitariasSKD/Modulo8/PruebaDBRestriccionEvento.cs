using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;

namespace PruebasUnitariasSKD.Modulo8
{
    [TestFixture]
    public class PruebaDBRestriccionEvento
    {
        #region Atributos
        private RestriccionEvento elResEvento;
        private CintaSimple laCinta1;
        private CintaSimple laCinta2;
        List<CintaSimple> lasCintas;

        private EventoSimple elEvento;
        List<EventoSimple> losEventos;
        private PersonaSimple laPersona;
        List<PersonaSimple> lasPersinas;
        #endregion

        #region SetUp
        [SetUp]
        public void Init()
        {
            DateTime fechaInicio = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime fechaFin = new DateTime(2009, 5, 1, 1, 1, 1);
            Horario horario = new Horario(1, fechaInicio, fechaFin, 10, 11);
            Categoria categoria = new Categoria(15, 16, "verde", "amarillo", "masculino");
            TipoEvento tipoEvento = new TipoEvento(1, "Pase de Cinta");
            Ubicacion ubicacion = new Ubicacion("10.499607", "66.788419", "Caracas", "Miranda", "NULL");
            Persona persona = new Persona();
            categoria.Id_categoria = 1;
            persona.ID = 33;
            ubicacion.Id_ubicacion = 1;



            lasCintas = new List<CintaSimple>();
                laCinta1 = new CintaSimple();
                laCinta1.IdCinta = 1;
                laCinta1.ColorCinta = "Blanco";
                laCinta2 = new CintaSimple();
                laCinta2.IdCinta = 2;
                laCinta2.ColorCinta = "Amarillo";
            lasCintas.Add(laCinta1);
            lasCintas.Add(laCinta2);

            elResEvento = new RestriccionEvento();
            elResEvento.IdEvento = 5;
            elResEvento.Descripcion = "Pruebas UnitariasRE";
            elResEvento.EdadMinima = 14;
            elResEvento.EdadMaxima = 20;
            elResEvento.Sexo = "B";
            elResEvento.IdEvento = 5;
            elResEvento.NombreEvento = "Pruebas UnitariasE";
            elResEvento.ListaCintas = lasCintas;
        }
        #endregion        

        #region PruebasUnitarias


        [Test]
        public void PruebaAgregarRestriccionEvento()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            Boolean auxiliar = bdRestriccionEvento.AgregarRestriccionEvento(elResEvento);
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

        [Test]
        public void PruebaModificarRestriccionEvento()
        {
            elResEvento.Descripcion = "Pruebas UnitariasREEEE";
            elResEvento.EdadMinima = 15;
            elResEvento.EdadMaxima = 21;
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            Boolean auxiliar = bdRestriccionEvento.ModificarRestriccionEvento(elResEvento);
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

        [Test]
        public void PruebaEliminarRestriccionEvento()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            Boolean auxiliar = bdRestriccionEvento.EliminarRestriccionEvento(elResEvento);
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

        [Test]
        public void PruebaAgregarRh_cinta()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            Boolean auxiliar = bdRestriccionEvento.AgregarRh_Cinta(elResEvento,1);
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

        [Test]
        public void PruebaEliminarRh_Cinta()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            Boolean auxiliar = bdRestriccionEvento.EliminarRh_Cinta(elResEvento);
            Console.Out.WriteLine(auxiliar);
            Assert.True(auxiliar);
        }

        [Test]
        public void PruebaConsultarEventosSinRestriccion()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            List<EventoSimple> listaEventoS = bdRestriccionEvento.ConsultarEventosSinRestriccion();
            Assert.Greater(listaEventoS.Count, 0);
        }

        [Test]
        public void PruebaConsultarEventosConRestriccion()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            List<RestriccionEvento> resEventos = bdRestriccionEvento.ConsultarEventosConRestriccion();
            Assert.Greater(resEventos.Count, 0);
        }

        [Test]
        public void PruebaConsultarCintasRestriccionEvento()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            List<CintaSimple> listaCintas = bdRestriccionEvento.ConsultarCintasRestriccionEvento(1);
            Assert.Greater(listaCintas.Count, 0);
        }

        [Test]
        public void PruebaAtletasCumplenRestriccionEvento()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            List<PersonaSimple> listaPersonas = bdRestriccionEvento.AtletasCumplenRestriccionEvento(1);
            Assert.Greater(listaPersonas.Count, 0);
        }

        [Test]
        public void PruebaEventosQuePuedeAsistirAtleta()
        {
            DatosSKD.Modulo8.BDRestriccionEvento bdRestriccionEvento = new DatosSKD.Modulo8.BDRestriccionEvento();
            List<EventoSimple> listaEventos = bdRestriccionEvento.EventosQuePuedeAsistirAtleta(1);
            Assert.Greater(listaEventos.Count, 0);
        }



        #endregion

        #region TearDown
        [TearDown]

        public void clean()
        {
            elResEvento = null;
            laCinta1 = null;
            laCinta2 = null;
            lasCintas = null;
            elEvento = null;
            losEventos = null;
            laPersona = null;
            lasPersinas = null;
        }
        #endregion
    }
}