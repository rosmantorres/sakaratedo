using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo10
{
    public class Evento : Entidad
    {
        #region Atributos

        private String nombre;
        private String descripcion;
        private float costo;
        private Persona persona;
        private DominioSKD.Entidades.Modulo12.Ubicacion ubicacion;
        private DominioSKD.Entidades.Modulo12.Categoria categoria;
        private TipoEvento tipoEvento;
        private Horario horario;
        private Boolean estado;

        #endregion

        #region Constructores

        public Evento(String nombre, String descripcion, float costo, Boolean estado, DominioSKD.Entidades.Modulo12.Ubicacion ubicacion, DominioSKD.Entidades.Modulo12.Categoria categoria, TipoEvento tipoEvento, Horario horario)
            : base()
        {

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.costo = costo;
            this.ubicacion = ubicacion;
            this.categoria = categoria;
            this.tipoEvento = tipoEvento;
            this.horario = horario;
            this.estado = estado;
        }

        public Evento(String nombre, String descripcion, float costo, Boolean estado, Persona persona, DominioSKD.Entidades.Modulo12.Ubicacion ubicacion, DominioSKD.Entidades.Modulo12.Categoria categoria, TipoEvento tipoEvento, Horario horario)
            : base()
        {

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.persona = persona;
            this.costo = costo;
            this.ubicacion = ubicacion;
            this.categoria = categoria;
            this.tipoEvento = tipoEvento;
            this.horario = horario;
            this.estado = estado;
        }

        public Evento(String nombre, String descripcion, float costo, DominioSKD.Entidades.Modulo12.Ubicacion ubicacion, TipoEvento tipoEvento, Horario horario)
            : base()
        {

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.costo = costo;
            this.ubicacion = ubicacion;
            this.tipoEvento = tipoEvento;
            this.horario = horario;
        }


        #region Constructor Modulo16
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public Evento()
            : base()
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

        public DominioSKD.Entidades.Modulo12.Ubicacion Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }


        public DominioSKD.Entidades.Modulo12.Categoria Categoria
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
