using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo16
{
   public class ListaCompra : Entidad
   {
       #region Atributos
       private List<Compra> listaCompra;
       #endregion 

       #region Propiedades

       /// <summary>
       /// Propiedad del atributo listaInventario
       /// </summary>
       public List<Compra> ListaCompras
       {
           get
           {
               return this.listaCompra;
           }
           set
           {
               this.listaCompra = value;
           }
       }

       #endregion

       #region Constructores

       public ListaCompra()
       {

       }
       #endregion
   }
}
