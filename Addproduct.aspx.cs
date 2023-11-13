using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ERP.Models;

namespace ERP
{
    public partial class Addproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlHelper ob = new Product(prodname.Text, code.Text, des.Text, mrp.Text, Convert.ToInt32(tax.Text), GST.Text, Session["company"].ToString());// run-time polymorphism
            ob.save1();// compile-time polymorphism..
            Response.Redirect("Productlist.aspx");

        }

    }

}