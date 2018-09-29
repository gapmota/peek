using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using peekapi.controller;
using peekapi.models;

namespace peekapi.get
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            if(type == "memory")
            {
                Response.Write(new ToJSON().getMemoriaToJson());
            }
            else if(type == "user")
            {
                Response.Write(new ToJSON().getUsuarioToJson());
            }
            else
            {
                Response.Write("IsNaN");
            }
        }
    }
}