using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo12;
using System.Web;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;
using LogicaNegociosSKD.Comandos.Modulo12;
using LogicaNegociosSKD;
using DominioSKD.Fabrica;

namespace Interfaz_Presentadores.Modulo12
{
    /// <summary>
    /// Presentador para la ventana Detallar Competencia
    /// </summary>
    public class PresentadorDetalleCompetencia
    {
        private IContratoDetalleCompetencia vista;
        public string laLatitud;
        public string laLongitud;

        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetalleCompetencia(IContratoDetalleCompetencia laVista)
        {
            this.vista = laVista;
        }

        /// <summary>
        /// Metodo para consultar las variables del url
        /// </summary>
        public void ObtenerVariableURL()
        {
            String detalleString = HttpContext.Current.Request.QueryString[M12_RecursoInterfazPresentador.strCompDetalle];
            if (detalleString != null)
                DetallarCompetencia(int.Parse(detalleString));
        }

        /// <summary>
        /// Metodo que se encarga del evento del boton para detallar una competencia
        /// </summary>
        /// <returns></returns>
        public void DetallarCompetencia(int elIdComp)
        {
            //FabricaComandos laFabrica = new FabricaComandos();
            //FabricaEntidades laFabricaEntidades = new FabricaEntidades();
            Entidad entidad = FabricaEntidades.ObtenerCompetencia();

            entidad.Id = elIdComp;
            Comando<Entidad> comandoDetallarCompetencia =
                FabricaComandos.ObtenerComandoDetallarCompetencia(entidad);

            try
            {

                DominioSKD.Entidades.Modulo12.Competencia laCompetencia = 
                    (DominioSKD.Entidades.Modulo12.Competencia)comandoDetallarCompetencia.Ejecutar();
                

                vista.nombreComp = laCompetencia.Nombre;
                vista.tipoComp = laCompetencia.TipoCompetencia.ToString();
                if (laCompetencia.OrganizacionTodas.Equals(false))
                    vista.orgComp = laCompetencia.Organizacion.Nombre;
                else
                    vista.orgComp = "Todas";

                vista.statusComp = laCompetencia.Status;
                vista.inicioComp = laCompetencia.FechaInicio.ToShortDateString();
                vista.finComp = laCompetencia.FechaFin.ToShortDateString();
                vista.categIniComp = laCompetencia.Categoria.Cinta_inicial;
                vista.categFinComp = laCompetencia.Categoria.Cinta_final;
                vista.edadIniComp = laCompetencia.Categoria.Edad_inicial.ToString();
                vista.edadFinComp = laCompetencia.Categoria.Edad_final.ToString();
                vista.categSexoComp = laCompetencia.Categoria.Sexo;
                vista.costoComp = "Bs." + " " + laCompetencia.Costo.ToString();
                laLatitud = laCompetencia.Ubicacion.Latitud.ToString();
                laLongitud = laCompetencia.Ubicacion.Longitud.ToString();
                vista.latitudComp = laLatitud;
                vista.longitudComp = laLongitud;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M12_RecursoInterfazPresentador.alertaHtml + ex.Mensaje 
                    + M12_RecursoInterfazPresentador.alertaHtmlFinal;
        
            }
        }
    }
}
