using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo12
{
    public class Competencia : Entidad
    {
        #region atributos
        private int id_competencia;
        private String nombre;
        private String tipoCompetencia;
        private bool organizacionTodas;
        private String status;
        private float costo;
        private Categoria categoria;
        private Ubicacion ubicacion;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private Organizacion organizacion;
        private List<Organizacion> listaOrganizaciones;


        #endregion
        #region propiedades
        public int Id_competencia
        {
            get { return id_competencia; }
            set { id_competencia = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String TipoCompetencia
        {
            get { return tipoCompetencia; }
            set { tipoCompetencia = value; }
        }


        public bool OrganizacionTodas
        {
            get { return organizacionTodas; }
            set { organizacionTodas = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public Ubicacion Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public Organizacion Organizacion
        {
            get { return organizacion; }
            set { organizacion = value; }
        }        
        public List<Organizacion> ListaOrganizaciones
        {
            get { return listaOrganizaciones; }
            set { listaOrganizaciones = value; }
        }

        public float Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        #endregion

        #region constructores
        public Competencia() : base()
        {
            id_competencia = 0;
            nombre = "";
            tipoCompetencia = "";
            organizacionTodas = false;
            status = "";
            costo = 0;
            categoria = null;
            ubicacion = null;
            fechaInicio = DateTime.Now;
            fechaFin = DateTime.Now;
            organizacion = null;
            listaOrganizaciones = null;
            

        }

        public Competencia(int elId, String elNombre, String elTipo, bool orgTodas, String elStatus) :base()
        {
            id_competencia    = elId;
            nombre            = elNombre;
            tipoCompetencia   = elTipo;
            organizacionTodas = orgTodas;
            status            = elStatus;
           

        }

        public Competencia(int id,int elId, String elNombre, String elTipo, bool orgTodas, String elStatus): base(id)
        {
            id_competencia = elId;
            nombre = elNombre;
            tipoCompetencia = elTipo;
            organizacionTodas = orgTodas;
            status = elStatus;


        }

        #endregion


    }
}
