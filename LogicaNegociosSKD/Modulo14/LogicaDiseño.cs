using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Modulo14
{
    public class LogicaDiseño
    {
        private DatosSKD.Modulo14.BDDiseño datos = new DatosSKD.Modulo14.BDDiseño();

        public Boolean AgregarDiseño(DominioSKD.Diseño diseño, DominioSKD.Planilla planilla)
        {
            diseño.Base64Encode();
            return  datos.GuardarDiseñoBD(diseño, planilla);
        }
    }
}
