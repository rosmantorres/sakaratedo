using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo16;
<<<<<<< HEAD
=======

>>>>>>> 3399a1ca4d519365f6ebc42dbbaa050ea2322f18

namespace LogicaNegociosSKD.Modulo16
{
    /// <summary>
    /// Clase que gestiona toda la logica de las compras hechas por el usuario
    /// </summary>
    public class Logicacompra
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Logicainventario
        /// </summary>
        private BDCompra compraBD;
        private int idPersona;
        private List<DominioSKD.Compra> laListaDeCompra;

        #endregion


        #region Constructores
        /// <summary>
        /// Constructor que devuelve una lista de tipo compra
        /// </summary>
        public Logicacompra()
        {
            laListaDeCompra = obtenerListaDeCompra(idPersona);
        }
        #endregion


        #region Metodos
<<<<<<< HEAD

        /// <summary>
        /// Metodo que obtiene todas las facturas del usuario conectado
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Retorna una lista de facturas</returns>
        public List<DominioSKD.Compra> obtenerListaDeCompra(int idPersona)
        {
            try
            {
                return BDCompra.ListarCompra(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }

=======
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
          
>>>>>>> 3399a1ca4d519365f6ebc42dbbaa050ea2322f18
        }
     
        #endregion


    }
}
