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
using DominioSKD.Entidades.Modulo7;

namespace LogicaNegociosSKD.Comandos.Modulo7
{
    /// <summary>
    /// Comando para detallar perfil de atleta
    /// </summary>
    public class ComandoConsultarPerfil : Comando<Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad>>
    {
        /// <summary>
        /// Implementacion de método ejecutar para comando consultar perfil de atleta
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

            PersonaM7 persona;
            DojoM7 dojo;
            OrganizacionM7 organizacion;
            UbicacionM7 ubicacionDojo;
            String ubicacionOrganizacion;
            CintaM7 ultimaCinta;

            PersonaM7 idPersona = (PersonaM7)LaEntidad;
            Tuple<Entidad, Entidad, Entidad, Entidad, String, Entidad> tupla;

            try
            {              
                if (idPersona.Id > 0)
                {
                    persona = (PersonaM7)baseDeDatosPersona.ConsultarXId(idPersona);

                    DojoM7 idDojo = (DojoM7)FabricaEntidades.ObtenerDojoM7();
                    idDojo.Id = persona.DojoPersona;
                    dojo = (DojoM7)baseDeDatosDojo.ConsultarXId(idDojo);

                    OrganizacionM7 idOrganizacion = (OrganizacionM7)FabricaEntidades.ObtenerOrganizacionM7();
                    idOrganizacion.Id = dojo.Organizacion_dojo;
                    organizacion = (OrganizacionM7)baseDeDatosOrganizacion.ConsultarXId(idOrganizacion);

                    ubicacionDojo = dojo.Ubicacion;
                    ubicacionOrganizacion = organizacion.Direccion;
                    ultimaCinta = (CintaM7)baseDeDatosCinta.UltimaCinta(idPersona);

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
                throw ex;
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosComandoModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosComandoModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKD ex)
            {
                throw ex;
            }

            return tupla;
        }
    }
}
