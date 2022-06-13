using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crownhart_CashFlowManager
{
    internal class HourlyEmployee : Employee
    {
        private int _hoursWorked;
        private decimal _hourlyWage;

        public HourlyEmployee(string firstName, string lastName, string ssn, int hoursWorked, decimal hourlyWage) : base(firstName, lastName, ssn)
        {
            _hoursWorked = hoursWorked;
            _hourlyWage = hourlyWage;
        }
        public override decimal GetPayableAmount()
        {
            if (_hoursWorked > 40)
            {
                int otHours = _hoursWorked - 40;
                decimal otHourly = (_hourlyWage / 2) + _hourlyWage;
                decimal otPay = otHours * otHourly;
                _amount = otPay + (40 * _hourlyWage);
                return _amount;
            }
            else
            {
                _amount = _hoursWorked * _hourlyWage;
                return _amount;
            }

        }

        public override int GetHoursWorked()
        {
            return _hoursWorked;
        }

        public override decimal GetHourlyWage()
        {
            return _hourlyWage;
        }

        public new void CurrentType(ILedger.LedgerType currentType)
        {
            currentType = ILedger.LedgerType.Hourly;
        }


    }
}
