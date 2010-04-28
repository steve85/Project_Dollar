using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace ExpenseManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
             */
 
            /*
             *  Changed ouput to Console Application (via Project Properties 
             *  while I build the application framework
             */
            ConsoleMenu.Menu();
        }
    }
}
