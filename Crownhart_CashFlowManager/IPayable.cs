using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crownhart_CashFlowManager
{
    internal interface IPayable : ILedger
    {
        decimal GetPayableAmount();

        decimal GetUnitPrice();

        string GetPayableName();

        string GetSSN();

        string GetPartNumber();

        string GetInvoiceNumber();

        int GetQuantity();

        decimal GetHourlyWage();

        int GetHoursWorked();

        public void CurrentType(LedgerType type);

    }
}
