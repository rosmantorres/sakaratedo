
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace templateApp.GUI.Modulo13
{


    public partial class M13_EstadisticaEntrenamiento : System.Web.UI.Page
    {

        public string SuggestionList = "";

        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "13";

            string queryString = "SELECT per_nombre,per_apellido FROM Persona  ORDER BY per_nombre DESC";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDeDatosSKD"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(SuggestionList))
                            {
                                SuggestionList += "\"" + reader["per_nombre"].ToString() + "\"";
                            }
                            else
                            {
                                SuggestionList += ", \"" + reader["per_nombre"].ToString() + "\"";
                            }

                        }
                    }
                }
            }


           

        }

    }

}


