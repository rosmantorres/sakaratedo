﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo5;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD.Comandos.Modulo5;
using LogicaNegociosSKD;
using DominioSKD;


namespace Interfaz_Presentadores.Modulo5
{
    public class PresentadorLlenarCintas
    {

        private IContratoListarCintas vista;
 
        public PresentadorLlenarCintas(IContratoListarCintas vista)
        {
            this.vista = vista;
        }


        public void LlenarInformacion()
        {

            FabricaComandos _fabrica = new FabricaComandos();
            Comando<List<Entidad>> _comando = _fabrica.ObtenerEjecutarConsultarTodosCinta();
            List<Entidad> _miLista = _comando.Ejecutar();
      
            // en caso de q sea null... pero cuando trengas la excepcion tienes q quitarlo
            if (_miLista != null)
                this.llenarVista(_miLista);
       }

        private void llenarVista(List<Entidad> lista)
        {
            foreach (Entidad entidad in lista)
            {
                DominioSKD.Entidades.Modulo5.Cinta cinta = (DominioSKD.Entidades.Modulo5.Cinta)entidad;
                this.vista.llenarId(cinta.Id_cinta.ToString());
                this.vista.llenarColorNombre(cinta.Color_nombre);
                this.vista.llenarRango(cinta.Rango);
                this.vista.llenarClasificacion(cinta.Clasificacion);
                this.vista.llenarSignificado(cinta.Significado);
                this.vista.llenarOrden(cinta.Orden);
                this.vista.llenarOrganizacion(cinta.Organizacion.Nombre);
                this.vista.llenarBotones(cinta.Id_cinta);
                if (cinta.Status)
                    this.vista.llenarStatusActivo(cinta.Id_cinta);
                else
                    this.vista.llenarStatusInactivo(cinta.Id_cinta);

            }
        }
    }
}
