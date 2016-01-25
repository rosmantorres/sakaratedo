using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Comandos.Modulo16;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Entidades.Modulo6;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD;
using DominioSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo16
{

    /// <summary>
    /// Prueba unitaria del Caso de Uso Eliminar Item
    /// </summary>
    [TestFixture]
    class PruebaComandoEliminarItem
    {
        #region Atributos
        //Atributos pertinentes a usar   
        private Comando<bool> PruebaComandoVacio;
        private Comando<bool> PruebaComandoVacio2;
        private ComandoeliminarItem pruebaComandoVacio3;
        private ComandoeliminarItem pruebaComandoVacio4;
        private Comando<bool> pruebaComandoImplemento1;
        private Comando<bool> pruebaComandoImplemento2;
        private Comando<bool> pruebaComandoImplemento3;
        private Comando<bool> pruebaComandoAgregarImplemento;
        private Comando<bool> pruebaComandoEvento1;
        private Comando<bool> pruebaComandoEvento2;
        private Comando<bool> pruebaComandoEvento3;
        private Comando<bool> pruebaComandoAgregarEvento;
        private Comando<bool> pruebaComandoMatricula1;
        private Comando<bool> pruebaComandoMatricula2;
        private Comando<bool> pruebaComandoMatricula3;
        private Comando<bool> pruebaComandoAgregarMatricula;
        private DominioSKD.Entidades.Modulo9.Evento evento;
        private DominioSKD.Entidades.Modulo9.Evento evento2;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Entidad persona4;
        private Implemento implemento;
        private Implemento implemento2;
        private Matricula matricula;
        private Matricula matricula2;
        private FabricaEntidades fabrica;
        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            fabrica = new FabricaEntidades();

            //La persona
            this.persona = FabricaEntidades.ObtenerPersona();
            this.persona.Id = 11;
            this.persona2 = FabricaEntidades.ObtenerPersona();
            this.persona2.Id = 12;
            this.persona3 = FabricaEntidades.ObtenerPersona();
            this.persona3.Id = 13;
            this.persona4 = FabricaEntidades.ObtenerPersona();
            this.persona4.Id = 14;

            //Dos implementos distintos
            this.implemento = (Implemento)FabricaEntidades.ObtenerImplemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;
            this.implemento2 = (Implemento)FabricaEntidades.ObtenerImplemento();
            this.implemento2.Id = 2;
            this.implemento2.Precio_Implemento = 3000;

            //Eventos
            //this.eventos = (ComandoConsultarTodosEventos)FabricaComandos.CrearComandoConsultarTodosEventos();
            //this.eventos.LaEntidad = fabrica.ObtenerPersona_M1(11, "prueba", "prueba");
            //this.listaEventos = (ListaEvento)this.eventos.Ejecutar();

            this.evento = (DominioSKD.Entidades.Modulo9.Evento)fabrica.ObtenerEvento();
            this.evento.Id = 1;
            this.evento.Costo = 0;

            this.evento2 = (DominioSKD.Entidades.Modulo9.Evento)fabrica.ObtenerEvento();
            this.evento2.Id = 2;
            this.evento2.Costo = 2000;

            //Dos matriculas distintas
            this.matricula = (Matricula)FabricaEntidades.ObtenerMatricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;
            this.matricula2 = (Matricula)FabricaEntidades.ObtenerMatricula();
            this.matricula2.Id = 2;
            this.matricula2.Costo = 4500;
            
            //Iniciamos los atributos para la prueba de vacio
            this.PruebaComandoVacio = FabricaComandos.CrearComandoeliminarItem();
            this.PruebaComandoVacio2 = FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona);
            this.pruebaComandoVacio3 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();
            this.pruebaComandoVacio4 = (ComandoeliminarItem)
                FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona);


            //valor  para Eliminar un Implemento
            this.pruebaComandoImplemento1 = FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona);
            this.pruebaComandoImplemento2 =FabricaComandos.CrearComandoeliminarItem(1, this.implemento2, this.persona);

            //valor para Eliminar un Evento
            this.pruebaComandoEvento1 = FabricaComandos.CrearComandoeliminarItem(
                3, this.evento, this.persona2);
            this.pruebaComandoEvento2 = FabricaComandos.CrearComandoeliminarItem(
                3, this.evento2, this.persona2);

            //valor para Eliminar una Matricula
            this.pruebaComandoMatricula1 = FabricaComandos.CrearComandoeliminarItem(2, this.matricula, this.persona3);
            this.pruebaComandoMatricula2 = FabricaComandos.CrearComandoeliminarItem(2, this.matricula2, this.persona3);

            //Comandos que eliminaran en la prueba de la persona4
            this.pruebaComandoImplemento3 =FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona4);
            this.pruebaComandoEvento3 = FabricaComandos.CrearComandoeliminarItem(3, this.evento, this.persona4);
            this.pruebaComandoMatricula3 = FabricaComandos.CrearComandoeliminarItem(2, this.matricula, this.persona4);
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
            Assert.IsNotNull(this.pruebaComandoVacio4);
            Assert.IsNotNull(this.pruebaComandoVacio4);
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoeliminarItem para eliminar implementos
        /// </summary>
        [Test]
        public void pruebaEliminarImplemento()
        {
            //Valor para Agregar Implementos
            this.pruebaComandoAgregarImplemento = FabricaComandos.CrearComandoAgregarItem
                (this.persona, this.implemento, 1, 1);
            this.pruebaComandoAgregarImplemento.Ejecutar();
            this.pruebaComandoAgregarImplemento = FabricaComandos.CrearComandoAgregarItem
                (this.persona, this.implemento2, 1, 1);
            this.pruebaComandoAgregarImplemento.Ejecutar();

            //Elimino un implemento del carrito de una persona con id 11
            Assert.IsTrue(this.pruebaComandoImplemento1.Ejecutar());

            //Trato de eliminar un elemento que ya no existe
            Assert.IsFalse(this.pruebaComandoImplemento1.Ejecutar());

            //Elimino un implemento del carrito de una persona con id 11
            Assert.IsTrue(this.pruebaComandoImplemento2.Ejecutar());

            //Trato de eliminar un elemento que ya no existe
            Assert.IsFalse(this.pruebaComandoImplemento2.Ejecutar());
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoeliminarItem para eliminar eventos
        /// </summary>
        [Test]
        public void pruebaAgregarEvento()
        {

            //Valor para Agregar un Evento
            this.pruebaComandoAgregarEvento = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.evento, 2, 1);
            this.pruebaComandoAgregarEvento.Ejecutar();
            this.pruebaComandoAgregarEvento = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.evento2, 2, 1);
            this.pruebaComandoAgregarEvento.Ejecutar();

            //Elimino un Evento del carrito de una persona con id 12
            Assert.IsTrue(this.pruebaComandoEvento1.Ejecutar());

            //Trato de eliminar un evento que ya no esta en el carrito
            Assert.IsFalse(this.pruebaComandoEvento1.Ejecutar());

            //Elimino un Evento del carrito de una persona con id 12
            Assert.IsTrue(this.pruebaComandoEvento2.Ejecutar());

            //Trato de eliminar un evento que ya no esta en el carrito
            Assert.IsFalse(this.pruebaComandoEvento2.Ejecutar());
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del comando EliminarItem para eliminar matriculas
        /// </summary>
        [Test]
        public void PruebaEliminarMatricula()
        {
            //Valor para Agregar una Matricula
            this.pruebaComandoAgregarMatricula = FabricaComandos.CrearComandoAgregarItem
                (this.persona3, this.matricula, 3, 1);
            this.pruebaComandoAgregarMatricula.Ejecutar();
            this.pruebaComandoAgregarMatricula = FabricaComandos.CrearComandoAgregarItem
                (this.persona3, this.matricula2, 3, 1);
            this.pruebaComandoAgregarMatricula.Ejecutar();

            //Elimino una matricula del carrito de una persona con id 13
            Assert.IsTrue(this.pruebaComandoMatricula1.Ejecutar());

            //Trato de eliminar una matricula que ya no esta en el carrito
            Assert.IsFalse(this.pruebaComandoMatricula1.Ejecutar());

            //Elimino una matricula del carrito de una persona con id 13
            Assert.IsTrue(this.pruebaComandoMatricula2.Ejecutar());

            //Trato de eliminar una matricula que ya no esta en el carrito
            Assert.IsFalse(this.pruebaComandoMatricula2.Ejecutar());
        }

        /// <summary>
        /// Prueba Unitaria que trabaja sobre el comando de EliminarItem para eliminar un carrito con
        /// un item de cada uno (Implemento, Evento y Matricula)
        /// </summary>
        [Test]
        public void PruebaEliminarTodos()
        {
            //Valor para agregar Items
            this.pruebaComandoAgregarImplemento = FabricaComandos.CrearComandoAgregarItem
                (this.persona4, this.implemento, 1, 1);
            this.pruebaComandoAgregarImplemento.Ejecutar();
            this.pruebaComandoAgregarEvento = FabricaComandos.CrearComandoAgregarItem
                (this.persona4, this.evento, 2, 1);
            this.pruebaComandoAgregarEvento.Ejecutar();
            this.pruebaComandoAgregarMatricula = FabricaComandos.CrearComandoAgregarItem
                (this.persona4, this.matricula, 3, 1);
            this.pruebaComandoAgregarMatricula.Ejecutar();

            //Elimino ese item del carrito y verifico que ya no este
            Assert.IsTrue(this.pruebaComandoImplemento3.Ejecutar());
            Assert.IsFalse(this.pruebaComandoImplemento3.Ejecutar());

            //Elimino ese item del carrito y verifico que ya no este
            Assert.IsTrue(this.pruebaComandoEvento3.Ejecutar());
            Assert.IsFalse(this.pruebaComandoEvento3.Ejecutar());

            //Elimino ese item del carrito y verifico que ya no este
            Assert.IsTrue(this.pruebaComandoMatricula3.Ejecutar());
            Assert.IsFalse(this.pruebaComandoMatricula3.Ejecutar());

        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar eliminaritem
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.PruebaComandoVacio = null;
            this.PruebaComandoVacio2 = null;
            this.pruebaComandoVacio3 = null;
            this.pruebaComandoVacio4 = null;
            this.pruebaComandoImplemento1 = null;
            this.pruebaComandoImplemento2 = null;
            this.pruebaComandoImplemento3 = null;
            this.pruebaComandoAgregarImplemento = null;
            this.pruebaComandoEvento1 = null;
            this.pruebaComandoEvento2 = null;
            this.pruebaComandoEvento3 = null;
            this.pruebaComandoAgregarEvento = null;
            this.pruebaComandoMatricula1 = null;
            this.pruebaComandoMatricula2 = null;
            this.pruebaComandoMatricula3 = null;
            this.pruebaComandoAgregarMatricula = null;
            this.evento = null;
            this.evento2 = null;
            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.persona4 = null;
            this.implemento = null;
            this.implemento2 = null;
            this.matricula = null;
            this.matricula2 = null;
            this.fabrica = null;
        }

    }
}
