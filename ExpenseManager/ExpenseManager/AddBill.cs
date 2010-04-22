using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ExpenseManager
{
    class AddBill
    {
        private ExpenseManager expenseManager;
        private static string _connectionString = ConfigurationSettings.AppSettings["connectionString"].ToString();

        public AddBill(ExpenseManager inExpenseManager)
        {
            expenseManager = inExpenseManager;
            // Call to load form here
        }

        public void InsertValues()
        {

        }
    }
}
