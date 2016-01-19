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

namespace Interfaz_Presentadores.Modulo12
{
    public class PresentadorDetalleCompetencia
    {
        private IContratoDetalleCompetencia vista;
        public string laLatitud;
        public string laLongitud;

        public PresentadorDetalleCompetencia(IContratoDetalleCompetencia laVista)
        {
            this.vista = laVista;
        }

        public void DetallarCompetencia(int elIdComp)
        {
            try
            {
                FabricaComandos laFabrica = new FabricaComandos();
                Comando<Entidad> comandoDetallarCompetencia = laFabrica.ObtenerComandoDetallarCompetencia(elIdComp);

                DominioSKD.Entidades.Modulo12.Competencia laCompetencia = (DominioSKD.Entidades.Modulo12.Competencia)comandoDetallarCompetencia.Ejecutar();
                

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
                vista.categEdadIniComp = laCompetencia.Categoria.Edad_inicial.ToString();
                vista.cateEdadFinComp = laCompetencia.Categoria.Edad_final.ToString();
                vista.categSexoComp = laCompetencia.Categoria.Sexo;
                vista.costoComp = "Bs." + " " + laCompetencia.Costo.ToString();
                laLatitud = laCompetencia.Ubicacion.Latitud.ToString();
                laLongitud = laCompetencia.Ubicacion.Longitud.ToString();
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M12_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M12_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M12_RecursoInterfazPresentador.alertaHtml + ex.Mensaje + M12_RecursoInterfazPresentador.alertaHtmlFinal;
        
            }
        }
    }
}
