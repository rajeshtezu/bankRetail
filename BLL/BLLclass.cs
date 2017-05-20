using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using TYPES;
using BO;


namespace BLL
{
    public class Business
    {
        Operation op = new Operation();

        protected string ProperName(string literal)
        {
            return op.camelCase(literal); 
        }

        public IEmpDetails getEmpDetails(int id)
        {
            return op.getEmpDetails(id);
        }

        public List<customerStatus> getCustomerStatus()
        {
            return op.getCustomerStatus();
        }

        public bool isCorrectPassword(int id, string password)
        {
            return op.isCorrectPassword(id, password);
        }

        public bool doAccountExist(int sourceAccount)
        {
            return op.doAccountExist(sourceAccount);
        }

        public bool changePassword(int id, string newPassword)
        {
            return op.changePassword(id,newPassword);
        }
    }
}
