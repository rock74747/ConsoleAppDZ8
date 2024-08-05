using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAppDZ8
{
    public class TransactionRu : ITransaction
    {
        public int TransactionId { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }

        public TransactionRu (int transactionId, float amount, DateTime date)
        {
            TransactionId = transactionId;
            Amount = amount;
            Date = date;
        }
    }
}

    
