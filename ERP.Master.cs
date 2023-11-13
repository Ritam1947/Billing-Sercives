﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class ERP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"]==null)
            {
                Response.Redirect("login.aspx");
            }
            user.Text = Session["username"].ToString();
        }
    }
}