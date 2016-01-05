﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo16
{
    public interface IdaoEvento : IDao<Entidad, bool, Entidad>
    {
        new List<Entidad> ConsultarTodos();
        List<Entidad> ListarEvento();
        Entidad DetallarEvento(int Id_evento);
        new Entidad ConsultarXId(Entidad entidad);

    }
}
