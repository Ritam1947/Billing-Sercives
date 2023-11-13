using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class Addinvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadcustomer();
                loadproduct();
            }
        }

        public void loadcustomer()
        {
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("select '-SELECT-' as phonenumber union all SELECT phonenumber FROM TBLCUSTOMER where companyname=@companyname", con);
            cmd.Parameters.AddWithValue("@companyname", Session["company"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();
            ddCustomer.DataSource = ds;
            ddCustomer.DataTextField = "phonenumber";
            ddCustomer.DataValueField = "phonenumber";
            ddCustomer.DataBind();
            
           
        }

        public void loadproduct()
        {
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("SELECT 0 as productid,'-SELECT-' AS Concatproduct UNION ALL SELECT productid,productname+'('+code+')' as Concatproduct from tblproduct where companyname=@companyname", con);
            cmd.Parameters.AddWithValue("companyname", Session["company"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();
            ddproduct.DataSource = ds;
            ddproduct.DataTextField = "Concatproduct";
            ddproduct.DataValueField = "productid";
            ddproduct.DataBind();
            
        }

        protected void ddCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string phonenumber = ddCustomer.SelectedValue;
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLCUSTOMER WHERE phonenumber = @phonenumber", con);
            cmd.Parameters.AddWithValue("@phonenumber", phonenumber);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())  //picks each tuple one by one
            {
                txtnm.Text = reader.GetString(1);
                txtem.Text = reader.GetString(3);
                Txtadd.Text = reader.GetString(4);
            }            
            con.Close();

        }

        protected void ddproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productid = ddproduct.SelectedValue;
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("SELECT mrp,descp from tblproduct where productid = @productid ", con);
            cmd.Parameters.AddWithValue("@productid", productid);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                txtmrp.Text = reader.GetString(0);
                txtdes.Text = reader.GetString(1);
            }
            con.Close();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Session["table"] != null)
            {
                dt = (DataTable)Session["table"]; //override

            }


            else
            {


                DataColumn dc = new DataColumn();
                dc.DataType = typeof(int);  // string --- 's' --> datatype ,'S'--> class String...
                dc.ColumnName = "Productid";
                dc.Caption = "Productid";
                dt.Columns.Add(dc);


                dc = new DataColumn(); // overwrite method
                dc.DataType = typeof(string);  // string --- 's' --> datatype ,'S'--> class String...
                dc.ColumnName = "Descp";
                dc.Caption = "Descp";
                dt.Columns.Add(dc);

                dc = new DataColumn(); // overwrite method
                dc.DataType = typeof(int);  // string --- 's' --> datatype ,'S'--> class String...
                dc.ColumnName = "MRP";
                dc.Caption = "MRP";
                dt.Columns.Add(dc);

                dc = new DataColumn(); // overwrite method
                dc.DataType = typeof(int);  // string --- 's' --> datatype ,'S'--> class String...
                dc.ColumnName = "Quantity";
                dc.Caption = "Quantity";
                dt.Columns.Add(dc);

                dc = new DataColumn(); // overwrite method
                dc.DataType = typeof(int);  // string --- 's' --> datatype ,'S'--> class String...
                dc.ColumnName = "Total";
                dc.Caption = "Total";
                dt.Columns.Add(dc);


            }

            DataRow dr = dt.NewRow();
            dr["Productid"] = Convert.ToInt32(ddproduct.SelectedValue);//Explicit
            dr["Descp"] = txtdes.Text;//should be same as the caption name
            dr["MRP"] = Convert.ToInt32(txtmrp.Text);
            dr["Quantity"] = Convert.ToInt32(txtqty.Text);
            dr["Total"] = Convert.ToInt32(txtqty.Text) * Convert.ToInt32(txtmrp.Text);
            dt.Rows.Add(dr);
            Session["table"] = dt;
            grdproduct.DataSource = dt; //runtime allocation
            grdproduct.DataBind();



        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
         
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("ins_invoiceheader", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Custmobile",ddCustomer.SelectedValue);
            cmd.Parameters.AddWithValue("@Createdate", DateTime.Now);//datetime.now -gives the current date time.. 
            cmd.Parameters.AddWithValue("@Companyname", Session["company"].ToString());
            con.Open();
            string id = cmd.ExecuteScalar().ToString();
            //nonexecute query should not be used bcz we have to read the data....
            DataTable dt = (DataTable)Session["table"];
            foreach (DataRow dr in dt.Rows)
            {
                cmd = new SqlCommand("ins_invoicedetails", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@invoiceid", id);
                cmd.Parameters.AddWithValue("@productid", dr["Productid"]);
                cmd.Parameters.AddWithValue("@MRP", dr["MRP"]);
                cmd.Parameters.AddWithValue("@Quantity", dr["Quantity"]);
                cmd.Parameters.AddWithValue("@total", dr["Total"]);
                cmd.ExecuteNonQuery();
            }
            con.Close();

            Session["table"] = null;
            Response.Redirect("print.aspx?invoice_id=" + id);
        }
    }

}
