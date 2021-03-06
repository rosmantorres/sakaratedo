﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo15;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo15;
using LogicaNegociosSKD.Fabrica;
using ExcepcionesSKD.Modulo15.ExcepcionPresentador;
using ExcepcionesSKD;


namespace Interfaz_Presentadores.Modulo15
{
    public  class PresentadorConsultarImplemento
    {

        /// <summary>
        /// Método de presentador que consulta implemento
        /// </summary>
         private IContratoConsultarImplemento _vista;

         public PresentadorConsultarImplemento(IContratoConsultarImplemento _vista)
        {
            this._vista = _vista;
        }

         public List<Entidad> cargarListaImplementos(Entidad dojo)
         {
             try
             {
                 Comando<List<Entidad>> comando;
                 comando = FabricaComandos.ObtenerComandoConsultar();
                 comando.LaEntidad = dojo;
                 return comando.Ejecutar();
             }
             catch (ExcepcionPresentadorConsultarImplemento ex)
             {
                 ex = new ExcepcionPresentadorConsultarImplemento(M15_RecursoInterfazPresentador.ErrorPConsultar, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;

             }

             catch (ExceptionSKD ex)
             {
                 ex = new ExcepcionesSKD.ExceptionSKD(M15_RecursoInterfazPresentador.ErrorPOperacion, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }

             catch (Exception ex)
             {

                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }
         }

         public List<Entidad> cargarListaImplementos2(Entidad dojo)

         /// <summary>
         /// Método de presentador que carga una lista de implementos segun el dojo
         /// </summary>
         {
             try{
             Comando<List<Entidad>> comando;
             comando = FabricaComandos.ObtenerComandoConsultar2();
             comando.LaEntidad = dojo;
             return comando.Ejecutar();

         }
             catch (ExcepcionPresentadorConsultarImplemento ex)
             {
                 ex = new ExcepcionPresentadorConsultarImplemento(M15_RecursoInterfazPresentador.ErrorPConsultar, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;

             }

             catch (ExceptionSKD ex)
             {
                 ex = new ExcepcionesSKD.ExceptionSKD(M15_RecursoInterfazPresentador.ErrorPOperacion, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }

             catch (Exception ex)
             {

                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }
         }

         public bool eliminarImplemento(string implemento ,int dojoid)
         {

             /// <summary>
             /// Método de presentador que elimina un implemento
             /// </summary>
             try
             {
                 Comando<bool> comando;
                 Entidad implementoEliminar = FabricaEntidades.ObtenerImplemento();
                 Entidad dojoEliminar = FabricaEntidades.tenerDojo();
                 comando = FabricaComandos.ObtenerComandoEliminarImplemento();
                 ((Implemento)implementoEliminar).Id_Implemento = Convert.ToInt32(implemento);
                 ((Dojo)dojoEliminar).Dojo_Id = dojoid;
                 comando.LaEntidad = implementoEliminar;
                 ((ComandoEliminarImplemento)comando).Dojo = dojoEliminar;
                 return comando.Ejecutar();
             }

             catch (ExcepcionPresentadorConsultarImplemento ex)
             {
                 ex = new ExcepcionPresentadorConsultarImplemento(M15_RecursoInterfazPresentador.ErrorPConsultar, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;

             }

             catch (ExceptionSKD ex)
             {
                 ex = new ExcepcionesSKD.ExceptionSKD(M15_RecursoInterfazPresentador.ErrorPOperacion, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }

             catch (Exception ex)
             {

                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }
         }

      

         public int usuarioDojo(Entidad usuario) {

             /// <summary>
             /// Método de presentador que con el usuario te devuelve el dojo
             /// </summary>
             
             try
             {
                 Comando<int> comando = FabricaComandos.ObtenerComandoUsuarioDojo();
                 comando.LaEntidad = usuario;
                 return comando.Ejecutar();
             }

             catch (ExcepcionPresentadorConsultarImplemento ex)
             {
                 ex = new ExcepcionPresentadorConsultarImplemento(M15_RecursoInterfazPresentador.ErrorPConsultar, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;

             }

             catch (ExceptionSKD ex)
             {
                 ex = new ExcepcionesSKD.ExceptionSKD(M15_RecursoInterfazPresentador.ErrorPOperacion, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }

             catch (Exception ex)
             {

                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }
         }
         public Entidad obtenerDojoXId(Entidad dojo)
         {
             /// <summary>
             /// Método de presentador para obtener el dojo por Id
             /// </summary>
             try
             {
                 Comando<Entidad> comando = FabricaComandos.ObtenerComandoDojo();
                 comando.LaEntidad = dojo;
                 return comando.Ejecutar();
             }

             catch (ExcepcionPresentadorConsultarImplemento ex)
             {
                 ex = new ExcepcionPresentadorConsultarImplemento(M15_RecursoInterfazPresentador.ErrorPConsultar, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;

             }

             catch (ExceptionSKD ex)
             {
                 ex = new ExcepcionesSKD.ExceptionSKD(M15_RecursoInterfazPresentador.ErrorPOperacion, new Exception());
                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }

             catch (Exception ex)
             {

                 Logger.EscribirError(M15_RecursoInterfazPresentador.ErrorPConsultar, ex);
                 throw ex;
             }
         }


   //     public Entidad obtnerDojo(string usuario)
     //    {
         //    FabricaComandos fabrica = new FabricaComandos();
       //      Comando<Entidad> comando;
          //   comando = fabrica.obt
            // return comando.Ejecutar();

//         }
      
      
         



    }
}
