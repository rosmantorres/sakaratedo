using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo15;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;

namespace PruebasUnitariasSKD.Modulo15
{
    [TestFixture]

    class PruebaLogica
    {
        private Implemento implemento;
        private Dojo dojo;
        private LogicaImplemento logica;

    [SetUp]
    public void Init()
        {
            implemento = new Implemento();
            logica = new LogicaImplemento();
            dojo = new Dojo(1);
            
        }
    [TearDown]
    public void Reset()
    {
        implemento = null;
        dojo = null;
    }

    #region M15_PruebaAgregarInventarioLogica
    [Test]
    [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
    public void M15_PruebaAgregarInventarioLogica()
    {
        logica.agregarInventarioLogica(null);
    }
    #endregion

    #region M15_PruebaListarInventarioLogica
    [Test]
    [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
    public void M15_PruebaListarInventarioLogica()
    {
        logica.listarInventarioLogica(null);
    }
    #endregion

    #region M15_PruebaListarInventarioLogica2
    [Test]
    [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
    public void M15_PruebaListarInventarioLogica2()
    {
        logica.listarInventarioLogica2(null);
    }
    #endregion

    #region M15_PruebaUsuarioImplementoLogica
    [Test]
    [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
    public void M15_PruebaUsuarioImplementoLogica()
    {
        logica.usuarioImplementoLogica(null);
    }
    #endregion

    #region M15_PruebamodificarInventarioLogica
    [Test]
    [ExpectedException(typeof(ErrorEnParametroDeProcedure))]
    public void M15_PruebamodificarInventarioLogica()
    {
        logica.modificarInventarioLogica(null);
    }
    #endregion


    }

}
