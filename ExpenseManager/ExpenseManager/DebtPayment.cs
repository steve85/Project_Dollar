using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager
{
    class DebtPayment
    {
        public int Id { get; set; }
        public int DebtId { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
    }
}
