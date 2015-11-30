using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD;
using PruebasUnitariasSKD.Modulo1;
using DominioSKD;
using ExcepcionesSKD;


namespace PruebasUnitariasSKD.Modulo1
{
    [TestFixture]
    class PruebasUnitariasDominio
    {
        [SetUp]
        protected  void parametros()
        {
           
        }
        // Prueba unitaria del metodo Cuenta() 
        [Test]
        public void PruebaConstructorCuenta1()
        {

            Cuenta cuenta = new Cuenta();

            Assert.AreEqual(cuenta.Id_usuario, 0);
            Assert.AreEqual(cuenta.Nombre_usuario, RecursosPU_Mod1.Vacio);
            Assert.AreEqual(cuenta.Contrasena, RecursosPU_Mod1.Vacio);
        }
        // Prueba unitaria del metodo Cuenta(int elIdUsuario, String elNombreUsuario, String laContrasena) 
        [Test]
        public  void PruebaConstructorCuenta2()
        {

            Cuenta cuenta = new Cuenta(Int32.Parse(RecursosPU_Mod1.Id), RecursosPU_Mod1.usuario, RecursosPU_Mod1.PruebaErrorClave,RecursosPU_Mod1.Vacio,RecursosPU_Mod1.Vacio);

            Assert.AreEqual(cuenta.Id_usuario, Int32.Parse(RecursosPU_Mod1.Id));
            Assert.AreEqual(cuenta.Nombre_usuario, RecursosPU_Mod1.usuario);
            Assert.AreEqual(cuenta.Contrasena, RecursosPU_Mod1.PruebaErrorClave);
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
            Cuenta cuenta = new Cuenta(RecursosPU_Mod1.usuario, RecursosPU_Mod1.PruebaErrorClave, listaRol, RecursosPU_Mod1.Vacio,RecursosPU_Mod1.Vacio);

            Assert.AreEqual(cuenta.Roles, listaRol);
            Assert.AreEqual(cuenta.Nombre_usuario, RecursosPU_Mod1.usuario);
            Assert.AreEqual(cuenta.Contrasena, RecursosPU_Mod1.PruebaErrorClave);
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
            Rol rl = new Rol(Int32.Parse(RecursosPU_Mod1.Id), RecursosPU_Mod1.Rol, RecursosPU_Mod1.Descripcion);
            Assert.AreEqual(rl.Id_rol, Int32.Parse(RecursosPU_Mod1.Id));
            Assert.AreEqual(rl.Nombre, RecursosPU_Mod1.Rol);
            Assert.AreEqual(rl.Descripcion, RecursosPU_Mod1.Descripcion);
        }

       
    }
}
