using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using peekapi.controller;
using peekapi.models;

namespace peekapi.set
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = Request.QueryString["json"];
            string type = Request.QueryString["type"];

            if (type == "memory")
            {
                new EntidadeMemoria().UpdateMemoria(new ToJSON().JsonToGetMemoria(json));
            }
            else if (type == "user")
            {

            }
            else
            {

            }
        }
    }
}