using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo5;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo5;
using DominioSKD.Entidades.Modulo3;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo5;
using DatosSKD.DAO.Modulo5;
using LogicaNegociosSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo5
{
    [TestFixture]
    class PUComandoCinta
    {
        private Comando<bool> miComando;
        private Entidad miEntidad;
        private Entidad miEntidadCinta;
        private Entidad miEntidadCintaModificar;
        FabricaComandos fabricaComandos;
        

        [SetUp]
        public void init()
        {
            FabricaEntidades miFabrica = new FabricaEntidades();
            miEntidad = miFabrica.ObtenerOrganizacion_M3(1, "Seito Karate-do");
            DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)miEntidad; ;
            miEntidadCinta = miFabrica.ObtenerCinta_M5(1, "Blanco", "1er Kyu", "Nivel inferior", 1, "Principiante", org, true);
            miEntidadCintaModificar = miFabrica.ObtenerCinta_M5(1, "Amarillo", "1er Kyu", "Nivel inferior", 3, "Principiante", org, true);
           
        }

        [Test]
        public void ejecutarElComandoAgregar()
        {
         //   EjecutarAgregarCinta EjecutarAgregar = this.fabricaComandos.ObtenerEjecutarAgregarCinta(miEntidadCinta);
            this.miComando = this.fabricaComandos.ObtenerEjecutarAgregarCinta(miEntidadCinta);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);
        
        }


        [Test]
        public void ejecutarElComandoModificar()
        {
            this.miComando = this.fabricaComandos.ObtenerEjecutarModificarCinta(miEntidadCintaModificar);
            bool resultado = this.miComando.Ejecutar();
            Assert.IsFalse(resultado);

        }
    }
}
