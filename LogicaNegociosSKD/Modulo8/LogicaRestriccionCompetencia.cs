using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Modulo8
{
    class LogicaRestriccionCompetencia
    {
//#region Atributos

        private List<DominioSKD.Competencia> laListaDeCompetencias;
        

        //#endregion

        //#region Get y Set
        //public List<DominioSKD.Competencia> LaListaDeCompetencias
        //{
        //    get { return laListaDeCompetencias; }
        //    set { laListaDeCompetencias = value; }
        //}
        //#endregion

        //#region Metodos Logica
        //public LogicaRestriccionCompetencia()
        //{
        //}

        //public List<DominioSKD.Competencia> obtenerListaDeCompetencias()
        //{
        //    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    try 
        //    {

        //        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //        return BDCompetencia.ListarCompetencias();
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        
        //}

        //public List<DominioSKD.Organizacion> M12obtenerListaDeOrganizaciones()
        //{
        //    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //    try
        //    {
        //        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //        return BDCompetencia.M12ListarOrganizaciones();
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //}

        //public List<DominioSKD.Cinta> M12obtenerListaDeCintas()
        //{
        //    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    try
        //    {
        //        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //        return BDCompetencia.M12ListarCintas();
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //}

        //public DominioSKD.Competencia detalleCompetenciaXId(int elIdCompetencia)
        //{
        //    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //    try
        //    {
        //        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //        return BDCompetencia.DetallarCompetencia(elIdCompetencia);
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //}

        //public bool agregarCompetencia(DominioSKD.Competencia laCompetencia)
        //{
        //    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    try
        //    {

        //        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosLogicaModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        //        return BDCompetencia.AgregarCompetencia(laCompetencia);
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.Modulo12.CompetenciaExistenteException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKD ex)
        //    {
        //        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
        //        throw ex;
        //    }
        //}
        //#endregion
    }
}
