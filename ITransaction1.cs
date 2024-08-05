using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleAppDZ8
{
   public interface ITransaction
    {
        int TransactionId { get; set; }
        float Amount { get; set; }
        DateTime Date { get; set; }



    }
}
