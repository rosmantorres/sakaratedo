using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DominioSKD.Entidades.Modulo16
{
    public class ListaEvento : Entidad
    {
       #region Atributos
       private List<Evento> listaEvento;
       #endregion 

       #region Propiedades

       /// <summary>
       /// Propiedad del atributo ListaEventos
       /// </summary>
       public List<Evento> ListaEventos
       {
           get
           {
               return this.listaEvento;
           }
           set
           {
               this.listaEvento = value;
           }
       }

       #endregion

       #region Constructores

       public ListaEvento()
       {

       }
       #endregion
    }
}
