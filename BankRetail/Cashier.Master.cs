using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankRetail
{
    public partial class Cashier : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cpyrtYear.Text = DateTime.Now.ToString("yyyy");

            if(string.IsNullOrEmpty(Session["CT"] as string))
            {
                Response.Redirect("../AccountManagement/Login.aspx");
            }
            else if(!string.IsNullOrEmpty(Session["NAE"] as string))
            {
                Response.Redirect("../AccountExecutive/Home.aspx");
            }

            emp_name.Text = camelCase(Session["EmpName"].ToString());
            emp_name_display.Text = camelCase(Session["EmpName"].ToString());
            EmpType.Text = Session["EmpType"].ToString();


        }

        protected string camelCase(string literal)
        {
            String value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(literal);
            return value;
        }

        
    }
}