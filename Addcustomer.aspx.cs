using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Models;

namespace ERP
{
    public partial class Addcustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISqlOperator ob = new customer(custname.Text, phno.Text, emid.Text, add.Text, Session["company"].ToString());
                ob.save();
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Oops!!! Something went wrong Please try after some time";
            }
            Response.Redirect("customerlist.aspx");


            
        }
    }
}