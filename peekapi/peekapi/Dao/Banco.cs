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
       // private static readonly string stringCnx = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
        public string StringDeConexao = "Server = tcp:mateuzserver.database.windows.net,1433; Initial Catalog = MEU; Persist Security Info = False; User ID = mateuz; Password = Banco2k18; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        public SqlConnection PegarConexao()
        {
            using (SqlConnection cnx = new SqlConnection(StringDeConexao))
            {
                return cnx;

            }


        }
        
    }
}