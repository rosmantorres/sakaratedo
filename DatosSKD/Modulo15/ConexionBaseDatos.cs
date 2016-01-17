using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace DatosSKD.Modulo15
{
   public static  class ConexionBaseDatos
   {
       #region agregarInventarioDatos
       public static void agregarInventarioDatos(Implemento implemento){

       BDConexion laConexion;
       List<Parametro> parametros ;
       Parametro parametro;
       try
       {
           //float precioNuevo = (float)precio_implemento;
           laConexion = new BDConexion();
           parametros = new List<Parametro>();
           if (implemento != null)
           {


               if ((implemento.Nombre_Implemento != null) && (implemento.Nombre_Implemento != ""))
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, implemento.Nombre_Implemento, false);

                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroNombreImplemento,
                   RecursosBDModulo15.tabla_idImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if ((implemento.Tipo_Implemento != null) && (implemento.Tipo_Implemento != ""))
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, implemento.Tipo_Implemento, false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTipoImplemento,
                   RecursosBDModulo15.tabla_tipoImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if ((implemento.Marca_Implemento != null) && (implemento.Marca_Implemento != ""))
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, implemento.Marca_Implemento, false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroMarcaImplemento,
                   RecursosBDModulo15.tabla_marcaImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if ((implemento.Color_Implemento != null) && (implemento.Color_Implemento != ""))
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, implemento.Color_Implemento, false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroColorImplemento,
                   RecursosBDModulo15.tabla_colorImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if ((implemento.Talla_Implemento != null) && (implemento.Talla_Implemento != ""))
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, implemento.Talla_Implemento, false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTallaImplemento,
                    RecursosBDModulo15.tabla_tallaImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if ((implemento.Precio_Implemento != null) && (implemento.Precio_Implemento > 0))
               {

                   parametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.Float, ((float)implemento.Precio_Implemento).ToString(), false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroPrecioImplemento,
                   RecursosBDModulo15.tabla_precioImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if ((implemento.Stock_Minimo_Implemento != null) && (implemento.Stock_Minimo_Implemento > 0))
               {

                   parametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.Int, implemento.Stock_Minimo_Implemento.ToString(), false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroStockMinimoImplemento,
                   RecursosBDModulo15.tabla_stockImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }

               if ((implemento.Cantida_implemento != null) && (implemento.Cantida_implemento > 0))
               {

                   parametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.Int, implemento.Cantida_implemento.ToString(), false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroCantidadInventario,
                   RecursosBDModulo15.tabla_cantidadImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if ((implemento.Descripcion_Implemento != null) && (implemento.Descripcion_Implemento != ""))
               {

                   parametro = new Parametro(RecursosBDModulo15.parametroDescripcionImplemento, SqlDbType.VarChar, implemento.Descripcion_Implemento, false);
                   parametros.Add(parametro);

               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDescripcionImplemento,
                   RecursosBDModulo15.tabla_descripcionImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if (implemento.Dojo_Implemento != null)
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, implemento.Dojo_Implemento.Dojo_Id.ToString(), false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                   RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               if ((implemento.Imagen_implemento != null) && (implemento.Imagen_implemento != ""))
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroImagenImplemento, SqlDbType.VarChar, implemento.Imagen_implemento, false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImagenImplemento,
                   RecursosBDModulo15.tabla_imagenImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }

               laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureAgregarInventario, parametros);
           }

           else
           {
               ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImplemento, RecursosBDModulo15.tabla_implemento, new Exception());
               Logger.EscribirError("ConexionBaseDatos", ex);
               throw ex;

           }
       }
       catch (ErrorEnParametroDeProcedure ex)
       {

           throw ex;
       }
       catch (ExceptionSKD ex)
       {
           Logger.EscribirError("ConexionBaseDatos", ex);
           throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());

       }
       
     }
       #endregion

       #region listarInventarioDatos 
       public static List<Implemento> listarInventarioDatos(Dojo dojo)
       {
           BDConexion laConexion;
           List<Implemento> listaDeImplementos = new List<Implemento>();
           List<Parametro> parametros;
           Parametro parametro;
           parametros = new List<Parametro>();
         
          
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               if ((dojo != null) && (dojo.Dojo_Id != null))
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, dojo.Dojo_Id.ToString(), false);
                   parametros.Add(parametro);
               }
               else
               {      ErrorEnParametroDeProcedure ex= new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                       RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                              Logger.EscribirError("ConexionBaseDatos",ex);
                    throw ex;
              }

                  DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarInventario, parametros);

               foreach (DataRow row in dt.Rows)
               {
                   Implemento implemento = new Implemento();
                   implemento.Dojo_Implemento = new Dojo();
                   implemento.Id_Implemento =    Convert .ToInt32(row[RecursosBDModulo15.tabla_idImplemento]);
                   implemento.Nombre_Implemento =row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                   implemento.Cantida_implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                   implemento.Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                   implemento.Tipo_Implemento   =row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                   implemento.Marca_Implemento  =row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                   implemento.Color_Implemento  =row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                   implemento.Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                   implemento.Dojo_Implemento.Dojo_Id =Convert.ToInt32(row[RecursosBDModulo15.tabla_dojoImplemento]);
                   implemento.Stock_Minimo_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_stockImplemento]);
                   implemento.Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                   implemento.Precio_Implemento =Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);

                   listaDeImplementos.Add(implemento);

               }

           }
           catch (ExceptionSKDConexionBD ex )
           {
              ex = new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                  RecursoGeneralBD.Mensaje, new Exception());
               Logger.EscribirError("ConexionBaseDatos", ex);
               throw ex;

           }
           catch (ExceptionSKD ex)
           {
               ex= new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
               Logger.EscribirError("ConexionBaseDatos", ex);
               throw ex;
           }

           return listaDeImplementos;

       }
       #endregion

       #region listarInventarioDatos2
       public static List<Implemento> listarInventarioDatos2(Dojo dojo)
       {
           BDConexion laConexion;
           List<Implemento> listaDeImplementos = new List<Implemento>();
           List<Parametro> parametros;

           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               Parametro parametro;
               if ((dojo != null) && (dojo.Dojo_Id != null))
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, dojo.Dojo_Id.ToString(), false);
                   parametros.Add(parametro);
               }
               else
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                     RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
               DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarInventario2, parametros);

               foreach (DataRow row in dt.Rows)
               {
                   Implemento implemento = new Implemento();
                   implemento.Dojo_Implemento = new Dojo();
                   implemento.Id_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_idImplemento]);
                   implemento.Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                   implemento.Cantida_implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                   implemento.Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                   implemento.Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                   implemento.Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                   implemento.Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                   implemento.Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                   implemento.Dojo_Implemento.Dojo_Id = Convert.ToInt32(row[RecursosBDModulo15.tabla_dojoImplemento]);
                   implemento.Stock_Minimo_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_stockImplemento]);
                   implemento.Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                   implemento.Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);

                   listaDeImplementos.Add(implemento);

               }

           }

           catch (ExceptionSKDConexionBD ex)
           {
             ex= new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                  RecursoGeneralBD.Mensaje, new Exception());
           }
           catch (ExceptionSKD ex)
           {
               ex = new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
               Logger.EscribirError("ConexionBaseDatos", ex);
               throw ex;
           }
           return listaDeImplementos;

       }
       #endregion

       #region implementoInventarioDatos
       public static Implemento implementoInventarioDatos(int idImplemento)
       {
           BDConexion laConexion;
           Implemento implemento = new Implemento();
           implemento.Dojo_Implemento = new Dojo();
           List<Parametro> parametros;
           Parametro parametro;
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               if (idImplemento != null)
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, idImplemento.ToString(), false);
                   parametros.Add(parametro);
               }
               else
                   throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroIdimplemento,
                       RecursosBDModulo15.tabla_idImplemento, new Exception());

               DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplemento, parametros);
               DataRow row; 
                row= dt.Rows[0];
               

                   implemento.Id_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_idImplemento]);
                   implemento.Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                   implemento.Cantida_implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                   implemento.Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                   implemento.Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                   implemento.Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                   implemento.Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                   implemento.Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                   implemento.Dojo_Implemento.Dojo_Id = Convert.ToInt32(row[RecursosBDModulo15.tabla_dojoImplemento]);
                   implemento.Stock_Minimo_Implemento = Convert.ToInt32(row[RecursosBDModulo15.tabla_stockImplemento]);
                   implemento.Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                   implemento.Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                   implemento.Descripcion_Implemento =row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
               

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

           return implemento;

       }
       #endregion

       #region eliminarInventarioDatos
       public  static void eliminarInventarioDatos(int idInventario,Dojo dojo)
       {

           BDConexion laConexion;
           List<Parametro> parametros;
           Parametro parametro;
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               if (idInventario != null)
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, idInventario.ToString(), false);
                   parametros.Add(parametro);
               }
               else
                   throw new ExcepcionesSKD.Modulo15.ImplementoSinIDException(RecursosBDModulo15.parametroIdimplemento,
                       RecursosBDModulo15.tabla_idImplemento, new Exception());

               if (dojo != null)
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, dojo.Dojo_Id.ToString(), false);
                   parametros.Add(parametro);
               }
               else
                   throw new ExcepcionesSKD.Modulo15.ImplementoSinIDException(RecursosBDModulo15.parametroDojoIdImplemento,
                       RecursosBDModulo15.tabla_dojoImplemento, new Exception());

                   laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureEliminarInventario, parametros);
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
       }
       #endregion

       #region modificarInventarioDatos
       public static void modificarInventarioDatos(Implemento implemento)
       {

           BDConexion laConexion;
           List<Parametro> parametros;
           Parametro parametro;
           //float precioNuevo = (float)precio_implemento;

           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();

               if (implemento != null)
               {

                   if (implemento.Id_Implemento != null)
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, implemento.Id_Implemento.ToString(), false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroIdimplemento,
                       RecursosBDModulo15.tabla_idImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Nombre_Implemento != null) && (implemento.Nombre_Implemento != ""))
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, implemento.Nombre_Implemento, false);
                       parametros.Add(parametro);
                   }
                   else
                       throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroNombreImplemento,
                         RecursosBDModulo15.tabla_idImplemento, new Exception());

                   if ((implemento.Tipo_Implemento != null) && (implemento.Tipo_Implemento != ""))
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, implemento.Tipo_Implemento, false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTipoImplemento,
                       RecursosBDModulo15.tabla_tipoImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Marca_Implemento != null) && (implemento.Marca_Implemento != ""))
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, implemento.Marca_Implemento, false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroMarcaImplemento,
                       RecursosBDModulo15.tabla_marcaImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Color_Implemento != null) && (implemento.Color_Implemento != ""))
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, implemento.Color_Implemento, false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroColorImplemento,
                       RecursosBDModulo15.tabla_colorImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Talla_Implemento != null) && (implemento.Talla_Implemento != ""))
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, implemento.Talla_Implemento, false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTallaImplemento,
                        RecursosBDModulo15.tabla_tallaImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Precio_Implemento != null) && (implemento.Precio_Implemento > 0))
                   {

                       parametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.Float, ((float)implemento.Precio_Implemento).ToString(), false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroPrecioImplemento,
                       RecursosBDModulo15.tabla_precioImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Stock_Minimo_Implemento != null) && (implemento.Stock_Minimo_Implemento > 0))
                   {

                       parametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.Int, implemento.Stock_Minimo_Implemento.ToString(), false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroStockMinimoImplemento,
                       RecursosBDModulo15.tabla_stockImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Cantida_implemento != null) && (implemento.Cantida_implemento > 0))
                   {

                       parametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.Int, implemento.Cantida_implemento.ToString(), false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroCantidadInventario,
                       RecursosBDModulo15.tabla_cantidadImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Descripcion_Implemento != null) && (implemento.Descripcion_Implemento != ""))
                   {

                       parametro = new Parametro(RecursosBDModulo15.parametroDescripcionImplemento, SqlDbType.VarChar, implemento.Descripcion_Implemento, false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDescripcionImplemento,
                       RecursosBDModulo15.tabla_descripcionImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if (implemento.Dojo_Implemento != null)
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, implemento.Dojo_Implemento.Dojo_Id.ToString(), false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                       RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Estatus_Implemento != null) && (implemento.Estatus_Implemento != ""))
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroEstatusImplemento, SqlDbType.VarChar, implemento.Estatus_Implemento, false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroEstatusImplemento,
                       RecursosBDModulo15.tabla_estatusImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }
                   if ((implemento.Imagen_implemento != null) && (implemento.Imagen_implemento != ""))
                   {
                       parametro = new Parametro(RecursosBDModulo15.parametroImagenImplemento, SqlDbType.VarChar, implemento.Imagen_implemento, false);
                       parametros.Add(parametro);
                   }
                   else
                   {
                       ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImagenImplemento,
                       RecursosBDModulo15.tabla_imagenImplemento, new Exception());
                       Logger.EscribirError("ConexionBaseDatos", ex);
                       throw ex;
                   }


                   laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureModificarInventario, parametros);
               }
               else 
               {
                   ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImplemento, RecursosBDModulo15.tabla_implemento, new Exception());
                   Logger.EscribirError("ConexionBaseDatos", ex);
                   throw ex;
               }
           }

           catch (SqlException ex)
           {
               throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                  RecursoGeneralBD.Mensaje, new Exception());
           }
         
           catch (ErrorEnParametroDeProcedure ex)
           {

               throw ex;
           }
           catch (Exception ex)
           {

               throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", new Exception());
           }   


       }
       #endregion 

       #region listarCarrito

       public static List<Implemento> listarInventarioDatos()
       {
           BDConexion laConexion;
           List<Implemento> listaDeImplementos = new List<Implemento>();
           List<Parametro> parametros;
           parametros = new List<Parametro>();
         
          
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarCarrito, parametros);

               foreach (DataRow row in dt.Rows)
               {
                   Implemento implemento = new Implemento();
                 //  implemento.Dojo_Implemento = new Dojo();
                   implemento.Id_Implemento =    Convert .ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                   implemento.Nombre_Implemento =row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                //   implemento.Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                   implemento.Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                   implemento.Tipo_Implemento   =row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                   implemento.Marca_Implemento  =row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                   implemento.Color_Implemento  =row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                   implemento.Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
              //     implemento.Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                   implemento.Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                   implemento.Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                   implemento.Precio_Implemento =Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                   implemento.Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
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

           return listaDeImplementos;

       }
       #endregion

       #region implementoInventarioDatosUltimo
       public static Implemento implementoInventarioDatosUltimo()
       {
           BDConexion laConexion;
           Implemento implemento = new Implemento();
           implemento.Dojo_Implemento = new Dojo();
           List<Parametro> parametros;
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplementoU, parametros);
               DataRow row;
               row = dt.Rows[0];


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
               implemento.Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
           }
           catch (Exception e)
           {
               throw e;
           }


           return implemento;

       }
       #endregion

       #region implementoInventarioDatosBool
       public static bool implementoInventarioDatosBool(int idImplemento)
       {
           BDConexion laConexion;
           Implemento implemento = new Implemento();
           implemento.Dojo_Implemento = new Dojo();
           List<Parametro> parametros;
           Parametro parametro;
           try
           {
               laConexion = new BDConexion();
               parametros = new List<Parametro>();
               if (idImplemento != null)
               {
                   parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, idImplemento.ToString(), false);
                   parametros.Add(parametro);
               }
               else
                   throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroIdimplemento,
                       RecursosBDModulo15.tabla_idImplemento, new Exception());

               DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplemento, parametros);
               DataRow row;
               row = dt.Rows[0];


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

           if (implemento.Id_Implemento == idImplemento)
               return true;
           else
               return false;

       }
       #endregion

       #region usuarioImplemento
       public static int usuarioImplementoDatos(String usuario)
       {
           BDConexion laConexion;
           List<Parametro> parametros;
           Parametro parametro;
            int idDojo;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (usuario != null)
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroUsuario, SqlDbType.VarChar, usuario, false);
                    parametros.Add(parametro);
                }
                else
                    throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroUsuario,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureUsuario, parametros);
                DataRow row;
                row = dt.Rows[0];


                idDojo = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
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

          return idDojo;

       }
       #endregion


   }
}
