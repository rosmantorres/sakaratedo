using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Matricula
    {
        private int id_matricula;
        private int identificador_matricula;
        private String fechaInicio;
        private String fechaUltimoPago;
        private Boolean status;
        private float monto;

        public int Id_matricula
        {
            get { return id_matricula; }
            set { id_matricula = value; }
        }

        public int Identificador_matricula
        {
            get { return identificador_matricula; }
            set { identificador_matricula = value; }
        }


        public String FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public String FechaUltimoPago
        {
            get { return fechaUltimoPago; }
            set { fechaUltimoPago = value; }
        }

        public Boolean Status
        {
            get { return status; }
            set { status = value; }
        }

        public float Monto
        {
            get { return monto; }
            set { monto = value; }
        }



        public Matricula()
        {
            id_matricula = 0;
            identificador_matricula = 0;
            fechaInicio = "";
            fechaUltimoPago = "";

        }

        public Matricula(int elId, int identificador, Boolean estado, String fechaIni, String fechaPago)
        {
            id_matricula = elId;
            identificador_matricula = identificador;
            status = estado;
            fechaInicio = fechaIni;
            fechaUltimoPago = fechaPago;
        }


        public Matricula(String fechaPago)
        {
            fechaUltimoPago = fechaPago;
        }
    }
}
