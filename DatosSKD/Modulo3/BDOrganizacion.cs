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

namespace DatosSKD.Modulo3
{
    public class BDOrganizacion
    {
        //Agregar logger 
        public static bool AgregarOrganizacion(Organizacion laOrganizacion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDModulo3.ParamNombreOrg, SqlDbType.VarChar, laOrganizacion.Nombre,false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamNombreDirOrg, SqlDbType.VarChar, laOrganizacion.Direccion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamTelOrg, SqlDbType.Int, laOrganizacion.Telefono.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamEmailOrg, SqlDbType.VarChar, laOrganizacion.Email, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamEstadoOrg, SqlDbType.VarChar, laOrganizacion.Estado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamEstiloOrg, SqlDbType.VarChar,laOrganizacion.Estilo, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo3.AgregarOrganizacion
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

            }
             catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
                

            return true;
        }

        //Agregar logger 
        public static bool ModificarOrganizacion(Organizacion laOrganizacion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDModulo3.ParamIdOrg, SqlDbType.Int, laOrganizacion.Id_organizacion.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamNombreOrg, SqlDbType.VarChar, laOrganizacion.Nombre, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamNombreDirOrg, SqlDbType.VarChar, laOrganizacion.Direccion, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamTelOrg, SqlDbType.Int, laOrganizacion.Telefono.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamEmailOrg, SqlDbType.VarChar, laOrganizacion.Email, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamEstadoOrg, SqlDbType.VarChar, laOrganizacion.Estado, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo3.ParamEstiloOrg, SqlDbType.VarChar, laOrganizacion.Estilo, false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo3.ModificarOrganizacion
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }


            return true;
        }

        //Agregar logger 
        public static bool EliminarOrganizacion(int laOrganizacion)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosBDModulo3.ParamIdEliminarOrg, SqlDbType.Int, laOrganizacion.ToString(), false);
                parametros.Add(elParametro);
              
                BDConexion laConexion = new BDConexion();// abres la conexion
                laConexion.EjecutarStoredProcedure(RecursosBDModulo3.EliminarOrganizacion
                                             , parametros);//ejecutas el stored procedure que quieres pasandole la lista de parametros

            }
            catch (SqlException ex) //es mi primera excepcion, puede tener muchas
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }


            return true;
        }
        
    
        public static List<Organizacion> ListarOrganizaciones()
        {

            BDConexion laConexion;
            List<Organizacion> laListaOrganizaciones = new List<Organizacion>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo3.ConsultarOrganizacion, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Organizacion laOrganizacion = new Organizacion();

                    laOrganizacion.Id_organizacion = int.Parse(row[RecursosBDModulo3.AliasIdOrg].ToString());
                    laOrganizacion.Nombre = row[RecursosBDModulo3.AliasNombreOrg].ToString();
                    laOrganizacion.Telefono = int.Parse(row[RecursosBDModulo3.AliasTelefonoOrg].ToString());
                    laOrganizacion.Email = row[RecursosBDModulo3.AliasEmailOrg].ToString();
                    laOrganizacion.Direccion = row[RecursosBDModulo3.AliasDireccionOrg].ToString();
                    laOrganizacion.Estado = row[RecursosBDModulo3.AliasEstadoOrg].ToString();
                    laOrganizacion.Estilo = row[RecursosBDModulo3.AliasNombreEstilo].ToString();

                    laListaOrganizaciones.Add(laOrganizacion);

                }

            }
            catch (SqlException ex)
            {

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }

            return laListaOrganizaciones;
        }

        public static List<Organizacion> ComboOrganizaciones()
        {

            BDConexion laConexion;
            List<Organizacion> laListaOrganizaciones = new List<Organizacion>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo3.ConsultarComboORG, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    laListaOrganizaciones.Add(new Organizacion(Int32.Parse(row[RecursosBDModulo3.AliasIdOrg].ToString()), row[RecursosBDModulo3.AliasNombreOrg].ToString()));
                    
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
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

            return laListaOrganizaciones;
        }
  
        public static Organizacion ConsultarOrganizacionXId(int idOrganizacion)
        {
           BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Organizacion laOrganizacion = new Organizacion();

                elParametro = new Parametro(RecursosBDModulo3.AliasIdOrg,SqlDbType.Int,idOrganizacion.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo3.ConsultarOrganizacionXId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    

                    laOrganizacion.Id_organizacion = int.Parse(row[RecursosBDModulo3.AliasIdOrg].ToString());
                    laOrganizacion.Nombre = row[RecursosBDModulo3.AliasNombreOrg].ToString();
                    laOrganizacion.Direccion = row[RecursosBDModulo3.AliasDireccionOrg].ToString();
                    laOrganizacion.Telefono = int.Parse(row[RecursosBDModulo3.AliasTelefonoOrg].ToString());
                    laOrganizacion.Email= row[RecursosBDModulo3.AliasEmailOrg].ToString();
                    laOrganizacion.Estado = row[RecursosBDModulo3.AliasEstadoOrg].ToString();
                    laOrganizacion.Estilo = row[RecursosBDModulo3.AliasNombreEstilo].ToString();
                    
                }
                return laOrganizacion;



            }
            catch (Exception e)
            {
                throw e;
            }

           
        }
       
        
        
        }





    }

