using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo9;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Modulo9
{
    /// <summary>
    /// Clase que maneja la logica para el Modulo de Eventos
    /// </summary>
    public class LogicaEvento
    {
        #region Constructores

        public LogicaEvento()
        { }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que crea un evento
        /// </summary>
        /// <param name="evento">El evento a crear</param>
        /// <returns>Verdadero o Falso</returns>

        public bool CrearEvento(Evento evento)
        {
            try
            {
                if (ValidarCaracteres(evento.Nombre))
                {
                    Console.Out.WriteLine("Nombre Valido");
                    if (ValidarCaracteres(evento.Descripcion))
                    {
                        Console.Out.WriteLine("Descripcion Valido");
                        if (ValidarCosto(evento.Costo))
                        {
                            Console.Out.WriteLine("Costo Valido");
                            String dia = (evento.Horario.FechaInicio.Date.Day.ToString());
                            String mes = (evento.Horario.FechaInicio.Date.Month.ToString());
                            String año = (evento.Horario.FechaInicio.Date.Year.ToString());
                            String fechaInicio = String.Concat(dia + "/" + mes + "/" + año);
                            if (ValidarFormatoFecha(fechaInicio))
                            {
                                Console.Out.WriteLine("FechaI Valido");
                                dia = (evento.Horario.FechaFin.Date.Day.ToString());
                                mes = (evento.Horario.FechaFin.Date.Month.ToString());
                                año = (evento.Horario.FechaFin.Date.Year.ToString());
                                String fechaFin = String.Concat(dia + "/" + mes + "/" + año);
                                if (ValidarFormatoFecha(fechaFin))
                                {
                                    Console.Out.WriteLine("FechaF Valido");
                                    if (ValidarFechaFinMayor(fechaInicio, fechaFin))
                                    {
                                        Console.Out.WriteLine("FechaI <= FechaF");
                                        BDEvento baseDeDatosEvento = new BDEvento();

                                        return baseDeDatosEvento.CrearEvento(evento);

                                    }
                                }
                            }
                        }
                    }

                }

            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;

        }

        /// <summary>
        /// MEtodo Que permite Crear un evento Con un nuevo tipo de evento
        /// </summary>
        /// <param name="evento">Evento a agregar</param>
        /// <returns>Verdadero o Falso</returns>

        public bool CrearEventoConTipo(Evento evento)
        {
            try
            {
                if (ValidarCaracteres(evento.Nombre))
                {
                    Console.Out.WriteLine("Nombre Valido");
                    if (ValidarCaracteres(evento.Descripcion))
                    {
                        Console.Out.WriteLine("Descripcion Valido");
                        if (ValidarCosto(evento.Costo))
                        {
                            Console.Out.WriteLine("Costo Valido");
                            String dia = (evento.Horario.FechaInicio.Date.Day.ToString());
                            String mes = (evento.Horario.FechaInicio.Date.Month.ToString());
                            String año = (evento.Horario.FechaInicio.Date.Year.ToString());
                            String fechaInicio = String.Concat(dia + "/" + mes + "/" + año);
                            if (ValidarFormatoFecha(fechaInicio))
                            {
                                Console.Out.WriteLine("FechaI Valido");
                                dia = (evento.Horario.FechaFin.Date.Day.ToString());
                                mes = (evento.Horario.FechaFin.Date.Month.ToString());
                                año = (evento.Horario.FechaFin.Date.Year.ToString());
                                String fechaFin = String.Concat(dia + "/" + mes + "/" + año);
                                if (ValidarFormatoFecha(fechaFin))
                                {
                                    Console.Out.WriteLine("FechaF Valido");
                                    if (ValidarFechaFinMayor(fechaInicio, fechaFin))
                                    {
                                        Console.Out.WriteLine("FechaI <= FechaF");
                                        if (ValidarCaracteres(evento.TipoEvento.Nombre))
                                        {
                                            Console.Out.WriteLine("Nombre de Evento Valido ");
                                            
                                            BDEvento baseDeDatosEvento = new BDEvento();

                                            return baseDeDatosEvento.CrearEvento(evento);
                                        }

                                    }
                                }
                            }
                        }
                    }

                }

            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;

        }

        /// <summary>
        /// Metodo que retorna de la BD todos los eventos
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        public List<Evento> ListarEventos()
        {

            BDEvento baseDeDatosEvento = new BDEvento();
            List<Evento> listaEventos = baseDeDatosEvento.ListarEventos();
            return listaEventos;
        }

        public bool ModificarEvento(Evento evento)
        {
            try
            {
                if (ValidarCaracteres(evento.Nombre))
                {
                    Console.Out.WriteLine("Nombre Valido");
                    if (ValidarCaracteres(evento.Descripcion))
                    {
                        Console.Out.WriteLine("Descripcion Valido");
                        if (ValidarCosto(evento.Costo))
                        {
                            Console.Out.WriteLine("Costo Valido");
                            String dia = (evento.Horario.FechaInicio.Date.Day.ToString());
                            String mes = (evento.Horario.FechaInicio.Date.Month.ToString());
                            String año = (evento.Horario.FechaInicio.Date.Year.ToString());
                            String fechaInicio = String.Concat(dia + "/" + mes + "/" + año);
                            if (ValidarFormatoFecha(fechaInicio))
                            {
                                Console.Out.WriteLine("FechaI Valido");
                                dia = (evento.Horario.FechaFin.Date.Day.ToString());
                                mes = (evento.Horario.FechaFin.Date.Month.ToString());
                                año = (evento.Horario.FechaFin.Date.Year.ToString());
                                String fechaFin = String.Concat(dia + "/" + mes + "/" + año);
                                if (ValidarFormatoFecha(fechaFin))
                                {
                                    Console.Out.WriteLine("FechaF Valido");
                                    if (ValidarFechaFinMayor(fechaInicio, fechaFin))
                                    {
                                        Console.Out.WriteLine("FechaI <= FechaF");
                                        BDEvento baseDeDatosEvento = new BDEvento();

                                        return baseDeDatosEvento.CrearEvento(evento);

                                    }
                                }
                            }
                        }
                    }

                }

            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;

        }
        /// <summary>
        /// Metodo que retorna de la BD un evento dado el ID
        /// </summary>
        /// <param name="idEvento">Id del evento</param>
        /// <returns>Objeto de tipo evento</returns>

        public Evento ConsultarEvento(String idEvento)
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            return baseDeDatosEvento.ConsultarEvento(idEvento);
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
                /*Console.Out.WriteLine(i);
                Console.Out.WriteLine(cadena.Length);
                Console.Out.WriteLine(cadena[i]);*/
                Boolean resultado = comparar.Contains(cadena[i]);
                if (resultado == true)
                {
                    contador++;
                }
            }
            //Console.Out.WriteLine(contador);
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
                /*Console.Out.WriteLine(i);
                Console.Out.WriteLine(cadena.Length);
                Console.Out.WriteLine(cadena[i]);*/
                Boolean resultado = comparar.Contains(cadena[i]);
                if (resultado == true)
                {
                    contador++;
                }
            }
            //Console.Out.WriteLine(contador);
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
                /*Console.Out.WriteLine(i);
                Console.Out.WriteLine(fecha.Length);
                Console.Out.WriteLine(fecha[i]);*/
                Boolean resultado = comparar.Contains(fecha[i]);
                if (resultado == true)
                {
                    contador++;
                }

            }
            //Console.Out.WriteLine(contador);
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

        /// <summary>
        /// Metodo que retorna todos los tipos de evento
        /// </summary>
        /// <returns>Lista de Tipos de Eventos</returns>
        public List<TipoEvento> ConsultarTiposEventos()
        {
            BDEvento baseDeDatosEvento = new BDEvento();
            return baseDeDatosEvento.ListarTiposEventos();

        }
        
        
        #endregion

    }
}
