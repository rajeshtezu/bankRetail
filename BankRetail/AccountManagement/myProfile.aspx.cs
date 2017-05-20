using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BO;

namespace BankRetail.AccountManagement
{
    public partial class myProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showData();
        }

        protected void showData()
        {
            Operation op = new Operation();
            EmpDetails employee = op.getEmpDetails(Convert.ToInt32(Session["EmpID"]));

            empID.Text = employee.Id.ToString();
            empName.Text = employee.Name;
            empType.Text = employee.Type;
            if (employee.Gender == "Male")
            {
                empGenderMale.Attributes.Add("style", "visibility: visible;");
                empGenderFemale.Attributes.Add("style", "display: none;");
            }
            else
            {
                empGenderFemale.Attributes.Add("style", "visibility: visible;");
                empGenderMale.Attributes.Add("style", "display: none;");
            }
        }

    }
}