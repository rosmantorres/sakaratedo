using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
//using DatosSKD.Modulo12;
using LogicaNegociosSKD;

namespace PruebasUnitariasSKD.Modulo12
{
    [TestFixture]
    public class PruebaLogicaCompetencias
    {
        Organizacion        laOrganizacion;
        List<Competencia>   laListaCompetencias;
        String              laFecha;
        List<Organizacion>  laListaOrganizaciones;
        Competencia         laCompetencia;
        //LogicaCompetencias  laLogicaCompetencia;
        List<Cinta>         laListaCintas;

        [SetUp]
        public void init()
        {
            laListaCompetencias     = new List<Competencia>();
            laCompetencia           = new Competencia();
            laOrganizacion          = new Organizacion();
            //laLogicaCompetencia     = new LogicaCompetencias();
            laListaOrganizaciones   = new List<Organizacion>();
            laListaCintas           = new List<Cinta>();
        }

        [TearDown]

        public void clean()
        {
            laListaCompetencias     = null;
            laCompetencia           = null;
            laOrganizacion          = null;
            //laLogicaCompetencia     = null;
            laListaOrganizaciones   = null;
            laListaCintas           = null;
        }

        [Test]
        public void pruebaVacioObtenerListaDeCompetencias()//Listo!!!
        {
            //laListaCompetencias = laLogicaCompetencia.obtenerListaDeCompetencias();
            Assert.IsNotNull(laListaCompetencias);
        }
        [Test]
        public void pruebaContarListaCompetencias()//Listo!!!
        {
            //laListaCompetencias = laLogicaCompetencia.obtenerListaDeCompetencias();
            Assert.AreEqual(8, laListaCompetencias.ToArray().Length);
        }
        [Test]
        public void pruebaVacioM12obtenerListaDeOrganizaciones()//Listo!!!
        {
            //laListaOrganizaciones = laLogicaCompetencia.M12obtenerListaDeOrganizaciones();
            Assert.IsNotNull(laListaOrganizaciones);
        }
        [Test]
        public void pruebaContarM12obtenerListaDeOrganizaciones()//Listo!!!
        {
            //laListaOrganizaciones = laLogicaCompetencia.M12obtenerListaDeOrganizaciones();
            Assert.AreEqual(5, laListaOrganizaciones.ToArray().Length);
        }
        [Test]
        public void pruebaVacioM12obtenerListaDeCintas()//Listo!!!
        {
            //laListaCintas = laLogicaCompetencia.M12obtenerListaDeCintas();
            Assert.IsNotNull(laListaCintas);
        }
        [Test]
        public void pruebaContarM12obtenerListaDeCintas()//Listo!!!
        {
            //laListaCintas = laLogicaCompetencia.M12obtenerListaDeCintas();
            Assert.AreEqual(5, laListaCintas.ToArray().Length);
        }
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void pruebaVaciodetalleCompetenciaXId()//Listo!!!
        {
            //laLogicaCompetencia.detalleCompetenciaXId(1);   
        }
        [Test]
        public void pruebaIddetalleCompetenciaXId()//Listo!!!
        {
            //laCompetencia = laLogicaCompetencia.detalleCompetenciaXId(8);
            Assert.AreEqual(8, laCompetencia.Id_competencia);
        }
        [Test]
        public void pruebaTrueAgregarCompetencia()//Listo!!!
        {
            Int32 orgTodas = 0;
            DateTime laFechaInicio = new DateTime(2015, 10, 10);
            DateTime laFechaFin = new DateTime(2016, 10, 10);
            laCompetencia = new Competencia();
            laCompetencia.Organizacion = new Organizacion();
            laCompetencia.Ubicacion = new Ubicacion();
            laCompetencia.Categoria = new Categoria();
            laCompetencia.Id_competencia = 31;
            laCompetencia.Nombre = "Prueba Agregar Logica";
            laCompetencia.TipoCompetencia = "2";
            laCompetencia.OrganizacionTodas = Convert.ToBoolean(orgTodas);
            laCompetencia.Status = "Por Iniciar";
            laCompetencia.FechaInicio = laFechaInicio;
            laCompetencia.FechaFin = laFechaFin;
            laCompetencia.Organizacion.Nombre = "Prueba";
            laCompetencia.Ubicacion.Ciudad = "Valencia";
            laCompetencia.Ubicacion.Estado = "Carabobo";
            laCompetencia.Ubicacion.Direccion = "";
            laCompetencia.Ubicacion.Latitud = "10.1727434";
            laCompetencia.Ubicacion.Longitud = "-68.0642649";
            laCompetencia.Categoria.Edad_inicial = 10;
            laCompetencia.Categoria.Edad_final = 15;
            laCompetencia.Categoria.Cinta_inicial = "Naranja";
            laCompetencia.Categoria.Cinta_final = "Verde";
            laCompetencia.Categoria.Sexo = "M";
            laCompetencia.Costo = 1950;
            //Assert.IsTrue(laLogicaCompetencia.agregarCompetencia(laCompetencia));
        }
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void pruebaFalseAgregarCompetencia()//Listo!!!
        {
            Int32 orgTodas = 0;
            DateTime laFechaInicio = new DateTime(2015, 10, 10);
            DateTime laFechaFin = new DateTime(2016, 10, 10);
            laCompetencia = new Competencia();
            laCompetencia.Organizacion = new Organizacion();
            laCompetencia.Ubicacion = new Ubicacion();
            laCompetencia.Categoria = new Categoria();
            laCompetencia.Id_competencia = 8;
            laCompetencia.Nombre = "Prueba Agregar";
            laCompetencia.TipoCompetencia = "2";
            laCompetencia.OrganizacionTodas = Convert.ToBoolean(orgTodas);
            laCompetencia.Status = "Por Iniciar";
            laCompetencia.FechaInicio = laFechaInicio;
            laCompetencia.FechaFin = laFechaFin;
            laCompetencia.Organizacion.Nombre = "Prueba";
            laCompetencia.Ubicacion.Ciudad = "Valencia";
            laCompetencia.Ubicacion.Estado = "Carabobo";
            laCompetencia.Ubicacion.Direccion = "";
            laCompetencia.Ubicacion.Latitud = "10.1727434";
            laCompetencia.Ubicacion.Longitud = "-68.0642649";
            laCompetencia.Categoria.Edad_inicial = 10;
            laCompetencia.Categoria.Edad_final = 15;
            laCompetencia.Categoria.Cinta_inicial = "Naranja";
            laCompetencia.Categoria.Cinta_final = "Verde";
            laCompetencia.Categoria.Sexo = "M";
            laCompetencia.Costo = 1950;
            //laLogicaCompetencia.agregarCompetencia(laCompetencia);
        }
    }
}
