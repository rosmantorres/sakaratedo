using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo6;

namespace DominioSKD.Entidades.Modulo16
{
    public class ListaMatricula : Entidad
    {
       #region Atributos
        private List<Matricula> listaMatricula;
       #endregion 

       #region Propiedades

       /// <summary>
       /// Propiedad del atributo listaMatricula
       /// </summary>
       public List<Matricula> ListaMatriculas
       {
           get
           {
               return this.listaMatricula;
           }
           set
           {
               this.listaMatricula = value;
           }
       }

       #endregion

       #region Constructores

       public ListaMatricula()
       {

       }
       #endregion
    }
}
