using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = JsonConvert.DeserializeObject<List<int>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json")));
            int totalFuelRequirement = FuelRequirementRecursive(data);
            Console.WriteLine(totalFuelRequirement);
            Console.ReadLine();
        }

        private static int FuelRequirement(List<int> data)
        {
            var totalFuelRequirement = 0;
            foreach (var module in data)
            {
                totalFuelRequirement += CalculateFuel(module);
            }
            return totalFuelRequirement;
        }

        private static int CalculateFuel(int module)
        {
            return (int)Math.Floor((double)module / 3) - 2;
        }

        private static int FuelRequirementRecursive(List<int> data)
        {
            var totalFuelRequirement = 0;
            foreach (var module in data)
            {
                var moduleRequirement = module;
                while (moduleRequirement >= 0)
                {
                    moduleRequirement = CalculateFuel(moduleRequirement);
                    if(moduleRequirement > 0)
                        totalFuelRequirement += moduleRequirement;
                }
            }
            return totalFuelRequirement;
        }
    }
}
