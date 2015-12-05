using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Historial_Matricula
    {
        #region atributos
        private int id_historial_matricula;
        private DateTime fecha_historial_matricula;
        private string modalidad_historial_matricula;
        private float monto_historial_matricula;
        private int dojoId_historial_matricula;
        private String dojoNombre_historial_matricula;

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
        public string DojoNombre_historial_matricula
        {
            get { return dojoNombre_historial_matricula; }
            set { dojoNombre_historial_matricula = value; }
        }
        public float Monto_historial_matricula
        {
            get { return monto_historial_matricula; }
            set { monto_historial_matricula = value; }
        }
        public int Id_historial_matricula
        {
            get { return id_historial_matricula; }
            set { id_historial_matricula = value; }
        }
        public int DojoId_historial_matricula
        {
            get { return dojoId_historial_matricula; }
            set { dojoId_historial_matricula = value; }
        }

        public Historial_Matricula(DateTime Fecha,string Modalidad,int Monto)
        {
            this.fecha_historial_matricula = Fecha;
        this.modalidad_historial_matricula=Modalidad;
        this.monto_historial_matricula=Monto;
        }

        public Historial_Matricula()
        {
            // TODO: Complete member initialization
        }

        #endregion

    }
}
