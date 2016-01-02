using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo9;

namespace DominioSKD
{
    public class RestriccionEvento
    {
        #region Atributos
        private int idRestEvento;
        private String descripcion;
        private int edadMinima;
        private int edadMaxima;
        private char sexo;

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

        public char Sexo
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
        public RestriccionEvento()
        {
            idRestEvento = 0;
            descripcion = String.Empty;
            edadMinima = 0;
            edadMaxima = 0;
            sexo = new char();

            listaCintas = null;
            listaEvento = null;

            fechaEdadMin = new DateTime();
            fechaEdadMax = new DateTime();

        }

        public RestriccionEvento(int elId, String laDescripcion, int laEdadMinima, int laEdadMaxima, DateTime laFechaEdadMin, DateTime laFechaEdadMax, char elSexo)
        {
            idRestEvento = elId;
            descripcion = laDescripcion;
            edadMinima = laEdadMinima;
            edadMaxima = laEdadMaxima;
            sexo = elSexo;
            
            listaCintas = null;
            listaEvento = null;

            fechaEdadMin = laFechaEdadMin;
            fechaEdadMax = laFechaEdadMax;
        }
        #endregion
    }
}
