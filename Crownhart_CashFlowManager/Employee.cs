using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crownhart_CashFlowManager
{
    internal abstract class Employee : IPayable
    {
        protected decimal _amount;
        private string _firstName;
        private string _lastName;
        private string _ssn;

        public Employee(string firstName, string lastName, string ssn)
        {
            _firstName = firstName;
            _lastName = lastName;
            _ssn = ssn;

        }
        public virtual decimal GetPayableAmount()
        {
            return _amount;
        }

        public string GetSSN()
        {
            return _ssn;
        }

        public string GetPayableName()
        {
            return _firstName + " " + _lastName;
        }

        public void CurrentType(ILedger.LedgerType type)
        {

        }

        public string GetPartNumber()
        {
            return "";
        }

        public string GetInvoiceNumber()
        {
            return "";
        }

        public int GetQuantity()
        {
            return 0;
        }

        public decimal GetUnitPrice()
        {
            return 0;
        }

        public virtual decimal GetHourlyWage()
        {
            return 1;
        }

        public virtual int GetHoursWorked()
        {
            return 1;
        }
    }

}
