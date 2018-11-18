using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using peekapi.Models;

namespace peekapi.Dao
{
    public class MacAddressDAO
    {
        public List<MacAddress> PegarMacs(int idComputador)
        {


            using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
            {
                cnx.Open();
                List<MacAddress> listMacs = new List<MacAddress>();
                string sql = "SELECT * FROM PEEK_MAC_ADDRESS WHERE ID_COMPUTADOR = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idComputador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            MacAddress m = new MacAddress();

                            m.IdComputador = idComputador;
                            m.MacAddress_ = dr["MAC_ADDRESS"].ToString();
                            m.TipoConexao = dr["TIPO_CONEXAO"].ToString();
                            m.DataCadastro = dr["DATA_CADASTRO"].ToString();

                            listMacs.Add(m);

                        }
                        return listMacs;
                    }


                }

            }

        }
    }
}