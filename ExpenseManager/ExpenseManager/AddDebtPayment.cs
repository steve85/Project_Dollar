using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManager
{
    class AddDebtPayment
    {
        private ExpenseManager _expenseManager;
        private Debt _debt;
        private DebtPayment _debtPayment; // ### May not need this property

        public AddDebtPayment(ExpenseManager inExpenseManager, Debt inDebt, DebtPayment inDebtPayment)
        {
            this._expenseManager = inExpenseManager;
            this._debt = inDebt;
            this._debtPayment = inDebtPayment;
            // ### Call here to load the form
        }

        private void AddNewPayment(DebtPayment newDebtPayment)
        {
            // ### Logic to update the debt object            
        }
    }
}
