using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo12;

namespace PruebasUnitariasSKD.Modulo12
{
    [TestFixture]
    public class PruebaBDCompetencias
    {
        DominioSKD.Organizacion         laOrganizacion;
        List<Competencia>               laLista;
        String                          laFecha;
        List<Organizacion>              laListaOrganizaciones;
        Competencia                     laCompetencia;
        BDCompetencia                   laBDCompetencia;
        List<Cinta>                     laListaCintas;
        
        [SetUp]
        public void init()
        {
            laLista                     = new List<Competencia>();
            laCompetencia               = new Competencia();
            laOrganizacion              = new Organizacion();
            laBDCompetencia             = new BDCompetencia();
            laListaOrganizaciones       = new List<Organizacion>();
            laListaCintas               = new List<Cinta>();
        }

        [TearDown]
        public void clean()
        {
            laLista                     = null;
            laCompetencia               = null;
            laOrganizacion              = null;
            laBDCompetencia             = null;
            laListaOrganizaciones       = null;
            laListaCintas               = null;
        }

        [Test]
        public void pruebaVacioListaCompetencias()//Listo!!!
        {
            laLista = laBDCompetencia.ListarCompetencias();
            Assert.IsNotNull(laLista);
        }
        [Test]
        public void pruebaContarListaCompetencias()//Listo!!!
        {
            laLista = laBDCompetencia.ListarCompetencias();
            Assert.AreEqual(7, laLista.ToArray().Length);
        }
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void pruebaVacioDetallarCompetencia()//List!!!
        {
            laBDCompetencia.DetallarCompetencia(1);
        }
        [Test]
        public void pruebaIdDetallarCompetencia()//Listo!!!
        {
            laCompetencia = laBDCompetencia.DetallarCompetencia(8);
            Assert.AreEqual(8, laCompetencia.Id_competencia);
        }
        [Test]
        public void pruebaTrueBuscarNombreCompetencia()//Listo!!!
        {
            laCompetencia.Id_competencia = 1;
            laCompetencia.Nombre = "Ryu Kobudo";
            laCompetencia.TipoCompetencia = "2";
            laCompetencia.OrganizacionTodas = true;
            laCompetencia.Status = "Por Iniciar";
            Assert.IsTrue(laBDCompetencia.BuscarNombreCompetencia(laCompetencia));
        }
        [Test]
        public void pruebaFalseBuscarNombreCompetencia()//Listo!!!
        {
            laCompetencia.Id_competencia = 1;
            laCompetencia.Nombre = "Ryu K";
            laCompetencia.TipoCompetencia = "1";
            laCompetencia.OrganizacionTodas = true;
            laCompetencia.Status = "Por Iniciar";
            Assert.IsFalse(laBDCompetencia.BuscarNombreCompetencia(laCompetencia));
        }
        [Test]
        public void pruebaTrueBuscarIDCompetencia()//Listo!!!
        {
            laCompetencia.Id_competencia = 8;
            laCompetencia.Nombre = "Ryu Kobudo";
            laCompetencia.TipoCompetencia = "1";
            laCompetencia.OrganizacionTodas = true;
            laCompetencia.Status = "Por Iniciar";
            Assert.IsTrue(laBDCompetencia.BuscarIDCompetencia(laCompetencia));
        }
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void pruebaFalseBuscarIDCompetencia()//Listo!!!
        {
            laCompetencia.Id_competencia = 19;
            laCompetencia.Nombre = "Ryu K";
            laCompetencia.TipoCompetencia = "1";
            laCompetencia.OrganizacionTodas = true;
            laCompetencia.Status = "Por Iniciar";
            laBDCompetencia.BuscarIDCompetencia(laCompetencia);
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
            laCompetencia.Id_competencia = 21;
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

            Assert.IsTrue(laBDCompetencia.AgregarCompetencia(laCompetencia));
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
            laBDCompetencia.AgregarCompetencia(laCompetencia);
        }
        [Test]
        public void pruebaTrueModificarCompetencia()//Listo!!!
        {
            Int32 orgTodas = 0;
            DateTime laFechaInicio = new DateTime(2001, 10, 10);
            DateTime laFechaFin = new DateTime(2016, 10, 10);
            laCompetencia = new Competencia();
            laCompetencia.Organizacion = new Organizacion();
            laCompetencia.Ubicacion = new Ubicacion();
            laCompetencia.Categoria = new Categoria();
            laCompetencia.Id_competencia = 19;
            laCompetencia.Nombre = "Prueba Modificar";
            laCompetencia.TipoCompetencia = "2";
            laCompetencia.OrganizacionTodas = Convert.ToBoolean(orgTodas);
            laCompetencia.Status = "Por Iniciar";
            laCompetencia.FechaInicio = laFechaInicio;
            laCompetencia.FechaFin = laFechaFin;
            laCompetencia.Organizacion.Nombre = "Prueba Modificar";
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
            Assert.IsTrue(laBDCompetencia.ModificarCompetencia(laCompetencia));
        }
        [Test]
        [ExpectedException(typeof(ExcepcionesSKD.ExceptionSKD))]
        public void pruebaFalseModificarCompetencia()//Listo!!!
        {
            Int32 orgTodas = 0;
            DateTime laFechaInicio = new DateTime(2001, 10, 10);
            DateTime laFechaFin = new DateTime(2016, 10, 10);
            laCompetencia = new Competencia();
            laCompetencia.Organizacion = new Organizacion();
            laCompetencia.Ubicacion = new Ubicacion();
            laCompetencia.Categoria = new Categoria();
            laCompetencia.Id_competencia = 19;
            laCompetencia.Nombre = "Kobudo";
            laCompetencia.TipoCompetencia = "2";
            laCompetencia.OrganizacionTodas = Convert.ToBoolean(orgTodas);
            laCompetencia.Status = "Por Iniciar";
            laCompetencia.FechaInicio = laFechaInicio;
            laCompetencia.FechaFin = laFechaFin;
            laCompetencia.Organizacion.Nombre = "Org Modificar";
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
            laBDCompetencia.ModificarCompetencia(laCompetencia);
        }
        [Test]
        public void pruebaVacioListaOrganizaciones()//Listo!!!
        {
            laListaOrganizaciones = laBDCompetencia.M12ListarOrganizaciones();
            Assert.IsNotNull(laListaOrganizaciones);
        }
        [Test]
        public void pruebaContarListaOrganizaciones()//Listo!!!
        {
            laListaOrganizaciones = laBDCompetencia.M12ListarOrganizaciones();
            Assert.AreEqual(5, laListaOrganizaciones.ToArray().Length);
        }
        [Test]
        public void pruebaVacioListaCintas()//Listo!!!
        {
            laListaCintas = laBDCompetencia.M12ListarCintas();
            Assert.IsNotNull(laListaCintas);
        }
        [Test]
        public void pruebaContarListaCintas()//Listo!!!
        {
            laListaCintas = laBDCompetencia.M12ListarCintas();
            Assert.AreEqual(5, laListaCintas.ToArray().Length);
        }
        [Test]
        public void pruebaModificarFechas()//Listo!!!
        {
            laFecha = laBDCompetencia.ModificarFechas("9");
            Assert.AreEqual("09", laFecha);
        }
        [Test]
        public void pruebaModificarFechasMayor()//Listo!!!
        {
            laFecha = laBDCompetencia.ModificarFechas("11");
            Assert.AreEqual("11", laFecha);
        }
        [Test]
        public void pruebaTrueBuscarNombreCompetenciaAgregar()//Listo!!!
        {
            laCompetencia.Id_competencia = 1;
            laCompetencia.Nombre = "Ryu Kobudo";
            laCompetencia.TipoCompetencia = "2";
            laCompetencia.OrganizacionTodas = true;
            laCompetencia.Status = "Por Iniciar";
            Assert.IsTrue(laBDCompetencia.BuscarNombreCompetenciaAgregar(laCompetencia));
        }
        [Test]
        public void pruebaFalseBuscarNombreCompetenciaAgregar()//Listo!!!
        {
            laCompetencia.Id_competencia = 1;
            laCompetencia.Nombre = "Ryu K";
            laCompetencia.TipoCompetencia = "1";
            laCompetencia.OrganizacionTodas = true;
            laCompetencia.Status = "Por Iniciar";
            Assert.IsFalse(laBDCompetencia.BuscarNombreCompetenciaAgregar(laCompetencia));
            
        }
    }
}