using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace visualizarDados
{
    public partial class index : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:mateuzserver.database.windows.net,1433;Initial Catalog=MEU;Persist Security Info=False;User ID=mateuz;Password=Banco2k18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        String R_total;
        String R_free;
        String R_use;
        String PC_totalRam;
        String PC_Proc;
        String Mac;
        int Proc_id;
        String Proc_time;
        DateTime Date;
        String Rede_ipv4;
        String Rede_ipv6;
        String Rede_down;
        String Rede_upload;
        String Mac_type;
        int Rede_Id;
        int id_pc;

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                #region Alimentando dados do computador
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PEEK_COMPUTADOR", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_pc = reader.GetInt32(0);
                            PC_totalRam = Convert.ToString(reader[1]);
                            PC_Proc = Convert.ToString(reader[2]);
                            Mac = Convert.ToString(reader[3]);

                            lblIdPc.Text = "Identificador - " + id_pc.ToString();
                            lblRam.Text = "Total de memória RAM - " + PC_totalRam.ToString();
                            lblProc.Text = "Descrição do processador - " + PC_Proc.ToString();
                            lblMac.Text = "MAC - " + Mac.ToString();
                        }
                    }
                }
                #endregion

                #region Alimentando dados do processador
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PEEK_PROCESSADOR", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proc_id = reader.GetInt32(0);
                            Proc_time = Convert.ToString(reader[1]);
                            Date = reader.GetDateTime(2);
                            id_pc = reader.GetInt32(3);

                            lblIdProc.Text = "Identificador do processador - " + Proc_id.ToString();
                            lblTime.Text = "Tempo de atividade - " + Proc_time.ToString();
                            lblDate.Text = "Data de cadastro - " + Date.ToString();
                            lblIdPc_Proc.Text = "Identificador - " + id_pc.ToString();
                        }
                    }
                }
                #endregion

                #region Alimentando dados da RAM
                using (SqlCommand cmd = new SqlCommand("SELECT TOTAL, LIVRE, EM_USO, ID_COMPUTADOR FROM PEEK_MEMORIA_RAM", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            R_total = Convert.ToString(reader[0]);
                            R_free = Convert.ToString(reader[1]);
                            R_use = Convert.ToString(reader[2]);
                            id_pc = reader.GetInt32(3);

                            lblTotal.Text = "Total de memória RAM - " + R_total.ToString();
                            lblFree.Text = "Livre - " + R_free.ToString();
                            lblUse.Text = "Usado - " + R_use.ToString();
                            lblIdPc_Ram.Text = "Identificador - " + id_pc.ToString();
                        }
                    }
                }
                #endregion

                #region Alimentando dados da Rede
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PEEK_REDE", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rede_Id = reader.GetInt32(0);
                            Rede_ipv4 = Convert.ToString(reader[1]);
                            Rede_ipv6 = Convert.ToString(reader[2]);
                            Mac = Convert.ToString(reader[3]);
                            Rede_down = Convert.ToString(reader[4]);
                            Rede_upload = Convert.ToString(reader[5]);
                            Date = reader.GetDateTime(6);
                            id_pc = reader.GetInt32(7);

                            lblIdPc_Rede.Text = "Identificador - " + id_pc.ToString();
                            lblIdRede.Text = "Identificador da rede - " + Rede_Id.ToString();
                            lblIpv4.Text = "IPV4 - " + Rede_ipv4.ToString();
                            lblIpv6.Text = "IPV6 - " + Rede_ipv6.ToString();
                            lblMacAddress.Text = "MAC da rede - " + Mac.ToString();
                            lvlDown.Text = "Velocidade Download - " + Rede_down.ToString();
                            lblUpload.Text = "Velocidade Upload - " + Rede_upload.ToString();
                            lblDateRede.Text = "Data de cadastro - " + Date.ToString();
                        }
                    }
                }
                #endregion

                #region Alimentando dados do MAC
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PEEK_MAC_ADDRESS", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Mac = Convert.ToString(reader[0]);
                            Mac_type = Convert.ToString(reader[1]);
                            Date = reader.GetDateTime(2);
                            id_pc = reader.GetInt32(3);

                            lblIdPc_Mac.Text = "Identificador - " + id_pc.ToString();
                            lblMacAd.Text = "MAC - " + Mac.ToString();
                            lblConnec.Text = "Tipo de conexão - " + Mac_type.ToString();
                            lblDateCad.Text = "Data de cadastro - " + Date.ToString();
                        }
                    }
                }
                #endregion

                conexao.Close();
            }
        }
    }
}