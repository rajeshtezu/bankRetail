using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using BO;

namespace DAL
{
    public partial class Operation
    {
        // private string connection = "server=intvmsql01; database=db03tms368_1617; user id=pj03tms368_1617; pwd=tcstvm";
        public object cashier_trn_statement(cashier_transactions obj)
        {
            List<cashier_transactions> status = new List<cashier_transactions>();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("cash_trn_statement", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@accID", obj.Account_id);
            cmd.Parameters.AddWithValue("@tno", obj.N_trn);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        DateTime date = Convert.ToDateTime(rd[0].ToString());
                        string trn_description = (rd[1].ToString());
                        string trn_type = (rd[2].ToString());
                        int balance = Convert.ToInt32(rd[3].ToString());
                        cashier_transactions trn = new cashier_transactions(date, trn_description, trn_type, balance);
                        status.Add(trn);
                    }
                }
            }
            catch (Exception ex)
            {
                //errMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return status;
        }

       }

}
