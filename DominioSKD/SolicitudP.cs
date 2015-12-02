﻿using System;
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
        private Planilla planilla;
        private int id;
        private String nombreEvento;
        #endregion

        #region metodos
        public SolicitudP()
        {
        }
        public SolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, int id)
        {
            this.fechaRetiro = fechaRetiro;
            this.fechaReincorporacion = fechaReincorporacion;
            this.motivo = motivo;
            this.id = id;
        }

        public SolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, Planilla planilla,int id)
        {
            this.fechaRetiro = fechaRetiro;
            this.fechaReincorporacion = fechaReincorporacion;
            this.motivo = motivo;
            this.planilla = planilla;
            this.id = id;
        }
        public SolicitudP( int id, String nombreEvento)
        {
        
            this.id = id;
            this.nombreEvento = nombreEvento;
        }
      
     
        #endregion

        #region gets y sets


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
        public Planilla Planilla
        {
            get { return planilla; }
            set { planilla = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public String NombreEvento
        {
            get { return nombreEvento; }
            set { nombreEvento = value; }
        }

        #endregion



    }
      


}
