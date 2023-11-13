using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String id = Request.QueryString["invoice_id"];
                SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
                SqlCommand cmd = new SqlCommand("sel_print", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@invoice_id", id);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds,"header");
                con.Close();

                lblcustname.Text = ds.Tables[0].Rows[0]["customername"].ToString();
                lblshpname.Text = ds.Tables[0].Rows[0]["customername"].ToString();
                lblshpadd.Text = ds.Tables[0].Rows[0]["ADDR"].ToString();
                lbladd.Text = ds.Tables[0].Rows[0]["ADDR"].ToString();
                lbldate.Text = ds.Tables[0].Rows[0]["CREATEDDATE"].ToString();
                lblid.Text = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                lblphone.Text = ds.Tables[0].Rows[0]["PHONENUMBER"].ToString(); 
                lblordid.Text = ds.Tables[0].Rows[0]["Orderid"].ToString() ;



                gridproduct.DataSource = ds.Tables[1];
                gridproduct.DataBind();
            }
        }
    }
}