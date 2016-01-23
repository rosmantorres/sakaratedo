using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo8
{
    #region RestriccionEvento
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
        /// <attr name="idEvento">codigo unico identificador del evento</attr>
        /// <attr name="nombreEvento">nombre del evento</attr>
        /// <attr name="listaCintas">atributo que comprende una lista de Objetos tipo cinta que corresponden a cintas 
        /// asociadas a la restriccion</attr>
        /// </summary>

        private int idRestEvento;
        private String descripcion;
        private int edadMinima;
        private int edadMaxima;
        private String sexo;
        private int idEvento;
        private String nombreEvento;
        private List<CintaSimple> listaCintas;
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

        public String NombreEvento
        {
            get { return nombreEvento; }
            set { nombreEvento = value; }
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

        public int IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        public List<CintaSimple> ListaCintas
        {
            get { return listaCintas; }
            set { listaCintas = value; }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor público sin parámetros de la clase RestriccionEvento
        /// </summary>
        public RestriccionEvento() : base(0)
        {
            this.idRestEvento = -1;
            this.descripcion = String.Empty;
            this.edadMinima = 0;
            this.edadMaxima = 0;
            this.sexo = String.Empty;
            this.idEvento = -1;
            this.nombreEvento = String.Empty;
            this.listaCintas = null;
        }

        /// <summary>
        /// Constructor público solo con el id de la restriccion de la clase RestriccionEvento y sin identificador unico
        /// </summary>
        public RestriccionEvento(int inputId) : base(0)
        {
            this.idRestEvento = inputId;
            this.descripcion = String.Empty;
            this.edadMinima = 0;
            this.edadMaxima = 0;
            this.sexo = String.Empty;
            this.idEvento = -1;
            this.nombreEvento = String.Empty;
            this.listaCintas = null;
        }

        /// <summary>
        /// Constructor público sin el id de la restriccion de la clase RestriccionEvento y sin identificador unico
        /// </summary>
        public RestriccionEvento(String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento) : base(0)
        {
            idRestEvento = -1;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            sexo = inputSexo;
            idEvento = inputIdEvento;
            nombreEvento = inputNombreEvento;
            listaCintas = null;
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase RestriccionEvento y con identificador unico
        /// </summary>
        public RestriccionEvento(int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento) : base(0)
        {
            idRestEvento = inputId;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            sexo = inputSexo;
            idEvento = inputIdEvento;
            nombreEvento = inputNombreEvento;
            listaCintas = null;
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase RestriccionEvento y con identificador unico
        /// </summary>
        public RestriccionEvento(int id, int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento)
        {
            base.Id = id;
            idRestEvento = inputId;
            descripcion = inputDescripcion;
            edadMinima = inputEdadMinima;
            edadMaxima = inputEdadMaxima;
            sexo = inputSexo;
            idEvento = inputIdEvento;
            nombreEvento = inputNombreEvento;
            listaCintas = null;
        }
        #endregion

    }
    #endregion

    #region EventoSimple
    public class EventoSimple : Entidad
    {

        #region Atributos
        /// <summary>
        /// Clase proyecto
        /// <attr name="idEvento">Codigo unico indentificador del evento</attr>
        /// <attr name="nombreEvento">Nombre del evento</attr>
        /// </summary>
        
        private int idEvento;
        private String nombreEvento;
        #endregion

        #region Propiedades
        public int IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        public String NombreEvento
        {
            get { return nombreEvento; }
            set { nombreEvento = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor público sin parámetros de la clase EventoSimple
        /// </summary>
        public EventoSimple() : base(0)
        {
            idEvento = -1;
            nombreEvento = String.Empty;
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase EventoSimple y con identificador unico
        /// </summary>
        public EventoSimple(int elId, String elNombre) : base(0)
        {
            idEvento = elId;
            nombreEvento = elNombre;
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase EventoSimple y con identificador unico
        /// </summary>
        public EventoSimple(int id, int elId, String elNombre)
        {
            base.Id = id;
            idEvento = elId;
            nombreEvento = elNombre;
        }
        #endregion

    }
    #endregion

    #region CintaSimple
    public class CintaSimple : Entidad
    {

        #region Atributos
        /// <summary>
        /// Clase proyecto
        /// <attr name="idCinta">Codigo unico indentificador de la cinta</attr>
        /// <attr name="colorCinta">Color de la cinta</attr>
        /// </summary>
        
        private int idCinta;
        private String colorCinta;
        #endregion

        #region Propiedades
        public int IdCinta
        {
            get { return idCinta; }
            set { idCinta = value; }
        }

        public String ColorCinta
        {
            get { return colorCinta; }
            set { colorCinta = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor público sin parámetros de la clase CintaSimple
        /// </summary>
        public CintaSimple() : base(0)
        {
            idCinta = 0;
            colorCinta = String.Empty;

        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase CintaSimple y con identificador unico
        /// </summary>
        public CintaSimple(int elId, String elColor) : base(0)
        {
            idCinta = elId;
            colorCinta = elColor;
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase CintaSimple y con identificador unico
        /// </summary>
        public CintaSimple(int id, int elId, String elColor)
        {
            base.Id = id;
            idCinta = elId;
            colorCinta = elColor;
        }
        #endregion

    }
    #endregion

}
