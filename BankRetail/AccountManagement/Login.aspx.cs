using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

using DAL;
using BO;

namespace BankRetail
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginFail.Attributes.Add("style", "display: none;");
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["NAE"] as string))
                {
                    Response.Redirect("../AccountExecutive/Home.aspx");
                }
                else if (!string.IsNullOrEmpty(Session["CT"] as string))
                {
                    Response.Redirect("../CashierTeller/Home.aspx");
                }
                else
                {
                    Session["NAE"] = "";
                    Session["CT"] = "";
                }
            }
        }

        protected void LoginButton(object sender, EventArgs e)
        {
            string userid= userIDText.Text;
            string pass = passwordText.Text;
            string errmsg = "";

            Operation op = new Operation();
            EmpLoginData eld =  op.EmpLogin(userid, pass, out errmsg);
            
            //Error msg if any execption occurs while fetching login data
            Response.Write(errmsg);

            if (eld.Valid == 1)
            {
                Session["EmpID"] = eld.Eid;
                List<string> nt = op.GetEmpNameById(eld.Eid, out errmsg);
                Session["EmpName"] = nt[0].ToString();
                if (nt[1].ToString() == "NAE")
                    Session["EmpType"] = "Customer Account Executive";
                else if (nt[1].ToString() == "CT")
                    Session["EmpType"] = "Cashier/Teller";

                Label1.Text = "Login Successful";
                if (eld.Etype == "NAE")
                {
                    Session["NAE"] = "true";
                    Response.Redirect("../AccountExecutive/Home.aspx");
                }
                else if (eld.Etype == "CT")
                {
                    Session["CT"] = "true";
                    Response.Redirect("../CashierTeller/Home.aspx");
                }
            }
            else
            {
                loginFail.Attributes.Add("style", "visibility: visible;");
                Label1.Text = "Login Unsuccessful. Please input correct credentials. ";
            }
        }
    }
}