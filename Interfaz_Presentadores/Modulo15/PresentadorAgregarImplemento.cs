using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using Interfaz_Contratos.Modulo15;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using ExcepcionesSKD.Modulo15.ExcepcionPresentador;
using ExcepcionesSKD;

namespace Interfaz_Presentadores.Modulo15
{
    public class PresentadorAgregarImplemento
    {
       
          private IContratoAgregarImplemento _vista;

          public PresentadorAgregarImplemento(IContratoAgregarImplemento _vista)
        {
            this._vista = _vista;
        }
          /// <summary>
          /// Método de presentador que agrega implemento
          /// </summary>
          public bool agregarImplemento(Entidad implemento) {
              try
              {

                  Comando<bool> comandoAgregar = FabricaComandos.ObtenerComandoAgregar();
                  comandoAgregar.LaEntidad = implemento;
                  return comandoAgregar.Ejecutar();
              }
              catch (ExcepcionPresentadorAgregarImplemento ex)
              {
                  ex = new ExcepcionPresentadorAgregarImplemento("Error en Presentador Agregar Implemento", new Exception());
                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;

              }

              catch (ExceptionSKD ex)
              {
                  ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;
              }

              catch (Exception ex)
              {

                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;
              }

          
          }
          public int usuarioDojo(Entidad usuario)
          {
              /// <summary>
              /// Método de presentador que con el usuario te devuelve el dojo
              /// </summary>
              try
              {
                  Comando<int> comando = FabricaComandos.ObtenerComandoUsuarioDojo();
                  comando.LaEntidad = usuario;
                  return comando.Ejecutar();
              }
              catch (ExcepcionPresentadorAgregarImplemento ex)
              {
                  ex = new ExcepcionPresentadorAgregarImplemento("Error en Presentador Agregar Implemento", new Exception());
                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;

              }

              catch (ExceptionSKD ex)
              {
                  ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;
              }

              catch (Exception ex)
              {

                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;
              }

          }
          public Entidad obtenerDojoXId(Entidad dojo)
          {

              /// <summary>
              /// Método de presentador para obtener el dojo por Id
              /// </summary>
              try
              {

                  Comando<Entidad> comando = FabricaComandos.ObtenerComandoDojo();
                  comando.LaEntidad = dojo;
                  return comando.Ejecutar();
              }
              catch (ExcepcionPresentadorAgregarImplemento ex)
              {
                  ex = new ExcepcionPresentadorAgregarImplemento("Error en Presentador Agregar Implemento", new Exception());
                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;

              }

              catch (ExceptionSKD ex)
              {
                  ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;
              }

              catch (Exception ex)
              {

                  Logger.EscribirError("Error en Presentador Agregar Implemento", ex);
                  throw ex;
              }


          }



    }
}
