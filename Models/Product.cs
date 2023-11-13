using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ERP.Models
{
    public class Product:SqlHelper
    {
        public string companyname { get; set; }
        public int productId { get; set; }
        public string productname { get; set; }
        public string code { get; set; }
        public string descp { get; set; }
        public string mrp { get; set; }
        public int tax { get; set; }
        public string gst { get; set; }

        public Product()
        {

        }

        public Product(string productname, string code, string descp, string mrp, int tax, string gst,string companyname)
        {
            this.productname = productname;
            this.code = code;
            this.descp = descp;
            this.mrp = mrp;
            this.tax = tax;
            this.gst = gst;
            this.companyname = companyname;

        }

        public override void save1()
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO TBLPRODUCT(PRODUCTNAME,CODE,DESCP,MRP,TAX,GST,companyname) VALUES(@prodname,@code,@des,@mrp,@tax,@GST,@companyname);", con);
            cmd.Parameters.AddWithValue("@prodname", productname);
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@des", descp);
            cmd.Parameters.AddWithValue("@mrp", mrp);
            cmd.Parameters.AddWithValue("@tax", tax);
            cmd.Parameters.AddWithValue("@GST", gst);
            cmd.Parameters.AddWithValue("@companyname", companyname);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public override string Getdb()
        {
            return "ERP";
        }
    }
}