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
    public partial class WebForm7 : System.Web.UI.Page
    {
        Operation op = new Operation();

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
                showData(1, 0, 0);
            }
        }

        protected void showData(int a, int id, int flag)
        {
            string errMsg = "";

            switch (a)
            {
                case 1:
                    {
                        //show search box
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchAccount.Attributes.Add("style", "visibility: visible;");
                        CustomerDetailsNotFound.Attributes.Add("style", "display: none;");
                        accountDetails.Attributes.Add("style", "display: none;");
                        deletionSuccess.Attributes.Add("style", "display: none;");
                        deletionUnsuccessfull.Attributes.Add("style", "display: none;");
                        AccountDetailsNotFound.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 2:
                    {
                        //if customer not found
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchAccount.Attributes.Add("style", "visibility: visible;");
                        CustomerDetailsNotFound.Attributes.Add("style", "visibility: visible;");
                        accountDetails.Attributes.Add("style", "display: none;");
                        deletionSuccess.Attributes.Add("style", "display: none;");
                        deletionUnsuccessfull.Attributes.Add("style", "display: none;");
                        AccountDetailsNotFound.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 3:
                    {
                        //if customer found
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchAccount.Attributes.Add("style", "display: none;");
                        CustomerDetailsNotFound.Attributes.Add("style", "display: none;");

                        deletionSuccess.Attributes.Add("style", "display: none;");
                        deletionUnsuccessfull.Attributes.Add("style", "display: none;");

                        spacetoFullPage.Attributes.Add("style", "display: none;");








                        if (flag == 1) // ssn
                        {
                            List<AccountDeletingDetails> accList = op.GetDeletingAccDetailsBySsn(id, out errMsg);

                            if (accList.Count == 0)
                            {
                                AccountDetailsNotFound.Attributes.Add("style", "visibility: visible;");
                                accountDetails.Attributes.Add("style", "display: none;");
                            }

                            else
                            {
                                GridViewAccount.DataSource = accList;
                                GridViewAccount.DataBind();

                                AccountDetailsNotFound.Attributes.Add("style", "display: none;");
                                accountDetails.Attributes.Add("style", "visibility: visible;");
                            }

                        }
                        else if (flag == 2) // id
                        {
                            List<AccountDeletingDetails> accList = op.GetDeletingAccDetailsById(id, out errMsg);

                            if (accList.Count == 0)
                            {
                                AccountDetailsNotFound.Attributes.Add("style", "visibility: visible;");
                                accountDetails.Attributes.Add("style", "display: none;");
                            }

                            else
                            {
                                GridViewAccount.DataSource = accList;
                                GridViewAccount.DataBind();

                                AccountDetailsNotFound.Attributes.Add("style", "display: none;");
                                accountDetails.Attributes.Add("style", "visibility: visible;");
                            }
                        }
                    }
                    break;

                case 4:
                    {
                        //if deletion successfull
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchAccount.Attributes.Add("style", "display: none;");
                        CustomerDetailsNotFound.Attributes.Add("style", "display: none;");
                        accountDetails.Attributes.Add("style", "display: none;");
                        deletionSuccess.Attributes.Add("style", "visibility: visible;");
                        deletionUnsuccessfull.Attributes.Add("style", "display: none;");
                        AccountDetailsNotFound.Attributes.Add("style", "display: none;");
                        break;
                    }
                case 5:
                    {
                        //if deletion unsuccessful. Please try again
                        ScriptManager.GetCurrent(Page).RegisterPostBackControl(search);
                        searchAccount.Attributes.Add("style", "display: none;");
                        CustomerDetailsNotFound.Attributes.Add("style", "display: none;");
                        accountDetails.Attributes.Add("style", "display: none;");
                        deletionSuccess.Attributes.Add("style", "visibility: visible;");
                        deletionUnsuccessfull.Attributes.Add("style", "display: none;");
                        AccountDetailsNotFound.Attributes.Add("style", "display: none;");
                        break;
                    }
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            int ssnFlag = 1;
            int idFlag = 2;
            string errMsg = "";
            bool check = false;
            //showData 
            //1 show search box
            //2 show customer not found
            //3 customer found with details
            //4 deletion successful

            if (!string.IsNullOrEmpty(SSN_CustomerIDText.Text as string))
            {
                if (RadioButtonList1.SelectedValue.ToString().Equals("SSN"))
                {
                    check = op.CheckExistingCustBySsn(Convert.ToInt32(SSN_CustomerIDText.Text), out errMsg);
                    if (check)
                    {
                        showData(3, Convert.ToInt32(SSN_CustomerIDText.Text), ssnFlag);
                    }
                    else
                    {
                        showData(2, 0, 0);
                    }
                }
                else if (RadioButtonList1.SelectedValue.ToString().Equals("ID"))
                {
                    check = op.CheckExistingCustByCustId(Convert.ToInt32(SSN_CustomerIDText.Text), out errMsg);
                    if (check)
                    {
                        showData(3, Convert.ToInt32(SSN_CustomerIDText.Text), idFlag);
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

        protected void GridViewAccount_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string errMsg = "";
            Label lb1 = (Label)GridViewAccount.Rows[e.RowIndex].FindControl("AccNoLabel");
            int accid = Convert.ToInt32(lb1.Text);

            Label lb2 = (Label)GridViewAccount.Rows[e.RowIndex].FindControl("CustIDLabel");
            int custid = Convert.ToInt32(lb2.Text);

            bool check = op.DeleteAccount(accid, out errMsg);

            if (check)
            {
                Response.Write("<script> alert('Account deletion initiated successfully')</script>");
            }
            else
            {
                Response.Write("<script> alert('Account deletion Failed') </script>");
            }

            showData(3, custid, 2);
        }
    }
}