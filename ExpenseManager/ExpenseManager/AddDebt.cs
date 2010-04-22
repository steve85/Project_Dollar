using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ExpenseManager
{
    class AddDebt
    {
        private ExpenseManager expenseManager;
        private static string _connectionString = ConfigurationSettings.AppSettings["connectionString"].ToString();
        private static string _getIdentity = "SELECT @@IDENTITY";

        public AddDebt(ExpenseManager inExpenseManager)
        {
            expenseManager = inExpenseManager;
            // Call to load form here
        }

        public void InsertValues(Debt newDebt)
        {
            int intSuccess = 0;
            int intDebtId = 0;
            string qryInsertDebt = @"INSERT INTO Debt ([ExpenseId] ,[PersonOwing] ,[AmountOutstanding] ,[IsPaid] ,[DatePaid]) 
                                    VALUES (@ExpenseId, @PersonOwing, @AmountOutstanding ,@IsPaid ,@DatePaid)";
            using (SqlConnection connInsert = new SqlConnection(_connectionString))
            {
                try
                {
                    connInsert.Open();
                    SqlCommand cmdInsertDebt = new SqlCommand(qryInsertDebt, connInsert);
                    cmdInsertDebt.Parameters.AddWithValue("@ExpenseId", newDebt.ExpenseId);
                    cmdInsertDebt.Parameters.AddWithValue("@PersonOwing", newDebt.PersonOwing);
                    cmdInsertDebt.Parameters.AddWithValue("@AmountOutstanding", newDebt.AmountOutstanding);
                    cmdInsertDebt.Parameters.AddWithValue("@IsPaid", newDebt.IsPaid);
                    cmdInsertDebt.Parameters.AddWithValue("@DatePaid", newDebt.DatePaid);
                    intSuccess = cmdInsertDebt.ExecuteNonQuery();
                    SqlCommand cmdGetDebtId = new SqlCommand(_getIdentity, connInsert);
                    if (intSuccess == 1)
                    {
                        intDebtId = int.Parse(cmdGetDebtId.ExecuteScalar().ToString());
                        // ### better error handling required
                        newDebt.Id = intDebtId;
                        expenseManager.AddToListDebt(newDebt);
                    }
                    else
                    {
                        // ### throw an exception
                    }

                    connInsert.Close();
                }
                catch (Exception e)
                {
                    // ### Exception details find someway to pass this to the form
                    string exceptionMessage = "The following error occured while trying to connect to the database:\n\n";
                    exceptionMessage += "Name: " + e.Message + "\n\n";
                    exceptionMessage += "Details: " + e.StackTrace;

                    // ### Debug
                    Console.WriteLine(exceptionMessage);
                }
            }
        }
    }
}
