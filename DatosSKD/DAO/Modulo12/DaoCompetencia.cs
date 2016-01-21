using DatosSKD.DAO;
using DatosSKD.InterfazDAO;
using DatosSKD.InterfazDAO.Modulo12;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo12;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo12
{
    public class DaoCompetencia : DAOGeneral, IDaoCompetencia
    {

        #region IDAO
            public bool Agregar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                DominioSKD.Entidades.Modulo12.Competencia laCompetencia = (DominioSKD.Entidades.Modulo12.Competencia)parametro;

                if (!BuscarNombreCompetenciaAgregar(laCompetencia))
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosDAOModulo12.ParamNombreCompetencia, SqlDbType.VarChar,
                        laCompetencia.Nombre, false);
                    parametros.Add(elParametro);

                    if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetenciaKata)
                        laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetencia1;
                    if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetenciaKumite)
                        laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetencia2;
                    if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetenciaAmbos)
                        laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetencia3;

                    elParametro = new Parametro(RecursosDAOModulo12.ParamTipoCompetencia, SqlDbType.VarChar,
                        laCompetencia.TipoCompetencia, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamOrganizacionTodas, SqlDbType.Bit,
                        laCompetencia.OrganizacionTodas.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamStatusCompetencia, SqlDbType.VarChar,
                        laCompetencia.Status, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamFechaInicio, SqlDbType.DateTime,
                        laCompetencia.FechaInicio.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamFechaFin, SqlDbType.DateTime,
                        laCompetencia.FechaFin.ToString(), false);
                    parametros.Add(elParametro);
                    if (laCompetencia.OrganizacionTodas == false)
                    {
                        elParametro = new Parametro(RecursosDAOModulo12.ParamNombreOrganizacion, SqlDbType.VarChar,
                            laCompetencia.Organizacion.Nombre, false);
                        parametros.Add(elParametro);
                    }
                    else
                    {
                        elParametro = new Parametro(RecursosDAOModulo12.ParamNombreOrganizacion, SqlDbType.VarChar,
                            "Todas", false);
                        parametros.Add(elParametro);
                    }
                    elParametro = new Parametro(RecursosDAOModulo12.ParamNombreCiudad, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Ciudad, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamNombreEstado, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Estado, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamNombreDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Direccion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamLatitudDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Latitud, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamLongitudDireccion, SqlDbType.VarChar,
                        laCompetencia.Ubicacion.Longitud, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamEdadInicio, SqlDbType.Int,
                        laCompetencia.Categoria.Edad_inicial.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamEdadFin, SqlDbType.Int,
                        laCompetencia.Categoria.Edad_final.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamCintaInicio, SqlDbType.VarChar,
                        laCompetencia.Categoria.Cinta_inicial, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamCintaFin, SqlDbType.VarChar,
                        laCompetencia.Categoria.Cinta_final, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamSexo, SqlDbType.Char,
                        laCompetencia.Categoria.Sexo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosDAOModulo12.ParamCostoCompetencia, SqlDbType.Float,
                        laCompetencia.Costo.ToString(), false);
                    parametros.Add(elParametro);

                    BDConexion laConexion = new BDConexion();
                    laConexion.EjecutarStoredProcedure(RecursosDAOModulo12.AgregarCompetencia, parametros);

                }
                else
                {
                    Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.Mensaje_Competencia_Existente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    throw new ExcepcionesSKD.Modulo12.CompetenciaExistenteException(RecursosDAOModulo12.Codigo_Competencia_Existente,
                                RecursosDAOModulo12.Mensaje_Competencia_Existente, new Exception());
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

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                     RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }

            public bool Modificar(Entidad parametro)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                try
                {
                    DominioSKD.Entidades.Modulo12.Competencia laCompetencia = (DominioSKD.Entidades.Modulo12.Competencia)parametro;

                    if (BuscarIDCompetencia(laCompetencia) && (!BuscarNombreCompetencia(laCompetencia)))
                    {
                        List<Parametro> parametros = new List<Parametro>();
                        Parametro elParametro = new Parametro(RecursosDAOModulo12.ParamIdCompetencia, SqlDbType.Int,
                            laCompetencia.Id.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamNombreCompetencia, SqlDbType.VarChar,
                            laCompetencia.Nombre, false);
                        parametros.Add(elParametro);

                        if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetenciaKata)
                            laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetencia1;
                        if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetenciaKumite)
                            laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetencia2;
                        if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetenciaAmbos)
                            laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetencia3;

                        elParametro = new Parametro(RecursosDAOModulo12.ParamTipoCompetencia, SqlDbType.VarChar,
                            laCompetencia.TipoCompetencia, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamOrganizacionTodas, SqlDbType.Bit,
                            laCompetencia.OrganizacionTodas.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamStatusCompetencia, SqlDbType.VarChar,
                            laCompetencia.Status, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamFechaInicio, SqlDbType.DateTime,
                            laCompetencia.FechaInicio.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamFechaFin, SqlDbType.DateTime,
                            laCompetencia.FechaFin.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamNombreOrganizacion, SqlDbType.VarChar,
                            laCompetencia.Organizacion.Nombre, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamNombreCiudad, SqlDbType.VarChar,
                            laCompetencia.Ubicacion.Ciudad, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamNombreEstado, SqlDbType.VarChar,
                            laCompetencia.Ubicacion.Estado, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamNombreDireccion, SqlDbType.VarChar,
                            laCompetencia.Ubicacion.Direccion, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamLatitudDireccion, SqlDbType.VarChar,
                            laCompetencia.Ubicacion.Latitud, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamLongitudDireccion, SqlDbType.VarChar,
                            laCompetencia.Ubicacion.Longitud, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamEdadInicio, SqlDbType.Int,
                            laCompetencia.Categoria.Edad_inicial.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamEdadFin, SqlDbType.Int,
                            laCompetencia.Categoria.Edad_final.ToString(), false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamCintaInicio, SqlDbType.VarChar,
                            laCompetencia.Categoria.Cinta_inicial, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamCintaFin, SqlDbType.VarChar,
                            laCompetencia.Categoria.Cinta_final, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamSexo, SqlDbType.Char,
                            laCompetencia.Categoria.Sexo, false);
                        parametros.Add(elParametro);
                        elParametro = new Parametro(RecursosDAOModulo12.ParamCostoCompetencia, SqlDbType.Float,
                            laCompetencia.Costo.ToString(), false);
                        parametros.Add(elParametro);

                        BDConexion laConexion = new BDConexion();
                        laConexion.EjecutarStoredProcedure(RecursosDAOModulo12.ModificarCompetencia, parametros);
                    }
                    else
                    {
                        Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.Mensaje_Competencia_Existente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                        throw new ExcepcionesSKD.Modulo12.CompetenciaExistenteException(RecursosDAOModulo12.Codigo_Competencia_Existente,
                                    RecursosDAOModulo12.Mensaje_Competencia_Existente, new Exception());
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

                    throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                         RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;
            }

            public Entidad ConsultarXId(Entidad parametro)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                BDConexion laConexion;
                List<Parametro> parametros;
                Parametro elParametro = new Parametro();

                FabricaEntidades laFabrica = new FabricaEntidades();

                //Competencia laCompetencia = new Competencia();
                DominioSKD.Entidades.Modulo12.Competencia laCompetencia;

                laCompetencia = (DominioSKD.Entidades.Modulo12.Competencia)laFabrica.ObtenerCompetencia();
                //PREGUNTAR POR EL ID
                laCompetencia.Id = parametro.Id;
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


                        elParametro = new Parametro(RecursosDAOModulo12.ParamIdCompetencia, SqlDbType.Int, laCompetencia.Id.ToString(),
                                                    false);
                        parametros.Add(elParametro);

                        DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                       RecursosDAOModulo12.ConsultarCompetenciasXId, parametros);

                        foreach (DataRow row in dt.Rows)
                        {
                            laCompetencia.Id = int.Parse(row[RecursosDAOModulo12.AliasIdCompetencia].ToString());
                            laCompetencia.Nombre = row[RecursosDAOModulo12.AliasNombreCompetencia].ToString();
                            laCompetencia.TipoCompetencia = row[RecursosDAOModulo12.AliasTipoCompetencia].ToString();

                            if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetencia1)
                                laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetenciaKata;
                            if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetencia2)
                                laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetenciaKumite;
                            if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetencia3)
                                laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetenciaAmbos;

                            laCompetencia.Status = row[RecursosDAOModulo12.AliasStatusCompetencia].ToString();
                            laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosDAOModulo12.AliasTodasOrganizaciones].ToString());

                            diaFecha = Convert.ToDateTime(row[RecursosDAOModulo12.AliasFechaInicio]).Day.ToString();

                            diaFecha = ModificarFechas(diaFecha);
                            // if (int.Parse(diaFecha) < 10)
                            //   diaFecha = "0" + diaFecha.ToString();

                            mesFecha = Convert.ToDateTime(row[RecursosDAOModulo12.AliasFechaInicio]).Month.ToString();

                            mesFecha = ModificarFechas(mesFecha);
                            //if (int.Parse(mesFecha) < 10)
                            //  mesFecha = "0" + mesFecha.ToString();

                            anoFecha = Convert.ToDateTime(row[RecursosDAOModulo12.AliasFechaInicio]).Year.ToString();
                            fechaInicio = mesFecha + RecursosDAOModulo12.SeparadorFecha + diaFecha + RecursosDAOModulo12.SeparadorFecha + anoFecha;
                            //laCompetencia.FechaInicio = Convert.ToDateTime(fechaInicio);

                            laCompetencia.FechaInicio = DateTime.ParseExact(fechaInicio, RecursosDAOModulo12.FormatoFecha,
                                CultureInfo.InvariantCulture);

                            diaFecha = Convert.ToDateTime(row[RecursosDAOModulo12.AliasFechaFin]).Day.ToString();

                            diaFecha = ModificarFechas(diaFecha);
                            //if (int.Parse(diaFecha) < 10)
                            //  diaFecha = "0" + diaFecha.ToString();

                            mesFecha = Convert.ToDateTime(row[RecursosDAOModulo12.AliasFechaFin]).Month.ToString();

                            mesFecha = ModificarFechas(mesFecha);
                            //if (int.Parse(mesFecha) < 10)
                            //  mesFecha = "0" + mesFecha.ToString();

                            anoFecha = Convert.ToDateTime(row[RecursosDAOModulo12.AliasFechaFin]).Year.ToString();
                            fechaFin = mesFecha + RecursosDAOModulo12.SeparadorFecha + diaFecha + RecursosDAOModulo12.SeparadorFecha + anoFecha;
                            //laCompetencia.FechaFin = Convert.ToDateTime(fechaFin);

                            laCompetencia.FechaFin = DateTime.ParseExact(fechaFin, RecursosDAOModulo12.FormatoFecha,
                                CultureInfo.InvariantCulture);

                            laCompetencia.Costo = float.Parse(row[RecursosDAOModulo12.AliasCostoCompetencia].ToString());

                            //PREGUNTAR!
                            if (laCompetencia.OrganizacionTodas == false)

                                laCompetencia.Organizacion = (Organizacion)laFabrica.ObtenerOrganizacion(int.Parse(row[RecursosDAOModulo12.AliasIdOrganizacion].ToString())
                                                                                , row[RecursosDAOModulo12.AliasNombreOrganizacion].ToString());
                            else
                            {

                                laCompetencia.Organizacion = (Organizacion)laFabrica.ObtenerOrganizacion(RecursosDAOModulo12.TodasLasOrganizaciones);
                            }

                            //PREGUNTAR!
                            laCompetencia.Ubicacion = (DominioSKD.Entidades.Modulo12.Ubicacion)laFabrica.ObtenerUbicacion(int.Parse(row[RecursosDAOModulo12.AliasIdUbicacion].ToString()),
                                                                    row[RecursosDAOModulo12.AliasLatitudDireccion].ToString(),
                                                                    row[RecursosDAOModulo12.AliasLongitudDireccion].ToString(),
                                                                    row[RecursosDAOModulo12.AliasNombreCiudad].ToString(),
                                                                    row[RecursosDAOModulo12.AliasNombreEstado].ToString(),
                                                                    row[RecursosDAOModulo12.AliasNombreDireccion].ToString());
                            //PREGUNTAR!
                            laCompetencia.Categoria = (DominioSKD.Entidades.Modulo12.Categoria)laFabrica.ObtenerCategoria(int.Parse(row[RecursosDAOModulo12.AliasIdCategoria].ToString()),
                                                                     int.Parse(row[RecursosDAOModulo12.AliasEdadInicio].ToString()),
                                                                     int.Parse(row[RecursosDAOModulo12.AliasEdadFin].ToString()),
                                                                     row[RecursosDAOModulo12.AliasCintaInicio].ToString(),
                                                                     row[RecursosDAOModulo12.AliasCintaFin].ToString(),
                                                                     row[RecursosDAOModulo12.AliasSexo].ToString());



                            //laCompetencia.Ubicacion = new Ubicacion(int.Parse(row[RecursosDAOModulo12.AliasIdUbicacion].ToString()),
                            //                                        row[RecursosDAOModulo12.AliasLatitudDireccion].ToString(),
                            //                                        row[RecursosDAOModulo12.AliasLongitudDireccion].ToString(),
                            //                                        row[RecursosDAOModulo12.AliasNombreCiudad].ToString(),
                            //                                        row[RecursosDAOModulo12.AliasNombreEstado].ToString(),
                            //                                        row[RecursosDAOModulo12.AliasNombreDireccion].ToString());

                            //laCompetencia.Categoria = new Categoria(int.Parse(row[RecursosDAOModulo12.AliasIdCategoria].ToString()),
                            //                                         int.Parse(row[RecursosDAOModulo12.AliasEdadInicio].ToString()),
                            //                                         int.Parse(row[RecursosDAOModulo12.AliasEdadFin].ToString()),
                            //                                         row[RecursosDAOModulo12.AliasCintaInicio].ToString(),
                            //                                         row[RecursosDAOModulo12.AliasCintaFin].ToString(),
                            //                                         row[RecursosDAOModulo12.AliasSexo].ToString());


                        }

                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                        return laCompetencia;
                    }
                    else
                    {

                        Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.Mensaje_Competencia_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                        throw new ExcepcionesSKD.Modulo12.CompetenciaInexistenteException(RecursosDAOModulo12.Codigo_Competencia_Inexistente,
                                    RecursosDAOModulo12.Mensaje_Competencia_Inexistente, new Exception());
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
                    throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                         RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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

            public List<Entidad> ConsultarTodos()
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                BDConexion laConexion;
                //List<Competencia> laListaDeCompetencias = new List<Competencia>();
                List<Entidad> laListaDeCompetencias = new List<Entidad>();
                FabricaEntidades laFabrica = new FabricaEntidades();

                DominioSKD.Entidades.Modulo12.Competencia laCompetencia;

                List<Parametro> parametros;

                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo12.ConsultarCompetencias, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        laCompetencia = (DominioSKD.Entidades.Modulo12.Competencia)laFabrica.ObtenerCompetencia();

                        laCompetencia.Id = int.Parse(row[RecursosDAOModulo12.AliasIdCompetencia].ToString());
                        laCompetencia.Nombre = row[RecursosDAOModulo12.AliasNombreCompetencia].ToString();
                        laCompetencia.TipoCompetencia = row[RecursosDAOModulo12.AliasTipoCompetencia].ToString();

                        if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetencia1)
                            laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetenciaKata;
                        if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetencia2)
                            laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetenciaKumite;
                        if (laCompetencia.TipoCompetencia == RecursosDAOModulo12.TipoCompetencia3)
                            laCompetencia.TipoCompetencia = RecursosDAOModulo12.TipoCompetenciaAmbos;

                        laCompetencia.Status = row[RecursosDAOModulo12.AliasStatusCompetencia].ToString();
                        laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosDAOModulo12.AliasTodasOrganizaciones].ToString());

                        //PREGUNTAR!
                        if (laCompetencia.OrganizacionTodas == false)

                            laCompetencia.Organizacion = (Organizacion)laFabrica.ObtenerOrganizacion(int.Parse(row[RecursosDAOModulo12.AliasIdOrganizacion].ToString())
                                                                            , row[RecursosDAOModulo12.AliasNombreOrganizacion].ToString());
                        else
                        {

                            laCompetencia.Organizacion = (Organizacion)laFabrica.ObtenerOrganizacion(RecursosDAOModulo12.TodasLasOrganizaciones);
                        }

                        //PREGUNTAR!
                        laCompetencia.Ubicacion = (DominioSKD.Entidades.Modulo12.Ubicacion)laFabrica.ObtenerUbicacion(int.Parse(row[RecursosDAOModulo12.AliasIdUbicacion].ToString()),
                                                                row[RecursosDAOModulo12.AliasNombreCiudad].ToString(),
                                                                row[RecursosDAOModulo12.AliasNombreEstado].ToString());
                                                                

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

                    throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                         RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return laListaDeCompetencias;

            }

        #endregion

        #region IDaoCompetencia
            public bool BuscarNombreCompetencia(Entidad parametro)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                bool retorno = false;
                BDConexion laConexion;
                List<Parametro> parametros;
                int contador = 0;
                try
                {
                    DominioSKD.Entidades.Modulo12.Competencia laCompetencia = (DominioSKD.Entidades.Modulo12.Competencia)parametro;

                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    Parametro elParametro = new Parametro(RecursosDAOModulo12.ParamNombreCompetencia, SqlDbType.VarChar
                                                          , laCompetencia.Nombre, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo12.ParamSalidaNumCompetencia, SqlDbType.Int, true);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo12.ParamIdCompetencia, SqlDbType.Int,
                        laCompetencia.Id.ToString(), false);
                    parametros.Add(elParametro);

                    List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosDAOModulo12.BuscarNombreCompetencia
                                                 , parametros);

                    foreach (Resultado elResultado in resultados)
                    {
                        if (elResultado.etiqueta == RecursosDAOModulo12.ParamSalidaNumCompetencia)
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
                    throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                         RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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


                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return retorno;


            }

            public bool BuscarIDCompetencia(Entidad parametro)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                bool retorno = false;
                BDConexion laConexion;
                List<Parametro> parametros;

                try
                {
                    DominioSKD.Entidades.Modulo12.Competencia laCompetencia = (DominioSKD.Entidades.Modulo12.Competencia)parametro;
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    Parametro elParametro = new Parametro(RecursosDAOModulo12.ParamIdCompetencia, SqlDbType.Int
                                                          , laCompetencia.Id.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo12.ParamSalidaNumCompetencia, SqlDbType.Int, true);
                    parametros.Add(elParametro);

                    List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosDAOModulo12.BuscarIDCompetencia
                                                 , parametros);

                    foreach (Resultado elResultado in resultados)
                    {
                        if (elResultado.etiqueta == RecursosDAOModulo12.ParamSalidaNumCompetencia)
                            if (int.Parse(elResultado.valor) == 1)
                                retorno = true;
                            else
                            {
                                Logger.EscribirWarning(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.Mensaje_Competencia_Inexistente, System.Reflection.MethodBase.GetCurrentMethod().Name);

                                throw new ExcepcionesSKD.Modulo12.CompetenciaInexistenteException(RecursosDAOModulo12.Codigo_Competencia_Inexistente,
                                    RecursosDAOModulo12.Mensaje_Competencia_Inexistente, new Exception());
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
                    throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                         RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return retorno;


            }

            public List<Entidad> M12ListarOrganizaciones()
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


                BDConexion laConexion;
                List<Parametro> parametros;

                FabricaEntidades laFabrica = new FabricaEntidades();
                List<Entidad> laListaOrganizaciones = new List<Entidad>();
                Organizacion laOrganizacion;


                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();


                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo12.ConsultarOrganizaciones, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        laOrganizacion = (Organizacion)laFabrica.ObtenerOrganizacion();

                        laOrganizacion.Id_organizacion = int.Parse(row[RecursosDAOModulo12.AliasIdOrganizacion].ToString());
                        laOrganizacion.Nombre = row[RecursosDAOModulo12.AliasNombreOrganizacion].ToString();

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

                    throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                         RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return laListaOrganizaciones;
            }

            public List<Entidad> M12ListarCintas()
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                BDConexion laConexion;
                List<Entidad> laListaCintas = new List<Entidad>();
                FabricaEntidades laFabrica = new FabricaEntidades();
                List<Parametro> parametros;
                Cinta laCinta;

                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();


                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo12.ConsultarCintas, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        laCinta = (Cinta)laFabrica.ObtenerCinta();

                        laCinta.Id_cinta = int.Parse(row[RecursosDAOModulo12.AliasIdCinta].ToString());
                        laCinta.Color_nombre = row[RecursosDAOModulo12.AliasNombreCinta].ToString();
                        laCinta.Orden = int.Parse(row[RecursosDAOModulo12.AliasOrdenCinta].ToString());

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

                    throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                         RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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


                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return laListaCintas;
            }

            public string ModificarFechas(string fecha)
            {
                if (int.Parse(fecha) < 10)
                    fecha = RecursosDAOModulo12.Concatenar0 + fecha.ToString();

                return fecha;
            }

            public bool BuscarNombreCompetenciaAgregar(Entidad parametro)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                bool retorno = false;
                BDConexion laConexion;
                List<Parametro> parametros;

                try
                {
                    DominioSKD.Entidades.Modulo12.Competencia laCompetencia = (DominioSKD.Entidades.Modulo12.Competencia)parametro;

                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    Parametro elParametro = new Parametro(RecursosDAOModulo12.ParamNombreCompetencia, SqlDbType.VarChar
                                                          , laCompetencia.Nombre, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAOModulo12.ParamSalidaNumCompetencia, SqlDbType.Int, true);
                    parametros.Add(elParametro);

                    List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosDAOModulo12.BuscarNombreCompetenciaAgregar
                                                 , parametros);

                    foreach (Resultado elResultado in resultados)
                    {
                        if (elResultado.etiqueta == RecursosDAOModulo12.ParamSalidaNumCompetencia)
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
                    throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDAOModulo12.Codigo_Error_Formato,
                         RecursosDAOModulo12.Mensaje_Error_Formato, ex);
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


                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo12.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return retorno;
            }
        #endregion
   
    }
}
