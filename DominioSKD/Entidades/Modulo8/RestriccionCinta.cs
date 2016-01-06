using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo8
{
    public class RestriccionCinta : Entidad
    {

        #region Atributos
        /// <summary>
        /// Clase proyecto
        /// <attr name="idRestriccionCinta">Codigo unico indentificador de la restriccion de las cintas</attr>
        /// <attr name="descripcion">Descripcion resumida de los parametros de la restriccion de la cinta</attr>
        /// <attr name="tiempoMinimo">Tiempo minimo a cumplir para avanzar de cinta</attr>
        /// <attr name="tiempoMaximo">Tiempo maximo a cumplir para avanzar de cinta</attr>
        /// <attr name="tiempoDocente">Tiempo como docente a cumplir para avanzar de cinta</attr>
        /// <attr name="puntosMinimos">Puntos a obtener para avanzar de cinta</attr>
        /// <attr name="listaCintas">atributo que comprende una lista de Objetos tipo cinta que corresponden a cintas 
        /// asociadas a la restriccion</attr>
        /// </summary>

        private int idRestriccionCinta;
        private String descripcion;
        private int tiempoMinimo;
        private int tiempoMaximo;
        private int tiempoDocente;
        private int puntosMinimos;
        private List<Cinta> listaCintas;
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

        public int TiempoDocente
        {
            get { return tiempoDocente; }
            set { tiempoDocente = value; }
        }

        public int PuntosMinimos
        {
            get { return puntosMinimos; }
            set { puntosMinimos = value; }
        }

        public List<Cinta> ListaCintas
        {
            get { return listaCintas; }
            set { listaCintas = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor público sin parámetros de la clase RestriccionCinta
        /// </summary>
        public RestriccionCinta()
            : base(0)
        {
            this.idRestriccionCinta = -1;
            this.descripcion = String.Empty;
            this.tiempoMinimo = 0;
            this.tiempoMaximo = 0;
            this.tiempoDocente = 1;
            this.puntosMinimos = 0;
            this.listaCintas = null;
        }

        /// <summary>
        /// Constructor público solo con el id de la restriccion de la clase RestriccionCinta y sin identificador unico
        /// </summary>
        public RestriccionCinta(int inputId)
            : base(0)
        {
            this.idRestriccionCinta = inputId;
            this.descripcion = String.Empty;
            this.tiempoMinimo = 0;
            this.tiempoMaximo = 0;
            this.tiempoDocente = 1;
            this.puntosMinimos = 0;
            this.listaCintas = null;
        }

        /// <summary>
        /// Constructor público sin el id de la restriccion de la clase RestriccionCinta y sin identificador unico
        /// </summary>
        public RestriccionCinta(String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos)
            : base(0)
        {
            idRestriccionCinta = -1;
            descripcion = inputDescripcion;
            tiempoMinimo = inputTiempoMinimo;
            tiempoMaximo = inputTiempoMaximo;
            tiempoDocente = inputTiempoDocente;
            puntosMinimos = inputPuntosMinimos;
            listaCintas = null;
        }

        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase RestriccionCinta y sin identificador unico
        /// </summary>
        public RestriccionCinta(int inputId, String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos)
            : base(0)
        {
            idRestriccionCinta = inputId;
            descripcion = inputDescripcion;
            tiempoMinimo = inputTiempoMinimo;
            tiempoMaximo = inputTiempoMaximo;
            tiempoDocente = inputTiempoDocente;
            puntosMinimos = inputPuntosMinimos;
            listaCintas = null;
        }
        
        /// <summary>
        /// Constructor público con todos los atributos de la tupla de la clase RestriccionCinta y con identificador unico
        /// </summary>
        public RestriccionCinta(int id, int inputId, String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos)
 
        {
            base.Id = id;
            idRestriccionCinta = inputId;
            descripcion = inputDescripcion;
            tiempoMinimo = inputTiempoMinimo;
            tiempoMaximo = inputTiempoMaximo;
            tiempoDocente = inputTiempoDocente;
            puntosMinimos = inputPuntosMinimos;
            listaCintas = null;
        }
        #endregion

    }
}
