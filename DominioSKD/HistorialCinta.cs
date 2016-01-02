using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo9;
using DominioSKD.Entidades.Modulo1;

namespace DominioSKD
{
    public class HistorialCinta
    {
        #region Atributos
        private int id;
        private DateTime fecha;
        //private Cinta cinta;
        private Persona persona;
        private Evento evento;
        #endregion

        #region Constructores
        public HistorialCinta(int id, DateTime fecha, /*Cinta cinta*/ Persona persona, Evento evento)
        {
            this.id = id;
            this.fecha = fecha;
            //this.cinta = cinta;
            this.persona = persona;
            this.evento = evento;
        }
        public HistorialCinta()
        {
            this.id = 0;
            this.fecha = new DateTime();
            //this.cinta = new Cinta();
            this.persona = new Persona();
            this.evento = new Evento();
        }
        #endregion

        #region Propiedades

        public int id_historialC
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        /*public Cinta Cinta
        {
            get { return cinta; }
            set { cinta = value; }
        }*/

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public Evento Evento
        {
            get { return evento; }
            set { evento = value; }
        }
        #endregion
    }
}
