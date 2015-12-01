using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Morosidad
    {
        #region atributos

        private string nombre;

        private string apellido;

        private string cedula;

        private string dojoNombre;

        private string meseMoroso;

        private string monto;

      

       
        #endregion
      
         #region metodos

        public Morosidad()
        {
            
        }
        public Morosidad(string nombre, string apellido, string cedula, string dojoNombre, string meseMoroso,string monto)
        {
           
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula=cedula;
            this.dojoNombre=dojoNombre;
            this.meseMoroso=meseMoroso;
            this.monto=monto;

        }

        #endregion

        #region gets y sets
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        public string DojoNombre
        {
            get { return dojoNombre; }
            set { dojoNombre = value; }
        }
        public string MeseMoroso
        {
            get { return meseMoroso; }
            set { meseMoroso = value; }
        }
        public string Monto
        {
            get { return monto; }
            set { monto = value; }
        }


        #endregion

    }
}
