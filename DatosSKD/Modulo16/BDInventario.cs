﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;

namespace DatosSKD.Modulo16
{
    public class BDInventario
    {

        #region Metodos
        /// <summary>
        /// Metodo que retorma una lista de implementos del inventario
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario</returns>
        public static List<Implemento> ListarInventario()
        {
            BDConexion laConexion;
            List<Implemento> laListaDeInventario = new List<Implemento>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.CONSULTAR_IMPLEMENTOS, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Implemento elInventario = new Implemento();

                    elInventario.Id_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString());
                    elInventario.Imagen_implemento = row[RecursosBDModulo16.PARAMETRO_IMAGEN].ToString();
                    elInventario.Nombre_Implemento = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elInventario.Marca_Implemento = row[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                    elInventario.Tipo_Implemento = row[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                    elInventario.Precio_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    laListaDeInventario.Add(elInventario);

                }
             
                return laListaDeInventario;
            }
            catch (Exception e)
            {
                throw e;
            }

            

        }


        /// <summary>
        /// Metodo que devueve un tipoimplemnto dado su id
        /// </summary>
        /// <param name="Id_implemento">Indica el objeto a detallar</param>
        /// <returns>Retorna un implemento en especifico con todos sus detalles</returns>
        public static Implemento DetallarImplemento(int Id_implemento)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Implemento elImplemento = new Implemento();

                elParametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, Id_implemento.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.DETALLAR_IMPLEMENTO, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    elImplemento.Imagen_implemento = row[RecursosBDModulo16.PARAMETRO_IMAGEN].ToString();
                    elImplemento.Nombre_Implemento = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elImplemento.Tipo_Implemento = row[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                    elImplemento.Marca_Implemento = row[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                    elImplemento.Color_Implemento = row[RecursosBDModulo16.PARAMETRO_COLOR].ToString();
                    elImplemento.Talla_Implemento = row[RecursosBDModulo16.PARAMETRO_TALLA].ToString();
                    elImplemento.Estatus_Implemento = row[RecursosBDModulo16.PARAMETRO_ESTATUS].ToString();
                    elImplemento.Precio_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    //elImplemento.descripcion = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();

                }
                return elImplemento;

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        #endregion

    }
}