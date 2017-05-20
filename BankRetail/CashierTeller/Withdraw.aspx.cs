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
    public partial class WebForm12 : System.Web.UI.Page
    {
        int sourceAccountBySession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["accountNum"] as string))
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
            switch (a)
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
            switch (v)
            {
                case 1:
                    {
                        withdrawForm.Attributes.Add("style", "visibility: visible;");
                        withdrawalSuccessful.Attributes.Add("style", "display: none;");
                        withdrawError.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 2:
                    {
                        withdrawForm.Attributes.Add("style", "display: none;");
                        withdrawalSuccessful.Attributes.Add("style", "visibility: visible;");
                        withdrawError.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 3:
                    {
                        withdrawForm.Attributes.Add("style", "display: none;");
                        withdrawalSuccessful.Attributes.Add("style", "display: none;");
                        withdrawError.Attributes.Add("style", "visibility: visible;");
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
            double withdrawAmount = Convert.ToDouble(withdrawAmountText.Text);

            
            Transfer dep = new Transfer(customerID, accountID, accountType, availableBalance, withdrawAmount, "", "", "", 0, 0, "");
            Operation op = new Operation();
            if (dep.SourceAvailableBalance > dep.TransactionAmount)
            {
                if (op.withdrawMoney(dep))
                {
                    showData(2);
                    showDetails(2);
                    transactionIDText.Text = dep.TransactionId.ToString();
                    Session["accountNum"] = "";
                }
                else
                {
                    showData(3);
                    errorMsg.Text = dep.ErrorMsg;
                    Session["accountNum"] = "";
                }
            }
            else
            {
                showData(3);
                errorMsg.Text = "Error occured. Requested amount more than the available balance.";
                Session["accountNum"] = "";
            }


        }
    }
}