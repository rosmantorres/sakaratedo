using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Modulo7
{
    /// <summary>
    /// Clase para obtener informacion acerca del atleta
    /// </summary>
    public class LogicaOrganizacionYDojo
    {
        #region Atributos
        private List<DominioSKD.Organizacion> laListaDeOrganizacion;
        private List<DominioSKD.Dojo> laListaDeDojo;
        private List<DominioSKD.Persona> laListaDePersona;
        #endregion

        #region Gets y Sets
        public List<DominioSKD.Organizacion> LaListaDeOrganizacion
        {
            get { return laListaDeOrganizacion; }
            set { laListaDeOrganizacion = value; }
        }

        public List<DominioSKD.Dojo> LaListaDeDojo
        {
            get { return laListaDeDojo; }
            set { laListaDeDojo = value; }
        }

        public List<DominioSKD.Persona> LaListaDePersona
        {
            get { return laListaDePersona; }
            set { laListaDePersona = value; }
        }
        #endregion

        #region Metodos
        public LogicaOrganizacionYDojo()
        {

        }

        public List<DominioSKD.Competencia> obtenerDetalleOrganizacion()
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
        #endregion

    }
}
