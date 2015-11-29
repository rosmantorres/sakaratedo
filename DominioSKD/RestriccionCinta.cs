using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class RestriccionCinta
    {
        #region Atributos
        private int idRestriccionCinta;
        private String descripcion;
        private int tiempoMinimo;
        private int tiempoMaximo;
        private int tiempoDocente;
        private List<Cinta> listaCintas;
        #endregion

        #region Propiedades
        public int IdRestriccionComp
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
     
        public List<Cinta> ListaCintas
        {
            get { return listaCintas; }
            set { listaCintas = value; }
        }

        #endregion

        #region Constructores
        public RestriccionCinta()
        {
            idRestriccionCinta = 0;
            descripcion = String.Empty;
            tiempoMinimo = 0;
            tiempoMaximo = 0;
            tiempoDocente = 0;
            listaCintas = null;
        }

        public RestriccionCinta(int inputId, String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente)
        {
            idRestriccionCinta = inputId;
            descripcion = inputDescripcion;
            tiempoMinimo = inputTiempoMinimo;
            tiempoMaximo = inputTiempoMaximo;
            tiempoDocente = inputTiempoDocente;
            listaCintas = null;
        }
        #endregion
    }
}
