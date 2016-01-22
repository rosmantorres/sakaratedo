using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo15;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo15;
using LogicaNegociosSKD.Fabrica;
namespace Interfaz_Presentadores.Modulo15
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
             comando = FabricaComandos.ObtenerComandoConsultar();
             comando.LaEntidad = dojo;
             return comando.Ejecutar();
        
         }

         public List<Entidad> cargarListaImplementos2(Entidad dojo)
         {
             Comando<List<Entidad>> comando;
             comando = FabricaComandos.ObtenerComandoConsultar2();
             comando.LaEntidad = dojo;
             return comando.Ejecutar();

         }

         public bool eliminarImplemento(string implemento ,int dojoid)
         {                        
             Comando<bool> comando;
             Entidad implementoEliminar = FabricaEntidades.ObtenerImplemento();
             Entidad dojoEliminar = FabricaEntidades.tenerDojo();
             comando = FabricaComandos.ObtenerComandoEliminarImplemento();
             ((Implemento)implementoEliminar).Id_Implemento = Convert.ToInt32(implemento);
             ((Dojo)dojoEliminar).Dojo_Id=dojoid;
             comando.LaEntidad = implementoEliminar;
             ((ComandoEliminarImplemento)comando).Dojo = dojoEliminar;
             return comando.Ejecutar();

         }

      

         public int usuarioDojo(Entidad usuario) {

             Comando<int> comando = FabricaComandos.ObtenerComandoUsuarioDojo();
             comando.LaEntidad = usuario;
             return comando.Ejecutar();
         
         }
         public Entidad obtenerDojoXId(Entidad dojo)
         {

             Comando<Entidad> comando = FabricaComandos.ObtenerComandoDojo();
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
