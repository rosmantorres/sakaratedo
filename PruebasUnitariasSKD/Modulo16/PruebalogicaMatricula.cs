using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using NUnit.Framework;
using LogicaNegociosSKD.Modulo16;
using LogicaNegociosSKD;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Clase de pruebas unitarias que trabaja sobre la clase Carrito
    /// </summary>
    /* AUN NO ESTA COMPLETADO */
    [TestFixture]
    public class PruebalogicaMatricula
    {
        #region Atributos
        //Atributos con los que trabajara la clase

        private List<DominioSKD.Matricula> l;
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Preparamos los atributos que vamos a utilizar con valores de prueba
        /// </summary>
        [SetUp]
        public void inicializar()
        {
            List<DominioSKD.Matricula> l = new List<DominioSKD.Matricula>();

        }

        /// <summary>
        /// Prueba unitaria que verifica que se obtiene la lista de compra
        /// </summary>
        [Test]
        public void pruebaobtenerListaMatriculas()
        {
            l =Logicamatricula.mostrarMensualidadesmorosas(1);
            /// Prueba unitaria que verifica que el objeto que instancia a logicaComra no es vacia
            Assert.IsNotNull(l);

            /// Prueba unitaria que verifica que obtener lista de compra es igual que el otro objeto que se compara

            
            Matricula laMatricula = new Matricula();
            laMatricula.Mat_identificador = "CAF - CAF - CAFE";
            laMatricula.Status = true;
            laMatricula.FechaCreacion = Convert.ToDateTime(29 / 11 / 2015);
            laMatricula.UltimaFechapago = Convert.ToDateTime(29 / 11 / 2015);
            Persona persona = new Persona();
            persona.ID = 1;
            laMatricula.IdentificadorUsuario = persona.ID;
            laMatricula.FechaTope = Convert.ToDateTime(29 / 11 / 2015);
            TipoEvento tipeven = new TipoEvento();

             Matricula laMatricula2 = new Matricula();
            laMatricula2.Mat_identificador = "CAF - CAF - CAFE";
            laMatricula2.Status = true;
            laMatricula2.FechaCreacion = Convert.ToDateTime(29 / 11 / 2015);
            laMatricula2.UltimaFechapago = Convert.ToDateTime(29 / 11 / 2015);
            Persona persona2 = new Persona();
            persona2.ID = 1;
            laMatricula2.IdentificadorUsuario = persona.ID;
            laMatricula2.FechaTope = Convert.ToDateTime(29 / 11 / 2015);
            TipoEvento tipeven2 = new TipoEvento();



            l.Add(laMatricula);

            List<DominioSKD.Matricula> l2 = new List<DominioSKD.Matricula>();
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

            l = null;
        }
        #endregion
    }
}

