using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace visualizarDados.screen
{
    public partial class computadores : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:mateuzserver.database.windows.net,1433;Initial Catalog=MEU;Persist Security Info=False;User ID=mateuz;Password=Banco2k18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Computador c;
        public List<Computador> cc;

        public struct Computador
        {
            public int codComputador;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ListarRegistros();
            CriarRegistros();
        }

        #region Criar as DIVS
        public void CriarRegistros()
        {

            cadastrados.Controls.Clear();
            cadastrados.Dispose();

            for (int i = 0; i < cc.Count; i++)
            {
                Panel linha = new Panel();
                linha.CssClass = "container";
                cadastrados.Controls.Add(linha);

                Button btnVisualizar = new Button();
                btnVisualizar.Text = "Computador: " + cc.ElementAt(i).codComputador;
                btnVisualizar.CssClass = "btnVisualizar";
                btnVisualizar.Command += Visualizar;
                btnVisualizar.CommandArgument = cc.ElementAt(i).codComputador.ToString();
                linha.Controls.Add(btnVisualizar);
            }
        }
        #endregion

        #region Listar os registros
        public void ListarRegistros()
        {
            c = new Computador();
            cc = new List<Computador>();
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ID_COMPUTADOR FROM PEEK_COMPUTADOR", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            c.codComputador = reader.GetInt32(0);
                            cc.Add(c);
                        }
                    }
                }
            }
            #endregion
        }

        public void Visualizar(object sender, CommandEventArgs e)
        {
            int cod_computer = int.Parse(e.CommandArgument.ToString());
            Session["computador"] = cod_computer + "";
            Response.Redirect("index.aspx");
        }
    }
}