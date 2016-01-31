using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo5;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo5;
using LogicaNegociosSKD;
using DominioSKD;
using DominioSKD.Fabrica;
using System.Text.RegularExpressions;

namespace Interfaz_Presentadores.Modulo5
{
    public class PresentadorModificarCinta
    {
        private IContratoModificarCinta vista;

        public PresentadorModificarCinta(IContratoModificarCinta vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para ejecutar el comando ComboOrganizaciones y ontener la lista de organizaciones
        /// </summary>
        public void llenarCombo()
        {
            try
            {
                Comando<List<Entidad>> _comando = FabricaComandos.ObtenerEjecutarComboOrganizaciones();
                List<Entidad> _miLista = _comando.Ejecutar();
                this.asignarInformacionCombo(_miLista);
            }
            catch (ExcepcionesSKD.Modulo5.ListaVaciaExcepcion ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Método para asiganar la informacion en el Combo con las organizaciones 
        /// </summary>
        private void asignarInformacionCombo(List<Entidad> listaOrganizaciones)
        {

            this.vista.agregarOrganizacionCombo(RecursoPresentadorM5.valorNulo, RecursoPresentadorM5.opcionDefecto);
            foreach (Entidad entidad in listaOrganizaciones)
            {
                DominioSKD.Entidades.Modulo3.Organizacion org = (DominioSKD.Entidades.Modulo3.Organizacion)entidad;

                this.vista.agregarOrganizacionCombo(org.Id_organizacion.ToString(), org.Nombre);

            }
            this.vista.agregarOrganizacionCombo(RecursoPresentadorM5.valorOtro, RecursoPresentadorM5.opcionOtro);

        }

        public void llenarModificar()
        {
            DominioSKD.Entidades.Modulo5.Cinta cinta = (DominioSKD.Entidades.Modulo5.Cinta)FabricaEntidades.ObtenerCinta_M5();
            cinta.Id_cinta = this.vista.obtenerIdCInta;

            Comando<Entidad> _comando = FabricaComandos.ObtenerEjecutarConsultarXIdCinta(cinta);
            Entidad _miEntidad = _comando.Ejecutar();
            DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)_miEntidad;

            this.vista.obtenerColorCinta = laCinta.Color_nombre;
            this.vista.obtenerRango= laCinta.Rango;
            this.vista.obtenerCategoria = laCinta.Clasificacion;
            this.vista.obtenerSignificado = laCinta.Significado;
            this.vista.obtenerOrden = laCinta.Orden.ToString();
            this.vista.obtenerIdOrganizacion = laCinta.Organizacion.Id_organizacion;
        }


        /// <summary>
        /// Método para validar la informacion de la cinta antes de agregarla 
        /// </summary>
        public void ValidarExpresionesReg(DominioSKD.Entidades.Modulo5.Cinta laCinta, string ordenString)
        {
            //Validar las expresionnes regulares
            Regex rex = new Regex(RecursoPresentadorM5.expresionNombre);
            Regex rex2 = new Regex(RecursoPresentadorM5.expresionNumero);
            Regex rex3 = new Regex(RecursoPresentadorM5.expresionNombreNumero);

            if (!rex.IsMatch(laCinta.Color_nombre))
                throw new ExcepcionesSKD.Modulo5.ExpresionesRegularesException(RecursoPresentadorM5.Codigo_Error_Expresion_Regular,
                                     RecursoPresentadorM5.Mensaje_Error_Expresion_Regular_Color, new Exception());
            else if (!rex3.IsMatch(laCinta.Rango))
                throw new ExcepcionesSKD.Modulo5.ExpresionesRegularesException(RecursoPresentadorM5.Codigo_Error_Expresion_Regular,
                     RecursoPresentadorM5.Mensaje_Error_Expresion_Regular_Rango, new Exception());
            else if (!rex.IsMatch(laCinta.Clasificacion))
                throw new ExcepcionesSKD.Modulo5.ExpresionesRegularesException(RecursoPresentadorM5.Codigo_Error_Expresion_Regular,
                    RecursoPresentadorM5.Mensaje_Error_Expresion_Regular_Clasificacion, new Exception());
            else if (!rex.IsMatch(laCinta.Significado))
                throw new ExcepcionesSKD.Modulo5.ExpresionesRegularesException(RecursoPresentadorM5.Codigo_Error_Expresion_Regular,
                     RecursoPresentadorM5.Mensaje_Error_Expresion_Regular_Significado, new Exception());
            else if (!rex2.IsMatch(ordenString))
                throw new ExcepcionesSKD.Modulo5.ExpresionesRegularesException(RecursoPresentadorM5.Codigo_Error_Expresion_Regular,
                   RecursoPresentadorM5.Mensaje_Error_Expresion_Regular_Orden, new Exception());
        }

        /// <summary>
        /// Método para obtener los valores de la vista y ejecutar el comando para modificar la cinta
        /// </summary>
        public void ModificarValoresCinta()
        {
            DominioSKD.Entidades.Modulo5.Cinta laCinta = (DominioSKD.Entidades.Modulo5.Cinta)FabricaEntidades.ObtenerCinta_M5();
            DominioSKD.Entidades.Modulo3.Organizacion laOrganizacion = (DominioSKD.Entidades.Modulo3.Organizacion)FabricaEntidades.ObtenerOrganizacion_M3();

           try
           {
               string ordenString;
                 
            laCinta.Id_cinta = this.vista.obtenerIdCInta;
            laCinta.Color_nombre = this.vista.obtenerColorCinta;
            laCinta.Rango = this.vista.obtenerRango;
            laCinta.Clasificacion = this.vista.obtenerCategoria;
            laCinta.Significado = this.vista.obtenerSignificado;
            ordenString = this.vista.obtenerOrden;
            laOrganizacion.Id_organizacion = this.vista.obtenerIdOrganizacion;
            laOrganizacion.Nombre = this.vista.obtenerNombreOrganizacion;
            laCinta.Organizacion = laOrganizacion;

            this.ValidarExpresionesReg(laCinta, ordenString);
                laCinta.Orden = Int32.Parse(ordenString);

                    Comando<bool> _comando = FabricaComandos.ObtenerEjecutarModificarCinta(laCinta);
                    bool resultado = _comando.Ejecutar();
                    if (resultado)
                       this.vista.Respuesta();

           }
           catch (ExcepcionesSKD.Modulo5.OrdenCintaRepetidoException ex)
           {
               this.vista.alertaModificarFallidoOrden(ex);
           }
           catch (Exception ex)
           {
               this.vista.alertaModificarFallido(ex);
           }
        }
    }
}
