using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo12
{
    public class Ubicacion : Entidad
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

        public Ubicacion() : base()
        {
            latitud      = "";
            longitud     = "";
            ciudad       = "";
            estado       = "";
            direccion    = "";
        }

        public Ubicacion(String laLat, String laLon, String laCiudad, String elEstado, String LaDir) : base()
        {
            latitud   = laLat;
            longitud  = laLon;
            ciudad    = laCiudad;
            estado    = elEstado;
            direccion = LaDir;
        }

        public Ubicacion(int id, String laLat, String laLon, String laCiudad, String elEstado, String LaDir) : base(id)
        {
            latitud      = laLat;
            longitud     = laLon;
            ciudad       = laCiudad;
            estado       = elEstado;
            direccion    = LaDir;
        }

        public Ubicacion(int elId, String laCiudad, String elEstado) : base(elId)
        {
            ciudad = laCiudad;
            estado = elEstado;
        }


    }
}
