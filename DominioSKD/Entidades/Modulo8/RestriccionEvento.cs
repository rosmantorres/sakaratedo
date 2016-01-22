using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo8
{
    public class RestriccionEvento : Entidad
    {

        #region Atributos
        /// <summary>
        /// Clase proyecto
        /// <attr name="idRestEvento">Codigo unico indentificador de la restriccion del evento</attr>
        /// <attr name="descripcion">Descripcion resumida de los parametros de la restriccion del evento</attr>
        /// <attr name="edadMinima">Edad minima con la que se puede participar en el evento</attr>
        /// <attr name="edadMaxima">Edad maxima con la que se puede participar en el evento</attr>
        /// <attr name="sexo">sexo permitido en el evento {M,F,B} M para solo atletas masculinos, 
        /// F solo para atletas femeninos, B para atletas de ambos sexos</attr>
        /// <attr name="listaCintas">atributo que comprende una lista de Objetos tipo cinta que corresponden a cintas 
        /// asociadas a la restriccion</attr>
        /// <attr name="listaEvento">atributo que comprende una lista de Objetos tipo Evento que corresponden 
        /// a eventos asociadas a la restriccion</attr>
        /// <attr name="fechaEdadMin">fecha antes de la cual se tiene que haber nacido para satisfacer la edad minima 
        /// permitida para el evento</attr>
        /// <attr name="fechaEdadMax">fecha depues de la cual se tiene que haber nacido para satisfacer la edad maxima 
        /// permitida para el evento</attr>
        /// </summary>

        private int idRestEvento;
        private String descripcion;
        private int edadMinima;
        private int edadMaxima;
        private String sexo;
        private List<Cinta> listaCintas;
        private List<Evento> listaEvento;
        private DateTime fechaEdadMin;
        private DateTime fechaEdadMax;
        #endregion

        #region Propiedades
        public int IdRestEvento
        {
            get { return idRestEvento; }
            set { idRestEvento = value; }
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

        public String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public List<Cinta> ListaCintas
        {
            get { return listaCintas; }
            set { listaCintas = value; }
        }

        public List<Evento> ListaEvento
        {
            get { return listaEvento; }
            set { listaEvento = value; }
        }

        public DateTime FechaEdadMinima
        {
            get { return fechaEdadMin; }
            set { fechaEdadMin = value; }
        }

        public DateTime FechaEdadMaxima
        {
            get { return fechaEdadMax; }
            set { fechaEdadMax = value; }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor público sin parámetros de la clase RestriccionEvento
        /// </summary>
        public RestriccionEvento()
            : base(0)
        {
            this.idRestEvento = -1;
            this.descripcion = String.Empty;
            this.edadMinima = 0;
            this.edadMaxima = 0;
            this.sexo = String.Empty;
            this.listaCintas = null;
            this.listaEvento = null;
            this.fechaEdadMin = new DateTime();
            this.fechaEdadMax = new DateTime();
        }

        /// <summary>
        /// Constructor público solo con el id de la restriccion de la clase RestriccionEvento y sin identificador unico
        /// </summary>
        public RestriccionEvento(int inputId)
            : base(0)
        {
            this.idRestEvento = inputId;
            this.descripcion = String.Empty;
            this.edadMinima = 0;
            this.edadMaxima = 0;
            this.sexo = String.Empty;
            this.listaCintas = null;
            this.listaEvento = null;
            this.fechaEdadMin = new DateTime();
            this.fechaEdadMax = new DateTime();
        }

        /// <summary>
        /// Constructor público sin el id de la restriccion de la clase RestriccionEvento y sin identificador unico
        /// </summary>
        public RestriccionEvento(String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo)
            : base(0)
        {
            idRestEvento = -1;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            sexo = inputSexo;
            listaCintas = null;
            listaEvento = null;
            fechaEdadMin = new DateTime();
            fechaEdadMax = new DateTime();
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase RestriccionEvento y sin identificador unico
        /// </summary>
        public RestriccionEvento(int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo)
            : base(0)
        {
            idRestEvento = inputId;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            sexo = inputSexo;
            listaCintas = null;
            listaEvento = null;
            fechaEdadMin = new DateTime();
            fechaEdadMax = new DateTime();
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase RestriccionEvento y con identificador unico
        /// </summary>
        public RestriccionEvento(int id, int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo)
        {
            base.Id = id;
            idRestEvento = inputId;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            sexo = inputSexo;
            listaCintas = null;
            listaEvento = null;
            fechaEdadMin = new DateTime();
            fechaEdadMax = new DateTime();
        }
        #endregion

    }
}
