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
        private static readonly string conexao = "";

        public static SqlConnection getConexao()
        {
            return new SqlConnection(conexao);
        }

    }
}