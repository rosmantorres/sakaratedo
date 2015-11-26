using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace DatosSKD.Modulo15
{
   public static  class ConexionBaseDatos
   {
       #region agregarInventarioDatos
       public static void agregarInventarioDatos(String nombre_implemento,
                                             String tipo_implemento,
                                             String marca_implemento,
                                             String color_implemento,
                                             String talla_implemento,
                                             int dojo ,int cantidad,
                                             int stock_minimo,
                                             String estatus_implemento,
                                             double precio_implemento){

       BDConexion laConexion;
       List<Parametro> parametros ;
       Parametro parametro;
       try
       {
           laConexion = new BDConexion();
           parametros = new List<Parametro>();
           parametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, nombre_implemento,false);
           parametros.Add(parametro);
           parametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, nombre_implemento, false);
           parametros.Add(parametro);
           parametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, nombre_implemento, false);
           parametros.Add(parametro);
           parametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, nombre_implemento, false);
           parametros.Add(parametro);
           parametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, nombre_implemento, false);
           parametros.Add(parametro);
           parametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.VarChar, nombre_implemento, false);
           parametros.Add(parametro);
           parametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.VarChar, nombre_implemento, false);
           parametros.Add(parametro);
           parametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.VarChar, nombre_implemento, false);
           parametros.Add(parametro);
           laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureAgregarInventario, parametros);
       }catch(Exception ex){

           throw ex;
       
       }
       


       }
       #endregion

       #region listarInventarioDatos 

       public static List<Implemento> listarInventarioDatos()
       {
           BDConexion laConexion;
           List<Implemento> listaDeImplementos = new List<Implemento>();
           List<Parametro> parametros;

           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();

               DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarInventario, parametros);

               foreach (DataRow row in dt.Rows)
               {
                   Implemento implemento = new Implemento();

                   implemento.Id_Implemento =    Convert .ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                   implemento.Nombre_Implemento =row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                   implemento.Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplento]);
                   implemento.Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                   implemento.Tipo_Implemento   =row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                   implemento.Marca_Implemento  =row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                   implemento.Color_Implemento  =row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                   implemento.Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                   implemento.Dojo_Implemento = row[RecursosBDModulo15.tabla_dojoImplemento].ToString();
                   implemento.Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                   implemento.Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                   implemento.Precio_Implemento =Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);

                   listaDeImplementos.Add(implemento);

               }

           }
           catch (Exception e)
           {
               throw e;
           }


           return listaDeImplementos;

       }
       #endregion

       #region listarInventarioDatos2

       public static List<Implemento> listarInventarioDatos2()
       {
           BDConexion laConexion;
           List<Implemento> listaDeImplementos = new List<Implemento>();
           List<Parametro> parametros;

           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();

               DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarInventario2, parametros);

               foreach (DataRow row in dt.Rows)
               {
                   Implemento implemento = new Implemento();

                   implemento.Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                   implemento.Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                   implemento.Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplento]);
                   implemento.Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                   implemento.Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                   implemento.Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                   implemento.Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                   implemento.Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                   implemento.Dojo_Implemento = row[RecursosBDModulo15.tabla_dojoImplemento].ToString();
                   implemento.Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                   implemento.Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                   implemento.Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);

                   listaDeImplementos.Add(implemento);

               }

           }
           catch (Exception e)
           {
               throw e;
           }


           return listaDeImplementos;

       }
       #endregion

       #region implementoInventarioDatos
       public static Implemento implementoInventarioDatos(int idImplemento)
       {
           BDConexion laConexion;
           Implemento implemento = new Implemento();
           List<Parametro> parametros;
           Parametro parametro;
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, idImplemento.ToString(), false);
               parametros.Add(parametro);
               DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplemento, parametros);
               DataRow row; 
                row= dt.Rows[0];
               

                   implemento.Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                   implemento.Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                   implemento.Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplento]);
                   implemento.Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                   implemento.Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                   implemento.Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                   implemento.Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                   implemento.Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                   implemento.Dojo_Implemento = row[RecursosBDModulo15.tabla_dojoImplemento].ToString();
                   implemento.Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                   implemento.Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                   implemento.Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
               

           }
           catch (Exception e)
           {
               throw e;
           }


           return implemento;

       }
       #endregion


       #region eliminarInventarioDatos
       public  static void eliminarInventarioDatos(int idInventario)
       {

           BDConexion laConexion;
           List<Parametro> parametros;
           Parametro parametro;
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, idInventario.ToString(), false);
               parametros.Add(parametro);
               laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureEliminarInventario, parametros);
           }
           catch (Exception ex)
           {

               throw ex;


           }
       }
       #endregion

       #region modificarInventarioDatos
       public static void modificarInventarioDatos(String nombre_implemento,
                                             String tipo_implemento,
                                             String marca_implemento,
                                             String color_implemento,
                                             String talla_implemento,
                                             int dojo, int cantidad,
                                             int stock_minimo,
                                             String estatus_implemento,
                                             double precio_implemento)
       {

           BDConexion laConexion;
           List<Parametro> parametros;
           Parametro parametro;
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               parametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, nombre_implemento, false);
               parametros.Add(parametro);
               parametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, nombre_implemento, false);
               parametros.Add(parametro);
               parametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, nombre_implemento, false);
               parametros.Add(parametro);
               parametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, nombre_implemento, false);
               parametros.Add(parametro);
               parametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, nombre_implemento, false);
               parametros.Add(parametro);
               parametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.VarChar, nombre_implemento, false);
               parametros.Add(parametro);
               parametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.VarChar, nombre_implemento, false);
               parametros.Add(parametro);
               parametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.VarChar, nombre_implemento, false);
               parametros.Add(parametro);
               laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureModificarInventario, parametros);
           }
           catch (Exception ex)
           {

               throw ex;

           }



       }
       #endregion 


   }
}
