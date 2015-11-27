﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    class RestriccionCompetencia
    {
        #region Atributos
        private int idRestriccionComp;
        private String descripcion;
        private int edadMinima;
        private int edadMaxima;
        private DateTime fechaEdadMin;
        private DateTime fechaEdadMax;
        private char sexo;
        private String modalidad;
        private List<Competencia> listaCompetencias;
        //private List<Cintas> listaCintas;
        #endregion

        #region Propiedades
        public int IdRestriccionComp
        {
            get { return idRestriccionComp; }
            //set { idRestriccionComp = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }

        }

        public int EdadMinima
        {
            get { return edadMinima; }
            set { edadMinima = value; }
        }

        public int EdadMaxima
        {
            get { return edadMaxima; }
            set { edadMaxima = value; }
        }

        public DateTime FechaEdadMin
        {
            get { return fechaEdadMin; }
            set { fechaEdadMin = value; }
        }

        public DateTime FechaEdadMax
        {
            get { return fechaEdadMax; }
            set { fechaEdadMax = value; }
        }

        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public String Modalidad
        {
            get { return modalidad; }
            set { modalidad = value; }
        }

        public List<Competencia> ListaCompetencias
        {
            get { return listaCompetencias; }
            set { listaCompetencias = value; }
        }

        //public List<Cinta> ListaCintas
        //{
        //    get { return listaCintas; }
        //    set { listaCintas = value; }
        //}

        #endregion

        #region Constructores
        public RestriccionCompetencia()
        {
            idRestriccionComp = 0;
            descripcion = String.Empty;
            edadMinima = 0;
            edadMaxima = 0;
            fechaEdadMin = new DateTime();
            fechaEdadMax = new DateTime();
            sexo = new char();
            modalidad = String.Empty;
            listaCompetencias = null;
            //listaCintas = null;
        }

        public RestriccionCompetencia(int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, DateTime inputFechaEdadMin, DateTime inputFechaEdadMax, char inputSexo, String inputModalidad)
        {
            idRestriccionComp = inputId;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            fechaEdadMin = inputFechaEdadMin;
            fechaEdadMax = inputFechaEdadMax;
            sexo = inputSexo;
            modalidad = inputModalidad;
            listaCompetencias = null;
            //listaCintas = null;
        }
        #endregion
    }
}
