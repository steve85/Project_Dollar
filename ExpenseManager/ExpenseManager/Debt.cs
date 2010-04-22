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
        public double AmountOutstanding { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DatePaid { get; set; }
        #endregion

        public string GetDebtDetails()
        {
            // Get the details for the listbox
            StringBuilder debtDetails = new StringBuilder();
         //   debtDetails.AppendFormat("{0} owes ${1} for expense {2}.", this.PersonOwing, this.AmountOutstanding,this.ExpenseId);
            debtDetails.AppendFormat("Debt\t{0}", this.PersonOwing);
            debtDetails.Append("\n\t");
            debtDetails.AppendFormat("Amount: {0}", this.AmountOutstanding);
            debtDetails.Append("\n\t");
            debtDetails.AppendFormat("ExpenseId: {0}", this.ExpenseId);
            return debtDetails.ToString();
        }
    }
}
