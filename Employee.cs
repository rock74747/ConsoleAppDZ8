using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDZ8
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public int PositionLevel { get; set; }
        public static void Print(ref List<Employee> list)
        {
            var companies = list.GroupBy(p => p.Department).Select(g => new { Department = g.Key, sal = g.Average(p => p.Salary) });

            foreach (var emp in companies)
            {
                Console.WriteLine($"Отдел {emp.Department} : {emp.sal} руб.");


            }

            double d = companies.Max(p => p.sal);
            var der = companies.SingleOrDefault(p => p.sal == d);
            Console.WriteLine($"Максимальная средняя зарплата:  {der}");

            var companies1 = list.GroupBy(p => p.Department).Select(g => new { Department = g.Key, name = g.Select(u => u).Where(v => v.Salary > g.Average(v => v.Salary)) });
            Console.WriteLine($"Работники с зарплатой выше средней по всем отделам:\n");
            foreach (var emp in companies1)
            {
                Console.WriteLine($"Отдел {emp.Department}");
                foreach (var employee in emp.name)
                {
                    Console.WriteLine($"{employee.Name} - {employee.Salary}");
                }
                Console.WriteLine();
            }

            var companies2 = list.GroupBy(p => p.PositionLevel).Select(g => new { PositionLevel = g.Key, number = g.Sum(v => v.Salary) });
            foreach (var emp in companies2)
            {
                Console.WriteLine($"Суммарная зарплата для каждого уровня должности:\n" +
                    $"Уровень должности {emp.PositionLevel} - {emp.number} руб.");
            }
        }
    }
}
