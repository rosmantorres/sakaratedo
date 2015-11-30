using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace LogicaNegociosSKD.Modulo9
{
    public class LogicaEvento
    {
        #region Constructores

        public LogicaEvento()
        { }
        #endregion

        #region Metodos

        public bool CrearEvento(Evento evento)
        {
            
            throw new NotImplementedException();
        }

        public List<Evento> ListarEventos()
        {

            throw new NotImplementedException();
        }

        public Evento ConsultarEvento(String idEvento)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que valida que los campos tipo String solo acepten letras mayusculas, minusculas y numeros
        /// </summary>
        /// <param name="cadena">Cadena a validar</param>
        /// <returns>verdadero o falso</returns>

        public bool ValidarCaracteres(String cadena)
        {
            int contador = 0;
            String comparar = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm123456789 ";
            for (int i=0;i<cadena.Length;i++)
            {
                Console.Out.WriteLine(i);
                Console.Out.WriteLine(cadena.Length);
                Console.Out.WriteLine(cadena[i]);
                Boolean resultado = comparar.Contains(cadena[i]);
                if (resultado == true)
                {
                    contador++;
                }
            }
            Console.Out.WriteLine(contador);
            if (contador == cadena.Length)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metodo que valida que el costo del evento este compuesto de numeros y que tenga decimales
        /// </summary>
        /// <param name="numero">El costo del proyecto</param>
        /// <returns>Verdadero o Falso</returns>

        public bool ValidarCosto(double numero)
        {
            String comparar = "123456789,";
            String cadena = numero.ToString();
            int contador = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                Console.Out.WriteLine(i);
                Console.Out.WriteLine(cadena.Length);
                Console.Out.WriteLine(cadena[i]);
                Boolean resultado = comparar.Contains(cadena[i]);
                if (resultado == true)
                {
                    contador++;
                }
            }
            Console.Out.WriteLine(contador);
            if (contador == cadena.Length)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metodo que convierte las fechas de String a DateTime
        /// </summary>
        /// <param name="fecha">String Fecha</param>
        /// <returns>la fecha en formato DateTime</returns>

        public DateTime ConvertirFecha(String fecha)
        {
            String[] convertirFechaInicio = fecha.Split('/');
            DateTime fechaResultado = new DateTime(int.Parse(convertirFechaInicio[2]), int.Parse(convertirFechaInicio[1]), int.Parse(convertirFechaInicio[0]),0,0,0);
            return fechaResultado;
        }

        /// <summary>
        /// Meetodo que valida que la fecha cumpla con el formato para BD y que no posea Letras
        /// </summary>
        /// <param name="fecha">fecha a validar</param>
        /// <returns>Verdadero o Falso</returns>

        public bool ValidarFormatoFecha(String fecha)
        {
            int contador =0 ;
            String comparar= "0123456789/-";
            for (int i = 0; i < fecha.Length; i++)
            {
                Console.Out.WriteLine(i);
                Console.Out.WriteLine(fecha.Length);
                Console.Out.WriteLine(fecha[i]);
                Boolean resultado = comparar.Contains(fecha[i]);
                if (resultado == true)
                {
                    contador++;
                }

            }
            Console.Out.WriteLine(contador);
            if (contador == fecha.Length)
                return true;
            else
                return false;

        }

        /// <summary>
        /// Metodo que valida que la fecha fin sea mayor que la fecha inicio
        /// </summary>
        /// <param name="fechaInicio">fecha inicio</param>
        /// <param name="fechaFin">fecha fin</param>
        /// <returns>verdadero o falso</returns>

        public bool ValidarFechaFinMayor(String fechaInicio, String fechaFin)
        {
            DateTime fechaI = this.ConvertirFecha(fechaInicio);
            DateTime fechaF = this.ConvertirFecha(fechaFin);
            if (fechaI.Date <= fechaF.Date)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
        #endregion

    }
}
