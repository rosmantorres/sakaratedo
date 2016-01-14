using DatosSKD.DAO.Modulo7;
using DatosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo7
{
    public class ComandoConsultarPerfil : Comando<Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad>>
    {
        /// <summary>
        /// Implementación del metodo abstracto Ejecutar de la clase comando
        /// </summary>
        /// <returns>Retorta tupla con persona, dojo, ubicacion dojo, organizacion, ubicacion organziacion y ultima cinta </returns>
        public override Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> Ejecutar()
        {
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            DaoPersona baseDeDatosPersona = fabrica.ObtenerDaoPersonaM7();
            DaoDojo baseDeDatosDojo = fabrica.ObtenerDaoDojoM7();
            DaoOrganizacion baseDeDatosOrganizacion= fabrica.ObtenerDaoOrganizacionM7();
            DaoCinta baseDeDatosCinta = fabrica.ObtenerDaoCintaM7();
            DaoUbicacion baseDeDatosUbicacion = fabrica.ObtenerDaoUbicacionM7();

            Persona persona;
            Dojo dojo;
            Organizacion organizacion;
            Ubicacion ubicacionDojo;
            String ubicacionOrganizacion;
            Cinta ultimaCinta;

            Persona idPersona = (Persona)LaEntidad;
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla;

            try
            {              
                if (idPersona.ID > 0)
                {
                    persona = (Persona)baseDeDatosPersona.ConsultarXId(idPersona);
       
                    Dojo idDojo = new Dojo(); //cambiar por fabrica
                    idDojo.Id = persona.DojoPersona;
                    dojo = (Dojo)baseDeDatosDojo.ConsultarXId(idDojo);

                    Organizacion idOrganizacion = new Organizacion(); //cambiar por fabrica
                    idOrganizacion.Id = dojo.Organizacion_dojo;
                    organizacion = (Organizacion)baseDeDatosOrganizacion.ConsultarXId(idOrganizacion);

                    ubicacionDojo = dojo.Ubicacion;
                    ubicacionOrganizacion = organizacion.Direccion;
                    ultimaCinta = (Cinta)baseDeDatosCinta.UltimaCinta(idPersona);

                    tupla = Tuple.Create((Entidad)persona, (Entidad)dojo, (Entidad)ubicacionDojo,
                        (Entidad)organizacion, ubicacionOrganizacion, (Entidad)ultimaCinta);
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
