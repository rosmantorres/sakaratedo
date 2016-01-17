using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo7
{
    /// <summary>
    /// Comando para detallar cinta de atleta
    /// </summary>
    public class ComandoConsultarDetallarCinta : Comando<Tuple<Entidad, DateTime>>
    {
        private Persona idPersona = new Persona(); //cambiar por fabrica

        public Persona IdPersona
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
        /// Implementacion de método ejecutar para comando detallar cinta de atleta
        /// </summary>
        /// <returns>Retorna entidad de cinta</returns>
        public override Tuple<Entidad, DateTime> Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            DaoCinta baseDeDatosCinta = fabrica.ObtenerDaoCintaM7();
            Tuple <Entidad, DateTime> tupla;
            DateTime fechaObtencionCinta;           
            Cinta idCinta = (Cinta)LaEntidad;
            Cinta cinta;

            try
            {
                if (idCinta.Id > 0)
                {
                    cinta =  (Cinta)baseDeDatosCinta.ConsultarXId(idCinta);
                    fechaObtencionCinta = baseDeDatosCinta.FechaCinta(idPersona, idCinta);


                    tupla = Tuple.Create((Entidad)cinta, fechaObtencionCinta);
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
            return tupla;
        }
    }
}
