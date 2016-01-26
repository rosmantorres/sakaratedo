using DominioSKD;
using LogicaNegociosSKD.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace templateApp.GUI.Modulo3
{
    public partial class M3_ConsultarOrganizacion : System.Web.UI.Page
    {
       // private LogicaOrganizacion logicaOrganizacion = new LogicaOrganizacion();
        List<Organizacion> listOrganizacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "3";
            
              if (!IsPostBack)
            {
              //  List<DominioSKD.Organizacion> listaOrganizacion = LlenarTabla();
              //  LlenarInformacion(listaOrganizacion);
            }
            
        }

         //Dado el id de org me traigo la lista de cintas
    /*    public List<DominioSKD.Organizacion> LlenarTabla()
        {

            return logicaOrganizacion.ListarOrganizacionCompleta();
            
        }
*/
        public void LlenarInformacion(List<DominioSKD.Organizacion> lista)
        {
            this.listOrganizacion = lista;
            foreach (Organizacion item in listOrganizacion)
            {

                this.tabla.Text += M3_RecursoInterfaz.AbrirTR;
                this.tabla.Text += M3_RecursoInterfaz.AbrirTD + item.Id.ToString() + M3_RecursoInterfaz.CerrarTD;
                this.tabla.Text += M3_RecursoInterfaz.AbrirTD + item.Nombre.ToString() + M3_RecursoInterfaz.CerrarTD;
                this.tabla.Text += M3_RecursoInterfaz.AbrirTD + item.Email.ToString() + M3_RecursoInterfaz.CerrarTD;
                this.tabla.Text += M3_RecursoInterfaz.AbrirTD + item.Telefono.ToString() + M3_RecursoInterfaz.CerrarTD;
                this.tabla.Text += M3_RecursoInterfaz.AbrirTD + item.Estilo.ToString() + M3_RecursoInterfaz.CerrarTD;
                this.tabla.Text += M3_RecursoInterfaz.AbrirTD + item.Direccion.ToString() + M3_RecursoInterfaz.CerrarTD;
                this.tabla.Text += M3_RecursoInterfaz.AbrirTD + item.Estado.ToString() + M3_RecursoInterfaz.CerrarTD;
                this.tabla.Text += M3_RecursoInterfaz.AbrirTD;
                 this.tabla.Text += M3_RecursoInterfaz.BotonInfo + item.Id + M3_RecursoInterfaz.BotonCerrar;
                 this.tabla.Text += M3_RecursoInterfaz.BotonModificar + item.Id + M3_RecursoInterfaz.BotonCerrar;
             //    this.tabla.Text += M3_RecursoInterfaz.BotonEliminar + item.Id_organizacion + M3_RecursoInterfaz.BotonCerrar;
                 if (item.Status)
                     this.tabla.Text += M3_RecursoInterfaz.BotonActivarOrg + item.Id + M3_RecursoInterfaz.BotonCerrar;
                 else
                     this.tabla.Text += M3_RecursoInterfaz.BotonDesactivarOrg+ item.Id + M3_RecursoInterfaz.BotonCerrar;
                 this.tabla.Text += M3_RecursoInterfaz.CerrarTD;
                 this.tabla.Text += M3_RecursoInterfaz.CerrarTR;
            }
        }

        protected void CambioDeStatus_Click(object sender, EventArgs e)
        {

        }

        }
    
}