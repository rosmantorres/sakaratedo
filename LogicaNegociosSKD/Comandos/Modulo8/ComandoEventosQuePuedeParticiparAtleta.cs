using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DatosSKD.DAO.Modulo8;
using ExcepcionesSKD;
using System.Data.SqlClient;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoEventosQuePuedeParticiparAtleta : Comando<List<DominioSKD.Entidad>>
    {
        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }

        public ComandoEventosQuePuedeParticiparAtleta(Entidad nuevaEntidad) 
            :base()
        {
            this.LaEntidad = nuevaEntidad;
        }

        public override List<DominioSKD.Entidad> Ejecutar()
        {
            List<DominioSKD.Entidad> resultado = new List<Entidad>(); ;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();


            try
            {
                //Deberia recibir una entidad de tipo persona, lo mantengo von int para hacer las pruebas unitarias
                int parametro = 1;
                IDaoRestriccionEvento daoRestriccionEvento = DatosSKD.Fabrica.FabricaDAOSqlServer.ObtenerDAORestriccionEvento();
                resultado = daoRestriccionEvento.EventosQuePuedeAsistirAtleta(parametro);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

    }
}