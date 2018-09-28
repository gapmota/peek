using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace peekapi.controller
{
    public class Banco
    {
        private static readonly string conexao = "Server=tcp:mateuzserver.database.windows.net,1433;Initial Catalog=MEU;Persist Security Info=False;User ID=mateuz;Password=Banco2k18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection getConexao()
        {
            return new SqlConnection(conexao);
        }

    }
}