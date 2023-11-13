using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class customer : ISqlOperator
    {
        public int Customerid { get; set; }
        public string CustomerName { get; set; }
        public string Phonenumber { get; set; }
        public string Emailid { get; set; }
        public string Addr { get; set; }
        public string companyname { get; set; }
        public customer()
        {

        }

        public customer(string customername, string phonenumber, string Emailid, string Addr,string companyname)
        {
            this.CustomerName = customername;
            this.Addr = Addr;
            this.Emailid = Emailid;
            this.Phonenumber = phonenumber;
            this.companyname = companyname;
        }


        public void save()
        {
            SqlConnection con = new SqlConnection(@"Server=192.168.0.103;Database=ERP;User Id=saa;Password=db@123456;");
            SqlCommand cmd = new SqlCommand("INSERT INTO tblcustomer(CUSTOMERNAME,PHONENUMBER,EMAILID,ADDR,companyname) VALUES (@custname,@phno,@emid,@add,@companyname);", con);
            cmd.Parameters.AddWithValue("@custname", CustomerName);
            cmd.Parameters.AddWithValue("@phno", Phonenumber);
            cmd.Parameters.AddWithValue("@emid", Emailid);
            cmd.Parameters.AddWithValue("@add", Addr);
            cmd.Parameters.AddWithValue("@companyname", companyname);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            finally 
            {
                con.Close();
                cmd.Dispose();//clears the Memory of command from RAM instantly
            }
        }
    }
}