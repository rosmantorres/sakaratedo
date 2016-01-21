using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo15;

namespace DominioSKD.Entidades.Modulo16
{
   public class ListaImplemento : Entidad
    {
       #region Atributos
       private List<Implemento> listaImplemento;
       #endregion 

       #region Propiedades

       /// <summary>
       /// Propiedad del atributo ListaImplementos
       /// </summary>
       public List<Implemento> ListaImplementos
       {
           get
           {
               return this.listaImplemento;
           }
           set
           {
               this.listaImplemento = value;
           }
       }

       #endregion

       #region Constructores

       public ListaImplemento()
       {

       }
       #endregion
   
    }
}
