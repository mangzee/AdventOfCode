using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2
{
    public class Element
    {
        public int Value;
        public bool IsVisited;
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = JsonConvert.DeserializeObject<List<int>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.json")));
            Console.WriteLine(Instruction(data, 12, 2));
            for (int i = 0; i < 99; i++)
                for (int j = 0; j < 99; j++)
                {
                    var output = Instruction(data, i, j);
                    if (output == 19690720)
                    {
                        Console.WriteLine($"Input 1: {i} Input 2 {j}");
                        Console.WriteLine(100 * i + j);
                    }
                }

            Console.ReadLine();
        }

        private static int Instruction(List<int> data, int input1, int input2)
        {
            var tempData = new List<int>(data)
            {
                [1] = input1,
                [2] = input2
            };
            for (var index = 0; index < tempData.Count; index += 4)
            {
                var element = tempData[index];
                if (element == 99)
                    break;
                var input1Index = tempData[index + 1];
                var input2Index = tempData[index + 2];
                var outputIndex = tempData[index + 3];
                var input1Data = tempData[input1Index];
                var input2Data = tempData[input2Index];
                int output;
                if (element == 1)
                {
                    output = input1Data + input2Data;
                    tempData[outputIndex] = output;
                }
                else if (element == 2)
                {
                    output = input1Data * input2Data;
                    tempData[outputIndex] = output;
                }
            }
            //Console.WriteLine(tempData[0]);
            return tempData[0];
        }
    }
}