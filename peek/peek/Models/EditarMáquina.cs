using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using peek.Controller;

namespace peek
{
    public class EditarMáquina
    {
        public bool EditarComputador (int IDComputador, int IDLab)
        {
            string sql = "UPDATE PEEK_COMPUTADOR SET id_lab = @LabMaquina where id_computador = @IDComputador";

            using (SqlConnection cnx = new Database().GetConexao())
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@IDComputador", IDComputador);
                    cmd.Parameters.AddWithValue("@LabMaquina", IDLab);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}