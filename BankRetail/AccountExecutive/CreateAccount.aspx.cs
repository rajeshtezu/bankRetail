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
    public partial class WebForm15 : System.Web.UI.Page
    {
        Operation op = new Operation();
        List<string> dummyList = new List<string>();

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

            // Loading for first time
            if (!IsPostBack)
            {
                showData(1,0, dummyList);
            }
        }

        protected void showData(int a, int id, List<string> accType)
        {
            switch (a)
            {
                case 1:
                    {
                        //show the initial data i.e. search box to search the SSN
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        checkCustomerID.Attributes.Add("style", "visibility: visible;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        newAccount.Attributes.Add("style", "display: none;");
                        creationSuccessful.Attributes.Add("style", "display: none;");
                        creationError.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
                case 2:
                    {
                        //Customer Not Fount
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        checkCustomerID.Attributes.Add("style", "visibility: visible;");
                        customerNotFound.Attributes.Add("style", "visibility: visible;");
                        newAccount.Attributes.Add("style", "display: none;");
                        creationSuccessful.Attributes.Add("style", "display: none;");
                        creationError.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
                case 3:
                    {
                        //Customer Found & Display the form
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        checkCustomerID.Attributes.Add("style", "display: none;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        newAccount.Attributes.Add("style", "visibility: visible;");
                        creationSuccessful.Attributes.Add("style", "display: none;");
                        creationError.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "display: none;");

                        fixedCustomerIDText.Text = id.ToString();
                        DropDownList1.Items[0].Attributes["disabled"] = "disabled";
                       

                        foreach (ListItem item in DropDownList1.Items)
                        {
                            foreach (string aT in accType) {
                                if ( item.Value.ToString().Equals(aT))
                                {
                                    item.Attributes.Add("disabled", "disabled");
                                    break;
                                }
                            }
                        }

                        break;
                    }
                case 4:
                    {
                        //Congratulations. customer created successfully. Display the success div.
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        checkCustomerID.Attributes.Add("style", "display: none;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        newAccount.Attributes.Add("style", "display: none;");
                        creationSuccessful.Attributes.Add("style", "visibility: visible;");
                        creationError.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
                case 5:
                    {
                        //Sorry mate. Error while creation. Don't worry. We can try again. All the best
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        checkCustomerID.Attributes.Add("style", "display: none;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        newAccount.Attributes.Add("style", "display: none;");
                        creationSuccessful.Attributes.Add("style", "display: none;");
                        creationError.Attributes.Add("style", "visibility: visible;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
            }

        }

        protected void search_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            List<string> accType = new List<string>();
            bool check = op.CheckExistingCustByCustId(Convert.ToInt32(customerIDText.Text), out errMsg);
            if (check)
            {
                accType = op.GetExistingAccByCustId(Convert.ToInt32(customerIDText.Text), out errMsg);
                showData(3, Convert.ToInt32(customerIDText.Text), accType);
            }
            else
            {
                showData(2,0, dummyList);
            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            bool check = false;
            string errMsg = "";
            string accType="";
            string acc = DropDownList1.SelectedValue.ToString();

            AccountDetails ad = null;
            int custId = Convert.ToInt32(fixedCustomerIDText.Text);
            if (acc.Equals("S"))
                accType = "Saving Account";
            if (acc.Equals("C"))
                accType = "Current Account";

            double amount = Convert.ToInt32(depositAmountText.Text) * 100;

            if (acc.Equals("S") || acc.Equals("C"))
            {
                ad = new AccountDetails(custId, 0, accType, amount, "", "", 0);
                check = op.CreateAccount(ad, out errMsg);
                if (check)
                {
                    customerIDSuccessvalue.Text = custId.ToString();
                    successAccountNumberText.Text = ad.AccId.ToString();
                    successAccountTypeText.Text = accType;
                    successDepositedAmountText.Text = (amount/100).ToString();
                    showData(4, 0, dummyList);
                }
                    
                else
                    showData(5, 0, dummyList);
            }
            else
            {
                showData(5, 0, dummyList);
            }
        }
    }
}