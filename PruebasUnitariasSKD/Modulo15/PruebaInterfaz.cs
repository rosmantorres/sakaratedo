﻿using DominioSKD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;
using templateApp.GUI;
using templateApp.GUI.Modulo15;
using DominioSKD.Entidades.Modulo15;


namespace PruebasUnitariasSKD.Modulo15
{
    [TestFixture]

    class PruebaInterfaz
    {
        private Implemento implemento;
        private Dojo dojo;
        private InterfazImplemento interfaz;

        [SetUp]
        public void Init()
        {
            implemento = new Implemento();
            interfaz = new InterfazImplemento();
            dojo = new Dojo(1);
            implemento.Nombre_Implemento = "Guantes Karate-DO";
            implemento.Tipo_Implemento = "Guantes";
            implemento.Marca_Implemento = "Adidas";
            implemento.Color_Implemento = "Azul";
            implemento.Talla_Implemento = "S";
            implemento.Precio_Implemento = 1500;
            implemento.Stock_Minimo_Implemento = 5;
            implemento.Cantida_implemento = 20;
            implemento.Dojo_Implemento = dojo;
            implemento.Descripcion_Implemento = "Guantes Wola";
            implemento.Imagen_implemento = "A.jpg";


        }
        [TearDown]
        public void Reset()
        {
            implemento = null;
            dojo = null;
        }

        #region M15_PruebaAgregarInventarioInterfaz
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaAgregarInventarioInterfaz()
        {
            interfaz.agregarInventarioInterfaz(null);
        }
        #endregion

        #region M15_PruebaListarInventarioInterfaz
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaListarInventarioInterfaz()
        {
            interfaz.listarInventarioInterfaz(null);
        }
        #endregion

        #region M15_PruebaListarInventarioLogica2
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaListarInventarioInterfaz2()
        {
            interfaz.listarInventarioInterfaz2(null);
        }
        #endregion

        #region M15_PruebaUsuarioImplementoInterfaz
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaUsuarioImplementoInterfaz()
        {
            interfaz.usuarioImplementoInterfaz(null);
        }
        #endregion

        #region M15_PruebamodificarInventarioInterfaz
        [Test]
        [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
        public void M15_PruebaeliminarInventarioInterfaz()
        {
            interfaz.modificarInventarioInterfaz(null);
        }
        #endregion


    }
}
