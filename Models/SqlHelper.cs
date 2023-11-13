using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public abstract class SqlHelper
    {
        public abstract void save1();
        public abstract string Getdb();
        public SqlConnection GetConnection()
        {
            string dbname = Getdb();
            return new SqlConnection("Data Source=192.168.0.103;Initial Catalog="+dbname+"; Persist Security Info=True;User ID=saa;Password=db@123456");
        }
    }
}