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
        private static string _getIdentity = "SELECT @@IDENTITY";

        public AddBill(ExpenseManager inExpenseManager)
        {
            expenseManager = inExpenseManager;
            // Call to load form here
        }

        public void InsertValues(Bill newBill)
        {
            int intSuccessExpense = 0;
            int intSuccessBill = 0;
            int intExpenseId = 0;
            int intBillId = 0;
            string qryInsertExpense = @"INSERT INTO GeneralExpense ([Name] ,[Description] ,[Value] ,[DateReceived] ,[IsPaid] ,[DatePaid] ,[IsOutstanding]) 
                                    VALUES (@Name, @Description, @Value, @DateReceived, @IsPaid, @DatePaid, @IsOutstanding)";
            string qryInsertBill = @"INSERT INTO Bill([ExpenseId],[Issuer],[ReferenceNo]) VALUES(@ExpenseId, @Issuer, @ReferenceNo)";

            // Inserts into two tables so I use a transaction to ensure integrity
            using (SqlConnection insertConn = new SqlConnection(_connectionString))
            {
                SqlTransaction sqlTransaction = null;
                try
                {
                    insertConn.Open();
                    sqlTransaction = insertConn.BeginTransaction();
                    SqlCommand cmdInsertExpense = new SqlCommand(qryInsertExpense, insertConn);
                    cmdInsertExpense.Parameters.AddWithValue("@Name", newBill.Name);
                    cmdInsertExpense.Parameters.AddWithValue("@Description", newBill.Description);
                    cmdInsertExpense.Parameters.AddWithValue("@Value", newBill.Value);
                    cmdInsertExpense.Parameters.AddWithValue("@DateReceived", newBill.DateReceived);
                    cmdInsertExpense.Parameters.AddWithValue("@IsPaid", newBill.IsPaid);
                    cmdInsertExpense.Parameters.AddWithValue("@DatePaid", newBill.DatePaid);
                    cmdInsertExpense.Parameters.AddWithValue("@IsOutstanding", newBill.IsOutstanding);
                    cmdInsertExpense.Transaction = sqlTransaction;
                    intSuccessExpense = cmdInsertExpense.ExecuteNonQuery();

                    SqlCommand cmdGetExpenseId = new SqlCommand(_getIdentity, insertConn);
                    cmdGetExpenseId.Transaction = sqlTransaction;

                    if (intSuccessExpense == 1)
                    {
                        intExpenseId = int.Parse(cmdGetExpenseId.ExecuteScalar().ToString());
                        newBill.Id = intExpenseId;
                    }

                    SqlCommand cmdInsertBill = new SqlCommand(qryInsertBill, insertConn);
                    // Add paramaters
                    cmdInsertBill.Parameters.AddWithValue("@ExpenseId", newBill.Id);
                    cmdInsertBill.Parameters.AddWithValue("@Issuer", newBill.Issuer);
                    cmdInsertBill.Parameters.AddWithValue("@ReferenceNo", newBill.ReferenceNo);
                    cmdInsertBill.Transaction = sqlTransaction;
                    intSuccessBill = cmdInsertBill.ExecuteNonQuery();

                    SqlCommand cmdGetBillId = new SqlCommand(_getIdentity, insertConn);
                    cmdGetBillId.Transaction = sqlTransaction;

                    if (intSuccessBill == 1)
                    {                        
                        intBillId = int.Parse(cmdGetBillId.ExecuteScalar().ToString());                        
                        newBill.BillId = intBillId;
                    }
                    sqlTransaction.Commit();
                    expenseManager.AddToListBill(newBill);
                    insertConn.Close();
                }
                catch (Exception e)
                {
                    // ### Exception details find someway to pass this to the form
                    string exceptionMessage = "The following error occured while trying to connect to the database:\n\n";
                    exceptionMessage += "Name: " + e.Message + "\n\n";
                    exceptionMessage += "Details: " + e.StackTrace;

                    // ### Debug
                    Console.WriteLine(exceptionMessage);

                    // Rollback SQL transaction
                    sqlTransaction.Rollback();
                }
            }
        }
    }
}
