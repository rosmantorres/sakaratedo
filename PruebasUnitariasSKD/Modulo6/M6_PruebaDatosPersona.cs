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
        private String _telefono1;
        private String _telefono2;

        private DominioSKD.Persona _per;
        private DominioSKD.Telefono _tel1;
        private DominioSKD.Telefono _tel2;



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
            this._telefono1 = "04141234325";
            this._telefono2 = "04125436734";

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

            this._tel1 = new Telefono();
            this._tel2 = new Telefono();

            this._tel1.Numero = this._telefono1;
            this._tel2.Numero = this._telefono2;

        }

        [Test]
        public void Prueba1NoNulo()
        {
            Assert.IsNotNull(this._per);
            Assert.IsNotNull(this._tel1);
            Assert.IsNotNull(this._tel2);
        }

        [Test]
        public void Prueba2_1SetGetPersona()
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
        public void Prueba2_2SetGetTelefono()
        {
            Assert.AreEqual(this._tel1.Numero, this._telefono1);
            Assert.AreEqual(this._tel2.Numero, this._telefono2);
        }

        [Test]
        public void Prueba3_1SetAddTelefono()
        {
            this._per.agregarTelefono(this._tel1);
            this._per.agregarTelefono(this._tel2);

            Assert.AreEqual(this._per.Telefonos.Count, 2);
            Assert.IsTrue(this._per.Telefonos.Contains(this._tel1));
            Assert.IsTrue(this._per.Telefonos.Contains(this._tel2));
        }

        [Test]
        public void Prueba4_1GuardarNuevaPersona()
        {
            DatosSKD.Modulo6.BDUsuarios.GuardarDatosDePersona(this._per);
            Assert.AreNotEqual(this._per.ID, -1);
        }

        [Test]
        public void Prueba4_2GuardarNuevosTelefonos()
        {
            DatosSKD.Modulo6.BDUsuarios.GuardarTelefonos(this._per);

            Assert.AreNotEqual(this._tel1.ID, -1);
            Assert.AreNotEqual(this._tel2.ID, -1);
        }


        [TestFixtureTearDown]
        public void Salir(){
            if (this._per.ID != -1)
            {
                BDConexion con = new BDConexion();
                con.EjecutarQuery("DELETE FROM dbo.TELEFONO WHERE PERSONA_per_id = " + this._per.ID.ToString());
                con = new BDConexion();
                con.EjecutarQuery("DELETE FROM dbo.PERSONA WHERE per_id = " + this._per.ID.ToString());
            }
           
        }
    }
}
