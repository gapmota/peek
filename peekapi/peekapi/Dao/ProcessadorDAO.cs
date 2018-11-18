using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using peekapi.Models;

namespace peekapi.Dao
{
    public class ProcessadorDAO
    {
        public Processador PegarProcessador(int idComputador)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                Processador processador = new Processador();
                string sql = "SELECT TOP 1 * FROM PEEK_PROCESSADOR WHERE ID_COMPUTADOR = @COD ORDER BY ID_PROCESSADOR DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@COD", idComputador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            processador.IdComputador = int.Parse(dr["ID_COMPUTADOR"].ToString());
                            processador.IdProcessador = int.Parse(dr["ID_PROCESSADOR"].ToString());
                            processador.TempoAtividade = dr["TEMPO_ATIVIDADE"].ToString();
                            processador.PorcentagemUso = dr["PORCENTAGEM_USO"].ToString();
                            processador.DataCadastro = dr["DATA_CADASTRO"].ToString();
                            
                            return processador;
                        }
                        return null;
                    }


                }

            }

        }
    }
}