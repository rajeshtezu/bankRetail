using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BO;

namespace BankRetail
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        Operation op = new Operation();

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

            if (!IsPostBack)
            {
                showData();
            }
        }

        public void showData()
        {
            string errMsg = "";
            AccStatusGridView.DataSource = op.GetAccountStatus(out errMsg);
            AccStatusGridView.DataBind();
        }

        protected void AccStatusGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int id = Convert.ToInt32(e.CommandArgument);
            showData();
        }
    }
}