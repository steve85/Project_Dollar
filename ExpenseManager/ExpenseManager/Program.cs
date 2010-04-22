using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private static void Menu()
        {
            ExpenseManager em = new ExpenseManager();
            string menuOption;
            while (true)
            {
                menuOption = string.Empty;
                Console.WriteLine("+++++ Expense Manager +++++");
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. List Expenses");
                Console.WriteLine("2. List Bills");
                Console.WriteLine("3. List Debts");
                Console.WriteLine("4. Add Expense");
                Console.WriteLine("5. Add Bill");
                Console.WriteLine("6. Add Debt");
                Console.WriteLine("7. Exit");
                Console.WriteLine();
                Console.WriteLine("Please select an option");
                menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Expenses:\n");
                        List<GeneralExpense> geList = em.GetListGeneralExpense();
                        foreach (GeneralExpense ge in geList)
                        {
                            Console.WriteLine(ge.GetExpenseDetails());
                        }                      
                        Console.WriteLine("\n\tPress any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Bills:\n");
                        List<Bill> billList = em.GetListBill();
                        foreach (Bill bill in billList)
                        {
                            Console.WriteLine(bill.GetBillDetails());
                        }
                        Console.WriteLine("\n\tPress any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Debts:\n");
                        List<Debt> debtList = em.GetListDebt();
                        foreach (Debt debt in debtList)
                        {
                            Console.WriteLine(debt.GetDebtDetails());
                        }
                        Console.WriteLine("\n\tPress any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Add New Expense:\n");
                        AddNewExpense(em, false);
                        Console.WriteLine("\n\tPress any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Add New Bill:\n");
                        AddNewExpense(em, true);
                        Console.WriteLine("\n\tPress any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Add New Debt:\n");
                        AddNewDebt(em);
                        Console.WriteLine("\n\tPress any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    case "7":
                        string exitVal = string.Empty;
                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.WriteLine("Are you sure you want exit (Y/N)?");
                            exitVal = Console.ReadLine();
                            switch (exitVal.ToUpper())
                            {
                                case "Y":
                                    System.Environment.Exit(0);
                                    break;
                                case "N":
                                    isValid = true;
                                    break;
                                default:
                                    Console.WriteLine("\tInvalid Option");
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("\tInvalid Menu option");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
        }

        private static void AddNewExpense(ExpenseManager inEM, bool isBill)
        {
            ExpenseManager em = inEM;
            GeneralExpense ge = new GeneralExpense();
            string eName = string.Empty;
            string eDesc = string.Empty;
            double eValue = 0;
            DateTime eDateRec = new DateTime(9999, 01, 01);
            bool eIsPaid = false;
            DateTime eDatePaid = new DateTime(9999, 01, 01);
            bool eIsOutstanding = false;
            string input = string.Empty;
            bool isValid = false;
            string invalid = "\t\tInvalid Value.";

            // Get Name
            while (!isValid)
            {
                Console.Write("Name: ");
                eName = Console.ReadLine();
                if (string.IsNullOrEmpty(eName))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    isValid = true;
                }
            }

            isValid = false;

            // Get Desc
            while (!isValid)
            {
                Console.Write("Description: ");
                eDesc = Console.ReadLine();
                if (string.IsNullOrEmpty(eDesc))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    isValid = true;
                }
            }

            isValid = false;

            // Get value
            while (!isValid)
            {          
                Console.Write("Value: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    if (double.TryParse(input, out eValue))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine(invalid);
                        Console.ReadLine();
                    }
                }
            }

            isValid = false;
            input = string.Empty;

            // Date recieved
            while (!isValid)
            {
                Console.Write("Date Received: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    if (DateTime.TryParse(input, out eDateRec))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine(invalid);
                        Console.ReadLine();
                    }
                }
            }

            isValid = false;
            input = string.Empty;

            // Get isPaid
            while (!isValid)
            {
                Console.Write("Has this expense been paid (Y/N): ");
                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "Y":
                        eIsPaid = true;
                        isValid = true;
                        break;
                    case "N":
                        eIsPaid = false;
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine(invalid);
                        Console.ReadLine();
                        break;
                }
            }

            isValid = false;
            input = string.Empty;

            if (eIsPaid)
            {
                // Date paid
                while (!isValid)
                {
                    Console.Write("Date Paid: ");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine(invalid);
                        Console.ReadLine();
                    }
                    else
                    {
                        if (DateTime.TryParse(input, out eDatePaid))
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine(invalid);
                            Console.ReadLine();
                        }
                    }
                }
            }
            else
            {
                eDatePaid = new DateTime(9999, 01, 01);
            }

            isValid = false;
            input = string.Empty;

            // Get isOutstanding
            while (!isValid)
            {
                Console.Write("Is this expense outstanding (Y/N): ");
                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "Y":
                        eIsOutstanding = true;
                        isValid = true;
                        break;
                    case "N":
                        eIsOutstanding = false;
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine(invalid);
                        Console.ReadLine();
                        break;
                }
            }

            ge.Name = eName;
            ge.Description = eDesc;
            ge.Value = eValue;
            ge.DateReceived = eDateRec;
            ge.IsPaid = eIsPaid;
            ge.DatePaid = eDatePaid;
            ge.IsOutstanding = eIsOutstanding;

            if (isBill)
            {
                AddNewBill(em, ge);
            }
            else
            {
                AddGeneralExpense addExpense = new AddGeneralExpense(em);
                addExpense.InsertValues(ge);
            }
        }

        private static void AddNewBill(ExpenseManager inEM, GeneralExpense ge)
        {
            ExpenseManager em = inEM;
            Bill bill = new Bill();
            string bIssuer = string.Empty;
            string bRefNo = string.Empty;
            string invalid = "\t\tInvalid Value.";
            bool isValid = false;

            // Get Issuer
            while (!isValid)
            {
                Console.Write("Bill Isssuer: ");
                bIssuer = Console.ReadLine();
                if (string.IsNullOrEmpty(bIssuer))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    isValid = true;
                }
            }

            isValid = false;

            // Get bill reference number
            while (!isValid)
            {
                Console.Write("Bill Reference No: ");
                bRefNo = Console.ReadLine();
                if (string.IsNullOrEmpty(bRefNo))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    isValid = true;
                }
            }

            bill.Name = ge.Name;
            bill.Description = ge.Description;
            bill.Value = ge.Value;
            bill.DateReceived = ge.DateReceived;
            bill.IsPaid = ge.IsPaid;
            bill.DatePaid = ge.DatePaid;
            bill.IsOutstanding = ge.IsOutstanding;
            bill.Issuer = bIssuer;
            bill.ReferenceNo = bRefNo;

            AddBill addBill = new AddBill(em);
            addBill.InsertValues(bill);

        }

        private static void AddNewDebt(ExpenseManager inEM)
        {
            ExpenseManager em = inEM;
            Debt debt = new Debt();
            int dExpenseId = 0;
            string dPersonOwing = string.Empty;
            double dAmountOutstanding = 0;
            bool dIsPaid = false;
            DateTime dDatePaid = new DateTime(9999, 01, 01);
            bool isValid = false;
            string input = string.Empty;
            string invalid = "\t\tInvalid Value.";

            List<int> expenseIdList = new List<int>();
            List<GeneralExpense> expenseList = em.GetListGeneralExpense();
            List<Bill> billList = em.GetListBill();

            // Get Expenses
            Console.WriteLine("Expenses:");
            foreach (GeneralExpense expense in expenseList)
            {
                Console.WriteLine(expense.GetShortDetails());
                expenseIdList.Add(expense.Id);
            }

            // Get Bills
            Console.WriteLine();
            Console.WriteLine("Bills:");
            foreach (Bill bill in billList)
            {
                Console.WriteLine(bill.GetShortDetails());
                expenseIdList.Add(bill.Id);
            }
            Console.WriteLine();       

            // Get Expense Id
            while (!isValid)
            {
                Console.Write("Expense Id: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    if (int.TryParse(input, out dExpenseId))
                    {
                        if (expenseIdList.Contains(dExpenseId))
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("\t\tNot a valid expense id.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine(invalid);
                        Console.ReadLine();
                    }
                }
            }

            isValid = false;

            // Get Person Owing
            while (!isValid)
            {
                Console.Write("Person Owing: ");
                dPersonOwing = Console.ReadLine();
                if (string.IsNullOrEmpty(dPersonOwing))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    isValid = true;
                }
            }

            isValid = false;
            input = string.Empty;

            // Get Amount
            while (!isValid)
            {
                Console.Write("Amount: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    if (double.TryParse(input, out dAmountOutstanding))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine(invalid);
                        Console.ReadLine();
                    }
                }
            }

            isValid = false;
            input = string.Empty;

            // Is Paid
            while (!isValid)
            {
                Console.Write("Is Debt Paid (Y/N): ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(invalid);
                    Console.ReadLine();
                }
                else
                {
                    switch (input.ToUpper())
                    {
                        case "Y":
                            isValid = true;
                            dIsPaid = true;
                            break;
                        case "N":
                            isValid = true;
                            dIsPaid = false;
                            break;
                        default:
                            Console.WriteLine(invalid);
                            Console.ReadLine();
                            break;
                    }
                }
            }

            isValid = false;
            input = string.Empty;

            if (dIsPaid)
            {
                // Date paid
                while (!isValid)
                {
                    Console.Write("Date Paid: ");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine(invalid);
                        Console.ReadLine();
                    }
                    else
                    {
                        if (DateTime.TryParse(input, out dDatePaid))
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine(invalid);
                            Console.ReadLine();
                        }
                    }
                }
            }
            else
            {
                dDatePaid = new DateTime(9999, 01, 01);
            }

            debt.ExpenseId = dExpenseId;
            debt.PersonOwing = dPersonOwing;
            debt.AmountOutstanding = dAmountOutstanding;
            debt.IsPaid = dIsPaid;
            debt.DatePaid = dDatePaid;

            AddDebt addDebt = new AddDebt(em);
            addDebt.InsertValues(debt);
        }

        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
             */
 
            /*
             *  Changed ouput to Console Application (via Project Properties 
             *  while I build the application framework
             */
            Menu();
        }
    }
}
