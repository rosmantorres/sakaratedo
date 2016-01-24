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
          private IContratoModificarImplemento _vista;

          public PresentadorModificarImplemento(IContratoModificarImplemento _vista)
        {
            this._vista = _vista;
        }


          public Entidad precargarImplemento(int idImplemento) {

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
                  ex = new ExcepcionPresentadorModificarImplemento("Error en Presentador Modificar Implemento", new Exception());
                  Logger.EscribirError("Error en Presentador Modificar Implemento", ex);
                  throw ex;

              }

              catch (ExceptionSKD ex)
              {
                  ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                  Logger.EscribirError("Error en Presentador Modificar Implemento", ex);
                  throw ex;
              }

              catch (Exception ex)
              {

                  Logger.EscribirError("Error en Presentador Modificar Implemento", ex);
                  throw ex;
              }
          }
          public bool modificarImplemento(Entidad implemento)
          {
              try
              {
                  Comando<bool> comandoModificar = FabricaComandos.ObtenerComandoModificarImplemento();
                  comandoModificar.LaEntidad = implemento;
                  return comandoModificar.Ejecutar();
              }
              catch (ExcepcionPresentadorModificarImplemento ex)
              {
                  ex = new ExcepcionPresentadorModificarImplemento("Error en Presentador Modificar Implemento", new Exception());
                  Logger.EscribirError("Error en Presentador Modificar Implemento", ex);
                  throw ex;

              }

              catch (ExceptionSKD ex)
              {
                  ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                  Logger.EscribirError("Error en Presentador Modificar Implemento", ex);
                  throw ex;
              }

              catch (Exception ex)
              {

                  Logger.EscribirError("Error en Presentador Modificar Implemento", ex);
                  throw ex;
              }
          }
    }
}
