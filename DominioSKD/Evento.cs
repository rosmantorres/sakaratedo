using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Evento
    {
        #region Atributos

        private int id_evento;
        private string descripcion;
        private string nombre;
        private int id_horario;
        private int id_ubicacion;
        private int id_dojo;
        private int id_categoria;
        private float costo;
        private Evento tipo_evento;

        #endregion

        #region Get y Set

        public int Id_evento
        {
            get { return id_evento; }
            set { id_evento = value; }
        }

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

        public int Id_horario
        {
            get { return id_horario; }
            set { id_horario = value; }
        }

        public int Id_ubicacion
        {
            get { return id_ubicacion; }
            set { id_ubicacion = value; }
        }

        public int Id_dojo
        {
            get { return id_dojo; }
            set { id_dojo = value; }
        }
        public int Id_categoria
        {
            get { return id_categoria; }
            set { id_categoria = value; }
        }

        public float Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public Evento Tipo_evento
        {
            get { return tipo_evento; }
            set { tipo_evento = value; }
        }

        #endregion

        #region Constructores

        public Evento()
        {
            id_evento = 0;
            descripcion = "";
            nombre = "";
            id_horario = 0;
            id_ubicacion = 0;
            id_dojo = 0;
            id_categoria = 0;
            costo = 0;
            tipo_evento = null;
        }

        public Evento(int eve_id, string eve_nombre, float precio)
        {
            id_evento = eve_id;
            nombre = eve_nombre;
            costo = precio;
        }

        #endregion

    }
}
