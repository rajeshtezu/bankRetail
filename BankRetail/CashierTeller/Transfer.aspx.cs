using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using DAL;
using BO;

namespace BankRetail
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        int sourceAccount;
        int targetAccount;
        double transferAmount;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlTitle)Master.FindControl("masterTitle")).Text += ":: Transfer";
            if(!IsPostBack)
            {
                Session["transfer"] = "true";
            }
            showData(1);
        }

        private void showDetails(int a)
        {
            switch (a)
            {
                case 1:
                    {
                        //GetDataItem();
                        
                        break;
                    }
                case 2:
                    {
                        //aftr success deposit
                        Operation op = new Operation();
                        Transfer target = op.getAccountData(sourceAccount);               
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
                        //Show Transfer form
                        transferForm.Attributes.Add("style", "visibility: visible;");
                        accountNotFound.Attributes.Add("style", "display: none;");
                        inefficientBalance.Attributes.Add("style", "display: none;");
                        transferSuccessful.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 2:
                    {
                        //account not found
                        transferForm.Attributes.Add("style", "display: none;");
                        accountNotFound.Attributes.Add("style", "visibility: visible;");
                        inefficientBalance.Attributes.Add("style", "display: none;");
                        transferSuccessful.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 3:
                    {
                        //insufficient balance
                        transferForm.Attributes.Add("style", "display: none;");
                        accountNotFound.Attributes.Add("style", "display: none;");
                        inefficientBalance.Attributes.Add("style", "visibility: visible;");
                        transferSuccessful.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 4:
                    {
                        //transfer success
                        transferForm.Attributes.Add("style", "display: none;");
                        accountNotFound.Attributes.Add("style", "display: none;");
                        inefficientBalance.Attributes.Add("style", "display: none;");
                        transferSuccessful.Attributes.Add("style", "visibility: visible;");

                        manageSpace.Attributes.Add("style", "display: none;");
                        break;
                    }
            }
        }

        protected void transfer_Click(object sender, EventArgs e)
        {
            Transfer tr = new Transfer();
            sourceAccount = Convert.ToInt32(sourceAccountText.Text);
            targetAccount = Convert.ToInt32(targetAccountText.Text);
            transferAmount = Convert.ToDouble(transferAmountText.Text);

            Operation op = new Operation();
            if (!string.IsNullOrEmpty(Session["transfer"] as string))
            {
                if (op.doAccountExist(sourceAccount))
                {
                    if (op.doAccountExist(targetAccount))
                    {
                        Transfer src = op.getAccountData(sourceAccount);
                        Transfer trg = op.getAccountData(targetAccount);
                        if (src.SourceAvailableBalance < transferAmount)
                        {
                            showData(3);
                            errorMsg.Text = src.ErrorMsg;
                        }
                        else
                        {
                            tr = new Transfer("", sourceAccount.ToString(), "", 0, transferAmount, targetAccount.ToString(), "", "", 0, 0, "");
                            if (op.transferBalance(tr))
                            {
                                //transfer success
                                showData(4);
                                showDetails(2);
                                successSourceAccountIDText.Text = src.SourceAccountID.ToString();
                                successTargetAccountIDText.Text = trg.SourceAccountID.ToString();
                                transactionIDText.Text = tr.TransactionId.ToString();
                                successBalPrTrnsctnSrcAccntText.Text = src.SourceAvailableBalance.ToString();
                                successBalPrTrnsctnTrgAccntText.Text = trg.SourceAvailableBalance.ToString();
                                src = op.getAccountData(sourceAccount);
                                trg = op.getAccountData(targetAccount);
                                successBalPoTrnsctnSrcAccntText.Text = src.SourceAvailableBalance.ToString();
                                successBalPoTrnsctnTrgAccntText.Text = trg.SourceAvailableBalance.ToString();
                                Session["transfer"] = "";
                            }
                        }
                    }
                    else
                    {
                        showData(2);
                        accountDet.Text = "Target Account is not available.";
                    }
                }


                else
                {
                    showData(2);
                    accountDet.Text = "Source Account is not available.";
                }
            }
            else
            {
                Session["transfer"] = "";
                Response.Redirect("Transfer.aspx");
            }

        }



    }
}