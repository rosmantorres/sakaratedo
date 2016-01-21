using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Entidades.Modulo6;
using LogicaNegociosSKD.Comandos.Modulo16;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using DominioSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo16
{/*
    /// <summary>
    /// Prueba unitaria del Caso de Uso Registrar Pago
    /// </summary>
    [TestFixture]
    public class PruebaComandoRegistrarPago
    {
        #region Atributos
        //Atributos pertinentes a usar
        private Comando<bool> ComandoEliminar;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Entidad persona4;
        private Entidad persona5;
        private Entidad persona6;
        private Matricula matricula;
        private Implemento implemento;        
        private DominioSKD.Entidades.Modulo9.Evento evento;
        private Comando<bool> PruebaComandoVacio;
        private Comando<bool> PruebaComandoVacio2;
        private ComandoRegistrarPago pruebaComandoVacio3;
        private ComandoRegistrarPago pruebaComandoVacio4;
        private Comando<bool> ComandoAgregarItem;
        private Comando<bool> ComandoRegistrarPago;
        private Comando<bool> ComandoRegistrarPago2;
        private Comando<bool> ComandoRegistrarPago3;
        private Comando<bool> ComandoRegistrarPago4;
        private Comando<bool> ComandoRegistrarPago5;
        private Comando<bool> ComandoRegistrarPago6;
        private FabricaEntidades fabrica;  
        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //Las fabricas
            fabrica = new FabricaEntidades();           

            //Dos implementos distintos
            this.implemento = new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;
            
            //Iniciamos los atributos para la prueba de vacio
            this.persona = fabrica.ObtenerPersona();
            this.PruebaComandoVacio = FabricaComandos.CrearComandoRegistrarPago();
            this.PruebaComandoVacio2 = FabricaComandos.CrearComandoRegistrarPago(this.persona, "prueba");
            this.pruebaComandoVacio3 = (ComandoRegistrarPago)FabricaComandos.CrearComandoRegistrarPago();
            this.pruebaComandoVacio4 = (ComandoRegistrarPago)FabricaComandos.CrearComandoRegistrarPago
                (this.persona, "prueba");
            
            //La persona
            this.persona.Id = 11;
            this.persona2 = fabrica.ObtenerPersona();
            this.persona2.Id = 12;
            this.persona3 = fabrica.ObtenerPersona();
            this.persona3.Id = 13;
            this.persona4 = fabrica.ObtenerPersona();
            this.persona4.Id = 14;
            this.persona5 = fabrica.ObtenerPersona();
            this.persona5.Id = 15;
            this.persona6 = fabrica.ObtenerPersona();
            this.persona6.Id = 16;

            //Implemento
            this.implemento = new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;

            //Eventos
            this.evento = (DominioSKD.Entidades.Modulo9.Evento)fabrica.ObtenerEvento();
            this.evento.Id = 1;
            this.evento.Costo = 0;

            //Matricula
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;

            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona, "Tarjeta");
            this.ComandoRegistrarPago2 = FabricaComandos.CrearComandoRegistrarPago(this.persona2, "Deposito");
            this.ComandoRegistrarPago3 = FabricaComandos.CrearComandoRegistrarPago(this.persona3, "Transferencia");
            this.ComandoRegistrarPago4 = FabricaComandos.CrearComandoRegistrarPago(this.persona4, "Tarjeta");

            //Insertamos la cantidad de implementos que no pueden ser satisfechos por el stock
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona5, this.implemento, 1, 10);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();

            //Insertamos una cantidad de inventario que no puede ser satisfecho de igual forma para esta persona
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona6, this.implemento, 1, 10);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem.Ejecutar();

            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem
                (this.persona6, this.evento, 2, 10);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona6, this.matricula, 3, 10);
            this.ComandoAgregarItem.Ejecutar();

            this.ComandoRegistrarPago5 = FabricaComandos.CrearComandoRegistrarPago(this.persona5, "Tarjeta");
            this.ComandoRegistrarPago6 = FabricaComandos.CrearComandoRegistrarPago(this.persona6, "Deposito");


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
            Assert.IsNotNull(this.pruebaComandoVacio4.TipoPago);
        }

        /// <summary>
        /// Prueba Unitaria que trabaja sobre el ejecutar del ComandoRegistrarPago para registrar el pago de carritos
        /// sin implementos o con implementos en los que su cantidad demandada puede ser llenada
        /// </summary>
        [Test]
        public void PruebaRegistrarPagosNormales()
        {
            //Agregamos datos ficticios en carritos
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona, this.implemento, 1, 20);
            this.ComandoAgregarItem.Ejecutar();      

            //Registramos el pago en un carrito donde solo hay Implementos y su cantidad se puede satisfacer
            Assert.IsTrue(this.ComandoRegistrarPago.Ejecutar());

            //Agregamos un item para la persona2
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.evento, 2, 10);
            this.ComandoAgregarItem.Ejecutar();

            //Registramos el pago en un carrito donde solo hay eventos
            Assert.IsTrue(this.ComandoRegistrarPago2.Ejecutar());

            //Agregamos un item para la persona3
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona3, this.matricula, 3, 10);
            this.ComandoAgregarItem.Ejecutar();  

            //Registramos el pago en un carrito donde solo hay matriculas
            Assert.IsTrue(this.ComandoRegistrarPago3.Ejecutar());

            //Agregamos items de prueba para la persona4
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.implemento, 1, 20);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem
                (this.persona4, this.evento, 2, 10);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.matricula, 3, 10);
            this.ComandoAgregarItem.Ejecutar();

            //Registramos el pago de un carrito donde hay Implementos, eventos y matirculas
            Assert.IsTrue(this.ComandoRegistrarPago4.Ejecutar());
        }

        /// <summary>
        /// Prueba Unitaria que trabaja sobre el ejecutar del ComandoRegistrarPago para intentar Registrar el pago 
        /// de un carrito donde la cantidad de implementos demandada no existe en el inventario
        /// </summary>
        [Test]
        public void PruebaRegistrarPagosImplementosExceso()
        {
            //Se trata de registrar el pago de un carrito donde solo hay implementos
            Assert.IsFalse(this.ComandoRegistrarPago5.Ejecutar());

            //Se trata de registrar el pago de un carrito donde hay cualquier otro producto
            Assert.IsFalse(this.ComandoRegistrarPago6.Ejecutar());
        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
           //Elimino de la persona5
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona5);
            this.ComandoEliminar.Ejecutar();

            //Elimino de la persona6
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(1, this.implemento, this.persona6);
            this.ComandoEliminar.Ejecutar();
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(3, this.implemento, this.persona6);
            this.ComandoEliminar.Ejecutar();
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(2, this.implemento, this.persona6);
            this.ComandoEliminar.Ejecutar();

            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.persona4 = null;
            this.persona5 = null;
            this.persona6 = null;
            this.matricula = null;
            this.implemento = null;           
            this.PruebaComandoVacio = null;
            this.PruebaComandoVacio2 = null;
            this.pruebaComandoVacio3 = null;
            this.pruebaComandoVacio4 = null;
            this.ComandoAgregarItem = null;
            this.ComandoRegistrarPago = null;
            this.ComandoRegistrarPago2 = null;
            this.ComandoRegistrarPago3 = null;
            this.ComandoRegistrarPago4 = null;
            this.ComandoRegistrarPago5 = null;
            this.ComandoRegistrarPago6 = null;
            this.fabrica = null;          
            this.evento = null;
        }
    }*/
}
