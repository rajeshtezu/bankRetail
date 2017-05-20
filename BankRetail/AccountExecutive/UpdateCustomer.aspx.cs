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
    public partial class UpdateCustomer : System.Web.UI.Page
    {
        Operation op = new Operation();
        int stateId;

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
                showData(1,0,0);
            }
        }

        protected void showData(int a, int id, int flag)
        {
            string errMsg = "";
            CustomerDetails cd = null;
            switch(a)
            {
                case 1:
                    {
                        // search box
                        //ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchCustomer.Attributes.Add("style", "visibility: visible;");
                        noCustomer.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "display: none;");
                        updationSuccessful.Attributes.Add("style", "display: none;");
                        errorInUpdation.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
                case 2:
                    {
                        //search box and error box(customer not found)
                        //ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchCustomer.Attributes.Add("style", "visibility: visible;");
                        noCustomer.Attributes.Add("style", "visibility: visible;");
                        customerFound.Attributes.Add("style", "display: none;");
                        updationSuccessful.Attributes.Add("style", "display: none;");
                        errorInUpdation.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
                case 3:
                    {
                        // customer found. display form
                        //ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchCustomer.Attributes.Add("style", "display: none;");
                        noCustomer.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "visibility: visible;");
                        updationSuccessful.Attributes.Add("style", "display: none;");
                        errorInUpdation.Attributes.Add("style", "display: none;");

                        if (flag == 1)
                        {
                            cd = op.GetCustDetailsBySsn(id, out errMsg);
                        }
                        else if (flag == 2)
                        {
                            cd = op.GetCustDetailsById(id, out errMsg);
                        }

                        fixedCustomerIDText.Text = cd.CustId.ToString();
                        customerNameText.Text = cd.Name;
                        AgeText.Text = cd.Age.ToString();
                        AddressText1.Text = cd.Addr1;
                        AddressText2.Text = cd.Addr2;
                        CityText.Text = cd.City;
                        PinText.Text = cd.Pin.ToString();
                        int stateId = cd.StateId;

                        StateList.DataSource = op.GetStateNames();
                        StateList.DataValueField = "StateId";
                        StateList.DataTextField = "Statename";
                        StateList.DataBind();
                        StateList.SelectedValue = stateId.ToString();

                        spacetoFullPage.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 4:
                    {
                        // updation successfull
                        //ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchCustomer.Attributes.Add("style", "display: none;");
                        noCustomer.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "display: none;");
                        updationSuccessful.Attributes.Add("style", "visibility: visible;");
                        errorInUpdation.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
                case 5:
                    {
                        // updation failed
                        //ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchCustomer.Attributes.Add("style", "display: none;");
                        noCustomer.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "display: none;");
                        updationSuccessful.Attributes.Add("style", "display: none;");
                        errorInUpdation.Attributes.Add("style", "visibility: visible;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
            }

        }

        protected void search_Click(object sender, EventArgs e)
        {
            string value = RadioButtonList1.SelectedItem.Value.ToString();
            string errMsg = "";
            int ssnFlag = 1;
            int idFlag = 2;
            if (!string.IsNullOrEmpty(SSN_customerIDText.Text as string))
            {
                if (value == "SSN")
                {
                    if (op.CheckExistingCustBySsn(Convert.ToInt32(SSN_customerIDText.Text), out errMsg))
                    {
                        showData(3, Convert.ToInt32(SSN_customerIDText.Text), ssnFlag);
                    }
                    else
                    {
                        showData(2, 0, 0);
                    }
                }
                else if (value == "ID")
                {
                    if (op.CheckExistingCustByCustId(Convert.ToInt32(SSN_customerIDText.Text), out errMsg))
                    {
                        showData(3, Convert.ToInt32(SSN_customerIDText.Text), idFlag);
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



            //bool check = true;// op.CheckExistingCustBySsn(Convert.ToInt32(SSNText.Text), out errMsg);
            //if (check)
            //{
            //    showData(2);
            //}
            //else
            //{
            //    showData(3);
            //}
        }

        protected void StateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            stateId = Convert.ToInt16(StateList.SelectedValue);
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            int ssnFlag = 1;
            int idFlag = 2;
            string value = RadioButtonList1.SelectedItem.Value.ToString();
            if(value == "SSN")
            {
                showData(3, Convert.ToInt32(SSN_customerIDText.Text), ssnFlag);
            }
            else if (value == "ID")
            {
                showData(3, Convert.ToInt32(SSN_customerIDText.Text), idFlag);
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            int custId = Convert.ToInt32(fixedCustomerIDText.Text.Trim());
            string custName = customerNameText.Text.Trim();
            int custAge = Convert.ToInt16(AgeText.Text.Trim());
            string addr1 = AddressText1.Text.Trim();
            string addr2 = AddressText2.Text.Trim();
            string city = CityText.Text.Trim();
            int pin = Convert.ToInt32(PinText.Text.Trim());

            stateId = Convert.ToInt32(StateList.SelectedValue);

            CustomerDetails cd = new CustomerDetails(custId,0, custName, custAge, addr1, addr2, city, stateId, pin);

            bool check = op.updateCustomer(cd, out errMsg);

            if (check)
                showData(4, 0, 0);
            else
                showData(5, 0, 0);
        }

      
    }
}