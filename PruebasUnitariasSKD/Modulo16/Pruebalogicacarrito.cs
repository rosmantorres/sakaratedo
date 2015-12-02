using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo16;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Clase de pruebas unitarias que trabaja sobre la clase Carrito
    /// </summary>

    [TestFixture]
    public class Pruebalogicacarrito
    {
        #region Atributos
        //Atributos con los que trabajara la clase
        private Carrito carritoPrueba;
        private Carrito miCarrito;

        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            this.carritoPrueba = new Carrito();

            Carrito miCarrito = new Carrito();

        }

        /// <summary>
        /// Prueba unitaria que verifica que la clase no sea vacia
        /// </summary>
        [Test]
        public void pruebaVacio()
        {
            Assert.IsNotNull(this.carritoPrueba);
        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo limpiar funcione
        /// </summary>
        [Test]
        public void pruebaLimpiar()
        {
            Assert.IsTrue(this.carritoPrueba.limpiar());
        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo eliminarItem funcione
        /// </summary>
        [Test]
        public void pruebaEliminaritem()
        {
            Assert.IsTrue(this.carritoPrueba.eliminarItem(1, 1));
        }



        /// <summary>
        /// Prueba unitaria que verifica que el metodo consultar matriculas trae algun dato
        /// </summary>
        [Test]
        public void pruebaLogicaVermatriculaenCarrito()
        {


            Carrito miCarrito = new Carrito();
            Matricula miMatricula = new Matricula();
            miMatricula.Mat_identificador = "CAF - CAF - CAFE";
            miMatricula.Status = true;
            miMatricula.FechaCreacion = Convert.ToDateTime(29 / 11 / 2015);
            miMatricula.UltimaFechapago = Convert.ToDateTime(29 / 11 / 2015);
            Persona persona = new Persona();
            persona.ID = 1;
            miMatricula.IdentificadorUsuario = persona.ID;
            miMatricula.FechaTope = Convert.ToDateTime(29 / 11 / 2015);
            TipoEvento tipeven = new TipoEvento();
            miCarrito.Listamatricula.Add(miMatricula);
            Assert.IsNotNull(Logicacarrito.verCarrito(1));
            Assert.AreEqual(Logicacarrito.verCarrito(1), miCarrito);


        }


        /// <summary>
        /// Prueba unitaria que verifica que el metodo consultar matriculas trae algun dato
        /// </summary>
        [Test]
        public void pruebaLogicaVereventoenCarrito()
        {


            Evento miEvento = new Evento();
            miEvento.Id_evento = 1;
            miEvento.Nombre = "Clase Regular";
            TipoEvento tipeven = new TipoEvento();
            tipeven.Id = 4;
            tipeven.Nombre = "Clases Regulares";
            miEvento.TipoEvento = tipeven;
            Horario horario = new Horario();
            horario.FechaFin = Convert.ToDateTime(15 / 10 / 2016);
            horario.FechaInicio = Convert.ToDateTime(15 / 10 / 2015);
            horario.Id = 1;
            horario.HoraFin = 4;
            horario.HoraInicio = 2;
            miEvento.Horario = horario;
            miEvento.Costo = 0;
            miEvento.Categoria = null;
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.Ciudad = "Caracas";
            ubicacion.Direccion = null;
            ubicacion.Id_ubicacion = 1;
            ubicacion.Latitud = "10.499607";
            ubicacion.Longitud = "-66.788419";
            miEvento.Ubicacion = ubicacion;
            miCarrito.Listaevento.Add(miEvento);

            /// Prueba unitaria que verifica que la el usuario con id 1 tiene en un carrito el evento con id 1 definido anteriormente 
            Assert.IsNotNull(Logicacarrito.verCarrito(1));


            /// Prueba unitaria que verifica que lo que contiene el usuario con id 1, contiene lo definido anteriormente
            Assert.AreEqual(Logicacarrito.verCarrito(1), miCarrito);


        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo consultar matriculas trae algun dato
        /// </summary>
        [Test]
        public void pruebaLogicaVerimplementoenCarrito()
        {

            Carrito miCarrito = new Carrito();
            Implemento miImplemento = new Implemento();
            miImplemento.Id_Implemento = 1;
            miImplemento.Nombre_Implemento = "Guantines Karate-DO";
            miImplemento.Imagen_implemento = "~/GUI/Modulo15/Imagenes/guantes.jpg";
            miImplemento.Marca_Implemento = "Kombate";
            miImplemento.Precio_Implemento = 4500;
            miImplemento.Stock_Minimo_Implemento = 5;
            miImplemento.Talla_Implemento = "S";
            miImplemento.Tipo_Implemento = "Guantines";
            miImplemento.Color_Implemento = "Azul";
            miCarrito.ListaImplemento.Add(miImplemento);

            /// Prueba unitaria que verifica que la el usuario con id 1 tiene en un carrito el implemento con id 1 definido anteriormente 
            Assert.IsNotNull(Logicacarrito.verCarrito(1));

            /// Prueba unitaria que verifica que lo que contiene el usuario con id 1, contiene en su carrito lo definido anteriormente
            Assert.AreEqual(Logicacarrito.verCarrito(1), miCarrito);

        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo agregar evento a carrito funciona correctamente
        /// </summary>
        [Test]
        public void pruebaLogicaagregarEventoaCarrito()
        {

            bool l = Logicacarrito.agregarEventoaCarrito(1, 1);
            Assert.IsNotNull(l);

            /// Prueba unitaria que demuestra que se pudo agregar el evento con id 1 y usuario 1
            Assert.IsTrue(l);


        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo agregar matricula a carrito funciona correctamente
        /// </summary>
        [Test]
        public void pruebaLogicaagregarMatriculaaCarrito()
        {
            bool l = Logicacarrito.agregarMatriculaaCarrito(1, 23);

            // prueba que l siendo instancia de logicacarrito no es null
            Assert.IsNotNull(l);

            /// Prueba unitaria que demuestra que se pudo agregar la matricula al carrito con id 23 y usuario 1
            Assert.IsTrue(l);

        }

        /// <summary>
        /// Prueba unitaria que verifica que el metodo agregar implemento a carrito funciona correctamente
        /// </summary>
        [Test]
        public void pruebaLogicaagregarImplementoaCarrito()
        {
            bool l = Logicacarrito.agregarInventarioaCarrito(1, 1);

            // prueba que l siendo instancia de logicacarrito no es null
            Assert.IsNotNull(l);
            /// Prueba unitaria que demuestra que se pudo agregar la inventario al carrito con id 1 y usuario 1
            Assert.IsTrue(l);
        }


        /// <summary>
        /// Prueba unitaria que verifica que el metodo agregar implemento a carrito funciona correctamente
        /// </summary>
        [Test]
        public void pruebaLogicaregistrarPago()
        {

            List<int> datos1 = new List<int>();
            datos1.Add(1);
            bool l = Logicacarrito.registrarPago(1, datos1, 1);

            // prueba que l siendo instancia de logicacarrito no es null
            Assert.IsNotNull(l);
            /// Prueba unitaria que demuestra que se pudo registrar el pago con el tipo de pago, los datos y el usuario
            Assert.IsTrue(l);
        }

        /// <summary>
        /// Limpiamos todos los atributos usados
        /// </summary>
        /// <summary>
        /// Limpiamos todos los atributos usados
        /// </summary>
        [TearDown]
        public void limpiar()
        {
            this.carritoPrueba = null;
            miCarrito = null;
        }
        #endregion
    }
}