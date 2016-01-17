using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaz_Contratos.Modulo16;
using DominioSKD.Entidades.Modulo6;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Fabrica;
using DominioSKD;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo16;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;
using Interfaz_Presentadores.Master;
using DominioSKD.Entidades.Modulo1;

namespace Interfaz_Presentadores.Modulo16
{
   public class PresentadorListarMensualidad
    {
        #region Atributos
        private IContratoListarMensualidad vista;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarMensualidad(IContratoListarMensualidad laVista)
        {
            vista = laVista;
            
        }
        #endregion

        #region Metodo para el consultar de la lista de Mensualidades
        /// <summary>
        /// metodo para consultar la lista de las Mensualidades
        /// </summary>
        public void consultarMensualidades(int persona)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Instancio el comando para listar la matricula
                Comando<Entidad> comandoListarMensualidades = FabricaComandos.CrearComandoConsultarTodasMensualidades();

                // casteamos el parametro
                PersonaM1 param = new PersonaM1();
                param._Id = persona;
                comandoListarMensualidades.LaEntidad = param;

                //Invocamos el comando
                ListaMatricula com = (ListaMatricula)comandoListarMensualidades.Ejecutar();

                //Obtenemos cada factura para ponerla en la tabla
                foreach (Entidad aux in com.ListaMatriculas)
                {
                    //Casteamos la entidad como una matricula
                    Matricula item = (Matricula)aux;

                    //Creamos la nueva fila que ira en la tabla
                    TableRow fila = new TableRow();

                    //Nueva celda que tendra el id de la matricula 
                    TableCell celda = new TableCell();
                    celda.Text = item.Id.ToString();

                    //Agrego la Celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el identificador de la matricula
                    celda = new TableCell();
                    celda.Text = item.Identificador.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el costo de la matricula
                    celda = new TableCell();
                    celda.Text = item.Costo.ToString(); 

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra la ultima fecha de pago de la mensualidad 
                    celda = new TableCell();
                    celda.Text = item.UltimaFechaPago.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra mes de la mensualidad 
                    celda = new TableCell();
                    celda.Text = item.Mes.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Nueva celda que tendra el anio de la mensualidad
                    celda = new TableCell();
                    celda.Text = item.Anio.ToString();

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Celda que tendra los botones de Detallar y Agregar a Carrito
                    celda = new TableCell();
                    Button boton = new Button();
                    boton.ID = "Matricula-" + item.Id.ToString();
                    boton.Command += DetalleMatricula_Mat;
                    boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                    boton.CommandName = item.Id.ToString();                 
                    celda.Controls.Add(boton);

                    //Boton de Agregar a Carrito
                    boton = new Button();
                    boton.ID = "Agregar-" + item.Id.ToString();
                    boton.Click += AgregarCarrito;
                    boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
                    celda.Controls.Add(boton);                         

                    //Agrego la celda a la fila
                    fila.Cells.Add(celda);

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Agrego la fila a la tabla
                    vista.tablaMensualidades.Rows.Add(fila);

                }

            }
            #region Catches
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (ArgumentNullException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (FormatException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (OverflowException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);

            }

            #endregion
        }
        #endregion

        #region Metodos para el detalle de la Mensualidad
        /// <summary>
        /// Metodo del presentador que pinta el detalle en el modal
        /// </summary>
        /// <param name="evento">La Mensualidad que se ha de mostrar en detalle</param>
        public void DetalleMatricula_Mat(object sender, CommandEventArgs e)
        {
            try {
                    //Escribo en el logger la entrada a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    string id = e.CommandName;
                    Matricula matricula = new Matricula();
                    matricula.Id = int.Parse(id);
                    
                    // Casteamos
                    Matricula resultados = DetalleMatricula(matricula);

                    // Variables para imprimir en el modal
                    vista.LiteralDetallesMensualidades.Text = "</br>" + "<h3>Id Matricula</h3>" + "<label id='aux1' >" + resultados.Id + "</label>" +
                                                                      "<h3>Identificador</h3>" + "<label id='aux2' >" + resultados.Identificador + "</label>" +
                                                                      "<h3>Costo</h3>" + "<label id='aux3' >" + resultados.Costo + "</label>" +
                                                                      "<h3>Ultima Fecha de Pago</h3>" + "<label id='aux4' >" + resultados.UltimaFechaPago + "</label>" +
                                                                      "<h3>Nombre del Dojo al que pertenece</h3>" + "<label id='aux4' >" + resultados.Dojo_Matricula.Nombre_dojo + "</label>" ;

                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    // Ejecutamos el Script                                          
                    vista.ejecutarScript();    
                }
            #region Catches
            catch (PersonaNoValidaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

            }

            #endregion
        }

        /// <summary>
        /// Metodo del presentador que detalla la Mensualidad dado el id especifico
        /// </summary>
        /// <param name="matricula">La mensualidad que se ha de mostrar en detalle</param>
        public Matricula DetalleMatricula(Entidad matricula)
        {
            Comando<Entidad> DetalleMatricula = FabricaComandos.CrearComandoDetallarMatricula(matricula);
            Matricula laMatricula = (Matricula)DetalleMatricula.Ejecutar();
            return laMatricula;
        }

        #endregion

        #region Metodo para Agregar la Mensualidad Morosa al Carrito
        /// <summary>
        /// Metodo del presentador que agrega una mensualidad al carrito del usuario
        /// </summary>
        /// <param name="sender">El objeto que ejecuta la accion</param>
        /// <param name="e">El arreglo de Mensualidades</param>
        public void AgregarCarrito(object sender, EventArgs ec)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Persona que eventualmente la buscaremos por el session
                Entidad persona = (Persona)FabricaEntidades.ObtenerPersona();
                persona.Id= int.Parse(HttpContext.Current.Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

                //Transformo el boton y obtengo la informacion de que item quiero agregar y su ID
                Button aux = (Button)sender;
                String[] datos = aux.ID.Split('-');

                //Creo la fabrica y el evento asignandole su ID
                FabricaEntidades fabrica = new FabricaEntidades();
                Matricula matricula = (Matricula)fabrica.ObtenerMatricula();
                matricula.Id = int.Parse(datos[1]);

                //Respuesta de la accion de agregar
                bool respuesta = false;                

                /*Obtengo el comando que Agregara el Item y ejecuto la accion correspondiente,
                la cantidad siempre sera 1*/
                Comando<bool> comando = FabricaComandos.CrearComandoAgregarItem(persona, matricula, 3, 1);
                respuesta = comando.Ejecutar();

                 //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                
                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=3&exito=1",false);
                else
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=3&exito=0",false);
                
            }            
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               
            }
            catch (ItemInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               
            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                
            }
            catch (OpcionItemErroneoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
              
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
           
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
              
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
            
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);                
            }
        }
        #endregion

    }
}
