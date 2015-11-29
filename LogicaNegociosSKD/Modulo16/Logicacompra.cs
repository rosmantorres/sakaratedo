using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo16;


namespace LogicaNegociosSKD.Modulo16
{
    /// <summary>
    /// Clase que gestiona toda la logica de las compras hechas por el usuario
    /// </summary>
    public class Logicacompra
    {
        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Logicacompra
        /// </summary>
        public Logicacompra()
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que obtiene la o las ultimas matriculas pagadas por una persona
        /// </summary>
        /// /// <param name="idUsuario">El id del usuario el cual se desea saber las matriculas que pago</param>
        /// <returns>Una lista con los id de las matriculas</returns>
        public List<Matricula> MatriculasPagadas(int idUsuario) 
        {
            //Preparo la lista a devolver
            List<Matricula> listaMatriculas = new List<Matricula>();

            //Obtenemos de la base de Datos la lista
            BDCompra bdCompra = new BDCompra();
            listaMatriculas = bdCompra.MatriculasPagadas(idUsuario);

            //Retornamos la respuesta
            return listaMatriculas;
          
        }
        #endregion


    }
}
