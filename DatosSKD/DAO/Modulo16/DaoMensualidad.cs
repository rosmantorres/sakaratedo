﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DatosSKD.DAO;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo6;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;

namespace DatosSKD.DAO.Modulo16
{
    public class DaoMensualidad : DAOGeneral, IdaoMensualidad
    {
        #region Metodos
        /// <summary>
        /// Metodo que retorma una lista de Matriculas Morosas Existentes
        /// </summary>
        /// <param name=Entidad>Se pasa el id del usuario logueado</param>
        /// <returns>Todas las mensualidades morosas asociadas al id de la persona logueada</returns>
        public Entidad ConsultarXId(Entidad entidad)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Matricula> laLista = new List<Matricula>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Matricula laMatricula;
            ListaMatricula lista = new ListaMatricula();

            PersonaM1 p = (PersonaM1)entidad;

            try
            {
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, p._Id.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_MATRICULAS_MOROSAS,
                    parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    laMatricula = (Matricula)laFabrica.ObtenerMatricula();
                    laMatricula.Id = int.Parse(row[RecursosBDModulo16.PARAMETRO_ID_MATRICULA].ToString());
                    laMatricula.Identificador = row[RecursosBDModulo16.PARAMETRO_IDENTIFICADOR_MAT].ToString();
                    laMatricula.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO_MATRICULA].ToString());
                    laMatricula.UltimaFechaPago= DateTime.Parse(row[RecursosBDModulo16.PARAMETRO_FECHA_PAGO_MATRICULA].ToString());
                    laMatricula.Mes = int.Parse(row[RecursosBDModulo16.PARAMETRO_MES_DEUDOR_MATRICULA].ToString());
                    laMatricula.Anio = int.Parse(row[RecursosBDModulo16.PARAMETRO_ANIO_DEUDOR_MATRICULA].ToString());
                    laLista.Add(laMatricula);

                }


                return lista;

            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion


        }

        /// <summary>
        /// Metodo que devueve todas las mensualidades
        /// </summary>
        /// <param name="NONE">Este procedimiento no posee paso de paramentros</param>
        /// <returns>Retorna todas las mensualidades sin filtro</returns>
        public List<Entidad> ListarMensualidad()
        {
            return new List<Entidad>();
        }

        /// <summary>
        /// Metodo que devueve todas las mensualidades
        /// </summary>
        /// <param name="NONE">Este procedimiento no posee paso de paramentros</param>
        /// <returns>Retorna todas las mensualidades</returns>
        public List<Entidad> ConsultarTodos()
        {
            return new List<Entidad>();
        }
        /// <summary>
        /// Metodo que devueve un tipomensualidad dado su id
        /// </summary>
        /// <param name="Id_mensualidad">Indica el objeto a detallar</param>
        /// <returns>Retorna la mensualidad en especifico con todos sus detalles</returns>
        public Entidad DetallarMensualidad(int Id_mensualidad)
        {
            return new Persona();
        }

        #endregion
    }
}
