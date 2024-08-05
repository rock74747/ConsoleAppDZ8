using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDZ8
{
    public class Trans <T> where T : ITransaction
    {

        public double Swap (ref List<T> stat,  DateTime Date1, DateTime Date2) 
        {
         

            var action = stat.Where(v => v.Date < Date2 && v.Date > Date1).Sum(g => g.Amount);
            if (action == 0) 
            {
                Console.WriteLine("Выберите иной период. В данный период транзакций нет");
                return 0;
            }
            double Summ = Math.Round(action, 2);
            return Summ;
        }
    }
}

