using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crownhart_CashFlowManager
{
    internal class SalariedEmployee : Employee
    {

        public SalariedEmployee(string firstName, string lastName, string ssn, decimal weeklySalary) : base(firstName, lastName, ssn)
        {
            _amount = weeklySalary;
        }

        public override decimal GetPayableAmount()
        {
            return _amount;
        }

        public new void CurrentType(ILedger.LedgerType currentType)
        {
            currentType = ILedger.LedgerType.Salaried;
        }


    }
}
