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

            

            
        }

        public static void DisplayData()
        {
            using var context = new ChinookContext(options);

            var salespeople = context.Employee
                .Where(e => e.Title.Contains("sales"))
                .ToList();

            foreach (var person in salespeople)
            {
                Console.WriteLine($"\t{person.Title} - {person.FirstName} {person.LastName}");
            }
        }
    }
}
