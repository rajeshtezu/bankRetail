using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BO;
using DAL;

namespace BankRetail
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        int sourceAccountBySession;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(Session["accountNum"] as string)))
            {
                sourceAccountBySession = Convert.ToInt32(Session["accountNum"]);
            }
            else
            {
                Response.Redirect("CustomerSearch.aspx");
            }
            showData(1);
            showDetails(1);
        }

        private void showDetails(int a)
        {
            switch(a)
            {
                case 1:
                    {
                        //GetDataItem();
                        Operation op = new Operation();
                        Transfer dep = op.getAccountData(sourceAccountBySession);
                        customerIDText.Text = dep.SourceCustomerID;
                        accountIDText.Text = dep.SourceAccountID;
                        accountTypeText.Text = dep.SourceAccountType;
                        availableBalanceText.Text = dep.SourceAvailableBalance.ToString();
                        break;
                    }
                case 2:
                    {
                        //aftr success deposit
                        Operation op = new Operation();
                        Transfer tr = op.getAccountData(sourceAccountBySession);
                        successAccountIDText.Text = tr.SourceAccountID;
                        successCustomerIDText.Text = tr.SourceCustomerID;
                        successAccountTypeText.Text = tr.SourceAccountType;
                        successAvailableBalanceText.Text = tr.SourceAvailableBalance.ToString();
                        transactionIDText.Text = tr.TransactionId.ToString();
                        break;
                    }
            }
            
        }

        private void showData(int v)
        {
            switch(v)
            {
                case 1:
                    {
                        depositForm.Attributes.Add("style", "visibility: visible;");
                        depositSuccessful.Attributes.Add("style", "display: none;");
                        depositError.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 2:
                    {
                        depositForm.Attributes.Add("style", "display: none;");
                        depositSuccessful.Attributes.Add("style", "visibility: visible;");
                        depositError.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 3:
                    {
                        depositForm.Attributes.Add("style", "display: none;");
                        depositSuccessful.Attributes.Add("style", "display: none;");
                        depositError.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            string customerID = customerIDText.Text;
            string accountID = accountIDText.Text;
            string accountType = accountTypeText.Text;
            double availableBalance = Convert.ToDouble(availableBalanceText.Text);
            double depositAmount = Convert.ToDouble(depositAmountText.Text);

            Transfer dep = new Transfer(customerID, accountID, accountType, availableBalance, depositAmount, "", "", "", 0, 0, "");
            Operation op = new Operation();
            if(op.depositMoney(dep))
            {
                showData(2);
                showDetails(2);
                transactionIDText.Text = dep.TransactionId.ToString();
                Session["accountNum"] = "";
            }
            else
            {
                showData(3);
                Session["accountNum"] = "";
            }


        }
    }
}