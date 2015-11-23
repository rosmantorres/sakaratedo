using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo1;

namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    class Prueba
    {
        [SetUp]
        protected  void parametros()
        {
           
        }
      
        [Test]
        public static void Prueba1()
        {
            login lg = new login();
            string[] resp = lg.iniciarSesion("man", "12345");
            Assert.AreEqual(resp, null);

        }
        [Test]
        public void PruebaHash()
        {
            login lg = new login();
            Console.WriteLine("hola:" +lg.hash("hola"));
            Console.WriteLine("hol:" + lg.hash("hol"));
            Console.WriteLine("1234:" + lg.hash("1234"));
            Console.WriteLine("1235:" + lg.hash("1235"));

            Assert.AreEqual(lg.hash("hola"), lg.hash("hola"));
            Assert.AreEqual(lg.hash("1234"), lg.hash("1234"));
            Assert.AreNotEqual(lg.hash("hol"), lg.hash("hola"));
            Assert.AreNotEqual(lg.hash("1235"), lg.hash("1234"));
        }
    }
}
