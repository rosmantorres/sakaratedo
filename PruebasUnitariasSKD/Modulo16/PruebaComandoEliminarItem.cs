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
        private int persona;
        private Implemento implemento;
        private bool seelimina;
        private Matricula matricula;
        private int objetoaBorrari ;
         private   int tipoObjetoi ;
         private  int usuarioi;
         private int objetoaBorrarm;
         private int tipoObjetom;
         private int usuariom;
         private int objetoaBorrare;
         private int tipoObjetoe;
         private int usuarioe;



        #endregion


        /// <summary>
        /// Inicializa  los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //Persona
            this.persona = 11;

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


             this.objetoaBorrari=1 ;
             this.tipoObjetoi=1 ;
             this.usuarioi=persona;

            this.objetoaBorrarm=1;
         this.tipoObjetom=1;
         this.usuariom=persona;


        this.objetoaBorrare=1;
         this.tipoObjetoe=1;
         this.usuarioe=persona;

            //Obtengo el comando
            this.pruebaComando = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();

            //Diferentes valores para Eliminar un Implemento
            this.pruebaComandoImplemento1 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();
            this.pruebaComandoImplemento1.ObjetoaBorrar = this.objetoaBorrari;
            this.pruebaComandoImplemento1.TipoObjeto = this.tipoObjetoi;
            this.pruebaComandoImplemento1.Usuario =this.persona;
           

            //Diferentes valores para Eliminar un Evento
            this.pruebaComandoEvento1 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();
            this.pruebaComandoEvento1.ObjetoaBorrar = this.objetoaBorrare;
            this.pruebaComandoEvento1.TipoObjeto = this.tipoObjetoe;
            this.pruebaComandoEvento1.Usuario = this.persona;
            

            //Diferentes valores para Eliminar una Matricula
            this.pruebaComandoMatricula1 = (ComandoeliminarItem)FabricaComandos.CrearComandoeliminarItem();
            this.pruebaComandoMatricula1.ObjetoaBorrar = this.objetoaBorrarm;
            this.pruebaComandoMatricula1.TipoObjeto = this.tipoObjetom;
            this.pruebaComandoMatricula1.Usuario = this.persona;
             

            
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
            this.persona = 0;
            this.implemento = null;
            this.matricula = null;
            

        }







    }
}
