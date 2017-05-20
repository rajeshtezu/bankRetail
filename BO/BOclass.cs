using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TYPES;

namespace BO
{
    public class EmpLoginData : IEmpLoginData
    {
        int eid;
        string etype;
        int valid;

        public EmpLoginData(int eid, string etype, int valid)
        {
            this.eid = eid;
            this.etype = etype;
            this.valid = valid;
        }

        public int Eid
        {
            get
            {
                return eid;
            }

            set
            {
                eid = value;
            }
        }

        public string Etype
        {
            get
            {
                return etype;
            }

            set
            {
                etype = value;
            }
        }

        public int Valid
        {
            get
            {
                return valid;
            }

            set
            {
                valid = value;
            }
        }
    }

    public class CustomerDetails : ICustomerDetails
    {
        int custId = 0;
        int ssn;
        string name;
        int age;
        string addr1;
        string addr2;
        string city;
        int stateId;
        int pin;

        public CustomerDetails(int custId, int ssn, string name, int age, string addr1, string addr2, string city, int stateId, int pin)
        {
            this.custId = custId;
            this.ssn = ssn;
            this.name = name;
            this.age = age;
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.city = city;
            this.stateId = stateId;
            this.pin = pin;
        }

        public int Ssn
        {
            get
            {
                return ssn;
            }

            set
            {
                ssn = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Addr1
        {
            get
            {
                return addr1;
            }

            set
            {
                addr1 = value;
            }
        }

        public string Addr2
        {
            get
            {
                return addr2;
            }

            set
            {
                addr2 = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public int StateId
        {
            get
            {
                return stateId;
            }

            set
            {
                stateId = value;
            }
        }

        public int Pin
        {
            get
            {
                return pin;
            }

            set
            {
                pin = value;
            }
        }

        public int CustId
        {
            get
            {
                return custId;
            }

            set
            {
                custId = value;
            }
        }
    }

    public class EmpDetails : IEmpDetails
    {
        int id;
        string name;
        string gender;
        string type;
        string errMsg;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string ErrMsg
        {
            get
            {
                return errMsg;
            }

            set
            {
                errMsg = value;
            }
        }
        
        public EmpDetails(int id, string name, string gender, string type, string errMsg)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.type = type;
            this.errMsg = errMsg;
        }
    }

    public class AccountDetails : IAccountDetails
    {
        int custId;
        int accId;
        string accType;
        double balance;
        string crDate;
        string crLastDate;
        int duration;

        public AccountDetails(int custId, int accId, string accType, double balance, string crDate, string crLastDate, int duration)
        {
            this.custId = custId;
            this.accId = accId;
            this.accType = accType;
            this.balance = balance;
            this.crDate = crDate;
            this.crLastDate = crLastDate;
            this.duration = duration;
        }

        public int CustId
        {
            get
            {
                return custId;
            }

            set
            {
                custId = value;
            }
        }

        public int AccId
        {
            get
            {
                return accId;
            }

            set
            {
                accId = value;
            }
        }

        public string AccType
        {
            get
            {
                return accType;
            }

            set
            {
                accType = value;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public string CrDate
        {
            get
            {
                return crDate;
            }

            set
            {
                crDate = value;
            }
        }

        public string CrLastDate
        {
            get
            {
                return crLastDate;
            }

            set
            {
                crLastDate = value;
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
            }
        }
    }

    public class AccountStatus : IAccountStatus
    {
        int custId;
        int accId;
        string accType;
        string status;
        string msg;
        string lastUpdated;

        public int CustId
        {
            get
            {
                return custId;
            }

            set
            {
                custId = value;
            }
        }

        public int AccId
        {
            get
            {
                return accId;
            }

            set
            {
                accId = value;
            }
        }

        public string AccType
        {
            get
            {
                return accType;
            }

            set
            {
                accType = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Msg
        {
            get
            {
                return msg;
            }

            set
            {
                msg = value;
            }
        }

        public string LastUpdated
        {
            get
            {
                return lastUpdated;
            }

            set
            {
                lastUpdated = value;
            }
        }

        public AccountStatus(int custId, int accId, string accType, string status, string msg, string lastUpdated)
        {
            this.custId = custId;
            this.accId = accId;
            this.accType = accType;
            this.status = status;
            this.msg = msg;
            this.lastUpdated = lastUpdated;
        }
    }

    //customer status
    public class customerStatus : IcustomerStatus
    {
        int customerID;
        int customerSSN;
        string customerStatusValue;
        string customerMessage;
        string lastUpdated;

        public int CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public int CustomerSSN
        {
            get
            {
                return customerSSN;
            }

            set
            {
                customerSSN = value;
            }
        }

        public string CustomerStatusValue
        {
            get
            {
                return customerStatusValue;
            }

            set
            {
                customerStatusValue = value;
            }
        }

        public string CustomerMessage
        {
            get
            {
                return customerMessage;
            }

            set
            {
                customerMessage = value;
            }
        }

        public string LastUpdated
        {
            get
            {
                return lastUpdated;
            }

            set
            {
                lastUpdated = value;
            }
        }

        public customerStatus(int customerID, int customerSSN, string customerStatusValue, string customerMessage, string lastUpdated)
        {
            this.CustomerID = customerID;
            this.CustomerSSN = customerSSN;
            this.CustomerStatusValue = customerStatusValue;
            this.CustomerMessage = customerMessage;
            this.LastUpdated = lastUpdated;
        }
    }

    public class cashier_transactions : Icashier_transactions
    {
        int account_id;
        int n_trn;
        // output parameters
        DateTime date;
        string trn_description;
        string trn_type;
        int balance;

        public int Account_id
        {
            get
            {
                return account_id;
            }

            set
            {
                account_id = value;
            }
        }

        public int N_trn
        {
            get
            {
                return n_trn;
            }

            set
            {
                n_trn = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Trn_description
        {
            get
            {
                return trn_description;
            }

            set
            {
                trn_description = value;
            }
        }

        public string Trn_type
        {
            get
            {
                return trn_type;
            }

            set
            {
                trn_type = value;
            }
        }

        public int Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public cashier_transactions(int account_id, int n_trn)
        {
            this.account_id = account_id;
            this.n_trn = n_trn;
        }

        public cashier_transactions(DateTime date, string trn_description, string trn_type, int balance)
        {
            this.date = date;
            this.trn_description = trn_description;
            this.trn_type = trn_type;
            this.balance = balance;
        }
    }

    public class AccountDeletingDetails : IAccountDeletingDetails
    {
        int accNo;
        int custId;
        string custName;
        string accType;
        double balance;

        public int AccNo
        {
            get
            {
                return accNo;
            }

            set
            {
                accNo = value;
            }
        }

        public int CustId
        {
            get
            {
                return custId;
            }

            set
            {
                custId = value;
            }
        }

        public string CustName
        {
            get
            {
                return custName;
            }

            set
            {
                custName = value;
            }
        }

        public string AccType
        {
            get
            {
                return accType;
            }

            set
            {
                accType = value;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public AccountDeletingDetails(int accNo, int custId, string custName, string accType, double balance)
        {
            this.accNo = accNo;
            this.custId = custId;
            this.custName = custName;
            this.accType = accType;
            this.balance = balance;
        }
    }
}
