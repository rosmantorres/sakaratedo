using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    class Reglamento
    {
             #region atributos
        private int id_reglamento;
        private string nombre_reglamento;
        private string descripcion_reglamento;
        private DateTime fecha_registro_reglamento;
        private bool status_reglamento;

      

             #endregion 
        #region propiedades
        public int Id_reglamento
        {
            get { return id_reglamento; }
            set { id_reglamento = value; }
        }
        public string Nombre_reglamento
        {
            get { return nombre_reglamento; }
            set { nombre_reglamento = value; }
        }

        public string Descripcion_reglamento
        {
            get { return descripcion_reglamento; }
            set { descripcion_reglamento = value; }
        }
        public DateTime Fecha_registro_reglamento
        {
            get { return fecha_registro_reglamento; }
            set { fecha_registro_reglamento = value; }
        }
        public bool Status_reglamento
        {
            get { return status_reglamento; }
            set { status_reglamento = value; }
        }


        public Reglamento(int Id,string Nombre,string Descripcion,DateTime Fecha,bool Status)
        { this.nombre_reglamento = Nombre;
        this.id_reglamento = Id;
        this.descripcion_reglamento = Descripcion;
        this.fecha_registro_reglamento =Fecha;
        this.status_reglamento = Status;
        }
        #endregion

    }
}
