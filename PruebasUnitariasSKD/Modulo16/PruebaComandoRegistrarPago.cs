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
{
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
        private Entidad pago;        
        List<String> datoPago;
        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //Dos implementos distintos
            this.implemento = (Implemento)FabricaEntidades.ObtenerImplemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;

            //La persona
            this.persona = FabricaEntidades.ObtenerPersona();
            this.persona.Id = 11;
            this.persona2 = FabricaEntidades.ObtenerPersona();
            this.persona2.Id = 12;
            this.persona3 = FabricaEntidades.ObtenerPersona();
            this.persona3.Id = 13;
            this.persona4 = FabricaEntidades.ObtenerPersona();
            this.persona4.Id = 14;
            this.persona5 = FabricaEntidades.ObtenerPersona();
            this.persona5.Id = 15;
            this.persona6 = FabricaEntidades.ObtenerPersona();
            this.persona6.Id = 16;
            
            //Iniciamos los atributos para la prueba de vacio
            this.datoPago = new List<String>();
            this.datoPago.Add("123456789");
            this.pago = FabricaEntidades.ObtenerPago(111,"Deposito", this.datoPago);
            this.PruebaComandoVacio = FabricaComandos.CrearComandoRegistrarPago();
            this.PruebaComandoVacio2 = FabricaComandos.CrearComandoRegistrarPago(this.persona, this.pago);
            this.pruebaComandoVacio3 = (ComandoRegistrarPago)FabricaComandos.CrearComandoRegistrarPago();
            this.pruebaComandoVacio4 = (ComandoRegistrarPago)FabricaComandos.CrearComandoRegistrarPago
                (this.persona, this.pago);           

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
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;            

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
            Assert.IsNotNull(this.pruebaComandoVacio4.Pago);
        }

        /// <summary>
        /// Prueba Unitaria que trabaja sobre el ejecutar del ComandoRegistrarPago para registrar el pago de carritos
        /// sin implementos o con implementos en los que su cantidad demandada puede ser llenada
        /// </summary>
        [Test]
        public void PruebaRegistrarPagosNormales()
        {
            /*Agregamos y Registramos el pago en un carrito 
            donde solo hay Implementos y su cantidad se puede satisfacer*/
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona, this.implemento, 1, 20);
            this.ComandoAgregarItem.Ejecutar();

            //Insertamos pagos de prueba
            this.datoPago = new List<String>();
            this.datoPago.Add("123456789");
            this.pago = FabricaEntidades.ObtenerPago(45000, "Tarjeta", datoPago);
            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona, this.pago);

            //Registramos el pago en un carrito donde solo hay Implementos y su cantidad se puede satisfacer
            Assert.IsTrue(this.ComandoRegistrarPago.Ejecutar());

            //Insertamos pagos de prueba
            this.datoPago = new List<String>();
            this.datoPago.Add("123456789");
            this.pago = FabricaEntidades.ObtenerPago(45000, "Tarjeta", datoPago);
            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona, this.pago);

            //Registramos el pago en un carrito donde solo hay Implementos y su cantidad se puede satisfacer
            Assert.IsTrue(this.ComandoRegistrarPago.Ejecutar());

            //Intentamos registrar el pago de un carrito no existente
            Assert.IsFalse(this.ComandoRegistrarPago.Ejecutar());           

            /*Agregamos y Registramos el pago en un carrito donde solo hay eventos*/
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.evento, 2, 10);
            this.ComandoAgregarItem.Ejecutar();

            //Insertamos pagos de prueba
            this.datoPago = new List<String>();
            this.datoPago.Add("123456789");
            this.pago = FabricaEntidades.ObtenerPago(0, "Tarjeta", datoPago);
            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona2, this.pago);

            //Registramos el pago en un carrito donde solo hay eventos
            Assert.IsTrue(this.ComandoRegistrarPago.Ejecutar());

            //Intentamos registrar el pago de un carrito que ya no existe
            Assert.IsFalse(this.ComandoRegistrarPago.Ejecutar());

            /*Agregamos y Registramos el pago de un carrito donde solo hay matriculas*/
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona3, this.matricula, 3, 10);
            this.ComandoAgregarItem.Ejecutar();

            //Insertamos pagos de prueba
            this.datoPago = new List<String>();
            this.datoPago.Add("123456789");
            this.pago = FabricaEntidades.ObtenerPago(25000, "Tarjeta", datoPago);
            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona3, this.pago);

            //Registramos el pago en un carrito donde solo hay matriculas
            Assert.IsTrue(this.ComandoRegistrarPago.Ejecutar());

            //Insertamos pagos de prueba
            this.datoPago = new List<String>();
            this.datoPago.Add("123456789");
            this.pago = FabricaEntidades.ObtenerPago(25000, "Tarjeta", datoPago);
            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona3, this.pago);

            //Registramos el pago en un carrito donde solo hay matriculas
            Assert.IsTrue(this.ComandoRegistrarPago.Ejecutar());

            //Intentamos registrar el pago de un carrito que no
            Assert.IsFalse(this.ComandoRegistrarPago.Ejecutar());

            /*Agregamos y pagamos un carrito que tiene implementos, eventos y matriculas*/
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.implemento, 1, 20);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem
                (this.persona4, this.evento, 2, 10);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.matricula, 3, 10);
            this.ComandoAgregarItem.Ejecutar();

            //Insertamos pagos de prueba
            this.datoPago = new List<String>();
            this.datoPago.Add("123456789");
            this.pago = FabricaEntidades.ObtenerPago(1900000, "Tarjeta", datoPago);
            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona4, this.pago);

            //Registramos el pago de un carrito donde hay Implementos, eventos y matirculas
            Assert.IsTrue(this.ComandoRegistrarPago.Ejecutar());

            //Intentamos registrar un pago en un carrito que ya no existe
            Assert.IsFalse(this.ComandoRegistrarPago.Ejecutar());
        }

        /// <summary>
        /// Prueba Unitaria que trabaja sobre el ejecutar del ComandoRegistrarPago para intentar Registrar el pago 
        /// de un carrito donde la cantidad de implementos demandada no existe en el inventario
        /// </summary>
        [Test]
        public void PruebaRegistrarPagosImplementosExceso()
        {
            //Insertamos pagos de prueba
            this.datoPago = new List<String>();
            this.datoPago.Add("123456789");
            this.pago = FabricaEntidades.ObtenerPago(1900000, "Tarjeta", this.datoPago);
            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona5, this.pago);

            //Se trata de registrar el pago de un carrito donde solo hay implementos
            Assert.IsFalse(this.ComandoRegistrarPago.Ejecutar());

            //Se trata de registrar el pago de un carrito donde hay cualquier otro producto
            this.ComandoRegistrarPago = FabricaComandos.CrearComandoRegistrarPago(this.persona6, this.pago);
            Assert.IsFalse(this.ComandoRegistrarPago.Ejecutar());
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
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(3, this.evento, this.persona6);
            this.ComandoEliminar.Ejecutar();
            this.ComandoEliminar = FabricaComandos.CrearComandoeliminarItem(2, this.matricula, this.persona6);
            this.ComandoEliminar.Ejecutar();

            //Limpio los demas valores
            this.ComandoEliminar = null;
            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.persona4 = null;
            this.persona5 = null;
            this.persona6 = null;
            this.matricula = null;
            this.implemento = null;
            this.evento = null;
            this.PruebaComandoVacio = null;
            this.PruebaComandoVacio2 = null;
            this.pruebaComandoVacio3 = null;
            this.pruebaComandoVacio4 = null;
            this.ComandoAgregarItem = null;
            this.ComandoRegistrarPago = null;
            this.pago = null;
            this.datoPago = null;
        }
    }
}
