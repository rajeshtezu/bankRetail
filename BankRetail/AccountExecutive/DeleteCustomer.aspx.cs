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
    public partial class WebForm6 : System.Web.UI.Page
    {
        Operation op = new Operation();
        string errMsg="";
           
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

            showData(1,0,0);

        }

        protected void showData(int a, int id, int flag)
        {
            CustomerDetails cd = null;
            string errMsg = "";

            switch (a)
            {
                case 1:
                    {
                        //show search Customer box
                        searchCustomer.Attributes.Add("style", "visibility: visible;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "display: none;");
                        deletionSuccessful.Attributes.Add("style", "display: none;");
                        deletionUnsuccessful.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 2:
                    {
                        //if customer not found
                        searchCustomer.Attributes.Add("style", "visibility: visible;");
                        customerNotFound.Attributes.Add("style", "visibility: visible;");
                        customerFound.Attributes.Add("style", "display: none;");
                        deletionSuccessful.Attributes.Add("style", "display: none;");
                        deletionUnsuccessful.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 3:
                    {
                        //if customer found
                        searchCustomer.Attributes.Add("style", "display: none;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "visibility: visible;");
                        deletionSuccessful.Attributes.Add("style", "display: none;");
                        deletionUnsuccessful.Attributes.Add("style", "display: none;");

                        //flag=1 for ssn
                        if (flag == 1)
                        {
                            cd = op.GetCustDetailsBySsn(id, out errMsg);
                        }
                        //flag=2 for id
                        else if (flag == 2)
                        {
                            cd = op.GetCustDetailsById(id, out errMsg);
                        }

                        customerIDText.Text = cd.CustId.ToString();
                        customerNameText.Text = cd.Name;
                        AgeText.Text = cd.Age.ToString();
                        AddressText.Text = cd.Addr1 + ", " + cd.Addr2 + ", City: " + cd.City + ", State: " + op.GetStateNameById(cd.StateId, out errMsg)  + ", Pin: " + cd.Pin.ToString();

                        spacetoFullPage.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 4:
                    {
                        //if deletion successfull
                        searchCustomer.Attributes.Add("style", "display: none;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "display: none;");
                        deletionSuccessful.Attributes.Add("style", "visibility: visible;");
                        deletionUnsuccessful.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 5:
                    {
                        //if deletion unsuccessful. Please try again
                        searchCustomer.Attributes.Add("style", "display: none;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "display: none;");
                        deletionSuccessful.Attributes.Add("style", "display: none;");
                        deletionUnsuccessful.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            //showData(2) if not found
            //showData(3) if found
            string value = RadioButtonList1.SelectedItem.Value.ToString();
            string errMsg = "";
            int ssnFlag = 1;
            int idFlag = 2;

            if (!string.IsNullOrEmpty(SSN_customerIdText.Text as string))
            {
                if (value == "SSN")
                {
                    if (op.CheckExistingCustBySsn(Convert.ToInt32(SSN_customerIdText.Text), out errMsg))
                    {
                        showData(3, Convert.ToInt32(SSN_customerIdText.Text), ssnFlag);
                    }
                    else
                    {
                        showData(2, 0, 0);
                    }
                }
                else if (value == "ID")
                {
                    if (op.CheckExistingCustByCustId(Convert.ToInt32(SSN_customerIdText.Text), out errMsg))
                    {
                        showData(3, Convert.ToInt32(SSN_customerIdText.Text), idFlag);
                    }
                    else
                    {
                        showData(2, 0, 0);
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter SSN/Customer ID')</script>");
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            //showData(4) if deletion successful
            //showData(5) if deletion unsuccessful
            bool success =  op.DeleteCustomerById(Convert.ToInt32(customerIDText.Text), out errMsg);
            if (success)
                showData(4, 0, 0);
            else
                showData(5, 0, 0);
        }
    }
}