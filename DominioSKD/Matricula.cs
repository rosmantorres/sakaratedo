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
        private String fechaInicio;
        private String fechaUltimoPago;

        public int Id_matricula
        {
            get { return id_matricula; }
            set { id_matricula = value; }
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


        public Matricula()
        {
            id_matricula = 0;
            fechaInicio = "";
            fechaUltimoPago = "";
           
        }

        public Matricula(int elId,String fechaIni, String fechaPago)
        {
            id_matricula = elId;
            fechaInicio = fechaIni;
            fechaUltimoPago = fechaPago;
        }


        public Matricula(String fechaPago)
        {
            fechaUltimoPago = fechaPago;
        }
    }
}
