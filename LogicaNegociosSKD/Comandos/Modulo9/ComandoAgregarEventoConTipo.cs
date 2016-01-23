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
    public class ComandoAgregarEventoConTipo : Comando<bool>
    {
        public ComandoAgregarEventoConTipo(Entidad entidad)
        {
            LaEntidad = entidad;
        }
        public override bool Ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}
