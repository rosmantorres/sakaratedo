using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
namespace DatosSKD.Modulo13
{
    class BDimplementos
    {

        
        #region Listar Implementarios

        public static DataTable D_Inventario()
        {
            BDConexion laConexion;
            List<Implemento> listaDeImplementos = new List<Implemento>();
// List<Parametro> parametros;
  //          Parametro parametro;
    //        parametros = new List<Parametro>();


            try
            {
                laConexion = new BDConexion();
      //          parametros = new List<Parametro>();
        /*        if ((dojo != null) && (dojo.Dojo_Id != null))
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, dojo.Dojo_Id.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                    throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                */
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas("M13_inventario", null);
/*
                foreach (DataRow row in dt.Rows)
                {
                    Implemento implemento = new Implemento();
                    implemento.Dojo_Implemento = new Dojo();
                    implemento.Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                    implemento.Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    implemento.Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    implemento.Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    implemento.Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    implemento.Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    implemento.Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    implemento.Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    implemento.Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    implemento.Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                    implemento.Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    implemento.Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);

                    listaDeImplementos.Add(implemento);

                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                   RecursoGeneralBD.Mensaje, new Exception());
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
            }
                */
            return dt;

        }
        #endregion

       






    }
}
