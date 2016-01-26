using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoAgregarListaCompetenciaRestriccionCompetencia : Comando<Boolean>
    {
        private Entidad RestriccionCompetencia;
        private List<Entidad> listaCompetencias;

        public List<Entidad> ListaCompetencias
        {
            get { return listaCompetencias; }
            set { listaCompetencias = value; }
        }
        
        

        public Entidad LaRestriccionCompetencia
        {
            get { return RestriccionCompetencia; }
            set { RestriccionCompetencia = value; }
        }

        public override Boolean Ejecutar()
        {
            Boolean resultado = false;

            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();

            IDaoRestriccionCompetencia daoRestriccionCompetencia = fabricaDAO.ObtenerDAORestriccionCompetencia();

            try
            {

                resultado = daoRestriccionCompetencia.AgregarListaCompetenciaRestriccionCompetencia(this.RestriccionCompetencia, this.listaCompetencias);

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
