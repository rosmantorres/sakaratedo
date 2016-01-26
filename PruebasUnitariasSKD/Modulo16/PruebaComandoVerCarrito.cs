﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo16;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Entidades.Modulo6;
using DominioSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Prueba unitaria del Caso de Uso de Ver Carrito
    /// </summary>
    [TestFixture]
    public class PruebaComandoVerCarrito
    {
        #region Atributos
        private Comando<bool> ComandoEliminar;
        private Comando<Entidad> PruebaComandoVacio;
        private Comando<Entidad> PruebaComandoVacio2;
        private Comando<Entidad> PruebaVerSoloImplemento;
        private Comando<Entidad> PruebaVerSoloEvento;
        private Comando<Entidad> PruebaVerSoloMatricula;
        private Comando<Entidad> PruebaVerTodo;
        private ComandoVerCarrito pruebaComandoVacio3;
        private ComandoVerCarrito pruebaComandoVacio4;
        private Comando<bool> ComandoAgregarItem;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Entidad persona4;
        private Implemento implemento;       
        private Matricula matricula;
        private Carrito Carrito;
        private DominioSKD.Entidades.Modulo9.Evento evento;
        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {

            //Las Personas
            this.persona = FabricaEntidades.ObtenerPersona();
            this.persona.Id = 11;
            this.persona2 = FabricaEntidades.ObtenerPersona();
            this.persona2.Id = 12;
            this.persona3 = FabricaEntidades.ObtenerPersona();
            this.persona3.Id = 13;
            this.persona4 = FabricaEntidades.ObtenerPersona();
            this.persona4.Id = 14;

            //Implemento
            this.implemento = (Implemento)FabricaEntidades.ObtenerImplemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;

            //Eventos
            this.evento = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
            this.evento.Id = 1;
            this.evento.Costo = 0;

            //Matricula
            this.matricula = (Matricula)FabricaEntidades.ObtenerMatricula();
            this.matricula.Id = 37;
            this.matricula.Costo = 4250;

            //Iniciamos los atributos para la prueba de vacio
            this.PruebaComandoVacio = FabricaComandos.CrearComandoVerCarrito();
            this.PruebaComandoVacio2 = FabricaComandos.CrearComandoVerCarrito(this.persona);
            this.pruebaComandoVacio3 = (ComandoVerCarrito)FabricaComandos.CrearComandoVerCarrito();
            this.pruebaComandoVacio4 = (ComandoVerCarrito)FabricaComandos.CrearComandoVerCarrito(this.persona);

            //Carrito Cuando hay solo Implementos
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona, this.implemento, 1, 5);
            this.ComandoAgregarItem.Ejecutar();
            this.PruebaVerSoloImplemento = FabricaComandos.CrearComandoVerCarrito(this.persona);

            //Carrito Cuando hay solo Eventos
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.evento, 2, 6);
            this.ComandoAgregarItem.Ejecutar();
            this.PruebaVerSoloEvento = FabricaComandos.CrearComandoVerCarrito(this.persona2);

            //Carrito Cuando hay solo Matriculas
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona3, this.matricula, 3, 1);
            this.ComandoAgregarItem.Ejecutar();
            this.PruebaVerSoloMatricula = FabricaComandos.CrearComandoVerCarrito(this.persona3);

            //Carrito Cuando hay Implementos, Eventos y Matriculas
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.implemento, 1, 5);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem
                (this.persona4, this.evento, 2, 6);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.matricula, 3, 1);
            this.ComandoAgregarItem.Ejecutar();
            this.PruebaVerTodo = FabricaComandos.CrearComandoVerCarrito(this.persona4);
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
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene implementos
        /// </summary>
        [Test]
        public void PruebaCarritoSoloImplementos()
        {
            //Ejecutamos el comando y casteamos
            this.Carrito = (Carrito)this.PruebaVerSoloImplemento.Ejecutar();

            //Revisamos que solo hayan Implementos y efectivamente haya solo uno agregado
            Assert.IsTrue(this.Carrito.ListaImplemento.Count == 1);
            Assert.IsTrue(this.Carrito.Listaevento.Count == 0);
            Assert.IsTrue(this.Carrito.Listamatricula.Count == 0);

            //Obtenemos el implemento y verificamos sus valores
            this.implemento = this.Carrito.ListaImplemento.ElementAt(0).Key as Implemento;
            Assert.AreEqual(this.implemento.Id, 1);
            Assert.AreEqual(this.implemento.Precio_Implemento, 4500);
            Assert.AreEqual(this.Carrito.ListaImplemento.ElementAt(0).Value, 5);            
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene Eventos
        /// </summary>
        [Test]
        public void PruebaCarritoSoloEventos()
        {
            //Ejecutamos el comando y casteamos
            this.Carrito = (Carrito)this.PruebaVerSoloEvento.Ejecutar();

            //Revisamos que solo hayan Eventos y efectivamente haya solo uno agregado
            Assert.IsTrue(this.Carrito.ListaImplemento.Count == 0);
            Assert.IsTrue(this.Carrito.Listaevento.Count == 1);
            Assert.IsTrue(this.Carrito.Listamatricula.Count == 0);

            //Obtenemos el Evento y verificamos sus valores
            this.evento = this.Carrito.Listaevento.ElementAt(0).Key as DominioSKD.Entidades.Modulo9.Evento;
            Assert.AreEqual(this.evento.Id, 1);
            Assert.AreEqual(this.evento.Costo, 0);
            Assert.AreEqual(this.Carrito.Listaevento.ElementAt(0).Value, 6);
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene Matriculas
        /// </summary>
        [Test]
        public void PruebaCarritoSoloMatriculas()
        {
            //Ejecutamos el comando y casteamos
            this.Carrito = (Carrito)this.PruebaVerSoloMatricula.Ejecutar();

            //Revisamos que solo hayan Matriculas y efectivamente haya solo una agregada
            Assert.IsTrue(this.Carrito.ListaImplemento.Count == 0);
            Assert.IsTrue(this.Carrito.Listaevento.Count == 0);
            Assert.IsTrue(this.Carrito.Listamatricula.Count == 1);

            //Obtenemos la Matricula y verificamos sus valores
            this.matricula = this.Carrito.Listamatricula.ElementAt(0).Key as Matricula;
            Assert.AreEqual(this.matricula.Id, 37);
            Assert.AreEqual(this.matricula.Costo, 4250);            
            Assert.AreEqual(this.Carrito.Listamatricula.ElementAt(0).Value, 1);
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que tiene
        /// implementos, eventos y matriculas
        /// </summary>
        [Test]
        public void PruebaCarritoVariosItems()
        {
            //Ejecutamos el comando y casteamos
            this.Carrito = (Carrito)this.PruebaVerTodo.Ejecutar();

            /*Revisamos que hayan Implementos, Eventos y matriculas, ademas,
              que efectivamente haya solo uno agregado de cada uno de ellos*/
            Assert.IsTrue(this.Carrito.ListaImplemento.Count == 1);
            Assert.IsTrue(this.Carrito.Listaevento.Count == 1);
            Assert.IsTrue(this.Carrito.Listamatricula.Count == 1);

            //Obtenemos los items y verificamos sus valores            
            this.implemento = this.Carrito.ListaImplemento.ElementAt(0).Key as Implemento;
            Assert.AreEqual(this.implemento.Id, 1);
            Assert.AreEqual(this.implemento.Precio_Implemento, 4500);
            Assert.AreEqual(this.Carrito.ListaImplemento.ElementAt(0).Value, 5);

            this.evento = this.Carrito.Listaevento.ElementAt(0).Key as DominioSKD.Entidades.Modulo9.Evento;
            Assert.AreEqual(this.evento.Id, 1);
            Assert.AreEqual(this.evento.Costo, 0);
            Assert.AreEqual(this.Carrito.Listaevento.ElementAt(0).Value, 6);

            this.matricula = this.Carrito.Listamatricula.ElementAt(0).Key as Matricula;
            Assert.AreEqual(this.matricula.Id, 37);
            Assert.AreEqual(this.matricula.Costo, 4250);           
            Assert.AreEqual(this.Carrito.Listamatricula.ElementAt(0).Value, 1);
        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            //Elimino de la primera prueba
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona);
            this.ComandoEliminar.Ejecutar();

            //Elimino de la segunda prueba
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem
                (3, this.evento, this.persona2);
            this.ComandoEliminar.Ejecutar();

            //Elimino de la tercera prueba
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(2, this.matricula, this.persona3);
            this.ComandoEliminar.Ejecutar();

            //Elimino de la cuarta prueba
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona4);
            this.ComandoEliminar.Ejecutar();
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem
                (3, this.evento, this.persona4);
            this.ComandoEliminar.Ejecutar();
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(2, this.matricula, this.persona4);
            this.ComandoEliminar.Ejecutar();

            //Dejo en null
            this.ComandoEliminar = null;
            this.PruebaComandoVacio = null;
            this.PruebaComandoVacio2 = null;
            this.PruebaVerSoloImplemento = null;
            this.PruebaVerSoloEvento = null;
            this.PruebaVerSoloMatricula = null;
            this.PruebaVerTodo = null;
            this.pruebaComandoVacio3 = null;
            this.pruebaComandoVacio4 = null;
            this.ComandoAgregarItem = null;
            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.persona4 = null;
            this.implemento = null;            
            this.matricula = null;
            this.Carrito = null;
            this.evento = null;
        }
    }
}
