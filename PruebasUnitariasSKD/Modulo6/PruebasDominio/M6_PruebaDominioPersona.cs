using System;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using ExcepcionesSKD;
using System.Net.Mail;

namespace PruebasUnitariasSKD.Modulo6
{
    [TestFixture]
    class M6_PruebaDominioPersona
    {
        private int _dbid;
        private String _nombre;
        private String _apellido;
        private Double _peso;
        private Double _estatura;
        private String _alergias;
        private DateTime _fechaNacimiento;
        private DocumentoIdentidad _documentoID;
        private String _direccion;

        private DominioSKD.Persona _per;


        [SetUp]
        public void PruebaSetup()
        {
            this._dbid = 45514;
            this._nombre = "Rómulo1";
            this. _apellido = "Rodríguez1";
            this._peso = 85.64;
            this._estatura = 1.75;
            this._alergias = "Ninguna2";
            this._fechaNacimiento = new DateTime(1990,10,05);
            this._documentoID = new DocumentoIdentidad();
            this._documentoID.Numero = 19135536;
            this._documentoID.Tipo = TipoDocumento.Cedula;
            this._documentoID.TipoCedula = TipoCedula.Nacional;
            this._direccion = "La vega Los Mangos";

            this._per = new DominioSKD.Persona(this._dbid);
        }

        [Test]
        public void PruebaNoNulo()
        {
            Assert.IsNotNull(this._per);
        }

        [Test]
        public void PruebaSetGet()
        {
            this._per.Nombre = this._nombre;
            this._per.Apellido = this._apellido;
            this._per.Peso = this._peso;
            this._per.Estatura = this._estatura;
            this._per.Alergias = this._alergias;
            this._per.FechaNacimiento = this._fechaNacimiento;
            this._per.DocumentoID = this._documentoID;
            this._per.Direccion = this._direccion;
            this._per.ContactoEmergencia = this._per;

            Assert.AreEqual(this._per.Nombre, this._nombre);
            Assert.AreEqual(this._per.Apellido, this._apellido);
            Assert.AreEqual(this._per.Peso, this._peso);
            Assert.AreEqual(this._per.Estatura, this._estatura);
            Assert.AreEqual(this._per.Alergias, this._alergias);
            Assert.AreEqual(this._per.FechaNacimiento, this._fechaNacimiento);
            Assert.AreEqual(this._per.DocumentoID, this._documentoID);
            Assert.AreEqual(this._per.Direccion, this._direccion);
            Assert.AreEqual(this._per.Edad, (DateTime.Now - this._fechaNacimiento).Days / 365);
            Assert.AreEqual(this._per, this._per.ContactoEmergencia);

           // Console.WriteLine(DatosSKD.Modulo6.BDUsuarios.AgregarPersona(this._per));
        }

        /*[Test]
        public void PruebaCorreos()
        {
            String c1 = "rodriguezrjrr@gmail.com";
            String c2 = "rrodriguez@eltercera.com.ve";
            String c3 = "rjrodriguezr.12@est.ucab.edu.ve";

            this._per.agregarEmail(c3, false);
            this._per.agregarEmail(c1, true);
            this._per.agregarEmail(c2, false);

            Assert.AreEqual(this._per.Correo.get, c1);
        }*/

        [Test]
        public void PruebaTelefonos()
        {
            Telefono t1 = new Telefono();
            Telefono t2 = new Telefono();

            t1.Numero = "04144516415";

            t2.Numero = "02314516315";

            Telefono[] array = { t1, t2 };

            this._per.agregarTelefono(t1);
            this._per.agregarTelefono(t2);

            Assert.AreEqual(this._per.Telefonos, array);
        }
    }
}
