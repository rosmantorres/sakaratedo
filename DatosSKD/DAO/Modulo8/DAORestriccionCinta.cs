﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD.Entidades;
using DominioSKD.Entidades.Modulo8;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD.Modulo8;

namespace DatosSKD.DAO.Modulo8
{
    public class DAORestriccionCinta : DAOGeneral, InterfazDAO.Modulo8.IDaoRestriccionCinta
    {
        #region Metodos IDao

        #region Agregar 
        /// <summary>
        /// Metodo para agregar una restriccion de cinta a la base de datos.
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public Boolean Agregar(DominioSKD.Entidad parametro)
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccionCinta =
                (DominioSKD.Entidades.Modulo8.RestriccionCinta)parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                Parametro elParametro = new Parametro(RecursosDAORestriccionCinta.ParamDescripcionRestricionCinta, SqlDbType.VarChar,
                    laRestriccionCinta.Descripcion, false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCinta.ParamCintaNueva, SqlDbType.Int,
                        laRestriccionCinta.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCinta.ParamTiempoMinimo, SqlDbType.Int,
                        laRestriccionCinta.TiempoMinimo.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCinta.ParamHorasDocentes, SqlDbType.Int,
                        laRestriccionCinta.TiempoDocente.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro(RecursosDAORestriccionCinta.ParamPuntosMinimos, SqlDbType.Int,
                        laRestriccionCinta.PuntosMinimos.ToString(), false);
                parametros.Add(elParametro);

                BDConexion laConexion = new BDConexion();
                laConexion.EjecutarStoredProcedure(RecursosDAORestriccionCinta.AgregarRestriccionCinta, parametros);
            }

            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                     RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }
        #endregion

        #region Modificar
        public Boolean Modificar(DominioSKD.Entidad parametro)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ConsultarXId

        public DominioSKD.Entidad ConsultarXId(DominioSKD.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ConsultarTodos

            public List<DominioSKD.Entidad> ConsultarTodos()
            {
                throw new NotImplementedException();
            }     

            #endregion

        #endregion

            #region Agregar Restriccion Cinta
            /// <summary>
            /// Metodo para agregar una restriccion de cinta a la base de datos.
            /// </summary>
            /// <param name="parametro"></param>
            /// <returns></returns>
            public Boolean AgregarRestriccionCinta(DominioSKD.Entidad parametro)
            {
                
                try
                {
                    
                    DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccionCinta =
                    (DominioSKD.Entidades.Modulo8.RestriccionCinta)parametro;
                    List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                    Parametro elParametro = new Parametro(RecursosDAORestriccionCinta.ParamDescripcionRestricionCinta, SqlDbType.VarChar,
                        laRestriccionCinta.Descripcion, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamCintaNueva, SqlDbType.Int,
                            laRestriccionCinta.Id.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamTiempoMinimo, SqlDbType.Int,
                            laRestriccionCinta.TiempoMinimo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamHorasDocentes, SqlDbType.Int,
                            laRestriccionCinta.TiempoDocente.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamPuntosMinimos, SqlDbType.Int,
                            laRestriccionCinta.PuntosMinimos.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamStatus, SqlDbType.Int,
                            laRestriccionCinta.Status.ToString(), false);
                    parametros.Add(elParametro);

                    //BDConexion laConexion = new BDConexion();
                    List<Resultado> resultados = this.EjecutarStoredProcedure(RecursosDAORestriccionCinta.AgregarRestriccionCinta
                                        , parametros);
                }

                catch (SqlException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                            RecursoGeneralBD.Mensaje, ex);
                }
                catch (FormatException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                         RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw ex;
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }

                return true;
            }
            #endregion

            #region Modificar Restriccion Cinta
            /// <summary>
            /// Metodo para Modificar una restriccion de cinta existente en la base de datos.
            /// </summary>
            /// <param name="parametro"></param>
            /// <returns></returns>
            public Boolean ModificarRestriccionCinta(DominioSKD.Entidad parametro)
            {
                DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccionCinta =
                    (DominioSKD.Entidades.Modulo8.RestriccionCinta)parametro;
                try
                {
                    List<Parametro> parametros = new List<Parametro>();

                    Parametro elParametro = new Parametro(RecursosDAORestriccionCinta.ParamIdRestriccion, SqlDbType.Int,
                            laRestriccionCinta.IdRestriccionCinta.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamTiempoMinimo, SqlDbType.Int,
                            laRestriccionCinta.TiempoMinimo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamPuntosMinimos, SqlDbType.Int,
                            laRestriccionCinta.PuntosMinimos.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamHorasDocentes, SqlDbType.Int,
                            laRestriccionCinta.TiempoDocente.ToString(), false);
                    parametros.Add(elParametro);

                    //BDConexion laConexion = new BDConexion();
                    this.EjecutarStoredProcedure(RecursosDAORestriccionCinta.ModificarRestriccionCinta, parametros);

                }
                catch (SqlException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                            RecursoGeneralBD.Mensaje, ex);
                }
                catch (FormatException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                         RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw ex;
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }

