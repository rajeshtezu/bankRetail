using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using TYPES;
using BO;

namespace DAL
{
    public partial class Operation
    {
         private string connection = "server=intvmsql01; database=db03tms368_1617; user id=pj03tms368_1617; pwd=tcstvm";

        //private string connection = "server=ABHISHEKVERMA\\SQLEXPRESS; database=master; user id=sa; pwd=tiger";


        //to convert string to camelCase
        public string camelCase(string literal)
        {
            String value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(literal);
            return value;
        }

        public EmpDetails getEmpDetails(int id)
        {
            int empID = id;
            string name = "";
            string gender = "";
            string employeeType = "";
            string errMsg = "";

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("getEmpDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        empID = Convert.ToInt32(rd[3].ToString().Trim());
                        name = camelCase(rd[0].ToString().Trim());
                        if(rd[2].ToString()=="M")
                        {
                            gender = "Male";
                        }
                        else
                        {
                            gender = "Female";
                        }
                        if(rd[1].ToString()=="NAE")
                        {
                            employeeType = "Customer Account Executive";
                        }
                        else
                        {
                            employeeType = "Cashier";
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message; 
            }
            finally
            {
                con.Close();
            }

            EmpDetails employee = new EmpDetails(empID, name, gender, employeeType, errMsg);
            return employee;
        }

        public List<customerStatus> getCustomerStatus()
        {
            List<customerStatus> status = new List<customerStatus>();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("checkLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int customerID = Convert.ToInt32(rd[0].ToString());
                        int customerSSN = Convert.ToInt32(rd[1].ToString());
                        string customerStatusValue = rd[2].ToString();
                        string customerMessage = rd[3].ToString();
                        string lastUpdated = rd[4].ToString();
                        customerStatus cs = new customerStatus(customerID, customerSSN, customerStatusValue, customerMessage, lastUpdated);
                        status.Add(cs);
                    }
                }
            }
            catch 
            {
                //errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return status;
        }

        public bool isCorrectPassword(int id, string password)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("checkLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", id);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                con.Open();
                int num = Convert.ToInt32(cmd.ExecuteScalar());
                if(num==1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            finally
            {
                con.Close();
            }
            return flag;
        }

        public bool doAccountExist(int sourceAccount)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("checkAccountById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", sourceAccount);

            try
            {
                con.Open();
                int num = Convert.ToInt32(cmd.ExecuteScalar());
                if (num == 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            finally
            {
                con.Close();
            }
            return flag;
        }

        public bool changePassword(int id, string newPassword)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("updatePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@password", newPassword);

            try
            {
                con.Open();
                int num = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (num == 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            finally
            {
                con.Close();
            }
            return flag;
        }

        public EmpLoginData EmpLogin(string userid, string pass, out string except)
        {
            int id=0;
            string type="";
            int val=0;
            except = "";
            
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("CheckCredit_1290881", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", userid);
            cmd.Parameters.AddWithValue("@password", pass);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        id = Convert.ToInt32(rd[0]);
                        type = rd[1].ToString();
                        val = Convert.ToInt32(rd[2]);                        
                    }
                }
            }
            catch (Exception ex)
            {
                except = "<script>alert('Error: " + ex.Message + "');</script>";   
            }
            finally
            {
                con.Close();
            }

            EmpLoginData eld = new EmpLoginData(id, type, val);
            return eld;
        }

        public List<string> GetEmpNameById(int id, out string except)
        {
            List<string> eNameType = new List<string>();
            string name = "";
            string EmpType = "";
            except = "";
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("FetchEmpNameType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", id);
            try
            {
                con.Open();
                SqlDataReader rd1 = cmd.ExecuteReader();

                if (rd1.HasRows)
                {
                    while (rd1.Read())
                    {
                        name = rd1[0].ToString();
                        EmpType = rd1[1].ToString();
                        eNameType.Add(name);
                        eNameType.Add(EmpType);
                    }
                }
            }
            catch (Exception ex)
            {
                except = "<script>alert('Error: " + ex.Message + "');</script>";
            }
            finally
            {
                con.Close();
            }
            return eNameType;
        }

