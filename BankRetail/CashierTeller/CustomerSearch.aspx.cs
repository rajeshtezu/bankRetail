using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Cryptography;
using System.Text;

using BO;
using DAL;

namespace BankRetail.CashierTeller
{
    public partial class Customer : System.Web.UI.Page
    {
        Operation op = new Operation();

        protected void Page_Load(object sender, EventArgs e)
        {
            // string text1 = "hello";
            // string text2 = "hello ";
            // string text3 = "Hello";
            // Response.Write("\nhello world:" + returnMD5(text1)+" "+returnMD5(text1).Length);
            // Response.Write("<br />hello world:" + returnMD5(text2));
            // Response.Write("<br />hello world:" + returnMD5(text3));

            showData(1, 0, 0);
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
                        searchCustomerForm.Attributes.Add("style", "visibility: visible;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 2:
                    {
                        //if customer not found
                        searchCustomerForm.Attributes.Add("style", "visibility: visible;");
                        customerNotFound.Attributes.Add("style", "visibility: visible;");
                        customerFound.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 3:
                    {
                        //if customer found
                        searchCustomerForm.Attributes.Add("style", "display: none;");
                        customerNotFound.Attributes.Add("style", "display: none;");
                        customerFound.Attributes.Add("style", "visibility: visible;");

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

                        CustomerSSNText.Text = cd.Ssn.ToString();
                        CustomerIDText.Text = cd.CustId.ToString();
                        customerNameText.Text = cd.Name;
                        customerAgetext.Text = cd.Age.ToString();
                        cutomerAddressText.Text = cd.Addr1 + ", " + cd.Addr2 + ", City: " + cd.City + ", State: " + op.GetStateNameById(cd.StateId, out errMsg) + ", Pin: " + cd.Pin.ToString();
                        addAccountList(cd.CustId);
                        spacetoFullPage.Attributes.Add("style", "display: none;");
                        break;
                    }
                
            }
        }

        private void addAccountList(int custId)
        {
            string errorMSG = "";
            Operation opr = new Operation();
            GridView1.DataSource = opr.GetDeletingAccDetailsById(custId,out errorMSG);
            GridView1.DataBind();
        }

        protected StringBuilder returnMD5(string s)
        {
            StringBuilder s1 = new StringBuilder();

            using (MD5 md5hash = MD5.Create())
            {
                byte[] d1 = md5hash.ComputeHash(Encoding.UTF8.GetBytes(s));
                for (int i = 0; i < d1.Length; i++)
                {
                    s1.Append(d1[i].ToString("x2"));
                }
            }
            return s1;

        }

        protected void search_Click(object sender, EventArgs e)
        {
            string value = RadioButtonList1.SelectedItem.Value.ToString();
            string errMsg = "";
            int ssnFlag = 1;
            int idFlag = 2;
            if (value == "SSN")
            {
                if (op.CheckExistingCustBySsn(Convert.ToInt32(SSN_CustomerIDText.Text), out errMsg))
                {
                    showData(3, Convert.ToInt32(SSN_CustomerIDText.Text), ssnFlag);
                }
                else
                {
                    showData(2, 0, 0);
                }
            }
            else if (value == "ID")
            {
                if (op.CheckExistingCustByCustId(Convert.ToInt32(SSN_CustomerIDText.Text), out errMsg))
                {
                    showData(3, Convert.ToInt32(SSN_CustomerIDText.Text), idFlag);
                }
                else
                {
                    showData(2, 0, 0);
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int accountNum = Convert.ToInt32(e.CommandArgument);
            Session["accountNum"] = accountNum.ToString();
            if(e.CommandName== "deposit")
            {
                Response.Redirect("Deposit.aspx");
            }
            else if(e.CommandName== "withdraw")
            {
                Response.Redirect("Withdraw.aspx");
            }
            else if(e.CommandName=="transfer")
            {
                Response.Redirect("Transfer.aspx");
            }

           
        }
    }
}