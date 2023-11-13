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
    public partial class updatecustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                String id = Request.QueryString["custid"];
                SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
                SqlCommand cmd = new SqlCommand("SELECT * FROM TBLCUSTOMER WHERE CUSTOMERID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read())  //picks each tuple one by one
                {
                    custname.Text = reader.GetString(1);
                    phno.Text = reader.GetString(2);
                    emid.Text = reader.GetString(3);
                    add.Text = reader.GetString(4);
                }
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("UPDATE tblcustomer set customername = @custname,phonenumber = @phno,Emailid =@emid,Addr=@add WHERE CUSTOMERID = @id", con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["custid"]);
            cmd.Parameters.AddWithValue("@custname", custname.Text);
            cmd.Parameters.AddWithValue("@phno", phno.Text);
            cmd.Parameters.AddWithValue("@emid", emid.Text);
            cmd.Parameters.AddWithValue("@add", add.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("customerlist.aspx");
        }
    }
}