        public DataSet GetStateNames()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("GetStates", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        public bool CheckExistingCustBySsn(int ssn, out string ErrMsg)
        {
            bool check = false;
            ErrMsg = "";
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("checkExistingCustBySsn", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ssn", ssn);

            try
            {
                con.Open();
                int n = Convert.ToInt16(cmd.ExecuteScalar());
                if (n == 1)
                    check = true;
                else
                    check = false;
            }
            catch(Exception e)
            {
                ErrMsg = e.Message;
            }
            finally
            {
                con.Close();
            }

            return check;
        }

        public bool CheckExistingCustByCustId(int id, out string ErrMsg)
        {
            bool check = false;
            ErrMsg = "";
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("checkExistingCustByID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                int n = Convert.ToInt16(cmd.ExecuteScalar());
                if (n == 1)
                    check = true;
                else
                    check = false;
            }
            catch (Exception e)
            {
                ErrMsg = e.Message;
            }
            finally
            {
                con.Close();
            }

            return check;
        }

        public int CreateCustomer(CustomerDetails cust, out string errMsg)
        {
            errMsg = "";
            int customerId = 0;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("CreateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ssn", cust.Ssn);
            cmd.Parameters.AddWithValue("@name", cust.Name);
            cmd.Parameters.AddWithValue("@age", cust.Age);
            cmd.Parameters.AddWithValue("@Addr1", cust.Addr1);
            cmd.Parameters.AddWithValue("@Addr2", cust.Addr2);
            cmd.Parameters.AddWithValue("@City", cust.City);
            cmd.Parameters.AddWithValue("@StateId", cust.StateId);
            cmd.Parameters.AddWithValue("@Pin", cust.Pin);
            //cmd.Parameters.AddWithValue("@lastUpdateDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@customerId",0);

            cmd.Parameters["@customerId"].Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                int n = cmd.ExecuteNonQuery();
                customerId = Convert.ToInt32(cmd.Parameters["@customerId"].Value);
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return customerId;
        }
        
        public CustomerDetails GetCustDetailsById(int id, out string errMsg)
        {
            errMsg = "";
            CustomerDetails cd = null;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("GetCustDataById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        cd = new CustomerDetails(Convert.ToInt32(rd[0]), Convert.ToInt32(rd[1]), rd[2].ToString(), Convert.ToInt16(rd[3]), rd[4].ToString(),
                                                rd[5].ToString(), rd[6].ToString(), Convert.ToInt16(rd[7]), Convert.ToInt32(rd[8]));
                    }
                }
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cd;
        }

        public CustomerDetails GetCustDetailsBySsn(int ssn, out string errMsg)
        {
            errMsg = "";
            CustomerDetails cd = null;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("GetCustDataBySsn", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ssn", ssn);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        cd = new CustomerDetails(Convert.ToInt32(rd[0]), Convert.ToInt32(rd[1]), rd[2].ToString(), Convert.ToInt16(rd[3]), rd[4].ToString(),
                                                rd[5].ToString(), rd[6].ToString(), Convert.ToInt16(rd[7]), Convert.ToInt32(rd[8]));
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return cd;
        }

