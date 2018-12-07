using peek.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace peek.dist.screenSystem
{
    public partial class maquinas : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:mateuzserver.database.windows.net,1433;Initial Catalog=MEU;Persist Security Info=False;User ID=mateuz;Password=Banco2k18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<Machine> listPC;

        protected void Page_Load(object sender, EventArgs e)
        {
                verComputadores();
                Carregar();
            
        }

        public void Carregar()
        {
            for (int i = 0; i < listPC.Count; i++)
            {
                Panel pnlComputer = new Panel();
                pnlComputer.CssClass = "pnlItem";
                machines.Controls.Add(pnlComputer);

                Label lblID = new Label();
                lblID.Text = "" + listPC.ElementAt(i).CodPc;
                lblID.CssClass = "lblItem";
                pnlComputer.Controls.Add(lblID);

                Label lblProc = new Label();
                lblProc.Text = "" + listPC.ElementAt(i).Proc;
                lblProc.CssClass = "lblItem";
                pnlComputer.Controls.Add(lblProc);

                Label lblRam = new Label();
                lblRam.Text = "" + listPC.ElementAt(i).Ram;
                lblRam.CssClass = "lblItem";
                pnlComputer.Controls.Add(lblRam);
            }
        }

        public List<Machine> verComputadores()
        {
            listPC = new List<Machine>();

            #region Contar e visualizar os computadores
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PEEK_COMPUTADOR", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Machine codigo = new Machine();

                            codigo.CodPc = reader.GetInt32(0);
                            codigo.Ram = Convert.ToString(reader[1]);
                            codigo.Proc = Convert.ToString(reader[2]);

                            listPC.Add(codigo);
                        }
                        return listPC;
                    }
                }
            }
            #endregion
        }
    }
}