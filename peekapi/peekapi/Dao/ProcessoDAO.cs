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

            using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
            {
                cnx.Open();
                
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
                            p.TempoInicio = long.Parse(dr["TEMPO_INICIO"].ToString());
                            p.TempoModoUsuario = long.Parse(dr["TEMPO_MODO_USUARIO"].ToString());
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

            return listProcessos;

        }

    }
}