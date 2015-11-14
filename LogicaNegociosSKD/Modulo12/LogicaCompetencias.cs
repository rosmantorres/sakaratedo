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

        public LogicaCompetencias()
        {
            laListaDeCompetencias = obtenerListaDeCompetencias();
        }

        public List<DominioSKD.Competencia> obtenerListaDeCompetencias()
        {
            try 
            {
                return BDCompetencia.ListarCompetencias();
            }
            catch (Exception e)
            {
                throw e;
            }
        
        }

    }
}
