using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo7;

namespace LogicaNegociosSKD.Modulo7
{
    /// <summary>
    /// Clase para obtener la lista de matriculas pagadas y la descripción de matricula
    /// </summary>
    public class LogicaMatriculasPagas
    {
        #region Atributos
        private List<DominioSKD.Matricula> laListaDeMatriculas;
        #endregion

        #region Get y Set
        public List<DominioSKD.Matricula> LaListaDeEventos
        {
            get { return laListaDeMatriculas; }
            set { laListaDeMatriculas = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor
        /// </summary>
        public LogicaMatriculasPagas()
        {
        }

        /// <summary>
        /// Método que obtiene la lista de matriculas que han sido pagadas
        /// </summary>
        /// <returns>Lista de objetos tipo Matricula</returns>
        public List<DominioSKD.Matricula> obtenerListaDeMatriculas(int idPersona)
        {
            try
            {
                BDMatricula baseDeDatosMatricula = new BDMatricula();
                return baseDeDatosMatricula.ListarMatriculasPagas(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public float obtenerMontoMatricula(int idPersona, int idMatricula)
        {
            try
            {
                BDMatricula baseDeDatosDetalleCompra = new BDMatricula();
                return baseDeDatosDetalleCompra.montoPagoMatricula(idPersona, idMatricula);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Método que obtiene el detalle de cada matricula por su ID
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID de la matricula</param>
        /// <returns>un objeto de tipo Matricula</returns>
      
        public DominioSKD.Matricula detalleMatriculaID(int idMatricula)
        {
            try
            {
                BDMatricula baseDeDatosMatricula = new BDMatricula();
                return baseDeDatosMatricula.DetallarMatricula(idMatricula);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

    }
}