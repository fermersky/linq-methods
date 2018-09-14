using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // TaskOne();
            TaskTwo();


            Console.WriteLine();

        }

        public static void TaskOne()
        {
            List<Person> persons = new List<Person>()
            {
                new Person(){ Name = "Andrey", Age = 24, City = "Kyiv" },
                new Person(){ Name = "Liza", Age = 18, City = "Moscow" },
                new Person(){ Name = "Oleg", Age = 15, City = "London" },
                new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
                new Person(){ Name = "Sergey", Age = 32, City = "Kyiv" },
            };

            // Выбрать людей, старших 25 лет.
            Console.WriteLine("\n------First task-----\n");

            var oldertwentyfive = from p in persons where p.Age > 25 select p;
            foreach (var item in oldertwentyfive)
                Console.WriteLine(item.Name + ' ' + item.City + ' ' + item.Age);

            Console.WriteLine();

            var oldertwentyfivesec = persons.Where(p => p.Age > 25);
            foreach (var item in oldertwentyfivesec)
                Console.WriteLine(item.Name + ' ' + item.City + ' ' + item.Age);

            // Выбрать людей, проживающих не в Киеве.

            Console.WriteLine("\n------Second task-----\n");

            var notKyiv = from p in persons where p.City != "Kyiv" select p;
            foreach (var item in notKyiv)
                Console.WriteLine(item.Name + ' ' + item.City + ' ' + item.Age);

            Console.WriteLine();

            var notKyivsec = persons.Where(p => p.City != "Kyiv");
            foreach (var item in notKyivsec)
                Console.WriteLine(item.Name + ' ' + item.City + ' ' + item.Age);

            // Выбрать имена людей, проживающих в Киеве.

            Console.WriteLine("\n------Third task-----\n");

            var Kyiv = from p in persons where p.City == "Kyiv" select p;
            foreach (var item in Kyiv)
                Console.WriteLine(item.Name);

            Console.WriteLine();

            var Kyivsec = persons.Where(p => p.City == "Kyiv");
            foreach (var item in Kyivsec)
                Console.WriteLine(item.Name);

            // Выбрать людей старших 35 лет с именем Sergey.

            Console.WriteLine("\n------Fourth task-----\n");

            var Sergey = from p in persons where (p.Age > 35) && (p.Name == "Sergey") select p;
            foreach (var item in Sergey)
                Console.WriteLine(item.Name + ' ' + item.City + ' ' + item.Age);

            Console.WriteLine();

            var Sergeysec = persons.Where(p => p.Age > 35 && p.Name == "Sergey");
            foreach (var item in Sergeysec)
                Console.WriteLine(item.Name + ' ' + item.City + ' ' + item.Age);

            // Выбрать людей, проживающих в Москве.

            Console.WriteLine("\n------Fiveth task-----\n");

            var Moscow = from p in persons where p.City == "Moscow" select p;
            foreach (var item in Moscow)
                Console.WriteLine(item.Name + ' ' + item.City + ' ' + item.Age);

            Console.WriteLine();

            var Moscowsec = persons.Where(p => p.City == "Moscow");
            foreach (var item in Moscowsec)
                Console.WriteLine(item.Name + ' ' + item.City + ' ' + item.Age);
        }
        public static void TaskTwo()
        {
            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
            };

            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee()
                { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee()
                { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee()
                { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee()
                { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee()
                { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee()
                { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepId = 4 }
            };

            // Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке.

            Console.WriteLine("\n------First task-----\n");

            var UaButNotDnr = from e in employees join d in departments on e.DepId equals d.Id
                              where d.Country == "Ukraine" && d.City != "Donetsk"
                              select new { e.FirstName, e.LastName, d.Country };

            foreach (var item in UaButNotDnr)
                Console.WriteLine(item.FirstName + ' ' + item.LastName + ' ' + item.Country);

            Console.WriteLine();

            var UaButNotDnrSec = employees.Join(
                departments,
                e => e.DepId,
                d => d.Id,
                (e, d) => new { e.FirstName, e.LastName, d.Country, d.City }
             ).Where(d => d.Country == "Ukraine" && d.City != "Donetsk");


            foreach (var item in UaButNotDnrSec)
                Console.WriteLine(item.FirstName + ' ' + item.LastName);

            // Вывести список стран без повторений.

            Console.WriteLine("\n------Second task-----\n");

            var dist = (from d in departments select d.Country).Distinct();
            foreach (var item in dist)
                Console.WriteLine(item);

            Console.WriteLine();

            var distsec = departments.Select(d => d.Country).Distinct();
            foreach (var item in distsec)
                Console.WriteLine(item);

            // Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет.

            Console.WriteLine("\n------Third task-----\n");

            var topthree = (from e in employees where e.Age > 25 select e).Take(3);
            foreach (var item in topthree)
                Console.WriteLine(item.FirstName + ' ' + item.LastName);

            Console.WriteLine();

            var topthreesec = employees.Where(e => e.Age > 25).Take(3);
            foreach (var item in topthreesec)
                Console.WriteLine(item.FirstName + ' ' + item.LastName);

            // Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 21 года

            Console.WriteLine("\n------Fourth task-----\n");

            var oldierthen23 = from e in employees
                               join d in departments on e.DepId equals d.Id
                               where e.Age > 21 && d.City == "Kyiv"
                               select new { e.FirstName, e.LastName, d.Country };

            foreach (var item in oldierthen23)
                Console.WriteLine(item.FirstName + ' ' + item.LastName);

            Console.WriteLine();

            var oldierthen23sec = employees.Join(
               departments,
               e => e.DepId,
               d => d.Id,
               (e, d) => new { e.FirstName, e.LastName, d.Country, e.Age, d.City }
            ).Where(e => e.Age > 21).Where(d => d.City == "Kyiv");

            foreach (var item in oldierthen23sec)
                Console.WriteLine(item.FirstName + ' ' + item.LastName);


            Console.WriteLine();

        }




        public static void MethodLinqOne()
        {
            string[] countries = { "usa", "ua", "rus" };

            var result = from item in countries where item.StartsWith("u") select item;

            foreach (var item in result)
                Console.WriteLine(item);

            result = (from c in countries where c.Length > 2 orderby c.Length descending select c).Distinct();
            // var max = collection.Select(item => item.Price).Max() select all prices 
            // var elem = collections.where(p => p.Price == max).FirstOrDefault();
            // var elem = collections.FirstOrDefault(p => p.Price == max)
            // products.max(p => p.price)

            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