        public bool updateCustomer(CustomerDetails cd, out string errMsg)
        {
            errMsg = "";
            bool check = false;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("UpdateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id",cd.CustId);
            cmd.Parameters.AddWithValue("@name",cd.Name);
            cmd.Parameters.AddWithValue("@age",cd.Age);
            cmd.Parameters.AddWithValue("@addrLine1",cd.Addr1);
            cmd.Parameters.AddWithValue("@addrLine2",cd.Addr2);
            cmd.Parameters.AddWithValue("@city",cd.City);
            cmd.Parameters.AddWithValue("@stateId",cd.StateId);
            cmd.Parameters.AddWithValue("@pin",cd.Pin);

            try
            {
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                    check = true;

            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return check;
        }

        public string GetStateNameById(int stateId, out string errMsg)
        {
            errMsg = "";
            string sName="";
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("GetStateNameByStateId", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", stateId);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                        sName = rd[0].ToString();
                } 

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return sName;
        }

        public bool DeleteCustomerById(int id, out string errMsg)
        {
            bool check = false;
            errMsg = "";

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("DeleteCustById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                int n = Convert.ToInt16(cmd.ExecuteNonQuery());
                if (n > 0)
                    check = true;
                else
                    check = false;
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return check;
        }

        public bool CreateAccount(AccountDetails ad, out string errMsg)
        {
            bool check = false;
            errMsg = "";

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("CreateAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cId", ad.CustId);
            cmd.Parameters.AddWithValue("@accType", ad.AccType);
            cmd.Parameters.AddWithValue("@bal", ad.Balance);
            cmd.Parameters.AddWithValue("@accId", ad.AccId);

            cmd.Parameters["@accId"].Direction = System.Data.ParameterDirection.Output;

            try
            {
                con.Open();
                int n = cmd.ExecuteNonQuery();
                ad.AccId = Convert.ToInt32(cmd.Parameters["@accId"].Value);

                if (n > 0)
                    check = true;
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return check;
        }

        public List<string> GetExistingAccByCustId(int id, out string errMsg)
        {
            errMsg = "";
            List<string> accList = new List<string>();

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("GetExistingAcc", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@custId", id);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        accList.Add(rd[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return accList;
        }

        public List<AccountStatus> GetAccountStatus(out string errMsg)
        {
            errMsg = "";
            List<AccountStatus> accStList = new List<AccountStatus>();

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("fetchAccStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string accT = rd[2].ToString();
                        if (accT == "S")
                            accT = "Saving Account";
                        else if (accT == "C")
                            accT = "Current Account";
                        AccountStatus accSt = new AccountStatus(Convert.ToInt32(rd[0]), Convert.ToInt32(rd[1]), accT, rd[3].ToString(), rd[4].ToString(), rd[5].ToString());
                        accStList.Add(accSt);
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return accStList;
        }

        public List<AccountDeletingDetails> GetDeletingAccDetailsById(int cId, out string errMsg)
        {
            List<AccountDeletingDetails> add = new List<AccountDeletingDetails>();
            errMsg = "";
            string t="";

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("fetchDelAccDetailsById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@custId", cId);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[3].ToString().Equals("S"))
                            t = "Saving";
                        else if(rd[3].ToString().Equals("C"))
                            t = "Current";
                        AccountDeletingDetails a = new AccountDeletingDetails(Convert.ToInt32(rd[0]), Convert.ToInt32(rd[1]), rd[2].ToString(), t, Convert.ToDouble(rd[4])/100);
                        add.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return add;
        }

        public List<AccountDeletingDetails> GetDeletingAccDetailsBySsn(int ssn, out string errMsg)
        {
            List<AccountDeletingDetails> add = new List<AccountDeletingDetails>();
            errMsg = "";
            string t = "";

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("fetchDelAccDetailsBySsn", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ssn", ssn);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[3].ToString().Equals("S"))
                            t = "Saving";
                        else if (rd[3].ToString().Equals("C"))
                            t = "Current";
                        AccountDeletingDetails a = new AccountDeletingDetails(Convert.ToInt32(rd[0]), Convert.ToInt32(rd[1]), rd[2].ToString(), t, Convert.ToDouble(rd[4])/100);
                        add.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return add;
        }

        public bool DeleteAccount(int aId, out string errMsg)
        {
            bool check = false;
            errMsg = "";

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("DeleteAcc", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@accId", aId);

            try
            {
                con.Open();
                int n = Convert.ToInt16(cmd.ExecuteNonQuery());
                if (n > 0)
                    check = true;
                else
                    check = false;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return check;
        }

    }
}
