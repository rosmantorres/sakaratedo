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
    public class PruebaBDMatricula
    {
        #region Atributos
        //Atributos con los que trabajara la clase

        private BDMatricula bdmat;
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            BDMatricula bdmat = new BDMatricula();

        }

        /// <summary>
        /// Prueba unitaria que verifica que se obtiene la lista de compra
        /// </summary>
        [Test]
        public void pruebaobtenerListaMatriculas()
        {

            /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
            Assert.IsNotNull(DatosSKD.Modulo16.BDMatricula.mostrarMensualidadesmorosas(1));

            /// Prueba unitaria que verifica que obtener lista de compra es igual que el otro objeto que se compara



            List<DominioSKD.Matricula> l = DatosSKD.Modulo16.BDMatricula.mostrarMensualidadesmorosas(1);
            List<DominioSKD.Matricula> l2 = DatosSKD.Modulo16.BDMatricula.mostrarMensualidadesmorosas(1);

            Matricula laMatricula = new Matricula();
            laMatricula.Identificador = "CAF - CAF - CAFE";
           
            laMatricula.FechaCreacion = Convert.ToDateTime(29 / 11 / 2015);
            laMatricula.UltimaFechaPago = Convert.ToDateTime(29 / 11 / 2015);
            Persona persona = new Persona();
            persona.ID = 1;
            
            
            TipoEvento tipeven = new TipoEvento();

            Matricula laMatricula2 = new Matricula();
            laMatricula2.Identificador = "CAF - CAF - CAFE";
         
            laMatricula2.FechaCreacion = Convert.ToDateTime(29 / 11 / 2015);
            laMatricula2.UltimaFechaPago = Convert.ToDateTime(29 / 11 / 2015);
            Persona persona2 = new Persona();
            persona2.ID = 1;
             
           
            TipoEvento tipeven2 = new TipoEvento();



            l.Add(laMatricula);
            l2.Add(laMatricula2);
            Assert.AreEqual(l, l2);

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

            bdmat = null;
        }
        #endregion
    }
}