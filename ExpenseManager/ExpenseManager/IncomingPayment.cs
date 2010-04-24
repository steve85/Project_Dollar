using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager
{
    class IncomingPayment
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string Payer { get; set; }
        public string Status { get; set; }
    }
}
