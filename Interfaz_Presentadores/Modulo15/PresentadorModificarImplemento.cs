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
              FabricaComandos fabrica = new FabricaComandos();
              FabricaEntidades fabrica2 = new FabricaEntidades();
            Comando<Entidad> comando = fabrica.ObtenerComandoImplementoXId();
            Entidad implemento = fabrica2.ObtenerImplemento();
            ((Implemento)implemento).Id_Implemento = idImplemento;
            comando.LaEntidad = implemento;
            return comando.Ejecutar();

          }
          public bool modificarImplemento(Entidad implemento)
          {
              FabricaComandos fabrica = new FabricaComandos();

              Comando<bool> comandoModificar = fabrica.ObtenerComandoModificarImplemento();
              comandoModificar.LaEntidad = implemento;
              return comandoModificar.Ejecutar();

          }
    }
}
