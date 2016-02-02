using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo8;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorConsultarTodosRestriccionCompetencia
    {
        private IContratoConsultarRestriccionCompetencia vista;
        List<Entidad> lista;
        public PresentadorConsultarTodosRestriccionCompetencia(IContratoConsultarRestriccionCompetencia laVista)
        {
            this.vista = laVista;

        }

        public void cargarInformacion(List<Entidad> lista)
        {
            try
            {
                this.lista = lista;
                foreach (DominioSKD.Entidades.Modulo8.RestriccionCompetencia restriccion in lista)
                {
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTR;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.IdRestriccionComp.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.Descripcion.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.EdadMinima.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.EdadMaxima.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.RangoMinimo.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.RangoMaximo.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.Sexo.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.Modalidad.ToString() + RecursoPresentadorM8.CerrarTD;
                    if (restriccion.Status == 1)
                        vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + "Activa" + RecursoPresentadorM8.CerrarTD;
                    else
                        vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + "Inactiva" + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.BotonModificarRegistroCompetencia + restriccion.IdRestriccionComp + RecursoPresentadorM8.Descripcion
                        + restriccion.Descripcion + RecursoPresentadorM8.EdadMin + restriccion.EdadMinima + RecursoPresentadorM8.EdadMax + restriccion.EdadMaxima
                        + RecursoPresentadorM8.RangoMin + restriccion.RangoMinimo + RecursoPresentadorM8.RangoMax + restriccion.RangoMaximo
                        + RecursoPresentadorM8.Sexo + restriccion.Sexo + RecursoPresentadorM8.Modalidad + restriccion.Modalidad + RecursoPresentadorM8.BotonCerrar;
                    vista.restriccionCompetencia += RecursoPresentadorM8.StatusRC + restriccion.IdRestriccionComp + RecursoPresentadorM8.RestriccionStatus + restriccion.Status + RecursoPresentadorM8.BotonCerrar;
                    vista.restriccionCompetencia += RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.CerrarTR;

                }



            }
            catch (Exception ex)
            {
                Alerta(ex.Message);

            }

        }

        public List<Entidad> LlenarTabla()
        {
            try
            {
                Comando<List<Entidad>> command = FabricaComandos.CrearComandoConsultarTodosRestriccionCompetencia();
                return command.Ejecutar();
            }

            catch (Exception ex)
            {
                Alerta(ex.Message);
                return null;
            }
        }
        
        public Boolean CambiarStatus(int id, int bitStatus)
        {
            try
            {
                DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestComp = new DominioSKD.Entidades.Modulo8.RestriccionCompetencia();
                if (bitStatus == 1)
                    bitStatus = 0;
                else
                {
                    if (bitStatus == 0)
                        bitStatus = 1;
                    else
                        return false;
                }
                laRestComp.Status = bitStatus;
                laRestComp.IdRestriccionComp = id;
                LogicaNegociosSKD.Fabrica.FabricaComandos fabrica = new LogicaNegociosSKD.Fabrica.FabricaComandos();

                LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarLogicoRestriccionCompetencia comando =
                (LogicaNegociosSKD.Comandos.Modulo8.ComandoEliminarLogicoRestriccionCompetencia)fabrica.CrearComandoEliminarLogicoRestriccionCompetencia(laRestComp);
                bool resultado = comando.Ejecutar();
                return resultado;
            }
            catch (SqlException ex)
            {
                Alerta(ex.Message);
                return false;
            }
            catch (FormatException ex)
            {
                Alerta(ex.Message);
                return false;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
                return false;
            }

            
        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public void MostrarAgregado(String eventoAgregado)
        {
            vista.alertaClase = RecursoPresentadorM8.alertaError1;
            vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
            vista.alerta = RecursoPresentadorM8.alertaHtml
                + RecursoPresentadorM8.AddRestSuccess
                + RecursoPresentadorM8.alertaHtmlFinal;
        }

        public void MostrarModificado(String eventoAgregado)
        {
            vista.alertaClase = RecursoPresentadorM8.alertaError1;
            vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
            vista.alerta = RecursoPresentadorM8.alertaHtml
                + RecursoPresentadorM8.ModRestSuccess
                + RecursoPresentadorM8.alertaHtmlFinal;
        }

    }
}
