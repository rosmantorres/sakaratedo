using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoAgregarRestriccionCompetencia : Comando<DominioSKD.Entidad>
    {
        public override Boolean Ejecutar(DominioSKD.Entidad parametro)
        {
            Boolean resultado = false;
            
            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();
            
            IDaoRestriccionCompetencia daoRestriccionCompetencia = fabricaDAO.ObtenerDAORestriccionCompetencia();

            try
            {
            
                resultado = daoRestriccionCompetencia.Agregar(parametro);
            
            }
            catch (Exception ex)
            {
                
                throw ex;
            
            }
            
            return resultado;

        }
     
    }
}
