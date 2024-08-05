using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppDZ8
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1");
            List<Employee> list = new List<Employee>
            {
             new Employee {Name = "Slava", Department = "Экономический", Salary = 455000.6, PositionLevel = 2},
             new Employee {Name = "Sergei", Department = "Проектный", Salary = 425528.4, PositionLevel = 1},
             new Employee {Name = "Nikolai", Department = "Экономический", Salary = 495569.2, PositionLevel = 1},
             new Employee {Name = "Vova", Department = "Производственный", Salary = 375698.3, PositionLevel = 2},
             new Employee {Name = "Tania", Department = "Экономический", Salary = 448235.9, PositionLevel = 3},
             new Employee {Name = "Bob", Department = "Проектный", Salary = 421239.7, PositionLevel = 2},
             new Employee {Name = "Tom", Department = "Проектный", Salary = 415468.2, PositionLevel = 3},
             new Employee {Name = "Dasha", Department = "Проектный", Salary = 409214.7, PositionLevel = 4},
             new Employee {Name = "Tom", Department = "Производственный", Salary = 386125.5, PositionLevel = 1},
             new Employee {Name = "Dima", Department = "Производственный", Salary = 371561.1, PositionLevel = 3},
             new Employee {Name = "Lada", Department = "Производственный", Salary = 363587.3, PositionLevel = 4},
             new Employee {Name = "Mike", Department = "Производственный", Salary = 358643.6, PositionLevel = 5}

            };
            Employee.Print(ref list);

            Console.WriteLine("Задача 2");

            List<TransactionRu> list2 = new List<TransactionRu>()
            {
             new TransactionRu (1, 128.2f,new DateTime (2024, 7, 20)),
             new TransactionRu (2, 4563.58f, new DateTime (2024, 6, 14)),
             new TransactionRu (3, 2452.81f, new DateTime (2024, 2, 02)),
             new TransactionRu (4, 563.74f, new DateTime (2024, 4, 12)),
             new TransactionRu (5, 1452.72f, new DateTime (2024, 6, 22)),
             new TransactionRu (6, 4578.59f, new DateTime (2024, 2, 07)),
             new TransactionRu (7, 736.28f, new DateTime (2024, 6, 21)),
             new TransactionRu (8, 2145.99f, new DateTime (2024, 5, 17))
            };
            DateTime dt1 = new DateTime(2024, 6, 01);
            DateTime dt2 = new DateTime(2024, 7, 23);
            var tel = new Trans<TransactionRu>();
            Console.WriteLine(tel.Swap(ref list2, dt1, dt2));


            Console.WriteLine("Задача 3");

            List<object> objects = new List<object>
            {
            new Foo { Id = Guid.NewGuid(), Name = "Apple", Description = "A fruit" },
            new Foo { Id = Guid.NewGuid(), Name = "Banana", Description = "Yellow fruit" },
            new Foo { Id = Guid.NewGuid(), Name = "Grapes", Description = "Small fruit" },
            new Bar { Id = Guid.NewGuid(), Title = "Lorem", Description = "Lorem ipsum dolor" },
            new Bar { Id = Guid.NewGuid(), Title = "Ipsum", Description = "Ipsum dolor sit" }
            };

            foreach (var emp in CalculateAverageStringLength(ref objects)) // Цикл формирования словаря по условию задачи
                Console.WriteLine($"\'{emp.Key}\': {emp.Value}");
        }
        static Dictionary<string, double> CalculateAverageStringLength(ref List <object> list)
            {   Dictionary<string, double> result = new Dictionary<string, double>();
                var result1 = list.Select (x => x.GetType().Name);
                result1 = result1.Distinct();
                foreach (var emp in result1) 
                {
                    var number = list.Where(x => x.GetType().Name == emp);
                    var number1 = from e in number
                                  from t in e.GetType().GetProperties() 
                          where t.PropertyType.Name == "String"
                          select t.GetValue(e).ToString().Length;

                    result.Add(emp, (double)number1.Sum() / number.Count());
                }
                return result;
        }
    }
}
