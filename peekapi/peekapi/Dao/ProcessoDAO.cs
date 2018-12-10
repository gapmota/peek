using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using peekapi.Models;

namespace peekapi.Dao
{
    public class ProcessoDAO
    {

        public List<Processo> PegarProcessos(int idComputador)
        {
            List<Processo> listProcessos = new List<Processo>();

            using (SqlConnection cnx = new Banco().PegarConexao())
            {

                string sql = "SELECT * FROM PEEK_PROCESSO WHERE ID_COMPUTADOR = @COD";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@COD", idComputador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            Processo p = new Processo();

                            p.IdProcesso = int.Parse(dr["ID_PROCESSO"].ToString());
                            p.IdComputador = int.Parse(dr["ID_COMPUTADOR"].ToString());
                            p.Pid = int.Parse(dr["PID"].ToString());
                            p.MemoriaRamUsada = long.Parse(dr["MEMORIA_RAM_USADA"].ToString());
                            p.TempoInicio = dr["TEMPO_INICIO"].ToString();
                            p.TempoModoUsuario = dr["TEMPO_MODO_USUARIO"].ToString();
                            p.Nome = dr["NOME"].ToString();
                            p.Usuario = dr["USUARIO"].ToString();
                            p.Prioridade = int.Parse(dr["PRIORIDADE"].ToString());
                            p.OpenFiles = long.Parse(dr["OPEN_FILES"].ToString());
                            p.GrupoID = dr["GRUPO_ID"].ToString();
                            p.Grupo = dr["GRUPO"].ToString();
                            p.DataCadastro = dr["DATA_CADASTRO"].ToString();
                            p.CommandLine = dr["COMMAND_LINE"].ToString();
                            p.Caminho = dr["CAMINHO"].ToString();
                            p.BytesLidos = long.Parse(dr["BYTES_LIDOS"].ToString());
                            p.BytesEscritos = long.Parse(dr["BYTES_ESCRITOS"].ToString());


                            listProcessos.Add(p);


                        }

                    }


                }

            }

            listProcessos.Sort((x, y) => (int)y.MemoriaRamUsada - (int)x.MemoriaRamUsada);

            return listProcessos;

        }


        public List<ProcessosInternet> PegarProcessosQueUsamInternet(int idUsuario)
        {
            List<ProcessosInternet> listProcessos = new List<ProcessosInternet>();

            using (SqlConnection cnx = new Banco().PegarConexao())
            {

                string sql = @"SELECT P.NOME, SUM(P.MEMORIA_RAM_USADA) MEMORIA_USADA, COUNT(P.NOME) QNT_PROCESSOS FROM dbo.PEEK_PROCESSO P
                                INNER JOIN dbo.PEEK_COMPUTADOR PC ON PC.ID_COMPUTADOR = P.ID_COMPUTADOR
                                INNER JOIN dbo.PEEK_LAB LAB ON LAB.ID_LAB = PC.ID_LAB
                                INNER JOIN dbo.PEEK_USUARIO U ON U.ID_USUARIO = LAB.ID_USUARIO
                                WHERE P.USA_INTERNET = 1
                                AND U.ID_USUARIO = @ID
                                AND CONVERT(int, DATEDIFF(DAY, p.data_cadastro, getdate())) = 0
								AND CONVERT(int, DATEDIFF(HOUR, p.data_cadastro, getdate()) % 24) = 0
								AND CONVERT(int, DATEDIFF(MINUTE, p.data_cadastro, getdate()) % 60.0) <= 5
                                GROUP BY P.NOME
                                ORDER BY MEMORIA_USADA DESC;";

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            ProcessosInternet p = new ProcessosInternet
                            {
                                Nome = dr["NOME"].ToString(),
                                MemoriaRamUsada = double.Parse(dr["MEMORIA_USADA"].ToString()),
                                QuantidadeProcessosAberto = int.Parse(dr["QNT_PROCESSOS"].ToString())

                            };

                            listProcessos.Add(p);


                        }
                        return listProcessos;
                    }


                }

            }


        }

        public List<ProcessosMaisUsados> PegarProcessosEmUsoTodosLab(int idUsuario)
        {
            List<ProcessosMaisUsados> listProcessos = new List<ProcessosMaisUsados>();

            using (SqlConnection cnx = new Banco().PegarConexao())
            {

                string sql = @"SELECT P.NOME, COUNT(P.NOME) AS QNT_PROCESSO,
                               SUM(P.MEMORIA_RAM_USADA) AS QNT_RAM
                                FROM PEEK_PROCESSO P INNER JOIN PEEK_COMPUTADOR PC
                                ON PC.ID_COMPUTADOR = P.ID_COMPUTADOR 
                                INNER JOIN PEEK_LAB L ON L.ID_LAB = PC.ID_LAB
                                INNER JOIN PEEK_USUARIO U ON U.ID_USUARIO = L.ID_USUARIO
                                WHERE U.ID_USUARIO = @ID
                                AND CONVERT(int, DATEDIFF(DAY, p.data_cadastro, getdate())) = 0
								AND CONVERT(int, DATEDIFF(HOUR, p.data_cadastro, getdate()) % 24) = 0
								AND CONVERT(int, DATEDIFF(MINUTE, p.data_cadastro, getdate()) % 60.0) <= 5
                                GROUP BY P.NOME
                                ORDER BY QNT_RAM DESC;";

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            ProcessosMaisUsados p = new ProcessosMaisUsados
                            {
                                Nome = dr["NOME"].ToString(),
                                QuantidadeProcessos = int.Parse(dr["QNT_PROCESSO"].ToString()),
                                MemoriaRamUsada = double.Parse(dr["QNT_RAM"].ToString())
                            };


                            listProcessos.Add(p);


                        }
                        return listProcessos;
                    }


                }

            }


        }


        public bool FinalizarProcesso(string processo, int idPc)
        {
            foreach (int pid in PegarPidsPorProcesso(processo, idPc))
            {
                using (SqlConnection cnx = new Banco().PegarConexao())
                {
             
                    string sql = @"INSERT INTO PEEK_FINALIZAR_PROCESSO (PID, NOME_PROCESSO, ID_COMPUTADOR) VALUES(
                                                                    @PID,@NOME,@ID_PC)";

                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@PID", pid);
                        cmd.Parameters.AddWithValue("@NOME", processo);
                        cmd.Parameters.AddWithValue("@ID_PC", idPc);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }

            }

            return false;
        }

        public List<int> PegarPidsPorProcesso(string processo, int idPc)
        {
            using (SqlConnection cnx = new Banco().PegarConexao())
            {
             
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