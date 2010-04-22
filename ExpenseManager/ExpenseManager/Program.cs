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
                        AddNewExpense(em);
                        Console.WriteLine("\n\tPress any key to return to the menu.");
                        Console.ReadLine();
                        break;
                    case "5":
                        break;
                    case "6":
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

        private static void AddNewExpense(ExpenseManager inEM)
        {
            ExpenseManager em = inEM;
            string eName = string.Empty;
            string eDesc = string.Empty;
            double eValue = 0;
            string eDateRec = string.Empty;
            string eIsPaid = string.Empty;
            string eDatePaid = string.Empty;
            string eIsOutstanding = string.Empty;

            Console.Write("Name: ");
            eName = Console.ReadLine();
            Console.Write("Description: ");
            eDesc = Console.ReadLine();
            Console.Write("Value: ");
            // eValue

        }

        private static void AddNewBill(ExpenseManager inEM)
        {
            ExpenseManager em = inEM;
        }

        private static void AddNewDebt(ExpenseManager inEM)
        {
            ExpenseManager em = inEM;
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
            // Testing adding of new item
            /*
            Console.WriteLine("Adding new Item...");
            AddGeneralExpense age = new AddGeneralExpense(em);
            GeneralExpense ge = new GeneralExpense();
            ge.Name = "Storage";
            ge.Description = "Storage fee for Petterd";
            ge.Value = 125.50;
            ge.DateReceived = new DateTime(2009, 06, 01);
            ge.IsPaid = true;
            ge.DatePaid = new DateTime(2009, 06, 15);
            ge.IsOutstanding = true;
            age.InsertValues(ge);
            */
        }
    }
}
