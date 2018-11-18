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

                                    hds.Add(h);
                                }

                            }
                            


                        }

                    }
                }
            }

            return hds;


        }

    }
}