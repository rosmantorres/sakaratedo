using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;
using DatosSKD.Modulo15;
using DominioSKD;
using DatosSKD.InterfazDAO.Modulo15;
using DominioSKD.Fabrica;

namespace DatosSKD.DAO.Modulo15
{
    public class DaoImplemento : DAOGeneral, IDaoImplemento
    {


        #region IDaoImplemento
        #region listarInventarioDatos
           List<Entidad> IDaoImplemento.listarInventarioDatos(Entidad parametroDojo)
        {
            BDConexion laConexion;
            List<Entidad> listaDeImplementos = new List<Entidad>();
            List<Parametro> parametros;
            Parametro parametro;
            parametros = new List<Parametro>();
            FabricaEntidades fabrica = new FabricaEntidades();
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (((Dojo)parametroDojo != null) && (((Dojo)parametroDojo).Dojo_Id != null))
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)parametroDojo).Dojo_Id.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                {
                    ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                     RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                    Logger.EscribirError("ConexionBaseDatos", ex);
                    throw ex;
                }

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarInventario, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad implemento = (Implemento)fabrica.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = new Dojo();
                    ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                    ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    ((Implemento)implemento).Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                    ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);

                    listaDeImplementos.Add(implemento);

                }

            }
            catch (ExceptionSKDConexionBD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, new Exception());
                Logger.EscribirError("ConexionBaseDatos", ex);
                throw ex;

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

        #region listaInventarioDatos2
           List<Entidad> IDaoImplemento.listarInventarioDatos2(Entidad parametroDojo)
        {
            BDConexion laConexion;
            List<Entidad> listaDeImplementos = new List<Entidad>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Parametro parametro;
                FabricaEntidades fabrica = new FabricaEntidades();
                if ((((Dojo)parametroDojo) != null) && (((Dojo)parametroDojo).Dojo_Id != null))
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)parametroDojo).Dojo_Id.ToString(), false);
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
                    Entidad implemento = fabrica.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = new Dojo();
                    ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                    ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    ((Implemento)implemento).Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                    ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                    listaDeImplementos.Add(implemento);

                }

            }

            catch (ExceptionSKDConexionBD ex)
            {
                ex = new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
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
          Entidad IDaoImplemento.implementoInventarioDatos(int idImplemento)
        {
            BDConexion laConexion;
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad implemento = fabrica.ObtenerImplemento();
            ((Implemento)implemento).Dojo_Implemento = (Dojo)fabrica.ObtenerDojo();
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


                ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                ((Implemento)implemento).Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();


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
          bool IDaoImplemento.eliminarInventarioDatos(int idInventario, Entidad parametroDojo)
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

                if (((Dojo)parametroDojo) != null)
                {
                    parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Dojo)parametroDojo).Dojo_Id.ToString(), false);
                    parametros.Add(parametro);
                }
                else
                    throw new ExcepcionesSKD.Modulo15.ImplementoSinIDException(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());

                laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureEliminarInventario, parametros);
                return true;
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
            return false;
        }
        #endregion

        #region modificarInventarioDatos
          bool IDaoImplemento.modificarInventarioDatos(Entidad parametroImplemento)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametro;
            //float precioNuevo = (float)precio_implemento;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                if (((Implemento)parametroImplemento) != null)
                {

                    if (((Implemento)parametroImplemento).Id_Implemento != null)
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, ((Implemento)parametroImplemento).Id_Implemento.ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Nombre_Implemento != null) && (((Implemento)parametroImplemento).Nombre_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Nombre_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                        throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroNombreImplemento,
                          RecursosBDModulo15.tabla_idImplemento, new Exception());

                    if ((((Implemento)parametroImplemento).Tipo_Implemento != null) && (((Implemento)parametroImplemento).Tipo_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Tipo_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTipoImplemento,
                        RecursosBDModulo15.tabla_tipoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Marca_Implemento != null) && (((Implemento)parametroImplemento).Marca_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Marca_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroMarcaImplemento,
                        RecursosBDModulo15.tabla_marcaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Color_Implemento != null) && (((Implemento)parametroImplemento).Color_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Color_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroColorImplemento,
                        RecursosBDModulo15.tabla_colorImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Talla_Implemento != null) && (((Implemento)parametroImplemento).Talla_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Talla_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTallaImplemento,
                         RecursosBDModulo15.tabla_tallaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Precio_Implemento != null) && (((Implemento)parametroImplemento).Precio_Implemento > 0))
                    {

                        parametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.Float, ((float)((Implemento)parametroImplemento).Precio_Implemento).ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroPrecioImplemento,
                        RecursosBDModulo15.tabla_precioImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Stock_Minimo_Implemento != null) && (((Implemento)parametroImplemento).Stock_Minimo_Implemento > 0))
                    {

                        parametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.Int, ((Implemento)parametroImplemento).Stock_Minimo_Implemento.ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroStockMinimoImplemento,
                        RecursosBDModulo15.tabla_stockImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Cantida_implemento != null) && (((Implemento)parametroImplemento).Cantida_implemento > 0))
                    {

                        parametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.Int, ((Implemento)parametroImplemento).Cantida_implemento.ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroCantidadInventario,
                        RecursosBDModulo15.tabla_cantidadImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Descripcion_Implemento != null) && (((Implemento)parametroImplemento).Descripcion_Implemento != ""))
                    {

                        parametro = new Parametro(RecursosBDModulo15.parametroDescripcionImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Descripcion_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDescripcionImplemento,
                        RecursosBDModulo15.tabla_descripcionImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if (((Implemento)parametroImplemento).Dojo_Implemento != null)
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Implemento)parametroImplemento).Dojo_Implemento.Dojo_Id.ToString(), false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Estatus_Implemento != null) && (((Implemento)parametroImplemento).Estatus_Implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroEstatusImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Estatus_Implemento, false);
                        parametros.Add(parametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroEstatusImplemento,
                        RecursosBDModulo15.tabla_estatusImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametroImplemento).Imagen_implemento != null) && (((Implemento)parametroImplemento).Imagen_implemento != ""))
                    {
                        parametro = new Parametro(RecursosBDModulo15.parametroImagenImplemento, SqlDbType.VarChar, ((Implemento)parametroImplemento).Imagen_implemento, false);
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
                    return true;
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
            return false;
        }
        #endregion

        #region listarInventarioDatos
            List<Entidad> IDaoImplemento.listarInventarioDatos()
        {
            BDConexion laConexion;
            FabricaEntidades fabrica = new FabricaEntidades();
            List<Entidad> listaDeImplementos = new List<Entidad>();
            List<Parametro> parametros;
            parametros = new List<Parametro>();


            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarCarrito, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad implemento = fabrica.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = new Dojo();
                    ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                    ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    ((Implemento)implemento).Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                    ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                  //  ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
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
          Entidad IDaoImplemento.implementoInventarioDatosUltimo()
        {
            BDConexion laConexion;
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad implemento = fabrica.ObtenerImplemento();
            ((Implemento)implemento).Dojo_Implemento = new Dojo();
            List<Parametro> parametros;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplementoU, parametros);
                DataRow row;
                row = dt.Rows[0];


                ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                ((Implemento)implemento).Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                //((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }


            return implemento;
        }
        #endregion

        #region implementoInventarioDatosBool
          bool IDaoImplemento.implementoInventarioDatosBool(int idImplemento)
          {
            BDConexion laConexion;
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad implemento = new Implemento();
            ((Implemento)implemento).Dojo_Implemento = new Dojo();
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


                ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                ((Implemento)implemento).Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);

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

            if (((Implemento)implemento).Id_Implemento == idImplemento)
                return true;
            else
                return false;
        }
        #endregion

        #region usuarioImplementoDatos
          int IDaoImplemento.usuarioImplementoDatos(string usuario)
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

          #region 
          #endregion
        #endregion

          #region IDAO

          #region Agregar
          bool InterfazDAO.IDao<Entidad, bool, Entidad>.Agregar(Entidad parametro)
        {

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro;


            try
            {
                //float precioNuevo = (float)precio_implemento;
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (((Implemento)parametro) != null)
                {


                    if ((((Implemento)parametro).Nombre_Implemento != null) && (((Implemento)parametro).Nombre_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, ((Implemento)parametro).Nombre_Implemento, false);

                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroNombreImplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Tipo_Implemento != null) && (((Implemento)parametro).Tipo_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, ((Implemento)parametro).Tipo_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTipoImplemento,
                        RecursosBDModulo15.tabla_tipoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Marca_Implemento != null) && (((Implemento)parametro).Marca_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, ((Implemento)parametro).Marca_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroMarcaImplemento,
                        RecursosBDModulo15.tabla_marcaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Color_Implemento != null) && (((Implemento)parametro).Color_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, ((Implemento)parametro).Color_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroColorImplemento,
                        RecursosBDModulo15.tabla_colorImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Talla_Implemento != null) && (((Implemento)parametro).Talla_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, ((Implemento)parametro).Talla_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTallaImplemento,
                         RecursosBDModulo15.tabla_tallaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Precio_Implemento != null) && (((Implemento)parametro).Precio_Implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.Float, ((float)((Implemento)parametro).Precio_Implemento).ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroPrecioImplemento,
                        RecursosBDModulo15.tabla_precioImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Stock_Minimo_Implemento != null) && (((Implemento)parametro).Stock_Minimo_Implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.Int, ((Implemento)parametro).Stock_Minimo_Implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroStockMinimoImplemento,
                        RecursosBDModulo15.tabla_stockImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }

                    if ((((Implemento)parametro).Cantida_implemento != null) && (((Implemento)parametro).Cantida_implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.Int, ((Implemento)parametro).Cantida_implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroCantidadInventario,
                        RecursosBDModulo15.tabla_cantidadImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Descripcion_Implemento != null) && (((Implemento)parametro).Descripcion_Implemento != ""))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroDescripcionImplemento, SqlDbType.VarChar, ((Implemento)parametro).Descripcion_Implemento, false);
                        parametros.Add(elParametro);

                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDescripcionImplemento,
                        RecursosBDModulo15.tabla_descripcionImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if (((Implemento)parametro).Dojo_Implemento != null)
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Implemento)parametro).Dojo_Implemento.Dojo_Id.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Imagen_implemento != null) && (((Implemento)parametro).Imagen_implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroImagenImplemento, SqlDbType.VarChar, ((Implemento)parametro).Imagen_implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImagenImplemento,
                        RecursosBDModulo15.tabla_imagenImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }

                    laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureAgregarInventario, parametros);
                    return true;
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

        #region Modificar
          bool InterfazDAO.IDao<Entidad, bool, Entidad>.Modificar(Entidad parametro)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro;
            //float precioNuevo = (float)precio_implemento;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                if (((Implemento)parametro) != null)
                {

                    if (((Implemento)parametro).Id_Implemento != null)
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, ((Implemento)parametro).Id_Implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Nombre_Implemento != null) && (((Implemento)parametro).Nombre_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroNombreImplemento, SqlDbType.VarChar, ((Implemento)parametro).Nombre_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                        throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroNombreImplemento,
                          RecursosBDModulo15.tabla_idImplemento, new Exception());

                    if ((((Implemento)parametro).Tipo_Implemento != null) && (((Implemento)parametro).Tipo_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroTipoImplemento, SqlDbType.VarChar, ((Implemento)parametro).Tipo_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTipoImplemento,
                        RecursosBDModulo15.tabla_tipoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Marca_Implemento != null) && (((Implemento)parametro).Marca_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroMarcaImplemento, SqlDbType.VarChar, ((Implemento)parametro).Marca_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroMarcaImplemento,
                        RecursosBDModulo15.tabla_marcaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Color_Implemento != null) && (((Implemento)parametro).Color_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroColorImplemento, SqlDbType.VarChar, ((Implemento)parametro).Color_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroColorImplemento,
                        RecursosBDModulo15.tabla_colorImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Talla_Implemento != null) && (((Implemento)parametro).Talla_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroTallaImplemento, SqlDbType.VarChar, ((Implemento)parametro).Talla_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroTallaImplemento,
                         RecursosBDModulo15.tabla_tallaImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Precio_Implemento != null) && (((Implemento)parametro).Precio_Implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroPrecioImplemento, SqlDbType.Float, ((float)((Implemento)parametro).Precio_Implemento).ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroPrecioImplemento,
                        RecursosBDModulo15.tabla_precioImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Stock_Minimo_Implemento != null) && (((Implemento)parametro).Stock_Minimo_Implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroStockMinimoImplemento, SqlDbType.Int, ((Implemento)parametro).Stock_Minimo_Implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroStockMinimoImplemento,
                        RecursosBDModulo15.tabla_stockImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Cantida_implemento != null) && (((Implemento)parametro).Cantida_implemento > 0))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroCantidadInventario, SqlDbType.Int, ((Implemento)parametro).Cantida_implemento.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroCantidadInventario,
                        RecursosBDModulo15.tabla_cantidadImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Descripcion_Implemento != null) && (((Implemento)parametro).Descripcion_Implemento != ""))
                    {

                        elParametro = new Parametro(RecursosBDModulo15.parametroDescripcionImplemento, SqlDbType.VarChar, ((Implemento)parametro).Descripcion_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDescripcionImplemento,
                        RecursosBDModulo15.tabla_descripcionImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if (((Implemento)parametro).Dojo_Implemento != null)
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroDojoIdImplemento, SqlDbType.Int, ((Implemento)parametro).Dojo_Implemento.Dojo_Id.ToString(), false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroDojoIdImplemento,
                        RecursosBDModulo15.tabla_dojoImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Estatus_Implemento != null) && (((Implemento)parametro).Estatus_Implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroEstatusImplemento, SqlDbType.VarChar, ((Implemento)parametro).Estatus_Implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroEstatusImplemento,
                        RecursosBDModulo15.tabla_estatusImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }
                    if ((((Implemento)parametro).Imagen_implemento != null) && (((Implemento)parametro).Imagen_implemento != ""))
                    {
                        elParametro = new Parametro(RecursosBDModulo15.parametroImagenImplemento, SqlDbType.VarChar, ((Implemento)parametro).Imagen_implemento, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        ErrorEnParametroDeProcedure ex = new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroImagenImplemento,
                        RecursosBDModulo15.tabla_imagenImplemento, new Exception());
                        Logger.EscribirError("ConexionBaseDatos", ex);
                        throw ex;
                    }


                    laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureModificarInventario, parametros);
                    return true;
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
            return false;
        }
        #endregion

        #region ConsultarXId
           Entidad InterfazDAO.IDao<Entidad, bool, Entidad>.ConsultarXId(Entidad parametro)
        {
            BDConexion laConexion;
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad implemento = fabrica.ObtenerImplemento();
            ((Implemento)implemento).Dojo_Implemento = (Dojo)fabrica.ObtenerDojo();
            List<Parametro> parametros;
            Parametro elParametro;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                if (((Implemento)parametro).Id_Implemento != null)
                {
                    elParametro = new Parametro(RecursosBDModulo15.parametroIdimplemento, SqlDbType.Int, ((Implemento)parametro).Id_Implemento.ToString(), false);
                    parametros.Add(elParametro);
                }
                else
                    throw new ExcepcionesSKD.Modulo15.ErrorEnParametroDeProcedure(RecursosBDModulo15.parametroIdimplemento,
                        RecursosBDModulo15.tabla_idImplemento, new Exception());

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarImplemento, parametros);
                DataRow row;
                row = dt.Rows[0];


                ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                ((Implemento)implemento).Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();


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

        #region ConsultarTodos
         List<Entidad> InterfazDAO.IDao<Entidad, bool, Entidad>.ConsultarTodos()
        {
            BDConexion laConexion;
            FabricaEntidades fabrica = new FabricaEntidades();
            List<Entidad> listaDeImplementos = new List<Entidad>();
            List<Parametro> parametros;
            parametros = new List<Parametro>();


            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo15.nombreProcedureConsultarCarrito, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Entidad implemento = fabrica.ObtenerImplemento();
                    ((Implemento)implemento).Dojo_Implemento = new Dojo();
                    ((Implemento)implemento).Id_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_idImplemento]);
                    ((Implemento)implemento).Nombre_Implemento = row[RecursosBDModulo15.tabla_nombreImplemento].ToString();
                    ((Implemento)implemento).Cantida_implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_cantidadImplemento]);
                    ((Implemento)implemento).Imagen_implemento = row[RecursosBDModulo15.tabla_imagenImplemento].ToString();
                    ((Implemento)implemento).Tipo_Implemento = row[RecursosBDModulo15.tabla_tipoImplemento].ToString();
                    ((Implemento)implemento).Marca_Implemento = row[RecursosBDModulo15.tabla_marcaImplemento].ToString();
                    ((Implemento)implemento).Color_Implemento = row[RecursosBDModulo15.tabla_colorImplemento].ToString();
                    ((Implemento)implemento).Talla_Implemento = row[RecursosBDModulo15.tabla_tallaImplemento].ToString();
                    ((Implemento)implemento).Dojo_Implemento.Dojo_Id = Convert.ToInt16(row[RecursosBDModulo15.tabla_dojoImplemento]);
                    ((Implemento)implemento).Stock_Minimo_Implemento = Convert.ToInt16(row[RecursosBDModulo15.tabla_stockImplemento]);
                    ((Implemento)implemento).Estatus_Implemento = row[RecursosBDModulo15.tabla_estatusImplemento].ToString();
                    ((Implemento)implemento).Precio_Implemento = Convert.ToDouble(row[RecursosBDModulo15.tabla_precioImplemento]);
                    ((Implemento)implemento).Descripcion_Implemento = row[RecursosBDModulo15.tabla_descripcionImplemento].ToString();
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

        #endregion



          
    }
}
