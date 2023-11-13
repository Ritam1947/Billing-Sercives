using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("INSERT INTO tbluser(NAME,USERNAME,PASSWORD,Companyname) VALUES(@name,@username,@password,@companyname);", con);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@username", usrname.Text);
            cmd.Parameters.AddWithValue("@password", txtpwd.Text);
            cmd.Parameters.AddWithValue("@companyname", Session["company"]);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("userlist.aspx");
        }
    }
}