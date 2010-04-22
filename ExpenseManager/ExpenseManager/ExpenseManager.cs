using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ExpenseManager
{
    class ExpenseManager
    {
        private List<GeneralExpense> _lstGeneralExpenses = new List<GeneralExpense>();
        private List<Bill> _lstBills = new List<Bill>();
        private List<Debt> _lstDebts = new List<Debt>();
        private static string _connectionString = ConfigurationSettings.AppSettings["connectionString"].ToString();
        // If date retrieved from database is null create object with this data 01/01/9999
        private static DateTime _dtNullDate = new DateTime(9999, 1, 1);
        
        public ExpenseManager()
        {
            // ### Debug
         //   Console.WriteLine("Expense Manager Initialised");
            this.LoadData();
        }

        #region Load Data Method
        private void LoadData()
        {
            // ### Debug
         //   Console.WriteLine("Loading Data...\n");

            // SQL Queries
            string selectExpenses = "SELECT dbo.GeneralExpense.*, dbo.Bill.* FROM GeneralExpense LEFT JOIN Bill ON GeneralExpense.Id = Bill.ExpenseId";
            string selectDebts = "SELECT dbo.Debt.* FROM dbo.Debt";
            using (SqlConnection loadConn = new SqlConnection(_connectionString))
            {
                try
                {
                    loadConn.Open();
                    SqlCommand cmdGetValues = new SqlCommand(selectExpenses, loadConn);
                    SqlDataReader dataReader = cmdGetValues.ExecuteReader();
                    while (dataReader.Read())
                    {
                        // Determine if data is general expense or bill
                        if (dataReader.IsDBNull(8))
                        {
                            // Create expense objects
                            GeneralExpense expense = new GeneralExpense();
                            expense.Id = dataReader.GetInt32(0);
                            expense.Name = dataReader.GetString(1);
                            expense.Description = dataReader.GetString(2);
                            expense.Value = dataReader.GetDouble(3);
                            expense.DateReceived = dataReader.GetDateTime(4);
                            expense.IsPaid = dataReader.GetBoolean(5);
                            expense.DatePaid = dataReader.IsDBNull(6) ? _dtNullDate : dataReader.GetDateTime(6);
                            expense.IsOutstanding = dataReader.GetBoolean(7);
                            _lstGeneralExpenses.Add(expense);
                        }
                        else
                        {
                            // Create bill objects
                            Bill bill = new Bill();
                            bill.Id = dataReader.GetInt32(0); 
                            bill.Name = dataReader.GetString(1);
                            bill.Description = dataReader.GetString(2);
                            bill.Value = dataReader.GetDouble(3);
                            bill.DateReceived = dataReader.GetDateTime(4);
                            bill.IsPaid = dataReader.GetBoolean(5);
                            bill.DatePaid = dataReader.IsDBNull(6) ? _dtNullDate : dataReader.GetDateTime(6);
                            bill.IsOutstanding = dataReader.GetBoolean(7);
                            bill.BillId = dataReader.GetInt32(8);
                            bill.Issuer = dataReader.GetString(10);
                            bill.ReferenceNo = dataReader.GetString(11);
                            _lstBills.Add(bill);
                        }
                    }
                    dataReader.Close();
                    cmdGetValues.CommandText = selectDebts;
                    dataReader = cmdGetValues.ExecuteReader();
                    while (dataReader.Read())
                    {
                        // Create debt objects
                        Debt debt = new Debt();
                        debt.Id = dataReader.GetInt32(0);
                        debt.ExpenseId = dataReader.GetInt32(1);
                        debt.PersonOwing = dataReader.GetString(2);
                        debt.AmountOutstanding = dataReader.GetDouble(3);
                        debt.IsPaid = dataReader.GetBoolean(4);
                        debt.DatePaid = dataReader.IsDBNull(5) ? _dtNullDate : dataReader.GetDateTime(5);
                        _lstDebts.Add(debt);
                    }
                    
                    dataReader.Dispose();
                    cmdGetValues.Dispose();
                    loadConn.Close();
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
#endregion

        #region List Accessor Methods
        public List<GeneralExpense> GetListGeneralExpense()
        {
            return _lstGeneralExpenses;
        }

        public List<Bill> GetListBill()
        {
            return _lstBills;
        }

        public List<Debt> GetListDebt()
        {
            return _lstDebts;
        }
        #endregion

        #region List Add Value Methods
        public void AddToListGeneralExpense(GeneralExpense newGeneralExpense)
        {
            _lstGeneralExpenses.Add(newGeneralExpense);
        }

        public void AddToListBill(Bill newBill)
        {
            _lstBills.Add(newBill);
        }

        public void AddToListDebt(Debt newDebt)
        {
            _lstDebts.Add(newDebt);
        }
        #endregion

        #region Add Object Methods
        public void AddNewGeneralExpense()
        {
            AddGeneralExpense addGeneralExpense = new AddGeneralExpense(this);
        }

        public void AddNewBill()
        {

        }

        public void AddNewDebt()
        {

        }
        #endregion
    }
}
