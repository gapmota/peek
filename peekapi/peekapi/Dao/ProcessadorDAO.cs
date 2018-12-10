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
                string sql = @"SELECT TOP 1 * FROM PEEK_PROCESSADOR R2 WHERE ID_COMPUTADOR = @COD ORDER BY ID_PROCESSADOR DESC";
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

        public int PegarMediaUsoTodosLab(int idUsuario)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                Processador processador = new Processador();
                string sql = @"SELECT AVG(PROCE.PORCENTAGEM_USO) AS USO_PROCESSADOR FROM PEEK_PROCESSADOR PROCE
                            INNER JOIN PEEK_COMPUTADOR PC ON PC.ID_COMPUTADOR = PROCE.ID_COMPUTADOR
                            INNER JOIN PEEK_LAB L ON PC.ID_LAB = L.ID_LAB
                            INNER JOIN PEEK_USUARIO U ON U.ID_USUARIO = L.ID_USUARIO
                            WHERE U.ID_USUARIO = @ID
                                AND CONVERT(int, DATEDIFF(DAY, proce.data_cadastro, getdate())) = 0
								AND CONVERT(int, DATEDIFF(HOUR, proce.data_cadastro, getdate()) % 24) = 0
								AND CONVERT(int, DATEDIFF(MINUTE, proce.data_cadastro, getdate()) % 60.0) <= 5
                                ;";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            try { 
                            return (int)double.Parse(dr["USO_PROCESSADOR"].ToString());
                            }
                            catch 
                            {
                                return 0;
                            }


                        }
                        return 0;
                    }

                }

            }

        }
    }
}