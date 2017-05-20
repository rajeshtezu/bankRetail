using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using BO;
using TYPES;

namespace DAL
{
    public partial class Operation
    {
        // private string connection = "server=intvmsql01; database=db03tms368_1617; user id=pj03tms368_1617; pwd=tcstvm";
        public Transfer getAccountData(int v)
        {
            string customerID;
            string accountID;
            string accountType;
            double balance;
            string errorMsg = "";
            Transfer tr = new Transfer();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("getAccountData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", v);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        customerID = rd[0].ToString();
                        accountID = rd[1].ToString();
                        accountType = "";
                        if (Convert.ToChar(rd[2]).Equals('S'))
                            accountType = "Saving Account";
                        else if (Convert.ToChar(rd[2]).Equals('C'))
                            accountType = "Current Account";
                        balance = Convert.ToDouble(rd[3]);
                        tr = new Transfer(customerID, accountID, accountType, balance, 0, "", "", "", 0, 0, "");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
            finally
            {
                con.Close();
                tr.ErrorMsg = errorMsg;
            }

            return tr;
        }

        public bool depositMoney(Transfer dep)
        {
            bool flag = false;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("transactMoney", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AccId", dep.SourceAccountID);
            cmd.Parameters.AddWithValue("@amount", dep.TransactionAmount);
            cmd.Parameters.AddWithValue("@transactionType", 'D');
            cmd.Parameters.AddWithValue("@transactionID", dep.TransactionId);
            cmd.Parameters.AddWithValue("@sourceAccount", 0);
            cmd.Parameters.AddWithValue("@targetAccount", 0);

            cmd.Parameters["@transactionID"].Direction = System.Data.ParameterDirection.Output;

            try
            {
                con.Open();
                int n = cmd.ExecuteNonQuery();
                dep.TransactionId = Convert.ToInt32(cmd.Parameters["@transactionID"].Value);

                if (n == 2)
                    flag = true;
            }
            catch (Exception ex)
            {
                dep.ErrorMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return flag;
        }

        public bool transferBalance(Transfer dep)
        {
            bool flag = false;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("transferMoney", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AccId", dep.SourceAccountID);
            cmd.Parameters.AddWithValue("@amount", dep.TransactionAmount);
            cmd.Parameters.AddWithValue("@transactionType", 'T');
            cmd.Parameters.AddWithValue("@transactionID", dep.TransactionId);
            cmd.Parameters.AddWithValue("@sourceAccount", dep.SourceAccountID);
            cmd.Parameters.AddWithValue("@targetAccount", dep.TargetAccountID);

            cmd.Parameters["@transactionID"].Direction = System.Data.ParameterDirection.Output;

            try
            {
                con.Open();
                int n = cmd.ExecuteNonQuery();
                dep.TransactionId = Convert.ToInt32(cmd.Parameters["@transactionID"].Value);

                if (n == 3)
                    flag = true;
            }
            catch (Exception ex)
            {
                dep.ErrorMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return flag;
        }

        public bool withdrawMoney(Transfer dep)
        {
            bool flag = false;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("transactMoney", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AccId", dep.SourceAccountID);
            cmd.Parameters.AddWithValue("@amount", -dep.TransactionAmount);
            cmd.Parameters.AddWithValue("@transactionType", 'W');
            cmd.Parameters.AddWithValue("@transactionID", dep.TransactionId);
            cmd.Parameters.AddWithValue("@sourceAccount", 0);
            cmd.Parameters.AddWithValue("@targetAccount", 0);

            cmd.Parameters["@transactionID"].Direction = System.Data.ParameterDirection.Output;

            try
            {
                con.Open();
                int n = cmd.ExecuteNonQuery();
                dep.TransactionId = Convert.ToInt32(cmd.Parameters["@transactionID"].Value);

                if (n == 2)
                    flag = true;
            }
            catch (Exception ex)
            {
                dep.ErrorMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return flag;
        }

        public StringBuilder returnMD5(string s)
        {
            StringBuilder sb = new StringBuilder();

            using (MD5 md5hash = MD5.Create())
            {
                byte[] b = md5hash.ComputeHash(Encoding.UTF8.GetBytes(s));
                for (int i = 0; i < b.Length; i++)
                {
                    sb.Append(b[i].ToString("x2"));
                }
            }
            return sb;
        }
    }
}
