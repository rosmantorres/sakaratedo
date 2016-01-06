using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.Fabrica;
using DatosSKD.DAO.Modulo7;
using DominioSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD.Modulo7;

namespace PruebasUnitariasSKD.Modulo7.PruebasDAO
{

    /// <summary>
    /// Clase que contiene las pruebas unitarias para DaoCinta
    /// </summary>
    [TestFixture]
    public class M7_PruebasDAOEvento
    {
        #region Atributos
        Persona idPersona;
        FabricaEntidades fabricaEntidades;
        FabricaDAOSqlServer fabricaSql;
        #endregion

        #region SetUp & TearDown
        [SetUp]
        public void Init()
        {
            fabricaSql = new FabricaDAOSqlServer();
            fabricaEntidades = new FabricaEntidades();
            idPersona = new Persona();
            idPersona.ID = 6;
        }

        [TearDown]
        public void Clean()
        {
            idPersona = null;
            fabricaEntidades = null;
            fabricaSql = null;
        }
        #endregion
        /// <summary>
        /// Método de prueba para ConSultarXId en DAO
        /// </summary>
        [Test]
        public void PruebaDetallarEventoXId()
        {

            DaoEvento baseDeDatosEvento = new DaoEvento();//esto se sustituye con la fabrica
            Evento idEvento = (Evento)fabricaEntidades.ObtenerEvento();
            idEvento.Id = 5;
            Evento evento = (Evento)baseDeDatosEvento.ConsultarXId(idEvento);
            Assert.AreEqual("La vida en el Dojo", evento.Nombre);
        }
        /// <summary>
        /// Método para probar que una matriculada detallado no sea nulo
        /// </summary>
        [Test]
        public void PruebaDetallarEventoXIdNoNulo()
        {
            DaoEvento baseDeDatosEvento = new DaoEvento();//esto se sustituye con la fabrica
            Evento idEvento = (Evento)fabricaEntidades.ObtenerEvento();
            idEvento.Id = 5;
            Evento evento = (Evento)baseDeDatosEvento.ConsultarXId(idEvento);
            Assert.NotNull(evento);
        }

        /// <summary>
        /// Método para probar la exception de número entero invalido de prueba detalle evento
        /// </summary>

        [Test]
        [ExpectedException(typeof(NumeroEnteroInvalidoException))]
        public void DetalleEventoNumeroEnteroException()
        {
            DaoEvento baseDeDatosEvento = new DaoEvento();//esto se sustituye con la fabrica
            Evento idEvento = (Evento)fabricaEntidades.ObtenerEvento();;
            idEvento.Id = -1;
            Evento evento = (Evento)baseDeDatosEvento.ConsultarXId(idEvento);
        }

      

    }
}
