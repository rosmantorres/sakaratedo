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

namespace DatosSKD.Modulo12
{
    public class BDCompetencia
    {
        public List<Competencia> ListarCompetencias()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Competencia> laListaDeCompetencias = new List<Competencia>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo12.ConsultarCompetencias, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia laCompetencia = new Competencia();

                    laCompetencia.Id_competencia = int.Parse(row[RecursosBDModulo12.AliasIdCompetencia].ToString());
                    laCompetencia.Nombre = row[RecursosBDModulo12.AliasNombreCompetencia].ToString();
                    laCompetencia.TipoCompetencia = row[RecursosBDModulo12.AliasTipoCompetencia].ToString();

                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia1)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKata;
                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia2)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKumite;
                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia3)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaAmbos;

                    laCompetencia.Status = row[RecursosBDModulo12.AliasStatusCompetencia].ToString();
                    laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDModulo12.AliasTodasOrganizaciones].ToString());

                    if (laCompetencia.OrganizacionTodas == false)
                        laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo12.AliasIdOrganizacion].ToString())
                                                                        , row[RecursosBDModulo12.AliasNombreOrganizacion].ToString());
                    else
                    {
                        laCompetencia.Organizacion = new Organizacion(RecursosBDModulo12.TodasLasOrganizaciones);
                    }
                    laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo12.AliasIdUbicacion].ToString()),
                                                            row[RecursosBDModulo12.AliasNombreCiudad].ToString(),
                                                            row[RecursosBDModulo12.AliasNombreEstado].ToString());

                    laListaDeCompetencias.Add(laCompetencia);

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

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaDeCompetencias;

        }

        public Competencia DetallarCompetencia(int idCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Competencia laCompetencia = new Competencia();
            laCompetencia.Id_competencia = idCompetencia;
            string diaFecha;
            string mesFecha;
            string anoFecha;
            string fechaInicio;
            string fechaFin;

            try
            {
                if (BuscarIDCompetencia(laCompetencia))
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();


                    elParametro = new Parametro(RecursosBDModulo12.ParamIdCompetencia, SqlDbType.Int, idCompetencia.ToString(),
                                                false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosBDModulo12.ConsultarCompetenciasXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        laCompetencia.Id_competencia = int.Parse(row[RecursosBDModulo12.AliasIdCompetencia].ToString());
                        laCompetencia.Nombre = row[RecursosBDModulo12.AliasNombreCompetencia].ToString();
                        laCompetencia.TipoCompetencia = row[RecursosBDModulo12.AliasTipoCompetencia].ToString();

                        if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia1)
                            laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKata;
                        if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia2)
                            laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKumite;
                        if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetencia3)
                            laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaAmbos;

                        laCompetencia.Status = row[RecursosBDModulo12.AliasStatusCompetencia].ToString();
                        laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDModulo12.AliasTodasOrganizaciones].ToString());

                        diaFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Day.ToString();

                        diaFecha = ModificarFechas(diaFecha);
                       // if (int.Parse(diaFecha) < 10)
                         //   diaFecha = "0" + diaFecha.ToString();

                        mesFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Month.ToString();

                        mesFecha = ModificarFechas(mesFecha);
                        //if (int.Parse(mesFecha) < 10)
                          //  mesFecha = "0" + mesFecha.ToString();

                        anoFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Year.ToString();
                        fechaInicio = mesFecha + RecursosBDModulo12.SeparadorFecha + diaFecha + RecursosBDModulo12.SeparadorFecha + anoFecha;
                        //laCompetencia.FechaInicio = Convert.ToDateTime(fechaInicio);

                        laCompetencia.FechaInicio = DateTime.ParseExact(fechaInicio, RecursosBDModulo12.FormatoFecha,
                            CultureInfo.InvariantCulture);

                        diaFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Day.ToString();

                        diaFecha = ModificarFechas(diaFecha);
                        //if (int.Parse(diaFecha) < 10)
                          //  diaFecha = "0" + diaFecha.ToString();

                        mesFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Month.ToString();

                        mesFecha = ModificarFechas(mesFecha);
                        //if (int.Parse(mesFecha) < 10)
                          //  mesFecha = "0" + mesFecha.ToString();

                        anoFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Year.ToString();
                        fechaFin = mesFecha + RecursosBDModulo12.SeparadorFecha + diaFecha + RecursosBDModulo12.SeparadorFecha + anoFecha;
                        //laCompetencia.FechaFin = Convert.ToDateTime(fechaFin);

                        laCompetencia.FechaFin = DateTime.ParseExact(fechaFin, RecursosBDModulo12.FormatoFecha,
                            CultureInfo.InvariantCulture);

                        laCompetencia.Costo = float.Parse(row[RecursosBDModulo12.AliasCostoCompetencia].ToString());

                        if (laCompetencia.OrganizacionTodas == false)
                            laCompetencia.Organizacion = new Organizacion(int.Parse(row[RecursosBDModulo12.AliasIdOrganizacion].ToString())
                                                                            , row[RecursosBDModulo12.AliasNombreOrganizacion].ToString());
                        else
                        {
                            laCompetencia.Organizacion = new Organizacion(RecursosBDModulo12.TodasLasOrganizaciones);
                        }
                        laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosBDModulo12.AliasIdUbicacion].ToString()),
                                                                row[RecursosBDModulo12.AliasLatitudDireccion].ToString(),
                                                                row[RecursosBDModulo12.AliasLongitudDireccion].ToString(),
                                                                row[RecursosBDModulo12.AliasNombreCiudad].ToString(),
                                                                row[RecursosBDModulo12.AliasNombreEstado].ToString(),
                                                                row[RecursosBDModulo12.AliasNombreDireccion].ToString());

                        laCompetencia.Categoria = new Categoria(int.Parse(row[RecursosBDModulo12.AliasIdCategoria].ToString()),
                                                                 int.Parse(row[RecursosBDModulo12.AliasEdadInicio].ToString()),
                                                                 int.Parse(row[RecursosBDModulo12.AliasEdadFin].ToString()),
                                                                 row[RecursosBDModulo12.AliasCintaInicio].ToString(),
                                                                 row[RecursosBDModulo12.AliasCintaFin].ToString(),
                                                                 row[RecursosBDModulo12.AliasSexo].ToString());


                    }

                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    return laCompetencia;
                }
                else
                {

                    Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.Mensaje_Competencia_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo12.CompetenciaInexistenteException(RecursosBDModulo12.Codigo_Competencia_Inexistente,
                                RecursosBDModulo12.Mensaje_Competencia_Inexistente, new Exception());
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
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


        }

        public bool BuscarNombreCompetencia(Competencia laCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;
            int contador = 0;
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo12.ParamNombreCompetencia, SqlDbType.VarChar
                                                      , laCompetencia.Nombre, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo12.ParamSalidaNumCompetencia, SqlDbType.Int, true);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo12.ParamIdCompetencia, SqlDbType.Int,
                    laCompetencia.Id_competencia.ToString(),false);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDModulo12.BuscarNombreCompetencia
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDModulo12.ParamSalidaNumCompetencia)
                        if (int.Parse(elResultado.valor) == 1)
                            retorno = true;
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
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


            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }

        public bool BuscarIDCompetencia(Competencia laCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo12.ParamIdCompetencia, SqlDbType.Int
                                                      , laCompetencia.Id_competencia.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo12.ParamSalidaNumCompetencia, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDModulo12.BuscarIDCompetencia
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDModulo12.ParamSalidaNumCompetencia)
                        if (int.Parse(elResultado.valor) == 1)
                            retorno = true;
                        else
                        {
                            Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.Mensaje_Competencia_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                            throw new ExcepcionesSKD.Modulo12.CompetenciaInexistenteException(RecursosBDModulo12.Codigo_Competencia_Inexistente,
                                RecursosBDModulo12.Mensaje_Competencia_Inexistente, new Exception());
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }

        public bool AgregarCompetencia(Competencia laCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                if (!BuscarNombreCompetenciaAgregar(laCompetencia))
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosBDModulo12.ParamNombreCompetencia, SqlDbType.VarChar,
                        laCompetencia.Nombre, false);
                    parametros.Add(elParametro);

                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaKata)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetencia1;
                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaKumite)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetencia2;
                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaAmbos)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetencia3;

                    elParametro = new Parametro(RecursosBDModulo12.ParamTipoCompetencia, SqlDbType.VarChar,
                        laCompetencia.TipoCompetencia, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamOrganizacionTodas, SqlDbType.Bit,
                        laCompetencia.OrganizacionTodas.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamStatusCompetencia, SqlDbType.VarChar,
                        laCompetencia.Status, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamFechaInicio, SqlDbType.DateTime,
                        laCompetencia.FechaInicio.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamFechaFin, SqlDbType.DateTime,
                        laCompetencia.FechaFin.ToString(), false);
                    parametros.Add(elParametro);
                    if (laCompetencia.OrganizacionTodas == false)
                    {
                        elParametro = new Parametro(RecursosBDModulo12.ParamNombreOrganizacion, SqlDbType.VarChar,
                            laCompetencia.Organizacion.Nombre, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        elParametro = new Parametro(RecursosBDModulo12.ParamNombreOrganizacion, SqlDbType.VarChar,
                            "Todas", false);
                        parametros.Add(elParametro);
                    }
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreCiudad, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Ciudad, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreEstado, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Estado, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Direccion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamLatitudDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Latitud, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamLongitudDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Longitud, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamEdadInicio, SqlDbType.Int,
                        laCompetencia.Categoria.Edad_inicial.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamEdadFin, SqlDbType.Int,
                        laCompetencia.Categoria.Edad_final.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamCintaInicio, SqlDbType.VarChar,
                        laCompetencia.Categoria.Cinta_inicial, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamCintaFin, SqlDbType.VarChar,
                        laCompetencia.Categoria.Cinta_final, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamSexo, SqlDbType.Char,
                        laCompetencia.Categoria.Sexo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamCostoCompetencia, SqlDbType.Float,
                        laCompetencia.Costo.ToString(), false);
                    parametros.Add(elParametro);

                    BDConexion laConexion = new BDConexion();
                    laConexion.EjecutarStoredProcedure(RecursosBDModulo12.AgregarCompetencia, parametros);

                }
                else
                {
                    Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.Mensaje_Competencia_Existente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo12.CompetenciaExistenteException(RecursosBDModulo12.Codigo_Competencia_Existente,
                                RecursosBDModulo12.Mensaje_Competencia_Existente, new Exception());
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
                
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaExistenteException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public bool ModificarCompetencia(Competencia laCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                if (BuscarIDCompetencia(laCompetencia) && (!BuscarNombreCompetencia(laCompetencia)))
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosBDModulo12.ParamIdCompetencia, SqlDbType.Int,
                        laCompetencia.Id_competencia.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreCompetencia, SqlDbType.VarChar,
                        laCompetencia.Nombre, false);
                    parametros.Add(elParametro);

                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaKata)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetencia1;
                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaKumite)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetencia2;
                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaAmbos)
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetencia3;

                    elParametro = new Parametro(RecursosBDModulo12.ParamTipoCompetencia, SqlDbType.VarChar,
                        laCompetencia.TipoCompetencia, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamOrganizacionTodas, SqlDbType.Bit,
                        laCompetencia.OrganizacionTodas.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamStatusCompetencia, SqlDbType.VarChar,
                        laCompetencia.Status, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamFechaInicio, SqlDbType.DateTime,
                        laCompetencia.FechaInicio.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamFechaFin, SqlDbType.DateTime,
                        laCompetencia.FechaFin.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreOrganizacion, SqlDbType.VarChar,
                        laCompetencia.Organizacion.Nombre, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreCiudad, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Ciudad, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreEstado, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Estado, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Direccion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamLatitudDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Latitud, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamLongitudDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Longitud, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamEdadInicio, SqlDbType.Int,
                        laCompetencia.Categoria.Edad_inicial.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamEdadFin, SqlDbType.Int,
                        laCompetencia.Categoria.Edad_final.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamCintaInicio, SqlDbType.VarChar,
                        laCompetencia.Categoria.Cinta_inicial, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamCintaFin, SqlDbType.VarChar,
                        laCompetencia.Categoria.Cinta_final, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamSexo, SqlDbType.Char,
                        laCompetencia.Categoria.Sexo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamCostoCompetencia, SqlDbType.Float,
                        laCompetencia.Costo.ToString(), false);
                    parametros.Add(elParametro);

                    BDConexion laConexion = new BDConexion();
                    laConexion.EjecutarStoredProcedure(RecursosBDModulo12.ModificarCompetencia, parametros);
                }
                else
                {
                    Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.Mensaje_Competencia_Existente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo12.CompetenciaExistenteException(RecursosBDModulo12.Codigo_Competencia_Existente,
                                RecursosBDModulo12.Mensaje_Competencia_Existente, new Exception());
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
                
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaExistenteException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        public List<Organizacion> M12ListarOrganizaciones()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Organizacion> laListaOrganizaciones = new List<Organizacion>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo12.ConsultarOrganizaciones, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Organizacion laOrganizacion = new Organizacion();

                    laOrganizacion.Id_organizacion = int.Parse(row[RecursosBDModulo12.AliasIdOrganizacion].ToString());
                    laOrganizacion.Nombre = row[RecursosBDModulo12.AliasNombreOrganizacion].ToString();
                    
                    laListaOrganizaciones.Add(laOrganizacion);

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
                
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaOrganizaciones;
        }

        public List<Cinta> M12ListarCintas()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Cinta> laListaCintas = new List<Cinta>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo12.ConsultarCintas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Cinta laCinta = new Cinta();

                    laCinta.Id_cinta = int.Parse(row[RecursosBDModulo12.AliasIdCinta].ToString());
                    laCinta.Color_nombre = row[RecursosBDModulo12.AliasNombreCinta].ToString();
                    laCinta.Orden = int.Parse(row[RecursosBDModulo12.AliasOrdenCinta].ToString());

                    laListaCintas.Add(laCinta);

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
                
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
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


            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaCintas;
        }

        public String ModificarFechas(string fecha)
        {
            if (int.Parse(fecha) < 10)
                fecha = RecursosBDModulo12.Concatenar0 + fecha.ToString();

            return fecha;
        }

        public bool BuscarNombreCompetenciaAgregar(Competencia laCompetencia)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool retorno = false;
            BDConexion laConexion;
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosBDModulo12.ParamNombreCompetencia, SqlDbType.VarChar
                                                      , laCompetencia.Nombre, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosBDModulo12.ParamSalidaNumCompetencia, SqlDbType.Int, true);
                parametros.Add(elParametro);

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDModulo12.BuscarNombreCompetenciaAgregar
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDModulo12.ParamSalidaNumCompetencia)
                    {
                        if (int.Parse(elResultado.valor) == 1)
                            retorno = true;
                    }
                    else
                        retorno = false;
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
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo12.Codigo_Error_Formato,
                     RecursosBDModulo12.Mensaje_Error_Formato, ex);
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


            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosBDModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return retorno;


        }

    }
}
