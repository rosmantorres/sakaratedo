using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    class Diseño
    {
        #region atributos

        private int id;
        private string contenido;

        #endregion

        #region metodos

        public Diseño(int id, string contenido)
        {
            this.id = id;
            this.contenido = contenido;
        }

        public Diseño(string contenido)
        {
            this.contenido = contenido;
        }
        #endregion

        #region gets y sets

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        #endregion
    }
}
