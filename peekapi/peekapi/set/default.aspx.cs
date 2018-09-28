using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using peekapi.controller;
using peekapi.Models;

namespace peekapi.set
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = Request.QueryString["json"];

            List<Usuario> usuario = new ToJSON().JsonToListUsuario(json);

            foreach (Usuario u in usuario)
            {
                Response.Write(u.Nome+" > "+u.Email+" > "+u.Id+"<br>");
            }

        }
    }
}