using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD;
using PruebasUnitariasSKD.Modulo1;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo2;
using ExcepcionesSKD;


namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    class PruebasUnitariasDominio
    {
        private FabricaEntidades laFabrica;
        [SetUp]
        protected void parametros()
        {
            laFabrica = new FabricaEntidades();
        }
        // Prueba unitaria del metodo Cuenta() 
        [Test]
        public void PruebaConstructorCuenta1()
        {

            Cuenta cuenta = (Cuenta)laFabrica.ObtenerCuenta_M1() ;

            Assert.AreEqual(cuenta.PersonaUsuario._Id, 0);
            Assert.AreEqual(cuenta.PersonaUsuario._Nombre, RecursosPU_Mod1.Vacio);
            Assert.AreEqual(cuenta.PersonaUsuario._Apellido, RecursosPU_Mod1.Vacio);
            Assert.AreEqual(cuenta.Nombre_usuario, RecursosPU_Mod1.Vacio);
            Assert.AreEqual(cuenta.Contrasena, RecursosPU_Mod1.Vacio);
            Assert.AreEqual(cuenta.Imagen, RecursosPU_Mod1.Vacio);
        }
        // Prueba unitaria del metodo Cuenta(int elIdUsuario, String elNombreUsuario, String laContrasena) 
        [Test]
        public void PruebaConstructorCuenta2()
        {

            Cuenta cuenta =(Cuenta)laFabrica.ObtenerCuenta_M1
                ( RecursosPU_Mod1.usuario, 
                RecursosPU_Mod1.PruebaErrorClave,null, RecursosPU_Mod1.Vacio,(PersonaM1)laFabrica.ObtenerPersona_M1());

            Assert.AreEqual(cuenta.PersonaUsuario._Id, Int32.Parse(RecursosPU_Mod1.Id));
            Assert.AreEqual(cuenta.Nombre_usuario, RecursosPU_Mod1.usuario);
            Assert.AreEqual(cuenta.Contrasena, RecursosPU_Mod1.PruebaErrorClave);
            Assert.AreEqual(cuenta.Imagen, RecursosPU_Mod1.Vacio);

        }
        // Prueba unitaria del metodo   public Cuenta(String elNombreUsuario, String laContrasena,List<Rol> listaRoles)
        [Test]
        public void PruebaConstructorCuenta3()
        {
            List<Rol> listaRol = new List<Rol>();
            Rol elRol = new Rol();
            elRol.Id_rol = Int32.Parse(RecursosPU_Mod1.Id);
            elRol.Nombre = RecursosPU_Mod1.usuario.ToString();
            listaRol.Add(elRol);
            FabricaEntidades laFabrica = new FabricaEntidades();
            Cuenta cuenta = (Cuenta)laFabrica.ObtenerCuenta_M1
                (RecursosPU_Mod1.usuario, RecursosPU_Mod1.PruebaErrorClave, listaRol, RecursosPU_Mod1.Vacio,(PersonaM1)laFabrica.ObtenerPersona_M1());

            Assert.AreEqual(cuenta.Roles, listaRol);
            Assert.AreEqual(cuenta.Nombre_usuario, RecursosPU_Mod1.usuario);
            Assert.AreEqual(cuenta.Contrasena, RecursosPU_Mod1.PruebaErrorClave);
            Assert.AreEqual(cuenta.Imagen, RecursosPU_Mod1.Vacio);
        }
        // Prueba unitaria del metodo   public Rol()
        [Test]
        public void PruebaConstructorRol1()
        {

            Rol rl = new Rol();
            Assert.AreEqual(rl.Id_rol, 0);
            Assert.AreEqual(rl.Nombre, RecursosPU_Mod1.Vacio);
            Assert.AreEqual(rl.Descripcion, RecursosPU_Mod1.Vacio);

        }
        // Prueba unitaria del metodo   public Rol(int  elId, String elNombre, String laDescripcion, DateTime laFecha)
        [Test]
        public void PruebaConstructorRol2()
        {

            Rol rl = new Rol(Int32.Parse(RecursosPU_Mod1.Id), RecursosPU_Mod1.Rol, RecursosPU_Mod1.Descripcion, Convert.ToDateTime(RecursosPU_Mod1.Fecha));
            Assert.AreEqual(rl.Id_rol, Int32.Parse(RecursosPU_Mod1.Id));
            Assert.AreEqual(rl.Nombre, RecursosPU_Mod1.Rol);
            Assert.AreEqual(rl.Descripcion, RecursosPU_Mod1.Descripcion);
            Assert.AreEqual(rl.Fecha_creacion, Convert.ToDateTime(RecursosPU_Mod1.Fecha));

        }
        // Prueba unitaria del metodo     public Rol(int elId, String elNombre, String laDescripcion)
        [Test]
        public void PruebaConstructorRol3()
        {
            Rol rl = (Rol) laFabrica.ObtenerRol_M2(Int32.Parse(RecursosPU_Mod1.Id), RecursosPU_Mod1.Rol, RecursosPU_Mod1.Descripcion,DateTime.Today);
            Assert.AreEqual(rl.Id_rol, Int32.Parse(RecursosPU_Mod1.Id));
            Assert.AreEqual(rl.Nombre, RecursosPU_Mod1.Rol);
            Assert.AreEqual(rl.Descripcion, RecursosPU_Mod1.Descripcion);
        }
        [Test]
        public void PruebaConstructorPersonaM1_1()
        {

            PersonaM1 Pn = new PersonaM1();
            Assert.AreEqual(Pn._Id, 0);
            Assert.AreEqual(Pn._Nombre, RecursosPU_Mod1.Vacio);
            Assert.AreEqual(Pn._Apellido, RecursosPU_Mod1.Vacio);
            Assert.AreEqual(Pn._DocumentoID, RecursosPU_Mod1.Vacio);

        }
        // Prueba unitaria del metodo    public PersonaM1(int id,string nombre,string apellido)
        [Test]
        public void PruebaConstructorPersonaM1_2()
        {

            PersonaM1 Pn = new PersonaM1(1, RecursosPU_Mod1.nombre, RecursosPU_Mod1.Apellido);
            Assert.AreEqual(Pn._Id, 1);
            Assert.AreEqual(Pn._Nombre, RecursosPU_Mod1.nombre);
            Assert.AreEqual(Pn._Apellido, RecursosPU_Mod1.Apellido);

        }


    }
}
