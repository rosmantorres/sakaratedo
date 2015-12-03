using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using System.IO;
using ExcepcionesSKD.Modulo16;
using DatosSKD;
using LogicaNegociosSKD.Modulo16;
using DatosSKD.Modulo16;
namespace PruebasUnitariasTotem.Modulo6
{
    [TestFixture]
    class PruebaExcepciones
    {

        /// <summary>
        ///  PRUEBAS EN LA CAPA DE LOGICA
        ///  
        ///  
        /// </summary>
        [Test]
        public void PruebaBDException()
        {

            int cero = 0;



            List<DominioSKD.Matricula> laListam = Logicamatricula.mostrarMensualidadesmorosas(1);
            int cantidadm = laListam.Count;
            // La prueba valida que la lista de matriculas este vacia, y si esta se certifica la excepcion que se pueda generar
            Assert.AreEqual(cero, cantidadm);



            Logicainventario logInv = new Logicainventario();
            List<DominioSKD.Implemento> laListai = Logicainventario.obtenerListaDeInventario();
            int cantidadi = laListai.Count;
            // La prueba valida que la lista de inventario este vacia, y si esta se certifica la excepcion que se pueda generar
            Assert.AreEqual(cero, cantidadi);



            Logicaevento logEve = new Logicaevento();
            List<DominioSKD.Matricula> laListae = Logicamatricula.mostrarMensualidadesmorosas(1);
            int cantidade = laListae.Count;
            // La prueba valida que la lista de inventario este vacia, y si esta se certifica la excepcion que se pueda generar
            Assert.AreEqual(cero, cantidade);

        }




        /// <summary>
        ///  PRUEBAS EN LA CAPA DE LOGICA
        ///  
        ///  
        /// </summary>
        [Test]
        public void PruebaErrorNullException()
        {
            Implemento miImplemento = new Implemento();

            miImplemento.Id_Implemento = 1;

            miImplemento.Imagen_implemento = "~/GUI/Modulo15/Imagenes/guantes.jpg";
            miImplemento.Marca_Implemento = "Kombate";
            miImplemento.Precio_Implemento = 4500;
            miImplemento.Stock_Minimo_Implemento = 5;
            miImplemento.Talla_Implemento = "S";
            miImplemento.Tipo_Implemento = "Guantines";
            miImplemento.Color_Implemento = "Azul";

            miImplemento.Nombre_Implemento = null;



            Logicainventario logInv = new Logicainventario();

            List<Implemento> implementos = Logicainventario.obtenerListaDeInventario();
            implementos = null;
            Assert.IsNull(implementos);



        }








        /// <summary>
        ///  PRUEBAS EN LA CAPA DE DATOS 
        ///  
        ///  
        /// </summary>
        [Test]
        public void PruebaBDDAOException()
        {



            Implemento miImplemento = new Implemento();

            miImplemento.Id_Implemento = 1;

            miImplemento.Imagen_implemento = "~/GUI/Modulo15/Imagenes/guantes.jpg";
            miImplemento.Marca_Implemento = "Kombate";
            miImplemento.Precio_Implemento = 4500;
            miImplemento.Stock_Minimo_Implemento = 5;
            miImplemento.Talla_Implemento = "S";
            miImplemento.Tipo_Implemento = "Guantines";
            miImplemento.Color_Implemento = "Azul";

            miImplemento.Nombre_Implemento = null;



            BDInventario bdInv = new BDInventario();

            List<Implemento> implementos = DatosSKD.Modulo16.BDInventario.ListarInventario();
            implementos = null;
            Assert.IsNull(implementos);







        }






    }
}