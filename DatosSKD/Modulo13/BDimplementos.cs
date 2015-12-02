using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace DatosSKD.Modulo13
{
    public class BDimplementos
    {
        
        
        #region Listar Inventario

        public static  SqlDataReader D_Inventario()
        {
            // BDConexion laConexion;
            String query = "  select imp.imp_imagen, imp_nombre,imp.imp_tipo, imp.imp_marca, imp.imp_color,  imp.imp_estatus, imp_precio, imp_stockmin, inv_cantidad_total, d.doj_nombre  from implemento as imp, inventario as inv, dojo as d where imp.imp_id=inv.IMPLEMENTO_imp_id and d.doj_id=inv.DOJO_doj_id;";
            //laConexion = new BDConexion();
            BDConexion objeto_con= new BDConexion();
            SqlDataReader resultado = objeto_con.EjecutarQuery(query);               
            
            




            return resultado;

        }
        #endregion

    

       
    }
}
