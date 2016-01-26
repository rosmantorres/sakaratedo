using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DatosSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo12;
using DominioSKD.Fabrica;

namespace PruebasUnitariasSKD.Modulo12
{
    [TestFixture]
    public class PruebasDAOCompetencias
    {
        IDaoCompetencia daoCompetencia;
        List<Entidad> laListaCompetencias;
        Entidad laCompe;
        Entidad laComp;
        Entidad laCompetencia;

        [SetUp]
        public void Init()
        {
            daoCompetencia = (IDaoCompetencia)FabricaDAOSqlServer.ObtenerDAOCompetencia();
            laCompe = (Entidad)FabricaEntidades.ObtenerCompetencia();
            laCompetencia = (Entidad)FabricaEntidades.ObtenerCompetencia();
            laComp = (Entidad)FabricaEntidades.ObtenerCompetencia();
            laListaCompetencias = new List<Entidad>();
        }
        [Test]
        public void pruebaVacioListaCompetencias()//Listo!!!
        {
            laListaCompetencias = daoCompetencia.ConsultarTodos();
            Assert.IsNotNull(laListaCompetencias);
        }
        [Test]
        public void pruebaContarListaCompetencias()//Listo!!!
        {
            laListaCompetencias = daoCompetencia.ConsultarTodos();
            Assert.AreEqual(12, laListaCompetencias.ToArray().Length);
        }
        [Test]
        public void pruebaIdDetallarCompetencia()//Listo!!!
        {
            laComp.Id = 3;
            laCompe = daoCompetencia.ConsultarXId(laComp);
            Assert.AreEqual(3, laCompe.Id);
        }
        [Test]
        public void pruebaAgregarCompetencia()//Listo!!!
        {
            Int32 orgTodas = 0;

            DominioSKD.Entidades.Modulo12.Competencia laCom = (DominioSKD.Entidades.Modulo12.Competencia)FabricaEntidades.ObtenerCompetencia();
            DateTime laFechaInicio = new DateTime(2015, 10, 10);
            DateTime laFechaFin = new DateTime(2016, 10, 10);
            laCom.Id = 13;
            //bool daoCompetencia_Agregar_laComp = true;
            laCom.Organizacion = new Organizacion();
            laCom.Organizacion.Id_organizacion = 78;
            laCom.Organizacion.Nombre = "Prueba Unit";
            laCom.Ubicacion = (DominioSKD.Entidades.Modulo12.Ubicacion)FabricaEntidades.ObtenerUbicacion();
            laCom.Categoria = (DominioSKD.Entidades.Modulo12.Categoria)FabricaEntidades.ObtenerCategoria();
            laCom.Nombre = "Prueba Agregar";
            laCom.TipoCompetencia = "2";
            laCom.OrganizacionTodas = Convert.ToBoolean(orgTodas);
            laCom.Status = "Por Iniciar";
            laCom.FechaInicio = laFechaInicio;
            laCom.FechaFin = laFechaFin;
            laCom.Ubicacion.Ciudad = "Valencia";
            laCom.Ubicacion.Estado = "Carabobo";
            laCom.Ubicacion.Direccion = "Prueba";
            laCom.Ubicacion.Latitud = "10.1727434";
            laCom.Ubicacion.Longitud = "-68.0642649";
            laCom.Categoria.Edad_inicial = 10;
            laCom.Categoria.Edad_final = 15;
            laCom.Categoria.Cinta_inicial = "Naranja";
            laCom.Categoria.Cinta_final = "Verde";
            laCom.Categoria.Sexo = "M";
            laCom.Costo = 1950;
            Assert.IsTrue(daoCompetencia.Agregar(laComp));
        }
        [Test]
        public void pruebaModificarCompetencia()//Listo!!!
        {
            Int32 orgTodas = 0;

            DominioSKD.Entidades.Modulo12.Competencia laCom = (DominioSKD.Entidades.Modulo12.Competencia)FabricaEntidades.ObtenerCompetencia();
            DateTime laFechaInicio = new DateTime(2015, 10, 10);
            DateTime laFechaFin = new DateTime(2016, 10, 10);
            laCom.Id = 13;
            bool daoCompetencia_Modificar = true;
            laCom.Organizacion = new Organizacion();
            laCom.Organizacion = (Organizacion)FabricaEntidades.ObtenerOrganizacion();
            laCom.Organizacion.Id_organizacion = 78;
            laCom.Organizacion.Nombre = "Prueba Unit";
            laCom.Ubicacion = (DominioSKD.Entidades.Modulo12.Ubicacion)FabricaEntidades.ObtenerUbicacion();
            laCom.Categoria = (DominioSKD.Entidades.Modulo12.Categoria)FabricaEntidades.ObtenerCategoria();
            laCom.Nombre = "Prueba Modificar";
            laCom.TipoCompetencia = "2";
            laCom.OrganizacionTodas = Convert.ToBoolean(orgTodas);
            laCom.Status = "Por Iniciar";
            laCom.FechaInicio = laFechaInicio;
            laCom.FechaFin = laFechaFin;
            laCom.Ubicacion.Ciudad = "Valencia";
            laCom.Ubicacion.Estado = "Carabobo";
            laCom.Ubicacion.Direccion = "Prueba";
            laCom.Ubicacion.Latitud = "10.1727434";
            laCom.Ubicacion.Longitud = "-68.0642649";
            laCom.Categoria.Edad_inicial = 10;
            laCom.Categoria.Edad_final = 15;
            laCom.Categoria.Cinta_inicial = "Naranja";
            laCom.Categoria.Cinta_final = "Verde";
            laCom.Categoria.Sexo = "M";
            laCom.Costo = 1950;
            Assert.IsTrue(daoCompetencia.Modificar(laComp));
        }
    }
}