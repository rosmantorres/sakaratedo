using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;
using ExcepcionesSKD;
using System.Globalization;
using DominioSKD.Fabrica;
using DatosSKD.InterfazDAO;
using DatosSKD.InterfazDAO.Modulo5;

namespace DatosSKD.DAO.Modulo5
{
    public class DaoCinta : DAOGeneral, IDaoCinta
    {
        #region IDAO
        public bool Agregar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

                FabricaEntidades laFabrica = new FabricaEntidades();
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;                

                laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)laFabrica.ObtenerOrganizacion_M3(laCinta.Organizacion.Id_organizacion, laCinta.Organizacion.Nombre);

                if (ValidarOrganizacion(laOrganizacion)) 
                {
                    if (!ValidarNombreCinta(laCinta))
                    {
                        if (!ValidarOrdenCinta(laCinta))
                        { 
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamColorCinta, SqlDbType.VarChar, laCinta.Color_nombre, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamRangoCinta, SqlDbType.VarChar, laCinta.Rango, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamClasiCinta, SqlDbType.VarChar, laCinta.Clasificacion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamSignificadoCinta, SqlDbType.VarChar, laCinta.Significado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamOrdenCinta, SqlDbType.Int, laCinta.Orden.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int, laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosDaoModulo5.AgregarCinta
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

                    }
                    else
                    {
                        throw new ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException(RecursosDaoModulo5.Codigo_Orden_Cinta_Repetida,
                                RecursosDaoModulo5.Mensaje_Orden_Cinta_Repetida, new Exception());
                    }
                  }
                  else
                  {
                      throw new ExcepcionesSKD.Modulo5.CintaRepetidaException(RecursosDaoModulo5.Codigo_Cinta_Repetida,
                              RecursosDaoModulo5.Mensaje_Cinta_Repetida, new Exception());
                  }
            }// Fin if    
            else
            {
                throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosDaoModulo5.Codigo_Organizacion_Inexistente,
                                RecursosDaoModulo5.Mensaje_Organizacion_Inexistente, new Exception());
            }
            } // Fin Try
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                     RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            return true;
        }

        public bool Modificar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

                FabricaEntidades laFabrica = new FabricaEntidades();
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;

                laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)laFabrica.ObtenerOrganizacion_M3(laCinta.Organizacion.Id_organizacion, laCinta.Organizacion.Nombre);

                if (ValidarOrganizacion(laOrganizacion))
               {
                  if (!ValidarNombreCinta(laCinta))
                   {
                       if (!ValidarOrdenCinta(laCinta))
                       { 
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosDaoModulo5.PararamIdCinta, SqlDbType.Int, laCinta.Id_cinta.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamColorCinta, SqlDbType.VarChar, laCinta.Color_nombre, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamRangoCinta, SqlDbType.VarChar, laCinta.Rango, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamClasiCinta, SqlDbType.VarChar, laCinta.Clasificacion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamSignificadoCinta, SqlDbType.VarChar, laCinta.Significado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamOrdenCinta, SqlDbType.Int, laCinta.Orden.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int, laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosDaoModulo5.ParamNomOrg, SqlDbType.VarChar, laCinta.Organizacion.Nombre, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosDaoModulo5.ModificarCinta
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

                  }
                     else
                     {
                         throw new ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException(RecursosDaoModulo5.Codigo_Orden_Cinta_Repetida,
                                 RecursosDaoModulo5.Mensaje_Orden_Cinta_Repetida, new Exception());
                     }
                   }
                   else
                   {
                       throw new ExcepcionesSKD.Modulo5.CintaRepetidaException(RecursosDaoModulo5.Codigo_Cinta_Repetida,
                               RecursosDaoModulo5.Mensaje_Cinta_Repetida, new Exception());
                   }
             } // Fin if
             else
                {
                    throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosDaoModulo5.Codigo_Organizacion_Inexistente,
                                   RecursosDaoModulo5.Mensaje_Organizacion_Inexistente, new Exception());
                }
            } // Fin Try
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            return true;
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            FabricaEntidades laFabrica = new FabricaEntidades();
            DominioSKD.Entidades.Modulo5.Cinta laCinta;

            laCinta = (DominioSKD.Entidades.Modulo5.Cinta)laFabrica.ObtenerCinta_M5();

            laCinta.Id_cinta = parametro.Id;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
          //      Cinta laCinta = new Cinta();

                elParametro = new Parametro(RecursosDaoModulo5.ParamIdCinta, SqlDbType.Int, laCinta.Id_cinta.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDaoModulo5.ConsultarCintasXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    laCinta.Id_cinta = int.Parse(row[RecursosDaoModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosDaoModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosDaoModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosDaoModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosDaoModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosDaoModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion = new DominioSKD.Entidades.Modulo3.Organizacion(int.Parse(row[RecursosDaoModulo5.AliasIdOrganizacion].ToString())
                                                                         , row[RecursosDaoModulo5.AliasNombreOrg].ToString());


                }
                
               

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return laCinta;
        }

        public List<Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Entidad> laListaCintas = new List<Entidad>();
            List<Parametro> parametros;
            FabricaEntidades laFabrica = new FabricaEntidades();

            DominioSKD.Entidades.Modulo5.Cinta laCinta;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDaoModulo5.ConsultarTodasLasCintas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    laCinta = (DominioSKD.Entidades.Modulo5.Cinta)laFabrica.ObtenerCinta_M5();

                    laCinta.Id_cinta = int.Parse(row[RecursosDaoModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosDaoModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosDaoModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosDaoModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosDaoModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosDaoModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion(int.Parse(row[RecursosDaoModulo5.AliasIdOrganizacion].ToString())
                                                                        , row[RecursosDaoModulo5.AliasNombreOrg].ToString());
                    laListaCintas.Add(laCinta);

                }

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaCintas;
        }
        #endregion

        #region IDaoCinta
        //BuscarIDOrganizacion
        public bool ValidarOrganizacion(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
 
            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)parametro;

                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laOrganizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamSalidaNumOrganizacion, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosDaoModulo5.BuscarIDOrganiacion
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosDaoModulo5.ParamSalidaNumOrganizacion)
                        if (int.Parse(elResultado.valor) == 1)
                            retorno = true;
                        else
                        {
                            Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.Mensaje_Organizacion_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                            throw new ExcepcionesSKD.Modulo5.OrganizacionInexistenteException(RecursosDaoModulo5.Codigo_Organizacion_Inexistente,
                                RecursosDaoModulo5.Mensaje_Organizacion_Inexistente, new Exception());
                        }
                }
            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }
        //BuscarOrdenCinta
        public bool ValidarOrdenCinta(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamOrdenCinta, SqlDbType.Int
                                                      , laCinta.Orden.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamSalidaNumCinta, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosDaoModulo5.BuscarOrdenCinta
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosDaoModulo5.ParamSalidaNumCinta)
                        if (int.Parse(elResultado.valor) == 1) // Significa q el orden si esta repetido
                            retorno = true;
                        else
                        {
                            retorno = false;
                        }
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                     RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }
        //BuscarNombreCinta
        public bool ValidarNombreCinta(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)parametro;

                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDaoModulo5.ParamColorCinta, SqlDbType.VarChar
                                                      , laCinta.Color_nombre, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrgCinta, SqlDbType.Int
                                                      , laCinta.Organizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDaoModulo5.ParamSalidaNumCinta, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosDaoModulo5.BuscarNombreCinta
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosDaoModulo5.ParamSalidaNumCinta)
                        if (int.Parse(elResultado.valor) == 1) // Significa q el nombre en esa organizacion esta repetido si esta repetido
                            retorno = true;
                        else
                        {
                            retorno = false;
                        }
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                     RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }

        public List<Entidad> ListarCintasXOrganizacion(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Entidad> laListaCintas = new List<Entidad>();
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            FabricaEntidades laFabrica = new FabricaEntidades();
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion;

            laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)laFabrica.ObtenerOrganizacion_M3();

            laOrganizacion.Id_organizacion = parametro.Id;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                // Organizacion laOrganizacion = new Organizacion();

                elParametro = new Parametro(RecursosDaoModulo5.ParamIdOrg, SqlDbType.Int, laOrganizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDaoModulo5.ConsultarCintasXOrganizacionId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    DominioSKD.Entidades.Modulo5.Cinta laCinta = new DominioSKD.Entidades.Modulo5.Cinta();

                    laCinta.Id_cinta = int.Parse(row[RecursosDaoModulo5.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosDaoModulo5.AliasColorCinta].ToString();
                    laCinta.Rango = row[RecursosDaoModulo5.AliasRangoCinta].ToString();
                    laCinta.Clasificacion = row[RecursosDaoModulo5.AliasClasificacionCint].ToString();
                    laCinta.Significado = row[RecursosDaoModulo5.AliasSignificadoCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosDaoModulo5.AliasOrdenCinta].ToString());
                    laCinta.Organizacion = new DominioSKD.Entidades.Modulo3.Organizacion(int.Parse(row[RecursosDaoModulo5.AliasIdOrganizacion].ToString())
                                                                         , row[RecursosDaoModulo5.AliasNombreOrg].ToString());
                    laListaCintas.Add(laCinta);

                }

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo5.FormatoIncorrectoException(RecursosDaoModulo5.Codigo_Error_Formato,
                    RecursosDaoModulo5.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoModulo5.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaCintas;
        }

        #endregion
    }
}
