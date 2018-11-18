using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace peekapi.Dao
{
    public class Banco
    {

        private static readonly string stringCnx = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
        public SqlConnection PegarConexao()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(stringCnx);
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();

                return cnx;

            }
            catch
            {
                return null;
            }


        }

    }
}
