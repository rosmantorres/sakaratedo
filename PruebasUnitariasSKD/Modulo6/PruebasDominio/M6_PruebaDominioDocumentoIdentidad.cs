using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;


namespace PruebasUnitariasSKD.Modulo6
{
    class M6_PruebaDominioDocumentoIdentidad
    {
        private DominioSKD.DocumentoIdentidad _ci;
        private int _cedula;

        [SetUp]
        public void PruebaSetup()
        {
            this._cedula = 1955154;
            this._ci = new DocumentoIdentidad();
            this._ci.Numero = this._cedula;
        }

        [Test]
        public void PruebaNoNulo()
        {
            Assert.IsNotNull(this._ci);
        }

        [Test]
        public void PruebaSetGetCedulaNacional()
        {
            
            this._ci.Tipo = DominioSKD.TipoDocumento.Cedula;
            this._ci.TipoCedula = DominioSKD.TipoCedula.Nacional;
            Assert.AreEqual(this._ci.ToString(), "V-" + this._cedula.ToString("N0"));

        }

        [Test]
        public void PruebaSetGetCedulaExtanjera()
        {

            this._ci.Tipo = DominioSKD.TipoDocumento.Cedula;
            this._ci.TipoCedula = DominioSKD.TipoCedula.Extranjera ;
            Assert.AreEqual(this._ci.ToString(), "E-" + this._cedula.ToString("N0"));

        }

        [Test]
        public void PruebaSetGetCedulaPasaporte()
        {

            this._ci.Tipo = DominioSKD.TipoDocumento.Pasaporte;
            Assert.AreEqual(this._ci.ToString(), "P-" + this._cedula.ToString("N0"));

        }

       
    }
}
