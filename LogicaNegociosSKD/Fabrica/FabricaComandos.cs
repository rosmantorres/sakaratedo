using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8

        public static Comando<Boolean> CrearComandoAgregarRestriccionCompetencia()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCompetencia();
        }
        public static Comando<Boolean> CrearComandoAgregarListaCompetenciaRestriccionCompetencia()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarListaCompetenciaRestriccionCompetencia();
        }
        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarCompetencias()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCompetencias();
        }
        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarTodasLasCompetenciasAsociadas()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarTodasLasCompetenciasAsociadas();
        }
        public static Comando<List<DominioSKD.Entidad>> CrearComandoConsultarTodasLasCompetenciasNoAsociadas()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarTodasLasCompetenciasNoAsociadas();
        }
        public static Comando<Boolean> CrearComandoEliminarListaCompetenciaRestriccionCompetencia()
        {
            return new LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarListaCompetenciaRestriccionCompetencia();
        }
        #endregion

        #region Modulo 9
        #endregion

        #region Modulo 10
        #endregion

        #region Modulo 11
        #endregion

        #region Modulo 12
        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        #endregion

        #region Modulo 15
        #endregion

        #region Modulo 16
        #endregion


    }
}
