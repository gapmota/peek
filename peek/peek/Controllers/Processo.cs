using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace peek.Controller
{
    public class Processo
    {
        public bool FinalizarProcesso(string processo, int idPc)
        {
            foreach (int pid in PegarPidsPorProcesso(processo, idPc))
            {
                using (SqlConnection cnx = new Database().GetConexao())
                {
                    cnx.Open();

                    string sql = @"INSERT INTO PEEK_FINALIZAR_PROCESSO (PID, NOME_PROCESSO, ID_COMPUTADOR) VALUES(
                                                                    @PID,@NOME,@ID_PC)";

                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@PID",pid);
                        cmd.Parameters.AddWithValue("@NOME", processo);
                        cmd.Parameters.AddWithValue("@ID_COMPUTADOR", idPc);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }

            }

            return false;
        }

        public List<int> PegarPidsPorProcesso(string processo, int idPc)
        {
            using (SqlConnection cnx = new Database().GetConexao())
            {
                cnx.Open();

                string sql = "SELECT PID FROM PEEK_PROCESSO WHERE ID_COMPUTADOR = @ID_PC AND NOME = @NOME";

                List<int> pids = new List<int>();

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID_PC", idPc);
                    cmd.Parameters.AddWithValue("@NOME", processo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            pids.Add(int.Parse(dr["PID"].ToString()));
                        }
                    }

                    return pids;
                }

            }
        }


    }
}