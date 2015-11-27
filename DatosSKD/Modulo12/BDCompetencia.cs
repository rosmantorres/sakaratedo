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

namespace DatosSKD.Modulo12
{
    public class BDCompetencia
    {

        public static List<Competencia> ListarCompetencias()
        {
            BDConexion laConexion;
            List<Competencia> laListaDeCompetencias = new List<Competencia>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo12.ConsultarCompetencias, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Competencia laCompetencia = new Competencia();

                    laCompetencia.Id_competencia = int.Parse(row[RecursosBDModulo12.AliasIdCompetencia].ToString());
                    laCompetencia.Nombre = row[RecursosBDModulo12.AliasNombreCompetencia].ToString();
                    laCompetencia.TipoCompetencia = row[RecursosBDModulo12.AliasTipoCompetencia].ToString();

                    if (laCompetencia.TipoCompetencia == "1")
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKata;
                    else
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKumite;

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
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }

            return laListaDeCompetencias;

        }

        public static Competencia DetallarCompetencia(int idCompetencia)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            int diaFecha;
            int mesFecha;
            int anoFecha;
            string fechaInicio;
            string fechaFin;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Competencia laCompetencia = new Competencia();

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

                    if (laCompetencia.TipoCompetencia == "1")
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKata;
                    else
                        laCompetencia.TipoCompetencia = RecursosBDModulo12.TipoCompetenciaKumite;

                    laCompetencia.Status = row[RecursosBDModulo12.AliasStatusCompetencia].ToString();
                    laCompetencia.OrganizacionTodas = Convert.ToBoolean(row[RecursosBDModulo12.AliasTodasOrganizaciones].ToString());
                    
                    diaFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Day;
                    mesFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Month;
                    anoFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaInicio]).Year;
                    fechaInicio = mesFecha.ToString() + "/" + diaFecha.ToString() + "/" + anoFecha.ToString();
                    laCompetencia.FechaInicio = Convert.ToDateTime(fechaInicio);
                   
                    diaFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Day;
                    mesFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Month;
                    anoFecha = Convert.ToDateTime(row[RecursosBDModulo12.AliasFechaFin]).Year;
                    fechaFin = mesFecha.ToString() + "/" + diaFecha.ToString() + "/" + anoFecha.ToString();
                    laCompetencia.FechaFin = Convert.ToDateTime(fechaFin);
                    
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
                return laCompetencia;



            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }


        }

        public static bool BuscarNombreCompetencia(Competencia laCompetencia)
        {
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

                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursosBDModulo12.BuscarNombreCompetencia
                                             , parametros);

                foreach (Resultado elResultado in resultados)
                {
                    if (elResultado.etiqueta == RecursosBDModulo12.ParamSalidaNumCompetencia)
                        if (int.Parse(elResultado.valor) == 1)
                            retorno = true;
                        else
                            retorno = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;


        }

        public static bool AgregarCompetencia(Competencia laCompetencia)
        {
            try
            {
                if (!BuscarNombreCompetencia(laCompetencia))
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosBDModulo12.ParamNombreCompetencia, SqlDbType.VarChar,
                        laCompetencia.Nombre, false);
                    parametros.Add(elParametro);

                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaKata)
                        laCompetencia.TipoCompetencia = "1";
                    else
                        if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaKumite)
                            laCompetencia.TipoCompetencia = "2";

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
                    laConexion.EjecutarStoredProcedure(RecursosBDModulo12.AgregarCompetencia, parametros);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool ModificarCompetencia(Competencia laCompetencia)
        {
            try
            {
                if (!BuscarNombreCompetencia(laCompetencia))
                {
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursosBDModulo12.ParamIdCompetencia, SqlDbType.Int,
                        laCompetencia.Id_competencia.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursosBDModulo12.ParamNombreCompetencia, SqlDbType.VarChar,
                        laCompetencia.Nombre, false);
                    parametros.Add(elParametro);
                    if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaKata)
                        laCompetencia.TipoCompetencia = "1";
                    else
                        if (laCompetencia.TipoCompetencia == RecursosBDModulo12.TipoCompetenciaKumite)
                            laCompetencia.TipoCompetencia = "2";

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
