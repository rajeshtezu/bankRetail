﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using DAL;

namespace BankRetail
{
    public partial class WebForm8 : System.Web.UI.Page
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

            showData();
        }

        protected void showData()
        {
            Operation op = new Operation();
            GridView1.DataSource = op.getCustomerStatus();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            showData();

        }
    }
}