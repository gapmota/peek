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

            if (ComandoJaInseridoRecentemente(idComputador, comando))
            {
                int id_cmd = PegarId(idComputador, comando);
                return PegarRetorno(id_cmd, comando);
            }
                

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
                            if (FoiExecutado(comando, id_cmd))
                            {
                                return PegarRetorno(id_cmd, comando);
                            }
                        }

                    }


                }

            }

            return null;
        }

        public bool FoiExecutado(string comando, int id_cmd)
        {

            while (true)
            {

                using (SqlConnection cnx = new Banco().PegarConexao())
                {
                    List<CmdRemoto> cmds = new List<CmdRemoto>();
                    string sql = "SELECT TOP 1 * FROM PEEK_CMD_REMOTO WHERE ID_CMD_REMOTO = @ID_CMD AND JA_EXECUTADO = 'S' AND COMANDO = @CMD ORDER BY ID_CMD_REMOTO DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@ID_CMD", id_cmd);
                        cmd.Parameters.AddWithValue("@CMD", comando);

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
                            c.IdCmdRemoto = id;
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
                string sql = "SELECT MAX(ID_CMD_REMOTO) as ID_CMD_REMOTO FROM PEEK_CMD_REMOTO WHERE COMANDO = @COMANDO AND ID_COMPUTADOR = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@COMANDO", comando);
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

            foreach (CmdRemoto i in this.PegarIdComandoCmd(idComputador))
            {
                using (SqlConnection cnx = new Banco().PegarConexao())
                {
                    string sql = "DELETE FROM PEEK_CMD_REMOTO_CONTEUDO WHERE ID_CMD_REMOTO = @ID_CMD";
                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@ID_CMD", i.IdCmdRemoto);

                        //apagar os cmd
                        {
                            using (SqlConnection cnx2 = new Banco().PegarConexao())
                            {
                                string sql2 = "DELETE FROM PEEK_CMD_REMOTO WHERE ID_CMD_REMOTO = @ID_PC";
                                using (SqlCommand cmd2 = new SqlCommand(sql2, cnx2))
                                {
                                    cmd2.Parameters.AddWithValue("@ID_PC", idComputador);
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

        public List<CmdRemoto> PegarIdComandoCmd(int idComputador)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                List<CmdRemoto> ids = new List<CmdRemoto>();
                string sql = "SELECT * FROM PEEK_CMD_REMOTO WHERE ID_COMPUTADOR = @ID_PC";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID_PC", idComputador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CmdRemoto cr = new CmdRemoto();

                            cr.IdCmdRemoto = int.Parse(dr["ID_CMD_REMOTO"].ToString());
                            cr.Comando = dr["COMANDO"].ToString();

                            ids.Add(cr);
                        }

                        return ids;
                    }

                }

            }

        }

        public bool ComandoJaInseridoRecentemente(int id_pc, string comando)
        {


            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                List<CmdRemoto> cmds = new List<CmdRemoto>();
                string sql = @"SELECT CONVERT(int, DATEDIFF(MINUTE, data_cadastro, getdate()) % 60) FROM PEEK_CMD_REMOTO
                               WHERE ID_COMPUTADOR = @ID_PC
                               AND COMANDO = @CMD
                               AND CONVERT(int, DATEDIFF(DAY, data_cadastro, getdate())) <= 0
                               AND CONVERT(int, DATEDIFF(HOUR, data_cadastro, getdate()) % 24) <= 0
                               AND CONVERT(int, DATEDIFF(MINUTE, data_cadastro, getdate()) % 60) <= 2
                              ";

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID_PC", id_pc);
                    cmd.Parameters.AddWithValue("@CMD", comando);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return true;
                        }

                        return false;
                    }

                }

            }
        }

        public List<CmdRemoto> TodosRetornos(List<CmdRemoto> id_cmd)
        {

            List<CmdRemoto> c = new List<CmdRemoto>();

            foreach(CmdRemoto i in id_cmd)
            {
                using (SqlConnection cnx = new Banco().PegarConexao())
                {
                    
                    string sql = "SELECT * FROM PEEK_CMD_REMOTO_CONTEUDO WHERE ID_CMD_REMOTO = @ID_CMD";
                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@ID_CMD", i.IdCmdRemoto);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CmdRemoto cr = new CmdRemoto();

                                cr.IdCmdRemoto = int.Parse(dr["ID_CMD_REMOTO"].ToString());
                                cr.Comando = i.Comando;
                                cr.Retorno = dr["RETORNO_CMD"].ToString();

                                c.Add(cr);

                            }

                            
                        }

                    }

                }

            }

            return c;

        }


    }
}