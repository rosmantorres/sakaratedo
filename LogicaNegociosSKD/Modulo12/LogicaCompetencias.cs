using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo12;

namespace LogicaNegociosSKD.Modulo12
{
    public class LogicaCompetencias
    {
        #region Atributos

        private List<DominioSKD.Competencia> laListaDeCompetencias;
       

        #endregion

        #region Get y Set
        public List<DominioSKD.Competencia> LaListaDeCompetencias
        {
            get { return laListaDeCompetencias; }
            set { laListaDeCompetencias = value; }
        }
        #endregion

        #region Metodos Logica
        public LogicaCompetencias()
        {
        }

        public List<DominioSKD.Competencia> obtenerListaDeCompetencias()
        {
            try 
            {
                return BDCompetencia.ListarCompetencias();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        
        }

        public List<DominioSKD.Organizacion> M12obtenerListaDeOrganizaciones()
        {
            try
            {
                return BDCompetencia.M12ListarOrganizaciones();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        }

        public List<DominioSKD.Cinta> M12obtenerListaDeCintas()
        {
            try
            {
                return BDCompetencia.M12ListarCintas();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        }

        public DominioSKD.Competencia detalleCompetenciaXId(int elIdCompetencia)
        {
            try
            {
                return BDCompetencia.DetallarCompetencia(elIdCompetencia);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        }

        public bool agregarCompetencia(DominioSKD.Competencia laCompetencia)
        {
            try
            {
                return BDCompetencia.AgregarCompetencia(laCompetencia);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaExistenteException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        }
        #endregion
 
    }
}
