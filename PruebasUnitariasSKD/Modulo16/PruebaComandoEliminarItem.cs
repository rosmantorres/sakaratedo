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
using DominioSKD.Entidades.Modulo1;
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
        private ComandoeliminarItem pruebaComando;
        private ComandoeliminarItem pruebaComandoImplemento1;
        private ComandoeliminarItem pruebaComandoEvento1;
        private ComandoeliminarItem pruebaComandoMatricula1;

        private Comando<bool> eliminarEventos;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Implemento implemento;
        private Implemento implemento2;
        private bool seelimina;
        private Matricula matricula;
        private Matricula matricula2;
        private List<Entidad> listaEventos;
        #endregion


        /// <summary>
        /// Inicializa  los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //Persona
            this.persona = new Persona();
            this.persona.Id = 11;

            //Implemento
            this.implemento = new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;

            //Eliminar Eventos
            this.eliminarEventos = FabricaComandos.CrearComandoeliminarItem();
            this.seelimina = this.eliminarEventos.Ejecutar();

            //Matricula
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;

            //Obtengo el comando
            this.pruebaComando = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();

            //Diferentes valores para Eliminar un Implemento
            this.pruebaComandoImplemento1 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();
            this.pruebaComandoImplemento1.Persona = this.persona;
            this.pruebaComandoImplemento1.Objeto = this.implemento;
            this.pruebaComandoImplemento1.TipoObjeto = 1;
            this.pruebaComandoImplemento1.Cantidad = 10;

            //Diferentes valores para Eliminar un Evento
            this.pruebaComandoEvento1 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();
            this.pruebaComandoEvento1.Persona = this.persona2;
            this.pruebaComandoEvento1.Objeto = this.listaEventos[0];
            this.pruebaComandoEvento1.TipoObjeto = 2;
            this.pruebaComandoEvento1.Cantidad = 10;

            //Diferentes valores para Eliminar una Matricula
            this.pruebaComandoMatricula1 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();
            this.pruebaComandoMatricula1.Persona = this.persona3;
            this.pruebaComandoMatricula1.Objeto = this.matricula;
            this.pruebaComandoMatricula1.TipoObjeto = 3;
            this.pruebaComandoMatricula1.Cantidad = 10;


        }


        /// <summary>
        /// Prueba unitaria para asegurar que el comando no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(this.pruebaComando);
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoeliminarItem, la cual se encarga de eliminar un implemento en especifico
        /// </summary>
        [Test]
        public void pruebaEliminarImplemento()
        {
            //Se prueba que se elimina un implemento al carrito de una persona
            Assert.IsTrue(this.pruebaComandoImplemento1.Ejecutar());
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoEliminarItem para eliminar un evento en especifico
        /// </summary>
        [Test]
        public void pruebaEliminarEvento()
        {
            //Se prueba que se elimina un Evento existente en el carrito de una persona
            Assert.IsTrue(this.pruebaComandoEvento1.Ejecutar());
        }


        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del comando EliminarItem para eliminar una matricula en especifico
        /// </summary>
        [Test]
        public void PruebaEliminarMatricula()
        {
            //Se prueba que se elimina una matricula existente en el carrito  de una persona
            Assert.IsTrue(this.pruebaComandoMatricula1.Ejecutar());
        }



        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.pruebaComando = null;
            this.pruebaComandoImplemento1 = null;
            this.pruebaComandoEvento1 = null;
            this.pruebaComandoMatricula1 = null;
            this.eliminarEventos = null;
            this.persona = null;
            this.implemento = null;
            this.matricula = null;
            this.eliminarEventos = null;

        }







    }
}