                return true;
            }
            #endregion
                   
            #region Consultar todas las restricciones de cinta existentes
            /// <summary>
            /// Metodo para Consultar todas las restricciones de cinta existente en la base de datos.
            /// </summary>
            /// <returns></returns>
            public List<DominioSKD.Entidad> ConsultarCintaTodas()
            {
               // BDConexion laConexion;
                FabricaEntidades fabricaEntidad = new FabricaEntidades();
                List<DominioSKD.Entidad> ListaCinta = new List<DominioSKD.Entidad>();
                List<Parametro> parametros;

                
                 try
                 {
                     //laConexion = new BDConexion();
                     this.Conectar();
                     parametros = new List<Parametro>();
                     DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAORestriccionCinta.ConsultarCinta, parametros);

                     foreach (DataRow row in dt.Rows)
                     {
                         ListaCinta.Add(new DominioSKD.Entidades.Modulo5.Cinta(Int32.Parse(row[RecursosDAORestriccionCinta.AliasId_cinta].ToString()), row[RecursosDAORestriccionCinta.AliasColorCinta].ToString()));
                     }

                 }
                 catch (SqlException ex)
                 {
                     Console.Out.WriteLine("1" + " " + ex.Message);
                     throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                             RecursoGeneralBD.Mensaje, ex);
                 }
                 catch (FormatException ex)
                 {
                     Console.Out.WriteLine("1" + " " + ex.Message);
                     throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                          RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
                 }
                 catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                 {
                     Console.Out.WriteLine("1" + " " + ex.Message);
                     throw ex;
                 }
                 catch (Exception ex)
                 {
                     Console.Out.WriteLine("1" + " " + ex.Message);
                     throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                 }
                

                return ListaCinta;

            }

            #endregion

            #region Consultar Restricciones de CInta para Data Table

            public List<DominioSKD.Entidad> ConsultarRestriccionCintaDT()
            {

                //BDConexion laConexion;
                this.Conectar();
                List<Parametro> parametros;
                FabricaEntidades fabricaEntidad = new FabricaEntidades();
                List<DominioSKD.Entidad> ListaRestriccionCinta = new List<DominioSKD.Entidad>();
                

                try
                {
                    //laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAORestriccionCinta.ConsultarRestriccionCinta, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        ListaRestriccionCinta.Add(new DominioSKD.Entidades.Modulo8.RestriccionCinta(Int32.Parse(row[RecursosDAORestriccionCinta.AliasIdRestriccionCinta].ToString()),
                                                                                   row[RecursosDAORestriccionCinta.AliasColorCinta].ToString(),
                                                                       Int32.Parse(row[RecursosDAORestriccionCinta.AliasTiempoMinCintas].ToString()),
                                                                       Int32.Parse(row[RecursosDAORestriccionCinta.AliasPuntosMinCintas].ToString()),
                                                                       Int32.Parse(row[RecursosDAORestriccionCinta.AliasTiempoDocente].ToString()),
                                                                       Int32.Parse(row[RecursosDAORestriccionCinta.AliasStatus].ToString())));
                    }

                }
                catch (SqlException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                            RecursoGeneralBD.Mensaje, ex);
                }
                catch (FormatException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                         RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw ex;
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }


                return ListaRestriccionCinta;

            }    

        #endregion

            #region Status Restriccion Cinta
            /// <summary>
            /// Metodo para Eliminar una restriccion de cinta a la base de datos.
            /// </summary>
            /// <param name="parametro"></param>
            /// <returns></returns>
            public Boolean StatusRestriccionCinta(DominioSKD.Entidad parametro)
            {

                try
                {

                    DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccionCinta =
                    (DominioSKD.Entidades.Modulo8.RestriccionCinta)parametro;
                    List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros
                                        
                    Parametro elParametro = new Parametro(RecursosDAORestriccionCinta.ParamIdRestriccion, SqlDbType.Int,
                            laRestriccionCinta.IdRestriccionCinta.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamStatus, SqlDbType.Int,
                            laRestriccionCinta.Status.ToString(), false);
                    parametros.Add(elParametro);

                    List<Resultado> resultados = this.EjecutarStoredProcedure(RecursosDAORestriccionCinta.EliminarRestriccionCinta
                                        , parametros);
                }
                catch (SqlException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                            RecursoGeneralBD.Mensaje, ex);
                }
                catch (FormatException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                         RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw ex;
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }

                return true;
            }
            #endregion

            
        #region Agregar Restriccion Cinta Simple
            /// <summary>
            /// Metodo para agregar una restriccion de cinta a la base de datos.
            /// </summary>
            /// <param name="parametro"></param>
            /// <returns></returns>
            public Boolean AgregarRestriccionCintaSimple(DominioSKD.Entidad parametro)
            {

                try
                {

                    DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccionCinta =
                    (DominioSKD.Entidades.Modulo8.RestriccionCinta)parametro;
                    List<Parametro> parametros = new List<Parametro>(); //declaras lista de parametros

                    Parametro elParametro = new Parametro(RecursosDAORestriccionCinta.ParamDescripcionRestricionCinta, SqlDbType.VarChar,
                        laRestriccionCinta.Descripcion, false);
                    parametros.Add(elParametro);
                    
                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamTiempoMinimo, SqlDbType.Int,
                            laRestriccionCinta.TiempoMinimo.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamHorasDocentes, SqlDbType.Int,
                            laRestriccionCinta.TiempoDocente.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamPuntosMinimos, SqlDbType.Int,
                            laRestriccionCinta.PuntosMinimos.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursosDAORestriccionCinta.ParamStatus, SqlDbType.Int,
                            laRestriccionCinta.Status.ToString(), false);
                    parametros.Add(elParametro);

                    //BDConexion laConexion = new BDConexion();
                    List<Resultado> resultados = this.EjecutarStoredProcedure(RecursosDAORestriccionCinta.AgregarRestriccionCintaSimple
                                        , parametros);
                }
                catch (SqlException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                            RecursoGeneralBD.Mensaje, ex);
                }
                catch (FormatException ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.Modulo8.FormatoIncorrectoException(RecursosDAORestriccionCompetencia.Codigo_Error_Formato,
                         RecursosDAORestriccionCompetencia.Mensaje_Error_Formato, ex);
                }
                catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw ex;
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("1" + " " + ex.Message);
                    throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }

                return true;
            }
            #endregion
    }
}
