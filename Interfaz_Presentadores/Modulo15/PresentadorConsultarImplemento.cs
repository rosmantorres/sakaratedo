using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using Interfaz_Contratos.Modulo15;
using LogicaNegociosSKD;

using LogicaNegociosSKD.Fabrica;namespace Interfaz_Presentadores.Modulo15
{
    public  class PresentadorConsultarImplemento
    {
         private IContratoConsultarImplemento _vista;

         public PresentadorConsultarImplemento(IContratoConsultarImplemento _vista)
        {
            this._vista = _vista;
        }

         public List<Entidad> cargarListaImplementos()
         {  
             FabricaComandos fabrica =new FabricaComandos();
             Comando<List<Entidad>> comando;
             comando = fabrica.ObtenerComandoConsultar();
             return comando.Ejecutar();
        
         }

   //      public Entidad obtnerDojo(string usuario)
     //    {
         //    FabricaComandos fabrica = new FabricaComandos();
       //      Comando<Entidad> comando;
          //   comando = fabrica.obt
            // return comando.Ejecutar();

//         }
      
      
         



    }
}
