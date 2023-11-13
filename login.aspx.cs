using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Boolean getlogin(string username, string password)
        {
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("SELECT name,companyname FROM tbluser where username =@usrname and password=@passwrd", con);
            
            cmd.Parameters.AddWithValue("@usrname", username);
            cmd.Parameters.AddWithValue("@passwrd", password);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["username"] = reader.GetString(0);
                Session["company"] = reader.GetString(1);
                con.Close();
                return true;
            }
            else
                return false;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(getlogin(txtusername.Text, txtpassword.Text))
            {
                Response.Redirect("Addinvoice.aspx");
            }
            else
            {
                lblerr.Text = "Invalid username or password";
            }
        }
    }
}