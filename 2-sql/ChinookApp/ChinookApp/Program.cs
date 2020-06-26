using ChinookApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ChinookApp
{
    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory 
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static readonly DbContextOptions<ChinookContext> options = new DbContextOptionsBuilder<ChinookContext>()
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .Options;

        static void Main(string[] args)
        {

            /*
             dotnet ef dbcontext scaffold "Server=tcp:bertrand-batch-2006.database.windows.net,1433;Initial Catalog=Chinook;Persist Security Info=False;
            User ID={db username};Password={db Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" 
            {dependency being used for translation} --startup-project {path to ConsoleApp from DataAccess} --force --output-dir Model

            dotnet ef dbcontext scaffold "Server=tcp:bertrand-batch-2006.database.windows.net,1433;Initial Catalog=Chinook;Persist Security Info=False;
            User ID=josh;Password=Thisisthepassword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" 
            Microsoft.EntityFrameworkCore.SqlServer --startup-project ../ChinookApp --force --output-dir Model

            Remember when generating code, go to the <db>Context.cs file, and delete the OnConfig class due to it having the password for the db included in the auto generation
             */

            DisplayData();

            Console.WriteLine("\nAdding some data...");
            AddSomeDataFromUserInput();

            DisplayData();

            Console.WriteLine("\nUpdating some data...");
            UpdateSomeData();

            DisplayData();

            Console.WriteLine("\nDeleting some data...");
            DeleteSomeData();

            DisplayData();


        }

        private static void DeleteSomeData()
        {
            using var context = new ChinookContext(options);

            // In order to properly find and delete the data, a select query will have to be made to find it
            var firedEmployee = context.Exemployee
                .Where(e => e.Id > 1)
                .ToList();

            foreach (var emp in firedEmployee)
            {
                context.Remove(emp);
            }

            context.SaveChanges();
        }

        private static void UpdateSomeData()
        {
            using var context = new ChinookContext(options);

            var employee = context.Exemployee.First(a => a.FirstName == "Amanda");
            employee.FirstName = "Ellen";
            context.SaveChanges();
        }

        private static void AddSomeDataFromUserInput()
        {

            //before allowing userdata to be implemented into the DB, you would want to add some input validation to ensure that the user is not entering anything malicious.
            using var context = new ChinookContext(options);

            //This will throw an error currently due to the Id not auto-incrementing in the DB itself unless Id is changed to something not currently in the Db. 
            Exemployee emp1 = new Exemployee {Id = 3, FirstName = "Amanda", LastName = "Ripley", Ssn = "1234447809", DeptId = 2 };

            var newEmployee = context.Add(emp1);//multiple entries can be added to the db by using the AddRange() method and supplying a Collection
            context.SaveChanges();
            Console.WriteLine("New Employee has been added...");
        }

        public static void DisplayData()
        {
            using var context = new ChinookContext(options);

            var employees = context.Exemployee.ToList();
            Console.WriteLine("-----Displaying all employees-----");
            foreach (var emp in employees)
            {
                Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
            }

            //var salespeople = context.Employee
            //    .Where(e => e.Title.Contains("sales"))
            //    .ToList();

            //foreach (var person in salespeople)
            //{
            //    Console.WriteLine($"\t{person.Title} - {person.FirstName} {person.LastName}");
            //}
        }
    }
}
