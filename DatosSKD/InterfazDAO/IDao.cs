using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.InterfazDAO
{
    /// <summary>
    /// Interfaz de un DAO
    /// </summary>
    /// <typeparam name="Parametro">Parametro manejado para el query</typeparam>
    /// <typeparam name="Resultado1">Resultado de del query en la bd</typeparam>
    /// <typeparam name="Resultado2">Resultado de del query en la bd</typeparam>
    public interface IDao<Parametro, Resultado1, Resultado2>
    {
        Resultado1 Agregar(Parametro parametro);
        Resultado1 Modificar(Parametro parametro);
        Resultado2 ConsultarXId(Parametro parametro);
        List<Resultado2> ConsultarTodos();
    }
}
