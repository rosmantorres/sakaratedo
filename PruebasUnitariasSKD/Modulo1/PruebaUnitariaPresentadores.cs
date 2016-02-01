using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Interfaz_Presentadores.Modulo1;
using Interfaz_Presentadores.Modulo2;
using DominioSKD.Entidades.Modulo2;



namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    class PruebaUnitariaPresentadores
    {

        [SetUp]
        protected  void parametros()
        {
 
        }

        [Test]
        public void M1PruebaValidarCaracteresLogin()
        {
            ValidacionesM1 lg = new ValidacionesM1();
            bool _respuesta;
            _respuesta = lg.ValidarCaracteres(RecursosPU_Mod1.Descripcion);
            Assert.AreEqual(true, _respuesta);
        }

        [Test]
        public void M1PruebaValidarCaracteresLoginIncorrecto()
        {
            ValidacionesM1 lg = new ValidacionesM1();
            bool _respuesta;
            _respuesta = lg.ValidarCaracteres(RecursosPU_Mod1.DescripcionInvalida);
            Assert.AreEqual(false, _respuesta);
        }

        [Test]
        public void M1PruebaValidarCaracteresLogin2()
        {
            ValidacionesM1 lg = new ValidacionesM1();
            bool _respuesta;
            _respuesta = lg.ValidarCaracteres(RecursosPU_Mod1.Descripcion, false);
            Assert.AreEqual(true, _respuesta);
        }

        [Test]
        public void M1PruebaValidarCaracteresLogin2Incorrecto()
        {
            ValidacionesM1 lg = new ValidacionesM1();
            bool _respuesta;
            _respuesta = lg.ValidarCaracteres(RecursosPU_Mod1.DescripcionInvalida, false);
            Assert.AreEqual(false, _respuesta);
        }

        [Test]
        public void M1PruebaValidarCamposVacios()
        {
            ValidacionesM1 lg = new ValidacionesM1();
            bool _respuesta;
            List<string> pruebalista = new List<string>();
            pruebalista.Add(RecursosPU_Mod1.Descripcion);
            _respuesta = lg.ValidarCamposVacios(pruebalista);
            Assert.AreEqual(true, _respuesta);
        }

        [Test]
        public void M1PruebaValidarCamposVaciosIncorrecto()
        {
            ValidacionesM1 lg = new ValidacionesM1();
            bool _respuesta;
            List<string> pruebalista = new List<string>();
            pruebalista.Add(RecursosPU_Mod1.Vacio);
            _respuesta = lg.ValidarCamposVacios(pruebalista);
            Assert.AreEqual(false, _respuesta);
        }


    }
}
