using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TYPES;

namespace BO
{
    public class Transfer
    {
        string sourceCustomerID;
        string sourceAccountID;
        string sourceAccountType;
        double sourceAvailableBalance;
        double transactionAmount;
        string targetAccountID;
        string targetCustomerID;
        string targetAccountType;
        double targetAvailableBalance;

        int transactionId;
        string errorMsg;

        public string SourceCustomerID
        {
            get
            {
                return sourceCustomerID;
            }

            set
            {
                sourceCustomerID = value;
            }
        }

        public string SourceAccountID
        {
            get
            {
                return sourceAccountID;
            }

            set
            {
                sourceAccountID = value;
            }
        }

        public string SourceAccountType
        {
            get
            {
                return sourceAccountType;
            }

            set
            {
                sourceAccountType = value;
            }
        }

        public double SourceAvailableBalance
        {
            get
            {
                return sourceAvailableBalance;
            }

            set
            {
                sourceAvailableBalance = value;
            }
        }

        public double TransactionAmount
        {
            get
            {
                return transactionAmount;
            }

            set
            {
                transactionAmount = value;
            }
        }

        public string TargetAccountID
        {
            get
            {
                return targetAccountID;
            }

            set
            {
                targetAccountID = value;
            }
        }

        public string TargetCustomerID
        {
            get
            {
                return targetCustomerID;
            }

            set
            {
                targetCustomerID = value;
            }
        }

        public double TargetAccountBalance
        {
            get
            {
                return targetAvailableBalance;
            }

            set
            {
                targetAvailableBalance = value;
            }
        }

        public int TransactionId
        {
            get
            {
                return transactionId;
            }

            set
            {
                transactionId = value;
            }
        }

        public string ErrorMsg
        {
            get
            {
                return errorMsg;
            }

            set
            {
                errorMsg = value;
            }
        }

        public string TargetAccountType
        {
            get
            {
                return targetAccountType;
            }

            set
            {
                targetAccountType = value;
            }
        }

        public Transfer(string sourceCustomerID, string sourceAccountID, string sourceAccountType, double sourceAvailableBalance, double transactionAmount, string targetAccountID, string targetCustomerID, string targetAccountType, double targetAvailableBalance, int transactionId, string errorMsg)
        {
            this.sourceCustomerID = sourceCustomerID;
            this.sourceAccountID = sourceAccountID;
            this.sourceAccountType = sourceAccountType;
            this.sourceAvailableBalance = sourceAvailableBalance;
            this.transactionAmount = transactionAmount;
            this.targetAccountID = targetAccountID;
            this.targetCustomerID = targetCustomerID;
            this.targetAccountType = targetAccountType;
            this.targetAvailableBalance = targetAvailableBalance;
            this.transactionId = transactionId;
            this.errorMsg = errorMsg;
        }

        public Transfer()
        {
        }
    }
}
