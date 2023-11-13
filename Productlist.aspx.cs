using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class Productlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Addproduct.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                int rowind = Convert.ToInt32(e.CommandArgument);
                String id = GridView1.Rows[rowind].Cells[0].Text;
                Response.Redirect("Updateproduct.aspx?prodid="+id);

            }
        }
    }
}