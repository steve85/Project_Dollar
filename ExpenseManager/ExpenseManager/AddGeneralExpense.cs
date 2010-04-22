using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ExpenseManager
{
    class AddGeneralExpense
    {
        private ExpenseManager expenseManager;
        private static string _connectionString = ConfigurationSettings.AppSettings["connectionString"].ToString();

        public AddGeneralExpense(ExpenseManager inExpenseManager)
        {
            expenseManager = inExpenseManager;
            // Call to display form will need to go here
        }

        public void InsertValues(GeneralExpense newGeneralExpense)
        {
            int intSuccess = 0;
            int intExpenseId = 0;
            string qryInsertExpense = @"INSERT INTO GeneralExpense ([Name] ,[Description] ,[Value] ,[DateReceived] ,[IsPaid] ,[DatePaid] ,[IsOutstanding]) 
                                    VALUES (@Name, @Description, @Value, @DateReceived, @IsPaid, @DatePaid, @IsOutstanding)";
            string qryGetExpenseId = "SELECT MAX(Id) FROM GeneralExpense";
            using (SqlConnection connInsert = new SqlConnection(_connectionString))
            {
                try
                {
                    connInsert.Open();
                    SqlCommand cmdInsertExpense = new SqlCommand(qryInsertExpense, connInsert);
                    cmdInsertExpense.Parameters.AddWithValue("@Name", newGeneralExpense.Name);
                    cmdInsertExpense.Parameters.AddWithValue("@Description", newGeneralExpense.Description);
                    cmdInsertExpense.Parameters.AddWithValue("@Value", newGeneralExpense.Value);
                    cmdInsertExpense.Parameters.AddWithValue("@DateReceived", newGeneralExpense.DateReceived);
                    cmdInsertExpense.Parameters.AddWithValue("@IsPaid", newGeneralExpense.IsPaid);
                    cmdInsertExpense.Parameters.AddWithValue("@DatePaid", newGeneralExpense.DatePaid);
                    cmdInsertExpense.Parameters.AddWithValue("@IsOutstanding", newGeneralExpense.IsOutstanding);
                    intSuccess = cmdInsertExpense.ExecuteNonQuery();
                    SqlCommand cmdGetExpenseId = new SqlCommand(qryGetExpenseId, connInsert);
                    if (intSuccess == 1)
                    {
                        intExpenseId = (int)cmdGetExpenseId.ExecuteScalar();
                        // ### better error handling required
                        newGeneralExpense.Id = intExpenseId;
                        expenseManager.AddToListGeneralExpense(newGeneralExpense);
                    }
                    else
                    {
                        // ### throw and exception
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
