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
              Comando<Entidad> comando = FabricaComandos.ObtenerComandoImplementoXId();
            Entidad implemento = FabricaEntidades.ObtenerImplemento();
            ((Implemento)implemento).Id_Implemento = idImplemento;
            comando.LaEntidad = implemento;
            return comando.Ejecutar();

          }
          public bool modificarImplemento(Entidad implemento)
          {

              Comando<bool> comandoModificar = FabricaComandos.ObtenerComandoModificarImplemento();
              comandoModificar.LaEntidad = implemento;
              return comandoModificar.Ejecutar();

          }
    }
}
