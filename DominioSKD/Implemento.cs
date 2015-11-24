using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Implemento
    {
        #region Atributos

        private int id_implemento;
        private string imagen;
        private string nombre;
        private string tipo;
        private string marca;
        private string color;
        private string talla;
        private string status;
        private float precio;
        private int stockmin;
        private string descripcion;

        #endregion

        #region Get y Set

        public int Id_implemento
        {
            get { return id_implemento; }
            set { id_implemento = value; }
        }

        public String Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public String Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public String Color
        {
            get { return color; }
            set { color = value; }
        }
        public String Talla
        {
            get { return talla; }
            set { talla = value; }
        }
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public int Stockmin
        {
            get { return stockmin; }
            set { stockmin = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        #endregion

        #region Constructores

        public Implemento()
        {
            id_implemento = 0;
            imagen = "";
            nombre = "";
            tipo = "";
            marca = "";
            color = "";
            talla = "";
            status = "";
            precio = 0;
            stockmin = 0;
            descripcion = "";
        }

        public Implemento(int imp_id, string imp_imagen, string imp_nombre, string imp_tipo, string imp_marca, float imp_precio)
        {
            id_implemento = imp_id;
            imagen = imp_imagen;
            nombre = imp_nombre;
            tipo = imp_tipo;
            marca = imp_marca;
            precio = imp_precio;
        }

        public Implemento(string imp_imagen, string imp_nombre, string imp_tipo, string imp_marca, string imp_color, string imp_talla, string imp_estatus, float imp_precio, string imp_descripcion)
        {
            imagen = imp_imagen;
            nombre = imp_nombre;
            tipo = imp_tipo;
            marca = imp_marca;
            color = imp_color;
            talla = imp_talla;
            status = imp_estatus;
            precio = imp_precio;
            descripcion = imp_descripcion;
        }
        #endregion
    }
}

