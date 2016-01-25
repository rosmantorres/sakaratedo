using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;
using DatosSKD.Fabrica;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoModificarRestriccionCompetencia : Comando<Boolean>
    {

        private Entidad parametro;

        public Entidad Parametro
        {
            get { return parametro; }
            set { parametro = value; }
        }
        
        public override Boolean Ejecutar()
        {
            Boolean resultado = false;
            
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            
            IDaoRestriccionCompetencia daoRestriccionCompetencia = fabricaDAO.ObtenerDAORestriccionCompetencia();

            try
            {
            
                resultado = daoRestriccionCompetencia.Modificar(this.parametro);
            
            }
            catch (Exception ex)
            {
                
                throw ex;
            
            }
            
            return resultado;

        }
     
    }

}

