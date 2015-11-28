using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
   public class Dojo
    {
        private int id_dojo;

       //prueba
        public Dojo() { }

        public Dojo(int id_dojo) {
            this.id_dojo = id_dojo;
        }

        public int Dojo_Id
        {
            get { return id_dojo; }

            set { id_dojo = value; }

        }
    }
}
