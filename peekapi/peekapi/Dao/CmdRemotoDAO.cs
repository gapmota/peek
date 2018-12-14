using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using peekapi.Models;
using System.Data.SqlClient;

namespace peekapi.Dao
{
    public class CmdRemotoDAO
    {
        public string InserirComandoCMD(int idComputador, string comando)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                string sql = "INSERT INTO peek_cmd_remoto(COMANDO,ID_COMPUTADOR) VALUES(@COMANDO,@ID_COMPUTADOR)";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@COMANDO", comando);
                    cmd.Parameters.AddWithValue("@ID_COMPUTADOR", idComputador);

                    if (cmd.ExecuteNonQuery() > 0)
                        return "aguardando retorno do comando";

                }

            }

            return "não foi possível inserir o comando: " + comando;
        }

        public string LimparComandoCMD(int idComputador)
        {

            foreach (int i in this.PegarIdComandoCmd(idComputador))
            {
                using (SqlConnection cnx = new Banco().PegarConexao())
                {
                    string sql = "DELETE FROM PEEK_CMD_REMOTO_CONTEUDO WHERE ID_CMD_REMOTO = @ID_CMD";
                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@ID_CMD", i);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            using (SqlConnection cnx2 = new Banco().PegarConexao())
                            {
                                string sql2 = "DELETE FROM PEEK_CMD_REMOTO WHERE ID_CMD_REMOTO = @ID_PC";
                                using (SqlCommand cmd2 = new SqlCommand(sql2, cnx2))
                                {
                                    cmd2.Parameters.AddWithValue("@ID_CMD", i);
                                    if (cmd2.ExecuteNonQuery() > 0)
                                        return "";
                                }
                            }
                        }

                    }

                }
            }
            return "";

        }

        public List<int> PegarIdComandoCmd(int idComputador)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                List<int> ids = new List<int>();
                string sql = "SELECT * FROM PEEK_CMD_REMOTO WHERE ID_COMPUTADOR = @ID_PC";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID_PC", idComputador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ids.Add(int.Parse(dr["ID_CMD_REMOTO"].ToString()));
                        }

                        return ids;
                    }

                }

            }

        }

    }
}