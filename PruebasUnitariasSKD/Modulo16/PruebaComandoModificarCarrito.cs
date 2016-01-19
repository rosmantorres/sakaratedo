using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DominioSKD.Entidades.Modulo6;
using LogicaNegociosSKD.Comandos.Modulo16;
using LogicaNegociosSKD;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using LogicaNegociosSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Prueba unitaria del Caso de Uso ModificarCarrito
    /// </summary>
    [TestFixture]
    public class PruebaComandoModificarCarrito
    {
        #region Atributos
        //Atributos pertinentes a usar
        private Comando<bool> ComandoEliminar;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Implemento implemento;
        private Matricula matricula;        
        private Comando<bool> PruebaComandoVacio;
        private Comando<bool> PruebaComandoVacio2;
        private ComandoModificarCarrito pruebaComandoVacio3;
        private ComandoModificarCarrito pruebaComandoVacio4;
        private Comando<bool> PruebaSoloImplementos;
        private Comando<bool> PruebaSoloEventos;
        private Comando<bool> PruebaTodosItems;
        private Evento evento;
        private Comando<bool> ComandoModificarCarrito;
        private Comando<bool> ComandoModificarCarrito2;
        private Comando<bool> ComandoModificarCarrito3;
        private Comando<bool> ComandoModificarCarrito4;
        private Comando<bool> ComandoModificarCarrito5;
        private Comando<bool> ComandoModificarCarrito6;
        FabricaEntidades fabrica;
        FabricaComandos fabricacomando;
        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //Las fabricas
            fabrica = new FabricaEntidades();
            fabricacomando = new FabricaComandos();           
         
            //Las personas
            this.persona = fabrica.ObtenerPersona();
            this.persona.Id = 11;
            this.persona2 = fabrica.ObtenerPersona();
            this.persona2.Id = 12;
            this.persona3 = fabrica.ObtenerPersona();
            this.persona3.Id = 13;

            //Implemento
            this.implemento = new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;

            //Matricula
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;

            //Evento
            this.evento = (Evento)fabrica.ObtenerEvento();
            this.evento.Id = 1;
            this.evento.Costo = 0;            

            //Iniciamos los atributos para la prueba de vacio
            this.PruebaComandoVacio = fabricacomando.CrearComandoModificarCarrito();
            this.PruebaComandoVacio2 = fabricacomando.CrearComandoModificarCarrito
                (this.persona, this.implemento, 1, 30);
            this.pruebaComandoVacio3 = (ComandoModificarCarrito)fabricacomando.CrearComandoModificarCarrito();
            this.pruebaComandoVacio4 = (ComandoModificarCarrito)fabricacomando.CrearComandoModificarCarrito
                (this.persona, this.implemento, 1, 30);

            //Items que agregaremos para despues modificar
            this.PruebaSoloImplementos = fabricacomando.CrearComandoAgregarItem(this.persona, this.implemento, 1, 20);
            this.PruebaSoloImplementos.Ejecutar();

            this.PruebaSoloEventos = 
                fabricacomando.CrearComandoAgregarItem(this.persona2, this.evento, 2, 10);
            this.PruebaSoloEventos.Ejecutar();

            this.PruebaTodosItems = fabricacomando.CrearComandoAgregarItem(this.persona3, this.implemento, 1, 20);
            this.PruebaTodosItems.Ejecutar();
            this.PruebaTodosItems = fabricacomando.CrearComandoAgregarItem
                (this.persona3, this.evento, 2, 10);
            this.PruebaTodosItems.Ejecutar();
            this.PruebaTodosItems = fabricacomando.CrearComandoAgregarItem(this.persona3, this.matricula, 3, 1);
            this.PruebaTodosItems.Ejecutar();

            //ModificarCarrito del primer test
            this.ComandoModificarCarrito = fabricacomando.CrearComandoModificarCarrito(this.persona, this.implemento, 1, 7);
            this.ComandoModificarCarrito2 = fabricacomando.CrearComandoModificarCarrito
                (this.persona2, this.evento, 2, 7);
            this.ComandoModificarCarrito3 = fabricacomando.CrearComandoModificarCarrito(this.persona3, this.implemento, 1, 7);
            this.ComandoModificarCarrito6 = fabricacomando.CrearComandoModificarCarrito
                (this.persona3, this.evento, 2, 7);

            //ModificarCarrito del segundo test
            this.ComandoModificarCarrito4 = fabricacomando.CrearComandoModificarCarrito(this.persona, this.implemento, 1, 8000);
            this.ComandoModificarCarrito5 = fabricacomando.CrearComandoModificarCarrito(this.persona3, this.implemento, 1, 8000);

        }

        /// <summary>
        /// Prueba unitaria para asegurar que el comando no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(this.PruebaComandoVacio);
            Assert.IsNotNull(this.PruebaComandoVacio2);
            Assert.IsNotNull(this.pruebaComandoVacio3);
            Assert.IsNotNull(this.pruebaComandoVacio4.Persona);
            Assert.IsNotNull(this.pruebaComandoVacio4.Objeto);
            Assert.IsNotNull(this.pruebaComandoVacio4.TipoObjeto);
            Assert.IsNotNull(this.pruebaComandoVacio4.Cantidad);
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del comandOModificarCarrito para la cantidad de
        /// unidades de un item ya sea sin implementos o con estos y verificar el modificar de un implemento
        /// colocandole una cantidad que existe en stock
        /// </summary>
        [Test]
        public void PruebaModificarCarritosNormales()
        {
            //Modifico un carrito en el que solo hay implementos
            Assert.IsTrue(this.ComandoModificarCarrito.Ejecutar());

            //Modifico un carrito en el que solo hay eventos
            Assert.IsTrue(this.ComandoModificarCarrito2.Ejecutar());

            //Modifico un carrito en el que hay Implementos, eventos y matriculas
            Assert.IsTrue(this.ComandoModificarCarrito3.Ejecutar());
            Assert.IsTrue(this.ComandoModificarCarrito6.Ejecutar());
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoModificarCarrito para verificar que no se
        /// pueda colocar una cantidad de implemento que no exista en ningun inventariop
        /// </summary>
        [Test]
        public void PruebaModificarCarritoImplementoExceso()
        {
            //Modifico un carrito en el que solo hay implementos poniendole una cantidad inexistente en en el stock
            Assert.IsFalse(this.ComandoModificarCarrito4.Ejecutar());

            /*Modifico un carrito en hay implementos, eventos y matriculas, poniendole al implemento una cantidad
            inexistente en el stock */
            Assert.IsFalse(this.ComandoModificarCarrito5.Ejecutar());
        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            FabricaComandos fabrica = new FabricaComandos();
           
            //Elimino de la persona
            this.ComandoEliminar = fabrica.CrearComandoeliminarItem(1, this.implemento, this.persona);
            this.ComandoEliminar.Ejecutar();

            //Elimino de la persona2
            this.ComandoEliminar = fabrica.CrearComandoeliminarItem(3, this.implemento, this.persona2);
            this.ComandoEliminar.Ejecutar();

            //Elimino de la persona3
            this.ComandoEliminar = fabrica.CrearComandoeliminarItem(2, this.implemento, this.persona3);
            this.ComandoEliminar.Ejecutar();
            this.ComandoEliminar = fabrica.CrearComandoeliminarItem(1, this.implemento, this.persona3);
            this.ComandoEliminar.Ejecutar();
            this.ComandoEliminar = fabrica.CrearComandoeliminarItem(3, this.implemento, this.persona3);
            this.ComandoEliminar.Ejecutar();  

            //Dejo en null
            this.ComandoEliminar = null;
            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.implemento = null;
            this.matricula = null;            
            this.PruebaComandoVacio = null;
            this.PruebaComandoVacio2 = null;
            this.pruebaComandoVacio3 = null;
            this.pruebaComandoVacio4 = null;
            this.PruebaSoloImplementos = null;
            this.PruebaSoloEventos = null;
            this.PruebaTodosItems = null;     
            this.ComandoModificarCarrito = null;
            this.ComandoModificarCarrito2 = null;
            this.ComandoModificarCarrito3 = null;
            this.ComandoModificarCarrito4 = null;
            this.ComandoModificarCarrito5 = null;
            fabrica = null;
            fabricacomando = null;
            this.evento = null;
        }
    }
}
