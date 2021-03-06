﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo4
{
    public class HistorialM : Entidad
    {
        #region atributos
        private int id_historial_matricula;
        private DateTime fecha_historial_matricula;
        private string modalidad_historial_matricula;
        private float monto_historial_matricula;
        private DojoM4 dojo_historial_matricula;

        #endregion

        #region propiedades
        public int Id_historial_matricula
        {
            get { return id_historial_matricula; }
            set { id_historial_matricula = value; }
        }
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
        public float Monto_historial_matricula
        {
            get { return monto_historial_matricula; }
            set { monto_historial_matricula = value; }
        }
        public DojoM4 Dojo_historial_matricula
        {
            get { return dojo_historial_matricula; }
            set { dojo_historial_matricula = value; }
        }
        #endregion
        #region Constructor
        public HistorialM(DateTime Fecha, string Modalidad, int Monto)
        {
            this.fecha_historial_matricula = Fecha;
            this.modalidad_historial_matricula = Modalidad;
            this.monto_historial_matricula = Monto;
        }

        public HistorialM()
        {
            // TODO: Complete member initialization
        }

        #endregion
    }
}
