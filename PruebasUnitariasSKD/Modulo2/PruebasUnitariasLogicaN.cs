﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo1;
using LogicaNegociosSKD.Modulo2;
using DominioSKD;

namespace PruebasUnitariasSKD.Modulo2
{
    [TestFixture]

    class PruebasUnitariasLogicaN
    {
       
            [SetUp]
            protected void parametros()
            {

            }

           
            // Prueba unitaria de la excepcion del metodo consultarRolesUsuario()
            [Test]
            public void PruebaValidarconsultarRolesUsuario()
            {
                List<Rol> _respuesta;
                _respuesta = logicaRol.consultarRolesUsuario(RecursosPU_Mod2.Id);
                Assert.AreNotEqual(null, _respuesta);

            }
            // Prueba unitaria de la excepcion del metodo consultarRolesUsuario() excepcion
            [Test]
            [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
            public void PruebaValidarconsultarRolesUsuarioEXC()
            {
                List<Rol> _respuesta;
                _respuesta = logicaRol.consultarRolesUsuario(null);
            }
            // Prueba unitaria  del metodo prioridadRol()
            [Test]
            public void PruebaprioridadRol()
            {

                int _respuesta = logicaRol.prioridadRol(RecursosPU_Mod2.Rol);
                int _respuesta1 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol2);
                int _respuesta2 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol3);
                int _respuesta3 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol4);
                int _respuesta4 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol5);
                int _respuesta5 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol6);
                int _respuesta6 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol7);
                int _respuesta7 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol8);
                int _respuesta8 = logicaRol.prioridadRol(RecursosPU_Mod2.Rol9);
                Assert.AreEqual(1, _respuesta);
                Assert.AreEqual(1, _respuesta1);
                Assert.AreEqual(2, _respuesta2);
                Assert.AreEqual(2, _respuesta3);
                Assert.AreEqual(3, _respuesta4);
                Assert.AreEqual(3, _respuesta5);
                Assert.AreEqual(4, _respuesta6);
                Assert.AreEqual(5, _respuesta7);
                Assert.AreEqual(6, _respuesta8);

            }
            // Prueba unitaria de la excepcion del metodo prioridadRol() Exc
            [Test]
            [ExpectedException(typeof(ExcepcionesSKD.Modulo2.RolesException))]
            public void PruebaprioridadRolExc()
            {
                int _respuesta;
                _respuesta = logicaRol.prioridadRol(RecursosPU_Mod2.RolInvalido);

            }
            // Prueba unitaria  del metodo agregarRol(),consultarRolesUsuario() ylogicaRol.eliminarRol();
            [Test]
            public void PruebaagregarEliminarConsultarRol()
            {
                List<Rol> RolesUsuario = logicaRol.consultarRolesUsuario(RecursosPU_Mod2.Id);
                bool _respuesta = logicaRol.agregarRol("1", "3");
                Assert.AreEqual(true, _respuesta);

                bool _respuesta2 = logicaRol.eliminarRol("1", "3");
                Assert.AreEqual(true, _respuesta2);

                List<Rol> RolesUsuario2 = logicaRol.consultarRolesUsuario(RecursosPU_Mod2.Id);
                Assert.AreEqual(RolesUsuario.Count, RolesUsuario2.Count);

            }
        
    }
}