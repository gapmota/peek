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
<<<<<<< HEAD
        private static readonly string stringCnx = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;

=======
       // private static readonly string stringCnx = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
        public string StringDeConexao = "Server = tcp:x.database.windows.net,1433; Initial Catalog = x; Persist Security Info = False; User ID = x; Password = x; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
>>>>>>> f882521cd309bda5f7df65db1c1d32519bd2c1f6
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
