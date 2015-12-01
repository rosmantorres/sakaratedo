using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int idEvento;
        private String nombreEvento;

        private List<Cinta> listaCintas;
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

        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public int IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        public List<Cinta> ListaCintas
        {
            get { return listaCintas; }
            set { listaCintas = value; }
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
            idEvento = 0;
            nombreEvento = String.Empty;

            listaCintas = null;

        }

        public RestriccionEvento(int elId, String laDescripcion, int laEdadMinima, int laEdadMaxima, char elSexo, int elIdEvento, String elNombreEvento)
        {
            idRestEvento = elId;
            descripcion = laDescripcion;
            edadMinima = laEdadMinima;
            edadMaxima = laEdadMaxima;
            sexo = elSexo;
            idEvento = elIdEvento;
            nombreEvento = elNombreEvento;
            
            listaCintas = null;
            
            //DateTime nacimiento = new DateTime(2000, 1, 25);
            //int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
        }
        #endregion
    }
}
