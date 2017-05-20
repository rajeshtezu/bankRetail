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
    public partial class WebForm4 : System.Web.UI.Page
    {
        Operation op = new Operation();
        int StateId;

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
                showData(1,0);
            }
        }

        protected void showData(int a, int custid)
        {
            switch(a)
            {
                case 1:
                    {
                        //show the initial data i.e. search box to search the SSN
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        CheckSSN.Attributes.Add("style", "visibility: visible;");
                        SSNExist.Attributes.Add("style", "display: none;");
                        newCustomer.Attributes.Add("style", "display: none;");
                        creationSuccessful.Attributes.Add("style", "display: none;");
                        creationError.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
                case 2:
                    {
                        //there is an account linked to given SSN. so display search box along with SSNExist error
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        CheckSSN.Attributes.Add("style", "visibility: visible;");
                        SSNExist.Attributes.Add("style", "visibility: visible;");
                        newCustomer.Attributes.Add("style", "display: none;");
                        creationSuccessful.Attributes.Add("style", "display: none;");
                        creationError.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
                case 3:
                    {
                        //there is no account linked to given SSN. Good to go. Create new account.
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        CheckSSN.Attributes.Add("style", "display: none;");
                        SSNExist.Attributes.Add("style", "display: none;");
                        newCustomer.Attributes.Add("style", "visibility: visible;");
                        creationSuccessful.Attributes.Add("style", "display: none;");
                        creationError.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "display: none;");

                        StateList.DataSource = op.GetStateNames();
                        StateList.DataValueField = "StateId";
                        StateList.DataTextField = "Statename";
                        StateList.DataBind();
                        break;
                    }
                case 4:
                    {
                        //Congratulations. customer created successfully. Display the success div.
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        CheckSSN.Attributes.Add("style", "display: none;");
                        SSNExist.Attributes.Add("style", "display: none;");
                        newCustomer.Attributes.Add("style", "display: none;");
                        creationSuccessful.Attributes.Add("style", "visibility: visible;");
                        creationError.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");

                        cID.Text = "<br> Customer ID: " +  custid.ToString();
                        break;
                    }
                case 5:
                    {
                        //Sorry mate. Error while creation. Don't worry. We can try again. All the best
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        CheckSSN.Attributes.Add("style", "display: none;");
                        SSNExist.Attributes.Add("style", "display: none;");
                        newCustomer.Attributes.Add("style", "display: none;");
                        creationSuccessful.Attributes.Add("style", "display: none;");
                        creationError.Attributes.Add("style", "visibility: visible;");

                        spacetoFullPage.Attributes.Add("style", "visibility: visible;");
                        break;
                    }
            }
            
        }

        protected void FormSubmit(object sender, EventArgs e)
        {
            string errMsg = "";
            int ssn;
            string name;
            int age;
            string Addr1, Addr2;
            string City;
            int Pin;

            ssn = Convert.ToInt32(fixedSSNText.Text);
            name = customerNameText.Text.ToString();
            age = Convert.ToInt32(AgeText.Text);
            Addr1 = AddressText1.Text.ToString();
            Addr2 = AddressText2.Text.ToString();
            City = CityText.Text.ToString();
            Pin = Convert.ToInt32(PINText.Text);

            CustomerDetails cd = new CustomerDetails(0,ssn, name, age, Addr1, Addr2, City,StateId, Pin);

            int custid = op.CreateCustomer(cd, out errMsg);

            if (custid != 0)
            {
                //Response.Write("<script> alert('Customer created successfully'); </script>");
                showData(4, custid);
            }
            else
            {
                //Response.Write("<script> alert('Error: "+ errMsg + "'); </script>");
                //Label1.Text = errMsg;
                showData(5, custid);
            }
        }

        protected void StateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            StateId = Convert.ToInt16(StateList.SelectedValue);
        }

        protected void search_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            bool check = op.CheckExistingCustBySsn(Convert.ToInt32(SSNText.Text), out errMsg);
            if (check)
            {
                //lblpartial.Text = "Already existed ssn";
                showData(2,0);
            }
            else
            {
                //lblpartial.Text = "You can proceed";
                //CheckSSN.Visible = false;
                showData(3,0);
                fixedSSNText.Text = SSNText.Text;
            }
            
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            customerNameText.Text = "";
            AgeText.Text = "";
            AddressText1.Text = "";
            AddressText2.Text = "";
            CityText.Text = "";
            PINText.Text = "";
        }
    }
}