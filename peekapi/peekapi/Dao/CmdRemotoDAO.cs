using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using peekapi.Models;
using System.Data.SqlClient;
using System.Threading;

namespace peekapi.Dao
{
    public class CmdRemotoDAO
    {
        public List<CmdRemoto> InserirComandoCMD(int idComputador, string comando)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                string sql = "INSERT INTO peek_cmd_remoto(COMANDO,ID_COMPUTADOR) VALUES(@COMANDO,@ID_COMPUTADOR)";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@COMANDO", comando);
                    cmd.Parameters.AddWithValue("@ID_COMPUTADOR", idComputador);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        int id_cmd = PegarId(idComputador, comando);
                        if (id_cmd != -1)
                        {
                            if (FoiExecutado(id_cmd))
                            {
                                return PegarRetorno(id_cmd, comando);
                            }
                        }
                        
                    }
                        

                }

            }

            return null;
        }

        public bool FoiExecutado(int id_cmd)
        {

            while (true)
            {

                using (SqlConnection cnx = new Banco().PegarConexao())
                {
                    List<CmdRemoto> cmds = new List<CmdRemoto>();
                    string sql = "SELECT * FROM PEEK_CMD_REMOTO WHERE ID_CMD_REMOTO = @ID_CMD AND JA_EXECUTADO = 'N'";
                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@ID_CMD", id_cmd);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                return true;
                            }
                        }

                    }

                }

                Thread.Sleep(1000);
            }
        }

        public List<CmdRemoto> PegarRetorno(int id, string comando)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                List<CmdRemoto> cmds = new List<CmdRemoto>();
                string sql = "SELECT * FROM PEEK_CMD_REMOTO_CONTEUDO WHERE ID_CMD_REMOTO = @ID_CMD";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID_CMD", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {




                        string cmd_return = "";
                        if (dr.Read())
                        {


                            cmd_return = dr["RETORNO_CMD"].ToString();

                        }

                        string[] cmd_split = cmd_return.Split('\n');



                        for (int i = 0; i < cmd_split.Length; i++)
                        {
                            CmdRemoto c = new CmdRemoto();
                            c.Comando = comando;
                            c.Retorno = cmd_split[i];

                            cmds.Add(c);
                        }




                        return cmds;
                    }

                }

            }

        }

        public int PegarId(int idComputador, string comando)
        {
            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                 string sql = "SELECT TOP 1 * FROM PEEK_CMD_REMOTO WHERE COMANDO = @COMANDO AND ID_COMPUTADOR = @ID AND JA_EXECUTADO = 'S' ORDER BY ID_CMD_REMOTO DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@COMANDO",comando);
                    cmd.Parameters.AddWithValue("@ID", idComputador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return int.Parse(dr["ID_CMD_REMOTO"].ToString());
                        }
                        return -1;
                    }

                }

            }

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