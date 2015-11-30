﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo7;

namespace LogicaNegociosSKD.Modulo7
{
    /// <summary>
    /// Clase para obtener la lista de cintas obtenidas y la descripción de una cinta
    /// </summary>
    public class LogicaCintas
    {
        #region Atributos
        private List<DominioSKD.Cinta> laListaDeCintas;
        #endregion

        #region Get y Set
        public List<DominioSKD.Cinta> LaListaDeCintas
        {
            get { return laListaDeCintas; }
            set { laListaDeCintas = value; }
        }
        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public LogicaCintas()
        {
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método que obtiene la lista de cintas de un atleta
        /// </summary>
        /// <returns>Lista de objetos tipo cinta</returns>
        public List<DominioSKD.Cinta> obtenerListaDeCintas(int idPersona)
        {
            try
            {
                BDCinta baseDeDatosCinta = new BDCinta();
                return baseDeDatosCinta.ListarCintasObtenidas(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que obtiene el detalle de cada cinta por su ID
        /// </summary>
        /// <param name="idCinta">Número entero que representa el id de la cinta</param>
        /// <returns>Objeto de tipo Cinta</returns>
        public DominioSKD.Cinta detalleCintaID(int idCinta)
        {
            try
            {
                BDCinta baseDeDatosCinta = new BDCinta();
                return baseDeDatosCinta.DetallarCinta(idCinta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Método que obtiene la fecha de recibimiento de una cinta para una persona
        /// </summary>
        /// <param name="idPersona">Número entero que representa el ID de la persona</param>
        /// <param name="idEvento">Número entero que representa el ID de la cinta</param>
        /// <returns>DateTime con la fecha de inscripción</returns>
        public DateTime obtenerFechaCinta(int idPersona, int idCinta)
        {
            try
            {
                BDCinta baseDeDatosCinta = new BDCinta();
                return baseDeDatosCinta.fechaCinta(idPersona, idCinta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <param name="idCinta"></param>
        /// <returns></returns>
        public DominioSKD.Cinta obtenerUltimaCinta(int idPersona)
        {
            try
            {
                BDCinta baseDeDatosCinta = new BDCinta();
                return baseDeDatosCinta.UltimaCinta(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        #endregion


    }
}
