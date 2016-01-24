using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;


namespace DominioSKD.Entidades.Modulo7
{
    public class EventoM7 : Entidad
    {
        #region Atributos

        private String nombre;
        private String descripcion;
        private float costo;
        private Persona persona;
        private Ubicacion ubicacion;
        private Categoria categoria;
        private TipoEvento tipoEvento;
        private Horario horario;
        private Boolean estado;

        #endregion

        #region Constructores


        #region Constructor Modulo16
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public EventoM7()
        {

        }
        #endregion


        #endregion

        #region Propiedades

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Horario Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public Ubicacion Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }


        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public float Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public TipoEvento TipoEvento
        {
            get { return tipoEvento; }
            set { tipoEvento = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        #endregion

    }
}
