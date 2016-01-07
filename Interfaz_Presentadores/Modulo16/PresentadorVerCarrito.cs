using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo16;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo9;
using DominioSKD.Entidades.Modulo6;

namespace Interfaz_Presentadores.Modulo16
{
    public class PresentadorVerCarrito
    {
        #region Atributos
        //Interfaz a usar de su vista
        IcontratoVerCarrito laVista;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase que recibe la interfaz
        /// </summary>
        /// <param name="laVista">Interfaz que es la vista a la que se manipulara</param>
        public PresentadorVerCarrito(IcontratoVerCarrito laVista)
        {
            this.laVista = laVista;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo del presentador que obtiene el carrito de una persona
        /// </summary>
        /// <param name="persona">La Persona a la que se desea ver su carrito</param>
        public void LlenarTabla(Entidad persona)
        {
            //Instancio el comando para ver el carrito, obtengo el carrito de la persona y casteo
            Comando<Entidad> VerCarrito = FabricaComandos.CrearComandoVerCarrito(persona);
            Carrito elCarrito = (Carrito)VerCarrito.Ejecutar();

            //Obtenemos los implementos del carrito de una persona para añadir sus datos al codigo HTML
            string tablaImplementosHTML = "";
            foreach(KeyValuePair<Entidad, int> aux in elCarrito.ListaImplemento)
            {

            }
            laVista.tablaImplemento.Text = tablaImplementosHTML;

            //Obtenemos los eventos del carrito de una persona para añadir sus datos al codigo HTML
            string tablaEventosHTML = "";
            foreach (KeyValuePair<Entidad, int> aux in elCarrito.Listaevento)
            {

            }
            laVista.tablaEvento.Text = tablaEventosHTML;

            //Obtenemos las matriculas del carrito de una persona para añadir sus datos al codigo HTML
            string tablaMatriculasHTML = "";
            foreach (KeyValuePair<Entidad, int> aux in elCarrito.Listamatricula)
            {

            }
            laVista.tablaMatricula.Text = tablaMatriculasHTML;
        }

        /// <summary>
        /// Metodo del presentador que registra el pago de los productos que hay en el carrito de una persona
        /// </summary>
        /// <param name="persona">La persona que desea comprar los productos</param>
        /// <param name="pago">El tipo de pago con el cual realizo la transaccion</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool RegistrarPago(Entidad persona, String pago)
        {
            //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso
            Comando<bool> registrarPago = FabricaComandos.CrearComandoRegistrarPago(persona, pago);
            bool respuesta = registrarPago.Ejecutar();

            //Retorno la respuesta
            return respuesta;
        }

        /// <summary>
        /// Metodo del presentador que modifica la cantidad de un item determinado en el carrito de una persona
        /// </summary>
        /// <param name="persona">La persona a la que se le modificara el carrito</param>
        /// <param name="objeto">El item en especifico el cual se alterara</param>
        /// <param name="TipoObjeto">indica si se trata de un implemento, evento o matricula</param>
        /// <param name="cantidad">Cantidad nueva que se quiere de ese item</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool ModificarCarrito(Entidad persona, Entidad objeto, int TipoObjeto, int cantidad)
        {
            //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso
            Comando<bool> ModificarCarrito = FabricaComandos.CrearComandoModificarCarrito(persona, objeto, TipoObjeto, cantidad);
            bool respuesta = ModificarCarrito.Ejecutar();

            //Retorno la respuesta
            return respuesta;
        }
        #endregion
    }
}
