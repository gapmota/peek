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
        string str = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
                Response.Redirect("login.aspx");

            str = Request["axpsa"];
            if (str == null || str == "")
            {
                verComputadores();
            }
            else
            {
                verComputadoresLab();
            }
            Carregar();
        }

        protected void btnMaquina(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            Response.Write(l.ID);

        }


        public void Carregar()
        {
            for (int i = 0; i < listPC.Count; i++)
            {
                Panel pnlComputer = new Panel();
                pnlComputer.ID = listPC.ElementAt(i).CodPc.ToString();
                pnlComputer.Attributes.Add("OnClick", "abrirModal(this)");
                pnlComputer.CssClass = "pnlItem";
                machines.Controls.Add(pnlComputer);

                Label lblID = new Label();
                lblID.ID = listPC.ElementAt(i).CodPc.ToString();
                lblID.Text = "" + listPC.ElementAt(i).CodPc;
                lblID.CssClass = "lblItem";
                pnlComputer.Controls.Add(lblID);

                Label lblProc = new Label();
                lblProc.ID = listPC.ElementAt(i).CodPc.ToString();
                lblProc.Text = "" + listPC.ElementAt(i).Proc;
                lblProc.CssClass = "lblItem";
                pnlComputer.Controls.Add(lblProc);

                Label lblRam = new Label();
                lblRam.ID = listPC.ElementAt(i).CodPc.ToString();
                lblRam.Text = "" + listPC.ElementAt(i).Ram;
                lblRam.CssClass = "lblItem";
                pnlComputer.Controls.Add(lblRam);

                Label lblCmd = new Label();
                lblCmd.ID = listPC.ElementAt(i).CodPc.ToString();
                lblCmd.Text = "CMD";
                lblCmd.CssClass = "lblCmd";
                pnlComputer.Controls.Add(lblCmd);



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


        public List<Machine> verComputadoresLab()
        {
            listPC = new List<Machine>();

            #region Contar e visualizar os computadores por lab
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PEEK_COMPUTADOR WHERE ID_LAB = @id_lab", conexao))
                {
                    cmd.Parameters.AddWithValue("@id_lab", str);
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