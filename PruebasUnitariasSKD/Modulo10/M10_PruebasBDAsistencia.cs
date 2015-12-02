using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;

namespace PruebasUnitariasSKD.Modulo10
{
    /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase BDAsistencia
    /// </summary>
    /// 

    [TestFixture]
    class M10_PruebasBDAsistencia
    {
        #region Atributos
        private int idDeEvento;
        private Evento evento;


        #endregion


        #region SetUp&TearDown

        [SetUp]
        public void Init()
        {
            idDeEvento = 1;
            evento = new Evento();
            evento.Nombre = "Pase a Negra";
            DateTime fechaInicio = new DateTime(2015, 11, 15, 8, 30, 52);
            DateTime fechaFin = new DateTime(2015, 11, 15, 1, 1, 1);
            Horario Horarios = new Horario(3, fechaInicio, fechaFin, 1, 3);
            TipoEvento TipoEvento = new TipoEvento();
            TipoEvento = new TipoEvento();
            TipoEvento.Nombre = "Pase de Cinta";
            evento.Horario = Horarios;
            evento.TipoEvento = TipoEvento;

        }
        [TearDown]

        public void clean()
        {
            idDeEvento = 0;
            evento = null;
        }

        #endregion

        #region Pruebas Unitarias


        [Test]
        public void ListarEventosAsistidos()
        {

        }


        #endregion
    }
}
