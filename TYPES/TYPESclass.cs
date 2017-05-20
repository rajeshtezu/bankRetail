using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace TYPES
{
    public interface ITransfer
    {
        string SourceCustomerID { get; set; }
        string SourceAccountID { get; set; }
        string SourceAccountType { get; set; }
        double SourceAvailableBalance { get; set; }
        double TransactionAmount { get; set; }
        string TargetAccountID { get; set; }
        string TargetCustomerID { get; set; }
        string TargetAccountType { get; set; }
        double TargetAvailableBalance { get; set; }
        int TransactionId { get; set; }
        string ErrorMsg { get; set; }
    }

    public interface IEmpLoginData
    {
        int Eid { set; get; }
        string Etype { set; get; }
        int Valid { set; get; }
    }

    public interface ICustomerDetails
    {
        int Ssn{ get; set; }

        string Name { get; set; }

        int Age { get; set; }

        string Addr1 { get; set; }

        string Addr2 { get; set; }

        string City { get; set; }

        int StateId { get; set; }

        int Pin { get; set; }

        int CustId { get; set; }
    }          

    public interface IEmpDetails
    {
        int Id { set; get; }

        string Name { set; get; }

        string Gender { set; get; }

        string Type { set; get; }

        string ErrMsg { set; get; }
    }

    public interface IAccountDetails
    {
        int CustId { get; set; }
        int AccId { get; set; }
        string AccType { get; set; }
        double Balance { get; set; }
        string CrDate { get; set; }
        string CrLastDate { get; set; }
        int Duration { get; set; }
    }

    public interface IAccountStatus
    {
        int CustId { get; set; }
        int AccId { get; set; }
        string AccType { get; set; }
        string Status { get; set; }
        string Msg { get; set; }
        string LastUpdated { get; set; }
    }

    public interface IcustomerStatus
    {
        int CustomerID { get; set; }
        int CustomerSSN { get; set; }
        string CustomerStatusValue { get; set; }
        string CustomerMessage { get; set; }
        string LastUpdated { get; set; }
    }

    public interface Icashier_transactions
    {
        int Account_id { get; set; }
        int N_trn { get; set; }
        DateTime Date { get; set; }
        string Trn_description { get; set; }
        string Trn_type { get; set; }
        int Balance { get; set; }
    }

    public interface IAccountDeletingDetails
    {
        int AccNo { get; set; }
        int CustId { get; set; }
        string CustName { get; set; }
        string AccType { get; set; }
        double Balance { get; set; }
    }

    public interface IOperation
    {
        //to convert string to camelCase
        string camelCase(string literal);

        IEmpDetails getEmpDetails(int id);
        
        List<IcustomerStatus> getCustomerStatus();
        
        bool isCorrectPassword(int id, string password);
        
        bool doAccountExist(int sourceAccount);
        
        bool changePassword(int id, string newPassword);
        
        IEmpLoginData EmpLogin(string userid, string pass, out string except);
        
        List<string> GetEmpNameById(int id, out string except);
        
        DataSet GetStateNames();
        
        bool CheckExistingCustBySsn(int ssn, out string ErrMsg);

        bool CheckExistingCustByCustId(int id, out string ErrMsg);

        int CreateCustomer(ICustomerDetails cust, out string errMsg);

        ICustomerDetails GetCustDetailsById(int id, out string errMsg);

        ICustomerDetails GetCustDetailsBySsn(int ssn, out string errMsg);

        bool updateCustomer(ICustomerDetails cd, out string errMsg);

        string GetStateNameById(int stateId, out string errMsg);

        bool DeleteCustomerById(int id, out string errMsg);

        bool CreateAccount(IAccountDetails ad, out string errMsg);

        List<string> GetExistingAccByCustId(int id, out string errMsg);

        List<IAccountStatus> GetAccountStatus(out string errMsg);

        List<IAccountDeletingDetails> GetDeletingAccDetailsById(int cId, out string errMsg);

        List<IAccountDeletingDetails> GetDeletingAccDetailsBySsn(int ssn, out string errMsg);

        bool DeleteAccount(int aId, out string errMsg);

        ITransfer getAccountData(int v);
        
        bool depositMoney(ITransfer dep);
        
        bool transferBalance(ITransfer dep);
        
        bool withdrawMoney(ITransfer dep);
        
        StringBuilder returnMD5(string s);

        object cashier_trn_statement(Icashier_transactions obj);
    }
}
