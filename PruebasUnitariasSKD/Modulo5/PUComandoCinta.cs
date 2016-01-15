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
        private Entidad miEntidadCintaAgregar;
        private Comando<List<Entidad>> miComandoLista;
        private Comando<Entidad> miComandoEntidad;
        

        [SetUp]
        public void init()
        {
            FabricaEntidades miFabrica = new FabricaEntidades();
            fabricaComandos = new FabricaComandos();
            miEntidad = miFabrica.ObtenerOrganizacion_M3(3, "Shotokan Org");
            DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)miEntidad; ;
            miEntidadCinta = miFabrica.ObtenerCinta_M5(1, "Blanco", "1er Kyu", "Nivel inferior", 1, "Principiante", org, true);
            miEntidadCintaModificar = miFabrica.ObtenerCinta_M5(1, "Verde", "1er Kyu", "Nivel inferior", 2, "Principiante", org, true);
            miEntidadCintaAgregar = miFabrica.ObtenerCinta_M5(16, "Rojo", "1er Kyu", "Nivel inferior", 4, "Principiante", org, true);
            
        }

        [Test]
        public void ejecutarElComandoAgregar()
        {
            this.miComando = this.fabricaComandos.ObtenerEjecutarAgregarCinta(miEntidadCintaAgregar);
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

        [Test]
        public void ejecutarElComandoConsultarTodosCinta()
        {
            this.miComandoLista = this.fabricaComandos.ObtenerEjecutarConsultarTodosCinta();
            List<Entidad> resultado = this.miComandoLista.Ejecutar();
            Assert.IsNotEmpty(resultado);

        }


        [Test]
        public void ejecutarElComandoConsultarXIdCinta()
        {
            this.miComandoEntidad = this.fabricaComandos.ObtenerEjecutarConsultarXIdCinta(miEntidadCinta);
            Entidad resultado = this.miComandoEntidad.Ejecutar();
            Assert.IsNotNull(resultado);

        }
    }
}
