using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo8
{
    public class RestriccionCompetencia : Entidad
    {

        #region Atributos
        /// <summary>
        /// Clase proyecto
        /// <attr name="idRestriccionComp">Codigo unico indentificador de la restriccion de las competencias</attr>
        /// <attr name="descripcion">Descripcion resumida de los parametros de la restriccion de la competencia</attr>
        /// <attr name="edadMinima">Edad minima con la que se puede participar el competencia</attr>
        /// <attr name="edadMaxima">Edad maxima con la que se puede participar el competencia</attr>
        /// <attr name="rangoMinimo">Rango Minimo de cinta con la que se puede participar en la competencia</attr>
        /// <attr name="rangoMaximo">Rango Minimo de cinta con la que se puede participar en la competencia</attr>
        /// <attr name="fechaEdadMin">fecha antes de la cual se tiene que haber nacido para satisfacer la edad minima 
        /// permitida de la competencia</attr>
        /// <attr name="fechaEdadMax">fecha depues de la cual se tiene que haber nacido para satisfacer la edad maxima 
        /// permitida de la competencia</attr>
        /// <attr name="sexo">sexo permitido en la competencia {M,F,B} M para solo atletas masculinos, 
        /// F solo para atletas femeninos, B para atletas de ambos sexos</attr>
        /// <attr name="modalidad">modalidades que comprende la competencia. {Kumite,Kata,Ambos}</attr>
        /// <attr name="listaCompetencias">atributo que comprende una lista de Objetos tipo competencia que corresponden 
        /// a competencias asociadas a la restriccion</attr>
        /// <attr name="listaCintas">atributo que comprende una lista de Objetos tipo cinta que corresponden a cintas 
        /// asociadas a la restriccion</attr>
        /// </summary>

        private int idRestriccionComp;
        private String descripcion;
        private int edadMinima;
        private int edadMaxima;
        private int rangoMinimo;
        private int rangoMaximo;
        private DateTime fechaEdadMin;
        private DateTime fechaEdadMax;
        private String sexo;
        private String modalidad;
        private List<Competencia> listaCompetencias;
        private List<Cinta> listaCintas;
        #endregion

        #region Propiedades
        public int IdRestriccionComp
        {
            get { return idRestriccionComp; }
            set { idRestriccionComp = value; }
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

        public int RangoMinimo
        {
            get { return rangoMinimo; }
            set { rangoMinimo = value; }
        }

        public int RangoMaximo
        {
            get { return rangoMaximo; }
            set { rangoMaximo = value; }
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

        public String Sexo
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

        public List<Cinta> ListaCintas
        {
            get { return listaCintas; }
            set { listaCintas = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor público sin parámetros de la clase RestriccionCompetencia
        /// </summary>
        public RestriccionCompetencia()
            : base(0)
        {
            this.idRestriccionComp = -1;
            this.descripcion = String.Empty;
            this.edadMinima = 0;
            this.edadMaxima = 0;
            this.rangoMinimo = 1;
            this.rangoMaximo = 20;
            this.fechaEdadMin = new DateTime();
            this.fechaEdadMax = new DateTime();
            this.sexo = String.Empty;
            this.modalidad = String.Empty;
            this.listaCompetencias = null;
            this.listaCintas = null;
        }

        /// <summary>
        /// Constructor público solo con el id de la restriccion de la clase RestriccionCompetencia y sin identificador unico
        /// </summary>
        public RestriccionCompetencia(int inputId)
            : base(0)
        {
            this.idRestriccionComp = inputId;
            this.descripcion = String.Empty;
            this.edadMinima = 0;
            this.edadMaxima = 0;
            this.rangoMinimo = 1;
            this.rangoMaximo = 20;
            this.fechaEdadMin = new DateTime();
            this.fechaEdadMax = new DateTime();
            this.sexo = String.Empty;
            this.modalidad = String.Empty;
            this.listaCompetencias = null;
            this.listaCintas = null;
        }

        /// <summary>
        /// Constructor público sin el id de la restriccion de la clase RestriccionCompetencia y sin identificador unico
        /// </summary>
        public RestriccionCompetencia(String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, int inputRangoMinimo,
                                      int inputRangoMaximo, String inputSexo, String inputModalidad)
            : base(0)
        {
            idRestriccionComp = -1;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            rangoMinimo = inputRangoMinimo;
            rangoMaximo = inputRangoMaximo;
            fechaEdadMin = new DateTime();
            fechaEdadMax = new DateTime();
            sexo = inputSexo;
            modalidad = inputModalidad;
            listaCompetencias = null;
            listaCintas = null;
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase RestriccionCompetencia y sin identificador unico
        /// </summary>
        public RestriccionCompetencia(int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, int inputRangoMinimo,
                                      int inputRangoMaximo, String inputSexo, String inputModalidad)
            : base(0)
        {
            idRestriccionComp = inputId;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            rangoMinimo = inputRangoMinimo;
            rangoMaximo = inputRangoMaximo;
            fechaEdadMin = new DateTime();
            fechaEdadMax = new DateTime();
            sexo = inputSexo;
            modalidad = inputModalidad;
            listaCompetencias = null;
            listaCintas = null;
        }


        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase RestriccionCompetencia y con identificador unico
        /// </summary>
        public RestriccionCompetencia(int id, int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, int inputRangoMinimo,
                                      int inputRangoMaximo, String inputSexo, String inputModalidad)
        {
            base.Id = id;
            idRestriccionComp = inputId;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            rangoMinimo = inputRangoMinimo;
            rangoMaximo = inputRangoMaximo;
            fechaEdadMin = new DateTime();
            fechaEdadMax = new DateTime();
            sexo = inputSexo;
            modalidad = inputModalidad;
            listaCompetencias = null;
            listaCintas = null;
        }
        #endregion

    }
}
