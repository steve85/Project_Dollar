using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager
{
    class Bill : GeneralExpense
    {
        #region Properties
        public int ExpenseId { get; set; }
        public string Issuer { get; set; }
        public string ReferenceNo { get; set; }
        #endregion

        public string GetBillDetails()
        {
            StringBuilder billDetails = new StringBuilder();
            billDetails.AppendFormat("Bill\t{0}", this.Issuer);
            billDetails.Append("\n\t");
            billDetails.AppendFormat("Amount: {0}", this.Value);
            billDetails.Append("\n\t");
            billDetails.AppendFormat("Reference: {0}", this.ReferenceNo);
            return billDetails.ToString();
        }
    }
}
