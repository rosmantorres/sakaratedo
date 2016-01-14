using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo8;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Modulo8
{
    public class ComandoModificarRestriccionCinta : Comando<Boolean>
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
            
            DatosSKD.Fabrica.FabricaDAOSqlServer fabricaDAO = new DatosSKD.Fabrica.FabricaDAOSqlServer();
            
            IDaoRestriccionCinta daoRestriccionCinta = fabricaDAO.ObtenerDAORestriccionCinta();

            try
            {

                resultado = daoRestriccionCinta.ModificarRestriccionCinta(this.parametro);
            
            }
            catch (Exception ex)
            {
                
                throw ex;
            
            }
            
            return resultado;

        }
     
    }
}
