using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo12
{
    public class Categoria : Entidad
    {
        #region atributos
        private int edad_inicial;
        private int edad_final;
        private String cinta_inicial;
        private String cinta_final;
        private String sexo;
        #endregion

        #region propiedades


        public int Edad_inicial
        {
            get { return edad_inicial; }
            set { edad_inicial = value; }
        }

        public int Edad_final
        {
            get { return edad_final; }
            set { edad_final = value; }
        }

        public String Cinta_inicial
        {
            get { return cinta_inicial; }
            set { cinta_inicial = value; }
        }

        public String Cinta_final
        {
            get { return cinta_final; }
            set { cinta_final = value; }
        }
        

        public String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        #endregion

        #region constructores
        public Categoria() : base()
        {
            edad_inicial  = -1;
            edad_final    = -1;
            cinta_inicial = "";
            cinta_final = "";
            sexo = "";
        }

        public Categoria( int laEdadIni, int laEdadFin, String laCintaIni, String laCintaFinal, String elSexo) : base ()
        {
            edad_inicial  = laEdadIni;
            edad_final    = laEdadFin;
            cinta_inicial = laCintaIni;
            cinta_final   = laCintaFinal;
            sexo          = elSexo;
        }

        public Categoria(int id, int laEdadIni, int laEdadFin, String laCintaIni, String laCintaFinal, String elSexo) : base(id)
        {
            edad_inicial = laEdadIni;
            edad_final = laEdadFin;
            cinta_inicial = laCintaIni;
            cinta_final = laCintaFinal;
            sexo = elSexo;
        }
        #endregion


    }
}
