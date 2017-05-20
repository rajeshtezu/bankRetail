using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankRetail.AccountExecutive
{
    public partial class accountManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If session for NAE is not created, Redirect to Login Page
            if (string.IsNullOrEmpty(Session["NAE"] as string))
            {
                Response.Redirect("../AccountManagement/Login.aspx");
            }
            // If CT is logged in and trying to access NAE, Redirect to (Login Page --> CT Home Page)
            else if (!string.IsNullOrEmpty(Session["CT"] as string))
            {
                Response.Redirect("../AccountManagement/Login.aspx");
            }

            emp_name.Text = camelCase(Session["EmpName"].ToString());
            EmpType.Text = Session["EmpType"].ToString();
        }

        protected string camelCase(string literal)
        {
            String value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(literal);
            return value;
        }
    }
}