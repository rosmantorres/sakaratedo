﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class TipoEvento : Entidad
    {
        #region Atributos
        private String nombre;
        #endregion

        #region Constructores
        public TipoEvento(String nombre):base()
        {
           
            this.nombre = nombre;
        }

        public TipoEvento():base()
        {
            
           
        }
        #endregion

        #region Propiedades

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion
    }
}
