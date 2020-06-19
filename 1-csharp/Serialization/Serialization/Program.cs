using Newtonsoft.Json;
using Serialization.DataModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // for your program, the starting directory is bin/Debug/netcoreapp3.
            string filePath = "../../../data.json";

            List<PlayerStats> data;
            try
            {
                string initialJson = File.ReadAllText(filePath);
               data = JsonConvert.DeserializeObject<List<PlayerStats>>(initialJson);
            }
            catch (FileNotFoundException)
            {
                data = GetInitialData();

            }

            data[0].Name += "+";
            string json = ConvertToJson(data);

            WriteStringToFile(filePath, json);
        }

        // How to write in-code documentation for method that will appear when hovering over the method. Three forward slashes will init the documentation template.
        /// <summary>
        /// serialize the objects into a string in JSON format
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="json"></param>
        /// <returns>serialized JSON</returns>
        private static void WriteStringToFile(string filePath, string json)
        {
            File.WriteAllText(filePath, json);
        }

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
