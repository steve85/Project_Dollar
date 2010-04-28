using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager
{
    class GeneralExpense
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime DateReceived { get; set; } 
        public bool IsPaid { get; set; }
        public DateTime DatePaid { get; set; }
        public bool IsOutstanding { get; set; }
        #endregion


        public string GetExpenseDetails()
        {      
            StringBuilder expenseDetails = new StringBuilder();
            expenseDetails.AppendFormat("Expense\t{0}", this.Name);
            expenseDetails.Append("\n\t");
            expenseDetails.AppendFormat("Description: {0}", this.Description);
            expenseDetails.Append("\n\t");
            expenseDetails.AppendFormat("Amount: {0}", this.Value);
            return expenseDetails.ToString();
        }

        public string GetShortDetails()
        {
            StringBuilder shortDetails = new StringBuilder();
            shortDetails.AppendFormat("{0}. {1} - ${2}", this.Id, this.Name, this.Value);
            return shortDetails.ToString();
        }

        // Returns a string with the formatted date DateReceived
        public string GetDateReceived()
        {
            return string.Format("{0:dd/MM/yyyy", this.DateReceived);
        }

        // Returns a string with the formatted date DatePaid
        public string GetDatePaid()
        {
            return string.Format("{0:dd/MM/yyyy" , this.DatePaid);
        }
    }
}
