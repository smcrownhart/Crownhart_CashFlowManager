using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crownhart_CashFlowManager
{
    internal class Invoice : IPayable
    {
        private string _partNumber;
        private int _quantity;
        private string _partDescription;
        private decimal _price;

        public Invoice(string PartNumber, int Quantity, string PartDescription, decimal Price)
        {
            GetPartNumber();
            _partNumber = PartNumber;
            _quantity = Quantity;
            _partDescription = PartDescription;
            _price = Price;
        }

        public string GetPartNumber()
        {
            //https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp
            Random random = new Random();
            for (int x = 0; x < 9999; x++)
            {
                _partNumber = random.Next(9999).ToString();
            }
            return _partNumber;
        }

        public string GetInvoiceNumber()
        {
            string invoiceNumber = "";
            Random random = new Random();
            for (int x = 0; x < 999999; x++)
            {
                invoiceNumber = random.Next(999999).ToString();
            }

            return invoiceNumber;
        }


        public decimal GetPayableAmount()
        {
            return _price * _quantity;
        }

        public string GetPayableName()
        {
            return _partDescription;
        }

        public decimal GetUnitPrice()
        {
            return _price;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public void CurrentType(ILedger.LedgerType currentType)
        {
            currentType = ILedger.LedgerType.Invoice;
        }


        public string GetSSN()
        {
            return "";
        }

        public decimal GetHourlyWage()
        {
            return 0;
        }

        public int GetHoursWorked()
        {
            return 0;
        }
    }
}
