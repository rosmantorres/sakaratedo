using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
  public class SolicitudP
    {
        #region atributos

        private String fechaRetiro;
        private String fechaReincorporacion;
        private String motivo;
        private int idPlanilla;

        #endregion

        #region metodos
        public SolicitudP()
        {
        }
        public SolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, int idPlanilla)
        {
            this.fechaRetiro = fechaRetiro;
            this.fechaReincorporacion = fechaReincorporacion;
            this.motivo = motivo;
            this.idPlanilla = idPlanilla;
        }
        #endregion

        #region gets y sets

        public int IDPlanilla
        {
            get { return idPlanilla; }
            set { idPlanilla = value; }
        }

        public String FechaRetiro
        {
            get { return fechaRetiro; }
            set { fechaRetiro = value; }
        }

        public String FechaReincorporacion
        {
            get { return fechaReincorporacion; }
            set { fechaReincorporacion = value; }
        }

        public String Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }

        #endregion



    }
      


}
