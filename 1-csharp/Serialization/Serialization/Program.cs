using Newtonsoft.Json;
using Serialization.DataModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // for your program, the starting directory is bin/Debug/netcoreapp3.
            string filePath = "../../../data.json";

            List<PlayerStats> data;
            try
            {
                string initialJson = await File.ReadAllTextAsync(filePath);
               data = JsonConvert.DeserializeObject<List<PlayerStats>>(initialJson);
            }
            catch (FileNotFoundException)
            {
                data = GetInitialData();

            }

            data[0].Name += "+";
            string json = ConvertToJson(data);

            await WriteStringToFileAsync(filePath, json);

            // at this point, the file is definitely written
        }

        // How to write in-code documentation for method that will appear when hovering over the method. Three forward slashes will init the documentation template.
        /// <summary>
        /// serialize the objects into a string in JSON format
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="json"></param>
        /// <returns>serialized JSON</returns>
        private async static Task WriteStringToFileAsync(string filePath, string json)
        {
            //await File.WriteAllTextAsync(filePath, json);
            //for more control over the file I/O, we would usually open a FileStream object

            //the CLR manages the memory for all the CLR objects with garbage collection
            //  (otherwise, there would be memory leaks any time I failed to manually clean up any object)

            //any time you have .NET code open of access some resource OUTSIDE the CLR
            //  (like the hard drive), you do need to manually tell it when you are done to avoid problems.
            //the IDisposable interface is implemented by any class which you need to do this for.

            //FileStream fileStream = null;

            try
            {
                //fileStream = new FileStream(filePath, FileMode.Create);
                //if you are fine wit the resource not being disposed until the variable goes out of scope...
                // you can use this for of the statement

                using var fileStream = new FileStream(filePath, FileMode.Create);

                //fileStream. //pretend the code has been finished. 
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
            /*finally
            {
                //if (fileStream != null)
                //{
                //    fileStream.Dispose(); //what if an exception is thrown at any point beforehand? The resourse would never be disposed of
                //}
                fileStream?.Dispose();
                // The C# has an operator "?." which calls a method (or accesses a property/field/etc.)
                //but only if the thing to the left is not null.

            }*/
            //C# has a "using statement" to replace the boilerplate "resource = null, try, finally, resource.Dispose"
            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //} // right here, at the closing brace, it effectively finally
            
        }
        // if you do not await the task, there is no way of knowing if the task completed or not
        //When doing something async:
        //1. Call the Async version of whatever library method
        //2. await that Task
        //3. mark the current method with the async modifier
        //4. if the mehtod returns type T, change it to return type Task<T>
        //   if it returns void, change it to the return type Task
        //5. as a matter of convention, add the Async suffix to your method name
        //(continue again from step 1 on the parts of your code that are now broken)
        // as an exception to the rules, do NOT rename the Main method, as your program would not run at the that point

        /// <summary>
        /// Converts data to a JSON format. Formatted to be in an Intented, readable format
        /// </summary>
        /// <param name="data"></param>
        /// <returns>data in a JSON format</returns>
        private static string ConvertToJson(List<PlayerStats> data)
        {
            //in .NET Core, we use a program called NuGet
            //Nuget is used to resolve dependencies and download them from regisries (usually NuGet.org)
            // Make sure to save after any dependency modification to be sure that everything had saved

            return JsonConvert.SerializeObject(data, Formatting.Indented);

            // can customized how the object is serialized with optional parameters to the above method or with attributes on the PlayerStats class and properties themselves. 
        }

        private static List<PlayerStats> GetInitialData()
        {

            // This is messy and should not be written like this.
            /*
                var x = new PlayerStats();
                x.ArcLocations = null;
                x.FreeThrowPercentage = 1000;
                x.PointsPerGame = 12;
             */
            // C# has property initializer syntax
            var x = new PlayerStats
            {
                ArcLocations = null,
                FreeThrowPercentage = 1000,
                PointsPerGame = 12
            };

            return new List<PlayerStats> 
            {
                new PlayerStats
                {
                    Name = "Lebron James",
                    FreeThrowPercentage = 65,
                    PointsPerGame = 25,
                    ArcLocations = new Dictionary<int, double> 
                    {
                        [-150] = 30,
                        [-120] = 30,
                        [-90] = 30
                    }
                },
                new PlayerStats(),
                new PlayerStats()
            };
        }
    }
}
