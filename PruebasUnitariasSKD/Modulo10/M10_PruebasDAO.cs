using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo10;
using DominioSKD;
using DatosSKD.DAO.Modulo10;
using DatosSKD.Fabrica;


namespace PruebasUnitariasSKD.Modulo10
{
    /// <summary>
    /// Clase que se encarga de Realizar las pruebas unitarias de los metodos de la Clase DAO
    /// </summary>
    /// 

    [TestFixture]

    public class M10_PruebasDAO
    {
        #region Atributos

        List<Entidad> listaEntidad;


        #endregion



        [SetUp]
        public void init()
        {
            listaEntidad = new List<Entidad>();
           

        }


        [TearDown]

        public void clean()
        {
            listaEntidad = null;
        }

        #region Pruebas Unitarias

        [Test]

        public void PruebaListarEventosA()
        {

            IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
            listaEntidad =  DAO.ListarEventosAsistidos();
            Assert.NotNull(listaEntidad);
            
        }

               [Test]

        public void PruebaListarEventosAcount()
        {

            IDaoAsistencia DAO = FabricaDAOSqlServer.ObtenerDAOAsistencia();
            listaEntidad =  DAO.ListarEventosAsistidos();
            Assert.AreEqual(1, listaEntidad.ToArray().Length);

      
        }

       

        #endregion

    }
}
