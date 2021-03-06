﻿using DatosSKD.InterfazDAO.Modulo4;
using DominioSKD;
using DominioSKD.Entidades.Modulo4;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.DAO.Modulo4
{
    public class DaoHistorialM : DAOGeneral, IDaoHistorialM
    {
        #region IDAO
        public bool Agregar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HistorialM elHistMat = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
                elHistMat = (HistorialM)parametro;

                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDAOModulo4.ParametroFechaVigenteHistorial, SqlDbType.DateTime,
                    elHistMat.Fecha_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAOModulo4.ParametroModalidad, SqlDbType.VarChar,
                    elHistMat.Modalidad_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAOModulo4.ParametroMontoMatricula, SqlDbType.Float,
                    elHistMat.Monto_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAOModulo4.ParamIdDojo, SqlDbType.Int,
                    elHistMat.Id_historial_matricula.ToString(), false);
                parametros.Add(elParametro);


                BDConexion laConexion = new BDConexion();
                laConexion.EjecutarStoredProcedure(RecursosDAOModulo4.AgregarHistorialMatricula, parametros);
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;


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

                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.HistorialMatriculaExistenteException ex)
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return false;
        }

        public bool Modificar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HistorialM elHistMat = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
                elHistMat = (HistorialM)parametro;


                List<Parametro> parametros = new List<Parametro>();

                Parametro elParametro = new Parametro(RecursosDAOModulo4.ParamIdMatricula, SqlDbType.Int,
                    elHistMat.Id_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAOModulo4.ParametroFechaVigenteHistorial, SqlDbType.DateTime,
                    elHistMat.Fecha_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAOModulo4.ParametroModalidad, SqlDbType.VarChar,
                    elHistMat.Modalidad_historial_matricula.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAOModulo4.ParametroMontoMatricula, SqlDbType.Float,
                    elHistMat.Monto_historial_matricula.ToString(), false);
                parametros.Add(elParametro);


                BDConexion laConexion = new BDConexion();
                laConexion.EjecutarStoredProcedure(RecursosDAOModulo4.ModificarHistorialMatricula, parametros);
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;


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

                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.HistorialMatriculaInexistenteException ex)
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


            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return false;
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            HistorialM elHistMat = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
            elHistMat = (HistorialM)parametro;

            try
            {

                laConexion = new BDConexion();



                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosDAOModulo4.ParamIdMatricula, SqlDbType.VarChar,
                    elHistMat.Id.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDAOModulo4.ConsultarMatriculasXId, parametros);

                foreach (DataRow row in dt.Rows)
                {


                    elHistMat.Id = int.Parse(row[RecursosDAOModulo4.AliasIdMatricula].ToString());
                    elHistMat.Fecha_historial_matricula = DateTime.Parse(row[RecursosDAOModulo4.AliasFechaMatricula].ToString());
                    elHistMat.Modalidad_historial_matricula = row[RecursosDAOModulo4.AliasModalidad].ToString();
                    elHistMat.Monto_historial_matricula = int.Parse(row[RecursosDAOModulo4.AliasMonto].ToString());


                }



            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.DojoInexistenteException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return elHistMat;
        }

        public List<Entidad> ConsultarTodos()
        {
            BDConexion laConexion;
            List<Entidad> laListaDeMatriculas = FabricaEntidades.ObtenerListaEntidad_M4();
            List<Parametro> parametros;

            

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosDAOModulo4.ConsultarMatriculas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    DojoM4 elDojo = (DojoM4)FabricaEntidades.ObtenerDojo_M4();
                    HistorialM elHistMat = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();

                    elHistMat.Id_historial_matricula = int.Parse(row[RecursosDAOModulo4.AliasIdMatricula].ToString());
                    elHistMat.Fecha_historial_matricula = DateTime.Parse(row[RecursosDAOModulo4.AliasFechaMatricula].ToString());
                    elHistMat.Modalidad_historial_matricula = row[RecursosDAOModulo4.AliasModalidad].ToString();
                    elHistMat.Monto_historial_matricula = int.Parse(row[RecursosDAOModulo4.AliasMonto].ToString());
                    elDojo.Id = int.Parse(row[RecursosDAOModulo4.AliasIdDojo].ToString());
                    elDojo.Nombre_dojo = row[RecursosDAOModulo4.AliasNombreDojo].ToString();
                    elHistMat.Dojo_historial_matricula = elDojo;

                    laListaDeMatriculas.Add(elHistMat);

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

                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.HistorialMatriculaInexistenteException ex)
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return laListaDeMatriculas;
        }

        public bool Eliminar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();


            try
            {
                HistorialM elHistMat = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
                elHistMat = (HistorialM)parametro;

                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                elParametro = new Parametro(RecursosDAOModulo4.ParamIdMatricula, SqlDbType.VarChar,
                   elHistMat.Id.ToString(), false);
                parametros.Add(elParametro);

                laConexion.EjecutarStoredProcedure(RecursosDAOModulo4.EliminarHMatricula, parametros);

                return true;

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

                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.HistorialMatriculaInexistenteException ex)
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            return false;
        }

        public List<Entidad> ConsultarTodosDojo(Entidad parametro)
        {
            BDConexion laConexion;
            List<Entidad> laListaDeMatriculas = FabricaEntidades.ObtenerListaEntidad_M4();
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                HistorialM elHistMat = (HistorialM)FabricaEntidades.ObtenerHistorialMatricula();
                elHistMat = (HistorialM)parametro;

                elParametro = new Parametro(RecursosDAOModulo4.ParamIdDojo, SqlDbType.Int, elHistMat.Dojo_historial_matricula.Id.ToString(),
                                              false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                           RecursosDAOModulo4.ConsultarMatriculasXDojo, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    elHistMat.Id = int.Parse(row[RecursosDAOModulo4.AliasIdMatricula].ToString());
                    elHistMat.Fecha_historial_matricula = DateTime.Parse(row[RecursosDAOModulo4.AliasFechaMatricula].ToString());
                    elHistMat.Modalidad_historial_matricula = row[RecursosDAOModulo4.AliasModalidad].ToString();
                    elHistMat.Monto_historial_matricula = int.Parse(row[RecursosDAOModulo4.AliasMonto].ToString());
                    laListaDeMatriculas.Add(elHistMat);

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

                throw new ExcepcionesSKD.Modulo4.FormatoIncorrectoException(RecursosDAOModulo4.Codigo_Error_Formato,
                     RecursosDAOModulo4.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.Modulo4.HistorialMatriculaInexistenteException ex)
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

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDAOModulo4.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            return laListaDeMatriculas;
        }
        #endregion
    }
}
