﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using peekapi.controller;
using peekapi.Models;

namespace peekapi.get
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(new ToJSON().getUsuarioToJson());
        }
    }
}