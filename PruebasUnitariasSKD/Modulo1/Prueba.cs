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
            Console.WriteLine("hola:" +login.hash("hola"));
            Console.WriteLine("hol:" + login.hash("hol"));
            Console.WriteLine("1234:" + login.hash("1234"));
            Console.WriteLine("1235:" + login.hash("1235"));

            Assert.AreEqual(login.hash("hola"), login.hash("hola"));
            Assert.AreEqual(login.hash("1234"), login.hash("1234"));
            Assert.AreNotEqual(login.hash("hol"), login.hash("hola"));
            Assert.AreNotEqual(login.hash("1235"), login.hash("1234"));
        }
    }
}
