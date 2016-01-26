using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo7
{
    public class UbicacionM7 : Entidad
    {
        #region atributos
        private String latitud;
        private String longitud;
        private String ciudad;
        private String estado;
        private String direccion;
        #endregion 

        #region propiedades

        public String Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }

        public String Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        public String Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        #endregion

        public UbicacionM7() : base()
        {
            latitud      = "";
            longitud     = "";
            ciudad       = "";
            estado       = "";
            direccion    = "";
        }

       

    }
}
