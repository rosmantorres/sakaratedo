using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Reporte_Inventario
    {

        public string nombre;

        public string tipo;

        public string marca;


        public string color;


        public string talla;


        public string estatus;


        public string precio;


        public string stockmin;


        public string descripcion;


        public string dojo;


        public string cantidad_total;




        public Reporte_Inventario()
        { }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Talla
        {
            get { return talla; }
            set { talla = value; }
        }
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public string Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string Stockmin
        {
            get { return stockmin; }
            set { stockmin = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Dojo
        {
            get { return dojo; }
            set { dojo = value; }
        }


        public string Cantidad_total
        {
            get { return cantidad_total; }
            set { cantidad_total = value; }
        }

    }
}
