using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using Interfaz_Contratos.Modulo15;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;

namespace Interfaz_Presentadores.Modulo15
{
    public class PresentadorAgregarImplemento
    {
          private IContratoAgregarImplemento _vista;

          public PresentadorAgregarImplemento(IContratoAgregarImplemento _vista)
        {
            this._vista = _vista;
        }

          public bool agregarImplemento(Entidad implemento) {

              
              FabricaComandos fabrica = new FabricaComandos();
              Comando<bool> comandoAgregar=fabrica.ObtenerComandoAgregar();
              comandoAgregar.LaEntidad = implemento;
              return comandoAgregar.Ejecutar();
          
          }


    }
}
