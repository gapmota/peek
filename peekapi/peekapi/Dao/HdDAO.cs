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

            using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
            //using (SqlConnection cnx = new Banco().PegarConexao())
            {
                cnx.Open();
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
                using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
                //using (SqlConnection cnx = new Banco().PegarConexao())
                {
                    cnx.Open();
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
                                    HD h = new HD();

                                    h.IdHd = int.Parse(dr["ID_HD"].ToString());
                                    h.Total = dr["TOTAL"].ToString();
                                    h.Usado = dr["USADO"].ToString();
                                    h.IdComputador = idComputador;
                                    h.Diretorio = dr["DIRETORIO"].ToString();
                                    h.TipoDir = dr["TIPO_DIR"].ToString();
                                    h.Uuid = dr["UUID"].ToString();
                                    h.Volume = dr["VOLUME"].ToString();
                                    h.DataCadastro = dr["DATA_CADASTRO"].ToString();
                                    
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