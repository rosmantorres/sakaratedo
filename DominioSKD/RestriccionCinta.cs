﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class RestriccionCinta
    {
        #region Atributos
        private int idRestriccionCinta;
        private String descripcion;
        private int tiempoMinimo;
        private int tiempoMaximo;
        private int tiempoDocente;
        private int puntosMinimos;
        #endregion

        #region Propiedades
        public int IdRestriccionCinta
        {
            get { return idRestriccionCinta; }
            set { idRestriccionCinta = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }

        public int TiempoMinimo
        {
            get { return tiempoMinimo; }
            set { tiempoMinimo = value; }
        }

        public int TiempoMaximo
        {
            get { return tiempoMaximo; }
            set { tiempoMaximo = value; }
        }

        public int PuntosMinimos
        {
            get { return puntosMinimos; }
            set { puntosMinimos = value; }
        }

        public int TiempoDocente
        {
            get { return tiempoDocente; }
            set { tiempoDocente = value; }
        }


        #endregion

        #region Constructores
        public RestriccionCinta()
        {
            idRestriccionCinta = 0;
            descripcion = String.Empty;
            tiempoMinimo = 0;
            tiempoMaximo = 0;
            tiempoDocente = 0;
            puntosMinimos = 0;
        }

        public RestriccionCinta(int inputId, String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputPuntosMinimos, int inputTiempoDocente)
        {
            idRestriccionCinta = inputId;
            descripcion = inputDescripcion;
            tiempoMinimo = inputTiempoMinimo;
            tiempoMaximo = inputTiempoMaximo;
            puntosMinimos = inputPuntosMinimos;
            tiempoDocente = inputTiempoDocente;
        }
        #endregion
    }
}
