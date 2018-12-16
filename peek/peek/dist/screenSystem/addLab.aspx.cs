using peek.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace peek.dist
{
    public partial class addLab : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:mateuzserver.database.windows.net,1433;Initial Catalog=MEU;Persist Security Info=False;User ID=mateuz;Password=Banco2k18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<Labs> listLabs;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
                Response.Redirect("login.aspx");

            verLabs();
            Carregar();
        }

        protected void btnLab(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            Response.Write(l.ID);

        }

        public void Carregar()
        {
            for (int i = 0; i < listLabs.Count; i++)
            {
                Panel pnlLabs = new Panel();
                pnlLabs.ID = listLabs.ElementAt(i).IDLab1.ToString();
                pnlLabs.CssClass = "pnlItemLab";
                labs.Controls.Add(pnlLabs);


                Label lblID = new Label();
                lblID.ID = listLabs.ElementAt(i).IDLab1.ToString();
                lblID.Text = "ID: " + listLabs.ElementAt(i).IDLab1;
                lblID.CssClass = "lblItemIDLab";
                pnlLabs.Controls.Add(lblID);

                Label lblNome = new Label();
                lblNome.ID = listLabs.ElementAt(i).IDLab1.ToString();
                lblNome.Text = "Nome: " + listLabs.ElementAt(i).Nome;
                lblNome.CssClass = "lblItemLab";
                pnlLabs.Controls.Add(lblNome);

                Label lblAndar = new Label();
                lblAndar.ID = listLabs.ElementAt(i).IDLab1.ToString();
                lblAndar.Text = "Andar: " + listLabs.ElementAt(i).Andar;
                lblAndar.CssClass = "lblItemLab";
                pnlLabs.Controls.Add(lblAndar);

                Label lblCapacity = new Label();
                lblCapacity.ID = listLabs.ElementAt(i).IDLab1.ToString();
                lblCapacity.Text = "Capacidade: " + listLabs.ElementAt(i).Capacity;
                lblCapacity.CssClass = "lblItemLab";
                pnlLabs.Controls.Add(lblCapacity);

                Label lblMaq = new Label();
                lblMaq.ID = listLabs.ElementAt(i).IDLab1.ToString();
                lblMaq.Text = "Ver Maquinas ";
                lblMaq.CssClass = "lblMaqLab";
                lblMaq.Attributes.Add("OnClick", "seeMachineLab(this)");
                pnlLabs.Controls.Add(lblMaq);

                Label lblCmd = new Label();
                lblCmd.ID = listLabs.ElementAt(i).IDLab1.ToString();
                lblCmd.Text = "CMD";
                lblCmd.CssClass = "lblMaqLab";
                lblCmd.Attributes.Add("OnClick", "abrirModalCmd("+listLabs.ElementAt(i).IDLab1.ToString()+")");
                pnlLabs.Controls.Add(lblCmd);
            }
        }

        public List<Labs> verLabs()
        {
            listLabs = new List<Labs>();

            #region Contar e visualizar os computadores
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PEEK_LAB", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Labs codigo = new Labs();

                            codigo.IDLab1 = reader.GetInt32(0);
                            codigo.Nome = Convert.ToString(reader[1]);
                            codigo.Andar = Convert.ToString(reader[2]);
                            codigo.Capacity = Convert.ToString(reader[3]);

                            listLabs.Add(codigo);
                        }
                        return listLabs;
                    }
                }
            }
            #endregion
        }
    }
}