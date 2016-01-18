using System;


namespace Interfaz_Contratos.Modulo5
{
    public interface IContratoListarCintas
    {

        void llenarId(string id);
        void llenarColorNombre(string colorNombre);
        void llenarRango(string rango);
        void llenarClasificacion(string clasificacion);
        void llenarSignificado(string significado);
        void llenarOrden(int orden);
        void llenarOrganizacion(string organizacion);
        void llenarBotones(int id);
        void llenarStatusActivo(int id);
        void llenarStatusInactivo(int id);
    }
}
