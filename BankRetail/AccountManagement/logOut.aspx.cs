using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankRetail.AccountManagement
{
    public partial class logOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["NAE"] = "";
            Session["CT"] = "";
            Response.Redirect("../AccountManagement/Login.aspx");
        }
    }
}