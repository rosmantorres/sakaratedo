using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using ExcepcionesSKD.Modulo4;
using LogicaNegociosSKD.Modulo4;

namespace PruebasUnitariasSKD.Modulo4
{
     [TestFixture]
    class M4_PruebaLogicaDojo
    {
       
        
            #region Atributos
            /// <summary>
            /// Atributo que representa el id del Dojo
            /// </summary>
            private int idDojo;
            /// <summary>
            /// Atributo que representa la clase LogicaEventosPagos
            /// </summary>
            LogicaDojo logicaDojo;
            #endregion

            #region SetUp & TearDown
            [SetUp]
            public void Init()
            {
                logicaDojo = new LogicaDojo();
                idDojo = 4;
            }

            [TearDown]
            public void Clean()
            {
                logicaDojo = null;
                idDojo = 0;
            }
            #endregion

            #region Test

            /// <summary>
            /// Método para probar que la lista obtenida puede tener cero o mas Dojos
            /// </summary>
            [Test]
            public void PruebaObtenerListaDojos()
            {
                List<Dojo> listaDojo = logicaDojo.obtenerListaDeDojos();
                Assert.GreaterOrEqual(listaDojo.Count, 0);
            }

            /// <summary>
            /// Método para probar que se detalla un Dojo
            /// </summary>
            [Test]
            public void PruebaDetalleDojo()
            {
                Dojo elDojo = logicaDojo.detalleDojoXId(idDojo);
                Assert.AreEqual(elDojo.Id_dojo, idDojo);
            }

             /// <summary>
            /// Método para probar que se detalla una competencia
            /// </summary>
            [Test]
            public void PruebaObtenerDetalleDojo()
            {
                bool prueba = true;
                Ubicacion ubi = new Ubicacion();
                ubi.Latitud = "200045";
                ubi.Longitud ="-12764";
                ubi.Estado = "Distrito Capital";
                ubi.Ciudad ="Caracas";
                DateTime fecha = new DateTime(01/01/2011);
                Historial_Matricula his = new Historial_Matricula(fecha, "Anual", 2340);
                Dojo elDojo = new Dojo("j-12345666-0", "DojoNuevo", 02124234567, "dojonuevo@gmail.com", "Dai-Fu.jpeg","false",2,ubi);
                bool agrego = logicaDojo.agregarDojo(elDojo,his,ubi);
                Assert.AreEqual(agrego,prueba);
            }



            #endregion
        }
    
}
