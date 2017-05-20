using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace BankRetail.AccountManagement
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //string errorMessage = "Couldn't process password change. Try again later.";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                showData(1);
            }
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["EmpID"].ToString());
            string lastPassword = lastPasswordText.Text;
            string newPassword = newPasswordText.Text;
            string confirmedPassword = confirmPasswordText.Text;
            

            Operation op = new Operation();

            if(op.isCorrectPassword(id,lastPassword))
            {
                if(newPassword==confirmedPassword)
                {
                    if(op.changePassword(id,newPassword))
                    {
                        showData(3);
                        Session["NAE"] = "";
                        Session["CT"] = "";
                        //HtmlMeta meta = new HtmlMeta();
                        //meta.HttpEquiv = "Refresh";
                        //meta.Content = "5;url=AccountManagement/Login.aspx";
                        //this.Page.Controls.Add(meta);
                        Response.AddHeader("Refresh", "5;url=changepassword.aspx");
                    }
                    else
                    {
                        showData(1);
                        showData(2);
                        errorMessageLabel.Text = "Couldn't process password change. Try again later.";
                        
                    }
                }
                else
                {
                    showData(1);
                    showData(2);
                    errorMessageLabel.Text = "New passwords doesn't match. Try again.";

                }


            }
            else
            {
                showData(1);
                showData(2);
                errorMessageLabel.Text = "Password change unsuccessful. Please Input Correct password";
            }

        }

        protected void showData(int a)
        {
            switch(a)
            {
                case 1:
                    {
                        changePasswordDiv.Attributes.Add("style", "visibility: visible;");
                        changeUnsuccessful.Attributes.Add("style", "display: none;");
                        changeSuccessful.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 2:
                    {
                        changePasswordDiv.Attributes.Add("style", "display: none;");
                        changeUnsuccessful.Attributes.Add("style", "visibility: visible;");
                        changeSuccessful.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 3:
                    {
                        changePasswordDiv.Attributes.Add("style", "display: none;");
                        changeUnsuccessful.Attributes.Add("style", "display: none;");
                        changeSuccessful.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
            }
        }
    }
}