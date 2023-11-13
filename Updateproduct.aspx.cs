using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class Updateproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String id = Request.QueryString["prodid"];
                SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
                SqlCommand cmd = new SqlCommand("SELECT * FROM TBLPRODUCT WHERE PRODUCTID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prodname.Text = reader.GetString(1);
                    code.Text = reader.GetString(2);
                    des.Text = reader.GetString(3);
                    mrp.Text = reader.GetString(4);
                    tax.Text = reader.GetInt32(5).ToString();
                    GST.Text = reader.GetString(6);
                }
                con.Close();
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("UPDATE tblproduct set productname = @prodname,code = @code,descp= @des , mrp =@mrp, tax=@tax,GST=@GST WHERE PRODUCTID = @id", con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["prodid"]);
            cmd.Parameters.AddWithValue("@prodname", prodname.Text);
            cmd.Parameters.AddWithValue("@code", code.Text);
            cmd.Parameters.AddWithValue("@des", des.Text);
            cmd.Parameters.AddWithValue("@mrp", mrp.Text);
            cmd.Parameters.AddWithValue("@tax", tax.Text);
            cmd.Parameters.AddWithValue("@GST", GST.Text);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Productlist.aspx");
        }
    }
}