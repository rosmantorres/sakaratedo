using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo7;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_ListarAsistenciaAEventos : System.Web.UI.Page
    {
        #region Atributos
        private List<Evento> laLista = new List<Evento>();
        #endregion
        #region Métodos
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";

        }









        #endregion
    }
}