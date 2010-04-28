using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager
{
    class Debt
    {
        #region Properties
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string PersonOwing { get; set; }
        // public double Amount {get; set;} // ### Add this later on the original debt amount
        public double AmountOutstanding { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DatePaid { get; set; } 
        #endregion

        public string GetDebtDetails()
        {
            StringBuilder debtDetails = new StringBuilder();
            debtDetails.AppendFormat("Debt\t{0}", this.PersonOwing);
            debtDetails.Append("\n\t");
            debtDetails.AppendFormat("Amount: {0}", this.AmountOutstanding);
            debtDetails.Append("\n\t");
            debtDetails.AppendFormat("ExpenseId: {0}", this.ExpenseId);
            return debtDetails.ToString();
        }

        // Returns a string with the formatted date DatePaid
        public string GetDatePaid()
        {
            return string.Format("{0:dd/MM/yyyy", this.DatePaid);
        }
    }
}
