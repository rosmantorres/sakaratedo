using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo13;

namespace LogicaNegociosSKD.Modulo13
{
    public class LogicaAtletaCinta
    {
        private List<DominioSKD.Persona> persona;

        public List<DominioSKD.Persona> Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public List<DominioSKD.Persona> obtenerListaPersona(String idCinta)
        {

            try
            {
                return BDAtletasCinta.ListarPersonasCintas(idCinta);
            }

            catch (Exception e)
            {
                throw e;

            }
        }


    }
    
}
