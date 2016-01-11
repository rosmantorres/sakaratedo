﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando para consultar la lista de todos los eventos
    /// </summary>
    public class ComandoConsultarTodosEventos : Comando<List<Entidad>>
    {
        #region Atributos
        /// <summary>
        /// Atributos del ComandoConsultarTodosEventos
        /// </summary>
        /// <param name="NONE">No posee paso de parametros</param>
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad 
        /// </summary>
        /// <Prop name="NONE">No posee propiedades</param>
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del ComandoConsultarTodosEventos
        /// </summary>
        public ComandoConsultarTodosEventos()
        {

        }

        #endregion

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="NONE">Este metodo no posee paso de parametros</param>
        /// <returns>lista de Eventos</returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IdaoEvento daoEventos = FabricaDAOSqlServer.ObtenerDaoEventos();
                return daoEventos.ConsultarTodos();
            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }
    }
}
