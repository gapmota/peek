using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using peekapi.Models;

namespace peekapi.Dao
{
    public class HdDAO
    {

        private List<string> PegarDetorios(int idComputador)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                {
                    List<string> listDiretorio = new List<string>();
                    string sql = "SELECT DISTINCT(DIRETORIO) FROM PEEK_HD WHERE ID_COMPUTADOR = @ID";
                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@ID", idComputador);


                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string diretorio = dr["DIRETORIO"].ToString();

                                listDiretorio.Add(diretorio);
                            }

                        }

                        return listDiretorio;


                    }

                }
            }
        }


        public List<HD> PegarHD(int idComputador)
        {
            List<HD> hds = new List<HD>();
            foreach (string dir in this.PegarDetorios(idComputador))
            {
                using (SqlConnection cnx = new Banco().PegarConexao())
                {
                    {
                        List<string> listDiretorio = new List<string>();
                        string sql = "SELECT TOP 1 * FROM PEEK_HD WHERE ID_COMPUTADOR = @ID AND DIRETORIO = @DIR ORDER BY ID_HD DESC";
                        using (SqlCommand cmd = new SqlCommand(sql, cnx))
                        {
                            cmd.Parameters.AddWithValue("@ID", idComputador);
                            cmd.Parameters.AddWithValue("@DIR", dir);


                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    HD h = new HD
                                    {
                                        IdHd = int.Parse(dr["ID_HD"].ToString()),
                                        Total = dr["TOTAL"].ToString(),
                                        Usado = dr["USADO"].ToString(),
                                        IdComputador = idComputador,
                                        Diretorio = dr["DIRETORIO"].ToString(),
                                        TipoDir = dr["TIPO_DIR"].ToString(),
                                        Uuid = dr["UUID"].ToString(),
                                        Volume = dr["VOLUME"].ToString(),
                                        DataCadastro = dr["DATA_CADASTRO"].ToString()
                                    };


                                    try
                                    {
                                        h.PorcentagemUso = int.Parse(dr["PORCETAGEM_USO"].ToString());
                                    }
                                    catch
                                    {
                                        h.PorcentagemUso = 0;
                                    }


                                    hds.Add(h);
                                }

                            }



                        }

                    }
                }
            }

            return hds;


        }

        public int PegarLabsQuePossuamMenosDeAlgumaPorcetagemLivreEmDisco(int idUsuario, int porc, string diretorio)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                Processador processador = new Processador();
                string sql = @"SELECT COUNT(DISTINCT HD.ID_COMPUTADOR) AS QNT_PC FROM PEEK_HD HD
                            INNER JOIN PEEK_COMPUTADOR PC ON PC.ID_COMPUTADOR = HD.ID_COMPUTADOR
                            INNER JOIN PEEK_LAB L ON PC.ID_LAB = L.ID_LAB
                            INNER JOIN PEEK_USUARIO U ON U.ID_USUARIO = L.ID_USUARIO
                            WHERE U.ID_USUARIO = @ID
								AND CONVERT(int, DATEDIFF(DAY, HD.data_cadastro, getdate())) = 0
                                AND CONVERT(int, DATEDIFF(HOUR, HD.data_cadastro, getdate()) % 24) = 0
                                AND CONVERT(int, DATEDIFF(MINUTE, HD.data_cadastro, getdate()) % 60.0) <= 1
								AND HD.PORCETAGEM_USO <= @PORC
								AND HD.DIRETORIO LIKE '%" + diretorio + @"%'
								GROUP BY HD.DIRETORIO
                                ;";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);
                    cmd.Parameters.AddWithValue("@PORC", porc);
                    cmd.Parameters.AddWithValue("@DIR", diretorio);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            try
                            {
                                return int.Parse(dr["QNT_PC"].ToString());
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

        public int PegarLabsQueEstaEntreDeAlgumaPorcetagemLivreEmDisco(int idUsuario, int porcInicial, int porcFinal, string diretorio)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                Processador processador = new Processador();
                string sql = @"SELECT COUNT(DISTINCT HD.ID_COMPUTADOR) AS QNT_PC FROM PEEK_HD HD
                            INNER JOIN PEEK_COMPUTADOR PC ON PC.ID_COMPUTADOR = HD.ID_COMPUTADOR
                            INNER JOIN PEEK_LAB L ON PC.ID_LAB = L.ID_LAB
                            INNER JOIN PEEK_USUARIO U ON U.ID_USUARIO = L.ID_USUARIO
                            WHERE U.ID_USUARIO = @ID
								AND CONVERT(int, DATEDIFF(DAY, HD.data_cadastro, getdate())) = 0
                                AND CONVERT(int, DATEDIFF(HOUR, HD.data_cadastro, getdate()) % 24) = 0
                                AND CONVERT(int, DATEDIFF(MINUTE, HD.data_cadastro, getdate()) % 60.0) <= 1
								AND HD.PORCETAGEM_USO BETWEEN @PORC_INICIAL and @PORC_FINAL
								AND HD.DIRETORIO LIKE '%" + diretorio + @"%'
								GROUP BY HD.DIRETORIO
                                ;";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);
                    cmd.Parameters.AddWithValue("@PORC_INICIAL", porcInicial);
                    cmd.Parameters.AddWithValue("@PORC_FINAL", porcFinal);
                    cmd.Parameters.AddWithValue("@DIR", diretorio);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            try
                            {
                                return int.Parse(dr["QNT_PC"].ToString());
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

        public int PegarLabsQuePossuamMaisAlgumaPorcetagemLivreEmDisco(int idUsuario, int porc, string diretorio)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                Processador processador = new Processador();
                string sql = @"SELECT COUNT(DISTINCT HD.ID_COMPUTADOR) AS QNT_PC FROM PEEK_HD HD
                            INNER JOIN PEEK_COMPUTADOR PC ON PC.ID_COMPUTADOR = HD.ID_COMPUTADOR
                            INNER JOIN PEEK_LAB L ON PC.ID_LAB = L.ID_LAB
                            INNER JOIN PEEK_USUARIO U ON U.ID_USUARIO = L.ID_USUARIO
                            WHERE U.ID_USUARIO = @ID
								AND CONVERT(int, DATEDIFF(DAY, HD.data_cadastro, getdate())) = 0
                                AND CONVERT(int, DATEDIFF(HOUR, HD.data_cadastro, getdate()) % 24) = 0
                                AND CONVERT(int, DATEDIFF(MINUTE, HD.data_cadastro, getdate()) % 60.0) <= 1
								AND HD.PORCETAGEM_USO >= @PORC
								AND HD.DIRETORIO LIKE '%" + diretorio + @"%'
								GROUP BY HD.DIRETORIO
                                ;";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);
                    cmd.Parameters.AddWithValue("@PORC", porc);
                    cmd.Parameters.AddWithValue("@DIR", diretorio);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            try
                            {
                                return int.Parse(dr["QNT_PC"].ToString());
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