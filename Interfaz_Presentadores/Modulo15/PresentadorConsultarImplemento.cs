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

         public List<Entidad> cargarListaImplementos(Entidad dojo)
         {  
             Comando<List<Entidad>> comando;
             FabricaComandos fabrica= new FabricaComandos();
             comando = fabrica.ObtenerComandoConsultar();
             comando.LaEntidad = dojo;
             return comando.Ejecutar();
        
         }

         public List<Entidad> cargarListaImplementos2(Entidad dojo)
         {
             Comando<List<Entidad>> comando;
             FabricaComandos fabrica = new FabricaComandos();
             comando = fabrica.ObtenerComandoConsultar2();
             comando.LaEntidad = dojo;
             return comando.Ejecutar();

         }

         public int usuarioDojo(Entidad usuario) {
             FabricaComandos fabrica = new FabricaComandos();

             Comando<int> comando = fabrica.ObtenerComandoUsuarioDojo();
             comando.LaEntidad = usuario;
             return comando.Ejecutar();
         
         }
         public Entidad obtenerDojoXId(Entidad dojo)
         {
             FabricaComandos fabrica = new FabricaComandos();

             Comando<Entidad> comando = fabrica.ObtenerComandoDojo();
             comando.LaEntidad=dojo;
             return comando.Ejecutar();

         }


   //     public Entidad obtnerDojo(string usuario)
     //    {
         //    FabricaComandos fabrica = new FabricaComandos();
       //      Comando<Entidad> comando;
          //   comando = fabrica.obt
            // return comando.Ejecutar();

//         }
      
      
         



    }
}
