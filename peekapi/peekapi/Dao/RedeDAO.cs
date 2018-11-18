using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using peekapi.Models;

namespace peekapi.Dao
{
    public class RedeDAO
    {
        public Rede PegarRede(int idComputador)
        {

            using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
            {
                cnx.Open();
                Rede rede = new Rede();
                string sql = "SELECT TOP 1 * FROM PEEK_REDE WHERE ID_COMPUTADOR = @COD ORDER BY ID_REDE DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@COD", idComputador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            rede.IdRede = int.Parse(dr["ID_REDE"].ToString());
                            rede.Ipv4 = dr["IPV4"].ToString();
                            rede.Ipv6 = dr["IPV6"].ToString();
                            rede.MacAddress = dr["MAC_ADDRESS"].ToString();
                            rede.VelocidadeDownload = dr["VELOCIDADE_DOWNLOAD"].ToString();
                            rede.VelocidadeUpload = dr["VELOCIDADE_UPLOAD"].ToString();
                            rede.DataCadastro = dr["DATA_CADASTRO"].ToString();
                            rede.IdComputador = int.Parse(dr["ID_COMPUTADOR"].ToString());

                            return rede;
                        }
                        return null;
                    }


                }

            }

        }

        //

        public double[] SomaDownloadUploadDeTodosOsLaboratorios(int idUsuario)
        {

            using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
            {
                double[] down_up = new double[2];
                cnx.Open();
                string sql = @"SELECT COUNT(VELOCIDADE_DOWNLOAD) as VELOCIDADE_DOWNLOAD, COUNT(VELOCIDADE_UPLOAD) as VELOCIDADE_UPLOAD FROM PEEK_REDE R
                                INNER JOIN PEEK_COMPUTADOR P ON R.ID_COMPUTADOR = P.ID_COMPUTADOR 
								INNER JOIN PEEK_LAB L ON L.ID_LAB = P.ID_LAB
								INNER JOIN PEEK_USUARIO U ON U.ID_USUARIO = L.ID_USUARIO 
								WHERE U.ID_USUARIO = @ID								 
                                AND R.ID_REDE IN ((SELECT ID_REDE FROM PEEK_REDE R2 INNER JOIN PEEK_COMPUTADOR P2 ON P2.ID_COMPUTADOR = R2.ID_COMPUTADOR
								INNER JOIN PEEK_LAB L2 ON L2.ID_LAB = P2.ID_LAB
								INNER JOIN PEEK_USUARIO U2 ON U2.ID_USUARIO = L2.ID_USUARIO 
								WHERE U2.ID_USUARIO = @ID
								AND R2.ID_COMPUTADOR = P2.ID_COMPUTADOR
                                AND CONVERT(int, DATEDIFF(DAY, R2.data_cadastro, getdate())) = 0
								AND CONVERT(int, DATEDIFF(HOUR, R2.data_cadastro, getdate()) % 24) = 0
								AND CONVERT(int, DATEDIFF(MINUTE, R2.data_cadastro, getdate()) % 60.0) = 1
								));";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                        {
                            down_up[0] = double.Parse(dr["VELOCIDADE_DOWNLOAD"].ToString());
                            down_up[1] = double.Parse(dr["VELOCIDADE_UPLOAD"].ToString());

                            return down_up;
                        }

                        down_up[0] = 0;
                        down_up[1] = 0;
                        return down_up;


                    }


                }

            }

        }

        public List<Lab> PegarTodosLaboratoriosDeUmUsuario(int idUsuario)
        {
            using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
            {
                cnx.Open();
                string sql = "SELECT * FROM PEEK_LAB WHERE ID_USUARIO = @ID";

                List<Lab> labs = new List<Lab>();

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Lab l = new Lab();

                            l.IDdLab = int.Parse(dr["ID_LAB"].ToString());
                            l.Andar = dr["ANDAR"].ToString();
                            l.Nome = dr["NOME"].ToString();
                            l.Capacidade = int.Parse(dr["CAPACIDADE"].ToString());

                            labs.Add(l);

                        }

                    }

                    return labs;


                }

            }
        }

        public List<LabConsumo> PegarLaboratoriosQueEstaoConsumindoInternet(int idUsuario)
        {
            using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
            {
                cnx.Open();

                List<LabConsumo> labs = new List<LabConsumo>();

                string sql = @"SELECT L.ID_LAB, L.NOME, L.ANDAR, L.CAPACIDADE,  COUNT(VELOCIDADE_DOWNLOAD) as VELOCIDADE_DOWNLOAD, COUNT(VELOCIDADE_UPLOAD) as VELOCIDADE_UPLOAD  FROM PEEK_REDE R
                                INNER JOIN PEEK_COMPUTADOR P ON R.ID_COMPUTADOR = P.ID_COMPUTADOR 
								INNER JOIN PEEK_LAB L ON L.ID_LAB = P.ID_LAB
								INNER JOIN PEEK_USUARIO U ON U.ID_USUARIO = L.ID_USUARIO 
								WHERE U.ID_USUARIO = @ID
								AND R.ID_REDE IN ((SELECT ID_REDE FROM PEEK_REDE R2 INNER JOIN PEEK_COMPUTADOR P2 ON P2.ID_COMPUTADOR = R2.ID_COMPUTADOR
								INNER JOIN PEEK_LAB L2 ON L2.ID_LAB = P2.ID_LAB
								INNER JOIN PEEK_USUARIO U2 ON U2.ID_USUARIO = L2.ID_USUARIO 
								WHERE U2.ID_USUARIO = @ID
                                AND CONVERT(int, DATEDIFF(DAY, R2.data_cadastro, getdate())) <= 0
								AND CONVERT(int, DATEDIFF(HOUR, R2.data_cadastro, getdate()) % 24) <= 0
								AND CONVERT(int, DATEDIFF(MINUTE, R2.data_cadastro, getdate()) % 60.0) <= 5 
								))
                                GROUP BY L.ID_LAB, L.NOME, L.ANDAR, L.CAPACIDADE
                                ORDER BY VELOCIDADE_DOWNLOAD DESC;";

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LabConsumo lc = new LabConsumo();
                            lc.IDdLab = int.Parse(dr["ID_LAB"].ToString());
                            lc.Andar = dr["ANDAR"].ToString();
                            lc.Nome = dr["NOME"].ToString();
                            lc.Capacidade = int.Parse(dr["CAPACIDADE"].ToString());
                            lc.Download = double.Parse(dr["VELOCIDADE_DOWNLOAD"].ToString()); 
                            lc.Upload = double.Parse(dr["VELOCIDADE_UPLOAD"].ToString());

                            labs.Add(lc);

                        }

                        return labs;

                    }


                }

            }
        }



    }
}