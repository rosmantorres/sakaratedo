using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Comandos.Modulo16;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo6;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD;

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
        private Comando<bool> ComandoEliminar;
        private Comando<bool> PruebaComandoVacio;
        private Comando<bool> PruebaComandoVacio2;
        private ComandoeliminarItem pruebaComandoVacio3;
        private ComandoeliminarItem pruebaComandoVacio4;
        private Comando<bool> pruebaComandoImplemento1;
        private Comando<bool> pruebaComandoEvento1;
        private Comando<bool> pruebaComandoMatricula1;
        private Comando<List<Entidad>> eventos;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Implemento implemento;
        private List<Entidad> listaEventos;
        private Matricula matricula;

        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //La persona
            this.persona = new Persona();
            this.persona.Id = 11;
            this.persona2 = new Persona();
            this.persona2.Id = 12;
            this.persona3 = new Persona();
            this.persona3.Id = 13;

            //Dos implementos distintos
            this.implemento = new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;


            //Eventos
            this.eventos = FabricaComandos.CrearComandoConsultarTodosEventos();
            this.listaEventos = this.eventos.Ejecutar();

            //Dos matriculas distintas
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;


            //Iniciamos los atributos para la prueba de vacio
            this.PruebaComandoVacio = FabricaComandos.CrearComandoeliminarItem();
            this.PruebaComandoVacio2 = FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona);
            this.pruebaComandoVacio3 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();
            this.pruebaComandoVacio4 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona);


            //valor  para Eliminar un Implemento
            this.pruebaComandoImplemento1 = FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona);
            //valor para Eliminar un Evento
            this.pruebaComandoEvento1 = FabricaComandos.CrearComandoeliminarItem(2, this.listaEventos[0], this.persona2);
            //valor  para Eliminar una Matricula
            this.pruebaComandoMatricula1 = FabricaComandos.CrearComandoeliminarItem(3, this.matricula, this.persona3);


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
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoeliminarItem para eliminar implemento 
        /// </summary>
        [Test]
        public void pruebaEliminarImplemento()
        {
            //Elimino un implemento al carrito de una persona con id 11
            Assert.IsTrue(this.pruebaComandoImplemento1.Ejecutar());
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoeliminarItem para eliminar evento 
        /// </summary>
        [Test]
        public void pruebaAgregarEvento()
        {
            //Elimino un Evento al carrito de una persona con id 12
            Assert.IsTrue(this.pruebaComandoEvento1.Ejecutar());
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del comando AgregarItem para agregar matricula
        /// </summary>
        [Test]
        public void PruebaEliminarMatricula()
        {
            //Elimino una matricula al carrito de una persona con id 13
            Assert.IsTrue(this.pruebaComandoMatricula1.Ejecutar());
        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar eliminaritem
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.ComandoEliminar = null;
            this.PruebaComandoVacio = null;
            this.PruebaComandoVacio2 = null;
            this.pruebaComandoVacio3 = null;
            this.pruebaComandoVacio4 = null;
            this.pruebaComandoImplemento1 = null;
            this.pruebaComandoEvento1 = null;
            this.pruebaComandoMatricula1 = null;
            this.eventos = null;
            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.implemento = null;
            this.listaEventos = null;
            this.matricula = null;
        }

    }
}
