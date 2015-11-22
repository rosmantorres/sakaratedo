using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    class Historial_Matricula
    {
        #region atributos
        private DateTime fecha_historial_matricula;
        private string modalidad_historial_matricula;
        private int monto_historial_matricula;
        #endregion

        #region propiedades
        public DateTime Fecha_historial_matricula
        {
            get { return fecha_historial_matricula; }
            set { fecha_historial_matricula = value; }
        }
        public string Modalidad_historial_matricula
        {
            get { return modalidad_historial_matricula; }
            set { modalidad_historial_matricula = value; }
        }
        public int Monto_historial_matricula
        {
            get { return monto_historial_matricula; }
            set { monto_historial_matricula = value; }
        }

        public Historial_Matricula(DateTime Fecha,string Modalidad,int Monto)
        {
            this.fecha_historial_matricula = Fecha;
        this.modalidad_historial_matricula=Modalidad;
        this.monto_historial_matricula=Monto;}

        #endregion

    }
}
