using System;

namespace Crownhart_CashFlowManager
{
    internal class Program
    {
        // Sue Crownhart
        // IT112 
        // NOTES: Your example output for salaried employee total gives the math of $1900.00. I'm
        // assuming that was a typo becaues 800.50 + 1110.00 = 1910.50
        // BEHAVIORS NOT IMPLEMENTED AND WHY: I'm honestly not sure if I got the enum thing working probably.
        //never dealt with Enumerations before. The Program does work and I can print out based on which type it is.
        //I just used a menu set up which you can repeatedly add to until you press 0. Also, wasn't sure what to do with part
        //numbers so I just generated those randomly too.

        static void Main(string[] args)
        {


            SalariedEmployee s1 = new SalariedEmployee("John", "Smith", "111-11-111", (decimal)800.50);
            s1.CurrentType(IPayable.LedgerType.Salaried);
            SalariedEmployee s2 = new SalariedEmployee("Susan", "Mathews", "222-22-222", (decimal)1110.00);
            s2.CurrentType(IPayable.LedgerType.Salaried);
            HourlyEmployee h1 = new HourlyEmployee("Karen", "Williams", "444-44-4444", 40, (decimal)16.75);
            h1.CurrentType(IPayable.LedgerType.Hourly);
            HourlyEmployee h2 = new HourlyEmployee("Carol", "Walsh", "333-33-3333", 42, (decimal)19.50);
            h2.CurrentType(IPayable.LedgerType.Hourly);
            Invoice i1 = new Invoice("PartNumber", 3, "FluxCapacitor", (decimal)14.50);
            i1.CurrentType(IPayable.LedgerType.Invoice);
            Invoice i2 = new Invoice("PartNumber", 2, "FluxCapacitor", (decimal)3656.66);
            i2.CurrentType(IPayable.LedgerType.Invoice);






            IPayable[] payable = new IPayable[1000];
            AddToCashPaid(s1, payable);
            AddToCashPaid(s2, payable);
            AddToCashPaid(h1, payable);
            AddToCashPaid(h2, payable);
            AddToCashPaid(i1, payable);
            AddToCashPaid(i2, payable);



            Console.WriteLine("Add some stuff that needs to be paid? y/n");
            string add = Console.ReadLine();

            while (add == "y")
            {
                menuDisplay();
                Console.WriteLine("Please Pick an option");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //add an hourly employee
                        string hfirst = ""; string hlast = ""; string hssn = ""; decimal hPay = 0; int hWorked = 0;
                        Console.WriteLine("What is the first name?");
                        hfirst = Console.ReadLine();
                        Console.WriteLine("What is the last name?");
                        hlast = Console.ReadLine();
                        Console.WriteLine("Enter the SSN ###-##-####");
                        hssn = Console.ReadLine();
                        Console.WriteLine("How Many hours did they work?");
                        hWorked = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("What is their hourly pay?");
                        hPay = Convert.ToDecimal(Console.ReadLine());

                        HourlyEmployee hourly = new HourlyEmployee(hfirst, hlast, hssn, hWorked, hPay);
                        AddToCashPaid(hourly, payable);
                        hourly.CurrentType(IPayable.LedgerType.Hourly);

                        break;

                    case "2":
                        //add a salaried Employee
                        string sfirst = ""; string slast = ""; string sssn = ""; decimal sPay = 0;
                        Console.WriteLine("What is the first name?");
                        sfirst = Console.ReadLine();
                        Console.WriteLine("What is the last name?");
                        slast = Console.ReadLine();
                        Console.WriteLine("Enter the SSN ###-##-####");
                        sssn = Console.ReadLine();
                        Console.WriteLine("What is their salary for the week?");
                        sPay = Convert.ToDecimal(Console.ReadLine());

                        SalariedEmployee salary = new SalariedEmployee(sfirst, slast, sssn, sPay);
                        AddToCashPaid(salary, payable);
                        salary.CurrentType(IPayable.LedgerType.Salaried);

                        break;
                    case "3":
                        //3.Add an Invoice Item

                        string pNumber = ""; int iQuantity = 0; string iName = ""; decimal iPrice = 0;

                        pNumber = "PartNumber";
                        Console.WriteLine("What is the part description?");
                        iName = Console.ReadLine();
                        Console.WriteLine("How many parts?");
                        iQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("How much does each one cost?");
                        iPrice = Convert.ToDecimal(Console.ReadLine());

                        Invoice invoice = new Invoice(pNumber, iQuantity, iName, iPrice);
                        AddToCashPaid(invoice, payable);
                        invoice.CurrentType(IPayable.LedgerType.Invoice);

                        break;
                    case "4":
                        decimal iPayout = 0; decimal sPayout = 0; decimal hPayout = 0; decimal twPayout = 0;
                        for (int i = 0; i < payable.Length; i++)
                        {
                            if (payable[i] != null)
                            {
                                if (payable[i] is HourlyEmployee)
                                {


                                    Console.WriteLine("Hourly Employee: " + payable[i].GetPayableName());
                                    Console.WriteLine("SSN: " + payable[i].GetSSN());
                                    Console.WriteLine("Hourly wage Salary: " + payable[i].GetHourlyWage().ToString("$0.00"));
                                    Console.WriteLine("Hours Worked: " + payable[i].GetHoursWorked());
                                    Console.WriteLine("Earned: " + payable[i].GetPayableAmount().ToString("$00.00") + "\n");
                                    hPayout += payable[i].GetPayableAmount();
                                }

                                if (payable[i] is SalariedEmployee)

                                {

                                    Console.WriteLine("Salaried Employee: " + payable[i].GetPayableName());
                                    Console.WriteLine("SSN: " + payable[i].GetSSN());
                                    Console.WriteLine("Weekly Salary: " + payable[i].GetPayableAmount().ToString("$00.00"));
                                    Console.WriteLine("Earned: " + payable[i].GetPayableAmount().ToString("$00.00") + "\n");
                                    sPayout += payable[i].GetPayableAmount();

                                }

                                if (payable[i] is Invoice)
                                {
                                    Console.WriteLine("Invoice");
                                    Console.WriteLine(payable[i].GetInvoiceNumber() + "_" + payable[i].GetPartNumber());
                                    Console.WriteLine("Quantity: " + payable[i].GetQuantity());
                                    Console.WriteLine("Part Description: " + payable[i].GetPayableName());
                                    Console.WriteLine("Unit Price: " + payable[i].GetUnitPrice().ToString("$00.00"));
                                    Console.WriteLine("Extened Price: " + payable[i].GetPayableAmount().ToString("$00.00") + "\n");
                                    iPayout += payable[i].GetPayableAmount();
                                }


                            }

                        }
                        twPayout = iPayout + sPayout + hPayout;

                        Console.WriteLine("Total Weekly Payout: " + twPayout.ToString("$0.00") + "\n");

                        Console.WriteLine("Category BreakDown");
                        Console.WriteLine("Invoices: " + iPayout.ToString("$0.00"));
                        Console.WriteLine("Salaried Payroll: " + sPayout.ToString("$0.00"));
                        Console.WriteLine("Hourly Payroll: " + hPayout.ToString("$0.00") + "\n");


                        break;

                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Sorry... you're not understood");
                        break;

                }

            }
        }

        public static bool AddToCashPaid(IPayable stuff, IPayable[] list)
        {
            for (int i = 0; i < 10; i++)
            {
                if (list[i] == null)
                {
                    list[i] = stuff;
                    return true;
                }

            }
            return false;
        }

        public static void menuDisplay()
        {
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("|                  Main Menu                     |");
            Console.WriteLine("|1. Add an Hourly Employee                       |");
            Console.WriteLine("|2. Add a Salaried Employee                      |");
            Console.WriteLine("|3. Add an Invoice Item                          |");
            Console.WriteLine("|4. Display Cash Flow                            |");
            Console.WriteLine("|0. Exit                                         |");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||");
        }
    }
}
