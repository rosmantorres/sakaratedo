using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo15;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using ExcepcionesSKD.Modulo15.ExcepcionPresentador;
using ExcepcionesSKD;

namespace Interfaz_Presentadores.Modulo15
{
   public class PresentadorModificarImplemento
    {
        /// <summary>
        /// Método de presentador para modificar un implemento
        /// </summary>
          private IContratoModificarImplemento _vista;

          public PresentadorModificarImplemento(IContratoModificarImplemento _vista)
        {
            this._vista = _vista;
        }


          public Entidad precargarImplemento(int idImplemento) {

              /// <summary>
              /// Método de presentador para precargar la informacion de un implemento
              /// </summary>
              try
              {

                  Comando<Entidad> comando = FabricaComandos.ObtenerComandoImplementoXId();
                  Entidad implemento = FabricaEntidades.ObtenerImplemento();
                  ((Implemento)implemento).Id_Implemento = idImplemento;
                  comando.LaEntidad = implemento;
                  return comando.Ejecutar();
              }
              catch (ExcepcionPresentadorModificarImplemento ex)
              {
                  ex = new ExcepcionPresentadorModificarImplemento(M15_RecursoInterfazPresentador.ErrorPModificar, new Exception());
                  Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPModificar, ex);
                  throw ex;

              }

              catch (ExceptionSKD ex)
              {
                  ex = new ExcepcionesSKD.ExceptionSKD(M15_RecursoInterfazPresentador.ErrorPOperacion, new Exception());
                  Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPModificar, ex);
                  throw ex;
              }

              catch (Exception ex)
              {

                  Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPModificar, ex);
                  throw ex;
              }
          }
          public bool modificarImplemento(Entidad implemento)
          {
              /// <summary>
              /// Método de presentador para modificar la informacion de un implemento
              /// </summary>
              try
              {
                  Comando<bool> comandoModificar = FabricaComandos.ObtenerComandoModificarImplemento();
                  comandoModificar.LaEntidad = implemento;
                  return comandoModificar.Ejecutar();
              }
              catch (ExcepcionPresentadorModificarImplemento ex)
              {
                  ex = new ExcepcionPresentadorModificarImplemento(M15_RecursoInterfazPresentador.ErrorPModificar, new Exception());
                  Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPModificar, ex);
                  throw ex;

              }

              catch (ExceptionSKD ex)
              {
                  ex = new ExcepcionesSKD.ExceptionSKD(M15_RecursoInterfazPresentador.ErrorPOperacion, new Exception());
                  Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPModificar, ex);
                  throw ex;
              }
              
              catch (Exception ex)
              {

                  Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPModificar, ex);
                  throw ex;
              }
          }
    }
}
