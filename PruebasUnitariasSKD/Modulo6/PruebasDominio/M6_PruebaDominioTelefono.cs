using System;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD;

namespace PruebasUnitariasSKD.Modulo6
{
    [TestFixture]
    class M6_PruebaDominioTelefono
    {
        private int _dbId;
        private String _number;
        private DominioSKD.Telefono _telf;


        [SetUp]
        public void PruebaSetup()
        {
            this._dbId = 16544;
            this._number = "04144513563";
            this._telf = new DominioSKD.Telefono(this._dbId);
        }
        
        [Test]
        public void PruebaNoNulo()
        {
            Assert.IsNotNull(this._telf);
        }
        
        [Test]
        public void PruebaSetGet()
        {
            this._telf.Numero = this._number;

            Assert.AreEqual(this._telf.ID, this._dbId);
            Assert.AreEqual(this._telf.Numero, this._number);
            Assert.AreEqual(this._telf.ToString(), this._number.Substring(0,4) + "-" +this._number.Substring(4));
            Console.WriteLine(this._telf);
        }

        [Test]
        [ExpectedException(typeof(InformacionPersonalInvalidaException))]
        public void PruebaExceptionLetraEnNumero()
        {
            this._telf.Numero = "B4664514224";
        }

        [Test]
        [ExpectedException(typeof(InformacionPersonalInvalidaException))]
        public void PruebaExceptionNumeroCorto()
        {
            this._telf.Numero = "446622";
        }
        
    }
}
