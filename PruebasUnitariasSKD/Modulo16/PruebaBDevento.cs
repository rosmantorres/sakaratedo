using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using NUnit.Framework;
using DatosSKD.Modulo16;


namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Clase de pruebas unitarias que trabaja sobre la clase Carrito
    /// </summary>
    /* AUN NO ESTA COMPLETADO */
    [TestFixture]
    public class PruebaBDevento
    {
        #region Atributos
        //Atributos con los que trabajara la clase

        private BDEvento bdeve;
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            BDEvento bdeve = new BDEvento();

        }

        /// <summary>
        /// Prueba unitaria que verifica que se obtiene la lista de compra
        /// </summary>
        [Test]
        public void pruebaobtenerListaEvento()
        {

            /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
            Assert.IsNotNull(DatosSKD.Modulo16.BDEvento.ListarEvento());

            /// Prueba unitaria que verifica que obtener lista de compra es igual que el otro objeto que se compara

            List<DominioSKD.Evento> l = DatosSKD.Modulo16.BDEvento.ListarEvento();
            List<DominioSKD.Evento> l2 = DatosSKD.Modulo16.BDEvento.ListarEvento();


            Evento elEvento = new Evento();
            elEvento.Id_evento = 1;
            elEvento.Nombre = "Clase Regular";
            elEvento.Descripcion = "Clases regulares del atleta que va los dias asignados";

            Evento elEvento2 = new Evento();
            elEvento2.Id_evento = 1;
            elEvento2.Nombre = "Clase Regular";
            elEvento2.Descripcion = "Clases regulares del atleta que va los dias asignados";


            List<DominioSKD.Evento> listeve = new List<DominioSKD.Evento>();
            listeve.Add(elEvento);

            List<DominioSKD.Evento> listeve2 = new List<DominioSKD.Evento>();
            listeve2.Add(elEvento2);


            /// Prueba unitaria que verifica que las dos listas tienen igual contenido
            Assert.AreEqual(listeve, listeve2);


            /// Prueba unitaria que verifica que se obtiene la misma informacion de las dos listas 

            Assert.AreEqual(l, l2);
        }



        /// <summary>
        /// Prueba unitaria que verifica que se obtiene la lista de compra
        /// </summary>
        [Test]
        public void pruebadetallarEvento()
        {
            /// Prueba unitaria que verifica que el objeto que instancia a bdComra no es vacia
            Assert.IsNotNull(DatosSKD.Modulo16.BDEvento.DetallarEvento(1));

            /// Prueba unitaria que verifica que el detalle del evento da igual para el id 1

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



            Evento miEvento2 = new Evento();
            miEvento2.Id_evento = 1;
            miEvento2.Nombre = "Clase Regular";
            TipoEvento tipeven2 = new TipoEvento();
            tipeven2.Id = 4;
            tipeven2.Nombre = "Clases Regulares";
            miEvento2.TipoEvento = tipeven;
            Horario horario2 = new Horario();
            horario2.FechaFin = Convert.ToDateTime(15 / 10 / 2016);
            horario2.FechaInicio = Convert.ToDateTime(15 / 10 / 2015);
            horario2.Id = 1;
            horario2.HoraFin = 4;
            horario2.HoraInicio = 2;
            miEvento2.Horario = horario;
            miEvento2.Costo = 0;
            miEvento2.Categoria = null;
            Ubicacion ubicacion2 = new Ubicacion();
            ubicacion2.Ciudad = "Caracas";
            ubicacion2.Direccion = null;
            ubicacion2.Id_ubicacion = 1;
            ubicacion2.Latitud = "10.499607";
            ubicacion2.Longitud = "-66.788419";
            miEvento2.Ubicacion = ubicacion;



            Assert.AreEqual(DatosSKD.Modulo16.BDEvento.DetallarEvento(miEvento.Id_evento), DatosSKD.Modulo16.BDEvento.DetallarEvento(miEvento2.Id_evento));

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

            bdeve = null;
        }
        #endregion
    }
}