using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo9;
using DominioSKD;
using ExcepcionesSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Comandos.Modulo9
{
    public class ComandoAgregarEvento : Comando<bool>
    {
        public ComandoAgregarEvento(Entidad entidad)
        {
            LaEntidad = entidad;
        }
        public override bool Ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}
