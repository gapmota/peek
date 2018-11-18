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

                            Processo p = new Processo
                            {
                                IdProcesso = int.Parse(dr["ID_PROCESSO"].ToString()),
                                IdComputador = int.Parse(dr["ID_COMPUTADOR"].ToString()),
                                Pid = int.Parse(dr["PID"].ToString()),
                                MemoriaRamUsada = long.Parse(dr["MEMORIA_RAM_USADA"].ToString()),
                                TempoInicio = long.Parse(dr["TEMPO_INICIO"].ToString()),
                                TempoModoUsuario = long.Parse(dr["TEMPO_MODO_USUARIO"].ToString()),
                                Nome = dr["NOME"].ToString(),
                                Usuario = dr["USUARIO"].ToString(),
                                Prioridade = int.Parse(dr["PRIORIDADE"].ToString()),
                                OpenFiles = long.Parse(dr["OPEN_FILES"].ToString()),
                                GrupoID = dr["GRUPO_ID"].ToString(),
                                Grupo = dr["GRUPO"].ToString(),
                                DataCadastro = dr["DATA_CADASTRO"].ToString(),
                                CommandLine = dr["COMMAND_LINE"].ToString(),
                                Caminho = dr["CAMINHO"].ToString(),
                                BytesLidos = long.Parse(dr["BYTES_LIDOS"].ToString()),
                                BytesEscritos = long.Parse(dr["BYTES_ESCRITOS"].ToString())
                            };

                            listProcessos.Add(p);


                        }
                        
                    }


                }

            }

            return listProcessos;

        }

    }
}