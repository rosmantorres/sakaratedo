using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;

namespace PruebasUnitariasSKD.Modulo6
{
    [TestFixture]
    class M6_PruebaDatosPersona
    {
        private String _nombre;
        private String _apellido;
        private Double _peso;
        private Double _estatura;
        private String _alergias;
        private DateTime _fechaNacimiento;
        private DocumentoIdentidad _documentoID;
        private String _direccion;
        private String _nacionalidad;

        private DominioSKD.Persona _per;


        [TestFixtureSetUp]
        public void PruebaSetup()
        {
            this._nombre = "Rómulo";
            this._apellido = "Rodríguez";
            this._peso = 85.64;
            this._estatura = 1.75;
            this._alergias = "Ninguna";
            this._nacionalidad = "Venezolana";
            this._fechaNacimiento = new DateTime(1990, 10, 05);
            this._documentoID = new DocumentoIdentidad();
            this._documentoID.Numero = 19135536;
            this._documentoID.Tipo = TipoDocumento.Cedula;
            this._documentoID.TipoCedula = TipoCedula.Nacional;
            this._direccion = "La vega Los Mangos";

            this._per = new DominioSKD.Persona();

            this._per.Nombre = this._nombre;
            this._per.Apellido = this._apellido;
            this._per.Peso = this._peso;
            this._per.Nacionalidad = this._nacionalidad;
            this._per.Estatura = this._estatura;
            this._per.Alergias = this._alergias;
            this._per.FechaNacimiento = this._fechaNacimiento;
            this._per.DocumentoID = this._documentoID;
            this._per.Direccion = this._direccion;
            this._per.ContatoEmergencia = this._per;
        }

        [Test]
        public void Prueba1NoNulo()
        {
            Assert.IsNotNull(this._per);
        }

        [Test]
        public void Prueba2SetGet()
        {

            Assert.AreEqual(this._per.Nombre, this._nombre);
            Assert.AreEqual(this._per.Apellido, this._apellido);
            Assert.AreEqual(this._per.Peso, this._peso);
            Assert.AreEqual(this._per.Estatura, this._estatura);
            Assert.AreEqual(this._per.Alergias, this._alergias);
            Assert.AreEqual(this._per.FechaNacimiento, this._fechaNacimiento);
            Assert.AreEqual(this._per.DocumentoID, this._documentoID);
            Assert.AreEqual(this._per.Direccion, this._direccion);
            Assert.AreEqual(this._per.Edad, (DateTime.Now - this._fechaNacimiento).Days / 365);
            Assert.AreEqual(this._per, this._per.ContatoEmergencia);
        }

        [Test]
        public void Prueba3GuardarNuevaPersona()
        {
            DatosSKD.Modulo6.BDUsuarios.GuardarDatosDePersona(this._per);
            Assert.AreNotEqual(this._per.ID, -1);
        }

        [TestFixtureTearDown]
        public void Salir(){
            if (this._per.ID != -1)
            {
                BDConexion con = new BDConexion();
                con.Conectar();
                con.EjecutarQuery("DELETE FROM dbo.PERSONA WHERE per_id = " + this._per.ID.ToString());
            }
           
        }

    }
}
