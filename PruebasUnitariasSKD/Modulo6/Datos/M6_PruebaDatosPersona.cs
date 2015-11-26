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
        private DominioSKD.Persona _perRepresentante;



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
            this._core.Primario = this._correo1_pri;
            this._per.agregarEmail(this._core);

            this._core = new Correo(this._correo2);
            this._core.Primario = this._correo2_pri;
            this._per.agregarEmail(this._core);

        }

        [Test]
        public void Prueba1GuardarNuevaPersona()
        {
            int idp;
            int idContacto;

            Persona _perContacto;

            _perContacto = new Persona();

            _perContacto.Nombre = "Raiza";
            _perContacto.Apellido = "Rojas";
            _perContacto.Sexo = Sexo.Femenino;
            Correo cc = new Correo("raiza08@gmail.com");
            cc.Primario = true;
            _perContacto.agregarEmail(cc);
            Telefono tt = new Telefono();
            tt.Numero = "05135254981";
            _perContacto.agregarTelefono(tt);


            this._per.ContatoEmergencia = _perContacto;





            DatosSKD.Modulo6.BDUsuarios.GuardarDatosDePersona(this._per);
            Assert.AreNotEqual(this._per.ID, -1);
            Assert.AreNotEqual(this._per.ContatoEmergencia.ID, -1);

            idContacto = _perContacto.ID;

            idp = this._per.ID;
            this._per = null;

            this._per = DatosSKD.Modulo6.BDUsuarios.GetInfoPersonaByID(idp);

            DatosSKD.Modulo6.BDUsuarios.GetContacto(this._per);

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

            Assert.IsNotNull(this._per.Correos);
            Assert.IsNotNull(this._per.Telefonos);

            Assert.AreEqual(this._per.Correo.ToString(), this._correo1);

            Assert.IsNotNull(this._per.ContatoEmergencia);
            Assert.AreEqual(this._per.ContatoEmergencia.ID, idContacto);
            
        }

        [Test]
        public void Prueba1GuardarNuevaPersonaRepresentante()
        {
            this._per.ContatoEmergencia = null;
            this._perRepresentante = new Persona();

            this._perRepresentante.Nombre = "Romulo Jose";
            this._perRepresentante.Apellido = "Rodriguez Moreno";

            this._perRepresentante.FechaNacimiento = new DateTime(1952, 09, 05);

            this._perRepresentante.Nacionalidad = "Venezolano";
            this._perRepresentante.DocumentoID = new DocumentoIdentidad();
            this._perRepresentante.DocumentoID.Tipo = TipoDocumento.Cedula;
            this._perRepresentante.DocumentoID.TipoCedula = TipoCedula.Nacional;
            this._perRepresentante.DocumentoID.Numero = 10372649;
            this._perRepresentante.Sexo = Sexo.Masculino;
            Correo cc = new Correo("rjrodroge@eltercera.comv.e");
            cc.Primario = true;
            this._perRepresentante.agregarEmail(cc);
            Telefono tt = new Telefono();
            tt.Numero = "16542510514";
            this._perRepresentante.agregarTelefono(tt);

            this._perRepresentante.addRepresentado(this._per);


            DatosSKD.Modulo6.BDUsuarios.GuardarDatosDeRepresentante(this._perRepresentante);

            Assert.AreNotEqual(this._perRepresentante, -1);
            Assert.AreNotEqual(this._per, -1);

            Persona carga = DatosSKD.Modulo6.BDUsuarios.GetInfoPersonaByID(this._perRepresentante.ID);

            DatosSKD.Modulo6.BDUsuarios.CargarRepresentados(carga);

            Assert.AreEqual(carga.ID, this._perRepresentante.ID);
            Assert.AreEqual(this._per.ID, this._perRepresentante.Representados[0].ID);


        }

        [TearDown]
        public void Salir(){

            if (this._perRepresentante != null)
            {
                this.query("DELETE FROM dbo.TELEFONO WHERE PERSONA_per_id = " + this._perRepresentante.ID.ToString());
                this.query("DELETE FROM dbo.EMAIL WHERE PERSONA_per_id = " + this._perRepresentante.ID);
                this.query("DELETE FROM dbo.RELACION WHERE PERSONA_per_id = " + this._perRepresentante.ID.ToString());
                this.query("DELETE FROM dbo.PERSONA WHERE per_id = " + this._perRepresentante.ID.ToString());
            }

            if (this._per.ID != -1)
            {
                if (this._tel1 != null)
                {
                    this.query("DELETE FROM dbo.TELEFONO WHERE PERSONA_per_id = " + this._per.ID.ToString());
                    if (this._per.ContatoEmergencia != null && this._per.ContatoEmergencia.Telefonos != null)
                    {
                        this.query("DELETE FROM dbo.TELEFONO WHERE PERSONA_per_id = " + this._per.ContatoEmergencia.ID.ToString());
                    }

                }
                if (this._core != null)
                {
                    this.query("DELETE FROM dbo.EMAIL WHERE PERSONA_per_id = " + this._per.ID.ToString());
                    if (this._per.ContatoEmergencia != null && this._per.ContatoEmergencia.Correos != null)
                    {
                        this.query("DELETE FROM dbo.EMAIL WHERE PERSONA_per_id = " + this._per.ContatoEmergencia.ID.ToString());
                    }
                }
                if (this._per.ContatoEmergencia != null)
                {
                    this.query("DELETE FROM dbo.RELACION WHERE PERSONA_per_id = " + this._per.ID.ToString());
                    this.query("DELETE FROM dbo.PERSONA WHERE per_id = " + this._per.ContatoEmergencia.ID.ToString());
                }
                this.query("DELETE FROM dbo.PERSONA WHERE per_id = " + this._per.ID.ToString());
            }
           
        }

        private void query(String query)
        {
            BDConexion con;
            con = new BDConexion();
            con.EjecutarQuery(query);
        }
    }
}
