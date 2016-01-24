﻿using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo7;
using DominioSKD.Fabrica;

namespace LogicaNegociosSKD.Comandos.Modulo7
{
    public class ComandoConsultarDetallarMatricula : Comando<Entidad>
    {
        
        private PersonaM7 idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7(); //cambiar por fabrica

        public PersonaM7 IdPersona
        {
            get
            {
                return this.idPersona;
            }
            set
            {
                this.idPersona = value;
            }
        }
    /// <summary>
    /// Implementación del metodo abstracto Ejecutar de la clase comando
    /// </summary>
    /// <returns>Retorna objeto de tipo Entidad con la informacion de la matricula</returns>
    
        public override Entidad Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoMatricula baseDeDatosMatricula = fabrica.ObtenerDaoMatriculaM7();
            MatriculaM7 idMatricula = (MatriculaM7)LaEntidad;
            MatriculaM7 matricula;

            try
            {
                if (idMatricula.Id > 0)
                {
                    matricula = (MatriculaM7)baseDeDatosMatricula.ConsultarXId(idMatricula);
                }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            return matricula;
        }
    }
}
