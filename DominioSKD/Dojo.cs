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


        #region propiedades
    
        public int Dojo_Id
        {
            get { return id_dojo; }

            set { id_dojo = value; }

        }

        public Dojo(int id_dojo) {
            this.id_dojo = id_dojo;
        }

        public int Dojo_Id
        {
            get { return id_dojo; }

            set { id_dojo = value; }

        }

        //constructor sin id 
        public Dojo(string Rif, string Nombre, int Telefono, string Email, string Logo, bool Status, Ubicacion ubicacion)
        {
  //          this.rif_dojo = Rif;
    //        this.nombre_dojo = Nombre;
      //      this.telefono_dojo = Telefono;
       //     this.email_dojo = Email;
        //    this.logo_dojo = Logo;
         //   this.status_dojo = Status;
         //   this.ubicacion = ubicacion;
        }
        public Dojo(int id_dojo)
        {
            this.id_dojo = id_dojo;
        }

        #endregion

    }
}
