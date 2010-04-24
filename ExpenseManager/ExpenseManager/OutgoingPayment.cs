using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager
{
    class OutgoingPayment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Payee { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
    }
}
