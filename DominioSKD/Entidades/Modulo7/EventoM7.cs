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
        private PersonaM7 persona;
        private UbicacionM7 ubicacion;
        private Categoria categoria;
        private TipoEventoM7 tipoEvento;
        private HorarioM7 horario;
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

        public HorarioM7 Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public UbicacionM7 Ubicacion
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

        public TipoEventoM7 TipoEvento
        {
            get { return tipoEvento; }
            set { tipoEvento = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public PersonaM7 Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        #endregion

    }
}
