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
        private String _correo1;
        private String _correo2;
        private Boolean _correo1_pri;
        private Boolean _correo2_pri;

        private DominioSKD.Persona _per;
        private DominioSKD.Telefono _tel1;
        private DominioSKD.Correo _core;



        [SetUp]
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
            this._telefono2 = "02125635635";
            this._correo1 = "rodriguezrjrr@gmail.com";
            this._correo1_pri = true;
            this._correo2 = "rrodriguez@eltercera.com.ve";
            this._correo2_pri = false;

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
            this._tel1.Numero = this._telefono1;
            this._per.agregarTelefono(this._tel1);

            this._tel1 = new Telefono();
            this._tel1.Numero = this._telefono2;
            this._per.agregarTelefono(this._tel1);

            this._core = new Correo(this._correo1);
            this._per.agregarEmail(this._core, this._correo1_pri);

            this._core = new Correo(this._correo2);
            this._per.agregarEmail(this._core, this._correo2_pri);


        }

        [Test]
        public void Prueba1GuardarNuevaPersona()
        {
            int idp;

            DatosSKD.Modulo6.BDUsuarios.GuardarDatosDePersona(this._per);
            Assert.AreNotEqual(this._per.ID, -1);
            idp = this._per.ID;
            this._per = null;

            this._per = DatosSKD.Modulo6.BDUsuarios.GetInfoPersonaByID(idp);


            Assert.AreEqual(this._per.Nombre,this._nombre);
            Assert.AreEqual(this._per.Apellido,this._apellido);
            Assert.AreEqual(this._per.Peso,this._peso);
            Assert.AreEqual(this._per.Estatura,this._estatura);
            Assert.AreEqual(this._per.FechaNacimiento,this._fechaNacimiento);
            Assert.AreEqual(this._per.Alergias,this._alergias);
            Assert.AreEqual(this._per.Direccion,this._direccion);
            Assert.AreEqual(this._per.Nacionalidad,this._nacionalidad);
            Assert.AreEqual(this._per.DocumentoID.Numero,this._documentoID.Numero);
            Assert.AreEqual(this._per.DocumentoID.Tipo, this._documentoID.Tipo);
            Assert.AreEqual(this._per.DocumentoID.TipoCedula, this._documentoID.TipoCedula);

        }

        [TearDown]
        public void Salir(){

            BDConexion con;

            if (this._per.ID != -1)
            {
                if (this._tel1 != null)
                {
                    con = new BDConexion();
                    con.EjecutarQuery("DELETE FROM dbo.TELEFONO WHERE PERSONA_per_id = " + this._per.ID.ToString());
                }
                if (this._core != null)
                {
                    con = new BDConexion();
                    con.EjecutarQuery("DELETE FROM dbo.EMAIL WHERE PERSONA_per_id = " + this._per.ID.ToString());
                }
                con = new BDConexion();
                con.EjecutarQuery("DELETE FROM dbo.PERSONA WHERE per_id = " + this._per.ID.ToString());
            }
           
        }
    }
}
