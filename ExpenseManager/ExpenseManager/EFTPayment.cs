using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager
{
    class EFTPayment : OutgoingPayment
    {
        public int EFTId { get; set; }
        public string Account { get; set; }
        public string PaymentReceipt { get; set; }
    }
}
